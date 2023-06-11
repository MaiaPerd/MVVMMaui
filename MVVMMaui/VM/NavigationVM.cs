using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MVVM;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public class NavigationVM : BaseVM
    {

		public ICommand NavigationChampionPageCommand { get; private set; }


		public NavigationVM()
		{
            NavigationChampionPageCommand = new Command<ChampionVM>(
                execute: (ChampionVM champion) =>
                {
                    Shell.Current.Navigation.PushAsync(new ChampionPage(champion));
                }
                );
        }

    


		
	}
}

