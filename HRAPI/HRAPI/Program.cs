using HRAPI.Auth;
using HRAPI.Data;
using HRAPI.Endpoints;
using HRAPI.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1 Configure Services

// Add DbContext
builder.Services.AddDbContext<HRSysContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyHRMSDb")));

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Add JSON Options (to prevent cycles)
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Add Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EmployeePolicy", policy => policy.RequireRole("Employee", "Manager", "HR Admin"));
    options.AddPolicy("ManagerPolicy", policy => policy.RequireRole("Manager", "HR Admin"));
    options.AddPolicy("HRAdminPolicy", policy => policy.RequireRole("HR Admin"));
});

// Add CORS (for Blazor)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7176") // Blazor app address
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMS API", Version = "v1" });
    // JWT Auth support in Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter JWT Bearer token *only*",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// 2 Middleware and Initialization

app.UseCors();

// Run automatic DB migration 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<HRSysContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"DB Migration error: {ex.Message}");
    }
}

app.MapGet("/", () => "Database is working!");

// Add authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Map  endpoints
app.MapAuthEndpoints();
app.MapEmployeeEndpoints();
app.MapManagerEndpoints();
app.MapHrAdminEndpoints();

// 3 Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRMS API v1");
    });
}

app.Run();

public partial class Program { } // Needed for WebApplicationFactory
