using System;
using System.Windows.Input;
using MVVM;
using ViewModel;

namespace MVVMMaui.VM
{
	public class UpdateChampionVM : BaseVM
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

        public UpdateChampionVM(ChampionManagerVM championManagerVM, ChampionVM champion)
        {
            this.championEdit = new ChampionVM(champion.Model);
            this.championManagerVM = championManagerVM;
        }

        public string Titre
        {
            get => "Modifier le Champion";
        }

        public string Status
        {
            get => "Modifier";
        }

        public bool Edit
        {
            get => false;
        }
    }
}

