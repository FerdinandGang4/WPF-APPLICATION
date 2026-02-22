using BankingApp.Models;

namespace BankingApp.Services;

public interface IAccountService
{
    Task<IReadOnlyList<Account>> GetAccountsForCustomerAsync(int customerId, CancellationToken cancellationToken = default);

    Task<Account?> GetByIdAsync(int accountId, CancellationToken cancellationToken = default);
}
