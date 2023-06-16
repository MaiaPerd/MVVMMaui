using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using ViewModel;

namespace MVVMMaui.VM
{
	public class ClassVM : ObservableObject
    {
        public ChampionClassVM ChampionClassVM
        {
            get => championClassVM;
            set
            {
                if (championClassVM == value) return;
                championClassVM = value;
                OnPropertyChanged();
            }
        }
        private ChampionClassVM championClassVM;

        public ClassVM(ChampionClassVM championClassVM)
        {
            ChampionClassVM = championClassVM;
            ClassName = championClassVM.ToString();
            ImageName = ClassName.ToLower() + ".png";
        }

        public string ClassName
        {
            get => className;
            set
            {
                if (className == value) return;
                className = value;
                OnPropertyChanged();
            }
        }
        private string className;

        public string ImageName
        {
            get => imageName;
            set
            {
                if (imageName == value) return;
                imageName = value;
                OnPropertyChanged();
            }
        }
        private string imageName;

    }
}

