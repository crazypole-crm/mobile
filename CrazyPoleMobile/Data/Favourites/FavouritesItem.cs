using SQLite;

namespace CrazyPoleMobile.Data.Favourites
{
    public class FavouritesItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Direction { get; set; }
        public string Hall { get; set; }
        public string Trainer { get; set; }
    }
}
