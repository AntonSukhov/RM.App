using System;

namespace RM.App.Services.Windows;

/// <summary>
/// Сервис операций работы с окном.
/// </summary>
public interface IWindowService
{
    /// <summary>
    /// Показывает окно по типу.
    /// </summary>
    /// <remarks>
    /// Выпоняется создание окна по его типу, назначение окну модели представления и показ окна.
    /// При необходимости можно вынести создание окна из <see cref="IWindowService"/> и перенести 
    /// эту ответственность в <see cref=""/>.
    /// </remarks>
    /// <param name="windowType">Тип класса окна.</param>
    /// <param name="viewModel">Модель представления для окна.</param>
    /// <param name="owner">Родительское окно. По умолчанию отсутствует.</param>
    void ShowWindowByType(Type windowType, object viewModel, IWindowOwner? owner = null);


    /// <summary>
    /// Закрывает указанное окно.
    /// </summary>
    /// <param name="window">Окно для закрытия.</param>
    void CloseWindow(IWindow window);
}