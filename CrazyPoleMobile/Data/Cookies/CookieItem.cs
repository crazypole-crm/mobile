using SQLite;

namespace CrazyPoleMobile.Data.Cookies
{
    [Table(nameof(CookieItem))]
    public class CookieItem
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Value { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
        public bool HttpOnly { get; set; } = false;
        public bool Secure { get; set; } = false;
    }
}
