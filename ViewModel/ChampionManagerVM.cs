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

        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
   
        private ObservableCollection<ChampionVM> champions = new ObservableCollection<ChampionVM>();

        private IDataManager DataManager { get; set; }

        public ChampionManagerVM(IDataManager dataManager)
		{
            DataManager = dataManager;
            loadChampions(index, count);
            index = 1;
            count = 5;
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
            //mette la readonly new () pour champions
           // PropertyChanged += ChampionManagerVM_PropertyChanged;
		}

        public ChampionManagerVM( )
        {
            loadChampions(index, count);
            index = 1;
            count = 5;
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
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

        public int Count
        {
            get => count;
            set
            {
                if (count == value) return;
                count = value;
                OnPropertyChanged();
            }
        }
        private int count;


        public async Task loadChampions(int index, int count)
        {
            foreach (var champion in await DataManager.ChampionsMgr.GetItems(index, count))
            {//trie
                champions.Add(new ChampionVM(champion));
            }

        }
	}
}

