using Microsoft.Maui.Handlers;
using UIKit;

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    public partial class CustomEntryHandler : ViewHandler<ICustomEntry, UIInputView>
    {
        protected override UIInputView CreatePlatformView()
        {
            throw new NotImplementedException();
        }

        protected override void ConnectHandler(UIInputView platformView)
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
