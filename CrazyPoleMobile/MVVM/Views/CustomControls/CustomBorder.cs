using CrazyPoleMobile.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    public class CustomBorder : Border
    {
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(CalendarDay), typeof(CustomBorder), null, propertyChanged: OnPropertyChanged);
        public CalendarDay SelectedItem
        {
            get => (CalendarDay)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var frame = bindable as VisualElement;
            var day = frame.BindingContext as CalendarDay;
            if (frame == null || day == null)
                return;

            if (day == oldValue as CalendarDay)
                frame.TranslateTo(0, 20, 150, Easing.CubicInOut);

            if (day == newValue as CalendarDay)
                frame.TranslateTo(0, -20, 150, Easing.CubicInOut);
        }

        public static readonly BindableProperty TxtProperty =
            BindableProperty.Create(nameof(Txt), typeof(CalendarDay), typeof(CustomBorder), null, propertyChanged: OnPropertyChanged);
        public CalendarDay Txt
        {
            get => (CalendarDay)GetValue(TxtProperty);
            set => SetValue(TxtProperty, value);
        }
    }
}
