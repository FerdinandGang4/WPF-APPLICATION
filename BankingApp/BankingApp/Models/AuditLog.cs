namespace BankingApp.Models;

public class AuditLog
{
    public long Id { get; set; }

    public int? ActorUserId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string Target { get; set; } = string.Empty;

    public DateTimeOffset TimestampUtc { get; set; } = DateTimeOffset.UtcNow;

    public string Metadata { get; set; } = string.Empty;
}
