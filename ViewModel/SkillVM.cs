using System;
using Model;
using System.Collections.ObjectModel;
using MVVM;
using ViewModel.converteur;

namespace ViewModel
{
	public class SkillVM : BaseGenericVM<Skill>
	{

        public string Name
        {
            get => Model?.Name;
        }

        public string Description
        {
            get => Model?.Description;
            set
            {
                if (Model == null || Model.Description == value) return;
                Model.Description = value;
                OnPropertyChanged();
            }
        }


        public SkillTypeVM Type
        {
            get => EnumToEnumVM.SkillTypeToSkillTypeVM(Model?.Type.ToString());
            
        }
    }
}

