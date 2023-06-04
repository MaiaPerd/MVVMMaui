using System;
using MVVM;
using ViewModel;

namespace MVVMMaui.VM
{
	public class ListChampionsVM : BaseVM
	{

        public ChampionManagerVM ChampionManagerVM
        {
            get => championManagerVM;
        }
        private ChampionManagerVM championManagerVM;

        public ListChampionsVM(ChampionManagerVM championManagerVM)
		{
            this.championManagerVM = championManagerVM;
        }


        public string Titre
        {
            get => "Modifier le Champion";
        }

    }
}

