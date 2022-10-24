using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class GradientButton : ContentView
{ 
	public GradientButton()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(String), typeof(GradientButton));

    public String Text
    {
        get => (String)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(GradientButton));

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly BindableProperty OnClickCommandProperty =
        BindableProperty.Create(nameof(OnClickCommand), typeof(ICommand), typeof(GradientButton));

    public ICommand OnClickCommand
    {
        get => (ICommand)GetValue(OnClickCommandProperty);
        set 
        {
            SetValue(OnClickCommandProperty, value);
        }
    }
}