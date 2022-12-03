﻿
using System.Text.Json.Serialization;

namespace CrazyPoleMobile.MVVM.Models
{
    public enum TrainingType
    {
        Individual,
        Group,
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

        public TrainingData()
        { }
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
