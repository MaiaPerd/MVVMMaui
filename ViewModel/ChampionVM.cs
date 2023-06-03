using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using Model;
using MVVM;
using System.Linq;

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
            loadCaracteristique();
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            loadSkins();
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
            loadSkills();
        }
        // Jusque la

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

     /*   public ImageSource Icon
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Model.Icon)));
            }
            set
            {
                //if (Model == null || Model.Icon == value) return;
                //Model.Icon = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(Name)); Fais changer d'autre propriéter force le binding
            }
        }*/


        public string Image
        {
            get => Model.Image.Base64;
          /*  {
                return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Model.Image.Base64)));
            }*/
        

        //return Image.FromStream(new MemoryStream(Convert.FromBase64String(Model.Image.Base64)));
        // return Convert.ToBase64String(System.IO.File.ReadAllBytes(Model.Image.Base64));
    

            set
            {
                if (Model == null || Model.Image.Base64 == value) return;
                Model.Image.Base64 = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(Name)); Fais changer d'autre propriéter force le binding
            }
        }

        public ChampionClass Class//En théorie il ne faudrait pas utiliser l'enum du model
        {
            get
            {
               // if(Model.Class == ChampionClassVM.Tank)
               return Model.Class;
            }
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (Model.Class != value)
                {
                    Model.Class = value;
                    OnPropertyChanged();
                }
            }
        }

        /*
        private ObservableCollection<KeyValuePair<string, int>> characteristics;
        public ReadOnlyObservableCollection<KeyValuePair<string, int>> Characteristics
        {
            get
            {
                
                foreach(var a in Model.Characteristics)
                {

                }
                return Model.Characteristics;
            }
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (Model.Characteristics != value)
                {
                    Model.Characteristics = value;
                    OnPropertyChanged();
                }
            }
        }*/

        public ReadOnlyObservableCollection<KeyValuePair<string, int>> Characteristics { get; private set; }

        private ObservableCollection<KeyValuePair<string, int>> characteristics = new ObservableCollection<KeyValuePair<string, int>>();

        private void loadCaracteristique()
        {
            foreach (var charact in Model.Characteristics)
            {
                characteristics.Add(charact);
            }
        }

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private set; }

        private ObservableCollection<SkinVM> skins = new ObservableCollection<SkinVM>();

        private void loadSkins()
        {
            foreach (var skin in Model.Skins)
            {
                skins.Add(new SkinVM(skin));
            }
            // A trier dans l'ordre alphabétique
        }

        public ReadOnlyObservableCollection<SkillVM> Skills { get; private set; }

        private ObservableCollection<SkillVM> skills = new ObservableCollection<SkillVM>();

        private void loadSkills()
        {
            foreach (var skill in Model.Skills)
            {
                skills.Add(new SkillVM(skill));
            }
        }



        /*
        public LargeImage Image
        {
            get => Model.Image;
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (Model.Image != value)
                {
                    Model.Image = value;
                    OnPropertyChanged();
                }
            }
        }*/

        /*private ObservableCollection<SkinVM> skins;
        public ReadOnlyObservableCollection<SkinVM> Skins
        {
            get
            {
                foreach(var skin in Model.Skins)
                {

                }
               // Model.Skins;
            }
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (Model.Skins != value)
                {
                    Model.Skins = value;
                    propertyChanged.OnPropertyChanged();
                }
            }
        }*/


    }
}

