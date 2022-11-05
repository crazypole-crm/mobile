using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    [ObservableObject]
    public partial class SignUpPageViewModel
    {
        public SignUpPageViewModel()
        {
        }

        [RelayCommand]
        private async void LoadLogInPage()
        {
            await Shell.Current.GoToAsync("//LogInPage", true);
        }

        [RelayCommand]
        private async void LoadRoutPage()
        {
            await Shell.Current.GoToAsync("//RoutPage", true);
        }
    }
}
