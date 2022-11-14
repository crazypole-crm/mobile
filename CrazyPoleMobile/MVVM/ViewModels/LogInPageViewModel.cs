using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.Services.Api;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class LogInPageViewModel : ObservableObject
    {
        RoutePageViewModel _route;
        AuthenticationApi _auth;

        [ObservableProperty] private string _email;
        [ObservableProperty] private string _password;
        [ObservableProperty] private string _message;
        [ObservableProperty] private bool _messageVisible = false;

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

        private void ShowMessage(string message)
        {
            Message = message;
            MessageVisible = true;
        }

        [RelayCommand]
        private async void LogIn()
        {
            if (_password == "" || _email == "")
            {
                ShowMessage("Все поля должны быть заполнены");
                return;
            }

            await _auth.LogIn(_email, _password);
            await _route.LoadHome();
        }
    }
}
