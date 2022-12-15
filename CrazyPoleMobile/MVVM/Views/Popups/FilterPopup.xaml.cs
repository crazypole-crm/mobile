using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.MVVM.ViewModels;
using CrazyPoleMobile.Services;
using CrazyPoleMobile.Services.Filters;
using System;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.Popups;

public partial class FilterPopup : Popup
{
    public FilterPopup(FilterPopupViewModel filterPopupViewModel)
	{
        InitializeComponent();
		BindingContext = filterPopupViewModel;
    }

}