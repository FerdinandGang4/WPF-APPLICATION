namespace BankingApp.Services;

public interface IStatementService
{
    Task<string> ExportCsvAsync(int accountId, DateTimeOffset fromUtc, DateTimeOffset toUtc, CancellationToken cancellationToken = default);

    Task<string> ExportPdfAsync(int accountId, DateTimeOffset fromUtc, DateTimeOffset toUtc, CancellationToken cancellationToken = default);
}
