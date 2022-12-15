using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using System.Collections.ObjectModel;
using CrazyPoleMobile.Extensions;
using CrazyPoleMobile.Helpers;
using CrazyPoleMobile.Data.Favourites;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class CalendarPageViewModel : ObservableObject
    {

        private ICalendarService _calendarService = new CalendarService();
        private TrainingFilterService _filterService = new();
        private List<TrainingData> _currentDayAllTrainings = new();

        [ObservableProperty]
        private CalendarDay _selectedDay;

        [ObservableProperty]
        private bool _isPageRefreshing = false;
        
        [ObservableProperty]
        private bool _isPageLoading = false;
        public ObservableCollection<TrainingData> CurrentDayTrainings { get; set; } = new();
        public ObservableCollection<CalendarDay> TrainingDays { get; set; } = new();
        public uint DaysLoadCount => 10;

        public CalendarPageViewModel(IFilterService<TrainingData> filterService) 
        {
            _filterService = (TrainingFilterService)filterService ?? new();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await Initialize();
        }

        [RelayCommand]
        private async Task Refresh()
        {
            _calendarService.ResetСache();
            _selectedDay = null;
            await Initialize();
        }

        [RelayCommand]
        private async void ShowFilterPopup()
        {
            this.ShowFilterPopup(_filterService,
                                 await _calendarService.GetHalls(),
                                 await _calendarService.GetDirections(),
                                 await _calendarService.GetTrainers(),
                                 ApplyFiltersCommand);
        }

        [RelayCommand]
        private async Task Initialize()
        {
            IsPageLoading = true;
            var today = DateTime.Now.Date;
            await DatePickerSelectDay(new CalendarDay(today));
            IsPageLoading = false;
            IsPageRefreshing = false;
        }

        [RelayCommand]
        private async Task DatePickerSelectDay(object sender)
        {
            var selectedDay = sender as CalendarDay;
            
            if(selectedDay == null) 
                return;

            TrainingDays.Clear();

            await SetDays(selectedDay.Date, DaysLoadCount, DaysLoadCount);

            await SelectDay(selectedDay);
        }

        [RelayCommand]
        private async Task ExpandDays()
        {
            if (TrainingDays.Count == 0)
                return;

            var lastDay = TrainingDays.Last();

            await SetDays(lastDay.Date, 0, DaysLoadCount);

        }

        [RelayCommand]
        private async Task SelectDay(object sender)
        {
            var selectedDay = (CalendarDay)sender;
            if (selectedDay == null || selectedDay.Equals(_selectedDay))
                return;
            
            SelectedDay = selectedDay;

            _currentDayAllTrainings = await _calendarService.GetTrainingForDay(selectedDay.Date);
            await ApplyFilters();

        }

        [RelayCommand]
        private async Task ApplyFilters()
        {
            CurrentDayTrainings.Clear();

            var favorService = ServiceHelper.GetService<FavouritesService>();
            var homePageVm = ServiceHelper.GetService<HomePageViewModel>();
            var favors = await favorService.LoadFavorites();

            await Task.Run(() =>
            {
                foreach (var item in _filterService.Filtrate(_currentDayAllTrainings).Reverse())
                {
                    item.OpenRegistrationPopup = new Command(() =>
                    {
                        OpenRegistrationPopup(item);
                    });

                    var favorItem = favors.FirstOrDefault(x => x.Direction == item.Direction.Name);

                    item.IsFavourite = favorItem != null;

                    if (favorItem == null)
                        favorItem = new FavouriteData() 
                        {
                            Direction = item.Direction.Name
                        };

                    item.AddFavourireCommand = new Command(async () => 
                    {
                        await Task.Run(() => 
                        {
                            favorService.AddFavorites(favorItem);
                            item.IsFavourite = true;
                        });
                        homePageVm.InitFavourites();
                        await ApplyFilters();
                    });

                    item.RemoveFavouriteCommand = new Command(async () => 
                    {
                        await Task.Run(() =>
                        {
                            favorService.DeleteFavorite(favorItem);
                            item.IsFavourite = false;
                        });
                        homePageVm.InitFavourites();
                        await ApplyFilters();
                    });

                    CurrentDayTrainings.Add(item);
                }
            });
        }

        private void OpenRegistrationPopup(TrainingData trainingData)
        {
            this.OpenRegistrationForLesson(
                ok: new Command(() => { }),
                cancel: new Command(() => { }),
                data: trainingData
                );
        }

        private async Task SetDays(DateTime day, uint daysBefore, uint daysAfter)
        {
            var trainingDays = 
                await _calendarService.GetTrainingDays(day, daysBefore, daysAfter);

            foreach (var item in trainingDays)
                TrainingDays.Add(item);
        }
    }
}
