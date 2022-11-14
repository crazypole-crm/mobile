
using System.Net;

namespace CrazyPoleMobile.Services.Api
{
    public interface IAuthenticationApi
    {
        public Task<HttpStatusCode> Registration(string email, string password);
        public Task<HttpStatusCode> LogIn(string email, string password);
        public Task LogOut();
    }
}
