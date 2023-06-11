using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using MVVM;
using ViewModel;

namespace MVVMMaui.VM
{
	public class AddChampionVM : BaseVM
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

        public AddChampionVM(ChampionManagerVM championManagerVM)
		{
            this.championEditCopie = new ChampionVM();
            championManagerVM.ChampionEdit = ChampionEditCopie;
            this.championManagerVM = championManagerVM;
            ChampionsClass = new ReadOnlyObservableCollection<ClassVM>(championsClass);
            LoadChampionsClass();
            this.Selection = ChampionsClass.First();
            name = ChampionEditCopie.Name;
            UpdateChampionCommand = new Command(execute: () =>
            {
                ChampionEditCopie.Class = Selection.ChampionClassVM;
                ChampionVM champion = new ChampionVM(Name, ChampionEditCopie);
                championManagerVM.SaveChampionCommand.Execute(champion);
                Shell.Current.Navigation.PopAsync();
            });
            ResetChampionCommand = new Command(execute: () =>
            {
                ChampionEditCopie = new ChampionVM(ChampionManagerVM.ChampionEdit);         
            });
        }

        public ReadOnlyObservableCollection<ClassVM> ChampionsClass { get; private set; }

        private ObservableCollection<ClassVM> championsClass = new ObservableCollection<ClassVM>();

        private void LoadChampionsClass()
        {
            foreach (ChampionClassVM classVM in ChampionManagerVM.ChampionsClass)
            {
                if(classVM != ChampionClassVM.Unknown)
                {
                    championsClass.Add(new ClassVM(classVM));
                }
            }

        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        private string name;


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

        public ICommand UpdateChampionCommand { get; set; }
        public ICommand ResetChampionCommand { get; set; }
    }
}

