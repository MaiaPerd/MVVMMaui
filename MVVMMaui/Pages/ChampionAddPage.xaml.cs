using ViewModel;

namespace MVVMMaui.Pages;

public partial class ChampionAddPage : ContentPage
{

    public ChampionAddPage()
	{
		InitializeComponent();
        Titre.Text = "Nouveau Champion";
        Status.Text = "Ajouter";
        NameEntry.IsEnabled = true;
    }

    public ChampionAddPage(ChampionVM championVM)
    {
        InitializeComponent();
        Titre.Text = "Modifier le Champion";
        Status.Text = "Modifier";
        BindingContext = championVM;
    }
}
