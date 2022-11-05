using CrazyPoleMobile.MVVM.ViewModels;
using CrazyPoleMobile.MVVM.Views.CustomControls;
using System.Collections;

namespace CrazyPoleMobile.MVVM.Views;

public partial class RoutePage : ContentPage
{
	private bool _isLayoutSizeInit = false;

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

            BarLayout.SetLayoutBounds(ContentBlock, new Rect(0, 0, 1, height));
            BarLayout.SetLayoutBounds(TabBarBlock, new Rect(0, contentSize, 1, tabBarSize));
            _isLayoutSizeInit = true;
		}

		base.OnSizeAllocated(width, height);
	}
}