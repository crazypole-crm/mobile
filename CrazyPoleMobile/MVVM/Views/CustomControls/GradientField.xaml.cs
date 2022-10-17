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
}