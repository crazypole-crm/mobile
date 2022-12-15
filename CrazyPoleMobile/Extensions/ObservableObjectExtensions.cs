using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.MVVM.Views.Popups;
using CrazyPoleMobile.MVVM.ViewModels;
using CrazyPoleMobile.Services;
using System.Windows.Input;

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

        public static async void ShowFilterPopup(this ObservableObject obj,
                                                 TrainingFilterService filterService,
                                                 List<HallData> halls,
                                                 List<DirectionData> directions,
                                                 List<UserData> trainers,
                                                 ICommand onApplyCommand)
        {
            await App.Current.MainPage.ShowPopupAsync(new FilterPopup(new FilterPopupViewModel(filterService, halls,
                                                                                               directions, trainers,
                                                                                               onApplyCommand)));
        }
    }
}
