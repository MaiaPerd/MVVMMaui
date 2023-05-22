using ViewModel;

namespace MVVMMaui;

public partial class MainPage : ContentPage
{
    readonly ChampionManagerVM championManagerVM = (Application.Current as App).championVM;

    public MainPage()
	{
		InitializeComponent();
        BindingContext = championManagerVM.Champions;
    }


}

//REucérer le champions manager vm et bindingcontext de la list
