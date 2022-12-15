
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services.Api.Data;
using System.Net;

namespace CrazyPoleMobile.Services.Api
{
    public interface ICalendarApi
    {
        public Task<List<ApiTrainingData>> GetTrainingsForPeriod(DateTime start, DateTime end);
        public Task<List<ApiUserData>> GetUsersDataByIds(List<string> UserId);
        public Task<List<ApiDirectionData>> GetDirections();
        public Task<List<ApiUserData>> GetTrainers();
        public Task<List<ApiHallData>> GetHalls();
    }
}
