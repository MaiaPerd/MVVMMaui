using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
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
        }

        [RelayCommand]
        private void NavigationUpdateSkinPage()
        {
            Shell.Current.Navigation.PushAsync(new SkinAddPage(Skin));
        }



    }
}