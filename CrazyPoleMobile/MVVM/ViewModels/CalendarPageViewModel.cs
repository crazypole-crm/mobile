using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Models;
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
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Dates))]
        private ObservableGroupedCollection<CalendarDay, TrainingData> _trainings = new();

        [ObservableProperty]
        private ObservableCollection<TrainingData> _currentDayTrainings;

        public ObservableCollection<CalendarDay> Dates 
        { 
            get 
            {
                var dates = new ObservableCollection<CalendarDay>();
                foreach (var group in _trainings)
                    dates.Add(group.Key);
                
                return dates;
            } 
        }

        public CalendarPageViewModel()
        {
            List<TrainingData> a = new() { new TrainingData() };
            var group = new ObservableGroup<CalendarDay, TrainingData>(new(new DateTime(2022, 11, 18)), a); 
            _trainings.Add(group);
            _trainings.Add(new(new CalendarDay(new DateTime(2022, 11, 19))));
            _currentDayTrainings = new ObservableCollection<TrainingData>() { new TrainingData(), new TrainingData() };
        }

        [RelayCommand]
        private void SelectDay(object sender)
        {
            var currentDay = (CalendarDay)sender;
            if (currentDay == null)
                return;

            CurrentDayTrainings = _trainings.FirstGroupByKeyOrDefault(currentDay);
        }

    }
}
