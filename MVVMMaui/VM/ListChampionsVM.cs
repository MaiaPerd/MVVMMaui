using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public partial class ListChampionsVM : ObservableObject
    {

        [ObservableProperty]
        private ChampionVM itemSelected;

        [ObservableProperty]
        private ChampionManagerVM championManagerVM;

        public ListChampionsVM(ChampionManagerVM championManagerVM)
		{
            this.championManagerVM = championManagerVM;

            NavigationAddChampionPageCommand = new Command(
               execute: () =>
               {
                   Shell.Current.Navigation.PushAsync(new ChampionAddPage());
               }
               );
            ItemTappedCommand = new Command<ChampionVM>(execute: (ChampionVM champion) =>
                {
                    Shell.Current.Navigation.PushAsync(new ChampionPage(champion));
                }
               );
            UpdateChampionCommand = new Command<ChampionVM>(execute: (ChampionVM champion) =>
                {
                    Shell.Current.Navigation.PushAsync(new ChampionAddPage(champion));
                }
               );
            DeleteChampionCommand = new Command<ChampionVM>(execute: async (ChampionVM champion) =>
            {
                bool answer = await Shell.Current.DisplayAlert("Delete", "Voulez vous supprimer: "+champion.Name, "Oui", "Non");
                if (answer) {
                    ChampionManagerVM.DeleteChampionCommand.Execute(champion);
                }
            }
               );
        }

        public ICommand UpdateChampionCommand { get; private set; }

        public ICommand ItemTappedCommand { get; private set; }

        public ICommand DeleteChampionCommand { get; private set; }

        public ICommand NavigationAddChampionPageCommand { get; private set; }
        

    }
}

