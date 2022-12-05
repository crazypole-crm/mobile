using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.Components;

public partial class DirectionFrame : ContentView
{
	public DirectionFrame()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty HeaderTextProperty =
        BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(DirectionFrame));

    public string HeaderText
    {
        get => (string)GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }

    public static readonly BindableProperty OpenCommandProperty =
        BindableProperty.Create(nameof(OpenCommand), typeof(ICommand), typeof(DirectionFrame));

    public ICommand OpenCommand
    {
        get => (ICommand)GetValue(OpenCommandProperty);
        set => SetValue(OpenCommandProperty, value);
    }

}