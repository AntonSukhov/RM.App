using System.Threading.Tasks;
using MsBox.Avalonia;
using RM.App.Converters;
using RM.App.Enums;

namespace RM.App.Services.Dialogs;

public class MessageBoxService : IMessageBoxService
{
    public async Task<MessageBoxResult> ShowAsync(string message, string title, 
        MessageBoxButton button, MessageBoxIcon icon)
    {
        var msBoxButton = MessageBoxConverter.FromMessageBoxButton(button);
        var msBoxIcon = MessageBoxConverter.FromMessageBoxIcon(icon);
        var box = MessageBoxManager
            .GetMessageBoxStandard(title, message, msBoxButton, msBoxIcon);

        var buttonResult = await box.ShowAsync();
        var messageBoxResult = MessageBoxConverter.ToMessageBoxResult(buttonResult);

        return messageBoxResult;
    }
}
