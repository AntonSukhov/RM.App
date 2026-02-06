using Avalonia.Controls;
using RM.App.Services.Windows;

namespace RM.App.Views;

public partial class WorkUnitDirectoryView : Window, IWindow, IWindowOwner
{
    public bool IsOpen => IsVisible;

    public WorkUnitDirectoryView()
    {
        InitializeComponent();
    }

    public void Show(IWindowOwner? owner = null)
    {
        if(owner is Window windowOwner)
        {
            Show(windowOwner);
        }
    }

}