using System.Text.Json.Serialization;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Models
{
    public class HomeDirectionData
    {
        public string Direction { get; set; } = string.Empty;


        [JsonIgnore]
        public ICommand GoToCalendar { get; set; }
    }
}
