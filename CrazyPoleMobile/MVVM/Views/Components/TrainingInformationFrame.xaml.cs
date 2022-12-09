namespace CrazyPoleMobile.MVVM.Views.Components;

public partial class TrainingInformationFrame : ContentView
{
	public TrainingInformationFrame()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TimeStartProperty =
            BindableProperty.Create(nameof(TimeStart), typeof(TimeOnly), typeof(CalendarDayFrame), null);
    public TimeOnly TimeStart
    {
        get => (TimeOnly)GetValue(TimeStartProperty);
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

    public static readonly BindableProperty TrainerFirstNameProperty =
            BindableProperty.Create(nameof(TrainerFirstName), typeof(string), typeof(CalendarDayFrame), "");
    public string TrainerFirstName
    {
        get => (string)GetValue(TrainerFirstNameProperty);
        set => SetValue(TrainerFirstNameProperty, value);
    }

    public static readonly BindableProperty TrainerLastNameProperty =
            BindableProperty.Create(nameof(TrainerLastName), typeof(string), typeof(CalendarDayFrame), "");
    public string TrainerLastName
    {
        get => (string)GetValue(TrainerLastNameProperty);
        set => SetValue(TrainerLastNameProperty, value);
    }

    public static readonly BindableProperty TrainerChangedProperty =
            BindableProperty.Create(nameof(TrainerChanged), typeof(bool), typeof(CalendarDayFrame), false);
    public bool TrainerChanged
    {
        get => (bool)GetValue(TrainerChangedProperty);
        set => SetValue(TrainerChangedProperty, value);
    }

    public string TrainerFirstLastName
    {
        get 
        {
            return TrainerLastName;
        }
    }
}