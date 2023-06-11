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
        BindingContext = new AddChampionVM(championManagerVM, championVM);

    }
}
