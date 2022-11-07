
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class TabBarButton : ContentView
{
	public TabBarButton()
	{
        InitializeComponent();
        Application.Current.RequestedThemeChanged += OnAppThemeChange;
    }

    protected override void OnBindingContextChanged()
    {
        SetColorTheme(Application.Current.RequestedTheme);
        base.OnBindingContextChanged();
    }

    public string CurrentSource 
    {
        get => Btn.Source.ToString();
        set
        {
            Btn.Source = value;
        }
    }

    public Brush CurrentBorderBrush
    {
        get => GetBrush(Application.Current.RequestedTheme);
        set
        {
            Brdr.Stroke = value;
        }
    }

    public static readonly BindableProperty SourceProperty =
        BindableProperty.Create(nameof(Source), typeof(string), typeof(TabBarButton));


    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly BindableProperty SourceLightProperty =
        BindableProperty.Create(nameof(SourceLight), typeof(string), typeof(TabBarButton));


    public string SourceLight
    {
        get => (string)GetValue(SourceLightProperty);
        set => SetValue(SourceLightProperty, value);
    }

    public static readonly BindableProperty SourceDarkProperty =
        BindableProperty.Create(nameof(SourceDark), typeof(string), typeof(TabBarButton));

    public string SourceDark
    {
        get => (string)GetValue(SourceDarkProperty);
        set => SetValue(SourceDarkProperty, value);
    }

    public static readonly BindableProperty SourceActiveProperty =
        BindableProperty.Create(nameof(SourceActive), typeof(string), typeof(TabBarButton));

    public string SourceActive
    {
        get => (string)GetValue(SourceActiveProperty);
        set => SetValue(SourceActiveProperty, value);
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

    public static readonly BindableProperty StrokeDarkBrushProperty =
        BindableProperty.Create(nameof(StrokeDarkBrush), typeof(Brush), typeof(TabBarButton));

    public Brush StrokeDarkBrush
    {
        get => (Brush)GetValue(StrokeDarkBrushProperty);
        set
        {
            SetValue(StrokeDarkBrushProperty, value);
        }
    }

    public static readonly BindableProperty StrokeLightBrushProperty =
        BindableProperty.Create(nameof(StrokeLightBrush), typeof(Brush), typeof(TabBarButton));

    public Brush StrokeLightBrush
    {
        get => (Brush)GetValue(StrokeLightBrushProperty);
        set
        {
            SetValue(StrokeLightBrushProperty, value);
        }
    }

    public static readonly BindableProperty StrokeActiveBrushProperty =
        BindableProperty.Create(nameof(StrokeActiveBrush), typeof(Brush), typeof(TabBarButton));

    public Brush StrokeActiveBrush
    {
        get => (Brush)GetValue(StrokeActiveBrushProperty);
        set
        {
            SetValue(StrokeActiveBrushProperty, value);
        }
    }

    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TabBarButton), false);

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set 
        {
            SetValue(IsSelectedProperty, value);
            SetColorTheme(Application.Current.RequestedTheme);
        } 
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

    private void OnAppThemeChange(object sender, AppThemeChangedEventArgs evt)
    {
        SetColorTheme(evt.RequestedTheme);
    }

    private void SetColorTheme(AppTheme appTheme)
    {
        if (appTheme == AppTheme.Light && !IsSelected)
        { 
            //Brdr.SetValue(Border.StrokeProperty, null);
            CurrentSource = SourceLight;
            CurrentBorderBrush = StrokeLightBrush;
        }

        if (appTheme == AppTheme.Dark && !IsSelected)
        {
            //Brdr.SetValue(Border.StrokeProperty, null);
            CurrentSource = SourceDark;
            CurrentBorderBrush = StrokeDarkBrush;
        }

        if (IsSelected)
        { 
            //Brdr.SetValue(Border.StrokeProperty, null);
            CurrentSource = SourceActive;
            CurrentBorderBrush = StrokeActiveBrush;
        }
    }

    private Brush GetBrush(AppTheme appTheme)
    {
        if (appTheme == AppTheme.Light && !IsSelected)
        {
            return StrokeLightBrush;
        }

        if (appTheme == AppTheme.Dark && !IsSelected)
        {
            return StrokeDarkBrush;
        }

        if (IsSelected)
        {
            return StrokeActiveBrush;
        }
        return null;
    }
}