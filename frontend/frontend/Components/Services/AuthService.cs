using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

public class AuthService
{
    private readonly HttpClient _http;
    public string? UserName { get; private set; }
    public string? Role { get; private set; }
    public bool IsAuthenticated { get; private set; }

    // ADD THIS LINE:
    public event Action? OnChange;
    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public Task InitializeAsync(string? token)
    {
        if (!string.IsNullOrWhiteSpace(token))
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            ParseJwt(token);
            IsAuthenticated = true;
        }
        else
        {
            _http.DefaultRequestHeaders.Authorization = null;
            IsAuthenticated = false;
            UserName = null;
            Role = null;
        }

        // ADD THIS LINE (notifies nav bar to update)
        OnChange?.Invoke();

        return Task.CompletedTask;
    }

    private void ParseJwt(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);

        // Corrected LINQ usage with 
        UserName = token.Claims.FirstOrDefault(c =>
            c.Type == "unique_name" ||
            c.Type == "name" ||
            c.Type.EndsWith("/name", StringComparison.OrdinalIgnoreCase))
            ?.Value;

        Role = token.Claims.FirstOrDefault(c =>
            c.Type.Equals("role", StringComparison.OrdinalIgnoreCase) ||
            c.Type.Equals("roles", StringComparison.OrdinalIgnoreCase) ||
            c.Type.EndsWith("/role", StringComparison.OrdinalIgnoreCase))
            ?.Value;

        // OPTIONAL: Uncomment if you want to debug all claims
        // foreach (var c in token.Claims)
        //     Console.WriteLine($"JWT CLAIM: {c.Type} = {c.Value}");
    }
}