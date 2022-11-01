using Android.Widget;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    public partial class CustomEntryHandler : ViewHandler<ICustomEntry, EditText> 
    {
        protected override EditText CreatePlatformView()
        {
            return new EditText(Context);
        }

        protected override void ConnectHandler(EditText platformView)
        {
            platformView.UpdateTextColor(VirtualView.TextColor);
            platformView.SetText(VirtualView.Text.ToCharArray(), 0, VirtualView.Text.Length);

            base.ConnectHandler(platformView);
        }

        private static void MapText(CustomEntryHandler handler, ICustomEntry view)
        {
            handler?.PlatformView.SetText(view.Text.ToCharArray(), 0, view.Text.Length);
        }

        private static void MapTextColor(CustomEntryHandler handler, ICustomEntry view)
        {
            handler?.PlatformView.SetTextColor(view.TextColor.ToPlatform());;
        }
    }
}
