using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml;

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    public partial class CustomEntryHandler : ViewHandler<ICustomEntry, FrameworkElement>
    {
        protected override FrameworkElement CreatePlatformView()
        {
            throw new NotImplementedException();
        }

        protected override void ConnectHandler(FrameworkElement platformView)
        {
            base.ConnectHandler(platformView);
        }

        private static void MapText(CustomEntryHandler handler, ICustomEntry view)
        {
            throw new NotImplementedException();
        }

        private static void MapTextColor(CustomEntryHandler handler, ICustomEntry view)
        {
            throw new NotImplementedException();
        }
    }
}
