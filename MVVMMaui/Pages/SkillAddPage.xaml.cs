using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class SkillAddPage : ContentPage
{
    public SkillAddPage(ChampionVM championEditCopie)
	{
		InitializeComponent();
        BindingContext = new AddSkillVM(championEditCopie);
    }
}
