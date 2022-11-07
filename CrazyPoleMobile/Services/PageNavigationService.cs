

using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.Services
{
    public class PageNavigationService : IPageNavigationService
    {
        private readonly Stack<Page> _stack = new Stack<Page>();
        private readonly IServiceProvider _serviceProvider;
        private IRouteController _controller;

        public PageNavigationService(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public T GetPage<T>() where T : Page
            => _serviceProvider.GetService<T>();

        public T GetViewModel<T>() where T : ObservableObject
            => _serviceProvider.GetService<T>();

        public void GoBack()
        {
            if (_stack.Count <= 1)
                return;

            var page = PopPage() as ContentPage;
            _controller.GetContentBlock.Children.Clear();
            _controller.GetContentBlock.Children.Add(page.Content);
        }

        public void InitRootPage(IRouteController page)
        {
            _controller = page;   
        }

        public void LoadPage<View, ViewModel>() where View : Page where ViewModel : ObservableObject
        {
            ContentPage page = GetPage<View>() as ContentPage;

            if (page is null) throw new Exception("Page not found");

            var content = page.Content;
            content.BindingContext = GetViewModel<ViewModel>();

            _controller.GetContentBlock.Children.Clear();
            _controller.GetContentBlock.Children.Add(page.Content);
            PushPage(page);
        }

        public Page PopPage() => _stack.Pop();

        public Page PopToRootPage()
        {
            var rootPage = _stack.ToArray()[0];
            _stack.Clear();
            _stack.Push(rootPage);
            return rootPage;
        }

        public void PushPage<T>(T page) where T : Page => _stack.Push(page);
    }
}
