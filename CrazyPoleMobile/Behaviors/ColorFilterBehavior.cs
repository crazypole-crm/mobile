using Color = Microsoft.Maui.Graphics.Color;

namespace CrazyPoleMobile.Behaviors
{
    public partial class ColorFilterBehavior
    {

        public static readonly BindableProperty ColorFilterProperty = 
            BindableProperty.Create(nameof(ColorFilter), typeof(Color), typeof(ColorFilterBehavior), propertyChanged: OnColorChanged);

        public Color ColorFilter
        {
            get => (Color)GetValue(ColorFilterProperty);
            set => SetValue(ColorFilterProperty, value);
        }

        public static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (ColorFilterBehavior)bindable;
            if (behavior.imageView is null)
            {
                return;
            }


            behavior.SetRendererEffect(behavior.imageView);
        }
    }
}
