using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.Services;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    [ObservableObject]
    public partial class RoutePageViewModel
    {
        private IPageNavigationService _router;

        public RoutePageViewModel(IPageNavigationService router)
        {
            _router = router;
        }

        public void InitRoot(Page page)
        {
            _router.InitRootPage(page);
        }

        [RelayCommand]
        public void LoadHome(Layout content)
        {
            _router.LoadPage<HomePage>(content);
        }

        [RelayCommand]
        public void LoadNotification(Layout content)
        {
            _router.LoadPage<NotificationPage>(content);
        }

        [RelayCommand]
        public void LoadCalendar(Layout content)
        {
            _router.LoadPage<CalendarPage>(content);
        }

        [RelayCommand]
        public void LoadSettings(Layout content)
        {
            _router.LoadPage<SettingsPage>(content);
        }
    }
    
}
