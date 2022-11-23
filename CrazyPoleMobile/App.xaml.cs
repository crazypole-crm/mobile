

using CrazyPoleMobile.Services;

namespace CrazyPoleMobile;

public partial class App : Application
{
	private readonly NotificationService _notifications;

	public App(NotificationService service)
	{
		InitializeComponent();
		MainPage = new AppShell();
		_notifications = service;
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
		window.Activated += (s, e) => _notifications.LoadAllNotifications();
		window.Destroying += (s, e) => _notifications.SaveAllNotifications();
		//window.Resumed += (s, e) => _notifications.LoadAllNotifications();
		return window;
    }
}