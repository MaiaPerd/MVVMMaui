using System;
using Model;
using System.Collections.ObjectModel;
using MVVM;

namespace ViewModel
{
	public class SkillVM : BaseGenericVM<Skill>
	{
        public SkillVM(Skill model)
		{
            Model = model;
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

