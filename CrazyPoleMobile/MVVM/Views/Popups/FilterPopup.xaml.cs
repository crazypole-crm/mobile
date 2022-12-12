using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Filters;
using System;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.Popups;

public partial class FilterPopup : Popup
{
	private TrainingFilterService _filterService;

	public List<DirectionData> Directions { get; set; }
    public List<HallData> Halls { get; set; }
    public DirectionData SelectedDirection { get; set; }
    public HallData SelectedHall { get; set; }
    public string TrainerName { get; set; } 
    public DirectionFilter TrainingDirectionFilter { get; set; }
	public HallFilter TrainingHallFilter { get; set; }
	public TrainerFilter TrainingTrainerFilter { get; set; }
	public ICommand CloseCommand { get; set; }
	public ICommand OnApplyCommand { get; set; }
	public ICommand ClearDirectionField { get; set; }
    public ICommand ClearHallField { get; set; }
    public ICommand ClearTrainerField { get; set; }
	public ICommand ClearPickerCommand { get; set; }

    public FilterPopup(TrainingFilterService filterService,
					List<HallData> halls,
					List<DirectionData> directions,
					ICommand onApplyCommand)
	{
		CloseCommand = new Command(SaveAndClose);
        ClearDirectionField = new Command(ClearDirection);
        ClearHallField = new Command(ClearHall);
		ClearTrainerField = new Command(ClearTrainer);
        ClearPickerCommand = new Command(ClearPicker);

        OnApplyCommand = onApplyCommand;

        _filterService = filterService;

		Directions = directions;
		Halls = halls;
        
		TrainingDirectionFilter = GetDirectionFilter();
		TrainingHallFilter = GetHallFilter();
		TrainingTrainerFilter = GetTrainerFilter();

        SelectedHall = GetSelectedHall();
		SelectedDirection = GetSelectedDirection();
		TrainerName = TrainingTrainerFilter.Trainer;

        InitializeComponent();		
	}

	private void SaveAndClose()
	{
		_filterService.ClearFilters();

		AddHallFilter();
		AddDirectionFilter();
		AddTrainerFilter();

		Close();
		OnApplyCommand.Execute(null);
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
	private HallData GetSelectedHall()
	{
        foreach (var hall in Halls)
            if (hall.Name == TrainingHallFilter.Hall)
                return hall;

        return default;
    }
	private DirectionData GetSelectedDirection()
	{
        foreach(var direction in Directions)
			if(direction.Name == TrainingDirectionFilter.Direction)
				return direction;

		return default;
    }
	private void AddHallFilter()
	{
		if (SelectedHall.Name == null)
			return;

		TrainingHallFilter.Hall = SelectedHall.Name;
		_filterService.AddFilter(TrainingHallFilter);
	}
	private void AddDirectionFilter()
	{
        if (SelectedDirection.Name == null)
            return;

        TrainingDirectionFilter.Direction = SelectedDirection.Name;
        _filterService.AddFilter(TrainingDirectionFilter);
    }
	private void AddTrainerFilter()
	{
		if (TrainerName == null || 
			TrainerName == string.Empty)
			return;

		TrainingTrainerFilter.Trainer = TrainerName;
		_filterService.AddFilter(TrainingTrainerFilter);
	}
	private void ClearDirection() => SelectedDirection = default;
	private void ClearHall() => SelectedHall = default;
	private void ClearTrainer() => TrainerName = default;
	private void ClearPicker(object pickerObj)
	{
		var picker = (Picker)pickerObj;
		if (picker == null)
			return;

		picker.SelectedIndex = -1;
	}

}