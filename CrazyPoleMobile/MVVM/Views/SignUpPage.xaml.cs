
using CrazyPoleMobile.MVVM.ViewModels;

namespace CrazyPoleMobile.MVVM.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
    }
}