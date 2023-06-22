using System;
using Model;
using MVVM;
using ViewModel;

namespace MVVMMaui.VM
{
	public class ClassVM : BaseVM
	{
        public ChampionClassVM ChampionClassVM
        {
            set { SetProperty(ref championClassVM, value); }
            get { return championClassVM; }
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
            set { SetProperty(ref className, value); }
            get { return className; }
        }
        private string className;

        public string ImageName
        {
            set { SetProperty(ref imageName, value); }
            get { return imageName; }
        }
        private string imageName;

    }
}

