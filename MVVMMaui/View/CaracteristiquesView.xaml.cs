using ViewModel;

namespace MVVMMaui.Views;

public partial class CaracteristiquesView : ContentView
{
	public CaracteristiquesView(ChampionVM championVM)
	{
		InitializeComponent();
		//BindingContext = championVM.Characteristics;
	}
}
