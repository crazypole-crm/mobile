using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.Services.Api;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using SKeys = CrazyPoleMobile.Helpers.SecureStorageKeysProviderHelper;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class ChangePasswordViewModel : ObservableObject
    {
        private readonly IPageNavigationService _router;
        private readonly AuthenticationApi _auth;
        private readonly ISecureStorageService _store;

        [ObservableProperty] private string _oldPassword = string.Empty;
        [ObservableProperty] private string _newPassword = string.Empty;
        [ObservableProperty] private string _repeatPassword = string.Empty;
        [ObservableProperty] private string _attentionText = string.Empty;

        [ObservableProperty] private bool _oldPasswordAttention = false;
        [ObservableProperty] private bool _newPasswordAttention = false;
        [ObservableProperty] private bool _repeatPassAttention = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveNewPasswordCommand))]
        private bool _notChangePassProcess = true;

        public ChangePasswordViewModel(
            IPageNavigationService router,
            AuthenticationApi auth,
            ISecureStorageService store)
        {
            _router = router;
            _auth = auth;
            _store = store;
        }

        public async void ClearFields()
        {
            OldPassword = string.Empty;
            NewPassword = string.Empty;
            RepeatPassword = string.Empty;

            OldPasswordAttention = false;
            NewPasswordAttention = false;
            RepeatPassAttention = false;
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
                _newPassword == string.Empty    ||
                _oldPassword == string.Empty)
            {
                AttentionText = "Поле обязательно для заполения";
                NewPasswordAttention = _newPassword == string.Empty;
                RepeatPassAttention = _repeatPassword == string.Empty;
                OldPasswordAttention = _oldPassword == string.Empty;

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

            var status = await _auth.ChangePassword(new ChangePasswordData()
            {
                OldPassword = _oldPassword,
                NewPassword = _newPassword,
                UserId = await _store.Get(SKeys.USER_ID)
            });

            if (status != System.Net.HttpStatusCode.OK)
            {
                AttentionText = "Введен неверный пароль";
                OldPasswordAttention = true;
                NotChangePassProcess = true;
                return;
            }

            NotChangePassProcess = true;
        }
    }
}
