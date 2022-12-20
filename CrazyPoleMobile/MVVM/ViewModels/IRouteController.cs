
namespace CrazyPoleMobile.MVVM.ViewModels
{
    public interface IRouteController
    {
        public Layout GetContentBlock { get; }
        public View GetTabBarView { get; }  
    }
}
