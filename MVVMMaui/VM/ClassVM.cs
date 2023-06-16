using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using ViewModel;

namespace MVVMMaui.VM
{
	public partial class ClassVM : ObservableObject
    {
        [ObservableProperty]
        private ChampionClassVM championClassVM;

        public ClassVM(ChampionClassVM championClassVM)
        {
            ChampionClassVM = championClassVM;
            ClassName = championClassVM.ToString();
            ImageName = ClassName.ToLower() + ".png";
        }

        [ObservableProperty]
        private string className;

        [ObservableProperty]
        private string imageName;

    }
}

