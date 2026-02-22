namespace BankingApp.Models;

public class CustomerProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ContactInfo { get; set; } = string.Empty;
}
