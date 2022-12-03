using CrazyPoleMobile.MVVM.Models;
using System.Text.Json;
using System.Net;
using System.Net.Http.Json;
using HC = CrazyPoleMobile.Services.Api.HostConfiguration;
using SK = CrazyPoleMobile.Helpers.SecureStorageKeysProviderHelper;

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
            catch { }

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
            catch { }

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
            catch { }

            return response.StatusCode;
        }

        public async Task<HttpData<UserAuthData>> CurrentUser()
        {
            HttpResponseMessage response = new();
            HttpData<UserAuthData> data = new();
            try
            {
                response = await _client.PostAsync(
                        $"{HC.HOST_NAME}{HC.CURRENT_USER_ROUTE}", null);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadFromJsonAsync<UserAuthData>();
                    data.Data = content;
                }
            }
            catch { }
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
                        $"{HC.HOST_NAME}{HC.CHANGE_PASS_ROUTE}", request);
            }
            catch { }
            finally
            {
                status = response.StatusCode;
            }
            return status;
        }

        public async Task<HttpStatusCode> UpdateUserData(UpdateUserData request)
        {
            HttpResponseMessage response = new();
            HttpStatusCode status;
            try
            {
                response = await _client.PostAsJsonAsync(
                        $"{HC.HOST_NAME}{HC.CHANGE_USER_DATA_ROUTE}",
                        request);
            }
            catch { }
            finally
            {
                status = response.StatusCode;
            }
            return status;
        }
    }
}
