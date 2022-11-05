using CommunityToolkit.Maui.Core.Views;
using CrazyPoleMobile.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace CrazyPoleMobile.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
    }
}