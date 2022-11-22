using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Models
{
    [Serializable]
    public class NotificationData
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public ICommand RemoveThis { get; set; } = null;

    }
}
