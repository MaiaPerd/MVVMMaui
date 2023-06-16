using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using ViewModel;

namespace MVVMMaui.VM
{
	public partial class AddSkinVM : ObservableObject
    {

        [ObservableProperty]
        private SkinVM skinEditCopie;

        public AddSkinVM(ChampionManagerVM championManagerVM, SkinVM skin)
		{
            SkinEditCopie = skin;
            championManagerVM.ChampionEdit.SkinEdit = skin;
            InitCommand(false, championManagerVM.ChampionEdit);
            this.titre = "Modifier le skin";
            this.status = "Modifier";
            this.edit = false; 
        }

        public AddSkinVM(ChampionManagerVM championManagerVM)
        {
            SkinEditCopie = new SkinVM(championManagerVM.ChampionEdit);
            championManagerVM.ChampionEdit.SkinEdit = SkinEditCopie;
            InitCommand(true, championManagerVM.ChampionEdit);
            this.titre = "Nouveau Skin";
            this.status = "Ajouter";
            this.edit = true;
        }

        private void InitCommand(bool add, ChampionVM championVM)
        {
            UpdateSkinCommand = new Command(execute: () =>
            {
                championVM.AddSkinCommand.Execute(add ? new SkinVM(Name, SkinEditCopie) : SkinEditCopie);
                Shell.Current.Navigation.PopAsync();
            });
            ResetSkinCommand = new Command(execute: () =>
            {
                SkinEditCopie = new SkinVM(championVM.SkinEdit);
            });
        }

        public ICommand UpdateSkinCommand { get; set; }
        public ICommand ResetSkinCommand { get; set; }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string titre;

        [ObservableProperty]
        private string status;

        [ObservableProperty]
        private bool edit;

    }
}

