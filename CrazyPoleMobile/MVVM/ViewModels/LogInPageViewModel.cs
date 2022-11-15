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

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LogInCommand))]
        private bool _notLoginProcess = true;

        public LogInPageViewModel(
            RoutePageViewModel route,
            AuthenticationApi auth)
        {
            _route = route;
            _auth = auth;
        }

        [RelayCommand]
        private async void LoadSignUpPage()
        {
            await _route.LoadSignUpPage();   
        }

        [RelayCommand]
        private async void LoadHomePage()
        {
            await _route.LoadHome();
        }

        [RelayCommand(CanExecute = nameof(NotLoginProcess))]
        private async void LogIn()
        {
            NotLoginProcess = false;

            if (_password == string.Empty || _email == string.Empty)
            {
                await App.Current.MainPage.ShowPopupAsync(
                    new WarningPopup("Все поля должны быть заполнены"));
                NotLoginProcess = true;
                return;
            }

            var status = await _auth.LogIn(_email, _password);

            if (status == HttpStatusCode.OK)
            { 
                await _route.LoadHome();
                NotLoginProcess = true;
                return;
            }

            NotLoginProcess = true;

            await App.Current.MainPage.ShowPopupAsync(
                    new ErrorPopup(status.ToString()));
        }
    }
}
