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
            index = 1;
            count = 5;
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
            LoadChampions(index, count);
            //mette la readonly new () pour champions
            // PropertyChanged += ChampionManagerVM.PropertyChanged;
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


        public async Task LoadChampions(int index, int count)
        {
            var a = await DataManager.ChampionsMgr.GetItems(index, count);
            foreach (var champion in a)
            {//trie
                champions.Add(new ChampionVM(champion));
            }

        }
	}
}

