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
            AddSkillChampionPageCommand = new Command(
            execute: async () =>
            {
                string name = await Shell.Current.DisplayPromptAsync("New skill", "Nom de la compétence: ");
                if (name != null)
                {
                    championManagerVM.ChampionEdit.AddSkillCommand.Execute(name);
                }
            }
            );
            AddSkinChampionPageCommand = new Command(
            execute: () =>
            {
                Shell.Current.Navigation.PushAsync(new SkinAddPage());
            }
            ); 
        }

        public ICommand NavigationUpdateChampionPageCommand { get; private set; }
        public ICommand AddSkinChampionPageCommand { get; private set; }
        public ICommand AddSkillChampionPageCommand { get; private set; }

    }
}

