using System.Threading.Tasks;
using RM.App.Enums;

namespace RM.App.Services.Dialogs;

public class NullMessageBoxService : IMessageBoxService
{
    public Task<MessageBoxResult> ShowAsync(string message, string title, MessageBoxButton buttons, MessageBoxIcon icon)
    {
       return Task.FromResult(MessageBoxResult.Cancel);
    }
}
