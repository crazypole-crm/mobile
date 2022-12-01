using CrazyPoleMobile.MVVM.Models;
using System.Data;
using System.Net;
using System.Net.Http.Json;
using HC = CrazyPoleMobile.Services.Api.HostConfiguration;
using SK = CrazyPoleMobile.Helpers.SecureStorageKeysProviderHelper;

namespace CrazyPoleMobile.Services.Api
{
    public class AuthenticationApi : IAuthenticationApi
    {
        private readonly HttpClient _client = HC.Client;
        private readonly CookieContainer _cookies = HC.Cookies;

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
            catch (Exception /*ex*/)
            {
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
            }
            return response.StatusCode;
        }

        public async Task<HttpData<UserAuthData>> CurrentUser()
        {
            HttpResponseMessage response = new();
            HttpData<UserAuthData> data = new();
            try
            {
                response = await _client.PostAsync(
                        $"{HC.HOST_NAME}{HC.CURRENT_USER}", null);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadFromJsonAsync<UserAuthData>();
                    data.Data = content;
                }
            }
            finally
            {
                data.Status = response.StatusCode;
            }
            return data;
        }

        public async Task<HttpStatusCode> ChangePassword(ChangePasswordData request)
        {
            HttpResponseMessage response = new();
            HttpStatusCode status;
            try
            {
                response = await _client.PostAsJsonAsync(
                        $"{HC.HOST_NAME}{HC.CHANGE_PASS}", request);
            }
            finally
            {
                status = response.StatusCode;   
            }
            return status;
        }
    }
}
