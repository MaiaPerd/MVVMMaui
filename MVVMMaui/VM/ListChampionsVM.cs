using System;
using System.Windows.Input;
using Model;
using MVVM;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public class ListChampionsVM : BaseVM
	{
        public ChampionVM ItemSelected
        {
            set { SetProperty(ref itemSelected, value); }
            get { return itemSelected; }

        }
        private ChampionVM itemSelected;

        public ChampionManagerVM ChampionManagerVM
        {
            get => championManagerVM;
        }
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

