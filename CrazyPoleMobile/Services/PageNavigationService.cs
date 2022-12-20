using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.Services
{
    public class PageNavigationService : IPageNavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private IRouteController _routController;

        private Dictionary<Type, Page> _pageCache = new();
        private Dictionary<Type, ObservableObject> _viewModelCache = new();

        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public PageNavigationService(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public T GetPage<T>() where T : Page
        {
            if (_pageCache.ContainsKey(typeof(T)))
            {
                return (T)_pageCache[typeof(T)];
            }

            var page = _serviceProvider.GetService<T>();
            _pageCache.Add(typeof(T), page);
            return page;
        }

        public T GetViewModel<T>() where T : ObservableObject
        {
            if (_viewModelCache.ContainsKey(typeof(T)))
            {
                return (T)_viewModelCache[typeof(T)];
            }

            var vm = _serviceProvider.GetService<T>();
            _viewModelCache.Add(typeof(T), vm);
            return vm;
        }

        public async Task GoBack()
        {
            if (Navigation.NavigationStack.Count <= 1)
                return;

            var page = await PopPage() as ContentPage;
        }

        public void InitRootPage(IRouteController router)
        {
            _routController = router;
        }

        public async Task<ViewModel> LoadPage<View, ViewModel>(bool pushStak = false) where View : Page where ViewModel : ObservableObject
        {
            ContentPage page = GetPage<View>() as ContentPage;

            if (page is null) throw new Exception("Page not found");

            var content = page.Content;
            content.BindingContext = GetViewModel<ViewModel>();

            if (pushStak)
                await PushPage(page);
            else
            {
                //await .(() => 
                //{
                    _routController.GetContentBlock.Children.Clear();
                //}, CancellationToken.None, );
                _routController.GetContentBlock.Children.Add(page.Content);
            }
            return (ViewModel)content.BindingContext;
        }

        public async Task<Page> PopPage() => await Navigation.PopAsync();

        public async Task PushPage<T>(T page) where T : Page => await Navigation.PushAsync(page);
    }
}
