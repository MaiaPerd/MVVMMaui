using System;
using System.Collections.ObjectModel;
using System.Globalization;
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

        public AddChampionVM(ChampionManagerVM championManagerVM, ChampionVM champion)
        {
            this.championEditCopie = new ChampionVM(champion);
            this.championManagerVM = championManagerVM;
            ChampionsClass = new ReadOnlyObservableCollection<ClassVM>(championsClass);
            LoadChampionsClass();
            this.Selection = new ClassVM(ChampionEditCopie.Class);
            name = ChampionEditCopie.Name;
            this.titre = "Modifier le Champion";
            this.status = "Modifier";
            this.edit = false;

            InitCommand(false);
        }

        public AddChampionVM(ChampionManagerVM championManagerVM)
		{
            this.championEditCopie = new ChampionVM();
            ChampionEditCopie.Image = PickImage.getImage("logolol.png");
            ChampionEditCopie.Icon = PickImage.getImage("logo.png");
            championManagerVM.ChampionEdit = ChampionEditCopie;
            this.championManagerVM = championManagerVM;
            ChampionsClass = new ReadOnlyObservableCollection<ClassVM>(championsClass);
            LoadChampionsClass();
            this.Selection = ChampionsClass.First();
            name = ChampionEditCopie.Name;
            this.titre = "Nouveau Champion";
            this.status = "Ajouter";
            this.edit = true;

            InitCommand(true);
        }

        private void InitCommand(bool add)
        {
            UpdateChampionCommand = new Command(execute: () =>
            {
                ChampionEditCopie.Class = Selection.ChampionClassVM;
                championManagerVM.SaveChampionCommand.Execute(add? new ChampionVM(Name, ChampionEditCopie):ChampionEditCopie);
                Shell.Current.Navigation.PopAsync();
            });
            ResetChampionCommand = new Command(execute: () =>
            {
                ChampionEditCopie = new ChampionVM(ChampionManagerVM.ChampionEdit);
            });
            AddCharacteristicCommand = new Command(execute: () =>
            {
                ChampionEditCopie.AddCharacteristicCommand.Execute(new KeyValuePair<string, int>(CharacteristicsValue, CharacteristicsKey));
                CharacteristicsValue = "";
                CharacteristicsKey = 0;
            });
            ImageChangeCommand = new Command(execute: async () =>
            {
                string image = await PickImage.PickAndShow();
                if(image != null)
                {
                    ChampionEditCopie.Image = image;
                }
                
            });
            IconChangeCommand = new Command(execute: async () =>
            {
                string image = await PickImage.PickAndShow();
                if (image != null)
                {
                    ChampionEditCopie.Icon = image;
                }
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
            get => titre;
        }
        private string titre;

        public string Status
        {
            get => status;
        }
        private string status;

        public bool Edit
        {
            get => edit;
        }
        private bool edit;

        

        public ClassVM Selection
        {
            get => selection;
            set
            {
                selection = value;
                OnPropertyChanged(nameof(Selection));
            }
        }
        private ClassVM selection;

        public string CharacteristicsValue
        {
            get => characteristicsValue;
            set
            {
                characteristicsValue = value;
                OnPropertyChanged();
            }
        }
        private string characteristicsValue = "";

        public int CharacteristicsKey
        {
            get => characteristicsKey;
            set
            {
                characteristicsKey = value;
                OnPropertyChanged();
            }
        }
        private int characteristicsKey = 0;

        public ICommand UpdateChampionCommand { get; set; }
        public ICommand ResetChampionCommand { get; set; }
        public ICommand AddCharacteristicCommand { get; set; }
        public ICommand ImageChangeCommand { get; set; }
        public ICommand IconChangeCommand { get; set; }
    }
}

