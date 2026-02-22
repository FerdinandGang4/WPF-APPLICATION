using BankingApp.Models;

namespace BankingApp.Services;

public sealed class InMemoryAdminService : IAdminService
{
    private static readonly IReadOnlyList<CustomerProfile> Customers =
    [
        new CustomerProfile { Id = 1, UserId = 1, Name = "Alex Carter", ContactInfo = "alex.carter@example.com" },
        new CustomerProfile { Id = 2, UserId = 2, Name = "Jordan Lee", ContactInfo = "jordan.lee@example.com" },
    ];

    private static readonly IReadOnlyList<AuditLog> Logs =
    [
        new AuditLog { Id = 1, ActorUserId = 2, Action = "LOGIN_SUCCESS", Target = "admin", TimestampUtc = DateTimeOffset.UtcNow.AddHours(-6), Metadata = "{\"ip\":\"127.0.0.1\"}" },
        new AuditLog { Id = 2, ActorUserId = 2, Action = "VIEW_CUSTOMER", Target = "customer:1", TimestampUtc = DateTimeOffset.UtcNow.AddHours(-2), Metadata = "{}" },
    ];

    public Task<IReadOnlyList<CustomerProfile>> SearchCustomersAsync(string query, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return Task.FromResult(Customers);
        }

        IReadOnlyList<CustomerProfile> result = Customers
            .Where(c => c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) || c.ContactInfo.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Task.FromResult(result);
    }

    public Task<IReadOnlyList<AuditLog>> GetAuditLogsAsync(DateTimeOffset fromUtc, DateTimeOffset toUtc, CancellationToken cancellationToken = default)
    {
        IReadOnlyList<AuditLog> result = Logs
            .Where(l => l.TimestampUtc >= fromUtc && l.TimestampUtc <= toUtc)
            .OrderByDescending(l => l.TimestampUtc)
            .ToList();

        return Task.FromResult(result);
    }
}
