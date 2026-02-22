namespace BankingApp.Models;

public class Payee
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string AccountReference { get; set; } = string.Empty;
}
