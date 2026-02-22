using System.Windows;
using BankingApp.Services;
using BankingApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace BankingApp;

public partial class App : Application
{
    private ServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();

        MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _serviceProvider?.Dispose();
        base.OnExit(e);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IAuthenticationService, InMemoryAuthenticationService>();
        services.AddSingleton<IAccountService, InMemoryAccountService>();
        services.AddSingleton<ITransactionService, InMemoryTransactionService>();
        services.AddSingleton<ITransferService, InMemoryTransferService>();
        services.AddSingleton<IPayeeService, InMemoryPayeeService>();
        services.AddSingleton<IStatementService, InMemoryStatementService>();
        services.AddSingleton<IAdminService, InMemoryAdminService>();

        services.AddTransient<DashboardViewModel>();
        services.AddTransient<MainWindow>();
    }
}
