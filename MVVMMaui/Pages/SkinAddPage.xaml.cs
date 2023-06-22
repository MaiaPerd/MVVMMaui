using MVVMMaui.VM;
using ViewModel;

namespace MVVMMaui.Pages;

public partial class SkinAddPage : ContentPage
{

    readonly ChampionManagerVM championManagerVM = (Application.Current as App).championVM;

    public SkinAddPage()
    {
        InitializeComponent();
        BindingContext = new AddSkinVM(championManagerVM);
    }

    public SkinAddPage(SkinVM skinVM)
    {
        InitializeComponent();
        BindingContext = new AddSkinVM(championManagerVM, skinVM);

    }
}
