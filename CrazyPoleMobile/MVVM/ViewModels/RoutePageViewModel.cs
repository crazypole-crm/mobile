using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.MVVM.Views.CustomControls;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;
using System.Net;
using SKeys = CrazyPoleMobile.Helpers.SecureStorageKeysProviderHelper;


namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class RoutePageViewModel : ObservableObject, IRouteController
    {
        private readonly IPageNavigationService _router;
        private readonly ISecureStorageService _store;
        private readonly AuthenticationApi _auth;
        private View _tabBar;
        private Layout _content;

        private TabBarButton _homeButton;
        private TabBarButton _notificationButton;
        private TabBarButton _calendarButton;
        private TabBarButton _settingsButton;

        [ObservableProperty] private bool _tabBarIsVisible = false;
        [ObservableProperty] private object _contentContext = null;
        [ObservableProperty] private bool _contentLoaded = false;

        public Layout GetContentBlock => _content;
        public View GetTabBarView => _tabBar;

        public RoutePageViewModel(
            IPageNavigationService router,
            ISecureStorageService store,
            AuthenticationApi auth)
        {
            _router = router;
            _store = store;
            _auth = auth;
        }

        public async void InitRoot(RoutePage page)
        {
            _tabBar = page.TabBarBlockRef;
            _content = page.ContentBlockRef;
            _homeButton = page.HomeButtonRef;
            _notificationButton = page.NotificationButtonRef;
            _calendarButton = page.CalendarButtonRef;
            _settingsButton = page.SettingsButtonRef;
            _router.InitRootPage(this);
            _contentContext = this;

            await HostConfiguration.LoadClientCookies();
            var data = await _auth.CurrentUser();

            if (data.Status == HttpStatusCode.OK)
            {
                await _store.Save(SKeys.USER_EMAIL, data.Data.Email);
                await _store.Save(SKeys.USER_ID, data.Data.Id);
                await LoadHome();
                ContentLoaded = true;
                return;
            }
            await LoadLogInPage();
            ContentLoaded = true;
        }


        private void DeactivateAllButtons()
        {
            _homeButton.IsSelected = false;
            _notificationButton.IsSelected = false;
            _calendarButton.IsSelected = false;
            _settingsButton.IsSelected = false;
        }

        [RelayCommand]
        public async Task LoadHome()
        {
            DeactivateAllButtons();
            _homeButton.IsSelected = true;
            ShowTabBar();
            var vm = await _router.LoadPage<HomePage, HomePageViewModel>();
            vm.InitFavourites();
            vm.InitSignedTrainings();
           
        }

        [RelayCommand]
        public async Task LoadNotification()
        {
            DeactivateAllButtons();
            _notificationButton.IsSelected = true;
            ShowTabBar();
            await _router.LoadPage<NotificationPage, NotificationPageViewModel>();
        }

        [RelayCommand]
        public async Task LoadCalendar()
        {
            DeactivateAllButtons();
            _calendarButton.IsSelected = true;
            ShowTabBar();
            await _router.LoadPage<CalendarPage, CalendarPageViewModel>();
        }

        [RelayCommand]
        public async Task LoadSettings()
        {
            DeactivateAllButtons();
            _settingsButton.IsSelected = true;
            ShowTabBar();
            await _router.LoadPage<SettingsPage, SettingsPageViewModel>();
        }

        public async Task LoadSignUpPage()
        {
            DeactivateAllButtons();
            await HideTabBar();
            await _router.LoadPage<SignUpPage, SignUpPageViewModel>();
        }

        public async Task LoadLogInPage()
        {
            DeactivateAllButtons();
            await HideTabBar();
            await _router.LoadPage<LogInPage, LogInPageViewModel>();
        }

        public async Task LoadChangePassword()
        {
            var vm = await _router.LoadPage<ChangePasswordPage, ChangePasswordViewModel>(true);
            vm.ClearFields();
        }

        public async Task LoadUpdateInfo()
        {
            var vm = await _router.LoadPage<UserInfoUpdatePage, UserInfoUpdateViewModel>(true);
            vm.InitAsync();
        }

        [RelayCommand]
        private async Task HideTabBar()
        {
            _tabBarIsVisible = false;
            await _tabBar.TranslateTo(0, 0, easing: Easing.SinInOut);
        }

        [RelayCommand]
        private async void ShowTabBar()
        {
            _tabBarIsVisible = true;
            await _tabBar.TranslateTo(0, -_tabBar.Height, easing: Easing.SinInOut);
        }
    }
}
