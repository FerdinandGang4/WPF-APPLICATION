using System.Windows;
using BankingApp.Services;
using BankingApp.ViewModels;

namespace BankingApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var viewModel = new DashboardViewModel(
            new InMemoryAccountService(),
            new InMemoryTransactionService());

        DataContext = viewModel;
        Loaded += async (_, _) => await viewModel.LoadAsync();
    }
}
