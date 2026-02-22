using BankingApp.Models;

namespace BankingApp.Services;

public sealed class InMemoryAuthenticationService : IAuthenticationService
{
    private static readonly List<User> Users =
    [
        new User { Id = 1, Username = "customer", PasswordHash = "demo-hash-customer", Role = UserRole.Customer },
        new User { Id = 2, Username = "admin", PasswordHash = "demo-hash-admin", Role = UserRole.Admin },
    ];

    public Task<User?> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        User? user = Users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));

        // Demo-only behavior: any non-empty password is accepted when user exists.
        if (user is null || string.IsNullOrWhiteSpace(password))
        {
            return Task.FromResult<User?>(null);
        }

        return Task.FromResult<User?>(user);
    }

    public Task<User> RegisterAsync(string username, string password, UserRole role, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username is required.", nameof(username));
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password is required.", nameof(password));
        }

        if (Users.Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("A user with the same username already exists.");
        }

        int nextId = Users.Count == 0 ? 1 : Users.Max(u => u.Id) + 1;
        var user = new User
        {
            Id = nextId,
            Username = username,
            PasswordHash = "demo-hash-" + username,
            Role = role,
        };

        Users.Add(user);
        return Task.FromResult(user);
    }
}
