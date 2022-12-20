using CommunityToolkit.Maui.Views;
using CrazyPoleMobile.MVVM.Models;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.Popups;

public partial class RegistrationForTraining : Popup
{
	private readonly ICommand _okCommand;
    private readonly ICommand _cancelCommand;
    private readonly TrainingData _trainingData;
   
    public ICommand OkCommand => new Command(() => 
    {
        _okCommand.Execute(null);
        Close();
    });
    public ICommand CancelCommand => new Command(() => 
    {
        _cancelCommand.Execute(null);
        Close();
    });

    public string Direction => _trainingData.Direction.Name;
    public string TimeInterval
    {
        get 
        {
            string timeStart = _trainingData.DateStart.ToString("hh:mm");
            string timeEnd = _trainingData.DateEnd.ToString("hh:mm");
            return $"{timeStart} - {timeEnd}";
        }
    }
    public string Hall => _trainingData.Hall.Name;
    public string AvailableSeats
    {
        get 
        {
            return $"Свободно {_trainingData.Hall.Capacity} мест";
        }
    }
    public string Description => (_trainingData.Description == string.Empty) 
        ? "Описания пока нет" 
        : _trainingData.Description;
    public string Trainer   
    {
        get
        {
            string firstName = _trainingData.Trainer.FirstName;
            string lastName = _trainingData.Trainer.LastName;
            return $"{firstName} {lastName}";
        }
    }

    public RegistrationForTraining(ICommand ok, ICommand cancel, TrainingData trainingData)
	{
        _okCommand = ok;
        _cancelCommand = cancel;
        _trainingData = trainingData;
		InitializeComponent();
	}
}