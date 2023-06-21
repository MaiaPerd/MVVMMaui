using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        }

        [RelayCommand]
        private void NavigationAddChampionPage()
        {
            Shell.Current.Navigation.PushAsync(new ChampionAddPage());
        }

        [RelayCommand]
        private async Task DeleteChampion(ChampionVM champion)
        {
            bool answer = await Shell.Current.DisplayAlert("Delete", "Voulez vous supprimer: " + champion.Name, "Oui", "Non");
            if (answer)
            {
                ChampionManagerVM.DeleteChampionCommand.Execute(champion);
            }
        }

        [RelayCommand]
        private void UpdateChampion(ChampionVM champion)
        {
            Shell.Current.Navigation.PushAsync(new ChampionAddPage(champion));
        }

        [RelayCommand]
        private void ItemTapped(ChampionVM champion)
        {
            Shell.Current.Navigation.PushAsync(new ChampionPage(champion));
        }

    }
}

