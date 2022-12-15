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

    public static readonly BindableProperty OnClickCommandParamenterProperty =
    BindableProperty.Create(nameof(OnClickCommandParamenter), typeof(object), typeof(GradientButton));

    public object OnClickCommandParamenter
    {
        get => GetValue(OnClickCommandParamenterProperty);
        set
        {
            SetValue(OnClickCommandParamenterProperty, value);
        }
    }

    public static readonly BindableProperty IsInteractableProperty =
        BindableProperty.Create(nameof(IsInteractable), typeof(bool), typeof(GradientButton));

    public bool IsInteractable
    {
        get => (bool)GetValue(IsInteractableProperty);
        set => SetValue(IsInteractableProperty, value);
    }

    public static readonly BindableProperty PlayLoadAnimationProperty =
        BindableProperty.Create(nameof(PlayLoadAnimation), typeof(bool), typeof(GradientButton));

    public bool PlayLoadAnimation
    {
        get => (bool)GetValue(PlayLoadAnimationProperty);
        set => SetValue(PlayLoadAnimationProperty, value);
    }
}