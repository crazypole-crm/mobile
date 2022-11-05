using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    [ObservableObject]
    public partial class LogInPageViewModel
    {
        public LogInPageViewModel()
        {
        }

        [RelayCommand]
        private async void LoadSignUpPage()
        {
            await Shell.Current.GoToAsync("//SignUpPage", true);
        }

        [RelayCommand]
        private async void LoadRoutPage()
        {
            await Shell.Current.GoToAsync("//RoutPage", true);
        }
    }
}
