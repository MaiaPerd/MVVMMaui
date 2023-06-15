using System;
using System.Collections.ObjectModel;
using Model;
using MVVM;

namespace ViewModel
{
	public class SkinVM : BaseGenericVM<Skin>
	{

        public SkinVM(Skin model)
        {
            Model = model;
        }

        public SkinVM(SkinVM skinVM) : this(skinVM.Name, skinVM)
        {
        }

        public SkinVM(ChampionVM champion)
        {
            Model = new Skin(name: "Nouveau skin", champion: champion.Model);
        }

        public SkinVM(string name, SkinVM skinVM)
        {
            Model = new Skin(name: name, champion: skinVM.Champion ,price: skinVM.Price, icon: skinVM.Icon, image: skinVM.Image, description: skinVM.Description);
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

