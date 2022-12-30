using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Helpers;
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
        private FavouritesService _favouritesService;

        [ObservableProperty] private bool _loadDirectionsProcess = true;
        [ObservableProperty] private bool _loadFavoritesProcess = true;
        [ObservableProperty] private bool _loadSignRegistrationsProcess = true;

        [ObservableProperty] private bool _favIsEmpty = true;
        [ObservableProperty] private bool _dirIsEmpty = true;
        [ObservableProperty] private bool _SignTrainingsIsEmpty = true;

        public HomePageViewModel(CalendarApi calendarApi,
                                 RoutePageViewModel route,
                                 IFilterService<TrainingData> filterService,
                                 FavouritesService favouritesService)
        {
            _calendarApi = calendarApi;
            _filterService = filterService;
            _route = route;
            _favouritesService = favouritesService;
            InitAsync();
        }

        private async void InitAsync()
        {
            await Task.Run(() => 
            {
                InitDirections();
                InitFavourites();
            });
        }

        public async void InitSignedTrainings()
        {
            LoadSignRegistrationsProcess = true;
            SignedTrainings.Clear();
            var registrations = await _calendarApi.GetRegistrationList();

            var regData = registrations.Data.DistinctBy((x) => x.Id);

            if (registrations.Status != System.Net.HttpStatusCode.OK) return;

            var calendarService = ServiceHelper.GetService<CalendarService>();

            DateTime now = DateTime.Now;
            DateTime twoWeek = now.AddDays(14);

            var trainings = await calendarService.GetTrainingsForPeriod(
                now.Date, twoWeek.Date);
            var directions = await calendarService.GetDirections();
            var halls = await calendarService.GetHalls();
            var trainers = await calendarService.GetTrainers();


            foreach (var apiReg in regData)
            {
                var training = trainings.FirstOrDefault((train) => train.Id == apiReg.TrainingId);

                if (training == null) continue;

                training.UnregistrationCommand = new Command(async () => 
                {
                    var regId = registrations.Data.FirstOrDefault(reg => reg.TrainingId == training.Id);

                    await _calendarApi.RemoveRegister(regId.Id);
                    SignedTrainings.Remove(training);
                    ++training.AvailableRegistrationsCount;
                    UpdateEmptyView();
                });

                SignedTrainings.Add(training);
                UpdateEmptyView();
            }

            LoadSignRegistrationsProcess = false;
        }

        private async void InitDirections()
        {
            LoadDirectionsProcess = true;
            var directions = await _calendarApi.GetDirections();
            foreach (ApiDirectionData direction in directions)
            {
                await AddDirection(direction);
                if (LoadDirectionsProcess)
                    LoadDirectionsProcess = false;
                UpdateEmptyView();
            }
            LoadDirectionsProcess = false;
        }

        public async void InitFavourites()
        {
            LoadFavoritesProcess = true;
            Favourites.Clear();
            var favorites = await _favouritesService.LoadFavorites();

            foreach (var item in favorites)
            {
                item.ApplyFilterCommand = new Command(async () =>
                {
                    _filterService.ClearFilters();
                    _filterService.AddFilter(new DirectionFilter(item.Direction));
                    await _route.LoadCalendar();
                    ServiceHelper.GetService<CalendarPageViewModel>().RefreshCommand.Execute(null);
                });

                Favourites.Add(item);
                UpdateEmptyView();
            }
        }

        private async Task AddDirection(ApiDirectionData direction)
        {
            await Task.Run(() => 
            {
                Directions.Add(new() 
                { 
                    Direction = direction.Name,
                    GoToCalendar = new Command(async () => 
                    {
                        _filterService.ClearFilters();
                        _filterService.AddFilter(new DirectionFilter(direction.Name));
                        await _route.LoadCalendar();
                        ServiceHelper.GetService<CalendarPageViewModel>().RefreshCommand.Execute(null);
                    })
                });
            });
        }

        public void UpdateEmptyView()
        {
            FavIsEmpty = Favourites.Count == 0;
            DirIsEmpty = Directions.Count == 0;
            SignTrainingsIsEmpty = SignedTrainings.Count == 0;
        }

        [ObservableProperty]
        private ObservableCollection<FavouriteData> _favourites = new();

        [ObservableProperty]
        private ObservableCollection<HomeDirectionData> _directions = new();

        [ObservableProperty]
        private ObservableCollection<TrainingData> _signedTrainings = new();
    }
}
