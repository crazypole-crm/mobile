using System.Reflection;
using System.Xml;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

[ContentProperty("Source")]
public class ImageResourceExtension : IMarkupExtension<string>
{
    public string Source { set; get; }

    public string ProvideValue(IServiceProvider serviceProvider)
    {
        //if (String.IsNullOrEmpty(Source))
        //{
        //    IXmlLineInfoProvider lineInfoProvider = serviceProvider.GetService(typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider;
        //    IXmlLineInfo lineInfo = (lineInfoProvider != null) ? lineInfoProvider.XmlLineInfo : new XmlLineInfo();
        //    throw new XamlParseException("ImageResourceExtension requires Source property to be set", lineInfo);
        //}

        //string assemblyName = GetType().GetTypeInfo().Assembly.GetName().Name;
        //var _ = ImageSource.FromResource(assemblyName + "." + Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        //return ImageSource.FromResource(assemblyName + "." + Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        return Source;
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
    }
}