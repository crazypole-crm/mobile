using CommunityToolkit.Maui.Views;
using CrazyPoleMobile.MVVM.ViewModels;
using CrazyPoleMobile.MVVM.Views.CustomControls;
using CrazyPoleMobile.Services;
using System.Collections;

namespace CrazyPoleMobile.MVVM.Views;

public partial class RoutePage : ContentPage
{
	private double _tabBarHeight = 100;
	private double _contentHeight;
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
		this.Loaded += (s, args) => InitVm(vm);
	}

	private void InitVm(RoutePageViewModel vm)
	{
		vm.InitRoot(this);
	}

	protected override void OnSizeAllocated(double width, double height)
	{
		_contentHeight = height * (1 - (_tabBarHeight / height));

		BarLayout.SetLayoutBounds(ContentBlock, new Rect(0, 0, 1, 1));
		BarLayout.SetLayoutBounds(TabBarBlock, new Rect(0, _contentHeight + _tabBarHeight + 5, 1, _tabBarHeight));
		base.OnSizeAllocated(width, height);

	}
}