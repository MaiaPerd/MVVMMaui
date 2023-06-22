using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class SkillAddPage : ContentPage
{
    readonly ChampionManagerVM championManagerVM = (Application.Current as App).championVM;

    public SkillAddPage()
	{
		InitializeComponent();
        BindingContext = new AddSkillVM(championManagerVM);
    }
}
