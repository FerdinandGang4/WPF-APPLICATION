using BankingApp.Models;

namespace BankingApp.Services;

public sealed class InMemoryAccountService : IAccountService
{
    private static readonly IReadOnlyList<Account> SeedAccounts =
    [
        new Account { Id = 1, CustomerId = 1, AccountNumber = "10010001", Type = AccountType.Checking, Balance = 3250.45m, Status = AccountStatus.Active },
        new Account { Id = 2, CustomerId = 1, AccountNumber = "10010002", Type = AccountType.Savings, Balance = 11250.00m, Status = AccountStatus.Active },
        new Account { Id = 3, CustomerId = 2, AccountNumber = "20020001", Type = AccountType.Checking, Balance = 890.12m, Status = AccountStatus.Active },
    ];

    public Task<IReadOnlyList<Account>> GetAccountsForCustomerAsync(int customerId, CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Account> accounts = SeedAccounts.Where(a => a.CustomerId == customerId).ToList();
        return Task.FromResult(accounts);
    }

    public Task<Account?> GetByIdAsync(int accountId, CancellationToken cancellationToken = default)
    {
        Account? account = SeedAccounts.FirstOrDefault(a => a.Id == accountId);
        return Task.FromResult(account);
    }
}
