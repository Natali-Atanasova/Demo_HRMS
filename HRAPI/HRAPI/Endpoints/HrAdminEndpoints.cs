using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HRAPI.Data;
using HRAPI.Entities;

namespace HRAPI.Endpoints
{
    public static class HrAdminEndpoints
    {
        public static RouteGroupBuilder MapHrAdminEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("admin")
                           .WithParameterValidation()
                           .RequireAuthorization("HRAdminPolicy");

            // GET /admin/all
            group.MapGet("/all", async (HRSysContext db) =>
            {
                var employees = await db.Employees
                    .Include(e => e.Department)
                    .ToListAsync();
                return Results.Ok(employees);
            });

            // GET /admin/employee/{id}
            group.MapGet("/employee/{id}", async (int id, HRSysContext db) =>
            {
                var employee = await db.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
                return employee is null ? Results.NotFound() : Results.Ok(employee);
            });

            // POST /admin/employee used to create employee and user
            group.MapPost("/employee", async (Employee newEmployee, HRSysContext db) =>
            {
                var department = await db.Departments.FindAsync(newEmployee.DepartmentId);
                if (department == null)
                    return Results.BadRequest("Invalid DepartmentId.");

                db.Employees.Add(newEmployee);
                await db.SaveChangesAsync();

                
                var defaultPassword = "ChangeMe123!"; //randomize
                var username = newEmployee.Email; // and a unique fild 

                if (await db.Users.AnyAsync(u => u.Username == username))
                    return Results.BadRequest("A user with this email/username already exists.");

                var user = new User
                {
                    Username = username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(defaultPassword),
                    Role = "Employee",
                    EmployeeId = newEmployee.Id
                };
                db.Users.Add(user);
                await db.SaveChangesAsync();

                //return the credentials so HR admin can pass to the new hire
                return Results.Created($"/admin/employee/{newEmployee.Id}", new
                {
                    employee = newEmployee,
                    user = new { username = user.Username, tempPassword = defaultPassword }
                });
            });

            // update employee
            group.MapPut("/employee/{id}", async (int id, Employee updatedEmployee, HRSysContext db, ClaimsPrincipal user) =>
            {
                //Prevent HR Admin from editing himself
                var username = user.Identity?.Name;
                var currentUser = await db.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (currentUser != null && currentUser.EmployeeId == id)
                {
                    return Results.BadRequest("HR Admins cannot edit themselves.");
                }

                var employee = await db.Employees.FindAsync(id);
                if (employee is null)
                    return Results.NotFound();

                // Update fields 
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.Email = updatedEmployee.Email;
                employee.JobTitle = updatedEmployee.JobTitle;
                employee.Salary = updatedEmployee.Salary;
                employee.DepartmentId = updatedEmployee.DepartmentId;

                await db.SaveChangesAsync();
                return Results.Ok(employee);
            });

            //  delete employee 
            group.MapDelete("/employee/{id}", async (int id, HRSysContext db, ClaimsPrincipal user) =>
            {
                // Prevent HR Admin from deleting themselves
                var username = user.Identity?.Name;
                var currentUser = await db.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (currentUser != null && currentUser.EmployeeId == id)
                {
                    return Results.BadRequest("HR Admins cannot delete themselves.");
                }

                var employee = await db.Employees.FindAsync(id);
                if (employee is null)
                    return Results.NotFound();

                // remove the user associated with this employee
                var userToDelete = await db.Users.FirstOrDefaultAsync(u => u.EmployeeId == id);
                if (userToDelete != null)
                    db.Users.Remove(userToDelete);

                db.Employees.Remove(employee);
                await db.SaveChangesAsync();

                return Results.Ok("Employee and user deleted.");
            });

            return group;
        }
    }
}
