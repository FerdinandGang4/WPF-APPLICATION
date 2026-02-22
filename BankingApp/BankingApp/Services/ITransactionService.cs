using BankingApp.Models;

namespace BankingApp.Services;

public interface ITransactionService
{
    Task<IReadOnlyList<Transaction>> GetTransactionsForAccountAsync(int accountId, CancellationToken cancellationToken = default);
}
