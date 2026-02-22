namespace BankingApp.Models;

public class Transaction
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public TransactionType Type { get; set; }

    public DateTimeOffset TimestampUtc { get; set; } = DateTimeOffset.UtcNow;

    public string Reference { get; set; } = string.Empty;
}
