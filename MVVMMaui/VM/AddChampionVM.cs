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
            this.Selection = "Mage";
            this.GroupName = "class";
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

        private object selection;


        public object Selection
        {
            get => selection;
            set
            {
                selection = value;
                OnPropertyChanged(nameof(Selection));
            }
        }

        private string groupName;
        

        public string GroupName
        {
            get => groupName;
            set
            {
                groupName = value;
                OnPropertyChanged(nameof(GroupName));
            }
        }

    }
}

