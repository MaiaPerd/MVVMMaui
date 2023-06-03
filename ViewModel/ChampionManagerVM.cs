using System;
using Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;

namespace ViewModel
{
	public class ChampionManagerVM
	{
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
   
        private ObservableCollection<ChampionVM> champions = new ObservableCollection<ChampionVM>();

        private IDataManager DataManager { get; set; }

        public ChampionManagerVM(IDataManager dataManager)
		{
            DataManager = dataManager;
            index = 1;
            count = 5;
            GetNbChampions();
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
            LoadChampions(index, count);

            PropertyChanged += ChampionManagerVM_PropertyChanged;
            NextPageCommand = new Command(execute: () =>
            {
                Index += 1;
            }, canExecute: () =>
            {
                return Index + 1 <= IndexMax;
            });

            PreviousPageCommand = new Command(execute: () =>
            {
                Index -= 1;
            }, canExecute: () =>
            {
                return Index - 1 >= 1;
            });
        }

        private void ChampionManagerVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName != null)
            {
                LoadChampions(Index, Count);
                GetNbChampions();
                (NextPageCommand as Command).ChangeCanExecute();
                (PreviousPageCommand as Command).ChangeCanExecute();

            }
        }

        public int Index
        {
           get => index;
           set
           {
               if (index == value) return;
               index = value;
               OnPropertyChanged();
           }
        }
        private int index;

        public int IndexMax
        {
            get => indexMax + 1;
            set
            {
                if (indexMax == value) return;
                indexMax = value;
                OnPropertyChanged();
            }
        }
        private int indexMax;

        public int Count
        {
            get => count;
            set
            {
                if (count == value) return;
                count = value;
                OnPropertyChanged();
            }
        }
        private int count;


        public async Task LoadChampions(int index, int count)
        {
            champions.Clear();
            var a = await DataManager.ChampionsMgr.GetItems(index-1, count);
            foreach (var champion in a)
            {//trie
                champions.Add(new ChampionVM(champion));
            }

        }

        public async Task GetNbChampions()
        {
            
            IndexMax = await DataManager.ChampionsMgr.GetNbItems() / Count;

        }


        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
    }
}



//mette la readonly new () pour champions
// PropertyChanged += ChampionManagerVM.PropertyChanged;
/* command code bing de la page 
 * methode abboner pour chaque element de chaque vue
 * C'est les cas d'utilisation
 * binding des fonctionalité ecrite en code, ce sont les commande
 * je bind le bouton su rune fonctionalité de la vm wraping
 * Ou sur la vm applicative
 * binder a plusieur element de plusieurs appli a evité
 * 
 * Command toujours bindable a ICommand
 * 
 * Une commande a 2 méthode execute et canexecute(si on a le droit d'execute la command)
 * Par default elle a pas de paramètre c'est une action
 * 
 * execute -> prend rien et renvoie rien c'est le but
 * canexcute -> renvoie un bool Func<bool> (return quelque chose ou rien) 
 * 
 * Avec un command parameter on a un objet
 * 
 * Si les vu non pas la command on peut les binder a un evenement 
 * Toolkit eventToBeheviorCommand qui transform les evenmeny en commande
 * 
 * Sur la vm on declare
 * 
 * public ICommand qui est definie dans la commande !!attention ne pas faire de propriéter calculé!!
 * Puis dans le constructeur on definie la commande :
 * load Nounours (new Command( execute => Load..()
   canExcute => Mgr != null //Mgr dans le model
 * La commande est bindable n'importe ou
 * Utilisation <Button Command="Binding nomCommand">
 * 
 * Ne met pas a jour le can execute donc dans le seteur on mes a jour la commande
 * Dans la proprité détailler:
 * private Manager Mgr {
 * get => mgr;
 * set{
 *  mgr = value
 *  (loadCommand as Command).ChangeCanExecute();
 * }
 * }
 * 
 * private Manager mgr = new Manager()
 * 


*/