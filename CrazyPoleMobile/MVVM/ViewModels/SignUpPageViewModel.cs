using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.Services.Api;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class SignUpPageViewModel : ObservableObject
    {
        private RoutePageViewModel _route;
        private AuthenticationApi _auth;

        [ObservableProperty] private string _email;
        [ObservableProperty] private string _password;
        [ObservableProperty] private string _repeatPassword;
        [ObservableProperty] private string _message;
        [ObservableProperty] private bool _messageVisible = false;


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

        private void ShowMessage(string message)
        {
            Message = message;
            MessageVisible = true;
        }

        [RelayCommand]
        private async void Registration()
        {
            if (_password == "" || _repeatPassword == "" || _email == "")
            {
                ShowMessage("Все поля должны быть заполнены");
                return;
            }

            if (_password != _repeatPassword)
            {
                ShowMessage("Пароли не совпадают");
                return;
            }

            await _auth.Registration(_email, _password);               
        }
    }
}
