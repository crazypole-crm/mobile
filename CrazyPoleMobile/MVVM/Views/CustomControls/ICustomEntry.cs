using Microsoft.Maui.Graphics;


namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    public interface ICustomEntry : IView
    {
        public string Text { get; set; }
        public Color TextColor { get; set; }
    }
}
