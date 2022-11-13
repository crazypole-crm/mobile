
namespace CrazyPoleMobile.Services.Api
{
    public class AuthenticationApi : IAuthenticationApi
    {
        private HttpClient _client = new HttpClient();

        public Task LogIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public Task Registration(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
