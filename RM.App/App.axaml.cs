using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RM.App.ViewModels;
using RM.App.Views;
using Microsoft.Extensions.DependencyInjection;
using RM.App.Extensions;
using System;
using RM.App.Services.Registry;
using RM.App.Enums;

namespace RM.App;

public partial class App : Application
{
    private IServiceProvider? _serviceProvider;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        services.AddServices();
        services.AddViewModels();

        _serviceProvider = services.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            RegisterWindowTypes(_serviceProvider);

            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            desktop.MainWindow = new MainView
            {
                DataContext = mainViewModel
            };
            desktop.MainWindow.Show();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void RegisterWindowTypes(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

        var windowTypeRegistry = serviceProvider.GetRequiredService<IWindowTypeRegistry>() 
            ?? throw new Exception($"Сервис типа {nameof(IWindowTypeRegistry)} отсутствует в {nameof(IServiceCollection)}."); // TODO: добавить правильный тип исключения.
   
        windowTypeRegistry.Register<WorkUnitDirectoryView>(WindowKey.WorkUnits);
    }
}