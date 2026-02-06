using System.Threading.Tasks;
using RM.App.Enums;

namespace RM.App.Services.Dialogs;

public interface IMessageBoxService
{
    Task<MessageBoxResult> ShowAsync(
        string message, 
        string title,
        MessageBoxButton button,
        MessageBoxIcon icon);
}
