namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class GradientField : ContentView
{
    public GradientField()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty PlaceholderTextProperty =
		BindableProperty.Create("Placeholder", typeof(String), typeof(GradientField));

	public String Placeholder
	{
		get => (String)GetValue(PlaceholderTextProperty);
		set => SetValue(PlaceholderTextProperty, value);
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