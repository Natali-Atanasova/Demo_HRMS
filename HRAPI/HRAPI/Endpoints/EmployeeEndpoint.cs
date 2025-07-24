using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HRAPI.Data;
using HRAPI.Entities;

namespace HRAPI.Endpoints
{
    public static class EmployeeEndpoint
    {
        public static RouteGroupBuilder MapEmployeeEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("employee")
                           .WithParameterValidation()
                           .RequireAuthorization("EmployeePolicy");

            // GET /employee/profile
            group.MapGet("/profile", async (ClaimsPrincipal user, HRSysContext db) =>
            {
                var username = user.Identity?.Name;
                var userRecord = await db.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (userRecord == null) return Results.NotFound();
                var employee = await db.Employees
                    .Include(e => e.Department)
                    .FirstOrDefaultAsync(e => e.Id == userRecord.EmployeeId);

                return employee is null ? Results.NotFound() : Results.Ok(employee);
            });

            return group;
        }
    }
}
