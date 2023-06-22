using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Model;
using MVVM;
using MVVMMaui.Pages;
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
            DeleteCharacteristicCommand = new Command(execute: async (characteristic) =>
            {
                KeyValuePair<string, int> charac = (KeyValuePair<string, int>)characteristic;
                bool answer = await Shell.Current.DisplayAlert("Delete", "Voulez vous supprimer: " + charac.Key, "Oui", "Non");
                if (answer)
                {
                    ChampionEditCopie.DeleteCharacteristicCommand.Execute(charac);
                }
            });
            AddSkillCommand = new Command(execute: (skill) =>
            {
                Shell.Current.Navigation.PushModalAsync(new SkillAddPage());

            });
            DeleteSkillCommand = new Command(execute: async (skill) =>
            {
                SkillVM skillVM = (SkillVM) skill;
                bool answer = await Shell.Current.DisplayAlert("Delete", "Voulez vous supprimer: " + skillVM.Name, "Oui", "Non");
                if (answer)
                {
                    ChampionEditCopie.DeleteSkillCommand.Execute(skillVM);
                }
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
            set { SetProperty(ref name, value); }
            get { return name; }
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
            set { SetProperty(ref selection, value); }
            get { return selection; }
        }
        private ClassVM selection;

        public string CharacteristicsValue
        {
            set { SetProperty(ref characteristicsValue, value); }
            get { return characteristicsValue; }
        }
        private string characteristicsValue = "";

        public int CharacteristicsKey
        {
            set { SetProperty(ref characteristicsKey, value); }
            get { return characteristicsKey; }

        }
        private int characteristicsKey = 0;

        
        public ICommand UpdateChampionCommand { get; set; }
        public ICommand ResetChampionCommand { get; set; }
        public ICommand AddCharacteristicCommand { get; set; }
        public ICommand DeleteCharacteristicCommand { get; set; }
        public ICommand AddSkillCommand { get; set; }
        public ICommand DeleteSkillCommand { get; set; }
        public ICommand ImageChangeCommand { get; set; }
        public ICommand IconChangeCommand { get; set; }
    }
}

