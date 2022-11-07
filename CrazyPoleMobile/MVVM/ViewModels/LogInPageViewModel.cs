using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class LogInPageViewModel : ObservableObject
    {
        RoutePageViewModel _route;

        public LogInPageViewModel(RoutePageViewModel route)
        {
            _route = route;
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
    }
}
