using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class ChampionsListPage : ContentPage
{
    readonly ChampionManagerVM championManagerVM = (Application.Current as App).championVM;

    public ChampionsListPage()
    {
        InitializeComponent();
        BindingContext = championManagerVM;
    }

    void ImageCell_Tapped(System.Object sender, System.EventArgs e)
    {
        var imageCell = (ImageCell)sender;
        Navigation.PushAsync(new ChampionPage((ChampionVM) imageCell.CommandParameter));
    }

    void Cell_Tapped(System.Object sender, System.EventArgs e)
    {
        var swipeView = (SwipeView)sender;
        var gesture = (TapGestureRecognizer)swipeView.GestureRecognizers[0];
        Navigation.PushAsync(new ChampionPage((ChampionVM)gesture.CommandParameter));
    }

    void TextCell_Tapped(System.Object sender, System.EventArgs e)
    {
        var textCell = (TextCell) sender;
        Navigation.PushAsync(new ChampionPage((ChampionVM) textCell.CommandParameter));
    }

    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new ChampionAddPage());
    }
}
