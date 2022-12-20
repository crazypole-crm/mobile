namespace CrazyPoleMobile.MVVM.Views.Components;

public partial class FavouritesFrame : ContentView
{

    public static readonly BindableProperty DirectionTextProperty =
        BindableProperty.Create(nameof(DirectionText), typeof(string), typeof(FavouritesFrame), string.Empty);

    public string DirectionText
    {
        get => (string)GetValue(DirectionTextProperty);
        set => SetValue(DirectionTextProperty, value);
    }

    public static readonly BindableProperty HallTextProperty =
        BindableProperty.Create(nameof(HallText), typeof(string), typeof(FavouritesFrame), string.Empty);

    public string HallText
    {
        get => (string)GetValue(HallTextProperty);
        set => SetValue(HallTextProperty, value);
    }

    public static readonly BindableProperty TrainerTextProperty =
        BindableProperty.Create(nameof(TrainerText), typeof(string), typeof(FavouritesFrame), string.Empty);

    public string TrainerText
    {
        get => (string)GetValue(TrainerTextProperty);
        set => SetValue(TrainerTextProperty, value);
    }

    public FavouritesFrame()
	{
		InitializeComponent();
	}
}