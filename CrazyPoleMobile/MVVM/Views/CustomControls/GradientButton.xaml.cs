using Microsoft.Maui.Controls;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class GradientButton : ContentView
{ 
	public GradientButton()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create("Text", typeof(String), typeof(GradientButton));

    public String Text
    {
        get => (String)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create("CornerRadius", typeof(int), typeof(GradientButton));

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly BindableProperty OnClickProperty =
        BindableProperty.Create("OnClick", typeof(EventHandler), typeof(GradientButton));

    public EventHandler OnClick
    {
        get => (EventHandler)GetValue(OnClickProperty);
        set 
        {
            SetValue(OnClickProperty, value);
        }
    }

    private void HandleClick(object sender, EventArgs e)
    {
        if (OnClick != null)
            OnClick(sender, e);       
    }
}