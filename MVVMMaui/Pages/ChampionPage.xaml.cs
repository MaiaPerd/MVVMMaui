using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class ChampionPage : ContentPage
{
    readonly ChampionManagerVM championManagerVM = (Application.Current as App).championVM;

    public ChampionPage(ChampionVM championVM)
	{
		InitializeComponent();
        championManagerVM.ChampionEdit = championVM;
        BindingContext = new PageChampionVM(championManagerVM);
    }

}
