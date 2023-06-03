using System.Collections.ObjectModel;
using ViewModel;

namespace MVVMMaui.Views;

public partial class CaracteristiquesView : ContentView
{

    public CaracteristiquesView(/*ChampionVM championVM*/)
	{
		InitializeComponent();
         var a = BindingContext;
        BindingContext = this;
        //BindingContext = championVM.Characteristics;
    }
}
 