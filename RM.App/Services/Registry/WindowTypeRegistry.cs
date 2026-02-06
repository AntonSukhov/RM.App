using System;
using System.Collections.Generic;
using RM.App.Enums;
using RM.App.Services.Windows;

namespace RM.App.Services.Registry;

/// <summary>
/// Реализация реестра типов окон.
/// </summary>
public class WindowTypeRegistry : IWindowTypeRegistry
{
    private readonly Dictionary<WindowKey, Type> _windowTypes = new();

    /// <inheritdoc/>
    public Type GetWindowType(WindowKey key)
    {
        if(_windowTypes.TryGetValue(key, out var type))
        {
            return type;
        }

        throw new KeyNotFoundException($"Окно не зарегистрировано: {key}.");
    }

    /// <inheritdoc/>
    public bool IsRegistered(WindowKey key) => _windowTypes.ContainsKey(key);

    /// <inheritdoc/>
    public void Register<TView>(WindowKey key) where TView : IWindow
    {
        if (_windowTypes.ContainsKey(key))
            throw new InvalidOperationException($"Ключ {key} уже зарегистрирован.");

        _windowTypes.Add(key, typeof(TView));
    }
}
