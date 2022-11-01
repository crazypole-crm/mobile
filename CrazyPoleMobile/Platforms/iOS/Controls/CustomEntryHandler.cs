using Microsoft.Maui.Handlers;
using UIKit;

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    public partial class CustomEntryHandler : ViewHandler<ICustomEntry, UITextField>
    {
        protected override UITextField CreatePlatformView()
        {
            throw new NotImplementedException();
        }

        protected override void ConnectHandler(UITextField platformView)
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
