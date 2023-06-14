using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{

    public class BaseGenericVM<Base> : BaseVM
    {

        public Base Model
        {
            get => model;
            set
            {
                if(model is null)
                {
                    model = value;
                }
                if (model.Equals(value)) return;
                model = value;
                OnPropertyChanged();
            }
        }
        private Base model;

    }
}

