using System;
using Model;
using MVVM;

namespace ViewModel
{
	public class SkinVM : BaseVM
	{
        public Skin Model
        {
            get => model;
            set
            {
                if (model.Equals(value)) return;
                model = value;
                OnPropertyChanged();
            }
        }
        private Skin model;

        public SkinVM(Skin model)
        {
            this.model = model;
        }

        public string Name
        {
            get => Model.Name;
        }

        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (Model.Description != value)
                {
                    Model.Description = value;
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
            }
        }

        public float Price
        {
            get => Model.Price;
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (Model.Price != value)
                {
                    Model.Price = value;
                    OnPropertyChanged();
                }
            }
        }

        public Champion Champion
        {
            get => Model.Champion;
        }


    }
}

