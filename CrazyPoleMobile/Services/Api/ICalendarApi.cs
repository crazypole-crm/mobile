
using System.Net;

namespace CrazyPoleMobile.Services.Api
{
    public interface ICalendarApi
    {
        public Task<HttpStatusCode> GetDirections();
        public Task<HttpStatusCode> GetTrainingsForPeriod(DateTime start, DateTime end);
        public Task<HttpStatusCode> GetHalls();
    }
}
