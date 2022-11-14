using CrazyPoleMobile.MVVM.Models;
using System.Net;
using System.Net.Http.Json;
using HC = CrazyPoleMobile.Services.Api.HostConfiguration;

namespace CrazyPoleMobile.Services.Api
{


    public class AuthenticationApi : IAuthenticationApi
    {
        private readonly HttpClient _client = HC.Client;

        public async Task<HttpStatusCode> LogIn(string email, string password)
        {
            var response = await _client.PostAsJsonAsync<UserAuthData>(
                    $"{HC.HOST_NAME}{HC.LOGIN_ROUTE}", 
                    new() 
                    { 
                        Email = email,
                        Password = password
                    });
            return response.StatusCode;
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> Registration(string email, string password)
        {
            var response = await _client.PostAsJsonAsync<UserAuthData>(
                    $"{HC.HOST_NAME}{HC.REGISTRATION_ROUTE}",
                    new()
                    {
                        Email = email,
                        Password = password
                    });
            return response.StatusCode;
        }
    }
}
