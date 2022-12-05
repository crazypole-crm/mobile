using System.Reflection;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class IconButton : ContentView
{
	public IconButton()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty SourceProperty =
        BindableProperty.Create("Source", typeof(String), typeof(IconButton));

    public String Source
    {
        get => (String)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(String), typeof(IconButton));

    public String CornerRadius
    {
        get => (String)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(IconButton));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

}