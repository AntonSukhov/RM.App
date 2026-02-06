using System;
using Microsoft.Extensions.DependencyInjection;
using RM.App.Services.Dialogs;
using RM.App.Services.Navigation;
using RM.App.Services.Registry;
using RM.App.Services.Windows;
using RM.App.ViewModels;

namespace RM.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        services.AddSingleton<IMessageBoxService, MessageBoxService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IWindowService, WindowService>();
        services.AddSingleton<IWindowTypeRegistry, WindowTypeRegistry>();
    }

    public static void AddViewModels(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        services.AddTransient<MainViewModel>();
        services.AddTransient<WorkUnitDirectoryViewModel>();
    }
}
