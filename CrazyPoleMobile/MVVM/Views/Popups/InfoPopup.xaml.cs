using CommunityToolkit.Maui.Views;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.Popups;

public partial class InfoPopup : Popup
{
    public string Message { get; set; } = "";
    public ICommand CloseCommand { get; set; }

    public InfoPopup(string message)
	{
        this.Message = message;
        CloseCommand = new Command(() => Close());
        InitializeComponent();
	}
}