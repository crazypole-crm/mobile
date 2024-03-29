using Microsoft.Maui.Controls.Shapes;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class GradientField : ContentView
{
    public GradientField()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty IsAttentionProperty =
        BindableProperty.Create(nameof(IsAttention), typeof(bool), typeof(GradientField), false);

    public bool IsAttention
    {
        get => (bool)GetValue(IsAttentionProperty);
        set 
        { 
            SetValue(IsAttentionProperty, value);
        }       
    }

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(GradientField), false);

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

    public static readonly BindableProperty AttentionTextProperty =
        BindableProperty.Create(nameof(AttentionText), typeof(string), typeof(GradientField));

    public string AttentionText
    {
        get => (string)GetValue(AttentionTextProperty);
        set => SetValue(AttentionTextProperty, value);
    }

    public static readonly BindableProperty LockProperty =
        BindableProperty.Create(nameof(Lock), typeof(bool), typeof(GradientField));

    public bool Lock
    {
        get => (bool)GetValue(LockProperty);
        set 
        {
            SetValue(LockProperty, value);
        } 
    }

    public void OnFocus(object sender, FocusEventArgs args)
	{
        IsAttention = false;
        if (Application.Current.Resources.TryGetValue("DefaultGradient", out object data) &&
                  !Lock)
        {
            Framing.Stroke = (LinearGradientBrush)data;
        }
	}

    public void OnUnfocus(object sender, FocusEventArgs args)
    {
        if (Application.Current.Resources.TryGetValue("DefaultGray", out object data) &&
            !Lock)
        {
            Framing.Stroke = (LinearGradientBrush)data;
        }
    }
}