namespace BankingApp.Models;

public class Transfer
{
    public long Id { get; set; }

    public int SourceAccountId { get; set; }

    public int DestinationAccountId { get; set; }

    public decimal Amount { get; set; }

    public TransferStatus Status { get; set; } = TransferStatus.Pending;

    public DateTimeOffset TimestampUtc { get; set; } = DateTimeOffset.UtcNow;
}
