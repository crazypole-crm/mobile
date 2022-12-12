using CrazyPoleMobile.Data.Notifications;
using CrazyPoleMobile.Helpers;
using CrazyPoleMobile.MVVM.Models;

namespace CrazyPoleMobile.Services
{
    public delegate void OnMessageReceived(NotificationData data);
    public delegate void OnMessageDelete(NotificationData sender);
    public delegate void OnLoadMessages(NotificationData[] data);
    public delegate void OnDeleteAllMessages();

    public class NotificationService
    {
        private NotificationDataBase _db = ServiceHelper.GetService<NotificationDataBase>();
        private List<NotificationData> _notifications = new();

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

        public async void OnMessageReceived(string title, string subtitle, string desc)
        {
            var notification = new NotificationData()
            {
                Data = new() 
                {
                    Title = title,
                    Subtitle = subtitle,
                    Description = desc
                }
            };

            notification.Data.Id = await _db.SaveItemAsync(notification.Data);

            notification.RemoveThis = new Command(async () =>
            {
                _messageDelete?.Invoke(notification);
                await _db.DeleteItemByIdAsync(notification.Data.Id);
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
            foreach (var notification in _notifications)
                await _db.SaveItemAsync(notification.Data);
        }

        public async void LoadAllNotifications()
        {
            var dbItems = await _db.GetItemsAsync();
            _notifications.Clear();
            foreach (var item in dbItems)
                await Task.Run(() => 
                {
                    _notifications.Add(new NotificationData()
                    {
                        Data = item
                    });
                    var notification = _notifications.Last();
                    notification.RemoveThis = new Command(async () => 
                    {
                        _messageDelete?.Invoke(notification);
                        await _db.DeleteItemByIdAsync(notification.Data.Id);
                        _notifications.Remove(notification);
                    });
                });
            _loadMessages?.Invoke(_notifications.ToArray());
        }

        public NotificationData[] GetAllNotifications()
        {
            return _notifications.ToArray();
        }
    }
}
