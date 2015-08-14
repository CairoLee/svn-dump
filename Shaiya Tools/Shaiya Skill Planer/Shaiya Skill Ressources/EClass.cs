using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya_Skill_Ressources {

	public enum EClass {
		__Start = 0,

		Archer_Elf,
		Mage_Elf,
		Ranger_Elf,

		Defender_Human,
		Fighter_Human,
		Priest_Human,

		Assasin_Vail,
		Oracle_Vail,
		Pagan_Vail,

		Warrior_Nordein,
		Guardian_Nordein,
		Hunter_Nordein,

		__End
	}

	public static class EClassExtension {

		public static string ToName( this EClass Class ) {
			switch( Class ) {
				case EClass.Archer_Elf:
					return "Bogenschütze (Elf)";
				case EClass.Mage_Elf:
					return "Magus (Elf)";
				case EClass.Ranger_Elf:
					return "Waldläufer (Elf)";

				case EClass.Defender_Human:
					return "Verteidiger (Mensch)";
				case EClass.Fighter_Human:
					return "Kämpfer (Mensch)";
				case EClass.Priest_Human:
					return "Priester (Mensch)";

				case EClass.Assasin_Vail:
					return "Atentäter (Vail)";
				case EClass.Oracle_Vail:
					return "Orakel (Vail)";
				case EClass.Pagan_Vail:
					return "Heide (Vail)";

				case EClass.Warrior_Nordein:
					return "Krieger (Nordein)";
				case EClass.Guardian_Nordein:
					return "Wächter (Nordein)";
				case EClass.Hunter_Nordein:
					return "Jäger (Nordein)";
				
				default:
					return "UNK \"" + Class.ToString() + "\"";
			}
		}

		public static int ToImageIndex( this EClass Class ) {
			switch( Class ) {
				case EClass.Fighter_Human:
				case EClass.Warrior_Nordein:
					return 0;

				case EClass.Defender_Human:
				case EClass.Guardian_Nordein:
					return 1;

				case EClass.Priest_Human:
				case EClass.Oracle_Vail:
					return 2;

				case EClass.Mage_Elf:
				case EClass.Pagan_Vail:
					return 3;

				case EClass.Ranger_Elf:
				case EClass.Assasin_Vail:
					return 4;

				case EClass.Archer_Elf:
				case EClass.Hunter_Nordein:
					return 5;

				default:
					return -1;
			}
		}

	}

}
