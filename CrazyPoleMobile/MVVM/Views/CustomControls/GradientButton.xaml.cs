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

}