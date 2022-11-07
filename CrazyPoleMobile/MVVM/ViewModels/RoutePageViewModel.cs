using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.MVVM.Views.CustomControls;
using CrazyPoleMobile.Services;
using Microsoft.Maui.Layouts;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public partial class RoutePageViewModel : ObservableObject, IRouteController
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

        public void InitRoot(
            Layout content, 
            View tabBar,
            TabBarButton homeButton,
            TabBarButton notificationButton,
            TabBarButton calendarButton,
            TabBarButton settingsButton)
        {
            _tabBar = tabBar;
            _content = content;
            _homeButton = homeButton;
            _notificationButton = notificationButton;
            _calendarButton = calendarButton;
            _settingsButton = settingsButton;
            _router.InitRootPage(this);
            _contentContext = this;
            LoadLogInPage();
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
    }
}
