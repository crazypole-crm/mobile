﻿using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services.Api.Data;
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

        public async Task<List<ApiDirectionData>> GetDirections()
        {
            HttpResponseMessage response = new();
            List<ApiDirectionData> directionData = new();
            try
            {
                response = await HostConfiguration.Client.PostAsync(
                    $"{HostConfiguration.HOST_NAME}{HostConfiguration.GET_DIRECTION_ROUTE}", 
                    null);

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
                response = await HostConfiguration.Client.PostAsync(
                    $"{HostConfiguration.HOST_NAME}{HostConfiguration.GET_HALLS_ROUTE}", null);

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
                response = await HostConfiguration.Client.PostAsJsonAsync<Period>(
                    $"{HostConfiguration.HOST_NAME}{HostConfiguration.GET_TRAININGS_ROUTE}",
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
            List<ApiUserData> usersData = new();
            
            if(UsersId.Count == 0)
                return usersData;

            HttpResponseMessage response = new();
            try
            {
                response = await HostConfiguration.Client.PostAsJsonAsync<UsersData>(
                $"{HostConfiguration.HOST_NAME}{HostConfiguration.GET_USER_DATA_ROUTE}", 
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

        public async Task<List<ApiUserData>> GetTrainers()
        {
            HttpResponseMessage response = new();
            List<ApiUserData> TrainersData = new();
            try
            {
                //response = await HostConfiguration.Client.PostAsync(
                //    $"{HostConfiguration.HOST_NAME}{HostConfiguration.GET_HALLS_ROUTE}", null);

                //var inputJson = await response.Content.ReadAsStreamAsync();
                //directionData = await JsonSerializer.DeserializeAsync<List<ApiHallData>>(inputJson, _jsonOptions);
                await Task.Delay(100);
                var mockTrainer = new ApiUserData() 
                { 
                    Id = "asdada",
                    AvatarUrl = "",
                    Birthday = "8/12/2000",
                    Email = "asd@mail.com",
                    FirstName = "Loh",
                    LastName = "Ne",
                    MiddleName = "Lohovich",
                    LastVisit = "",
                    Phone = "88005553535",
                    Role = UserRole.Trainer
                };
                TrainersData.Add(mockTrainer);
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }

            return TrainersData;
        }
    }
}
