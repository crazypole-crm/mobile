using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class NotificationPageViewModel : ObservableObject, IDisposable
    {
        private NotificationService _notificationService;
        [ObservableProperty]
        private bool _notificationsEmpty = true;

        public NotificationPageViewModel(NotificationService notificationService)
        {
            _notificationService = notificationService;
            _notificationService.MessageReceived += AddNotification;
            _notificationService.MessageDelete += DeleteNotification;
            _notificationService.DeleteAllMessages += DeleteAllMessage;
            _notificationService.LoadMessages += LoadMessage;
             LoadMessage(_notificationService.GetAllNotifications());
        }

        [ObservableProperty]
        private ObservableCollection<NotificationData> _notifications = new();

        private async void LoadMessage(NotificationData[] dataArray)
        {
            _notifications.Clear();
            foreach (var data in dataArray)
            {
                await Task.Run(() => 
                {
                    _notifications.Add(data);
                });
            }
            UpadateBackgroundVisible();
        }

        private void DeleteAllMessage()
        {
            _notifications.Clear();
            UpadateBackgroundVisible();
        }

        private void DeleteNotification(NotificationData data)
        {
            _notifications.Remove(data);
            UpadateBackgroundVisible();
        }

        private void AddNotification(NotificationData data)
        {
            _notifications.Add(data);
            UpadateBackgroundVisible();
        }

        public void Dispose()
        {
            _notificationService.MessageReceived -= AddNotification;
            _notificationService.MessageDelete -= DeleteNotification;
            _notificationService.DeleteAllMessages -= DeleteAllMessage;
            _notificationService.LoadMessages -= LoadMessage;
        }

        [RelayCommand]
        private async void CloseAll()
        {
            await Task.Run(() =>
            {
                while (_notifications.Count != 0)
                        _notifications[0].RemoveThis.Execute(this);
            });
            UpadateBackgroundVisible();
        }

        private void UpadateBackgroundVisible()
        {
            NotificationsEmpty = _notifications.Count == 0;
        }
    }
}
