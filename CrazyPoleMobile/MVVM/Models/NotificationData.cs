using CrazyPoleMobile.Data.Notifications;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Models
{
    [Serializable]
    public class NotificationData
    {
        [JsonInclude]
        public NotificationItem Data { get; set; }

        [JsonIgnore]
        public ICommand RemoveThis { get; set; } = null;

    }
}
