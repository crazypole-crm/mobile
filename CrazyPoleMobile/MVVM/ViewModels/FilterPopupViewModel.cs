using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class FilterPopupViewModel : ObservableObject
    {
        private TrainingFilterService _filterService;
        public List<DirectionData> Directions { get; set; }
        public List<HallData> Halls { get; set; }
        public List<UserData> Trainers { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsTrainerSelected))]
        private int _selectedDirectionIndex;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsHallSelected))]
        private int _selectedHallIndex;
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsTrainerSelected))]
        private int _selectedTrainerIndex;
        public bool IsTrainerSelected => _selectedTrainerIndex != -1;
        public bool IsHallSelected => _selectedHallIndex != -1;
        public bool IsDirectionSelected => _selectedTrainerIndex != -1;
        public DirectionFilter TrainingDirectionFilter { get; set; }
        public HallFilter TrainingHallFilter { get; set; }
        public TrainerFilter TrainingTrainerFilter { get; set; }

        public ICommand OnApplyCommand { get; set; }

        public FilterPopupViewModel(TrainingFilterService filterService,
                                    List<HallData> halls,
                                    List<DirectionData> directions,
                                    List<UserData> trainers,
                                    ICommand onApplyCommand)
        {
            OnApplyCommand = onApplyCommand;

            _filterService = filterService;

            Directions = directions;
            Halls = halls;
            Trainers = trainers;

            TrainingDirectionFilter = GetDirectionFilter();
            TrainingHallFilter = GetHallFilter();
            TrainingTrainerFilter = GetTrainerFilter();

            SelectedHallIndex = GetSelectedHallIdex();
            SelectedDirectionIndex = GetSelectedDirectionIndex();
            SelectedTrainerIndex = GetSelectedTrainerIndex();
        }

        [RelayCommand]
        private void SaveAndClose(object popupObj)
        {
            var popup = (Popup)popupObj;
            if (popup == null)
                return;
            
            _filterService.ClearFilters();

            AddHallFilter();
            AddDirectionFilter();
            AddTrainerFilter();

            popup.Close();
            OnApplyCommand.Execute(null);
        }

        [RelayCommand]
        private void Close(object popupObj)
        {
            var popup = (Popup)popupObj;
            if (popup == null)
                return;

            popup.Close();
        }

        [RelayCommand]
        private void ClearPicker(object pickerObj)
        {
            var picker = (Picker)pickerObj;
            if (picker == null)
                return;

            picker.SelectedIndex = -1;
        }

        private DirectionFilter GetDirectionFilter()
        {
            return GetFilter<DirectionFilter>(_filterService) ?? (new());
        }
        private HallFilter GetHallFilter()
        {
            return GetFilter<HallFilter>(_filterService) ?? (new());
        }
        private TrainerFilter GetTrainerFilter()
        {
            return GetFilter<TrainerFilter>(_filterService) ?? (new());
        }
        private T GetFilter<T>(TrainingFilterService service) where T : IFilterElement<TrainingData>
        {
            foreach (var filterItem in service.Filters)
                if (filterItem is T filter)
                    return filter;

            return default;
        }
        private int GetSelectedHallIdex()
        {
            for(int i = 0; i < Halls.Count; ++i)
                if (Halls[i].Name == TrainingHallFilter.Hall)
                    return i;

            return -1;
        }
        private int GetSelectedDirectionIndex()
        {
            for(int i = 0; i < Directions.Count; ++i)
                if (Directions[i].Name == TrainingDirectionFilter.Direction)
                    return i;

            return -1;
        }
        private int GetSelectedTrainerIndex()
        {
            for(int i = 0; i < Trainers.Count; ++i)
                if (Trainers[i].FullName == TrainingTrainerFilter.Trainer)
                    return i;

            return -1;
        }
        private void AddHallFilter()
        {
            if (_selectedHallIndex == -1 || Halls[_selectedHallIndex].Name == null)
                return;

            TrainingHallFilter.Hall = Halls[_selectedHallIndex].Name;
            _filterService.AddFilter(TrainingHallFilter);
        }
        private void AddDirectionFilter()
        {
            if (_selectedDirectionIndex == -1 || 
                Directions[_selectedDirectionIndex].Name == null)
                return;

            TrainingDirectionFilter.Direction = Directions[_selectedDirectionIndex].Name;
            _filterService.AddFilter(TrainingDirectionFilter);
        }
        private void AddTrainerFilter()
        {
            if (_selectedTrainerIndex == -1 || 
                Trainers[_selectedTrainerIndex] == null)
                return;

            TrainingTrainerFilter.Trainer = Trainers[_selectedTrainerIndex].FullName;
            _filterService.AddFilter(TrainingTrainerFilter);
        }

    }
}
