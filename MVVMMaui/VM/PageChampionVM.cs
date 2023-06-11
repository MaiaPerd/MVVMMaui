using System;
using System.Windows.Input;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public class PageChampionVM
	{
        public ChampionManagerVM ChampionManagerVM
        {
            get => championManagerVM;
        }
        private ChampionManagerVM championManagerVM;

        public PageChampionVM(ChampionManagerVM championManagerVM)
        {
            this.championManagerVM = championManagerVM;
            NavigationUpdateChampionPageCommand = new Command(
             execute: () =>
             {
                 Shell.Current.Navigation.PushAsync(new ChampionAddPage(championManagerVM.ChampionEdit));
             }
             );
        }

        public ICommand NavigationUpdateChampionPageCommand { get; private set; }

    }
}

