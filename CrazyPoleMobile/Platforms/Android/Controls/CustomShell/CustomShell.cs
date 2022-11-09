using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using AndroidX.AppCompat.View.Menu;
using AndroidX.Navigation.UI;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Navigation;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.Views.CustomControls.CustomShell
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context)
            : base(context)
        {
        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new MarginedTabBarAppearance(this, shellItem);
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<TabBar> e)
        //{
        //    base.OnElementChanged(e);

        //    if (ViewGroup != null && ViewGroup.ChildCount > 0)
        //    {
        //        BottomNavigationMenuView bottomNavigationMenuView = FindChildOfType<BottomNavigationMenuView>(ViewGroup);

        //        if (bottomNavigationMenuView != null)
        //        {
        //            // use extension method from XF
        //            bottomNavigationMenuView.SetShiftMode(false, false);
        //        }

        //    }

        //    T FindChildOfType<T>(ViewGroup viewGroup) where T : Android.Views.View
        //    {
        //        if (viewGroup == null || viewGroup.ChildCount == 0) return null;

        //        for (var i = 0; i < viewGroup.ChildCount; i++)
        //        {
        //            var child = viewGroup.GetChildAt(i);

        //            var typedChild = child as T;
        //            if (typedChild != null) return typedChild;

        //            if (!(child is ViewGroup)) continue;

        //            var result = FindChildOfType<T>(child as ViewGroup);

        //            if (result != null) return result;
        //        }

        //        return null;
        //    }
        //}
    }

    public class MarginedTabBarAppearance : ShellBottomNavViewAppearanceTracker
    {
        public MarginedTabBarAppearance(IShellContext shellContext, ShellItem shellItem)
                : base(shellContext, shellItem)
        {
        }

        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            base.SetAppearance(bottomView, appearance);

            //bottomView.SetBackground(bottomView.Context.GetDrawable(Resource.Drawable.customshell));
            ////bottomView.SetBackgroundDrawable = null;
            //bottomView.ItemRippleColor = null;
            //bottomView.SetShiftMode(false, false);
            //bottomView.Layout(1,1,1,1);
            //bottomView.SetIte
            ////for(int i = 0; i < bottomView.ChildCount; ++i)
            ////{
            ////    var item = (NavigationBarMenuView) bottomView.GetChildAt(i);
            ////    item.;
            ////}

            ////bottomView.SetPadding(400, 0, 400, 0);
            //var menuView = bottomView.GetChildAt(0) as BottomNavigationMenuView;
            ////var shiftMode = menuView.Class.GetDeclaredField("mShiftingMode");
            ////shiftMode.Accessible = true;
            ////shiftMode.SetBoolean(menuView, false);
            ////shiftMode.Accessible = false;
            ////shiftMode.Dispose();
            //for (int i = 0; i < menuView.ChildCount; i++)
            //{
            //    var item = menuView.GetChildAt(i) as BottomNavigationItemView;
            //    if (item == null)
            //        continue;
            //    //item.OnFocusChangeListener = 
            //    //item.SetIconSize(10);
            //    item.SetActiveIndicatorResizeable(false);
                
            //}

            //if (Application.Current.Resources.ContainsKey("TabBarBackgroundColor") &&
            //    Application.Current.Resources["TabBarBackgroundColor"] is Color tabColor)
            //{
            //    bottomView.SetBackgroundColor(tabColor.ToAndroid());
            //}
        }
    }
}
