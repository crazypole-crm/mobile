

namespace CrazyPoleMobile.Services
{
    public class PageNavigationService : IPageNavigationService
    {
        private readonly Stack<Page> _stack = new Stack<Page>();
        private readonly IServiceProvider _serviceProvider;

        public PageNavigationService(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public T GetPage<T>() where T : Page
            => _serviceProvider.GetService<T>();

        public void GoBack(Layout contentContainer)
        {
            if (_stack.Count <= 1)
                return;

            var page = PopPage() as ContentPage;
            contentContainer.Children.Clear();
            contentContainer.Children.Add(page.Content);
        }

        public void InitRootPage(Page page)
        {
            PushPage(page);
        }

        public void LoadPage<T>(Layout contentContainer) where T : Page
        {
            ContentPage page = GetPage<T>() as ContentPage;

            if (page is null) throw new Exception("Page not found");

            contentContainer.Children.Clear();
            contentContainer.Children.Add(page.Content);
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
