using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
			Model = model;
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

