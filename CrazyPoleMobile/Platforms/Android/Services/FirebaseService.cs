﻿using Android.App;
using Android.Content;
using AndroidX.Core.App;
using Firebase.Messaging;
using Storage = Microsoft.Maui.Storage.SecureStorage;
using SKeys = CrazyPoleMobile.Helpers.SecureStorageKeysProviderHelper;
using PK = CrazyPoleMobile.Helpers.PreferencesKeysHelper;
using CrazyPoleMobile.Helpers;
using CrazyPoleMobile.Services;

namespace CrazyPoleMobile.Platforms.Android.Services
{

    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        private Action<string> _onNewToken;
        private Action<string, string, string> _onMessageReceived;

        public FirebaseService() 
        {
            var notificationService = ServiceHelper.GetService<NotificationService>();
            _onMessageReceived = notificationService.OnMessageReceived;
            _onNewToken = notificationService.OnNewToken;
        }

        public override async void OnNewToken(string token)
        {
            base.OnNewToken(token);
            await Storage.Default.SetAsync(SKeys.DEVICE_NOTIFICATION_TOKEN_KEY, token);
            _onNewToken(token);
            FirebaseMessaging.Instance.SubscribeToTopic("crazyPole");
        }
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            SendNotification(message.Data);
        }

        private async void SendNotification(IDictionary<string, string> data) 
        {
            var key = await SecureStorage.Default.GetAsync(SKeys.USER_ID);

            if (key == null) return;

            var title = data["title"];
            var desc = data["description"];
            var userIds = data["userIds"];

            if (!userIds.Contains(key)) return; 

            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                .SetContentTitle("Crazy Pole")
                .SetSmallIcon(Resource.Mipmap.appicon)
                .SetContentText(title)
                .SetContentInfo(desc)
                .SetChannelId(MainActivity.CHANNEL_ID)
                .SetPriority(2);

            var notificationManager = NotificationManagerCompat.From(this);
            if (Preferences.Default.Get<bool>(PK.NOTIFICATIONS_ENABLE_KEY, true))
                notificationManager.Notify(MainActivity.NotificationId, notificationBuilder.Build());
            _onMessageReceived("Crazy Pole", title, desc);
        }
    }
}
