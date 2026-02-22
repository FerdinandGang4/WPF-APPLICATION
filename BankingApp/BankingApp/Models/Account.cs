namespace BankingApp.Models;

public class Account
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string AccountNumber { get; set; } = string.Empty;

    public AccountType Type { get; set; } = AccountType.Checking;

    public decimal Balance { get; set; }

    public AccountStatus Status { get; set; } = AccountStatus.Active;

    public string CurrencyCode { get; set; } = "USD";

    public DateTimeOffset OpenedAtUtc { get; set; } = DateTimeOffset.UtcNow;
}
