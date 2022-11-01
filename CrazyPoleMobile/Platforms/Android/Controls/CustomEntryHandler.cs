using Android.Widget;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    /// 
    /// Это реализация для андроида. 
    /// 
    public partial class CustomEntryHandler : ViewHandler<ICustomEntry, EditText> 
    {
        // Обязательный метод который просто должен возвращать нативный элемент платформы
        protected override EditText CreatePlatformView()
        {
            return new EditText(Context);
        }

        // Грубо говоря конструктор. Тут происходит подписка на события и всякое такое
        protected override void ConnectHandler(EditText platformView)
        {
            platformView.UpdateTextColor(VirtualView.TextColor);
            platformView.SetText(VirtualView.Text.ToCharArray(), 0, VirtualView.Text.Length);

            base.ConnectHandler(platformView);
        }

        // Методы маппера. Методы отвечают за валидацию и преобразования типов из MAUI в платформенные типы.
        private static void MapText(CustomEntryHandler handler, ICustomEntry view)
        {
            handler?.PlatformView.SetText(view.Text.ToCharArray(), 0, view.Text.Length);
        }

        private static void MapTextColor(CustomEntryHandler handler, ICustomEntry view)
        {
            handler?.PlatformView.SetTextColor(view.TextColor.ToPlatform());;
        }
    }
}
