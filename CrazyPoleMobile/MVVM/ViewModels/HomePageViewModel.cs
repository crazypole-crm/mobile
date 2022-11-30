using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.Models;
using System.Collections.ObjectModel;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<MockFavouriteData> _favourites = new() 
        {
            new() { Direction = "Pole Dance" },
            new() { Direction = "Pole Exotic" },
            new() { Direction = "Йога" }
        };

        [ObservableProperty]
        private ObservableCollection<MockDirectionsData> _directions = new() 
        {
            new() { Direction = "Pole Dance", Description = "Desc" },
            new() { Direction = "Pole Exotic", Description = "Desc" },
            new() { Direction = "Йога", Description = "Desc" }
        };
    }
}
