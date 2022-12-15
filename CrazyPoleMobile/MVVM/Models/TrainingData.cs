
using CrazyPoleMobile.Services.Api.Data;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Models
{
    public enum TrainingType
    {
        Individual,
        Group,
    }

    public class TrainingData : IEquatable<TrainingData>
    {
        public string BaseId { get; }
        public string Id { get; }
        public DirectionData Direction { get; }
        public UserData Trainer { get; }
        public HallData Hall { get; }
        public DateTime DateStart { get; }
        public DateTime DateEnd { get; }
        public TimeSpan Duration
        {
            get => DateEnd.TimeOfDay - DateStart.TimeOfDay;
        }
        public string Description { get; }
        public int AvailableRegistrationsCount { get; }
        public bool IsCanceled { get; set; }
        public bool IsMoved { get; set; }
        public bool IsTrainerChanged { get; set; }

        [JsonIgnore]
        public ICommand OpenRegistrationPopup { get; set; }

        public TrainingData()
        { }

        public TrainingData(string baseId,
                            string id,
                            DirectionData direction,
                            UserData trainer,
                            HallData hall,
                            DateTime dateStart,
                            DateTime dateEnd,
                            string description,
                            int availableRegistrationsCount,
                            bool isCanceled,
                            bool isMoved,
                            bool isTrainerChanged)
        {
            BaseId = baseId;
            Id = id;
            Direction = direction;
            Trainer = trainer;
            Hall = hall;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Description = description;
            IsCanceled = isCanceled;
            IsMoved = isMoved;
            AvailableRegistrationsCount = availableRegistrationsCount;
            IsTrainerChanged = isTrainerChanged;
        }

        public bool Equals(TrainingData other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class GroupedTrainingData : TrainingData
    {
        public static TrainingType Type => TrainingType.Group;
        public string[] Clients { get; }
    }

    public class IndividualTrainingData : TrainingData
    {
        public static TrainingType Type => TrainingType.Individual;
        public string Client { get; }
    }
}
