using CommunityToolkit.Maui.Views;
using MVVMMaui.VM;

namespace MVVMMaui.Views;

public partial class RadioElementView : ContentView
{
    public static readonly BindableProperty ClassProperty = BindableProperty.Create("Class", typeof(ClassVM), typeof(RadioElementView), null);

    public ClassVM Class
    {
        get => (ClassVM)GetValue(ClassProperty);
        set => SetValue(ClassProperty, value);
    }

    public RadioElementView()
	{
		InitializeComponent();
        BindingContext = ClassProperty;
	}
}
