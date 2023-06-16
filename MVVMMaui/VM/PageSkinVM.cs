using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public partial class PageSkinVM : ObservableObject
	{
        [ObservableProperty]
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