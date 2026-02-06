using System;

namespace RM.App.Services.Windows;

/// <summary>
/// Реализация сервиса операций работы с окном.
/// </summary>
public class WindowService : IWindowService
{   
    /// <inheritdoc/>
    public void ShowWindowByType(Type windowType, object viewModel, IWindowOwner? owner = null)
    {
        ArgumentNullException.ThrowIfNull(windowType, nameof(windowType));
        ArgumentNullException.ThrowIfNull(viewModel, nameof(viewModel));

        var window = (IWindow?)Activator.CreateInstance(windowType) 
            ?? throw new Exception($"Тип {windowType.Name} не {nameof(IWindow)}"); //TODO: Заменить Exception на более правильное исключение

        window.DataContext = viewModel;

        if (owner != null)
            window.Show(owner);
        else
            window.Show();
    }

    /// <inheritdoc/>
    public void CloseWindow(IWindow window)
    {
        ArgumentNullException.ThrowIfNull(window, nameof(window));

        window.Close();
    }
}
