using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MVVMMaui.Pages;
using ViewModel;

namespace MVVMMaui.VM
{
	public class NavigationVM
	{

		public ICommand NavigationCommand { get; private set; }
		public NavigationVM()
		{
			NavigationCommand = new Command<ChampionVM>(push);
		}

		private void push(ChampionVM champion)
        {
			Shell.Current.Navigation.PushAsync(new ChampionPage(champion));

        }
		
	}
}

