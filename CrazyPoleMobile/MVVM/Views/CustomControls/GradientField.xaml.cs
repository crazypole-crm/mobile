using Microsoft.Maui.Controls.Shapes;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class GradientField : ContentView
{
    public GradientField()
	{
		InitializeComponent();
        
	}

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(GradientButton), false);

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty PlaceholderTextProperty =
		BindableProperty.Create("Placeholder", typeof(String), typeof(GradientField));

	public String Placeholder
	{
		get => (String)GetValue(PlaceholderTextProperty);
		set => SetValue(PlaceholderTextProperty, value);
	}

    public static readonly BindableProperty InputTypeProperty =
        BindableProperty.Create("InputType", typeof(Keyboard), typeof(GradientField));

    public Keyboard InputType
    {
        get => (Keyboard)GetValue(InputTypeProperty);
        set => SetValue(InputTypeProperty, value);
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(GradientField));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public void OnFocus(object sender, FocusEventArgs args)
	{
		if (Application.Current.Resources.TryGetValue("DefaultGradient", out object data))
		{
			Framing.Stroke = (LinearGradientBrush)data;	
		}

	}

	public void OnUnfocus(object sender, FocusEventArgs args)
	{
        if (Application.Current.Resources.TryGetValue("DefaultGray", out object data))
        {
            Framing.Stroke = (LinearGradientBrush)data;
        }
    }
}