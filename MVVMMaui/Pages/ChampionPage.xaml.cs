using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class ChampionPage : ContentPage
{
    readonly ChampionManagerVM championManagerVM = (Application.Current as App).championVM;

    public ChampionPage(ChampionVM championVM)
	{
		InitializeComponent();
        BindingContext = new PageChampionVM(championManagerVM);
    }

}
