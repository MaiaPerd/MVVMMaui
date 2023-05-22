using ViewModel;

namespace MVVMMaui;

public partial class App : Application
{
	public ChampionManagerVM championVM;

	public App(ChampionManagerVM champion)
	{
		InitializeComponent();
		championVM = champion;
		MainPage = new AppShell();
	}
}

