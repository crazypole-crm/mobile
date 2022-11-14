
using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.MVVM.Views;

public partial class LogInPage : ContentPage
{
    public LogInPage(LogInPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}

