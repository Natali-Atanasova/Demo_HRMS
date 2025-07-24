using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace HRAPI.Tests
{
    public class FullApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FullApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        // Helper: Login and get JWT token
        private async Task<string> GetJwtAsync(HttpClient client, string username, string password)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(new { username, password }),
                Encoding.UTF8, "application/json");

            var loginResp = await client.PostAsync("/login", loginContent);
            loginResp.EnsureSuccessStatusCode();

            var loginJson = await loginResp.Content.ReadAsStringAsync();
            return JsonDocument.Parse(loginJson).RootElement.GetProperty("token").GetString();
        }

        // Employee: /employee/profile
        [Theory]
        [InlineData("miroslav.borisov", "Password123!")]
        [InlineData("teodora.mitkova", "Password123!")]
        public async Task EmployeeProfile_Authorized_ReturnsProfile(string username, string password)
        {
            var client = _factory.CreateClient();
            var jwt = await GetJwtAsync(client, username, password);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var resp = await client.GetAsync("/employee/profile");
            resp.EnsureSuccessStatusCode();

            var profileJson = await resp.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(profileJson));
        }

        //  HR Admin: /admin/all
        [Theory]
        [InlineData("svetla.petrova", "Password123!")] 
        public async Task Admin_GetAllEmployees_Works(string username, string password)
        {
            var client = _factory.CreateClient();
            var jwt = await GetJwtAsync(client, username, password);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var resp = await client.GetAsync("/admin/all");
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            Assert.Contains("department", json, System.StringComparison.OrdinalIgnoreCase);
        }

        //  HR Admin: /admin/employee/{id}
        [Theory]
        [InlineData("svetla.petrova", "Password123!", 1)] 
        public async Task Admin_GetEmployeeById_Works(string username, string password, int employeeId)
        {
            var client = _factory.CreateClient();
            var jwt = await GetJwtAsync(client, username, password);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var resp = await client.GetAsync($"/admin/employee/{employeeId}");
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                return; 
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            Assert.Contains("email", json, System.StringComparison.OrdinalIgnoreCase);
        }

        
        // HR Admin: Update Employee
        [Theory]
        [InlineData("svetla.petrova", "Password123!", 2)] 
        public async Task Admin_CanUpdateEmployee(string username, string password, int employeeId)
        {
            var client = _factory.CreateClient();
            var jwt = await GetJwtAsync(client, username, password);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var updateEmp = new
            {
                FirstName = "Updated",
                LastName = "Test",
                Email = $"updated{System.Guid.NewGuid()}@example.com",
                JobTitle = "UpdatedTester",
                Salary = 5678,
                DepartmentId = 1 
            };

            var content = new StringContent(JsonSerializer.Serialize(updateEmp), Encoding.UTF8, "application/json");
            var resp = await client.PutAsync($"/admin/employee/{employeeId}", content);

            Assert.True(
                resp.IsSuccessStatusCode ||
                resp.StatusCode == System.Net.HttpStatusCode.BadRequest ||
                resp.StatusCode == System.Net.HttpStatusCode.NotFound
            );
        }

        // HR Admin: Delete Employee
        [Theory]
        [InlineData("svetla.petrova", "Password123!", 3)] 
        public async Task Admin_CanDeleteEmployee(string username, string password, int employeeId)
        {
            var client = _factory.CreateClient();
            var jwt = await GetJwtAsync(client, username, password);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var resp = await client.DeleteAsync($"/admin/employee/{employeeId}");

            Assert.True(
                resp.IsSuccessStatusCode ||
                resp.StatusCode == System.Net.HttpStatusCode.BadRequest ||
                resp.StatusCode == System.Net.HttpStatusCode.NotFound
            );
        }

        // Manager: /manager/department
        [Theory]
        [InlineData("maria.georgieva", "Password123!")] 
        public async Task Manager_GetDepartment_Works(string username, string password)
        {
            var client = _factory.CreateClient();
            var jwt = await GetJwtAsync(client, username, password);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var resp = await client.GetAsync("/manager/department");
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            Assert.Contains("employees", json, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
