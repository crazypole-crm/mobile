namespace CrazyPoleMobile.MVVM.Views;

public partial class CalendarPage : ContentPage
{
<<<<<<< Updated upstream
	public CalendarPage()
	{
=======
	public CalendarPage(CalendarPageViewModel viewmodel)
	{
		BindingContext = viewmodel;
>>>>>>> Stashed changes
		InitializeComponent();
	}
}