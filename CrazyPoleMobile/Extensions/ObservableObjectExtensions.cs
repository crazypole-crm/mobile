using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.Views.Popups;

namespace CrazyPoleMobile.Extensions
{
    public static class ObservableObjectExtensions
    {
        public static async void SendErrorMessage(this ObservableObject obj, string message)
        {
            await App.Current.MainPage.ShowPopupAsync(
                    new ErrorPopup(message));
        }

        public static async void SendWarningMessage(this ObservableObject obj, string message)
        {
            await App.Current.MainPage.ShowPopupAsync(
                    new WarningPopup(message));
        }

        public static async void SendInfoMessage(this ObservableObject obj, string message)
        {
            await App.Current.MainPage.ShowPopupAsync(
                    new InfoPopup(message));
        }
    }
}
