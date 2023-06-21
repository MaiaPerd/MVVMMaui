using System;
using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ViewModel;

namespace MVVMMaui.VM
{
	public partial class AddChampionVM : ObservableObject
    {
        [ObservableProperty]
        private ChampionVM championEditCopie;

        [ObservableProperty]
        private ChampionManagerVM championManagerVM;

        private bool add;

        public AddChampionVM(ChampionManagerVM championManagerVM, ChampionVM champion)
        {
            this.championEditCopie = new ChampionVM(champion);
            this.championManagerVM = championManagerVM;
            ChampionsClass = new ReadOnlyObservableCollection<ClassVM>(championsClass);
            LoadChampionsClass();
            Selection = new ClassVM(ChampionEditCopie.Class);
            name = ChampionEditCopie.Name;
            this.titre = "Modifier le Champion";
            this.status = "Modifier";
            this.edit = false;

            add = (false);
        }

        public AddChampionVM(ChampionManagerVM championManagerVM)
		{
            this.championEditCopie = new ChampionVM();
            var converter = new StringToImageConverter();
            using FileStream fs = File.OpenRead("logolol.png");
            ImageSource image = ImageSource.FromStream(() => fs);
            ChampionEditCopie.Image = (string)converter.ConvertBack(image, null, null, CultureInfo.CurrentCulture);
            using FileStream fs2 = File.OpenRead("logo.png");
            ImageSource icon = ImageSource.FromStream(() => fs2);
            ChampionEditCopie.Icon = (string)converter.ConvertBack(icon, null, null, CultureInfo.CurrentCulture);
            championManagerVM.ChampionEdit = ChampionEditCopie;
            this.championManagerVM = championManagerVM;
            ChampionsClass = new ReadOnlyObservableCollection<ClassVM>(championsClass);
            LoadChampionsClass();
            Selection = ChampionsClass.First();
            name = ChampionEditCopie.Name;
            this.titre = "Nouveau Champion";
            this.status = "Ajouter";
            this.edit = true;

            add = (true);
        }

        [RelayCommand]
        private void UpdateChampion()
        {
            ChampionEditCopie.Class = Selection.ChampionClassVM;
            ChampionManagerVM.SaveChampionCommand.Execute(add ? new ChampionVM(Name, ChampionEditCopie) : ChampionEditCopie);
            Shell.Current.Navigation.PopAsync();
        }


        [RelayCommand]
        private void AddCharacteristic()
        {
            ChampionEditCopie.AddCharacteristicCommand.Execute(new KeyValuePair<string, int>(CharacteristicsValue, CharacteristicsKey));
            CharacteristicsValue = "";
            CharacteristicsKey = 0;
        }

        [RelayCommand]
        private void ResetChampion()
        {
            ChampionEditCopie = new ChampionVM(ChampionManagerVM.ChampionEdit);
        }

        [RelayCommand]
        private async Task ImageChange()
        {
            string image = await PickAndShow();
            if (image != null)
            {
                ChampionEditCopie.Image = image;
            }
        }

        [RelayCommand]
        private async Task IconChange()
        {
            string image = await PickAndShow();
            if (image != null)
            {
                ChampionEditCopie.Icon = image;
            }
        }

        public async Task<String> PickAndShow()
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(PickOptions.Images);
                if (result != null)
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                    var converter = new StringToImageConverter();
                    return (string)converter.ConvertBack(image, null, null, CultureInfo.CurrentCulture);
                }
                return null;
               /* if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        // save the file into local storage
                        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                        using Stream sourceStream = await photo.OpenReadAsync();
                        using FileStream localFileStream = File.OpenWrite(localFilePath);

                        await sourceStream.CopyToAsync(localFileStream);
                    }
                }*/
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }

        public ReadOnlyObservableCollection<ClassVM> ChampionsClass { get; private set; }

        private ObservableCollection<ClassVM> championsClass = new ObservableCollection<ClassVM>();

        private void LoadChampionsClass()
        {
            foreach (ChampionClassVM classVM in ChampionManagerVM.ChampionsClass)
            {
                if(classVM != ChampionClassVM.Unknown)
                {
                    championsClass.Add(new ClassVM(classVM));
                }
            }

        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string titre;

        [ObservableProperty]
        private string status;

        [ObservableProperty]
        private bool edit;

        [ObservableProperty]
        private ClassVM selection;

        [ObservableProperty]
        private string characteristicsValue = "";

        [ObservableProperty]
        private int characteristicsKey = 0;

    }
}

