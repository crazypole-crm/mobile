using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.MVVM.Views;

public partial class CalendarPage : ContentPage
{
	public CalendarPage(CalendarPageViewModel viewmodel)
	{
		BindingContext = viewmodel;
		InitializeComponent();
	}
}