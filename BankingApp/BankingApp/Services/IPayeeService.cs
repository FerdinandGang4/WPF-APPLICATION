using BankingApp.Models;

namespace BankingApp.Services;

public interface IPayeeService
{
    Task<IReadOnlyList<Payee>> GetPayeesForCustomerAsync(int customerId, CancellationToken cancellationToken = default);

    Task<Payee> AddPayeeAsync(Payee payee, CancellationToken cancellationToken = default);

    Task UpdatePayeeAsync(Payee payee, CancellationToken cancellationToken = default);

    Task DeletePayeeAsync(int payeeId, CancellationToken cancellationToken = default);
}
