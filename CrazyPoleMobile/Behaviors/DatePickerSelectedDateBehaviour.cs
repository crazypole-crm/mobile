using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrazyPoleMobile.Behaviors
{
    public class DatePickerSelectedDateBehaviour : Behavior<DatePicker>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(DatePickerSelectedDateBehaviour), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        
        public static readonly BindableProperty InputConverterProperty =
            BindableProperty.Create(nameof(Converter), typeof(IValueConverter), typeof(DatePickerSelectedDateBehaviour), null);
        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(InputConverterProperty); }
            set { SetValue(InputConverterProperty, value); }
        }

        private DatePicker _associatedObject;

        protected override void OnAttachedTo(DatePicker bindable)
        {
            base.OnAttachedTo(bindable);
            _associatedObject = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.DateSelected += OnDatePickerDateSelected;
        }


        protected override void OnDetachingFrom(DatePicker bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.DateSelected -= OnDatePickerDateSelected;
            _associatedObject = null;
        }
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();
            BindingContext = _associatedObject.BindingContext;
        }

        void OnDatePickerDateSelected(object sender, DateChangedEventArgs e)
        {
            if (Command == null)
            {
                return;
            }

            object parameter = Converter.Convert(e.NewDate, typeof(object), null, null);
            if (Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }
    }
}
