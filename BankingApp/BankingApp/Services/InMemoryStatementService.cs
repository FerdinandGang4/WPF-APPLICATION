namespace BankingApp.Services;

public sealed class InMemoryStatementService : IStatementService
{
    public Task<string> ExportCsvAsync(int accountId, DateTimeOffset fromUtc, DateTimeOffset toUtc, CancellationToken cancellationToken = default)
    {
        string path = $"statement_{accountId}_{DateTimeOffset.UtcNow:yyyyMMddHHmmss}.csv";
        return Task.FromResult(path);
    }

    public Task<string> ExportPdfAsync(int accountId, DateTimeOffset fromUtc, DateTimeOffset toUtc, CancellationToken cancellationToken = default)
    {
        string path = $"statement_{accountId}_{DateTimeOffset.UtcNow:yyyyMMddHHmmss}.pdf";
        return Task.FromResult(path);
    }
}
