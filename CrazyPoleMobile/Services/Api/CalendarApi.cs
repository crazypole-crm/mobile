
using Android.Service.Autofill;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services.Api.Data;
using Java.Security;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CrazyPoleMobile.Services.Api
{
    public class CalendarApi : ICalendarApi
    {
        private struct Period
        {
            public long StartDate { get; set; }
            public long EndDate { get; set; }
        }

        private struct UsersData
        {
            public List<string> Ids { get; set; }
        }

        private JsonSerializerOptions _jsonOptions = new()
        {
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

        private HttpClient _client;

        public CalendarApi()
        {
            _client = new();
            _client.BaseAddress =  new("http://10.0.2.2");
        }

        public async Task<List<ApiDirectionData>> GetDirections()
        {
            HttpResponseMessage response = new();
            List<ApiDirectionData> directionData = new();
            try
            {
                response = await _client.PostAsync(
                    "/list/courses", null);

                var inputJson = await response.Content.ReadAsStreamAsync();
                directionData = await JsonSerializer.DeserializeAsync<List<ApiDirectionData>>(inputJson, _jsonOptions);
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }

            return directionData;
        }

        public async Task<List<ApiHallData>> GetHalls()
        {
            HttpResponseMessage response = new();
            List<ApiHallData> directionData = new();
            try
            {
                response = await _client.PostAsync(
                    "/list/courses", null);

                var inputJson = await response.Content.ReadAsStreamAsync();
                directionData = await JsonSerializer.DeserializeAsync<List<ApiHallData>>(inputJson, _jsonOptions);
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }

            return directionData;
        }

        public async Task<List<ApiTrainingData>> GetTrainingsForPeriod(DateTime start, DateTime end)
        {
            HttpResponseMessage response = new();
            List<ApiTrainingData> trainingData = new();
            try
            {
                response = await _client.PostAsJsonAsync<Period>(
                    "/list/trainings",
                    new()
                    {
                        StartDate = ((DateTimeOffset)start).ToUnixTimeMilliseconds(),
                        EndDate = ((DateTimeOffset)end).ToUnixTimeMilliseconds()
                    });

                var inputJson = await response.Content.ReadAsStreamAsync();
                trainingData = await JsonSerializer.DeserializeAsync<List<ApiTrainingData>>(inputJson, _jsonOptions);
        }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }

            return trainingData;
        }

        public async Task<List<ApiUserData>> GetUsersDataByIds(List<string> UsersId)
        {
            HttpResponseMessage response = new();
            List<ApiUserData> usersData = new();
            try
            {
                response = await _client.PostAsJsonAsync<UsersData>(
                "/get/users_data", 
                new()
                {
                    Ids = UsersId
                });
                var inputJson = await response.Content.ReadAsStreamAsync();
                usersData = await JsonSerializer.DeserializeAsync<List<ApiUserData>>(inputJson, _jsonOptions);

            }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }

            return usersData;
        }
    }
}
