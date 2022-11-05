using System.Reflection;
using System.Xml;

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

}