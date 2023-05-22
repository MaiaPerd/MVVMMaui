using System;
using Model;
using MVVM;

namespace ViewModel
{
	public class SkinVM
	{
        private Skin Model { get; set; }

        private ToolKit propertyChanged;

        public SkinVM(Skin model)
        {
            Model = model;
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
                    propertyChanged.OnPropertyChanged();
                }
            }
        }

        public string Icon
        {
            get => Model.Icon;
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (Model.Icon != value)
                {
                    Model.Icon = value;
                    propertyChanged.OnPropertyChanged();
                }
            }
        }

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
                    propertyChanged.OnPropertyChanged();
                }
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
                    propertyChanged.OnPropertyChanged();
                }
            }
        }

        public Champion Champion
        {
            get => Model.Champion;
        }


    }
}

