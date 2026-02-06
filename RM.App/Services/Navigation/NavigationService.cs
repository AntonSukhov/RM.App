using System;
using Microsoft.Extensions.DependencyInjection;
using RM.App.Enums;
using RM.App.Services.Registry;
using RM.App.Services.Windows;

namespace RM.App.Services.Navigation;

/// <summary>
/// Реализация сервиса для навигации между окнами.
/// </summary>
/// <summary>
/// Конкретная реализация INavigationService.
/// Связывает реестр типов, DI‑контейнер и сервис окон.
/// </summary>
public class NavigationService : INavigationService
{
    private readonly IWindowTypeRegistry _workTypeRegistry;
    private readonly IServiceProvider _serviceProvider;
    private readonly IWindowService _windowService;

    /// <summary>
    /// Инициализирует экземпляр <see cref="NavigationService"/>.
    /// </summary>
    /// <param name="workTypeRegistry">Реестр типов окон.</param>
    /// <param name="serviceProvider">Провайдер сервисов.</param>
    /// <param name="windowService">Сервис окна.</param>
    public NavigationService(
        IWindowTypeRegistry workTypeRegistry,
        IServiceProvider serviceProvider,
        IWindowService windowService)
    {
         ArgumentNullException.ThrowIfNull(workTypeRegistry, nameof(workTypeRegistry));
         ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));
         ArgumentNullException.ThrowIfNull(windowService, nameof(windowService));

        _workTypeRegistry = workTypeRegistry;
        _serviceProvider = serviceProvider;
        _windowService = windowService;
    }

    /// <inheritdoc />
    public void NavigateTo(WindowKey windowKey, IWindowOwner? owner = null)
    {
        var windowType = _workTypeRegistry.GetWindowType(windowKey);

        var viewModelType = GetViewModelType(windowType);

        var viewModel = _serviceProvider.GetRequiredService(viewModelType);

        _windowService.ShowWindowByType(windowType, viewModel, owner);
    }

    /// <summary>
    /// Определяет тип ViewModel по типу View.
    /// Использует эвристику: заменяет "View" на "ViewModel" в имени типа.
    /// </summary>
    /// <param name="viewType">Тип класса View</param>
    /// <returns>Тип класса ViewModel</returns>
    private static Type GetViewModelType(Type viewType)
    {
        var viewNamespace = viewType.Namespace;
        var viewModelNamespace = viewNamespace.Replace(".Views", ".ViewModels");
        
        if (viewModelNamespace == viewNamespace)
            viewModelNamespace += ".ViewModels";

        var viewModelClassName = viewType.Name.Replace("View", "ViewModel");

        var fullViewModelTypeName = $"{viewModelNamespace}.{viewModelClassName}";

        var viewModelType = Type.GetType(fullViewModelTypeName) 
        ?? throw new InvalidOperationException($"ViewModel не найден. Ожидаемый тип: {fullViewModelTypeName}.");

        return viewModelType;
    }
}
