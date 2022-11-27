using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services.Api
{
    public interface ITrainingsApi
    {
        public Task<HttpStatusCode> GetTrainingsList();
    }
}
