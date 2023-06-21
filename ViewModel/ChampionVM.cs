using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using Model;
using System.Linq;
using System.Windows.Input;
using ViewModel.converteur;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.Input;

namespace ViewModel
{
    public partial class ChampionVM : ObservableObject
    {
        [ObservableProperty]
        private Champion model;

        public ChampionVM(Champion model)
		{
            Model = model;
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(characteristics);
            LoadCaracteristique();
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            LoadSkins();
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
            LoadSkills();
        }

        public ChampionVM(ChampionVM championVM) : this(championVM.Name, championVM)
        {
        }

        public ChampionVM()
        {
            Model = new Champion(name: "Nouveau");
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(characteristics);
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
        }

        public ChampionVM(string name, ChampionVM championVM)
        {
            Model = new Champion(name: name, champClass: championVM.Model.Class, icon: championVM.Icon, image: championVM.Image, bio: championVM.Bio);
            foreach (var characteristic in championVM.Characteristics)
            {
                Model.AddCharacteristics(Tuple.Create(characteristic.Key, characteristic.Value));
            }
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(characteristics);
            LoadCaracteristique();
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            foreach (var skin in championVM.Skins)
            {
                skins.Add(skin);
            }
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
            foreach (var skill in championVM.Skills)
            {
                skills.Add(skill);
            }
        }

        [RelayCommand]
        private void AddCharacteristic(KeyValuePair<string, int> characteristic)
        {
            characteristics.Add(characteristic);
        }

        [RelayCommand]
        private void AddSkin(SkinVM skin)
        {
            skins.Add(skin);
        }

        [RelayCommand]
        private void AddSkill(String name)
        {
            skills.Add(new SkillVM(new Skill(name: name, type: SkillType.Basic)));
        }


        public string Name
		{
			get => Model?.Name;
		}

		public string Bio
		{
			get => Model?.Bio;
			set => SetProperty(Model.Bio, value, Model, (c, n) => c.Bio = n);
		}

        public string Icon
        {
            get => Model?.Icon;
            set => SetProperty(Model.Icon, value, Model, (c, n) => c.Icon = n);
        }

        public string Image
        {
            get => Model.Image.Base64;
            set => SetProperty(Model.Image.Base64, value, Model, (c, n) => c.Image.Base64 = n);
        }

        public ChampionClassVM Class
        {
            get => EnumToEnumVM.ChampionClassToChampionClassVM(Model.Class.ToString());
            set => SetProperty(EnumToEnumVM.ChampionClassToChampionClassVM(Model.Class.ToString()), value, Model, (c, n) => c.Class = EnumToEnumVM.ChampionClassVMToChampionClass(n.ToString()));
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

        SkinVM skinEdit;

        public SkinVM SkinEdit
        {
            get => skinEdit;
            set
            {
                if (skinEdit == value) return;
                skinEdit = value;
                OnPropertyChanged();
            }
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

