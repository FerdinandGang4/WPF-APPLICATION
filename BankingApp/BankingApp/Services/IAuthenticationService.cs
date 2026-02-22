using BankingApp.Models;

namespace BankingApp.Services;

public interface IAuthenticationService
{
    Task<User?> LoginAsync(string username, string password, CancellationToken cancellationToken = default);

    Task<User> RegisterAsync(string username, string password, UserRole role, CancellationToken cancellationToken = default);
}
