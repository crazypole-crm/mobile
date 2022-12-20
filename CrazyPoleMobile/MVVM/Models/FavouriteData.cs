using System.Text.Json.Serialization;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Models
{
    public class FavouriteData
    {
        public int Id { get; set; } = -1;
        public string Direction { get; set; } = string.Empty;
        public string Trainer { get; set; } = string.Empty;
        public string Hall { get; set; } = string.Empty;
        public string Uid { get; set; } = string.Empty;

        [JsonIgnore]
        public ICommand ApplyFilterCommand { get; set; }
    }
}
