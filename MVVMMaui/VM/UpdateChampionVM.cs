using System;
using System.Collections.ObjectModel;
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
            ChampionsClass = new ReadOnlyObservableCollection<ClassVM>(championsClass);
            LoadChampionsClass();
            this.Selection = ChampionsClass.First();
            this.GroupName = "class";
        }

        public ReadOnlyObservableCollection<ClassVM> ChampionsClass { get; private set; }

        private ObservableCollection<ClassVM> championsClass = new ObservableCollection<ClassVM>();

        private void LoadChampionsClass()
        {
            foreach (ChampionClassVM classVM in ChampionManagerVM.ChampionsClass)
            {
                if (classVM != ChampionClassVM.Unknown)
                {
                    championsClass.Add(new ClassVM(classVM));
                }
            }

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

        private ClassVM selection;


        public ClassVM Selection
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

