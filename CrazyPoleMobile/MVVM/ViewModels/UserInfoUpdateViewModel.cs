using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class UserInfoUpdateViewModel : ObservableObject
    {
        private readonly IPageNavigationService _router;
        private readonly AuthenticationApi _auth;
        private readonly ISecureStorageService _store;

        [ObservableProperty] private string _firstName = string.Empty;
        [ObservableProperty] private string _middleName = string.Empty;
        [ObservableProperty] private string _lastName = string.Empty;
        [ObservableProperty] private string _phoneNumber = "+7 ";
        [ObservableProperty] private string _birthDay = DateTime.Today.ToString();
        [ObservableProperty] private string _email = string.Empty;

        [ObservableProperty] private bool _firstNameAttention = false;
        [ObservableProperty] private bool _middleNameAttention = false;
        [ObservableProperty] private bool _lastNameAttention = false;
        [ObservableProperty] private bool _phoneNumberAttention = false;
        [ObservableProperty] private bool _birthDayAttention = false;
        [ObservableProperty] private bool _emailAttention = false;
        [ObservableProperty] private string _attentionText = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(UpdateUserDataCommand))]
        private bool _notUpdateDataProcess = true;

        public UserInfoUpdateViewModel(
            IPageNavigationService router,
            AuthenticationApi auth,
            ISecureStorageService store)
        {
            _router = router;
            _auth = auth;
            _store = store;
        }

        [RelayCommand]
        public async void Back()
        {
            await _router.GoBack();
        }

        [RelayCommand(CanExecute = nameof(NotUpdateDataProcess))]
        public async void UpdateUserData()
        {

        }
    }
}
