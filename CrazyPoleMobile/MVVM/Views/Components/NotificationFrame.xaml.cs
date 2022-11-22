using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.Components;

public partial class NotificationFrame : ContentView
{
	public NotificationFrame()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(NotificationFrame));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set
        {
            SetValue(TitleProperty, value);
        }
    }

    public static readonly BindableProperty SubtitleProperty =
        BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(NotificationFrame));

    public string Subtitle
    {
        get => (string)GetValue(SubtitleProperty);
        set
        {
            SetValue(SubtitleProperty, value);
        }
    }

    public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(nameof(Description), typeof(string), typeof(NotificationFrame));

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set
        {
            SetValue(DescriptionProperty, value);
        }
    }


    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NotificationFrame));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set
        {
            SetValue(CommandProperty, value);
        }
    }
}