using BankingApp.Models;

namespace BankingApp.Services;

public sealed class InMemoryTransactionService : ITransactionService
{
    private static readonly IReadOnlyList<Transaction> SeedTransactions =
    [
        new Transaction { Id = 1, AccountId = 1, Amount = 2500.00m, Type = TransactionType.Deposit, Reference = "Payroll", TimestampUtc = DateTimeOffset.UtcNow.AddDays(-10) },
        new Transaction { Id = 2, AccountId = 1, Amount = -125.76m, Type = TransactionType.Withdrawal, Reference = "Groceries", TimestampUtc = DateTimeOffset.UtcNow.AddDays(-7) },
        new Transaction { Id = 3, AccountId = 1, Amount = -45.10m, Type = TransactionType.Withdrawal, Reference = "Fuel", TimestampUtc = DateTimeOffset.UtcNow.AddDays(-5) },
        new Transaction { Id = 4, AccountId = 2, Amount = 150.00m, Type = TransactionType.Interest, Reference = "Monthly Interest", TimestampUtc = DateTimeOffset.UtcNow.AddDays(-2) },
        new Transaction { Id = 5, AccountId = 2, Amount = 5000.00m, Type = TransactionType.Deposit, Reference = "Savings Transfer", TimestampUtc = DateTimeOffset.UtcNow.AddDays(-1) },
    ];

    public Task<IReadOnlyList<Transaction>> GetTransactionsForAccountAsync(int accountId, CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Transaction> transactions = SeedTransactions
            .Where(t => t.AccountId == accountId)
            .OrderByDescending(t => t.TimestampUtc)
            .ToList();

        return Task.FromResult(transactions);
    }
}
