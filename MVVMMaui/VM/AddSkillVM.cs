using System;
using MVVM;
using System.Windows.Input;
using ViewModel;
using Model;

namespace MVVMMaui.VM
{
	public class AddSkillVM : BaseVM
    {

        SkillVM skillEdit;

        public SkillVM SkillEdit
        {
            set { SetProperty(ref skillEdit, value); }
            get { return skillEdit; }
        }

        public ChampionManagerVM ChampionManagerVM
        {
            get => championManagerVM;
        }
        private ChampionManagerVM championManagerVM;


        public AddSkillVM(ChampionVM championVM, ChampionManagerVM championManagerVM)
        {
            SkillEdit = new SkillVM();
            this.championManagerVM = championManagerVM;
            name = SkillEdit.Name;
            AddSkillCommand = new Command(execute: () =>
            {
                championVM.AddSkillCommand.Execute(new SkillVM(Name, SkillEdit));
                Shell.Current.Navigation.PopModalAsync();
            });
            ResetSkillCommand = new Command(execute: () =>
            {
                SkillEdit = new SkillVM();
            });
        }

        public ICommand AddSkillCommand { get; set; }
        public ICommand ResetSkillCommand { get; set; }


        public string Name
        {
            set { SetProperty(ref name, value); }
            get { return name; }
        }
        private string name;

     
    }
}

