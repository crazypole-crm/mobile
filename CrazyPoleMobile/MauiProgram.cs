using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Mvvm;
using CrazyPoleMobile.Handlers;
using CrazyPoleMobile.MVVM.Views.CustomControls;

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
			})
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Semibold.ttf", "MontserratSemibold");

            });

		return builder.Build();
	}
}
