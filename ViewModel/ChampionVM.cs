using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using Model;
using MVVM;
using System.Linq;
using System.Windows.Input;
using ViewModel.converteur;

namespace ViewModel
{
	public class ChampionVM : BaseVM
    {
        // Faire une classe génerique avec ça
        public Champion Model
        {
            get => model;
            set
            {
                if (model.Equals(value)) return;
                model = value;
                OnPropertyChanged();
            }
        }
        private Champion model;

        public ChampionVM(Champion model)
		{
			this.model = model;
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(characteristics);
            LoadCaracteristique();
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            LoadSkins();
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
            LoadSkills();
            commandDef();
        }

        public ChampionVM(ChampionVM championVM)
        {
            this.model = new Champion(name: championVM.Name, champClass: championVM.Model.Class, icon: championVM.Icon, image: championVM.Image, bio: championVM.Bio);
            foreach (var characteristic in championVM.Characteristics)
            {
                Model.AddCharacteristics(Tuple.Create(characteristic.Key, characteristic.Value));
            }
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(characteristics);
            LoadCaracteristique();
            Skins = championVM.Skins;
            Skills = championVM.Skills;
            commandDef();
        }

        public ChampionVM()
        {
            this.model = new Champion(name: "Nouveau");
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(characteristics);
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
            commandDef();
        }

        public ChampionVM(string name, ChampionVM championVM)
        {
            this.model = new Champion(name: name, champClass: championVM.Model.Class, icon: championVM.Icon, image: championVM.Image, bio: championVM.Bio);
            foreach (var characteristic in championVM.Characteristics)
            {
                Model.AddCharacteristics(Tuple.Create(characteristic.Key, characteristic.Value));
            }
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(characteristics);
            LoadCaracteristique();
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            LoadSkins();
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
            LoadSkills();
            commandDef();
        }
        // Jusque la


        public void commandDef()
        {
            AddCharacteristicCommand = new Command(
             execute: (characteristic) =>
             {
                 characteristics.Add((KeyValuePair<string, int>)characteristic);
             }
           );
            AddSkinCommand = new Command(
                 execute: (name) =>
                 {
                     skins.Add(new SkinVM(new Skin(name: (string)name, champion: Model)));
                 }
                );
            AddSkillCommand = new Command(
               execute: (name) =>
               {
                   skills.Add(new SkillVM(new Skill(name: (string)name, type: SkillType.Basic)));
               }
              );
        }

        public ICommand AddCharacteristicCommand { get; set; }
        public ICommand AddSkinCommand { get; set; }
        public ICommand AddSkillCommand { get; set; }


        public string Name
		{
			get => Model.Name;
		}

		public string Bio
		{
			get => Model.Bio;
			set
			{
				if(Model == null)
				{
					return;
				}
				if(Model.Bio != value)
				{
					Model.Bio = value;
					OnPropertyChanged();
				}
			}
		}
        
        public string Icon
        {
            get => Model.Icon;
            set
            {
                if (Model == null || Model.Icon == value) return;
                Model.Icon = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(Name)); Fais changer d'autre propriéter force le binding
            }
        }


        public string Image
        {
            get => Model.Image.Base64;
            set
            {
                if (Model == null || Model.Image.Base64 == value) return;
                Model.Image.Base64 = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(Name)); Fais changer d'autre propriéter force le binding
            }
        }

        public ChampionClassVM Class
        {
            get
            {
                return EnumToEnumVM.ChampionClassToChampionClassVM(Model.Class.ToString());
            }
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (EnumToEnumVM.ChampionClassToChampionClassVM(Model.Class.ToString()) != value)
                {
                    Model.Class = EnumToEnumVM.ChampionClassVMToChampionClass(value.ToString());
                    OnPropertyChanged();
                }
            }
        }

        public ReadOnlyObservableCollection<KeyValuePair<string, int>> Characteristics { get; private set; }

        private ObservableCollection<KeyValuePair<string, int>> characteristics = new ObservableCollection<KeyValuePair<string, int>>();

        private void LoadCaracteristique()
        {
            characteristics.Clear();
            foreach (var charact in Model.Characteristics)
            {
                characteristics.Add(charact);
            }
        }

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private set; }

        private ObservableCollection<SkinVM> skins = new ObservableCollection<SkinVM>();

        private void LoadSkins()
        {
            foreach (var skin in Model.Skins)
            {
                skins.Add(new SkinVM(skin));
            }
            // A trier dans l'ordre alphabétique
        }

        public ReadOnlyObservableCollection<SkillVM> Skills { get; private set; }

        private ObservableCollection<SkillVM> skills = new ObservableCollection<SkillVM>();

        private void LoadSkills()
        {
            foreach (var skill in Model.Skills)
            {
                skills.Add(new SkillVM(skill));
            }
        }

    }
}

