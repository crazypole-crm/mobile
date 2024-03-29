﻿using CommunityToolkit.Maui;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.MVVM.ViewModels;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Api;
using Syncfusion.Maui.Core.Hosting;
using CrazyPoleMobile.Data.Cookies;
using CrazyPoleMobile.Data.Notifications;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Data.Favourites;

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
		builder.Services.AddSingleton<CalendarApi>();

		// Provide page services
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<NotificationPage>();
		builder.Services.AddSingleton<CalendarPage>();
		builder.Services.AddSingleton<SettingsPage>();
		builder.Services.AddSingleton<SignUpPage>();
		builder.Services.AddSingleton<LogInPage>();
		builder.Services.AddSingleton<RoutePage>();
        builder.Services.AddSingleton<ChangePasswordPage>();
		builder.Services.AddSingleton<UserInfoUpdatePage>();

        // Provide ViewModels services
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<NotificationPageViewModel>();
        builder.Services.AddSingleton<CalendarPageViewModel>();
        builder.Services.AddSingleton<SettingsPageViewModel>();
		builder.Services.AddSingleton<SignUpPageViewModel>();
		builder.Services.AddSingleton<LogInPageViewModel>();
		builder.Services.AddSingleton<RoutePageViewModel>();
        builder.Services.AddTransient<ChangePasswordViewModel>();
		builder.Services.AddTransient<UserInfoUpdateViewModel>();

        builder.Services.AddSingleton<IPageNavigationService, PageNavigationService>();
		builder.Services.AddSingleton<IFilterService<TrainingData>, TrainingFilterService>();
		builder.Services.AddSingleton<CalendarService>();
		builder.Services.AddSingleton<NotificationDataBase>();
		builder.Services.AddSingleton<CookieDataBase>();
		builder.Services.AddSingleton<FavouritesDataBase>();
		builder.Services.AddSingleton<FavouritesService>();
		
		builder.Services.AddTransient<FilterPopupViewModel>();

        return builder.Build();

	}
}
