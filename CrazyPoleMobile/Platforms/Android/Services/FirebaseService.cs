
using Android.App;
using Android.Content;
using AndroidX.Core.App;
using Firebase.Messaging;

namespace CrazyPoleMobile.Platforms.Android.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public const string DEVICE_TOKEN_NAME = "DeviceToken";

        public FirebaseService() { }
        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
            if (Preferences.ContainsKey(DEVICE_TOKEN_NAME))
            {
                Preferences.Remove(DEVICE_TOKEN_NAME);
            }

            Preferences.Set(DEVICE_TOKEN_NAME, token);
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
