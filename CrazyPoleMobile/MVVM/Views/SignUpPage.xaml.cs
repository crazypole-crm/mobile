namespace CrazyPoleMobile.MVVM.Views;

public partial class SignUpPage : ContentPage
{
	private EventHandler loadHome = async (object sander, EventArgs e) => 
	{
        await Shell.Current.GoToAsync("//Home", true);
    };

	public SignUpPage()
	{
		InitializeComponent();
	}

	private async void LoadLogInPage(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//LogInPage", true);
    }
}