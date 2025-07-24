using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HRAPI.Data;
using HRAPI.Entities;

namespace HRAPI.Endpoints
{
    public static class ManagerEndpoints
    {
        public static RouteGroupBuilder MapManagerEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("manager")
                           .WithParameterValidation()
                           .RequireAuthorization("ManagerPolicy");

            // GET /manager/department
            group.MapGet("/department", async (ClaimsPrincipal user, HRSysContext db) =>
            {
                var username = user.Identity?.Name;
                var userRecord = await db.Users
                    .Include(u => u.Employee)
                    .ThenInclude(e => e.Department)
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (userRecord == null || userRecord.Employee == null)
                    return Results.NotFound();

                var manager = userRecord.Employee;

                var employees = await db.Employees
                    .Include(e => e.Department)
                    .Where(e => e.DepartmentId == manager.DepartmentId)
                    .ToListAsync();

                return Results.Ok(new { manager, employees });
            });

            // POST /manager/employee - option i block by frontend, can be added if needed
            group.MapPost("/employee", async (Employee newEmployee, HRSysContext db, ClaimsPrincipal user) =>
            {
                var username = user.Identity?.Name;
                var userRecord = await db.Users
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (userRecord == null || userRecord.Employee == null)
                    return Results.BadRequest("Manager not found.");

                // Force new employee into the manager's department
                newEmployee.DepartmentId = userRecord.Employee.DepartmentId;

                db.Employees.Add(newEmployee);
                await db.SaveChangesAsync();
                db.Entry(newEmployee).Reference(e => e.Department).Load();
                return Results.Created($"/manager/employee/{newEmployee.Id}", newEmployee);
            });

            // PUT /manager/employee/{id}
            group.MapPut("/employee/{id}", async (int id, Employee updatedEmployee, ClaimsPrincipal user, HRSysContext db) =>
            {
                var username = user.Identity?.Name;
                var userRecord = await db.Users
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (userRecord?.Employee == null)
                    return Results.Forbid();

                var manager = userRecord.Employee;

                var employee = await db.Employees.FirstOrDefaultAsync(e => e.Id == id && e.DepartmentId == manager.DepartmentId);

                if (employee is null)
                    return Results.NotFound();

                employee.FirstName = updatedEmployee.FirstName ?? employee.FirstName;
                employee.LastName = updatedEmployee.LastName ?? employee.LastName;
                employee.Email = updatedEmployee.Email ?? employee.Email;
                employee.JobTitle = updatedEmployee.JobTitle ?? employee.JobTitle;
                employee.Salary = updatedEmployee.Salary != 0 ? updatedEmployee.Salary : employee.Salary;
                employee.DepartmentId = updatedEmployee.DepartmentId != 0 ? updatedEmployee.DepartmentId : employee.DepartmentId;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            // DELETE /manager/employee/{id} - option i block by frontend, can be added if needed
            group.MapDelete("/employee/{id}", async (int id, ClaimsPrincipal user, HRSysContext db) =>
            {
                var username = user.Identity?.Name;
                var userRecord = await db.Users
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (userRecord?.Employee == null)
                    return Results.Forbid();

                var manager = userRecord.Employee;

                var employee = await db.Employees.FirstOrDefaultAsync(e => e.Id == id && e.DepartmentId == manager.DepartmentId);

                if (employee is null)
                    return Results.NotFound();

                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            return group;
        }
    }
}
