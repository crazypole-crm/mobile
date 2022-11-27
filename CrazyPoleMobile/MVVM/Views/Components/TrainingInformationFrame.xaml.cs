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

    public static readonly BindableProperty TimeEndProperty =
        BindableProperty.Create(nameof(TimeEnd), typeof(TimeOnly), typeof(CalendarDayFrame), null);
    public TimeOnly TimeEnd
    {
        get => (TimeOnly)GetValue(TimeEndProperty);
        set => SetValue(TimeEndProperty, value);
    }
}