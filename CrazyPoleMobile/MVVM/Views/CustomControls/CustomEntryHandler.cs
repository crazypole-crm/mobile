#if IOS || MACCATALYST
using PlatformView = UIKit.UITextField;
#elif ANDROID
using PlatformView = Android.Widget.EditText;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.FrameworkElement;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif
using Microsoft.Maui.Handlers;

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    public partial class CustomEntryHandler
    {
        public static PropertyMapper<CustomEntry, CustomEntryHandler> CustomEntryMapper = 
            new (ViewHandler.ViewMapper)
        {
            [nameof(ICustomEntry.Text)] = MapText,
            [nameof(ICustomEntry.TextColor)] = MapTextColor,
        };

        public CustomEntryHandler() : base(CustomEntryMapper)
        {

        }

        public CustomEntryHandler(PropertyMapper mapper) : base(mapper)
        {
            
        }

    }
}
