using CrazyPoleMobile.MVVM.Models;
using Microsoft.Maui.ApplicationModel.Communication;
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
            HttpResponseMessage response = new();
            try
            {
                response = await _client.PostAsJsonAsync<UserAuthData>(
                        $"{HC.HOST_NAME}{HC.LOGIN_ROUTE}", 
                        new() 
                        { 
                            Email = email,
                            Password = password
                        });
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> LogOut()
        {
            HttpResponseMessage response = new();
            try
            {
                response = await _client.PostAsync(
                    $"{HC.HOST_NAME}{HC.LOGOUT_ROUTE}", null);
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> Registration(string email, string password)
        {
            HttpResponseMessage response = new();
            try
            {
                response = await _client.PostAsJsonAsync<UserAuthData>(
                        $"{HC.HOST_NAME}{HC.REGISTRATION_ROUTE}",
                        new()
                        {
                            Email = email,
                            Password = password
                        });
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> CurrentUser()
        {
            HttpResponseMessage response = new();
            try
            {
                response = await _client.PostAsJsonAsync<UserAuthData>(
                        $"{HC.HOST_NAME}{HC.CURRENT_USER}", null);
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }
            return response.StatusCode;
        }
    }
}
