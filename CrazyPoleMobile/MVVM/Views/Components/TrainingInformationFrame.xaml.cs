using System.Windows.Input;

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

    public static readonly BindableProperty AvailableRegistrationsCountProperty =
            BindableProperty.Create(nameof(AvailableRegistrationsCount), typeof(int), typeof(CalendarDayFrame), -1);
    public int AvailableRegistrationsCount
    {
        get => (int)GetValue(AvailableRegistrationsCountProperty);
        set => SetValue(AvailableRegistrationsCountProperty, value);
    }

    public static readonly BindableProperty IsFavouriteProperty =
            BindableProperty.Create(nameof(IsFavourite), typeof(bool), typeof(CalendarDayFrame), false);
    public bool IsFavourite
    {
        get => (bool)GetValue(IsFavouriteProperty);
        set => SetValue(IsFavouriteProperty, value);
    }

    public static readonly BindableProperty AddFavouriteProperty =
            BindableProperty.Create(nameof(AddFavourite), typeof(ICommand), typeof(CalendarDayFrame));
    public ICommand AddFavourite
    {
        get => (ICommand)GetValue(AddFavouriteProperty);
        set => SetValue(AddFavouriteProperty, value);
    }

    public static readonly BindableProperty RemoveFavouriteProperty =
            BindableProperty.Create(nameof(RemoveFavourite), typeof(ICommand), typeof(CalendarDayFrame));
    public ICommand RemoveFavourite
    {
        get => (ICommand)GetValue(RemoveFavouriteProperty);
        set => SetValue(RemoveFavouriteProperty, value);
    }
}