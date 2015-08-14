using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// Represents the class, used in the world server (eAthenas MAPID_*)
	/// <para>
	/// Note: The flags used in the itemdb will be converted
	/// </para>
	/// </summary>
	public enum EClass {
		JOBl_2_1 = 0x100, // 256
		JOBl_2_2 = 0x200, // 512
		JOBl_2 = 0x300, // 1024

		JOBl_UPPER = 0x1000, // 4096
		JOBl_BABY = 0x2000, // 8192

		// For filtering and quick checking
		UPPERMASK = 0x0fff,
		BASEMASK = 0x00ff,


		// 1_1 classes
		Novice = 0x0,
		Swordman,
		Mage,
		Archer,
		Acolyte,
		Merchant,
		Thief,
		Taekwon,
		Wedding,
		Gunslinger,
		Ninja,
		Xmas,
		Summer,
		MaxBase,
		// 2_1 classes
		Super_Novice = JOBl_2_1 | 0x0,
		Knight,
		Wizard,
		Hunter,
		Priest,
		Blacksmith,
		Assassin,
		StarGladiator,
		// 2_2 classes
		Crusader = JOBl_2_2 | 0x1,
		Sage,
		Barddancer,
		Monk,
		Alchemist,
		Rogue,
		SoulLinker,
		// 1-1 advanced
		NoviceHigh = JOBl_UPPER | 0x0,
		SwordmanHigh,
		MageHigh,
		ArcherHigh,
		AcolyteHigh,
		MerchantHigh,
		ThiefHigh,
		// 2_1 advanced
		LordKnight = JOBl_UPPER | JOBl_2_1 | 0x1,
		HighWizard,
		Sniper,
		HighPriest,
		Whitesmith,
		AssassinCross,
		// 2_2 advanced
		Paladin = JOBl_UPPER | JOBl_2_2 | 0x1,
		Professor,
		Clowngypsy,
		Champion,
		Creator,
		Stalker,
		// 1-1 baby
		Baby = JOBl_BABY | 0x0,
		BabySwordman,
		BabyMage,
		BabyArcher,
		BabyAcolyte,
		BabyMerchant,
		BabyThief,
		BabyTaekwon,
		// 2_1 baby
		SuperBaby = JOBl_BABY | JOBl_2_1 | 0x0,
		BabyKnight,
		BabyWizard,
		BabyHunter,
		BabyPriest,
		BabyBlacksmith,
		BabyAssassin,
		BabyStar_Gladiator,
		// 2_2 baby
		BabyCrusader = JOBl_BABY | JOBl_2_2 | 0x1,
		BabySage,
		BabyBarddancer,
		BabyMonk,
		BabyAlchemist,
		BabyRogue,
		BabySoulLinker,
		Max
	}


	public static class ServerClassExtension {

		/// <summary>
		/// Converts the class from eAs system to the client system
		/// </summary>
		/// <param name="cls"></param>
		/// <returns></returns>
		public static EClientClass Convert(this EClass cls) {
			string memberName = cls.ToString();
			EClientClass clientClass = (EClientClass)Enum.Parse(typeof(EClientClass), memberName);
			return clientClass;
		}

	}

}
