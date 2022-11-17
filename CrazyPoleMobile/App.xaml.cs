
using CrazyPoleMobile.MVVM.ViewModels;
using CrazyPoleMobile.MVVM.Views;
using CrazyPoleMobile.Services;

namespace CrazyPoleMobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}

}