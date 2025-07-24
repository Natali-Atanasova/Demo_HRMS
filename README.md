# Demo_HRMS

This is a full-stack HR management application developed using .NET 8 Minimal APIs, Blazor Server, and SQL Server Express. It was created for the UKG junior developer hiring challenge to showcase real-world architecture, secure authentication, and clean, scalable code practices.

---

## Purpose

To simulate a functioning HR platform that includes secure role-based access, responsive UI, and robust backend logic. The goal was to reflect real-life HR use cases like employee assignment, role isolation, and controlled data updates while using modern web tools effectively.

---

## Key Features

- **JWT Authentication**: Login is token-based and tied to strict role validation.
- **Role Management**: Admins, Managers, and Employees each have limited views and permissions.
- **CRUD Operations**: Employees and Departments can be created, updated, and deleted with appropriate restrictions.
- **Blazor UI**: Fully server-side rendered UI with role-specific views and navigation.
- **EF Core Integration**: Code-first approach with relationship mapping and database seeding.
- **Secure API**: Organized endpoints grouped and protected using ASP.NET Core policies.
- **Swagger Support**: API is available for testing at [https://localhost:7107/swagger/index.html](https://localhost:7107/swagger/index.html), or (in file location \HRAPI there is a file named launch-swagger- double click to launch Swagger)
- **Monitoring Ready**: Structured for Grafana integration (in file location \HRAPI ther is a file named launch-grafana- double click to launch Grafana)

---

## Roles and Permissions

- **HR Admin**:

  - Full control over users, departments, and employees.
  - Can create users that are tied to new employees.
  - Restricted from editing or deleting their own account.

- **Manager**:

  - Can view and update only employees in their own department.
  - Cannot create or delete users.

- **Employee**:

  - Limited to viewing and editing their own profile.

---

## Technology Stack

- **Frontend**: Blazor Server, Bootstrap
- **Backend**: .NET 8 Minimal API, ASP.NET Core
- **Authentication**: JWT, ProtectedLocalStorage
- **Database**: SQL Server Express, EF Core (Code First)
- **Testing Tools**: Swagger, Postman
- **Monitoring**: Grafana (external setup)

---

## How to Run

**Requirements:**

- .NET 8 SDK
- SQL Server Express
- Visual Studio or Visual Studio Code

**Steps:**

1. Clone the project repository.
2. Run the following migration command:
   ```bash
   dotnet ef database update
   ```
3. Launch the backend (`HRAPI`) and frontend (`HRMS.Blazor`) projects.
4. Navigate to [https://localhost:7107](https://localhost:7107) to view the UI.
5. Access Swagger at [https://localhost:7107/swagger/index.html](https://localhost:7107/swagger/index.html).

---

## Project Structure

- `HRAPI/` – Minimal APIs, Auth, DB Context, Endpoints
- `HRMS.Blazor/` – UI Components, Pages, Services
- `HRMS.Domain/` – Models and DTOs
- `HRMS.Infrastructure/` – Database, Repositories, Seeding

---

## Code Notes

- **Role-based UI navigation** is handled through checks in Razor components.
- **Token storage** uses Blazor's `ProtectedLocalStorage`.
- **EF Core relationships** are mapped and validated on startup.
- **AdminEmployees.razor** includes logic to prevent an admin from deleting themselves.

---
## Demo Users for Login

Use the following pre-configured accounts to test the system:

| Role      | Username           | Password      |
|-----------|--------------------|---------------|
| Admin     | svetla.petrova     | Password123!  |
| Manager   | kalina.petkova     | Password123!  |
| Employee  | ivaylo.marinov     | Password123!  |

All accounts use the same password for simplicity. Role-based access will restrict what each user can see and do after logging in.

---

## Future Ideas

- Docker support and CI/CD pipelines
- Leave requests and attendance tracking
- Admin dashboard with charts
- Azure deployment for production use

---

## License

This code is provided for evaluation and demonstration purposes. Not intended for production without review.




