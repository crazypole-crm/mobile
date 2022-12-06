using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;
using CrazyPoleMobile.Services.Api.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class CalendarPageViewModel : ObservableObject
    {

        private ICalendarService _calendarService = new CalendarService();

        [ObservableProperty]
        private CalendarDay _selectedDay;
        public ObservableCollection<CalendarDay> TrainingDays { get; set; } = new();
        public ObservableCollection<TrainingData> CurrentDayTrainings { get; set; } = new();

        public uint DaysLoadCount { get; } = 10;

        public CalendarPageViewModel() 
        {
            Initialize();
        }

        [RelayCommand]
        private async Task Initialize()
        {
            var today = DateTime.Now.Date;
            await DatePickerSelectDay(new CalendarDay(today));
        }


        [RelayCommand]
        private async Task DatePickerSelectDay(object sender)
        {
            var selectedDay = sender as CalendarDay;
            
            if(selectedDay == null) 
                return;

            TrainingDays.Clear();

            await SetDays(selectedDay.Date, DaysLoadCount, DaysLoadCount);

            await Task.Delay(100);

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
            CurrentDayTrainings.Clear();
            await Task.Delay(100);

            foreach(var item in await _calendarService.GetTrainingForDay(selectedDay.Date))
                CurrentDayTrainings.Add(item);

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
