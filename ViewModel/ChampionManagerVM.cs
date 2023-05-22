using System;
using Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;

namespace ViewModel
{
	public class ChampionManagerVM
	{
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /*public ChampionVM champions
        {
            get => model;
            set
            {
                if (model.Equals(value)) return;
                model = value;
                OnPropertyChanged();
            }
        }*/
        private ObservableCollection<ChampionVM> champions = new ObservableCollection<ChampionVM>();

        private IDataManager DataManager { get; set; }

        public ChampionManagerVM(IDataManager dataManager)
		{
            DataManager = dataManager;
            //mette la readonly new () pour champions
           // PropertyChanged += ChampionManagerVM_PropertyChanged;
		}

        public int Index
       {
           get => index;
           set
           {
               if (index == value) return;
               index = value;
               OnPropertyChanged();
           }
       }
        private int index;


        public async Task loadChampions(int index, int count)
        {
            foreach (var champion in await DataManager.ChampionsMgr.GetItems(index, count))
            {//trie
                champions.Add(new ChampionVM(champion));
            }

        }
	}
}

