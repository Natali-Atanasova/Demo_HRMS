using HRAPI.Auth;
using HRAPI.Data;
using HRAPI.Entities;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async (UserDto userDto, HRSysContext db, IConfiguration config) =>
        {
            if (await db.Users.AnyAsync(u => u.Username == userDto.Username))
                return Results.BadRequest("Username already exists.");

            // Ensure EmployeeId exists!
            var employee = await db.Employees.FindAsync(userDto.EmployeeId);
            if (employee == null)
                return Results.BadRequest("Invalid EmployeeId. You must create an Employee first.");

            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Role = userDto.Role,
                EmployeeId = userDto.EmployeeId,
                Employee = employee
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Results.Ok("Registered");
        });

        app.MapPost("/login", async (LoginDto login, HRSysContext db, IConfiguration config) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Username == login.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
                return Results.Unauthorized();

            var token = JwtHelpers.GenerateJwtToken(user, config);
            return Results.Ok(new { token });
        });
    }
}
