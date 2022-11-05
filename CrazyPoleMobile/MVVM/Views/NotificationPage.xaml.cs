using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.MVVM.Views;

public partial class NotificationPage : ContentPage
{
	public NotificationPage(NotificationPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}