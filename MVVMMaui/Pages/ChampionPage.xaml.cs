using ViewModel;

namespace MVVMMaui.Pages;

public partial class ChampionPage : ContentPage
{
	public ChampionPage(ChampionVM championVM)
	{
		InitializeComponent();
        BindingContext = championVM;
    }

    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new ChampionAddPage((ChampionVM) BindingContext));
    }

}
