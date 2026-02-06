namespace RM.App.Services.Windows;

public interface IWindow
{
    bool IsOpen { get; }
    object? DataContext { get; set; }

    void Show();
    void Show(IWindowOwner? owner = null);
    void Close(); 
}
