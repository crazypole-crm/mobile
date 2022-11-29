using System.Net;
using CrazyPoleMobile.Helpers;
using CrazyPoleMobile.Data.Cookies;

namespace CrazyPoleMobile.Services.Api
{
    public static class HostConfiguration
    {
        public const string HOST_NAME = "http://10.0.2.2";
        public const string REGISTRATION_ROUTE = "/register";
        public const string LOGIN_ROUTE = "/login";
        public const string LOGOUT_ROUTE = "/logout";
        public const string CURRENT_USER = "/current/user_data";

        private static CookieDataBase _db = ServiceHelper.GetService<CookieDataBase>();
        private static CookieContainer _cookieContainer = new();
        private static HttpClientHandler _clientHandler = new()
        {
            UseCookies = true,
            CookieContainer = _cookieContainer
        };

        private static HttpClient _client = new(_clientHandler);

        public static HttpClient Client => _client;
        public static CookieContainer Cookies => _cookieContainer;

        public static async void SaveClientCookies()
        {
            var cookies = _cookieContainer.GetAllCookies();
            foreach (Cookie cookie in cookies.Cast<Cookie>())
                await _db.SaveItemAsync(new CookieItem() 
                {
                    Name = cookie.Name,
                    Value = cookie.Value,
                    Domain = cookie.Domain,
                    Path = cookie.Path,
                    HttpOnly = cookie.HttpOnly,
                    Secure = cookie.Secure
                });

        }

        public static async Task LoadClientCookies()
        {
            var currentCookies = _cookieContainer.GetAllCookies();
            var cookies = await _db.GetItemsAsync();
            foreach (CookieItem cookie in cookies)
            {
                var currentCookie = currentCookies.FirstOrDefault(x => x.Name == cookie.Name);
                if (currentCookie == null)
                    _cookieContainer.Add(new Cookie() 
                    {
                        Name = cookie.Name,
                        Value = cookie.Value,
                        Path = cookie.Path,
                        Domain = cookie.Domain,
                        HttpOnly = cookie.HttpOnly,
                        Secure = cookie.Secure
                    });
            }
        }
    }
}
