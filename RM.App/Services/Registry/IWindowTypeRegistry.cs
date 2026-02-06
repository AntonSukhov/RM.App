using System;
using RM.App.Enums;
using RM.App.Services.Windows;

namespace RM.App.Services.Registry;

/// <summary>
/// Реестр типов окон.
/// </summary>
/// <remarks>
/// Реестр хранит соответствия между ключами и типами окон программы.
/// </remarks>
public interface IWindowTypeRegistry
{
    /// <summary>
    /// Регистрирует тип окна под указанным ключом.
    /// </summary>
    /// <typeparam name="TView">Тип окна.</typeparam>
    /// <param name="key">Ключ окна.</param>
    void Register<TView>(WindowKey key) where TView : IWindow;

    /// <summary>
    /// Возвращает тип окна по ключу.
    /// </summary>
    /// <param name="key">Ключ окна.</param>
    /// <returns>Тип класса окна.</returns>
    Type GetWindowType(WindowKey key);

    /// <summary>
    /// Проверяет, зарегистрирован ли ключ.
    /// </summary>
    /// <param name="key">Ключ окна.</param>
    /// <returns><c>true</c>, если ключ есть в реестре, иначе <c>false</c>.</returns>
    bool IsRegistered(WindowKey key);
}
