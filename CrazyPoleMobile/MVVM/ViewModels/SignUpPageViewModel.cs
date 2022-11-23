using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views.Popups;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;
using System.Net;
using SKeys = CrazyPoleMobile.Helpers.SecureStorageKeysProviderHelper;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class SignUpPageViewModel : ObservableObject
    {
        private readonly RoutePageViewModel _route;
        private readonly AuthenticationApi _auth;
        private readonly ISecureStorageService _store;

        [ObservableProperty] private string _email = string.Empty;
        [ObservableProperty] private string _password = string.Empty;
        [ObservableProperty] private string _repeatPassword = string.Empty;
        [ObservableProperty] private string _attentionText = string.Empty;

        [ObservableProperty] private bool _emailAttention = false;
        [ObservableProperty] private bool _passwordAttention = false;
        [ObservableProperty] private bool _repeatPasswordAttention = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrationCommand))]
        private bool _notRegistrationProcess = true;

        public SignUpPageViewModel(
            RoutePageViewModel routePage,
            AuthenticationApi auth,
            ISecureStorageService storage)
        {
            _route = routePage;
            _auth = auth;
            _store = storage;
        }

        [RelayCommand]
        private void LoadLogInPage()
        {
            _route.LoadLogInPage();    
        }

        [RelayCommand]
        private void LoadHome()
        {
            _route.LoadHome();
        }

        [RelayCommand(CanExecute = nameof(NotRegistrationProcess))]
        private async void Registration()
        {
            NotRegistrationProcess = false;

            if (_password == string.Empty ||
                _repeatPassword == string.Empty ||
                _email == string.Empty)
            {
                EmailAttention = _email.Length == 0;
                PasswordAttention = _password.Length == 0;
                RepeatPasswordAttention = _repeatPassword.Length == 0;

                AttentionText = "Поле обязательно к заполнению";

                NotRegistrationProcess = true;
                return;
            }

            if (_password != _repeatPassword)
            {
                RepeatPasswordAttention = true;
                AttentionText = "Пароли не совпадают";

                NotRegistrationProcess = true;
                return;
            }

            var status = await _auth.Registration(_email, _password);

            if (status == HttpStatusCode.OK)
            {
                _route.LoadHome();

                NotRegistrationProcess = true;
                //await _store.Save(SKeys.USER_EMAIL_KEY, _email);
                //await _store.Save(SKeys.USER_PASSWORD_KEY, _password);
                return;
            }

            NotRegistrationProcess = true;

            await App.Current.MainPage.ShowPopupAsync(
                    new ErrorPopup(status.ToString()));
        }
    }
}
