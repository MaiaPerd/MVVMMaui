using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using ViewModel;

namespace MVVMMaui.VM
{
	public class AddSkinVM : ObservableObject
    {

        SkinVM skinEditCopie;

        public SkinVM SkinEditCopie
        {
            set { SetProperty(ref skinEditCopie, value); }
            get { return skinEditCopie; }
        }

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


        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        private string name;

        public string Titre
        {
            get => titre;
        }
        private string titre;

        public string Status
        {
            get => status;
        }
        private string status;

        public bool Edit
        {
            get => edit;
        }
        private bool edit;
    }
}

