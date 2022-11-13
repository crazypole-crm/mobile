
namespace CrazyPoleMobile.MVVM.Models
{
    public enum TrainingType
    {
        Grouped     = 0,
        Individual  = 1
    }

    public class TrainingData
    {
        public string Id { get; }
        public string DirectionId { get; }
        public string TrainerId { get; }
        public string HallId { get; }
        public DateTime Date { get; } 
        public TimeOnly TimeStart { get; }
        public TimeOnly TimeEnd { get; }
        public string Description { get; }
    }

    public class GroupedTrainingData : TrainingData
    {
        public static TrainingType Type => TrainingType.Grouped;
        public string[] Clients { get; }
    }

    public class IndividualTrainingData : TrainingData
    {
        public static TrainingType Type => TrainingType.Individual;
        public string Client { get; }
    }
}
