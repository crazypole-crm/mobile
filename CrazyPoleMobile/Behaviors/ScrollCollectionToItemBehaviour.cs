using CrazyPoleMobile.MVVM.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Behaviors
{

    public class ScrollCollectionToItemBehaviour : Behavior<ItemsView>
    {
        public static BindableProperty ScrollToItemProperty =
            BindableProperty.Create(nameof(ScrollToItem),
                                    typeof(object),
                                    typeof(ScrollCollectionToItemBehaviour),
                                    null,
                                    BindingMode.Default,
                                    propertyChanged: OnScrollToItemPropertyChanged);
        public object ScrollToItem
        {
            get => GetValue(ScrollToItemProperty);
            set => SetValue(ScrollToItemProperty, value);
        }


        public static BindableProperty AssociationProperty =
            BindableProperty.Create(nameof(Association),
                                    typeof(ItemsView),
                                    typeof(ScrollCollectionToItemBehaviour),
                                    null);
        public ItemsView Association
        {
            get => (ItemsView)GetValue(AssociationProperty);
            set => SetValue(AssociationProperty, value);
        }


        private ItemsView _associatedObject;

        protected override void OnAttachedTo(ItemsView bindable)
        {
            base.OnAttachedTo(bindable);
            _associatedObject = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;

        }

        protected override void OnDetachingFrom(ItemsView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            _associatedObject = null;
        }
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();
            BindingContext = _associatedObject.BindingContext;
        }

        private static void OnScrollToItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null) return;

            if (bindable == null) return;

            var collection = (ItemsView)bindable.GetValue(AssociationProperty);
            if (collection == null) return;
            

            collection.ScrollTo(newValue as CalendarDay, null, ScrollToPosition.Center, true);
        }
    }
}
