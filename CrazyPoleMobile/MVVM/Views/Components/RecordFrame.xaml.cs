using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.Components;

public partial class RecordFrame : ContentView
{
	public RecordFrame()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty DirectionTextProperty =
        BindableProperty.Create(nameof(DirectionText), typeof(string), typeof(RecordFrame));

    public string DirectionText
    {
        get => (string)GetValue(DirectionTextProperty);
        set
        {
            SetValue(DirectionTextProperty, value);
        }
    }

    public static readonly BindableProperty HallTextProperty =
        BindableProperty.Create(nameof(HallText), typeof(string), typeof(RecordFrame));

    public string HallText
    {
        get => (string)GetValue(HallTextProperty);
        set
        {
            SetValue(HallTextProperty, value);
        }
    }

    public static readonly BindableProperty TrainerTextProperty =
        BindableProperty.Create(nameof(TrainerText), typeof(string), typeof(RecordFrame));

    public string TrainerText
    {
        get => (string)GetValue(TrainerTextProperty);
        set
        {
            SetValue(TrainerTextProperty, value);
        }
    }

    public static readonly BindableProperty StartDateProperty =
        BindableProperty.Create(nameof(StartDate), typeof(DateTime), typeof(RecordFrame));

    public DateTime StartDate
    {
        get => (DateTime)GetValue(StartDateProperty);
        set
        {
            SetValue(StartDateProperty, value);
        }
    }

    public static readonly BindableProperty ButtonCommandProperty =
        BindableProperty.Create(nameof(ButtonCommand), typeof(ICommand), typeof(RecordFrame));

    public ICommand ButtonCommand
    {
        get => (ICommand)GetValue(ButtonCommandProperty);
        set
        {
            SetValue(ButtonCommandProperty, value);
        }
    }
}