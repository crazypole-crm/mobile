using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net;
using CrazyPoleMobile.MVVM.Views.Popups;
using CrazyPoleMobile.Services.Api;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class ChangePasswordViewModel : ObservableObject
    {
        private readonly IPageNavigationService _router;
        private readonly AuthenticationApi _auth;

        [ObservableProperty] private string _newPassword = string.Empty;
        [ObservableProperty] private string _repeatPassword = string.Empty;
        [ObservableProperty] private string _attentionText = string.Empty;

        [ObservableProperty] private bool _newPasswordAttention = false;
        [ObservableProperty] private bool _repeatPassAttention = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveNewPasswordCommand))]
        private bool _notChangePassProcess = true;

        public ChangePasswordViewModel(
            IPageNavigationService router,
            AuthenticationApi auth)
        {
            _router = router;
            _auth = auth;
        }

        [RelayCommand]
        public async void Back()
        {
            await _router.GoBack();
        }

        [RelayCommand(CanExecute = nameof(NotChangePassProcess))]
        public async void SaveNewPassword()
        {
            NotChangePassProcess = false;

            if (_repeatPassword == string.Empty || 
                _newPassword == string.Empty)
            {
                AttentionText = "Поле обязательно для заполения";
                NewPasswordAttention = _newPassword == string.Empty;
                RepeatPassAttention = _repeatPassword == string.Empty;

                NotChangePassProcess = true;
                return;
            }


            if (_repeatPassword != _newPassword)
            {
                AttentionText = "Пароли не совпадают";
                NewPasswordAttention = true;
                RepeatPassAttention = true;

                NotChangePassProcess = true;
                return;
            }

            var userData = await _auth.CurrentUser();

            if (userData.Status == HttpStatusCode.OK)
            {
                ChangePasswordData request = new()
                {
                    UserId = userData.Data.Id,
                    OldPassword = userData.Data.Password,
                    NewPassword = NewPassword
                };
                var status = await _auth.ChangePassword(request);

                if (status == HttpStatusCode.OK)
                {
                    await App.Current.MainPage.ShowPopupAsync(
                        new InfoPopup("Пароль обновлен"));
                }
                else
                {
                    await App.Current.MainPage.ShowPopupAsync(
                        new ErrorPopup(status.ToString()));
                }

                NotChangePassProcess = true;
                return;
            }


            NotChangePassProcess = true;

            await App.Current.MainPage.ShowPopupAsync(
                    new ErrorPopup(userData.Status.ToString()));
        }
    }
}
