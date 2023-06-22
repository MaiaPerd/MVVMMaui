using System;
using System.Globalization;
using Model;

namespace ViewModel.converteur
{
	public class EnumToEnumVM
    {
        public static ChampionClassVM ChampionClassToChampionClassVM(string value)
        {
            bool success = Enum.TryParse((string)value, out ChampionClassVM enumValue);
            return success ? enumValue : ChampionClassVM.Unknown;
        }

        public static ChampionClass ChampionClassVMToChampionClass(string value)
        {
            bool success = Enum.TryParse((string)value, out ChampionClass enumValue);
            return success ? enumValue : ChampionClass.Unknown;
        }

        public static SkillTypeVM SkillTypeToSkillTypeVM(string value)
        {
            bool success = Enum.TryParse((string)value, out SkillTypeVM enumValue);
            return success ? enumValue : SkillTypeVM.Unknown;
        }

        public static SkillType SkillTypeVMToSkillType(string value)
        {
            bool success = Enum.TryParse((string)value, out SkillType enumValue);
            return success ? enumValue : SkillType.Unknown;
        }


    }
}

