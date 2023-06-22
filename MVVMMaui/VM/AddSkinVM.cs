using System;
using System.Globalization;
using System.Windows.Input;
using Model;
using MVVM;
using ViewModel;

namespace MVVMMaui.VM
{
	public class AddSkinVM : BaseVM
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
            name = SkinEditCopie.Name;
            this.titre = "Modifier le skin";
            this.status = "Modifier";
            this.edit = false; 
        }

        public AddSkinVM(ChampionManagerVM championManagerVM)
        {
            SkinEditCopie = new SkinVM(new ChampionVM(championManagerVM.ChampionEdit));
            championManagerVM.ChampionEdit.SkinEdit = SkinEditCopie;
            SkinEditCopie.Image = PickImage.getImage("logolol.png");
            SkinEditCopie.Icon = PickImage.getImage("logo.png");
            InitCommand(true, championManagerVM.ChampionEdit);
            name = SkinEditCopie.Name;
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
            ImageChangeCommand = new Command(execute: async () =>
            {
                string image = await PickImage.PickAndShow();
                if (image != null)
                {
                    SkinEditCopie.Image = image;
                }
            });
            IconChangeCommand = new Command(execute: async () =>
            {
                string image = await PickImage.PickAndShow();
                if (image != null)
                {
                    SkinEditCopie.Icon = image;
                }
            });
        }

        public ICommand ImageChangeCommand { get; set; }
        public ICommand IconChangeCommand { get; set; }
        public ICommand UpdateSkinCommand { get; set; }
        public ICommand ResetSkinCommand { get; set; }


        public string Name
        {
            set { SetProperty(ref name, value); }
            get { return name; }
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

