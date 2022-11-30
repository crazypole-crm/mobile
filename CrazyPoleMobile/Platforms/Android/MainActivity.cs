using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CrazyPoleMobile;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    private static int _notificationId = 0;

    public const string CHANNEL_ID = "PUSH_NOTIFY_CHANNEL";
    public static int NotificationId 
    {
        set => _notificationId = value;
        get
        {
            ++_notificationId;
            return _notificationId;
        }
    } 

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
