
namespace CrazyPoleMobile.Services.Api
{
    public static class HostConfiguration
    {
        public const string HOST_NAME = "http://localhost";
        public const string REGISTRATION_ROUTE = "/register";
        public const string LOGIN_ROUTE = "/login";
        public const string LOGOUT_ROUTE = "/logout";
        public const string CURRENT_USER = "/current/user_data";

        private static readonly HttpClient _client = new();
        public static HttpClient Client => _client;
    }
}
