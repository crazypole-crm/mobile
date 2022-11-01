using Syncfusion.Maui.Core;
using Syncfusion.Maui.Graphics.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Handlers
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder ConfigureCrazyCore(this MauiAppBuilder builder)
        {

            builder.ConfigureMauiHandlers(delegate (IMauiHandlersCollection handlers)
            {
                Microsoft.Maui.Handlers.NavigationViewHandler.Mapper.AppendToMapping("CrazyCustom", (h, v) => 
                {
#if __ANDROID__
                    h.PlatformView.SetBackgroundColor(Android.Graphics.Color.Red);
#endif
                });
            });
            return builder;
        }
    }
}
