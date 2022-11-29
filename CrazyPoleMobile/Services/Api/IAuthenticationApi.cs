
using System.Net;

namespace CrazyPoleMobile.Services.Api
{
    public class LogInArgs
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.NotFound;
        public string Id { get; set; } = string.Empty;
    }

    public interface IAuthenticationApi
    {
        public Task<HttpStatusCode> Registration(string email, string password);
        public Task<HttpStatusCode> LogIn(string email, string password);
        public Task<HttpStatusCode> LogOut();
        public Task<HttpStatusCode> CurrentUser();
    }
}
