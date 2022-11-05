using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.MVVM.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}