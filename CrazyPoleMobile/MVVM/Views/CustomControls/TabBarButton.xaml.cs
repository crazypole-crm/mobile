
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class TabBarButton : ContentView
{
	public TabBarButton()
	{
        InitializeComponent();
    } 

    public static readonly BindableProperty SourceProperty =
        BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(TabBarButton));

    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly BindableProperty PaddingImageProperty =
        BindableProperty.Create(nameof(PaddingImage), typeof(double), typeof(TabBarButton));

    public double PaddingImage
    {
        get => (double)GetValue(PaddingImageProperty);
        set => SetValue(PaddingImageProperty, value);
    }

    public static readonly BindableProperty PaddingBorderProperty =
        BindableProperty.Create(nameof(PaddingBorder), typeof(double), typeof(TabBarButton));

    public double PaddingBorder
    {
        get => (double)GetValue(PaddingBorderProperty);
        set => SetValue(PaddingBorderProperty, value);
    }

    public static readonly BindableProperty ShapeProperty =
        BindableProperty.Create(nameof(Shape), typeof(IShape), typeof(TabBarButton));

    public IShape Shape
    {
        get => (IShape)GetValue(ShapeProperty);
        set => SetValue(ShapeProperty, value);
    }

    public static readonly BindableProperty StrokeThicknessProperty =
        BindableProperty.Create(nameof(StrokeThickness), typeof(double), typeof(TabBarButton));

    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    public static readonly BindableProperty ImageBgBrushProperty =
        BindableProperty.Create(nameof(ImageBgBrush), typeof(Brush), typeof(TabBarButton));

    public Brush ImageBgBrush
    {
        get => (Brush)GetValue(ImageBgBrushProperty);
        set => SetValue(ImageBgBrushProperty, value);
    }

    public static readonly BindableProperty StrokeBrushProperty =
        BindableProperty.Create(nameof(StrokeBrush), typeof(Brush), typeof(TabBarButton));

    public Brush StrokeBrush
    {
        get => (Brush)GetValue(StrokeBrushProperty);
        set => SetValue(StrokeBrushProperty, value);
    }

    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TabBarButton), false);

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TabBarButton));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(TabBarButton));

    public object CommandParameter
    {
        get => (object)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
}