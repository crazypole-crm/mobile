using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services.Api
{
    public interface ICalendarApi
    {
        public Task GetDirections();
        public Task GetTrainingsForPeriod(DateTime start, DateTime end);
        public Task GetHalls();
    }
}
