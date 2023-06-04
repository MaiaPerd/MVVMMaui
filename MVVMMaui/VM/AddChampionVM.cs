using System;
using System.Windows.Input;
using MVVM;
using ViewModel;

namespace MVVMMaui.VM
{
	public class AddChampionVM : BaseVM
    {
        ChampionVM championEdit;

        public ChampionVM ChampionEdit
        {
            set { SetProperty(ref championEdit, value); }
            get { return championEdit; }
        }

        public ChampionManagerVM ChampionManagerVM
        {
            get => championManagerVM;
        }
        private ChampionManagerVM championManagerVM;

        public AddChampionVM(ChampionManagerVM championManagerVM)
		{
            this.championEdit = new ChampionVM();
            this.championManagerVM = championManagerVM;
     	}

        public string Titre
        {
            get => "Nouveau Champion";
        }

        public string Status
        {
            get => "Ajouter";
        }

        public bool Edit
        {
            get => true;
        }

    }
}

