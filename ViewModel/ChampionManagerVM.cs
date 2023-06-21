using System;
using Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ViewModel
{
    public partial class ChampionManagerVM : ObservableObject
    {
        [ObservableProperty]
        private ChampionVM championEdit;

        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
   
        private ObservableCollection<ChampionVM> champions = new ObservableCollection<ChampionVM>();

        private IDataManager DataManager { get; set; }

        public ChampionManagerVM(IDataManager dataManager)
		{
            DataManager = dataManager;
            index = 1;
            count = 5;
            GetNbChampions();
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
            LoadChampions(index, count);
            ChampionsClass = new ReadOnlyObservableCollection<ChampionClassVM>(championsClass);
            LoadChampionsClass();

            PropertyChanged += ChampionManagerVM_PropertyChanged;
            NextPageCommand = new Command(execute: () =>
            {
                Index += 1;
            }, canExecute: () =>
            {
                return Index + 1 <= IndexMax;
            });

            PreviousPageCommand = new Command(execute: () =>
            {
                Index -= 1;
            }, canExecute: () =>
            {
                return Index - 1 >= 1;
            });

        }

        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }

        /*
        [RelayCommand(CanExecute = nameof(CanNextPage))]
        private void NextPage()
        {
            Index += 1;
        }
        private bool CanNextPage()
        {
            return Index + 1 <= IndexMax;
        }

        [RelayCommand(CanExecute = nameof(CanPreviousPage))]
        public void PreviousPage()
        {
            Index -= 1;
        }
        private bool CanPreviousPage()
        {
            return Index - 1 >= 1;
        }
        */
        [RelayCommand]
        private void SaveChampion(ChampionVM championVM)
        {
            var old = champions.Where((champion) => champion.Model.Equals((championVM).Model));
            if (old.Count() == 0)
            {
                DataManager.ChampionsMgr.AddItem((championVM).Model);
            }
            else
            {
                DataManager.ChampionsMgr.UpdateItem(((ChampionVM)old.First()).Model, (championVM).Model);
            }
            ChampionEdit = championVM;
            Index = IndexMax;
            LoadChampions(Index, Count);
        }

        [RelayCommand]
        private void DeleteChampion(ChampionVM championVM)
        {
            DataManager.ChampionsMgr.DeleteItem((championVM).Model);
            LoadChampions(Index, Count);
        }

        public ReadOnlyObservableCollection<ChampionClassVM> ChampionsClass { get; private set; }

        private ObservableCollection<ChampionClassVM> championsClass = new ObservableCollection<ChampionClassVM>();

        private void LoadChampionsClass()
        {
            foreach (ChampionClassVM champion in Enum.GetValues(typeof(ChampionClassVM)))
            {
                championsClass.Add(champion);
            }
            
        }


        private void ChampionManagerVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName != null)
            {
                LoadChampions(Index, Count);
                GetNbChampions();
                (NextPageCommand as Command).ChangeCanExecute();
                (PreviousPageCommand as Command).ChangeCanExecute();

            }
        }

        [ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(PreviousPageCommand))]
        private int index;

        public int IndexMax
        {
            get => indexMax + 1;
            set
            {
                if (indexMax == value) return;
                indexMax = value;
                OnPropertyChanged();
            }
        }
        private int indexMax;

        [ObservableProperty]
        private int count;

        public async Task LoadChampions(int index, int count)
        {
            champions.Clear();
            var a = await DataManager.ChampionsMgr.GetItems(index-1, count);
            foreach (var champion in a)
            {//trie
                champions.Add(new ChampionVM(champion));
            }

        }

        public async Task GetNbChampions()
        {
            
            IndexMax = await DataManager.ChampionsMgr.GetNbItems() / Count;

        }


    }
}

