using System;
using Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using MVVM;

namespace ViewModel
{
	public class ChampionManagerVM : BaseVM
	{
        ChampionVM championEdit;

        public ChampionVM ChampionEdit
        {
            get => championEdit;
            set
            {
                if (championEdit == value) return;
                championEdit = value;
                OnPropertyChanged();
            }
        }

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
            SkillTypes = new ReadOnlyObservableCollection<SkillTypeVM>(skillTypes);
            LoadSkillType();

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

            SaveChampionCommand = new Command(execute: (championVM) =>
            {
                var old = champions.Where((champion) => champion.Model.Equals(((ChampionVM)championVM).Model));
                if(old.Count() == 0)
                {
                    dataManager.ChampionsMgr.AddItem(((ChampionVM)championVM).Model);
                }
                else
                {
                    dataManager.ChampionsMgr.UpdateItem(((ChampionVM)old.First()).Model, ((ChampionVM)championVM).Model);          
                }
                ChampionEdit = (ChampionVM)championVM;
                Index = IndexMax;
                LoadChampions(Index, Count);

            });

            DeleteChampionCommand = new Command(execute: (championVM) =>
            {
                dataManager.ChampionsMgr.DeleteItem(((ChampionVM)championVM).Model);
                LoadChampions(Index, Count);
            });
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

        public ReadOnlyObservableCollection<SkillTypeVM> SkillTypes { get; private set; }

        private ObservableCollection<SkillTypeVM> skillTypes = new ObservableCollection<SkillTypeVM>();

        private void LoadSkillType()
        {
            foreach (SkillTypeVM skillType in Enum.GetValues(typeof(SkillTypeVM)))
            {
                skillTypes.Add(skillType);
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


        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        
        public ICommand DeleteChampionCommand { get; set; }
        public ICommand SaveChampionCommand { get; set; }

    }
}
