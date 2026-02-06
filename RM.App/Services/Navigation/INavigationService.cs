using RM.App.Enums;
using RM.App.Services.Windows;

namespace RM.App.Services.Navigation;

/// <summary>
/// Сервис для навигации между окнами.
/// </summary>
/// <remarks>
/// Абстрагирует процесс открытия окна по ключу <see cref="WindowKey"/>.
/// </remarks>
public interface INavigationService
{
    /// <summary>
    /// Открывает окно по указанному ключу.
    /// </summary>
    /// <param name="windowKey">Ключ окна.</param>
    /// <param name="owner">Родительское окно. По умолчанию отсутствует.</param>
    void NavigateTo(WindowKey windowKey, IWindowOwner? owner = null);
}
