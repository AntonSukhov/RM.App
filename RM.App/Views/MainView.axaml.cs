using System;
using Avalonia.Controls;
using ReactiveUI;
using RM.App.Messages;

namespace RM.App.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        MessageBus.Current
            .Listen<CloseWindowRequest>()
            .Subscribe(Close);
    }
}