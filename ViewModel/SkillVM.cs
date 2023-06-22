using System;
using Model;
using System.Collections.ObjectModel;
using MVVM;
using ViewModel.converteur;

namespace ViewModel
{
	public class SkillVM : BaseGenericVM<Skill>
	{
        public SkillVM(Skill model) : base(model)
        {
        }

        public SkillVM(SkillVM skill) : this(skill.Name, skill)
        {
        }

        public SkillVM(string name, SkillVM skill) : base(new Skill(name, EnumToEnumVM.SkillTypeVMToSkillType(skill.Type.ToString()), skill.Description))
        {
        }

        public SkillVM() : base(new Skill("Nouveau skill", SkillType.Basic, ""))
        {
        }

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

