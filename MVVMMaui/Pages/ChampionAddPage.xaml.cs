using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class ChampionAddPage : ContentPage
{
    readonly ChampionManagerVM championManagerVM = (Application.Current as App).championVM;

    public ChampionAddPage()
	{
		InitializeComponent();
        BindingContext = new AddChampionVM(championManagerVM);
    }

    public ChampionAddPage(ChampionVM championVM)
    {
        InitializeComponent();
        BindingContext = new UpdateChampionVM(championManagerVM, championVM);

    }

    public static readonly BindableProperty CharacteristicsValueProperty = BindableProperty.Create("CharacteristicsValue", typeof(string), typeof(ChampionAddPage), "");
    public static readonly BindableProperty CharacteristicsKeyProperty = BindableProperty.Create("CharacteristicsValue", typeof(int), typeof(ChampionAddPage), 0);

    public string CharacteristicsValue
    {
        get => (string)GetValue(CharacteristicsValueProperty);
        set => SetValue(CharacteristicsValueProperty, value);
    }

    public int CharacteristicsKey
    {
        get => (int)GetValue(CharacteristicsKeyProperty);
        set => SetValue(CharacteristicsKeyProperty, value);
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopAsync();
    }

    void RadioButton_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
    }

    void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        //FilePicker on récupère l'image et on la changer 
     
    }
}
