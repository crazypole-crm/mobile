using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CrazyPoleMobile.MVVM.Models;

namespace CrazyPoleMobile.Services.Api.Data
{

    public class ApiTrainingData
    {
        [JsonPropertyName("baseTrainingId")]
        public string BaseTrainingId { get; set; }
        [JsonPropertyName("trainingId")]
        public string TrainingId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("startDate")]
        public long StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public long EndDate { get; set; }
        [JsonPropertyName("trainerId")]
        public string TrainerId { get; set; }
        [JsonPropertyName("hallId")]
        public string HallId { get; set; }
        [JsonPropertyName("courseId")]
        public string CourseId { get; set; }
        [JsonPropertyName("type")]
        public TrainingType Type { get; set; }
        [JsonPropertyName("isCanceled")]
        public bool IsCanceled { get; set; }
        [JsonPropertyName("ssMoved")]
        public bool IsMoved { get; set; }
        [JsonPropertyName("isTrainerChanged")]
        public bool IsTrainerChanged { get; set; }
    }
}
