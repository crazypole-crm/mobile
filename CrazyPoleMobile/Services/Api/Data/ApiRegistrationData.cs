using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services.Api.Data
{
    public class ApiRegistrationData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("trainingId")]
        public string TrainingId { get; set; } = string.Empty;
        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;
        [JsonPropertyName("status")]
        public ApiRegistrationStatus Status { get; set; }
    }
}
