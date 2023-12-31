﻿using System;
using System.Windows.Input;
using Model;
using MVVM;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public class PageChampionVM : BaseVM
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
            SkinPageNavCommand = new Command(
            execute: (skin) =>
            {
                Shell.Current.Navigation.PushAsync(new SkinPage((SkinVM)skin));
            }
            );
            DeleteSkinCommand = new Command(
            execute: async (skin) =>
            {
                bool answer = await Shell.Current.DisplayAlert("Delete", "Voulez vous supprimer: " + ((SkinVM)skin).Name, "Oui", "Non");
                if (answer)
                {
                    championManagerVM.ChampionEdit.DeleteSkinCommand.Execute((SkinVM)skin);
                }
            }
            );
        }


        public ICommand DeleteSkinCommand { get; private set; }
        public ICommand SkinPageNavCommand { get; private set; }
        public ICommand NavigationUpdateChampionPageCommand { get; private set; }
        public ICommand AddSkinChampionPageCommand { get; private set; }
        public ICommand AddSkillChampionPageCommand { get; private set; }

    }
}

