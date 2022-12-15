using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;
using CrazyPoleMobile.Services.Api.Data;
using CrazyPoleMobile.Services.Filters;
using System.Collections.ObjectModel;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private CalendarApi _calendarApi;
        private IFilterService<TrainingData> _filterService = new TrainingFilterService();
        private RoutePageViewModel _route;

        [ObservableProperty] private bool _loadDirectionsProcess = true;

        public HomePageViewModel(CalendarApi calendarApi,
                                 RoutePageViewModel route,
                                 IFilterService<TrainingData> filterService)
        {
            _calendarApi = calendarApi;
            _filterService = filterService;
            _route = route;
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
                _directions.Add(new() 
                { 
                    Direction = direction.Name,
                    GoToCalendar = new Command(async () => 
                    {
                        _filterService.ClearFilters();
                        _filterService.AddFilter(new DirectionFilter(direction.Name));
                        await _route.LoadCalendar();
                    })
                });
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
        private ObservableCollection<HomeDirectionData> _directions = new();
    }
}
