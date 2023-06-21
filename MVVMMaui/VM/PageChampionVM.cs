using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public partial class PageChampionVM : ObservableObject
	{
        [ObservableProperty]
        private ChampionManagerVM championManagerVM;

        public PageChampionVM(ChampionManagerVM championManagerVM)
        {
            this.championManagerVM = championManagerVM;
        }

        [RelayCommand]
        private void NavigationUpdateChampionPage()
        {
            Shell.Current.Navigation.PushAsync(new ChampionAddPage(ChampionManagerVM.ChampionEdit));
        }

        [RelayCommand]
        private async Task AddSkillChampionPage()
        {
            string name = await Shell.Current.DisplayPromptAsync("New skill", "Nom de la compétence: ");
            if (name != null)
            {
                championManagerVM.ChampionEdit.AddSkillCommand.Execute(name);
            }
        }

        [RelayCommand]
        private void AddSkinChampionPage()
        {
            Shell.Current.Navigation.PushAsync(new SkinAddPage());
        }


    }
}

