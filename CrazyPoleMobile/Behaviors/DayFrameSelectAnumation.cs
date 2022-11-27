using CrazyPoleMobile.MVVM.Views.Components;

namespace CrazyPoleMobile.Behaviors
{
    public class DayFrameSelectAnumation : Behavior<CalendarDayFrame>
    {

        private CalendarDayFrame _obj;

        public static readonly BindableProperty IsSelectProperty =
        BindableProperty.Create(nameof(IsSelect), typeof(bool), typeof(CalendarDayFrame), true);

        public bool IsSelect
        {
            get => (bool)GetValue(IsSelectProperty);
            set
            {
                SetValue(IsSelectProperty, value);
                HandleSelectionChanged(value);
            }
        }

        protected override void OnAttachedTo(CalendarDayFrame bindable)
        {
            base.OnAttachedTo(bindable);
            _obj = bindable;
        }

        private async void HandleSelectionChanged(bool value)
        {
            if (value)
                await _obj.TranslateTo(0, -5);

            if (!value)
                await _obj.TranslateTo(0, 0);
        }

    }
}
