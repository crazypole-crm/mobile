using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services.Api;
using CrazyPoleMobile.Services.Api.Data;
using System.Collections.ObjectModel;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private CalendarApi _calendarApi;

        [ObservableProperty] private bool _loadDirectionsProcess = true;

        public HomePageViewModel(CalendarApi calendarApi)
        {
            _calendarApi = calendarApi;
            InitAsync();
        }

        private async void InitAsync()
        {
             await InitDirections();
        }

        private async Task InitDirections()
        {
            LoadDirectionsProcess = true;
            var directions = await _calendarApi.GetDirections();
            foreach (ApiDirectionData direction in directions)
            {
                await AddDirection(direction);
                if (LoadDirectionsProcess)
                    LoadDirectionsProcess = false;
            }
            LoadDirectionsProcess = false;
        }

        private async Task AddDirection(ApiDirectionData direction)
        {
            await Task.Run(() => 
            {
                _directions.Add(new() { Direction = direction.Name });
            });
        }


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
            //new() { Direction = "Pole Dance", Description = "Desc" },
            //new() { Direction = "Pole Exotic", Description = "Desc" },
            //new() { Direction = "Йога", Description = "Desc" }
        };
    }
}
