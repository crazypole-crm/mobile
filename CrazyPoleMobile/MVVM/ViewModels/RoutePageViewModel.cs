using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.MVVM.Views.CustomControls;
using CrazyPoleMobile.MVVM.Views.Popups;
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

            //var password = await _store.Get(SKeys.USER_PASSWORD_KEY);
            //var email = await _store.Get(SKeys.USER_EMAIL_KEY);

            var status = await _auth.CurrentUser();

            //if (status == HttpStatusCode.OK)
            //{
                LoadHome();
            //    return;
            //}

            //LoadLogInPage();
        }


        private void DeactivateAllButtons()
        {
            _homeButton.IsSelected = false;
            _notificationButton.IsSelected = false;
            _calendarButton.IsSelected = false;
            _settingsButton.IsSelected = false;
        }

        [RelayCommand]
        public async void LoadHome()
        {
            DeactivateAllButtons();
            _homeButton.IsSelected = true;
            ShowTabBar();
            await _router.LoadPage<HomePage, HomePageViewModel>();
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
            HideTabBar();
            await _router.LoadPage<SignUpPage, SignUpPageViewModel>();
        }

        public async void LoadLogInPage()
        {
            DeactivateAllButtons();
            HideTabBar();
            await _router.LoadPage<LogInPage, LogInPageViewModel>();
        }

        [RelayCommand]
        private async void HideTabBar()
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
