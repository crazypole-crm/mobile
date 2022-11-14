
namespace CrazyPoleMobile.Services.Api
{
    public interface IAuthenticationApi
    {
        public Task Registration(string email, string password);
        public Task LogIn(string email, string password);
        public Task LogOut();
    }
}
