using BankingApp.Models;

namespace BankingApp.Services;

public sealed class InMemoryTransferService : ITransferService
{
    private static long _nextId = 1;

    public Task<Transfer> TransferAsync(int sourceAccountId, int destinationAccountId, decimal amount, CancellationToken cancellationToken = default)
    {
        if (sourceAccountId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sourceAccountId));
        }

        if (destinationAccountId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(destinationAccountId));
        }

        if (sourceAccountId == destinationAccountId)
        {
            throw new InvalidOperationException("Source and destination accounts must be different.");
        }

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Transfer amount must be greater than zero.");
        }

        var transfer = new Transfer
        {
            Id = _nextId++,
            SourceAccountId = sourceAccountId,
            DestinationAccountId = destinationAccountId,
            Amount = amount,
            Status = TransferStatus.Completed,
            TimestampUtc = DateTimeOffset.UtcNow,
        };

        return Task.FromResult(transfer);
    }
}
