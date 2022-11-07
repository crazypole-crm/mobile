using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class SignUpPageViewModel : ObservableObject
    {
        RoutePageViewModel _route;

        public SignUpPageViewModel(RoutePageViewModel routePage)
        {
            _route = routePage;
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
    }
}
