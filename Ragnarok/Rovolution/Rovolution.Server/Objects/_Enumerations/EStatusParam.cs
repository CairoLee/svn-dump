using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public enum EStatusParam {

		Speed,
		Baseexp,
		Jobexp,
		Karma,
		Manner,
		Hp,
		Maxhp,
		Sp,	// 0-7
		Maxsp,
		Statuspoint,
		Placeholder_0a,
		Baselevel,
		Skillpoint,
		Str,
		Agi,
		Vit,	// 8-15
		Int,
		Dex,
		Luk,
		Class,
		Zeny,
		Sex,
		Nextbaseexp,
		Nextjobexp,	// 16-23
		Weight,
		Maxweight,
		Placeholder_1a,
		Placeholder_1b,
		Placeholder_1c,
		Placeholder_1d,
		Placeholder_1e,
		Placeholder_1f,	// 24-31
		Ustr,
		Uagi,
		Uvit,
		Uint,
		Udex,
		Uluk,
		Placeholder_26,
		Placeholder_27,	// 32-39
		Placeholder_28,
		Atk1,
		Atk2,
		Matk1,
		Matk2,
		Def1,
		Def2,
		Mdef1,	// 40-47
		Mdef2,
		Hit,
		Flee1,
		Flee2,
		Critical,
		Aspd,
		Placeholder_36,
		Joblevel,	// 48-55
		Upper,
		Partner,
		Cart,
		Fame,
		Unbreakable,	// 56-60
		Cartinfo = 99,	// 99

		Basejob = 119,	// 100 + 19
		Baseclass = 120,	// Hmm.. Why 100 + 19? I just use the next one...
		Killerrid = 121,
		Killedrid = 122,

		// Mercenaries
		Mercflee = 165,
		Merckills = 189,
		Mercfaith = 190,

		// Original1000-
		Attackrange = 1000,
		Atkele,
		Defele,	// 1000-1002
		Castrate,
		Maxhprate,
		Maxsprate,
		Sprate,// 1003-1006
		Addele,
		Addrace,
		Addsize,
		Subele,
		Subrace,// 1007-1011
		Addeff,
		Reseff,	// 1012-1013
		BaseAtk,
		AspdRate,
		HpRecovRate,
		RecovRate,
		SpeedRate,// 1014-1018
		CriticalDef,
		NearAtkDef,
		LongAtkDef,// 1019-1021
		DoubleRate,
		DoubleAddRate,
		SkillHeal,
		MatkRate,// 1022-1025
		IgnoreDefEle,
		IgnoreDefRace,// 1026-1027
		AtkRate,
		SpeedAddrate,
		RegenRate,// 1028-1030
		MagicAtkDef,
		MiscAtkDef,// 1031-1032
		IgnoreMdefEle,
		IgnoreMdefRace,// 1033-1034
		MagicAddele,
		MagicAddrace,
		MagicAddsize,// 1035-1037
		PerfectHitRate,
		PerfectHitAddRate,
		CriticalRate,
		GetZenyNum,
		AddGetZenyNum,// 1038-1042
		AddDamageClass,
		AddMagicDamageClass,
		AddDefClass,
		AddMdefClass,// 1043-1046
		AddMonsterDropItem,
		DefRatioAtkEle,
		DefRatioAtkRace,
		UnbreakableGarment,// 1047-1050
		HitRate,
		FleeRate,
		Flee2Rate,
		DefRate,
		Def2Rate,
		MdefRate,
		Mdef2Rate,// 1051-1057
		SplashRange,
		SplashAddRange,
		Autospell,
		HpDrainRate,
		DrainRate,// 1058-1062
		ShortWeaponDamageReturn,
		LongWeaponDamageReturn,
		WeaponComaEle,
		WeaponComaRace,// 1063-1066
		Addeff2,
		BreakWeaponRate,
		BreakArmorRate,
		AddStealRate,// 1067-1070
		MagicDamageReturn,
		RandomAttackIncrease,
		AllStats,
		AgiVit,
		AgiDexStr,
		PerfectHide,// 1071-1076
		NoKnockback,
		Classchange,// 1077-1078
		HpDrainValue,
		DrainValue,// 1079-1080
		WeaponAtk,
		WeaponAtkRate,// 1081-1082
		Delayrate,
		HpDrainRateRace,
		DrainRateRace,// 1083-1085
		IgnoreMdefRate,
		IgnoreDefRate,
		SkillHeal2,
		AddeffOnskill,// 1086-1089
		AddHealRate,
		AddHeal2Rate,// 1090-1091

		RestartFullRecover = 2000,
		NoCastcancel,
		NoSizefix,
		NoMagicDamage,
		NoWeaponDamage,
		NoGemstone,// 2000-2005
		NoCastcancel2,
		NoMiscDamage,
		UnbreakableWeapon,
		UnbreakableArmor,
		UnbreakableHelm,// 2006-2010
		UnbreakableShield,
		LongAtkRate,// 2011-2012

		CritAtkRate,
		CriticalAddrace,
		NoRegen,
		AddeffWhenhit,
		AutospellWhenhit,// 2013-2017
		SkillAtk,
		Unstripable,
		AutospellOnskill,// 2018-2020
		GainValue,
		HpRegenRate,
		HpLossRate,
		Addrace2,
		HpGainValue,// 2021-2025
		Subsize,
		HpDrainValueRace,
		AddItemHealRate,
		DrainValueRace,
		ExpAddrace,	// 2026-2030
		GainRace,
		Subrace2,
		UnbreakableShoes,	// 2031-2033
		UnstripableWeapon,
		UnstripableArmor,
		UnstripableHelm,
		UnstripableShield,// 2034-2037
		Intravision,
		AddMonsterDropItemgroup,
		LossRate,// 2038-2040
		AddSkillBlow,
		VanishRate,
		MagicGainValue,
		MagicHpGainValue,
		AddClassDropItem// 2041-2045
	}
}
