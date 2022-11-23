using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.Services.Api;
using PK = CrazyPoleMobile.Helpers.PreferencesKeysHelper;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class SettingsPageViewModel : ObservableObject
    {
        private readonly AuthenticationApi _auth;
        private readonly RoutePageViewModel _route;

        private bool _notificationEnabled = true;

        public bool NotificationEnabled
        {
            get => _notificationEnabled;
            set
            {
                if (Preferences.Default.ContainsKey(PK.NOTIFICATIONS_ENABLE_KEY))
                {
                    Preferences.Default.Remove(nameof(PK.NOTIFICATIONS_ENABLE_KEY));
                }
                Preferences.Default.Set(nameof(PK.NOTIFICATIONS_ENABLE_KEY), value);
                SetProperty(ref _notificationEnabled, value);
            }
        }

        public SettingsPageViewModel(
            AuthenticationApi auth,
            RoutePageViewModel route)
        {
            _auth = auth;
            _route = route;
        }

        [RelayCommand]
        private async void LogOut()
        {
            _route.LoadLogInPage();
            await _auth.LogOut();
        }

        [RelayCommand]
        private static void OpenVK(object sender)
        {
            OpenUri("https://vk.com/crazypole");
        }

        [RelayCommand]
        private static void OpenWebSite(object sender)
        {
            OpenUri("https://crazypole.tilda.ws/");
        }

        [RelayCommand]
        private static void OpenWhatsApp(object sender)
        {
            OpenUri("https://wa.me/79177073451");
        }

        [RelayCommand]
        private static void OpenTelegramm(object sender)
        {
            OpenUri("https://t.me/kaktusishka");
        }

        private static async void OpenUri(string url)
        {
            try
            {
                Uri uri = new(url);
                BrowserLaunchOptions options = new()
                {
                    LaunchMode = BrowserLaunchMode.External,
                    TitleMode = BrowserTitleMode.Show
                };

                await Browser.Default.OpenAsync(uri, options);
            }
            catch (Exception /*ex*/)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}
