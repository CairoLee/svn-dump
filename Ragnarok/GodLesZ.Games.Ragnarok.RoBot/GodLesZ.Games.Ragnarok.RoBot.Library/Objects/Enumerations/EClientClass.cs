using System;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Objects.Enumerations {

	/// <summary>
	/// These mark the ID of the jobs, as expected by the client
	/// </summary>
	public enum EClientClass {
		Novice,
		Swordman,
		Mage,
		Archer,
		Acolyte,
		Merchant,
		Thief,
		Knight,
		Priest,
		Wizard,
		Blacksmith,
		Hunter,
		Assassin,
		Knight2,
		Crusader,
		Monk,
		Sage,
		Rogue,
		Alchemist,
		Bard,
		Dancer,
		Crusader2,
		Wedding,
		SuperNovice,
		Gunslinger,
		Ninja,
		Xmas,
		Summer,
		MaxBasic,

		NoviceHigh = 4001,
		SwordmanHigh,
		MageHigh,
		ArcherHigh,
		AcolyteHigh,
		MerchantHigh,
		ThiefHigh,
		LordKnight,
		HighPriest,
		HighWizard,
		Whitesmith,
		Sniper,
		AssassinCross,
		LordKnight2,
		Paladin,
		Champion,
		Professor,
		Stalker,
		Creator,
		Clown,
		Gypsy,
		Paladin2,

		Baby,
		BabySwordman,
		BabyMage,
		BabyArcher,
		BabyAcolyte,
		BabyMerchant,
		BabyThief,
		BabyKnight,
		BabyPriest,
		BabyWizard,
		BabyBlacksmith,
		BabyHunter,
		BabyAssassin,
		BabyKnight2,
		BabyCrusader,
		BabyMonk,
		BabySage,
		BabyRogue,
		BabyAlchemist,
		BabyBard,
		BabyDancer,
		BabyCrusader2,
		SuperBaby,

		Taekwon,
		StarGladiator,
		StarGladiator2,
		SoulLinker,
		Max
	}


	public static class ClientClassExtension {

		public static EClass Convert(this EClientClass cls) {
			var memberName = cls.ToString();
			var serverClass = (EClass)Enum.Parse(typeof(EClass), memberName);
			return serverClass;
		}

		public static EClientClass Index(this EClientClass cls) {
			var iCls = (int)cls;
			if (iCls >= (int)EClientClass.NoviceHigh) {
				return (EClientClass)(iCls - (int)EClientClass.NoviceHigh + (int)EClientClass.MaxBasic);
			}
			return cls;
		}
	}

}
