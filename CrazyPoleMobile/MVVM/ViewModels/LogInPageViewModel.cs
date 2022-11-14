using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views.Popups;
using CrazyPoleMobile.Services.Api;
using System.Net;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class LogInPageViewModel : ObservableObject
    {
        RoutePageViewModel _route;
        AuthenticationApi _auth;

        [ObservableProperty] private string _email = string.Empty;
        [ObservableProperty] private string _password = string.Empty;

        public LogInPageViewModel(
            RoutePageViewModel route,
            AuthenticationApi auth)
        {
            _route = route;
            _auth = auth;
        }

        [RelayCommand]
        private void LoadSignUpPage()
        {
            _route.LoadSignUpPage();   
        }

        [RelayCommand]
        private void LoadHomePage()
        {
            _route.LoadHome();
        }

        [RelayCommand]
        private async void LogIn()
        {
            if (_password == string.Empty || _email == string.Empty)
            {
                await App.Current.MainPage.ShowPopupAsync(
                    new WarningPopup("Все поля должны быть заполнены"));
                return;
            }

            var status = await _auth.LogIn(_email, _password);

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
