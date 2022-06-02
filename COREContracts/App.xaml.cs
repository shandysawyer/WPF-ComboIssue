using COREContracts.DataAccess.Models;
using COREContracts.DataAccess.Repositories;
using COREContracts.ViewModels;
using COREContracts.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notifications.Wpf;
using Prism.Events;
using System;
using System.IO;
using System.Windows;

namespace COREContracts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = new HostBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    _ = builder
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    _ = services
                        .AddSingleton<IEventAggregator, EventAggregator>()
                        .AddScoped<Func<CoreContext>>(provider => () => new CoreContext())
                        .AddScoped<ICoreRepository, CoreRepository>()
                        .AddScoped<INavigationViewModel, NavigationViewModel>()
                        .AddScoped<IContractEditViewModel, ContractEditViewModel>()
                        .AddScoped<MainViewModel>()
                        .AddScoped<MainWindow>();
                })
                .ConfigureLogging(configureLoggging =>
                {
                    _ = configureLoggging.AddConsole();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
