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
        //Class.SetBinding(CollectionView.ItemsSourceProperty, nameof(championManagerVM.ChampionsClass));
        BindingContext = new AddChampionVM(championManagerVM);
    }

    public ChampionAddPage(ChampionVM championVM)
    {
        InitializeComponent();
        // Class.SetBinding(CollectionView.ItemsSourceProperty, nameof(championManagerVM.ChampionsClass));
        //BindingContext = championManagerVM;
        BindingContext = new UpdateChampionVM(championManagerVM, championVM);

    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopAsync();
    }
}
