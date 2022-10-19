using CommunityToolkit.Maui;

namespace CrazyPoleMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
                //fonts.AddFont("Montserrat-Black.ttf", "MontserratBlack");
                //fonts.AddFont("Montserrat-BlackItalic.ttf", "MontserratBlackItalic");
                //fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                //fonts.AddFont("Montserrat-BoldItalic.ttf", "MontserratBoldItalic");
                //fonts.AddFont("Montserrat-ExtraBold.ttf", "MontserratExtraBold");
                //fonts.AddFont("Montserrat-ExtraBoldItalic.ttf", "MontserratExtraBoldItalic");
                //fonts.AddFont("Montserrat-ExtraLight.ttf", "MontserratExtraLight");
                //fonts.AddFont("Montserrat-Italic.ttf", "MontserratItalic");
                //fonts.AddFont("Montserrat-Italic.ttf", "MontserratItalic");
                //fonts.AddFont("Montserrat-Italic-VariableFont_wght.ttf", "MontserratItalic");
                //fonts.AddFont("Montserrat-VariableFont_wght.ttf", "Montserrat");
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Semibold.ttf", "MontserratSemibold");

            });

		return builder.Build();
	}
}
