using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CrazyPoleMobile;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public const string CHANNEL_ID = "PUSH_NOTIFY_CHANNEL";
    public const int NOTIFICATION_ID = 100;

    private NotificationManager _notificationManager;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        _notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
        CreateNotificationChannel();

    }

    private void CreateNotificationChannel()
    {
        if (OperatingSystem.IsOSPlatformVersionAtLeast("android", 26))
        {
            var channel = new NotificationChannel(CHANNEL_ID, "Push Notify Channel", NotificationImportance.Default);
            _notificationManager.CreateNotificationChannel(channel);
        }
    }
}
