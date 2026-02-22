using System.Collections.ObjectModel;
using System.Windows.Input;
using BankingApp.Commands;
using BankingApp.Models;
using BankingApp.Services;

namespace BankingApp.ViewModels;

public sealed class DashboardViewModel : ViewModelBase
{
    private const int DemoCustomerId = 1;

    private readonly IAccountService _accountService;
    private readonly ITransactionService _transactionService;

    private Account? _selectedAccount;
    private bool _isLoading;
    private string _statusMessage = "Ready";

    public DashboardViewModel(IAccountService accountService, ITransactionService transactionService)
    {
        _accountService = accountService;
        _transactionService = transactionService;

        RefreshCommand = new AsyncRelayCommand(LoadAsync);
    }

    public ObservableCollection<Account> Accounts { get; } = [];

    public ObservableCollection<Transaction> RecentTransactions { get; } = [];

    public ICommand RefreshCommand { get; }

    public bool IsLoading
    {
        get => _isLoading;
        private set
        {
            if (SetProperty(ref _isLoading, value))
            {
                (RefreshCommand as AsyncRelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        private set => SetProperty(ref _statusMessage, value);
    }

    public Account? SelectedAccount
    {
        get => _selectedAccount;
        set
        {
            if (SetProperty(ref _selectedAccount, value))
            {
                _ = LoadTransactionsForSelectedAccountAsync();
            }
        }
    }

    public async Task LoadAsync()
    {
        if (IsLoading)
        {
            return;
        }

        try
        {
            IsLoading = true;
            StatusMessage = "Loading accounts...";

            IReadOnlyList<Account> accounts = await _accountService.GetAccountsForCustomerAsync(DemoCustomerId);

            Accounts.Clear();
            foreach (Account account in accounts)
            {
                Accounts.Add(account);
            }

            SelectedAccount = Accounts.FirstOrDefault();
            StatusMessage = Accounts.Count == 0 ? "No accounts found." : "Accounts loaded.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Load failed: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task LoadTransactionsForSelectedAccountAsync()
    {
        RecentTransactions.Clear();

        if (SelectedAccount is null)
        {
            return;
        }

        IReadOnlyList<Transaction> transactions = await _transactionService.GetTransactionsForAccountAsync(SelectedAccount.Id);

        foreach (Transaction transaction in transactions)
        {
            RecentTransactions.Add(transaction);
        }

        StatusMessage = $"Showing {RecentTransactions.Count} transactions for account {SelectedAccount.AccountNumber}.";
    }
}
