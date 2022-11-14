

using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.Services
{
    public class PageNavigationService : IPageNavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private IRouteController _routController;
        private IPopupController _popupController;

        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public PageNavigationService(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public T GetPage<T>() where T : Page
            => _serviceProvider.GetService<T>();

        public T GetViewModel<T>() where T : ObservableObject
            => _serviceProvider.GetService<T>();

        public async Task GoBack()
        {
            if (Navigation.NavigationStack.Count <= 1)
                return;

            var page = await PopPage() as ContentPage;
            _routController.GetContentBlock.Children.Clear();
            _routController.GetContentBlock.Children.Add(page.Content);
        }

        public void InitRootPage(IRouteController router, IPopupController popup)
        {
            _routController = router;
            _popupController = popup;
        }

        public async Task LoadPage<View, ViewModel>(bool pushStak = true) where View : Page where ViewModel : ObservableObject
        {
            ContentPage page = GetPage<View>() as ContentPage;

            if (page is null) throw new Exception("Page not found");

            var content = page.Content;
            content.BindingContext = GetViewModel<ViewModel>();

            _routController.GetContentBlock.Children.Clear();
            _routController.GetContentBlock.Children.Add(page.Content);
            if (pushStak)
                await PushPage(page);

        }

        public async Task<Page> PopPage() => await Navigation.PopAsync();

        public async Task PushPage<T>(T page) where T : Page => await Navigation.PushModalAsync(page);

        public Task ShowPopup<View, ViewModel>()
            where View : Page
            where ViewModel : ObservableObject
        {
            throw new NotImplementedException();   
        }
    }
}
