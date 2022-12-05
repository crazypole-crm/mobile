using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.Models
{
    [Serializable]
    public class UpdateUserData
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("firstName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FirstName { get; set; } = null;
        [JsonPropertyName("middleName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MiddleName { get; set; } = null;
        [JsonPropertyName("lastName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LastName { get; set; } = null;
        [JsonPropertyName("phoneNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PhoneNumber { get; set; } = null;
        [JsonPropertyName("birthday")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BirthDay { get; set; } = null;
    }
}
