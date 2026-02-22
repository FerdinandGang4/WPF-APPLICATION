using BankingApp.Models;

namespace BankingApp.Services;

public interface ITransferService
{
    Task<Transfer> TransferAsync(int sourceAccountId, int destinationAccountId, decimal amount, CancellationToken cancellationToken = default);
}
