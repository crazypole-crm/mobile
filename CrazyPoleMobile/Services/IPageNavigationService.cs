using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.Services
{
    public interface IPageNavigationService
    {
        public Task LoadPage<View, ViewModel>(bool pushStak = false) where View : Page where ViewModel : ObservableObject;
        public Task GoBack();
        public Task PushPage<T>(T page) where T : Page;
        public Task<Page> PopPage();
        public T GetPage<T>() where T : Page;
        public T GetViewModel<T>() where T : ObservableObject;
        public void InitRootPage(IRouteController router);
    }
}
