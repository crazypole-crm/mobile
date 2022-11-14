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


        public SignUpPageViewModel(
            RoutePageViewModel routePage,
            AuthenticationApi auth)
        {
            _route = routePage;
            _auth = auth;
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

        [RelayCommand]
        private async void Registration()
        {
            if (_password == string.Empty ||
                _repeatPassword == string.Empty ||
                _email == string.Empty)
            {
                await App.Current.MainPage.ShowPopupAsync(
                    new WarningPopup("Все поля должны быть заполнены"));
                return;
            }

            if (_password != _repeatPassword)
            {
                await App.Current.MainPage.ShowPopupAsync(
                    new WarningPopup("Пароли не совпадают"));
                return;
            }

            var status = await _auth.Registration(_email, _password);

            if (status == HttpStatusCode.OK)
            {
                _route.LoadHome();
                return;
            }    

            await App.Current.MainPage.ShowPopupAsync(
                    new ErrorPopup(status.ToString()));
        }
    }
}
