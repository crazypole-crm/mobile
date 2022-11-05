using Android.Widget;
using Android.Graphics;
using ImageButton = Microsoft.Maui.Controls.ImageButton;
using Google.Android.Material.ImageView;
using Color = Android.Graphics.Color;
using Microsoft.Maui.Platform;

namespace CrazyPoleMobile.Behaviors
{
    public partial class ColorFilterBehavior : PlatformBehavior<ImageButton, ShapeableImageView>
    {
        ShapeableImageView imageView;
        protected override void OnAttachedTo(ImageButton bindable, ShapeableImageView platformView)
        {
            imageView = platformView;
            SetRendererEffect(platformView);
        }

        protected override void OnDetachedFrom(ImageButton bindable, ShapeableImageView platformView)
        {
            SetRendererEffect(platformView);
        }

        void SetRendererEffect(ImageView imageView)
        {
            var renderEffect = GetEffect(ColorFilter.ToPlatform());
            imageView.SetRenderEffect(renderEffect);
        }

        static RenderEffect GetEffect(Color color)
        {
            var colorMatrix = new ColorMatrix();
            colorMatrix.SetScale(color.R, color.G, color.B, color.A);
            return RenderEffect.CreateColorFilterEffect(new ColorMatrixColorFilter(colorMatrix));

            //return RenderEffect.CreateShaderEffect(new LinearGradient(50, 0, 50, 100, Color.Red, Color.Green, Shader.TileMode.Mirror));
        }
    }
}
