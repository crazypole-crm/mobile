using System.Reflection;
using System.Xml;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

[ContentProperty("Source")]
public class ImageResourceExtension : IMarkupExtension<string>
{
    public string Source { set; get; }

    public string ProvideValue(IServiceProvider serviceProvider)
    {
        return Source;
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
    }
}