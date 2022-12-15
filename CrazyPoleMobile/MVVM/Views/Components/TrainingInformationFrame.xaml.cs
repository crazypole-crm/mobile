namespace CrazyPoleMobile.MVVM.Views.Components;

public partial class TrainingInformationFrame : ContentView
{
	public TrainingInformationFrame()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TimeStartProperty =
            BindableProperty.Create(nameof(TimeStart), typeof(DateTime), typeof(CalendarDayFrame), null);
    public DateTime TimeStart
    {
        get => (DateTime)GetValue(TimeStartProperty);
        set => SetValue(TimeStartProperty, value);
    }

    public static readonly BindableProperty DurationProperty =
        BindableProperty.Create(nameof(Duration), typeof(TimeSpan), typeof(CalendarDayFrame), null);
    public TimeSpan Duration
    {
        get => (TimeSpan)GetValue(DurationProperty);
        set => SetValue(DurationProperty, value);
    }

    public static readonly BindableProperty TrainingNameProperty =
            BindableProperty.Create(nameof(TrainingName), typeof(string), typeof(CalendarDayFrame), "");
    public string TrainingName
    {
        get => (string)GetValue(TrainingNameProperty);
        set => SetValue(TrainingNameProperty, value);
    }

    public static readonly BindableProperty TrainerNameProperty =
            BindableProperty.Create(nameof(TrainerName), typeof(string), typeof(CalendarDayFrame), "");
    public string TrainerName
    {
        get => (string)GetValue(TrainerNameProperty);
        set => SetValue(TrainerNameProperty, value);
    }

    public static readonly BindableProperty TrainerChangedProperty =
            BindableProperty.Create(nameof(TrainerChanged), typeof(bool), typeof(CalendarDayFrame), false);
    public bool TrainerChanged
    {
        get => (bool)GetValue(TrainerChangedProperty);
        set => SetValue(TrainerChangedProperty, value);
    }
}