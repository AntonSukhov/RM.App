using MsBox.Avalonia.Enums;
using RM.App.Enums;

namespace RM.App.Converters;

public static class MessageBoxConverter
{
     public static ButtonEnum FromMessageBoxButton(MessageBoxButton button)
    {
        return button switch
        {
            MessageBoxButton.Ok => ButtonEnum.Ok,
            MessageBoxButton.YesNo => ButtonEnum.YesNo,
            MessageBoxButton.OkCancel => ButtonEnum.OkCancel,
            MessageBoxButton.OkAbort => ButtonEnum.OkAbort,
            MessageBoxButton.YesNoCancel => ButtonEnum.YesNoCancel,
            MessageBoxButton.YesNoAbort => ButtonEnum.YesNoAbort,
            _ => ButtonEnum.Ok
        };
    }

    public static Icon FromMessageBoxIcon(MessageBoxIcon icon)
    {
        return icon switch
        {
            MessageBoxIcon.None => Icon.None,
            MessageBoxIcon.Error => Icon.Error,
            MessageBoxIcon.Info => Icon.Info,
            MessageBoxIcon.Question => Icon.Question,
            MessageBoxIcon.Warning => Icon.Warning,
            _ => Icon.None
        };
    }

    public static MessageBoxResult ToMessageBoxResult(ButtonResult result)
    {
        return result switch
        {
            ButtonResult.Ok => MessageBoxResult.Ok,
            ButtonResult.Yes => MessageBoxResult.Yes,
            ButtonResult.No => MessageBoxResult.No,
            ButtonResult.Abort => MessageBoxResult.Abort,
            ButtonResult.Cancel => MessageBoxResult.Cancel,
            ButtonResult.None => MessageBoxResult.None,
            _ => MessageBoxResult.None
        };
    }
}
