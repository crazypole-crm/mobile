using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views.Popups;
using CrazyPoleMobile.Services.Api;
using System.Net;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class SignUpPageViewModel : ObservableObject
    {
        private RoutePageViewModel _route;
        private AuthenticationApi _auth;

        [ObservableProperty] private string _email = string.Empty;
        [ObservableProperty] private string _password = string.Empty;
        [ObservableProperty] private string _repeatPassword = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrationCommand))]
        private bool _notRegistrationProcess = true;

        public SignUpPageViewModel(
            RoutePageViewModel routePage,
            AuthenticationApi auth)
        {
            _route = routePage;
            _auth = auth;
        }

        [RelayCommand]
        private async void LoadLogInPage()
        {
            await _route.LoadLogInPage();    
        }

        [RelayCommand]
        private async void LoadHome()
        {
            await _route.LoadHome();
        }

        [RelayCommand(CanExecute = nameof(NotRegistrationProcess))]
        private async void Registration()
        {
            NotRegistrationProcess = false;

            if (_password == string.Empty ||
                _repeatPassword == string.Empty ||
                _email == string.Empty)
            {
                await App.Current.MainPage.ShowPopupAsync(
                    new WarningPopup("Все поля должны быть заполнены"));
                NotRegistrationProcess = true;
                return;
            }

            if (_password != _repeatPassword)
            {
                await App.Current.MainPage.ShowPopupAsync(
                    new WarningPopup("Пароли не совпадают"));
                NotRegistrationProcess = true;
                return;
            }

            var status = await _auth.Registration(_email, _password);

            if (status == HttpStatusCode.OK)
            {
                await _route.LoadHome();
                NotRegistrationProcess = true;
                return;
            }

            NotRegistrationProcess = true;

            await App.Current.MainPage.ShowPopupAsync(
                    new ErrorPopup(status.ToString()));
        }
    }
}
