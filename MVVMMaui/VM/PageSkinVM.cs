using System;
using System.Windows.Input;
using MVVM;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public class PageSkinVM : BaseVM
	{
        public SkinVM Skin
        {
            get => skin;
        }
        private SkinVM skin;

        public PageSkinVM(SkinVM skinVM)
        {
            this.skin = skinVM;
            NavigationUpdateSkinPageCommand = new Command(
             execute: () =>
             {
                 Shell.Current.Navigation.PushAsync(new SkinAddPage(skinVM));
             }
             );
        }

        public ICommand NavigationUpdateSkinPageCommand { get; private set; }

    }
}