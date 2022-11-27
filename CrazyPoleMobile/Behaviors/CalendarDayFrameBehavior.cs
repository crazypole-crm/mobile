using CommunityToolkit.Maui.Behaviors;
using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.MVVM.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Behaviors
{
    public class CalendarDayFrameBehavior : Behavior<ContentView>
    {

        public static readonly BindableProperty SelectorProperty =
        BindableProperty.Create(nameof(Selector), typeof(CalendarDay), typeof(CalendarDayFrameBehavior), null, propertyChanged: OnPropertyChanged);
        public CalendarDay Selector
        {
            get => (CalendarDay)GetValue(SelectorProperty);
            set => SetValue(SelectorProperty, value);
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var frame = bindable as VisualElement;
            var day = (frame.BindingContext as DaysCollection).Date;
            if (frame == null || day == null)
                return;

            if (day == oldValue as CalendarDay)
                frame.TranslateTo(0, -20, 150, Easing.CubicInOut);

            if (day == newValue as CalendarDay)
                frame.TranslateTo(0, 20, 150, Easing.CubicInOut);
        }

        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);
            BindingContext = bindable.BindingContext;
        }
    }
}
