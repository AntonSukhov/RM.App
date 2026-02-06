using System;
using System.Reactive;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RM.App.Enums;
using RM.App.Services.Navigation;

namespace RM.App.ViewModels;

/// <summary>
/// Модель представления главного окна.
/// </summary>
public partial class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    /// <summary>
    /// Получает команду открытия справочника единиц работ.
    /// </summary>
    public ReactiveCommand<Unit, Unit> OpenWorkUnitsReferenceCommand { get; }

    /// <summary>
    /// Инициализирует экземпляр <see cref="MainViewModel"/>
    /// </summary>
    /// <param name="messageBoxService">Сервис навигации между окнами приложения.</param>
    public MainViewModel(INavigationService navigationService)
    {
        ArgumentNullException.ThrowIfNull(navigationService, nameof(navigationService));

        OpenWorkUnitsReferenceCommand = ReactiveCommand.Create(
            ExecuteOpenWorkUnitsReference,
            outputScheduler: AvaloniaScheduler.Instance);

         _navigationService = navigationService;
    }

    private void ExecuteOpenWorkUnitsReference()
    {
        _navigationService.NavigateTo(WindowKey.WorkUnits);   
    }
}
