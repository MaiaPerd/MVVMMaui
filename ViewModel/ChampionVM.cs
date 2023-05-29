using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using Model;
using MVVM;

namespace ViewModel
{
	public class ChampionVM : INotifyPropertyChanged
    {
        //Faire une classe génerique avec ça
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
        /*
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
        }*/

        public ImageSource Icon
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
        }


        public ImageSource Image
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Model.Image.Base64)));
            }
        

        //return Image.FromStream(new MemoryStream(Convert.FromBase64String(Model.Image.Base64)));
        // return Convert.ToBase64String(System.IO.File.ReadAllBytes(Model.Image.Base64));
    

            set
            {
                //if (Model == null || Model.Image == value) return;
                //Model.Image = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(Name)); Fais changer d'autre propriéter force le binding
            }
        }

        public ChampionClass Class//En théorie il ne faudrait pas utiliser l'enum du model
        {
            get => Model.Class;
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
        private ObservableCollection<Dictionary<string, int>> characteristics;
        public ReadOnlyObservableCollection<Dictionary<string, int>> Characteristics
        {
            get => Model.Characteristics;
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

