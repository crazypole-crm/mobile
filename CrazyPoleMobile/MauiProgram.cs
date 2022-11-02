using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Mvvm;
using CrazyPoleMobile.Handlers;
using CrazyPoleMobile.MVVM.Views.CustomControls;
using CrazyPoleMobile.MVVM.Views.CustomControls.CustomShell;

namespace CrazyPoleMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureSyncfusionCore()
			.ConfigureMauiHandlers(collection => 
			{
				collection.AddHandler(typeof(CustomEntry), typeof(CustomEntryHandler));
#if ANDROID
                collection.AddHandler(typeof(Shell), typeof(CustomShellRenderer));
#endif
			})
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Semibold.ttf", "MontserratSemibold");

            });

		return builder.Build();
	}
}
