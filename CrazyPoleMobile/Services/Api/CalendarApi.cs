
using System.Net;

namespace CrazyPoleMobile.Services.Api
{
    public class CalendarApi : ICalendarApi
    {
        public Task<HttpStatusCode> GetDirections()
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> GetHalls()
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> GetTrainingsForPeriod(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
