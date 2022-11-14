using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.Popups;

public partial class ErrorPopup : Popup
{
	public string Message { get; set; } = "";
	public ICommand CloseCommand { get; set; }

	public ErrorPopup(string message)
	{
		this.Message = message;
		CloseCommand = new Command(() => Close());
		InitializeComponent();		
	}
}