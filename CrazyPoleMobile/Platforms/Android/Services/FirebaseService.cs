
using Android.App;
using Android.Content;
using AndroidX.Core.App;
using CrazyPoleMobile.Services;
using Firebase.Messaging;
using Storage = Microsoft.Maui.Storage.SecureStorage;
using SKeys = CrazyPoleMobile.Services.SecureStorageKeysProviderService;

namespace CrazyPoleMobile.Platforms.Android.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public FirebaseService() { }

        public override async void OnNewToken(string token)
        {
            base.OnNewToken(token);
            await Storage.Default.SetAsync(SKeys.DEVICE_NOTIFICATION_TOKEN_KEY, token);
        }
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var notification = message.GetNotification();

            SendNotification(notification.Body, notification.Title, message.Data);
        }

        private void SendNotification(string messageBody, string title, IDictionary<string, string> data) 
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);

            foreach (var key in data.Keys) 
            {
                intent.PutExtra(key, data[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(this,
                MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.Immutable);

            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Mipmap.appicon)
                .SetContentText(messageBody)
                .SetChannelId(MainActivity.CHANNEL_ID)
                .SetContentIntent(pendingIntent)
                .SetPriority(2);

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(MainActivity.NOTIFICATION_ID, notificationBuilder.Build());
        }
    }
}
