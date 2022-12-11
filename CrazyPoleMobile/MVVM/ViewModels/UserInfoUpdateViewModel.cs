using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.Extensions;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;
using System.Text.RegularExpressions;
using SKeys = CrazyPoleMobile.Helpers.SecureStorageKeysProviderHelper;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class UserInfoUpdateViewModel : ObservableObject
    {
        private readonly IPageNavigationService _router;
        private readonly AuthenticationApi _auth;
        private readonly ISecureStorageService _store;
        private const string PHONE_NUMBER_REGEX = "^\\+?[1-9][0-9]{7,14}$";
        private const string EMAIL_REGEX = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        [ObservableProperty] private string _firstName = string.Empty;
        [ObservableProperty] private string _middleName = string.Empty;
        [ObservableProperty] private string _lastName = string.Empty;
        [ObservableProperty] private string _phoneNumber = string.Empty;
        [ObservableProperty] private DateTime _birthDay;
        [ObservableProperty] private string _email = string.Empty;

        [ObservableProperty] private bool _loaded = false;

        [ObservableProperty] private bool _firstNameAttention = false;
        [ObservableProperty] private bool _middleNameAttention = false;
        [ObservableProperty] private bool _lastNameAttention = false;
        [ObservableProperty] private bool _phoneNumberAttention = false;
        [ObservableProperty] private bool _birthDayAttention = false;
        [ObservableProperty] private bool _emailAttention = false;
        [ObservableProperty] private string _attentionText = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(UpdateDataCommand))]
        private bool _notUpdateDataProcess = true;

        private DateTime MinDate { get; } = new DateTime(1970, 1, 1); 

        public UserInfoUpdateViewModel(
            IPageNavigationService router,
            AuthenticationApi auth,
            ISecureStorageService store)
        {
            _router = router;
            _auth = auth;
            _store = store;
            InitAsync();
        }

        private async void InitAsync()
        {
            var data = await _auth.CurrentUser();

            if (data.Status == System.Net.HttpStatusCode.OK)
            {
                await Task.Run(() =>
                {
                    if (data.Data is null)
                        return;
                    Email = data.Data.Email;
                    PhoneNumber = data.Data.Phone ?? string.Empty;
                    FirstName = data.Data.FirstName ?? string.Empty;
                    MiddleName = data.Data.MiddleName ?? string.Empty;
                    LastName = data.Data.LastName ?? string.Empty;
                    if (long.TryParse(data.Data.birthday, out long ms))
                    {
                        BirthDay = MinDate + TimeSpan.FromMilliseconds(ms);
                    }
                    else
                    {
                        BirthDay = DateTime.Today;
                    }
                });
            }
            Loaded = true;
        }

        [RelayCommand]
        private async void Back()
        {
            await _router.GoBack();
        }

        [RelayCommand(CanExecute = nameof(NotUpdateDataProcess))]
        public async void UpdateData()
        {
            NotUpdateDataProcess = false;
            UpdateUserData data = new();

            FirstName = FirstName.Trim();
            if (FirstName != string.Empty)
                data.FirstName = FirstName;

            MiddleName = MiddleName.Trim();
            if (MiddleName != string.Empty)
                data.MiddleName = MiddleName;

            LastName = LastName.Trim();
            if (LastName != string.Empty)
                data.LastName = LastName;

            PhoneNumber = PhoneNumber.Trim();
            if (PhoneNumber != string.Empty)
            {
                if (Regex.IsMatch(PhoneNumber, PHONE_NUMBER_REGEX))
                {
                    data.PhoneNumber = PhoneNumber;
                }   
                else
                {
                    AttentionText = "Не верный формат";
                    PhoneNumberAttention = true;
                    NotUpdateDataProcess = true;
                    return;
                }
            }

            if (BirthDay != DateTime.Today)
            {
                data.BirthDay = (BirthDay - MinDate).TotalMilliseconds.ToString();
                await _store.Save(SKeys.USER_BIRTHDAY, data.BirthDay);
            }    

            Email = Email.Trim();
            if (!Regex.IsMatch(Email, EMAIL_REGEX))
            {
                AttentionText = "Не верный формат";
                EmailAttention = true;
                NotUpdateDataProcess = true;
                return;
            }
            data.Email = Email;

            var status = await _auth.UpdateUserData(data);
            if (status == System.Net.HttpStatusCode.OK)
            {
                NotUpdateDataProcess = true;
                return;
            }

            this.SendErrorMessage(status.ToString());
            NotUpdateDataProcess = true;
        }
    }
}
