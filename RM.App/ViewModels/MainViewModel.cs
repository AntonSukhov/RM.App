using System;
using System.Reactive;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RM.App.Enums;
using RM.App.Messages;
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
    public ReactiveCommand<Unit, Unit> OpenWorkUnitsReferenceCommand { get; private set; }

    /// <summary>
    /// Получает команду закрытия главного окна.
    /// </summary>
    public ReactiveCommand<Unit, Unit> CloseMainViewCommand { get; private set; }

    /// <summary>
    /// Инициализирует экземпляр <see cref="MainViewModel"/>
    /// </summary>
    /// <param name="navigationService">Сервис навигации между окнами приложения.</param>
    public MainViewModel(INavigationService navigationService)
    {
        ArgumentNullException.ThrowIfNull(navigationService, nameof(navigationService));

        _navigationService = navigationService;

        OpenWorkUnitsReferenceCommand = ReactiveCommand.Create(
            ExecuteOpenWorkUnitsReference,
            outputScheduler: AvaloniaScheduler.Instance);

         CloseMainViewCommand = ReactiveCommand.Create(
            ExecuteCloseMainView,
            outputScheduler: AvaloniaScheduler.Instance);
    }

    private void ExecuteOpenWorkUnitsReference()
    {
        _navigationService.NavigateTo(WindowKey.WorkUnits);   
    }

    private void ExecuteCloseMainView()
    {
        MessageBus.Current.SendMessage(new CloseWindowRequest());
    }
}
