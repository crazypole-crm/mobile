using CommunityToolkit.Maui.Views;
using CrazyPoleMobile.MVVM.ViewModels;
using CrazyPoleMobile.MVVM.Views.CustomControls;
using System.Collections;

namespace CrazyPoleMobile.MVVM.Views;

public partial class RoutePage : ContentPage
{
	private bool _isLayoutSizeInit = false;

	public Grid ContentBlockRef => ContentBlock;
	public Border TabBarBlockRef => TabBarBlock;
	public TabBarButton HomeButtonRef => HomeButton;
    public TabBarButton NotificationButtonRef => NotificationButton;
    public TabBarButton CalendarButtonRef => CalendarButton;
    public TabBarButton SettingsButtonRef => SettingsButton;

    public RoutePage(RoutePageViewModel vm)
	{
        BindingContext = vm;
		InitializeComponent();
		vm.InitRoot(this);
	}

	protected override void OnSizeAllocated(double width, double height)
	{
		if (!_isLayoutSizeInit)
		{
			var contentSize = height * 0.90f;
			var tabBarSize = height - contentSize;

            BarLayout.SetLayoutBounds(ContentBlock, new Rect(0, 0, 1, 1));
            BarLayout.SetLayoutBounds(TabBarBlock, new Rect(0, contentSize + tabBarSize, 1, tabBarSize));
		}
		base.OnSizeAllocated(width, height);

	}
}