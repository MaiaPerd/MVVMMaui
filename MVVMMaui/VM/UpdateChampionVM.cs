using System;
using System.Windows.Input;
using MVVM;
using ViewModel;
//x:DataType="viewmodel:ChampionVM"
namespace MVVMMaui.VM
{
	public class UpdateChampionVM : BaseVM
    {
        ChampionVM championEditCopie;

        public ChampionVM ChampionEditCopie
        {
            set { SetProperty(ref championEditCopie, value); }
            get { return championEditCopie; }
        }

        public ChampionManagerVM ChampionManagerVM
        {
            get => championManagerVM;
        }
        private ChampionManagerVM championManagerVM;

        public UpdateChampionVM(ChampionManagerVM championManagerVM, ChampionVM champion)
        {
            this.championEditCopie = new ChampionVM(champion);
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

