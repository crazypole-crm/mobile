using System.Collections;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.Views.CustomControls;

public partial class CustomPicker : ContentView
{
    public static readonly BindableProperty TitleProperty =
    BindableProperty.Create(nameof(Title), typeof(string), typeof(GradientButton));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(CustomPicker));

    public IList ItemsSource
    {
        get => (IList)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty ItemDisplayBindingProperty =
            BindableProperty.Create(nameof(ItemDisplayBinding), typeof(BindingBase), typeof(CustomPicker));

    public BindingBase ItemDisplayBinding
    {
        get => (BindingBase)GetValue(ItemDisplayBindingProperty);
        set => SetValue(ItemDisplayBindingProperty, value);
    }

    public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(CustomPicker));

    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    public ICommand ClearCommand { get; set; }

    public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(CustomPicker));

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public CustomPicker()
	{
		InitializeComponent();
        ClearCommand = new Command(ClearPicker);
	}

    private void ClearPicker(object pickerObj)
    {
        var picker = (Picker)pickerObj;
        if (picker == null)
            return;

        picker.SelectedIndex = -1;
    }
}