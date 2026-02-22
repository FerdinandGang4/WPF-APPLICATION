using BankingApp.Models;

namespace BankingApp.Services;

public sealed class InMemoryPayeeService : IPayeeService
{
    private static readonly List<Payee> Payees =
    [
        new Payee { Id = 1, CustomerId = 1, Name = "City Utilities", AccountReference = "UTIL-001" },
        new Payee { Id = 2, CustomerId = 1, Name = "Landlord", AccountReference = "RENT-202" },
    ];

    public Task<IReadOnlyList<Payee>> GetPayeesForCustomerAsync(int customerId, CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Payee> result = Payees.Where(p => p.CustomerId == customerId).ToList();
        return Task.FromResult(result);
    }

    public Task<Payee> AddPayeeAsync(Payee payee, CancellationToken cancellationToken = default)
    {
        if (payee is null)
        {
            throw new ArgumentNullException(nameof(payee));
        }

        int nextId = Payees.Count == 0 ? 1 : Payees.Max(p => p.Id) + 1;
        payee.Id = nextId;
        Payees.Add(payee);
        return Task.FromResult(payee);
    }

    public Task UpdatePayeeAsync(Payee payee, CancellationToken cancellationToken = default)
    {
        if (payee is null)
        {
            throw new ArgumentNullException(nameof(payee));
        }

        Payee? existing = Payees.FirstOrDefault(p => p.Id == payee.Id);
        if (existing is null)
        {
            throw new InvalidOperationException("Payee not found.");
        }

        existing.Name = payee.Name;
        existing.AccountReference = payee.AccountReference;
        return Task.CompletedTask;
    }

    public Task DeletePayeeAsync(int payeeId, CancellationToken cancellationToken = default)
    {
        Payee? existing = Payees.FirstOrDefault(p => p.Id == payeeId);
        if (existing is not null)
        {
            Payees.Remove(existing);
        }

        return Task.CompletedTask;
    }
}
