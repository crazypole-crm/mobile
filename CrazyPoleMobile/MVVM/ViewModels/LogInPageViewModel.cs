using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views.Popups;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;
using System.ComponentModel.DataAnnotations;
using System.Net;
using SKeys = CrazyPoleMobile.Helpers.SecureStorageKeysProviderHelper;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class LogInPageViewModel : ObservableObject
    {
        private readonly RoutePageViewModel _route;
        private readonly AuthenticationApi _auth;
        private readonly ISecureStorageService _store;

        [ObservableProperty] private string _email = string.Empty;
        [ObservableProperty] private string _password = string.Empty;
        [ObservableProperty] private string _attentionText = string.Empty;

        [ObservableProperty] private bool _emailAttention = false;
        [ObservableProperty] private bool _passwordAttention = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LogInCommand))]
        private bool _notLoginProcess = true;

        public LogInPageViewModel(
            RoutePageViewModel route,
            AuthenticationApi auth,
            ISecureStorageService store)
        {
            _route = route;
            _auth = auth;
            _store = store;
        }

        [RelayCommand]
        private async void LoadSignUpPage()
        {
            await _route.LoadSignUpPage();   
        }

        [RelayCommand]
        private void LoadHomePage()
        {
            _route.LoadHome();
        }

        [RelayCommand(CanExecute = nameof(NotLoginProcess))]
        private async void LogIn()
        {
            NotLoginProcess = false;

            if (_password == string.Empty || _email == string.Empty)
            {
                
                AttentionText = "Поле обязательно к заполнению";

                EmailAttention = _email == string.Empty;
                PasswordAttention = _password == string.Empty;

                NotLoginProcess = true;
                return;
            }

            var status = await _auth.LogIn(_email, _password);

            if (status == HttpStatusCode.OK)
            { 
                _route.LoadHome();
                NotLoginProcess = true;
                //await _store.Save(SKeys.USER_EMAIL_KEY, _email);
                //await _store.Save(SKeys.USER_PASSWORD_KEY, _password);
                return;
            }

            NotLoginProcess = true;

            await App.Current.MainPage.ShowPopupAsync(
                    new ErrorPopup(status.ToString()));
        }
    }
}
