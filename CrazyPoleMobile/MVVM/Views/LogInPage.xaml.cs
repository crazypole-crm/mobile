
using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.MVVM.Views;

public partial class LogInPage : ContentPage
{
	private EventHandler loadHome = async (object sender, EventArgs e) => 
	{
        await Shell.Current.GoToAsync("//Home", true);
    };

    public LogInPage(LogInPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}

	private async void LoadSignUpPage(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//SignUpPage", true);
    }
}

