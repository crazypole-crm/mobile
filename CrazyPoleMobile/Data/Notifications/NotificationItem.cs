using SQLite;

namespace CrazyPoleMobile.Data.Notifications
{
    [Table(nameof(NotificationItem))]
    public class NotificationItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
    }
}
