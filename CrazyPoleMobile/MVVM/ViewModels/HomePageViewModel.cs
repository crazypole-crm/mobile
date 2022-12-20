﻿using CommunityToolkit.Mvvm.ComponentModel;
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

        private async void InitDirections()
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

        [ObservableProperty]
        private ObservableCollection<FavouriteData> _favourites = new();

        [ObservableProperty]
        private ObservableCollection<HomeDirectionData> _directions = new();
    }
}
