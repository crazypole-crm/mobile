﻿using CommunityToolkit.Maui;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.MVVM.ViewModels;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;
using Syncfusion.Maui.Core.Hosting;
using CrazyPoleMobile.Data.Cookies;

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
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Semibold.ttf", "MontserratSemibold");

            });

		builder.Services.AddSingleton<NotificationService>();

		// SecureStorageService
		builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();

		// Api services
		builder.Services.AddSingleton<AuthenticationApi>();

		// Provide page services
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<NotificationPage>();
		builder.Services.AddTransient<CalendarPage>();
		builder.Services.AddTransient<SettingsPage>();
		builder.Services.AddTransient<SignUpPage>();
		builder.Services.AddTransient<LogInPage>();
		builder.Services.AddTransient<RoutePage>();

		// Provide ViewModels services
		builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<NotificationPageViewModel>();
        builder.Services.AddSingleton<CalendarPageViewModel>();
        builder.Services.AddSingleton<SettingsPageViewModel>();
		builder.Services.AddSingleton<SignUpPageViewModel>();
		builder.Services.AddSingleton<LogInPageViewModel>();
		builder.Services.AddSingleton<RoutePageViewModel>();

		builder.Services.AddSingleton<IPageNavigationService, PageNavigationService>();
		builder.Services.AddSingleton<CookieDataBase>();

        return builder.Build();
	}
}
