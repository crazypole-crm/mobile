﻿
namespace CrazyPoleMobile.Behaviors
{
    public class ButtonAnimationBehavior : Behavior<Button>
    {
        private Task _pressedAnimation;
        private Task _releasedAnimation;
        const double DELTA_SCALE = 0.05d;
        const uint DURATION = 150;
        double _pressedScale;
        double _releasedScale;



        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Pressed += OnPressed;
            bindable.Released += OnReleased;
            bindable.Unfocused += OnReleased;
            _pressedScale = bindable.Scale - DELTA_SCALE;
            _releasedScale = bindable.Scale;
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        private async void OnPressed(object sender, EventArgs args)
        {
            if (_pressedAnimation != null) return;
            VisualElement obj = sender as VisualElement;
            if (obj != null)
            {
                if (_releasedAnimation != null)
                    await _releasedAnimation.WaitAsync(CancellationToken.None);
                _pressedAnimation = obj.ScaleTo(_pressedScale, DURATION, Easing.CubicInOut);
                await _pressedAnimation;
                _pressedAnimation = null;
            }
        }

        

        private async void OnReleased(object sender, EventArgs args)
        {
            if (_releasedAnimation != null) return;
            VisualElement obj = sender as VisualElement;
            if (obj != null)
            {
                if (_pressedAnimation != null )
                    await _pressedAnimation.WaitAsync(CancellationToken.None);
                _releasedAnimation = obj.ScaleTo(_releasedScale, DURATION, Easing.CubicInOut);
                await _releasedAnimation;
                _releasedAnimation = null;
            }
        }
    }
}
