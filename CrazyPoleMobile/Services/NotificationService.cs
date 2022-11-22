using CrazyPoleMobile.MVVM.Models;
using System.Text.Json;

namespace CrazyPoleMobile.Services
{
    public delegate void OnMessageReceived(NotificationData data);
    public delegate void OnMessageDelete(NotificationData sender);
    public delegate void OnLoadMessages(NotificationData[] data);
    public delegate void OnDeleteAllMessages();

    public class NotificationService
    {
        private List<NotificationData> _notifications = new();
        private string _localStoragePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private const string DATA_FILE_NAME = "NotificationData.dat";

        private OnMessageReceived _messageReceived;
        private OnMessageDelete _messageDelete;
        private OnLoadMessages _loadMessages;
        private OnDeleteAllMessages _deleteAllMessages;

        public event OnMessageReceived MessageReceived
        {
            add => _messageReceived += value;
            remove => _messageReceived -= value;
        }

        public event OnMessageDelete MessageDelete
        {
            add => _messageDelete += value;
            remove => _messageDelete -= value;
        }

        public event OnLoadMessages LoadMessages
        {
            add => _loadMessages += value;
            remove => _loadMessages -= value;
        }

        public event OnDeleteAllMessages DeleteAllMessages
        {
            add => _deleteAllMessages += value;
            remove => _deleteAllMessages -= value;
        }

        public void OnNewToken(string token)
        {
        }

        public void OnMessageReceived(string title, string subtitle, string desc)
        {
            var notification = new NotificationData()
            {
                Title = title,
                Subtitle = subtitle,
                Description = desc
            };
            notification.RemoveThis = new Command(() =>
            {
                _messageDelete?.Invoke(notification);
                _notifications.Remove(notification);
            });
            _notifications.Add(notification);
            _messageReceived?.Invoke(notification);
        }

        public void DeleteAllNotifications()
        {
            _notifications.Clear();
            _deleteAllMessages?.Invoke();
        }

        public async void SaveAllNotifications()
        {
            using (FileStream fs = new($"{_localStoragePath}/{DATA_FILE_NAME}", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, _notifications.ToArray());
            }
        }

        public async void LoadAllNotifications()
        {
            if (!File.Exists($"{_localStoragePath}/{DATA_FILE_NAME}")) return;
            using (FileStream fs = new($"{_localStoragePath}/{DATA_FILE_NAME}", FileMode.OpenOrCreate))
            {
                var arrayData = await JsonSerializer.DeserializeAsync<NotificationData[]>(fs);
                DeleteAllNotifications();
                foreach (var data in arrayData)
                    data.RemoveThis = new Command(() =>
                    {
                        _messageDelete?.Invoke(data);
                        _notifications.Remove(data);
                    });
                
                _notifications.AddRange(arrayData);
            }
            _loadMessages?.Invoke(_notifications.ToArray());
        }

        public NotificationData[] GetAllNotifications()
        {
            return _notifications.ToArray();
        }
    }
}
