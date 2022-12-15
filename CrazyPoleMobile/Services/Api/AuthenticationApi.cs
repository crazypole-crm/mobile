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
            HttpResponseMessage response = null;
            Retry:
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
                if (response == null)
                {
                    await Task.Delay(3000);
                    goto Retry;
                }
            }

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> LogOut()
        {
            HttpResponseMessage response = null;
            Retry:
            try
            {
                response = await _client.PostAsync(
                    $"{HC.HOST_NAME}{HC.LOGOUT_ROUTE}", null);
            }
            catch 
            {
                if (response == null)
                {
                    await Task.Delay(3000);
                    goto Retry;
                }
            }

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> Registration(string email, string password)
        {
            HttpResponseMessage response = null;
            Retry:
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
                if (response == null)
                {
                    await Task.Delay(3000);
                    goto Retry;
                }
            }

            return response.StatusCode;
        }

        public async Task<HttpData<UserAuthData>> CurrentUser()
        {
            HttpResponseMessage response = null;
            HttpData<UserAuthData> data = new();
            Retry:
            try
            {
                response = await _client.PostAsync(
                        $"{HC.HOST_NAME}{HC.CURRENT_USER_ROUTE}", null);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadFromJsonAsync<UserAuthData>();
                    data.Data = content;
                }
                data.Status = response.StatusCode;
                return data;
            }
            catch 
            {
                if (response == null)
                {
                    await Task.Delay(3000);
                    goto Retry;
                }

                data.Status = response.StatusCode;
                return data;
            }

            throw new Exception("No response received");
        }

        public async Task<HttpStatusCode> ChangePassword(ChangePasswordData request)
        {
            HttpResponseMessage response = null;
            Retry:
            try
            {
                response = await _client.PostAsJsonAsync(
                        $"{HC.HOST_NAME}{HC.CHANGE_PASS_ROUTE}", request);
            }
            catch 
            {
                if (response == null)
                {
                    await Task.Delay(3000);
                    goto Retry;
                }
            }
           
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateUserData(UpdateUserData request)
        {
            HttpResponseMessage response = new();
            Retry:
            try
            {
                response = await _client.PostAsJsonAsync(
                        $"{HC.HOST_NAME}{HC.CHANGE_USER_DATA_ROUTE}",
                        request);
            }
            catch 
            {
                if (response == null)
                {
                    await Task.Delay(3000);
                    goto Retry;
                }
            }

            return response.StatusCode;
        }
    }
}
