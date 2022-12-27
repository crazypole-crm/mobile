
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services.Api.Data;
using System.Net;

namespace CrazyPoleMobile.Services.Api
{
    public interface ICalendarApi
    {
        public Task<HttpStatusCode> RegisterOnTraining(string trainingId);
        public Task<HttpStatusCode> RemoveRegister(string registrationId);
        public Task<HttpData<List<ApiRegistrationData>>> GetRegistrationList();
        public Task<List<ApiTrainingData>> GetTrainingsForPeriod(DateTime start, DateTime end, List<string> ids = null);
        public Task<List<ApiUserData>> GetUsersDataByIds(List<string> UserId);
        public Task<List<ApiDirectionData>> GetDirections();
        public Task<List<ApiUserData>> GetTrainers();
        public Task<List<ApiHallData>> GetHalls();
    }
}
