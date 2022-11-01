#if IOS || MACCATALYST
using PlatformView = UIKit.UITextField;
#elif ANDROID
using PlatformView = Android.Widget.EditText;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.FrameworkElement;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif
using Microsoft.Maui.Handlers;

/// Насколько я понял, не обязательно использовать препроцессорные директивы для указания
/// конкретной нативной реализации той или иной вьюхи, но лучше так сделать, чтобы в случае чего не париться 
/// с указанием конкретного типа вьюхи.
/// 
/// Стоит также обратить внимание на то, что нэймспейсы всех партиций хэндлера должны быть одинаковы,
/// так-как partial будет работать только в одном нэймспейсе.
/// В целом тут нет никакой реализации, потому что реализация должна писаться для каждой платформы индивидуально
/// Если нет необходимости реализовывать хэндлер для определенной платформы, то его все равно необходимо создать,
/// но при этом реализовывать методы не обязательно и можно просто выкидывать эксепшон.
/// Далее смотри реализацию для Андроида! Далее уже сам поймешь.

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    // Объявляется кроссплатформенный хэндлер
    public partial class CustomEntryHandler
    {
        // Обязательно нужно сделать маппер для свойств, чтобы они подхватились ксамлом
        public static PropertyMapper<CustomEntry, CustomEntryHandler> CustomEntryMapper = 
            new (ViewHandler.ViewMapper)
        {
            [nameof(ICustomEntry.Text)] = MapText,
            [nameof(ICustomEntry.TextColor)] = MapTextColor,
        };

        // Обязательно должен быть пустой конструктор, который прокидывает свой маппер в базовый хэндлер
        public CustomEntryHandler() : base(CustomEntryMapper) 
        {

        }

        /// 
        /// На случай если мы будем делать на основе этого хэндлера 
        /// Новый хэндлер то нужно прокинуть маппер до базового хэндлера
        /// 
        public CustomEntryHandler(PropertyMapper mapper) : base(mapper)
        {
            
        }

    }
}
