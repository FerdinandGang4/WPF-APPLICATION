using BankingApp.Models;

namespace BankingApp.Services;

public interface IAdminService
{
    Task<IReadOnlyList<CustomerProfile>> SearchCustomersAsync(string query, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<AuditLog>> GetAuditLogsAsync(DateTimeOffset fromUtc, DateTimeOffset toUtc, CancellationToken cancellationToken = default);
}
