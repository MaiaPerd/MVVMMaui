using System;
using Model;
using System.Collections.ObjectModel;
using MVVM;

namespace ViewModel
{
	public class SkillVM : BaseVM
	{
        public Skill Model
        {
            get => model;
            set
            {
                if (model.Equals(value)) return;
                model = value;
                OnPropertyChanged();
            }
        }
        private Skill model;

        public SkillVM(Skill model)
		{
            this.model = model;
        }

        public string Name
        {
            get => Model.Name;
        }


        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model == null || Model.Description == value) return;
                Model.Description = value;
                OnPropertyChanged();
            }
        }

        public SkillType Type // A changer l'enum
        {
            get => Model.Type;
        }
    }
}

