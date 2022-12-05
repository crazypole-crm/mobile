using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace CrazyPoleMobile.MVVM.Views.Components;

public partial class CalendarDayFrame : ContentView
{
    public CalendarDayFrame()
	{
		InitializeComponent();
	}
    public static readonly BindableProperty SelectorProperty =
            BindableProperty.Create(nameof(Selector), typeof(CalendarDay), typeof(CalendarDayFrame), null, propertyChanged: OnPropertyChanged);
    public CalendarDay Selector
    {
        get => (CalendarDay)GetValue(SelectorProperty);
        set => SetValue(SelectorProperty, value);
    }

    public static readonly BindableProperty SelectionMoveDownXProperty =
            BindableProperty.Create(nameof(SelectionMoveDownX), typeof(int), typeof(CalendarDayFrame));

    public int SelectionMoveDownX
    {
        get => (int)GetValue(SelectionMoveDownXProperty);
        set => SetValue(SelectionMoveDownXProperty, value);
    }

    public static readonly BindableProperty SelectionMoveDownTimeProperty =
            BindableProperty.Create(nameof(SelectionMoveTime), typeof(uint), typeof(CalendarDayFrame));

    public uint SelectionMoveTime
    {
        get => (uint)GetValue(SelectionMoveDownTimeProperty);
        set => SetValue(SelectionMoveDownTimeProperty, value);
    }

    public static readonly BindableProperty DayProperty =
        BindableProperty.Create(nameof(Day), typeof(string), typeof(CalendarDayFrame));

    public string Day
    {
        get => (string)GetValue(DayProperty);
        set => SetValue(DayProperty, value);
    }

    public static readonly BindableProperty DayOfWeekProperty =
       BindableProperty.Create(nameof(DayOfWeek), typeof(string), typeof(CalendarDayFrame));

    public string DayOfWeek
    {
        get => (string)GetValue(DayOfWeekProperty);
        set => SetValue(DayOfWeekProperty, value);
    }

    public static readonly BindableProperty IsCircleVisibleProperty =
   BindableProperty.Create(nameof(IsCircleVisible), typeof(bool), typeof(CalendarDayFrame));

    public bool IsCircleVisible
    {
        get => (bool)GetValue(IsCircleVisibleProperty);
        set => SetValue(IsCircleVisibleProperty, value);
    }

    private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var frame = bindable as VisualElement;
        
        var day = frame.BindingContext as CalendarDay;
        if (frame == null || day == null)
            return;

        if (day.Equals(oldValue as CalendarDay))
        {
            var selectionMoveDownSpeed = (uint)frame.GetValue(SelectionMoveDownTimeProperty);
            frame.TranslateTo(0, 0, selectionMoveDownSpeed, Easing.CubicInOut);
        }

        if (day.Equals(newValue as CalendarDay))
        {
            var selectionMoveDown = (int)frame.GetValue(SelectionMoveDownXProperty);
            var selectionMoveDownSpeed = (uint)frame.GetValue(SelectionMoveDownTimeProperty);
            frame.TranslateTo(0, selectionMoveDown, selectionMoveDownSpeed, Easing.CubicInOut);
        }
    }


}