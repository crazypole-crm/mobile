using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.MVVM.Views.CustomControls;
using CrazyPoleMobile.MVVM.Views.Popups;
using CrazyPoleMobile.Services;
using Microsoft.Maui.Layouts;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class RoutePageViewModel : ObservableObject, IRouteController, IPopupController
    {
        private IPageNavigationService _router;
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

        public RoutePageViewModel(IPageNavigationService router)
        {
            _router = router;

        }

        public void InitRoot(RoutePage page)
        {
            _tabBar = page.TabBarBlockRef;
            _content = page.ContentBlockRef;
            _homeButton = page.HomeButtonRef;
            _notificationButton = page.NotificationButtonRef;
            _calendarButton = page.CalendarButtonRef;
            _settingsButton = page.SettingsButtonRef;
            _router.InitRootPage(this, this);
            _contentContext = this;
            LoadLogInPage();
            //await App.Current.MainPage.ShowPopupAsync(new ErrorPopup());
        }


        private void DeactivateAllButtons()
        {
            _homeButton.IsSelected = false;
            _notificationButton.IsSelected = false;
            _calendarButton.IsSelected = false;
            _settingsButton.IsSelected = false;
        }

        [RelayCommand]
        public void LoadHome()
        {
            DeactivateAllButtons();
            _router.LoadPage<HomePage, HomePageViewModel>();
            _homeButton.IsSelected = true;
            ShowTabBar();
        }

        [RelayCommand]
        public void LoadNotification()
        {
            DeactivateAllButtons();
            _router.LoadPage<NotificationPage, NotificationPageViewModel>();
            _notificationButton.IsSelected = true;
            ShowTabBar();
        }

        [RelayCommand]
        public void LoadCalendar()
        {
            DeactivateAllButtons();
            _router.LoadPage<CalendarPage, CalendarPageViewModel>();
            _calendarButton.IsSelected = true;
            ShowTabBar();
        }

        [RelayCommand]
        public void LoadSettings()
        {
            DeactivateAllButtons();
            _router.LoadPage<SettingsPage, SettingsPageViewModel>();
            _settingsButton.IsSelected = true;
            ShowTabBar();
        }

        public void LoadSignUpPage()
        {
            DeactivateAllButtons();
            _router.LoadPage<SignUpPage, SignUpPageViewModel>();
            HideTabBar();
        }

        public void LoadLogInPage()
        {
            DeactivateAllButtons();
            _router.LoadPage<LogInPage, LogInPageViewModel>();
            HideTabBar();
        }

        [RelayCommand]
        private void HideTabBar()
        {
            _tabBar.TranslateTo(0, 0, easing: Easing.SinInOut);
            _tabBarIsVisible = false;
        }

        [RelayCommand]
        private void ShowTabBar()
        {
            _tabBar.TranslateTo(0, -_tabBar.Height, easing: Easing.SinInOut);
            _tabBarIsVisible = true;
        }

        [RelayCommand]
        private async void ShowPopup()
        {
            await App.Current.MainPage.ShowPopupAsync(new WarningPopup("Message"));
        }

        public Frame GetPopupView()
        {
            return null;
        }

        public Layout GetPopupContent()
        {
            throw new NotImplementedException();
        }

        public void InitTabButton<T>(TabBarButton btn, bool ShowTabs = false) where T : ContentPage
        {

        }
    }
}
