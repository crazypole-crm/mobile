using Android.Graphics;
using PlatformView = Android.Views.View;

namespace CrazyPoleMobile.Behaviors
{
    public partial class BlurBehavior : PlatformBehavior<View, PlatformView>
    {
        PlatformView imageView;
        protected override void OnAttachedTo(View bindable, PlatformView platformView)
        {
            imageView = platformView;
            SetRendererEffect(imageView, 100);
        }

        protected override void OnDetachedFrom(View bindable, PlatformView platformView)
        {
            SetRendererEffect(imageView, 0);
        }

        void SetRendererEffect(PlatformView imageView, float radius)
        {
            var renderEffect = GetEffect(radius);
            imageView.SetRenderEffect(renderEffect);
        }

        static RenderEffect GetEffect(float radius)
        {
            return RenderEffect.CreateBlurEffect(radius, radius, Shader.TileMode.Repeat);
        }

    }
}
