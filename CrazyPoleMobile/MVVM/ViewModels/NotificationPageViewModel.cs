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
        private List<ICommand> _notificationsRef = new();

        private async void LoadMessage(NotificationData[] dataArray)
        {
            foreach (var data in dataArray)
            { 
                _notifications.Add(data);
                _notificationsRef.Add(data.RemoveThis);
                await Task.Delay(50);
            }
            UpadateBackgroundVisible();
        }

        private void DeleteAllMessage()
        {
            _notifications.Clear();
            _notificationsRef.Clear();
            UpadateBackgroundVisible();
        }

        private void DeleteNotification(NotificationData data)
        {
            _notifications.Remove(data);
            _notificationsRef.Remove(data.RemoveThis);
            UpadateBackgroundVisible();
        }

        private void AddNotification(NotificationData data)
        {
            _notifications.Add(data);
            _notificationsRef.Add(data.RemoveThis);
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
            while (_notificationsRef.Count != 0)
            {
                _notificationsRef[0].Execute(this);
                await Task.Delay(50);
            }
            UpadateBackgroundVisible();
        }

        private void UpadateBackgroundVisible()
        {
            NotificationsEmpty = _notifications.Count == 0;
        }
    }
}
