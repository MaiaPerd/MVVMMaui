using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class ChampionsListPage : ContentPage
{
    readonly ChampionManagerVM championManagerVM = (Application.Current as App).championVM;

    public ChampionsListPage()
    {
        InitializeComponent();
        BindingContext = new ListChampionsVM(championManagerVM);
    }
}
