using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Objects;

namespace Rovolution.Server {

	/// <summary>
	/// Represents a status foir a serial object
	/// <para>Only used for Character, Mobs, Mercenary and Pets</para>
	/// </summary>
	public class WorldObjectStatus : /*DatabaseObject, */ICloneable {
		/// <summary>
		/// skill -> status
		/// </summary>
		private static EStatusChange[] SkillStatusChangeTable;
		/// <summary>
		/// status -> icon
		/// </summary>
		private static EStatusChangeIcon[] StatusIconChangeTable;
		/// <summary>
		/// status -> skill
		/// </summary>
		private static ESkill[] StatusSkillChangeTable;

		/// <summary>
		/// Status -> flags
		/// </summary>
		public static EStatusCalcFlag[] StatusChangeFlagTable {
			get;
			private set;
		}


		/// <summary>
		/// Gets or sets the WorldObject of this status
		/// </summary>
		public WorldObject Object {
			get;
			set;
		}


		public uint HP {
			get;
			set;
		}

		public uint HPMax {
			get;
			set;
		}

		public uint SP {
			get;
			set;
		}

		public uint SPMax {
			get;
			set;
		}


		// Attributes
		// TODO: extract to single struct?
		public ushort Str {
			get;
			set;
		}

		public ushort Agi {
			get;
			set;
		}

		public ushort Vit {
			get;
			set;
		}

		public ushort Int {
			get;
			set;
		}

		public ushort Dex {
			get;
			set;
		}

		public ushort Luk {
			get;
			set;
		}


		public ushort AtkBase {
			get;
			set;
		}

		public ushort MagicAtkMin {
			get;
			set;
		}

		public ushort MagicAtkMax {
			get;
			set;
		}

		public ushort Speed {
			get;
			set;
		}

		public ushort AMotion {
			get;
			set;
		}

		public ushort ADelay {
			get;
			set;
		}

		public ushort DMotion {
			get;
			set;
		}

		public EMonsterMode Mode {
			get;
			set;
		}

		public short Hit {
			get;
			set;
		}

		public short Flee {
			get;
			set;
		}

		public short Flee2 {
			get;
			set;
		}

		public short Crit {
			get;
			set;
		}

		public short Def2 {
			get;
			set;
		}

		public short MDef2 {
			get;
			set;
		}

		public short AspdRate {
			get;
			set;
		}

		public EElement DefEle {
			get;
			set;
		}

		public byte EleLv {
			get;
			set;
		}

		public ESize Size {
			get;
			set;
		}

		public ERace Race {
			get;
			set;
		}


		public byte Def {
			get;
			set;
		}

		public byte MDef {
			get;
			set;
		}

		public WeaponAtk Rhw {
			get;
			set;
		}

		public WeaponAtk Lhw {
			get;
			set;
		}


		public WorldObjectStatus(WorldObject obj) {
			Object = obj;
			Rhw = new WeaponAtk();
			Lhw = new WeaponAtk();
			//Serial = new DatabaseID(obj.ID, obj.Type);
		}


		public static void Initialize() {
			InitializeStatusTable();
		}


		#region StatusChange tables
		private static void InitializeStatusTable() {
			StatusSkillChangeTable = new ESkill[(int)EStatusChange.Max];
			StatusIconChangeTable = new EStatusChangeIcon[(int)EStatusChange.Max];
			StatusChangeFlagTable = new EStatusCalcFlag[(int)EStatusChange.Max];
			SkillStatusChangeTable = new EStatusChange[(int)ESkill.Max];

			// First we define the skill for common ailments. These are used in skill_additional_effect through sc cards
			AddSC(ESkill.NpcPetrifyattack, EStatusChange.Stone, EStatusChangeIcon.Blank, EStatusCalcFlag.DefEle | EStatusCalcFlag.Def | EStatusCalcFlag.Mdef);
			AddSC(ESkill.NpcWidefreeze, EStatusChange.Freeze, EStatusChangeIcon.Blank, EStatusCalcFlag.DefEle | EStatusCalcFlag.Def | EStatusCalcFlag.Mdef);
			AddSC(ESkill.NpcStunattack, EStatusChange.Stun, EStatusChangeIcon.Blank, EStatusCalcFlag.None);
			AddSC(ESkill.NpcSleepattack, EStatusChange.Sleep, EStatusChangeIcon.Blank, EStatusCalcFlag.None);
			AddSC(ESkill.NpcPoison, EStatusChange.Poison, EStatusChangeIcon.Blank, EStatusCalcFlag.Def2 | EStatusCalcFlag.Regen);
			AddSC(ESkill.NpcCurseattack, EStatusChange.Curse, EStatusChangeIcon.Blank, EStatusCalcFlag.Luk | EStatusCalcFlag.Batk | EStatusCalcFlag.Watk | EStatusCalcFlag.Speed);
			AddSC(ESkill.NpcSilenceattack, EStatusChange.Silence, EStatusChangeIcon.Blank, EStatusCalcFlag.None);
			AddSC(ESkill.NpcWideconfuse, EStatusChange.Confusion, EStatusChangeIcon.Blank, EStatusCalcFlag.None);
			AddSC(ESkill.NpcBlindattack, EStatusChange.Blind, EStatusChangeIcon.Blank, EStatusCalcFlag.Hit | EStatusCalcFlag.Flee);
			AddSC(ESkill.NpcBleeding, EStatusChange.Bleeding, EStatusChangeIcon.Bleeding, EStatusCalcFlag.Regen);
			AddSC(ESkill.NpcPoison, EStatusChange.Dpoison, EStatusChangeIcon.Blank, EStatusCalcFlag.Def2 | EStatusCalcFlag.Regen);

			// The main status definitions
			AddSC(ESkill.SmBash, EStatusChange.Stun);
			AddSC(ESkill.SmProvoke, EStatusChange.Provoke, EStatusChangeIcon.Provoke, EStatusCalcFlag.Def | EStatusCalcFlag.Def2 | EStatusCalcFlag.Batk | EStatusCalcFlag.Watk);
			AddSC(ESkill.SmMagnum, EStatusChange.WatkElement);
			AddSC(ESkill.SmEndure, EStatusChange.Endure, EStatusChangeIcon.Endure, EStatusCalcFlag.Mdef | EStatusCalcFlag.Dspd);
			AddSC(ESkill.MgSight, EStatusChange.Sight);
			AddSC(ESkill.MgSafetywall, EStatusChange.Safetywall);
			AddSC(ESkill.MgFrostdiver, EStatusChange.Freeze);
			AddSC(ESkill.MgStonecurse, EStatusChange.Stone);
			AddSC(ESkill.AlRuwach, EStatusChange.Ruwach);
			AddSC(ESkill.AlPneuma, EStatusChange.Pneuma);
			AddSC(ESkill.AlIncagi, EStatusChange.Increaseagi, EStatusChangeIcon.Increaseagi, EStatusCalcFlag.Agi | EStatusCalcFlag.Speed);
			AddSC(ESkill.AlDecagi, EStatusChange.Decreaseagi, EStatusChangeIcon.Decreaseagi, EStatusCalcFlag.Agi | EStatusCalcFlag.Speed);
			AddSC(ESkill.AlCrucis, EStatusChange.Signumcrucis, EStatusChangeIcon.Signumcrucis, EStatusCalcFlag.Def);
			AddSC(ESkill.AlAngelus, EStatusChange.Angelus, EStatusChangeIcon.Angelus, EStatusCalcFlag.Def2);
			AddSC(ESkill.AlBlessing, EStatusChange.Blessing, EStatusChangeIcon.Blessing, EStatusCalcFlag.Str | EStatusCalcFlag.Int | EStatusCalcFlag.Dex);
			AddSC(ESkill.AcConcentration, EStatusChange.Concentrate, EStatusChangeIcon.Concentrate, EStatusCalcFlag.Agi | EStatusCalcFlag.Dex);
			AddSC(ESkill.TfHiding, EStatusChange.Hiding, EStatusChangeIcon.Hiding, EStatusCalcFlag.Speed);
			AddSC(ESkill.TfPoison, EStatusChange.Poison);
			AddSC(ESkill.KnTwohandquicken, EStatusChange.Twohandquicken, EStatusChangeIcon.Twohandquicken, EStatusCalcFlag.Aspd);
			AddSC(ESkill.KnAutocounter, EStatusChange.Autocounter);
			AddSC(ESkill.PrImpositio, EStatusChange.Impositio, EStatusChangeIcon.Impositio, EStatusCalcFlag.Watk);
			AddSC(ESkill.PrSuffragium, EStatusChange.Suffragium, EStatusChangeIcon.Suffragium, EStatusCalcFlag.None);
			AddSC(ESkill.PrAspersio, EStatusChange.Aspersio, EStatusChangeIcon.Aspersio, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.PrBenedictio, EStatusChange.Benedictio, EStatusChangeIcon.Benedictio, EStatusCalcFlag.DefEle);
			AddSC(ESkill.PrSlowpoison, EStatusChange.Slowpoison, EStatusChangeIcon.Slowpoison, EStatusCalcFlag.Regen);
			AddSC(ESkill.PrKyrie, EStatusChange.Kyrie, EStatusChangeIcon.Kyrie, EStatusCalcFlag.None);
			AddSC(ESkill.PrMagnificat, EStatusChange.Magnificat, EStatusChangeIcon.Magnificat, EStatusCalcFlag.Regen);
			AddSC(ESkill.PrGloria, EStatusChange.Gloria, EStatusChangeIcon.Gloria, EStatusCalcFlag.Luk);
			AddSC(ESkill.PrLexdivina, EStatusChange.Silence);
			AddSC(ESkill.PrLexaeterna, EStatusChange.Aeterna, EStatusChangeIcon.Aeterna, EStatusCalcFlag.None);
			AddSC(ESkill.WzMeteor, EStatusChange.Stun);
			AddSC(ESkill.WzVermilion, EStatusChange.Blind);
			AddSC(ESkill.WzFrostnova, EStatusChange.Freeze);
			AddSC(ESkill.WzStormgust, EStatusChange.Freeze);
			AddSC(ESkill.WzQuagmire, EStatusChange.Quagmire, EStatusChangeIcon.Quagmire, EStatusCalcFlag.Agi | EStatusCalcFlag.Dex | EStatusCalcFlag.Aspd | EStatusCalcFlag.Speed);
			AddSC(ESkill.BsAdrenaline, EStatusChange.Adrenaline, EStatusChangeIcon.Adrenaline, EStatusCalcFlag.Aspd);
			AddSC(ESkill.BsWeaponperfect, EStatusChange.Weaponperfection, EStatusChangeIcon.Weaponperfection, EStatusCalcFlag.None);
			AddSC(ESkill.BsOverthrust, EStatusChange.Overthrust, EStatusChangeIcon.Overthrust, EStatusCalcFlag.None);
			AddSC(ESkill.BsMaximize, EStatusChange.Maximizepower, EStatusChangeIcon.Maximizepower, EStatusCalcFlag.Regen);
			AddSC(ESkill.HtLandmine, EStatusChange.Stun);
			AddSC(ESkill.HtAnklesnare, EStatusChange.Ankle);
			AddSC(ESkill.HtSandman, EStatusChange.Sleep);
			AddSC(ESkill.HtFlasher, EStatusChange.Blind);
			AddSC(ESkill.HtFreezingtrap, EStatusChange.Freeze);
			AddSC(ESkill.AsCloaking, EStatusChange.Cloaking, EStatusChangeIcon.Cloaking, EStatusCalcFlag.Cri | EStatusCalcFlag.Speed);
			AddSC(ESkill.AsSonicblow, EStatusChange.Stun);
			AddSC(ESkill.AsEnchantpoison, EStatusChange.Encpoison, EStatusChangeIcon.Encpoison, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.AsPoisonreact, EStatusChange.Poisonreact, EStatusChangeIcon.Poisonreact, EStatusCalcFlag.None);
			AddSC(ESkill.AsVenomdust, EStatusChange.Poison);
			AddSC(ESkill.AsSplasher, EStatusChange.Splasher);
			AddSC(ESkill.NvTrickdead, EStatusChange.Trickdead, EStatusChangeIcon.Trickdead, EStatusCalcFlag.Regen);
			AddSC(ESkill.SmAutoberserk, EStatusChange.Autoberserk, EStatusChangeIcon.Autoberserk, EStatusCalcFlag.None);
			AddSC(ESkill.TfSprinklesand, EStatusChange.Blind);
			AddSC(ESkill.TfThrowstone, EStatusChange.Stun);
			AddSC(ESkill.McLoud, EStatusChange.Loud, EStatusChangeIcon.Loud, EStatusCalcFlag.Str);
			AddSC(ESkill.MgEnergycoat, EStatusChange.Energycoat, EStatusChangeIcon.Energycoat, EStatusCalcFlag.None);
			AddSC(ESkill.NpcEmotion, EStatusChange.Modechange, EStatusChangeIcon.Blank, EStatusCalcFlag.Mode);
			AddSC(ESkill.NpcEmotionOn, EStatusChange.Modechange);
			AddSC(ESkill.NpcAttrichange, EStatusChange.Elementalchange, EStatusChangeIcon.ArmorProperty, EStatusCalcFlag.DefEle);
			AddSC(ESkill.NpcChangewater, EStatusChange.Elementalchange);
			AddSC(ESkill.NpcChangeground, EStatusChange.Elementalchange);
			AddSC(ESkill.NpcChangefire, EStatusChange.Elementalchange);
			AddSC(ESkill.NpcChangewind, EStatusChange.Elementalchange);
			AddSC(ESkill.NpcChangepoison, EStatusChange.Elementalchange);
			AddSC(ESkill.NpcChangeholy, EStatusChange.Elementalchange);
			AddSC(ESkill.NpcChangedarkness, EStatusChange.Elementalchange);
			AddSC(ESkill.NpcChangetelekinesis, EStatusChange.Elementalchange);
			AddSC(ESkill.NpcPoison, EStatusChange.Poison);
			AddSC(ESkill.NpcBlindattack, EStatusChange.Blind);
			AddSC(ESkill.NpcSilenceattack, EStatusChange.Silence);
			AddSC(ESkill.NpcStunattack, EStatusChange.Stun);
			AddSC(ESkill.NpcPetrifyattack, EStatusChange.Stone);
			AddSC(ESkill.NpcCurseattack, EStatusChange.Curse);
			AddSC(ESkill.NpcSleepattack, EStatusChange.Sleep);
			AddSC(ESkill.NpcMagicalattack, EStatusChange.Magicalattack);
			AddSC(ESkill.NpcKeeping, EStatusChange.Keeping, EStatusChangeIcon.Blank, EStatusCalcFlag.Def);
			AddSC(ESkill.NpcDarkblessing, EStatusChange.Coma);
			AddSC(ESkill.NpcBarrier, EStatusChange.Barrier, EStatusChangeIcon.Blank, EStatusCalcFlag.Mdef | EStatusCalcFlag.Def);
			AddSC(ESkill.NpcDefender, EStatusChange.Armor);
			AddSC(ESkill.NpcLick, EStatusChange.Stun);
			AddSC(ESkill.NpcHallucination, EStatusChange.Hallucination, EStatusChangeIcon.Hallucination, EStatusCalcFlag.None);
			AddSC(ESkill.NpcRebirth, EStatusChange.Rebirth);
			AddSC(ESkill.RgRaid, EStatusChange.Stun);
			AddSC(ESkill.RgStripweapon, EStatusChange.Stripweapon, EStatusChangeIcon.Stripweapon, EStatusCalcFlag.Watk);
			AddSC(ESkill.RgStripshield, EStatusChange.Stripshield, EStatusChangeIcon.Stripshield, EStatusCalcFlag.Def);
			AddSC(ESkill.RgStriparmor, EStatusChange.Striparmor, EStatusChangeIcon.Striparmor, EStatusCalcFlag.Vit);
			AddSC(ESkill.RgStriphelm, EStatusChange.Striphelm, EStatusChangeIcon.Striphelm, EStatusCalcFlag.Int);
			AddSC(ESkill.AmAcidterror, EStatusChange.Bleeding);
			AddSC(ESkill.AmCpWeapon, EStatusChange.CpWeapon, EStatusChangeIcon.CpWeapon, EStatusCalcFlag.None);
			AddSC(ESkill.AmCpShield, EStatusChange.CpShield, EStatusChangeIcon.CpShield, EStatusCalcFlag.None);
			AddSC(ESkill.AmCpArmor, EStatusChange.CpArmor, EStatusChangeIcon.CpArmor, EStatusCalcFlag.None);
			AddSC(ESkill.AmCpHelm, EStatusChange.CpHelm, EStatusChangeIcon.CpHelm, EStatusCalcFlag.None);
			AddSC(ESkill.CrAutoguard, EStatusChange.Autoguard, EStatusChangeIcon.Autoguard, EStatusCalcFlag.None);
			AddSC(ESkill.CrShieldcharge, EStatusChange.Stun);
			AddSC(ESkill.CrReflectshield, EStatusChange.Reflectshield, EStatusChangeIcon.Reflectshield, EStatusCalcFlag.None);
			AddSC(ESkill.CrHolycross, EStatusChange.Blind);
			AddSC(ESkill.CrGrandcross, EStatusChange.Blind);
			AddSC(ESkill.CrDevotion, EStatusChange.Devotion);
			AddSC(ESkill.CrProvidence, EStatusChange.Providence, EStatusChangeIcon.Providence, EStatusCalcFlag.All);
			AddSC(ESkill.CrDefender, EStatusChange.Defender, EStatusChangeIcon.Defender, EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd);
			AddSC(ESkill.CrSpearquicken, EStatusChange.Spearquicken, EStatusChangeIcon.Spearquicken, EStatusCalcFlag.Aspd);
			AddSC(ESkill.MoSteelbody, EStatusChange.Steelbody, EStatusChangeIcon.Steelbody, EStatusCalcFlag.Def | EStatusCalcFlag.Mdef | EStatusCalcFlag.Aspd | EStatusCalcFlag.Speed);
			AddSC(ESkill.MoBladestop, EStatusChange.BladestopWait);
			AddSC(ESkill.MoBladestop, EStatusChange.Bladestop);
			AddSC(ESkill.MoExplosionspirits, EStatusChange.Explosionspirits, EStatusChangeIcon.Explosionspirits, EStatusCalcFlag.Cri | EStatusCalcFlag.Regen);
			AddSC(ESkill.MoExtremityfist, EStatusChange.Extremityfist, EStatusChangeIcon.Blank, EStatusCalcFlag.Regen);
			AddSC(ESkill.SaMagicrod, EStatusChange.Magicrod);
			AddSC(ESkill.SaAutospell, EStatusChange.Autospell, EStatusChangeIcon.Autospell, EStatusCalcFlag.None);
			AddSC(ESkill.SaFlamelauncher, EStatusChange.Fireweapon, EStatusChangeIcon.Fireweapon, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.SaFrostweapon, EStatusChange.Waterweapon, EStatusChangeIcon.Waterweapon, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.SaLightningloader, EStatusChange.Windweapon, EStatusChangeIcon.Windweapon, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.SaSeismicweapon, EStatusChange.Earthweapon, EStatusChangeIcon.Earthweapon, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.SaVolcano, EStatusChange.Volcano, EStatusChangeIcon.Landendow, EStatusCalcFlag.Watk);
			AddSC(ESkill.SaDeluge, EStatusChange.Deluge, EStatusChangeIcon.Landendow, EStatusCalcFlag.Maxhp);
			AddSC(ESkill.SaViolentgale, EStatusChange.Violentgale, EStatusChangeIcon.Landendow, EStatusCalcFlag.Flee);
			AddSC(ESkill.SaReverseorcish, EStatusChange.Orcish);
			AddSC(ESkill.SaComa, EStatusChange.Coma);
			AddSC(ESkill.BdEncore, EStatusChange.Dancing, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed | EStatusCalcFlag.Regen);
			AddSC(ESkill.BdRichmankim, EStatusChange.Richmankim);
			AddSC(ESkill.BdEternalchaos, EStatusChange.Eternalchaos, EStatusChangeIcon.Blank, EStatusCalcFlag.Def2);
			AddSC(ESkill.BdDrumbattlefield, EStatusChange.Drumbattle, EStatusChangeIcon.Blank, EStatusCalcFlag.Watk | EStatusCalcFlag.Def);
			AddSC(ESkill.BdRingnibelungen, EStatusChange.Nibelungen, EStatusChangeIcon.Blank, EStatusCalcFlag.Watk);
			AddSC(ESkill.BdRokisweil, EStatusChange.Rokisweil);
			AddSC(ESkill.BdIntoabyss, EStatusChange.Intoabyss);
			AddSC(ESkill.BdSiegfried, EStatusChange.Siegfried, EStatusChangeIcon.Blank, EStatusCalcFlag.All);
			AddSC(ESkill.BaFrostjoker, EStatusChange.Freeze);
			AddSC(ESkill.BaWhistle, EStatusChange.Whistle, EStatusChangeIcon.Blank, EStatusCalcFlag.Flee | EStatusCalcFlag.Flee2);
			AddSC(ESkill.BaAssassincross, EStatusChange.Assncros, EStatusChangeIcon.Blank, EStatusCalcFlag.Aspd);
			AddSC(ESkill.BaPoembragi, EStatusChange.Poembragi);
			AddSC(ESkill.BaAppleidun, EStatusChange.Appleidun, EStatusChangeIcon.Blank, EStatusCalcFlag.Maxhp);
			AddSC(ESkill.DcScream, EStatusChange.Stun);
			AddSC(ESkill.DcHumming, EStatusChange.Humming, EStatusChangeIcon.Blank, EStatusCalcFlag.Hit);
			AddSC(ESkill.DcDontforgetme, EStatusChange.Dontforgetme, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd);
			AddSC(ESkill.DcFortunekiss, EStatusChange.Fortune, EStatusChangeIcon.Blank, EStatusCalcFlag.Cri);
			AddSC(ESkill.DcServiceforyou, EStatusChange.Service4u, EStatusChangeIcon.Blank, EStatusCalcFlag.All);
			AddSC(ESkill.NpcDarkcross, EStatusChange.Blind);
			AddSC(ESkill.NpcGranddarkness, EStatusChange.Blind);
			AddSC(ESkill.NpcStop, EStatusChange.Stop, EStatusChangeIcon.Stop, EStatusCalcFlag.None);
			AddSC(ESkill.NpcWeaponbraker, EStatusChange.Brokenweapon, EStatusChangeIcon.Brokenweapon, EStatusCalcFlag.None);
			AddSC(ESkill.NpcArmorbrake, EStatusChange.Brokenarmor, EStatusChangeIcon.Brokenarmor, EStatusCalcFlag.None);
			AddSC(ESkill.NpcChangeundead, EStatusChange.Changeundead, EStatusChangeIcon.Undead, EStatusCalcFlag.DefEle);
			AddSC(ESkill.NpcPowerup, EStatusChange.Inchitrate, EStatusChangeIcon.Blank, EStatusCalcFlag.Hit);
			AddSC(ESkill.NpcAgiup, EStatusChange.Incfleerate, EStatusChangeIcon.Blank, EStatusCalcFlag.Flee);
			AddSC(ESkill.NpcInvisible, EStatusChange.Cloaking);
			AddSC(ESkill.LkAurablade, EStatusChange.Aurablade, EStatusChangeIcon.Aurablade, EStatusCalcFlag.None);
			AddSC(ESkill.LkParrying, EStatusChange.Parrying, EStatusChangeIcon.Parrying, EStatusCalcFlag.None);
			AddSC(ESkill.LkConcentration, EStatusChange.Concentration, EStatusChangeIcon.Concentration, EStatusCalcFlag.Batk | EStatusCalcFlag.Watk | EStatusCalcFlag.Hit | EStatusCalcFlag.Def | EStatusCalcFlag.Def2 | EStatusCalcFlag.Mdef | EStatusCalcFlag.Dspd);
			AddSC(ESkill.LkTensionrelax, EStatusChange.Tensionrelax, EStatusChangeIcon.Tensionrelax, EStatusCalcFlag.Regen);
			AddSC(ESkill.LkBerserk, EStatusChange.Berserk, EStatusChangeIcon.Berserk, EStatusCalcFlag.Def | EStatusCalcFlag.Def2 | EStatusCalcFlag.Mdef | EStatusCalcFlag.Mdef2 | EStatusCalcFlag.Flee | EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd | EStatusCalcFlag.Maxhp | EStatusCalcFlag.Regen);
			AddSC(ESkill.HpAssumptio, EStatusChange.Assumptio, EStatusChangeIcon.Assumptio, EStatusCalcFlag.None);
			AddSC(ESkill.HpBasilica, EStatusChange.Basilica);
			AddSC(ESkill.HwMagicpower, EStatusChange.Magicpower, EStatusChangeIcon.Magicpower, EStatusCalcFlag.Matk);
			AddSC(ESkill.PaSacrifice, EStatusChange.Sacrifice);
			AddSC(ESkill.PaGospel, EStatusChange.Gospel, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd);
			AddSC(ESkill.PaGospel, EStatusChange.Scresist);
			AddSC(ESkill.ChTigerfist, EStatusChange.Stop);
			AddSC(ESkill.AscEdp, EStatusChange.Edp, EStatusChangeIcon.Edp, EStatusCalcFlag.None);
			AddSC(ESkill.SnSight, EStatusChange.Truesight, EStatusChangeIcon.Truesight, EStatusCalcFlag.Str | EStatusCalcFlag.Agi | EStatusCalcFlag.Vit | EStatusCalcFlag.Int | EStatusCalcFlag.Dex | EStatusCalcFlag.Luk | EStatusCalcFlag.Cri | EStatusCalcFlag.Hit);
			AddSC(ESkill.SnWindwalk, EStatusChange.Windwalk, EStatusChangeIcon.Windwalk, EStatusCalcFlag.Flee | EStatusCalcFlag.Speed);
			AddSC(ESkill.WsMeltdown, EStatusChange.Meltdown, EStatusChangeIcon.Meltdown, EStatusCalcFlag.None);
			AddSC(ESkill.WsCartboost, EStatusChange.Cartboost, EStatusChangeIcon.Cartboost, EStatusCalcFlag.Speed);
			AddSC(ESkill.StChasewalk, EStatusChange.Chasewalk, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed);
			AddSC(ESkill.StRejectsword, EStatusChange.Rejectsword, EStatusChangeIcon.Rejectsword, EStatusCalcFlag.None);
			AddSC(ESkill.StRejectsword, EStatusChange.Autocounter);
			AddSC(ESkill.CgMarionette, EStatusChange.Marionette, EStatusChangeIcon.Marionette, EStatusCalcFlag.Str | EStatusCalcFlag.Agi | EStatusCalcFlag.Vit | EStatusCalcFlag.Int | EStatusCalcFlag.Dex | EStatusCalcFlag.Luk);
			AddSC(ESkill.CgMarionette, EStatusChange.Marionette2, EStatusChangeIcon.Marionette2, EStatusCalcFlag.Str | EStatusCalcFlag.Agi | EStatusCalcFlag.Vit | EStatusCalcFlag.Int | EStatusCalcFlag.Dex | EStatusCalcFlag.Luk);
			AddSC(ESkill.LkSpiralpierce, EStatusChange.Stop);
			AddSC(ESkill.LkHeadcrush, EStatusChange.Bleeding);
			AddSC(ESkill.LkJointbeat, EStatusChange.Jointbeat, EStatusChangeIcon.Jointbeat, EStatusCalcFlag.Batk | EStatusCalcFlag.Def2 | EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd);
			AddSC(ESkill.HwNapalmvulcan, EStatusChange.Curse);
			AddSC(ESkill.PfMindbreaker, EStatusChange.Mindbreaker, EStatusChangeIcon.Blank, EStatusCalcFlag.Matk | EStatusCalcFlag.Mdef2);
			AddSC(ESkill.PfMemorize, EStatusChange.Memorize);
			AddSC(ESkill.PfFogwall, EStatusChange.Fogwall);
			AddSC(ESkill.PfSpiderweb, EStatusChange.Spiderweb, EStatusChangeIcon.Blank, EStatusCalcFlag.Flee);
			AddSC(ESkill.WeBaby, EStatusChange.Baby, EStatusChangeIcon.Baby, EStatusCalcFlag.None);
			AddSC(ESkill.TkRun, EStatusChange.Run, EStatusChangeIcon.Run, EStatusCalcFlag.Speed | EStatusCalcFlag.Dspd);
			AddSC(ESkill.TkRun, EStatusChange.Spurt, EStatusChangeIcon.Spurt, EStatusCalcFlag.Str);
			AddSC(ESkill.TkReadystorm, EStatusChange.Readystorm, EStatusChangeIcon.Readystorm, EStatusCalcFlag.None);
			AddSC(ESkill.TkReadydown, EStatusChange.Readydown, EStatusChangeIcon.Readydown, EStatusCalcFlag.None);
			AddSC(ESkill.TkDownkick, EStatusChange.Stun);
			AddSC(ESkill.TkReadyturn, EStatusChange.Readyturn, EStatusChangeIcon.Readyturn, EStatusCalcFlag.None);
			AddSC(ESkill.TkReadycounter, EStatusChange.Readycounter, EStatusChangeIcon.Readycounter, EStatusCalcFlag.None);
			AddSC(ESkill.TkDodge, EStatusChange.Dodge, EStatusChangeIcon.Dodge, EStatusCalcFlag.None);
			AddSC(ESkill.TkSptime, EStatusChange.Earthscroll, EStatusChangeIcon.Earthscroll, EStatusCalcFlag.None);
			AddSC(ESkill.TkSevenwind, EStatusChange.Sevenwind);
			AddSC(ESkill.TkSevenwind, EStatusChange.Ghostweapon, EStatusChangeIcon.Ghostweapon, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.TkSevenwind, EStatusChange.Shadowweapon, EStatusChangeIcon.Shadowweapon, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.SgSunWarm, EStatusChange.Warm, EStatusChangeIcon.Warm, EStatusCalcFlag.None);
			AddSC(ESkill.SgMoonWarm, EStatusChange.Warm);
			AddSC(ESkill.SgStarWarm, EStatusChange.Warm);
			AddSC(ESkill.SgSunComfort, EStatusChange.SunComfort, EStatusChangeIcon.SunComfort, EStatusCalcFlag.Def2);
			AddSC(ESkill.SgMoonComfort, EStatusChange.MoonComfort, EStatusChangeIcon.MoonComfort, EStatusCalcFlag.Flee);
			AddSC(ESkill.SgStarComfort, EStatusChange.StarComfort, EStatusChangeIcon.StarComfort, EStatusCalcFlag.Aspd);
			AddSC(ESkill.SgFriend, EStatusChange.SkillrateUp);
			AddSC(ESkill.SgKnowledge, EStatusChange.Knowledge, EStatusChangeIcon.Blank, EStatusCalcFlag.All);
			AddSC(ESkill.SgFusion, EStatusChange.Fusion, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed);
			AddSC(ESkill.BsAdrenaline2, EStatusChange.Adrenaline2, EStatusChangeIcon.Adrenaline2, EStatusCalcFlag.Aspd);
			AddSC(ESkill.SlKaizel, EStatusChange.Kaizel, EStatusChangeIcon.Kaizel, EStatusCalcFlag.None);
			AddSC(ESkill.SlKaahi, EStatusChange.Kaahi, EStatusChangeIcon.Kaahi, EStatusCalcFlag.None);
			AddSC(ESkill.SlKaupe, EStatusChange.Kaupe, EStatusChangeIcon.Kaupe, EStatusCalcFlag.None);
			AddSC(ESkill.SlKaite, EStatusChange.Kaite, EStatusChangeIcon.Kaite, EStatusCalcFlag.None);
			AddSC(ESkill.SlStun, EStatusChange.Stun);
			AddSC(ESkill.SlSwoo, EStatusChange.Swoo, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed);
			AddSC(ESkill.SlSke, EStatusChange.Ske, EStatusChangeIcon.Blank, EStatusCalcFlag.Batk | EStatusCalcFlag.Watk | EStatusCalcFlag.Def | EStatusCalcFlag.Def2);
			AddSC(ESkill.SlSka, EStatusChange.Ska, EStatusChangeIcon.Blank, EStatusCalcFlag.Def | EStatusCalcFlag.Mdef | EStatusCalcFlag.Aspd);
			AddSC(ESkill.SlSma, EStatusChange.Sma, EStatusChangeIcon.Sma, EStatusCalcFlag.None);
			AddSC(ESkill.SmSelfprovoke, EStatusChange.Provoke, EStatusChangeIcon.Provoke, EStatusCalcFlag.Def | EStatusCalcFlag.Def2 | EStatusCalcFlag.Batk | EStatusCalcFlag.Watk);
			AddSC(ESkill.StPreserve, EStatusChange.Preserve, EStatusChangeIcon.Preserve, EStatusCalcFlag.None);
			AddSC(ESkill.PfDoublecasting, EStatusChange.Doublecast, EStatusChangeIcon.Doublecast, EStatusCalcFlag.None);
			AddSC(ESkill.HwGravitation, EStatusChange.Gravitation, EStatusChangeIcon.Blank, EStatusCalcFlag.Aspd);
			AddSC(ESkill.WsCarttermination, EStatusChange.Stun);
			AddSC(ESkill.WsOverthrustmax, EStatusChange.Maxoverthrust, EStatusChangeIcon.Maxoverthrust, EStatusCalcFlag.None);
			AddSC(ESkill.CgLongingfreedom, EStatusChange.Longing, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd);
			AddSC(ESkill.CgHermode, EStatusChange.Hermode);
			AddSC(ESkill.ItemEnchantarms, EStatusChange.Enchantarms, EStatusChangeIcon.Blank, EStatusCalcFlag.AtkEle);
			AddSC(ESkill.SlHigh, EStatusChange.Spirit, EStatusChangeIcon.Spirit, EStatusCalcFlag.All);
			AddSC(ESkill.KnOnehand, EStatusChange.Onehand, EStatusChangeIcon.Onehand, EStatusCalcFlag.Aspd);
			AddSC(ESkill.GsFling, EStatusChange.Fling, EStatusChangeIcon.Blank, EStatusCalcFlag.Def | EStatusCalcFlag.Def2);
			AddSC(ESkill.GsCracker, EStatusChange.Stun);
			AddSC(ESkill.GsDisarm, EStatusChange.Stripweapon);
			AddSC(ESkill.GsPiercingshot, EStatusChange.Bleeding);
			AddSC(ESkill.GsMadnesscancel, EStatusChange.Madnesscancel, EStatusChangeIcon.Madnesscancel, EStatusCalcFlag.Batk | EStatusCalcFlag.Aspd);
			AddSC(ESkill.GsAdjustment, EStatusChange.Adjustment, EStatusChangeIcon.Adjustment, EStatusCalcFlag.Hit | EStatusCalcFlag.Flee);
			AddSC(ESkill.GsIncreasing, EStatusChange.Increasing, EStatusChangeIcon.Accuracy, EStatusCalcFlag.Agi | EStatusCalcFlag.Dex | EStatusCalcFlag.Hit);
			AddSC(ESkill.GsGatlingfever, EStatusChange.Gatlingfever, EStatusChangeIcon.Gatlingfever, EStatusCalcFlag.Batk | EStatusCalcFlag.Flee | EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd);
			AddSC(ESkill.NjTatamigaeshi, EStatusChange.Tatamigaeshi, EStatusChangeIcon.Blank, EStatusCalcFlag.None);
			AddSC(ESkill.NjSuiton, EStatusChange.Suiton, EStatusChangeIcon.Blank, EStatusCalcFlag.Agi | EStatusCalcFlag.Speed);
			AddSC(ESkill.NjHyousyouraku, EStatusChange.Freeze);
			AddSC(ESkill.NjNen, EStatusChange.Nen, EStatusChangeIcon.Nen, EStatusCalcFlag.Str | EStatusCalcFlag.Int);
			AddSC(ESkill.NjUtsusemi, EStatusChange.Utsusemi, EStatusChangeIcon.Utsusemi, EStatusCalcFlag.None);
			AddSC(ESkill.NjBunsinjyutsu, EStatusChange.Bunsinjyutsu, EStatusChangeIcon.Bunsinjyutsu, EStatusCalcFlag.Dye);

			AddSC(ESkill.NpcIcebreath, EStatusChange.Freeze);
			AddSC(ESkill.NpcAcidbreath, EStatusChange.Poison);
			AddSC(ESkill.NpcHelljudgement, EStatusChange.Curse);
			AddSC(ESkill.NpcWidesilence, EStatusChange.Silence);
			AddSC(ESkill.NpcWidefreeze, EStatusChange.Freeze);
			AddSC(ESkill.NpcWidebleeding, EStatusChange.Bleeding);
			AddSC(ESkill.NpcWidestone, EStatusChange.Stone);
			AddSC(ESkill.NpcWideconfuse, EStatusChange.Confusion);
			AddSC(ESkill.NpcWidesleep, EStatusChange.Sleep);
			AddSC(ESkill.NpcWidesight, EStatusChange.Sight);
			AddSC(ESkill.NpcEvilland, EStatusChange.Blind);
			AddSC(ESkill.NpcMagicmirror, EStatusChange.Magicmirror);
			AddSC(ESkill.NpcSlowcast, EStatusChange.Slowcast, EStatusChangeIcon.Slowcast, EStatusCalcFlag.None);
			AddSC(ESkill.NpcCriticalwound, EStatusChange.Criticalwound, EStatusChangeIcon.Criticalwound, EStatusCalcFlag.None);
			AddSC(ESkill.NpcStoneskin, EStatusChange.Armorchange, EStatusChangeIcon.Blank, EStatusCalcFlag.Def | EStatusCalcFlag.Mdef);
			AddSC(ESkill.NpcAntimagic, EStatusChange.Armorchange);
			AddSC(ESkill.NpcWidecurse, EStatusChange.Curse);
			AddSC(ESkill.NpcWidestun, EStatusChange.Stun);

			AddSC(ESkill.NpcHellpower, EStatusChange.Hellpower, EStatusChangeIcon.Hellpower, EStatusCalcFlag.None);
			AddSC(ESkill.NpcWidehelldignity, EStatusChange.Hellpower, EStatusChangeIcon.Hellpower, EStatusCalcFlag.None);
			AddSC(ESkill.NpcInvincible, EStatusChange.Invincible, EStatusChangeIcon.Invincible, EStatusCalcFlag.Speed);
			AddSC(ESkill.NpcInvincibleoff, EStatusChange.Invincibleoff, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed);

			AddSC(ESkill.CashBlessing, EStatusChange.Blessing, EStatusChangeIcon.Blessing, EStatusCalcFlag.Str | EStatusCalcFlag.Int | EStatusCalcFlag.Dex);
			AddSC(ESkill.CashIncagi, EStatusChange.Increaseagi, EStatusChangeIcon.Increaseagi, EStatusCalcFlag.Agi | EStatusCalcFlag.Speed);
			AddSC(ESkill.CashAssumptio, EStatusChange.Assumptio, EStatusChangeIcon.Assumptio, EStatusCalcFlag.None);

			//AddSC(ESkill.AllPartyflee,  EStatusChange.Incflee,  EStatusChangeIcon.Partyflee, EStatusCalcFlag. None);

			AddSC(ESkill.CrShrink, EStatusChange.Shrink, EStatusChangeIcon.Shrink, EStatusCalcFlag.None);
			AddSC(ESkill.RgCloseconfine, EStatusChange.Closeconfine2, EStatusChangeIcon.Closeconfine2, EStatusCalcFlag.None);
			AddSC(ESkill.RgCloseconfine, EStatusChange.Closeconfine, EStatusChangeIcon.Closeconfine, EStatusCalcFlag.Flee);
			AddSC(ESkill.WzSightblaster, EStatusChange.Sightblaster, EStatusChangeIcon.Sightblaster, EStatusCalcFlag.None);
			AddSC(ESkill.DcWinkcharm, EStatusChange.Winkcharm, EStatusChangeIcon.Winkcharm, EStatusCalcFlag.None);
			AddSC(ESkill.MoBalkyoung, EStatusChange.Stun);
			AddSC(ESkill.SaElementwater, EStatusChange.Elementalchange);
			AddSC(ESkill.SaElementfire, EStatusChange.Elementalchange);
			AddSC(ESkill.SaElementground, EStatusChange.Elementalchange);
			AddSC(ESkill.SaElementwind, EStatusChange.Elementalchange);

			AddSC(ESkill.HlifAvoid, EStatusChange.Avoid, EStatusChangeIcon.Blank, EStatusCalcFlag.Speed);
			AddSC(ESkill.HlifChange, EStatusChange.Change, EStatusChangeIcon.Blank, EStatusCalcFlag.Vit | EStatusCalcFlag.Int);
			AddSC(ESkill.HfliFleet, EStatusChange.Fleet, EStatusChangeIcon.Blank, EStatusCalcFlag.Aspd | EStatusCalcFlag.Batk | EStatusCalcFlag.Watk);
			AddSC(ESkill.HfliSpeed, EStatusChange.Speed, EStatusChangeIcon.Blank, EStatusCalcFlag.Flee);
			AddSC(ESkill.HamiDefence, EStatusChange.Defence, EStatusChangeIcon.Blank, EStatusCalcFlag.Def);
			AddSC(ESkill.HamiBloodlust, EStatusChange.Bloodlust, EStatusChangeIcon.Blank, EStatusCalcFlag.Batk | EStatusCalcFlag.Watk);

			AddSC(ESkill.MerCrash, EStatusChange.Stun);
			AddSC(ESkill.MerProvoke, EStatusChange.Provoke, EStatusChangeIcon.Provoke, EStatusCalcFlag.Def | EStatusCalcFlag.Def2 | EStatusCalcFlag.Batk | EStatusCalcFlag.Watk);
			AddSC(ESkill.MsMagnum, EStatusChange.WatkElement);
			AddSC(ESkill.MerSight, EStatusChange.Sight);
			AddSC(ESkill.MerDecagi, EStatusChange.Decreaseagi, EStatusChangeIcon.Decreaseagi, EStatusCalcFlag.Agi | EStatusCalcFlag.Speed);
			AddSC(ESkill.MerMagnificat, EStatusChange.Magnificat, EStatusChangeIcon.Magnificat, EStatusCalcFlag.Regen);
			AddSC(ESkill.MerLexdivina, EStatusChange.Silence);
			AddSC(ESkill.MaLandmine, EStatusChange.Stun);
			AddSC(ESkill.MaSandman, EStatusChange.Sleep);
			AddSC(ESkill.MaFreezingtrap, EStatusChange.Freeze);
			AddSC(ESkill.MerAutoberserk, EStatusChange.Autoberserk, EStatusChangeIcon.Autoberserk, EStatusCalcFlag.None);
			AddSC(ESkill.MlAutoguard, EStatusChange.Autoguard, EStatusChangeIcon.Autoguard, EStatusCalcFlag.None);
			AddSC(ESkill.MsReflectshield, EStatusChange.Reflectshield, EStatusChangeIcon.Reflectshield, EStatusCalcFlag.None);
			AddSC(ESkill.MlDefender, EStatusChange.Defender, EStatusChangeIcon.Defender, EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd);
			AddSC(ESkill.MsParrying, EStatusChange.Parrying, EStatusChangeIcon.Parrying, EStatusCalcFlag.None);
			AddSC(ESkill.MsBerserk, EStatusChange.Berserk, EStatusChangeIcon.Berserk, EStatusCalcFlag.Def | EStatusCalcFlag.Def2 | EStatusCalcFlag.Mdef | EStatusCalcFlag.Mdef2 | EStatusCalcFlag.Flee | EStatusCalcFlag.Speed | EStatusCalcFlag.Aspd | EStatusCalcFlag.Maxhp | EStatusCalcFlag.Regen);
			AddSC(ESkill.MlSpiralpierce, EStatusChange.Stop);
			AddSC(ESkill.MerQuicken, EStatusChange.MercQuicken, EStatusChangeIcon.Blank, EStatusCalcFlag.Aspd);
			AddSC(ESkill.MlDevotion, EStatusChange.Devotion);
			AddSC(ESkill.MerKyrie, EStatusChange.Kyrie, EStatusChangeIcon.Kyrie, EStatusCalcFlag.None);
			AddSC(ESkill.MerBlessing, EStatusChange.Blessing, EStatusChangeIcon.Blessing, EStatusCalcFlag.Str | EStatusCalcFlag.Int | EStatusCalcFlag.Dex);
			AddSC(ESkill.MerIncagi, EStatusChange.Increaseagi, EStatusChangeIcon.Increaseagi, EStatusCalcFlag.Agi | EStatusCalcFlag.Speed);

			AddSC(ESkill.GdLeadership, EStatusChange.Guildaura, EStatusChangeIcon.Blank, EStatusCalcFlag.Str | EStatusCalcFlag.Agi | EStatusCalcFlag.Vit | EStatusCalcFlag.Dex);
			AddSC(ESkill.GdBattleorder, EStatusChange.Battleorders, EStatusChangeIcon.Blank, EStatusCalcFlag.Str | EStatusCalcFlag.Int | EStatusCalcFlag.Dex);
			AddSC(ESkill.GdRegeneration, EStatusChange.Regeneration, EStatusChangeIcon.Blank, EStatusCalcFlag.Regen);


			// Storing the target job rather than simply SC_SPIRIT simplifies code later on
			SkillStatusChangeTable[(int)ESkill.SlAlchemist] = (EStatusChange)EClass.Alchemist;
			SkillStatusChangeTable[(int)ESkill.SlMonk] = (EStatusChange)EClass.Monk;
			SkillStatusChangeTable[(int)ESkill.SlStar] = (EStatusChange)EClass.StarGladiator;
			SkillStatusChangeTable[(int)ESkill.SlSage] = (EStatusChange)EClass.Sage;
			SkillStatusChangeTable[(int)ESkill.SlCrusader] = (EStatusChange)EClass.Crusader;
			SkillStatusChangeTable[(int)ESkill.SlSupernovice] = (EStatusChange)EClass.Super_Novice;
			SkillStatusChangeTable[(int)ESkill.SlKnight] = (EStatusChange)EClass.Knight;
			SkillStatusChangeTable[(int)ESkill.SlWizard] = (EStatusChange)EClass.Wizard;
			SkillStatusChangeTable[(int)ESkill.SlPriest] = (EStatusChange)EClass.Priest;
			SkillStatusChangeTable[(int)ESkill.SlBarddancer] = (EStatusChange)EClass.Barddancer;
			SkillStatusChangeTable[(int)ESkill.SlRogue] = (EStatusChange)EClass.Rogue;
			SkillStatusChangeTable[(int)ESkill.SlAssasin] = (EStatusChange)EClass.Assassin;
			SkillStatusChangeTable[(int)ESkill.SlBlacksmith] = (EStatusChange)EClass.Blacksmith;
			SkillStatusChangeTable[(int)ESkill.SlHunter] = (EStatusChange)EClass.Hunter;
			SkillStatusChangeTable[(int)ESkill.SlSoullinker] = (EStatusChange)EClass.SoulLinker;


			// Status that don't have a skill associated
			StatusIconChangeTable[(int)EStatusChange.Weight50] = EStatusChangeIcon.Weight50;
			StatusIconChangeTable[(int)EStatusChange.Weight90] = EStatusChangeIcon.Weight90;
			StatusIconChangeTable[(int)EStatusChange.Aspdpotion0] = EStatusChangeIcon.Aspdpotion0;
			StatusIconChangeTable[(int)EStatusChange.Aspdpotion1] = EStatusChangeIcon.Aspdpotion1;
			StatusIconChangeTable[(int)EStatusChange.Aspdpotion2] = EStatusChangeIcon.Aspdpotion2;
			StatusIconChangeTable[(int)EStatusChange.Aspdpotion3] = EStatusChangeIcon.Aspdpotioninfinity;
			StatusIconChangeTable[(int)EStatusChange.Speedup0] = EStatusChangeIcon.MovhasteHorse;
			StatusIconChangeTable[(int)EStatusChange.Speedup1] = EStatusChangeIcon.Speedpotion1;
			StatusIconChangeTable[(int)EStatusChange.Incstr] = EStatusChangeIcon.Incstr;
			StatusIconChangeTable[(int)EStatusChange.Miracle] = EStatusChangeIcon.Spirit;
			StatusIconChangeTable[(int)EStatusChange.Intravision] = EStatusChangeIcon.Intravision;
			StatusIconChangeTable[(int)EStatusChange.Strfood] = EStatusChangeIcon.Foodstr;
			StatusIconChangeTable[(int)EStatusChange.Agifood] = EStatusChangeIcon.Foodagi;
			StatusIconChangeTable[(int)EStatusChange.Vitfood] = EStatusChangeIcon.Foodvit;
			StatusIconChangeTable[(int)EStatusChange.Intfood] = EStatusChangeIcon.Foodint;
			StatusIconChangeTable[(int)EStatusChange.Dexfood] = EStatusChangeIcon.Fooddex;
			StatusIconChangeTable[(int)EStatusChange.Lukfood] = EStatusChangeIcon.Foodluk;
			StatusIconChangeTable[(int)EStatusChange.Fleefood] = EStatusChangeIcon.Foodflee;
			StatusIconChangeTable[(int)EStatusChange.Hitfood] = EStatusChangeIcon.Foodhit;
			StatusIconChangeTable[(int)EStatusChange.ManuAtk] = EStatusChangeIcon.ManuAtk;
			StatusIconChangeTable[(int)EStatusChange.ManuDef] = EStatusChangeIcon.ManuDef;
			StatusIconChangeTable[(int)EStatusChange.SplAtk] = EStatusChangeIcon.SplAtk;
			StatusIconChangeTable[(int)EStatusChange.SplDef] = EStatusChangeIcon.SplDef;
			StatusIconChangeTable[(int)EStatusChange.ManuMatk] = EStatusChangeIcon.ManuMatk;
			StatusIconChangeTable[(int)EStatusChange.SplMatk] = EStatusChangeIcon.SplMatk;

			// Cash items
			StatusIconChangeTable[(int)EStatusChange.FoodStrCash] = EStatusChangeIcon.FoodStrCash;
			StatusIconChangeTable[(int)EStatusChange.FoodAgiCash] = EStatusChangeIcon.FoodAgiCash;
			StatusIconChangeTable[(int)EStatusChange.FoodVitCash] = EStatusChangeIcon.FoodVitCash;
			StatusIconChangeTable[(int)EStatusChange.FoodDexCash] = EStatusChangeIcon.FoodDexCash;
			StatusIconChangeTable[(int)EStatusChange.FoodIntCash] = EStatusChangeIcon.FoodIntCash;
			StatusIconChangeTable[(int)EStatusChange.FoodLukCash] = EStatusChangeIcon.FoodLukCash;
			StatusIconChangeTable[(int)EStatusChange.Expboost] = EStatusChangeIcon.Expboost;
			StatusIconChangeTable[(int)EStatusChange.Itemboost] = EStatusChangeIcon.Itemboost;
			StatusIconChangeTable[(int)EStatusChange.Jexpboost] = EStatusChangeIcon.CashPlusonlyjobexp;
			StatusIconChangeTable[(int)EStatusChange.Lifeinsurance] = EStatusChangeIcon.Lifeinsurance;
			StatusIconChangeTable[(int)EStatusChange.Bossmapinfo] = EStatusChangeIcon.Bossmapinfo;
			StatusIconChangeTable[(int)EStatusChange.DefRate] = EStatusChangeIcon.DefRate;
			StatusIconChangeTable[(int)EStatusChange.MdefRate] = EStatusChangeIcon.MdefRate;
			StatusIconChangeTable[(int)EStatusChange.Inccri] = EStatusChangeIcon.Inccri;
			StatusIconChangeTable[(int)EStatusChange.Incflee2] = EStatusChangeIcon.Plusavoidvalue;
			StatusIconChangeTable[(int)EStatusChange.Inchealrate] = EStatusChangeIcon.Inchealrate;
			StatusIconChangeTable[(int)EStatusChange.SLifepotion] = EStatusChangeIcon.SLifepotion;
			StatusIconChangeTable[(int)EStatusChange.LLifepotion] = EStatusChangeIcon.LLifepotion;
			StatusIconChangeTable[(int)EStatusChange.SpcostRate] = EStatusChangeIcon.AtkerBlood;
			StatusIconChangeTable[(int)EStatusChange.CommonscResist] = EStatusChangeIcon.TargetBlood;

			// Mercenary bonus
			StatusIconChangeTable[(int)EStatusChange.MercFleeup] = EStatusChangeIcon.MercFleeup;
			StatusIconChangeTable[(int)EStatusChange.MercAtkup] = EStatusChangeIcon.MercAtkup;
			StatusIconChangeTable[(int)EStatusChange.MercHpup] = EStatusChangeIcon.MercHpup;
			StatusIconChangeTable[(int)EStatusChange.MercSpup] = EStatusChangeIcon.MercSpup;
			StatusIconChangeTable[(int)EStatusChange.MercHitup] = EStatusChangeIcon.MercHitup;

			// Other SC which are not necessarily associated to skills
			StatusChangeFlagTable[(int)EStatusChange.Aspdpotion0] = EStatusCalcFlag.Aspd;
			StatusChangeFlagTable[(int)EStatusChange.Aspdpotion1] = EStatusCalcFlag.Aspd;
			StatusChangeFlagTable[(int)EStatusChange.Aspdpotion2] = EStatusCalcFlag.Aspd;
			StatusChangeFlagTable[(int)EStatusChange.Aspdpotion3] = EStatusCalcFlag.Aspd;
			StatusChangeFlagTable[(int)EStatusChange.Speedup0] = EStatusCalcFlag.Speed;
			StatusChangeFlagTable[(int)EStatusChange.Speedup1] = EStatusCalcFlag.Speed;
			StatusChangeFlagTable[(int)EStatusChange.Atkpotion] = EStatusCalcFlag.Batk;
			StatusChangeFlagTable[(int)EStatusChange.Matkpotion] = EStatusCalcFlag.Matk;
			StatusChangeFlagTable[(int)EStatusChange.Incallstatus] |= EStatusCalcFlag.Str | EStatusCalcFlag.Agi | EStatusCalcFlag.Vit | EStatusCalcFlag.Int | EStatusCalcFlag.Dex | EStatusCalcFlag.Luk;
			StatusChangeFlagTable[(int)EStatusChange.Incstr] |= EStatusCalcFlag.Str;
			StatusChangeFlagTable[(int)EStatusChange.Incagi] |= EStatusCalcFlag.Agi;
			StatusChangeFlagTable[(int)EStatusChange.Incvit] |= EStatusCalcFlag.Vit;
			StatusChangeFlagTable[(int)EStatusChange.Incint] |= EStatusCalcFlag.Int;
			StatusChangeFlagTable[(int)EStatusChange.Incdex] |= EStatusCalcFlag.Dex;
			StatusChangeFlagTable[(int)EStatusChange.Incluk] |= EStatusCalcFlag.Luk;
			StatusChangeFlagTable[(int)EStatusChange.Inchit] |= EStatusCalcFlag.Hit;
			StatusChangeFlagTable[(int)EStatusChange.Inchitrate] |= EStatusCalcFlag.Hit;
			StatusChangeFlagTable[(int)EStatusChange.Incflee] |= EStatusCalcFlag.Flee;
			StatusChangeFlagTable[(int)EStatusChange.Incfleerate] |= EStatusCalcFlag.Flee;
			StatusChangeFlagTable[(int)EStatusChange.Inccri] |= EStatusCalcFlag.Cri;
			StatusChangeFlagTable[(int)EStatusChange.Incflee2] |= EStatusCalcFlag.Flee2;
			StatusChangeFlagTable[(int)EStatusChange.Incmhprate] |= EStatusCalcFlag.Maxhp;
			StatusChangeFlagTable[(int)EStatusChange.Incmsprate] |= EStatusCalcFlag.Maxsp;
			StatusChangeFlagTable[(int)EStatusChange.Incatkrate] |= EStatusCalcFlag.Batk | EStatusCalcFlag.Watk;
			StatusChangeFlagTable[(int)EStatusChange.Incmatkrate] |= EStatusCalcFlag.Matk;
			StatusChangeFlagTable[(int)EStatusChange.Incdefrate] |= EStatusCalcFlag.Def;
			StatusChangeFlagTable[(int)EStatusChange.Strfood] |= EStatusCalcFlag.Str;
			StatusChangeFlagTable[(int)EStatusChange.Agifood] |= EStatusCalcFlag.Agi;
			StatusChangeFlagTable[(int)EStatusChange.Vitfood] |= EStatusCalcFlag.Vit;
			StatusChangeFlagTable[(int)EStatusChange.Intfood] |= EStatusCalcFlag.Int;
			StatusChangeFlagTable[(int)EStatusChange.Dexfood] |= EStatusCalcFlag.Dex;
			StatusChangeFlagTable[(int)EStatusChange.Lukfood] |= EStatusCalcFlag.Luk;
			StatusChangeFlagTable[(int)EStatusChange.Hitfood] |= EStatusCalcFlag.Hit;
			StatusChangeFlagTable[(int)EStatusChange.Fleefood] |= EStatusCalcFlag.Flee;
			StatusChangeFlagTable[(int)EStatusChange.Batkfood] |= EStatusCalcFlag.Batk;
			StatusChangeFlagTable[(int)EStatusChange.Watkfood] |= EStatusCalcFlag.Watk;
			StatusChangeFlagTable[(int)EStatusChange.Matkfood] |= EStatusCalcFlag.Matk;
			StatusChangeFlagTable[(int)EStatusChange.ArmorElement] |= EStatusCalcFlag.All;
			StatusChangeFlagTable[(int)EStatusChange.ArmorResist] |= EStatusCalcFlag.All;
			StatusChangeFlagTable[(int)EStatusChange.SpcostRate] |= EStatusCalcFlag.All;
			StatusChangeFlagTable[(int)EStatusChange.Walkspeed] |= EStatusCalcFlag.Speed;
			StatusChangeFlagTable[(int)EStatusChange.Itemscript] |= EStatusCalcFlag.All;
			// Cash items
			StatusChangeFlagTable[(int)EStatusChange.FoodStrCash] = EStatusCalcFlag.Str;
			StatusChangeFlagTable[(int)EStatusChange.FoodAgiCash] = EStatusCalcFlag.Agi;
			StatusChangeFlagTable[(int)EStatusChange.FoodVitCash] = EStatusCalcFlag.Vit;
			StatusChangeFlagTable[(int)EStatusChange.FoodDexCash] = EStatusCalcFlag.Dex;
			StatusChangeFlagTable[(int)EStatusChange.FoodIntCash] = EStatusCalcFlag.Int;
			StatusChangeFlagTable[(int)EStatusChange.FoodLukCash] = EStatusCalcFlag.Luk;
			// Mercenary bonus
			StatusChangeFlagTable[(int)EStatusChange.MercFleeup] |= EStatusCalcFlag.Flee;
			StatusChangeFlagTable[(int)EStatusChange.MercAtkup] |= EStatusCalcFlag.Watk;
			StatusChangeFlagTable[(int)EStatusChange.MercHpup] |= EStatusCalcFlag.Maxhp;
			StatusChangeFlagTable[(int)EStatusChange.MercSpup] |= EStatusCalcFlag.Maxsp;
			StatusChangeFlagTable[(int)EStatusChange.MercHitup] |= EStatusCalcFlag.Hit;

			if (Config.DisplayHallucination == false) {
				StatusIconChangeTable[(int)EStatusChange.Hallucination] = EStatusChangeIcon.Blank;
			}
		}

		private static void AddSC(ESkill sk, EStatusChange sc, EStatusChangeIcon icon, EStatusCalcFlag flag) {
			// Indices for array access
			int isc = (int)sc;
			int isk = (int)sk;

			if (StatusSkillChangeTable[isc] == 0) {
				StatusSkillChangeTable[isc] = sk;
			}

			if (StatusIconChangeTable[isc] == EStatusChangeIcon.Blank) {
				StatusIconChangeTable[isc] = icon;
			}

			StatusChangeFlagTable[isc] |= flag;

			if (SkillStatusChangeTable[isk] == EStatusChange.None) {
				SkillStatusChangeTable[isk] = sc;
			}
		}

		private static void AddSC(ESkill sk, EStatusChange sc) {
			AddSC(sk, sc, EStatusChangeIcon.Blank, EStatusCalcFlag.None);
		}
		#endregion



		/// <summary>
		/// Clone-like copys all values
		/// </summary>
		/// <param name="status"></param>
		public void LoadFromStatus(WorldObjectStatus status) {
			LoadFromStatus(status, true);
		}

		/// <summary>
		/// Clone-like copys all values
		/// </summary>
		/// <param name="status"></param>
		public void LoadFromStatus(WorldObjectStatus status, bool includeHP) {
			// TODO: confirm this.. i think this is the way how status_cpy() works
			if (includeHP == true) {
				HP = status.HP;
				SP = status.SP;
			}
			HPMax = status.HPMax;
			SPMax = status.SPMax;
			Str = status.Str;
			Agi = status.Agi;
			Vit = status.Vit;
			Int = status.Int;
			Dex = status.Dex;
			Luk = status.Luk;
			AtkBase = status.AtkBase;
			MagicAtkMin = status.MagicAtkMin;
			MagicAtkMax = status.MagicAtkMax;
			Speed = status.Speed;
			AMotion = status.AMotion;
			ADelay = status.ADelay;
			DMotion = status.DMotion;
			Mode = status.Mode;
			Hit = status.Hit;
			Flee = status.Flee;
			Flee2 = status.Flee2;
			Crit = status.Crit;
			Def2 = status.Def2;
			MDef2 = status.MDef2;
			AspdRate = status.AspdRate;
			DefEle = status.DefEle;
			EleLv = status.EleLv;
			Size = status.Size;
			Race = status.Race;
			Def = status.Def;
			MDef = status.MDef;
			Rhw = status.Rhw;
			Lhw = status.Lhw;
		}


		public void CalculateMonster(bool first) {
			Calculate(EStatusCalcFlag.All, first);
		}

		public void CalculatePet(bool first) {
			Calculate(EStatusCalcFlag.All, first);
		}

		public void CalculateCharacter(bool first) {
			Calculate(EStatusCalcFlag.All, first);
		}

		public void CalculateHomunculus(bool first) {
			Calculate(EStatusCalcFlag.All, first);
		}

		public void CalculateMercenary(bool first) {
			Calculate(EStatusCalcFlag.All, first);
		}

		/// <summary>
		/// Recalculates parts of an object's base status and battle status according to the specified flags
		/// Also sends updates to the client wherever applicable
		/// </summary>
		/// <param name="flag"></param>
		/// <param name="first"></param>
		public void Calculate(EStatusCalcFlag flag, bool first) {
			WorldObjectStatus prevStatus = (WorldObjectStatus)WorldObject.GetStatusData(Object).Clone();

			// Calc base status
			if ((flag & EStatusCalcFlag.Base) > 0) {
				switch (Object.WorldID.Type) {
					case EDatabaseType.Mob:
						CalculateMob_(first);
						break;
					case EDatabaseType.Char:
						CalculateChar_(first);
						break;
					case EDatabaseType.Pet:
						CalculatePet_(first);
						break;
					case EDatabaseType.Homunculus:
						CalculateHom_(first);
						break;
					case EDatabaseType.Mercenary:
						CalculateMerc_(first);
						break;
				}
			}

			if (Object.WorldID.Type == EDatabaseType.Pet) {
				return;
			}
			if (first == true && Object.WorldID.Type == EDatabaseType.Mob) {
				return;
			}

			CalculateMain(flag);

			if (first == true && Object.WorldID.Type == EDatabaseType.Homunculus) {
				return;
			}

			// compare against new values and send client updates
			WorldObjectStatus status = WorldObject.GetStatusData(Object);

			if (Object.WorldID.Type == EDatabaseType.Char) {
				// updatestatus bla..
			} else if (Object.WorldID.Type == EDatabaseType.Homunculus) {

			} else if (Object.WorldID.Type == EDatabaseType.Mercenary) {

			}

		}

		/// <summary>
		/// Recalculates parts of an object's battle status according to the specified flags
		/// </summary>
		/// <param name="flag"></param>
		public void CalculateMain(EStatusCalcFlag flag) {
			WorldObjectStatus b_status = WorldObject.GetBaseStatusData(Object);
			WorldObjectStatus status = WorldObject.GetStatusData(Object);
			WorldObjectStatusChangeList sc = WorldObject.GetStatusChange(Object);
			Character character = (Object as Character);
			int temp;

			if (b_status == null || status == null) {
				return;
			}
			if (!Object.Type.And(EDatabaseType.Regeneration) && (sc == null || sc.Count == 0)) { //No difference.
				status.LoadFromStatus(b_status);
				return;
			}

			if ((flag & EStatusCalcFlag.Str) > 0) {
				status.Str = CalculateStr(sc, b_status.Str);
				flag |= EStatusCalcFlag.Batk;
				if (Object.Type.And(EDatabaseType.Homunculus)) {
					flag |= EStatusCalcFlag.Watk;
				}
			}

			if ((flag & EStatusCalcFlag.Agi) > 0) {
				status.Agi = CalculateAgi(sc, b_status.Agi);
				flag |= EStatusCalcFlag.Flee;
				if (Object.Type.And(EDatabaseType.Char | EDatabaseType.Homunculus)) {
					flag |= EStatusCalcFlag.Aspd | EStatusCalcFlag.Dspd;
				}
			}

			if ((flag & EStatusCalcFlag.Vit) > 0) {
				status.Vit = CalculateVit(sc, b_status.Vit);
				flag |= EStatusCalcFlag.Def2 | EStatusCalcFlag.Mdef2;
				if (Object.Type.And(EDatabaseType.Char | EDatabaseType.Homunculus | EDatabaseType.Mercenary)) {
					flag |= EStatusCalcFlag.Maxhp;
				}
				if (Object.Type.And(EDatabaseType.Homunculus)) {
					flag |= EStatusCalcFlag.Def;
				}
			}

			if ((flag & EStatusCalcFlag.Int) > 0) {
				status.Int = CalculateInt(sc, b_status.Int);
				flag |= EStatusCalcFlag.Matk | EStatusCalcFlag.Mdef2;
				if (Object.Type.And(EDatabaseType.Char | EDatabaseType.Homunculus | EDatabaseType.Mercenary)) {
					flag |= EStatusCalcFlag.Maxsp;
				}
				if (Object.Type.And(EDatabaseType.Homunculus)) {
					flag |= EStatusCalcFlag.Mdef;
				}
			}

			if ((flag & EStatusCalcFlag.Dex) > 0) {
				status.Dex = CalculateDex(sc, b_status.Dex);
				flag |= EStatusCalcFlag.Batk | EStatusCalcFlag.Hit;
				if (Object.Type.And(EDatabaseType.Char | EDatabaseType.Homunculus)) {
					flag |= EStatusCalcFlag.Aspd;
				}
				if (Object.Type.And(EDatabaseType.Homunculus)) {
					flag |= EStatusCalcFlag.Watk;
				}
			}

			if ((flag & EStatusCalcFlag.Luk) > 0) {
				status.Luk = CalculateLuk(sc, b_status.Luk);
				flag |= EStatusCalcFlag.Batk | EStatusCalcFlag.Cri | EStatusCalcFlag.Flee2;
			}


			if ((flag & EStatusCalcFlag.Batk) > 0 && b_status.AtkBase > 0) {
				status.AtkBase = CalculateBaseAtk(status);
				temp = b_status.AtkBase - CalculateBaseAtk(b_status);
				if (temp > 0) {
					status.AtkBase += (ushort)temp;
				}
				status.AtkBase = CalculateBatk(sc, status.AtkBase);
			}


			if ((flag & EStatusCalcFlag.Watk) > 0) {
				// TODO: is null, need to implement character status full first..
				/*
				status.Rhw.AtkMin = CalculateWatk(sc, b_status.Rhw.AtkMin);
				// Should not affect weapon refine bonus
				if (character == null) {
					status.Rhw.AtkMax = CalculateWatk(sc, b_status.Rhw.AtkMax);
				}

				if (b_status.Lhw.AtkMin > 0 || b_status.Lhw.AtkMax > 0) {
					if (character != null) {
						character.State.LrFlag = true;
						status.Lhw.AtkMin = CalculateWatk(sc, b_status.Lhw.AtkMin);
						character.State.LrFlag = false;
					} else {
						status.Lhw.AtkMin = CalculateWatk(sc, b_status.Lhw.AtkMin);
						status.Lhw.AtkMax = CalculateWatk(sc, b_status.Lhw.AtkMax);
					}
				}

				if (Object.Type.And(EDatabaseType.Homunculus) == true) {
					status.Rhw.AtkMin += (ushort)(status.Dex - b_status.Dex);
					status.Rhw.AtkMax += (ushort)(status.Str - b_status.Str);
					if (b_status.Rhw.AtkMax < b_status.Rhw.AtkMin) {
						b_status.Rhw.AtkMax = b_status.Rhw.AtkMin;
					}
				}
				*/
			}

			if ((flag & EStatusCalcFlag.Hit) > 0) {
				if (status.Dex == b_status.Dex) {
					status.Hit = CalculateHit(sc, b_status.Hit);
				} else {
					status.Hit = CalculateHit(sc, (short)(b_status.Hit + (status.Dex - b_status.Dex)));
				}
			}

			if ((flag & EStatusCalcFlag.Flee) > 0) {
				if (status.Agi == b_status.Agi) {
					status.Flee = CalculateFlee(sc, b_status.Flee);
				} else {
					status.Flee = CalculateFlee(sc, (short)(b_status.Flee + (status.Agi - b_status.Agi)));
				}
			}

			if ((flag & EStatusCalcFlag.Def) > 0) {
				status.Def = CalculateDef(sc, b_status.Def);
				if (Object.Type.And(EDatabaseType.Homunculus) == true) {
					status.Def += (byte)(status.Vit / 5 - b_status.Vit / 5);
				}
			}

			if ((flag & EStatusCalcFlag.Def2) > 0) {
				if (status.Vit == b_status.Vit) {
					status.Def2 = CalculateDef2(sc, b_status.Def2);
				} else {
					status.Def2 = CalculateDef2(sc, (short)(b_status.Def2 + (status.Vit - b_status.Vit)));
				}
			}

			if ((flag & EStatusCalcFlag.Mdef) > 0) {
				status.MDef = CalculateMdef(sc, b_status.MDef);
				if (Object.Type.And(EDatabaseType.Homunculus) == true) {
					status.MDef += (byte)(status.Int / 5 - b_status.Int / 5);
				}
			}

			if ((flag & EStatusCalcFlag.Mdef2) > 0) {
				if (status.Int == b_status.Int) {
					status.MDef2 = CalculateMdef2(sc, b_status.MDef2);
				} else {
					status.MDef2 = CalculateMdef2(sc, (short)(b_status.MDef2 + (status.Int - b_status.Int) + ((status.Vit - b_status.Vit) >> 1)));
				}
			}

			if ((flag & EStatusCalcFlag.Speed) > 0) {
				WorldObjectUnit ud = (Object as WorldObjectUnit);
				status.Speed = CalculateSpeed(sc, b_status.Speed);

				// Re-walk to adjust speed (we do not check if walktimer != INVALID_TIMER
				// because if you step on something while walking, the moment this
				// piece of code triggers the walk-timer is set on INVALID_TIMER) 
				if (ud != null) {
					ud.UState.ChangeWalkTarget = ud.UState.SpeedChanged = true;
				}

				if (Object.Type.And(EDatabaseType.Char) && status.Speed < (ushort)Global.MAX_WALK_SPEED)
					status.Speed = (ushort)Global.MAX_WALK_SPEED;

				// TODO: need the config
				//if( bl->type&BL_HOM && battle_config.hom_setting&0x8 && ((TBL_HOM*)bl)->master)
				//	status->speed = status_get_speed(&((TBL_HOM*)bl)->master->bl);


			}

			if ((flag & EStatusCalcFlag.Cri) > 0 && status.Crit > 0) {
				if (status.Luk == b_status.Luk) {
					status.Crit = CalculateCrit(sc, b_status.Crit);
				} else {
					status.Crit = CalculateCrit(sc, (short)(b_status.Crit + 3 * (status.Luk - b_status.Luk)));
				}
			}

			if ((flag & EStatusCalcFlag.Flee2) > 0 && status.Flee2 > 0) {
				if (status.Luk == b_status.Luk) {
					status.Flee2 = CalculateFlee2(sc, b_status.Flee2);
				} else {
					status.Flee2 = CalculateFlee2(sc, (short)(b_status.Flee2 + (status.Luk - b_status.Luk)));
				}
			}

			if ((flag & EStatusCalcFlag.AtkEle) > 0) {
				// TODO: same as atk..
				/*
				status.Rhw.Element = CalculateElement(sc, b_status.Lhw.Element);
				if (character != null) {
					character.State.LrFlag = true;
				}
				status.Lhw.Element = CalculateElement(sc, b_status.Lhw.Element);
				if (character != null) {
					character.State.LrFlag = false;
				}
				*/
			}

			if ((flag & EStatusCalcFlag.DefEle) > 0) {
				status.DefEle = CalculateElement(sc, b_status.DefEle);
				status.EleLv = CalculateElementLevel(sc, b_status.EleLv);
			}

			if ((flag & EStatusCalcFlag.Mode) > 0) {
				status.Mode = CalculateMode(sc, b_status.Mode);
				// Since mode changed, reset their state.
				if (!((status.Mode & EMonsterMode.CanAttack) > 0)) {
					(Object as WorldObjectUnit).StopAttack();
				}
				if (!((status.Mode & EMonsterMode.CanMove) > 0)) {
					(Object as WorldObjectUnit).StopWalking(0);
				}
			}

			// No status changes alter these yet

			if ((flag & EStatusCalcFlag.Maxhp) > 0) {
				if (character != null) {
					status.HPMax = CalculateBasePcMaxHP(character, status);
					status.HPMax += (uint)(b_status.HPMax - character.Status.HPMax);

					status.HPMax = CalculateMaxHP(sc, status.HPMax);
				} else {
					status.HPMax = CalculateMaxHP(sc, b_status.HPMax);
				}

				// FIXME: Should perhaps a status_zap should be issued?
				if (status.HP > status.HPMax) {
					status.HP = status.HPMax;
					if (character != null) {
						character.Account.Netstate.Send(new Network.Packets.WorldUpdateStatus(character, EStatusParam.Hp));
					}
				}
			}

			if ((flag & EStatusCalcFlag.Maxhp) > 0) {
				if (character != null) {
					status.SPMax = CalculateBasePcMaxSP(character, status);
					status.SPMax += (uint)(b_status.SPMax - character.Status.SPMax);

					status.SPMax = CalculateMaxSP(sc, status.SPMax);
				} else {
					status.SPMax = CalculateMaxSP(sc, b_status.SPMax);
				}

				// FIXME: Should perhaps a status_zap should be issued?
				if (status.SP > status.SPMax) {
					status.SP = status.SPMax;
					if (character != null) {
						character.Account.Netstate.Send(new Network.Packets.WorldUpdateStatus(character, EStatusParam.Sp));
					}
				}
			}


			if ((flag & EStatusCalcFlag.Matk) > 0) {
				// New matk
				status.MagicAtkMin = CalculateBaseMatkMin(status);
				status.MagicAtkMax = CalculateBaseMatkMax(status);

				if (character != null && character.MatkRate != 100) {
					// Bonuses from previous matk
					status.MagicAtkMin = (ushort)(status.MagicAtkMin * character.MatkRate / 100);
					status.MagicAtkMax = (ushort)(status.MagicAtkMax * character.MatkRate / 100);
				}

				status.MagicAtkMin = CalculateMatk(sc, status.MagicAtkMin);
				status.MagicAtkMax = CalculateMatk(sc, status.MagicAtkMax);

				// Store current matk values
				if (sc[EStatusChange.Magicpower] != null) {
					sc.MpMatkMin = status.MagicAtkMin;
					sc.MpMatkMax = status.MagicAtkMax;
				}

				// TODO homu object
				// Hom Min Matk is always the same as Max Matk
				//if (Object.Type.And(EDatabaseType.Homunculus) &&
				//if( bl->type&BL_HOM && battle_config.hom_setting&0x20 ) 
				//	status->matk_min = status->matk_max;

			}

			if ((flag & EStatusCalcFlag.Aspd) > 0) {
				ushort amotion;
				if (character != null) {
					amotion = CalculateBaseAmotion(status);
					status.AspdRate = CalculateAspdRate(sc, b_status.AspdRate);

					if (status.AspdRate != 1000)
						amotion = (ushort)(amotion * status.AspdRate / 1000);

					status.AMotion = amotion.CapValue((ushort)Config.MaxAspd, (ushort)2000);
					status.ADelay = (ushort)(2 * status.AMotion);
				} else if (Object.Type.And(EDatabaseType.Homunculus) == true) {
					// TODO: homu object
					//amotion = (1000 - 4 * status.Agi - status.Dex) * (Object as Homunculus).BaseAspd / 1000;
					amotion = 500;
					status.AspdRate = CalculateAspdRate(sc, b_status.AspdRate);

					if (status.AspdRate != 1000) {
						amotion = (ushort)(amotion * status.AspdRate / 1000);
					}

					status.AMotion = amotion.CapValue((ushort)Config.MaxAspd, (ushort)2000);
					status.ADelay = status.AMotion;
				} else {
					// mercenary and mobs
					amotion = b_status.AMotion;
					status.AspdRate = CalculateAspdRate(sc, b_status.AspdRate);

					if (status.AspdRate != 1000) {
						amotion = (ushort)(amotion * status.AspdRate / 1000);
					}

					status.AMotion = amotion.CapValue((ushort)Config.MaxAspd, (ushort)2000);

					temp = b_status.ADelay * status.AspdRate / 1000;
					status.AMotion = ((ushort)temp).CapValue((ushort)Config.MaxAspd, (ushort)4000);
				}
			}

			if ((flag & EStatusCalcFlag.Dspd) > 0) {
				ushort dmotion;
				if (character != null) {
					if (b_status.Agi == status.Agi) {
						status.DMotion = CalculateDmotion(sc, b_status.DMotion);
					} else {
						dmotion = (ushort)(800 - status.Agi * 4);
						status.DMotion = dmotion.CapValue(400, 800);
						// It's safe to ignore b_status->dmotion since no bonus affects it.
						status.DMotion = CalculateDmotion(sc, status.DMotion);
					}
				} else if (Object.Type.And(EDatabaseType.Homunculus) == true) {
					dmotion = (ushort)(800 - status.Agi * 4);
					status.DMotion = dmotion.CapValue(400, 800);
					status.DMotion = CalculateDmotion(sc, b_status.DMotion);
				} else {
					// mercenary and mobs
					status.DMotion = CalculateDmotion(sc, b_status.DMotion);
				}
			}

			EStatusCalcFlag regenFlags = (EStatusCalcFlag.Vit | EStatusCalcFlag.Maxhp | EStatusCalcFlag.Int | EStatusCalcFlag.Maxsp);
			if ((flag & regenFlags) > 0 && Object.Type.And(EDatabaseType.Regeneration) == true) {
				CalculateRegenData(status, WorldObject.GetRegenData(Object));
			}

			if ((flag & EStatusCalcFlag.Regen) > 0 && Object.Type.And(EDatabaseType.Regeneration) == true) {
				CalculateRegenRate(WorldObject.GetRegenData(Object), sc);
			}

		}

		/// <summary>
		/// Fills in the misc data that can be calculated from the other status info (except for level)
		/// </summary>
		public void CalculateMisc(int level) {
			// Non players get the value set, players need to stack with previous bonuses
			if (Object.Type != EDatabaseType.Char) {
				AtkBase = 0;
				Hit = Flee =
				Def2 = MDef2 =
				Crit = Flee2 = 0;
			}

			MagicAtkMin = CalcBaseMagicAtkMin();
			MagicAtkMax = CalcBaseMagicAtkMax();

			// TODO: need cap_value()?
			Hit += (short)(level + Dex);
			Flee += (short)(level + Agi);
			Def2 += (short)(Vit);
			MDef2 += (short)(Int + (Vit >> 1));
			Crit += (short)(Luk * 3 + 10);
			Flee2 += (short)(Luk + 10);

			AtkBase += CalcBaseAtk();

			if (Crit > 0) {
				switch (Object.Type) {
					case EDatabaseType.Mob:
						// TODO: more configs >.<
						//		 - configs are done now, implement me!
						break;
					case EDatabaseType.Char:
						// Players don't have a critical adjustment setting as of yet
						break;
					default:
						break;
				}
			}

			if ((Object.Type & EDatabaseType.Regeneration) > 0) {
				if ((Object.Type & EDatabaseType.Mob) > 0) {
					(Object as Monster).Regen.Calculate();
				}
				// else if character, pet, ...
			}

		}


		private EMonsterMode CalculateMode(WorldObjectStatusChangeList sc, EMonsterMode mode) {
			return mode;
		}

		private uint CalculateBasePcMaxHP(Character character, WorldObjectStatus status) {
			return 0;
		}

		private uint CalculateBasePcMaxSP(Character character, WorldObjectStatus status) {
			return 0;
		}


		private EElement CalculateElement(WorldObjectStatusChangeList sc, EElement ele) {
			return ele;
		}

		private byte CalculateElementLevel(WorldObjectStatusChangeList sc, byte eleLevel) {
			return eleLevel;
		}

		private uint CalculateMaxHP(WorldObjectStatusChangeList sc, uint maxHP) {
			return maxHP;
		}

		private uint CalculateMaxSP(WorldObjectStatusChangeList sc, uint maxSP) {
			return maxSP;
		}

		private ushort CalculateBaseMatkMin(WorldObjectStatus status) {
			return 0;
		}

		private ushort CalculateBaseMatkMax(WorldObjectStatus status) {
			return 0;
		}

		private ushort CalculateMatk(WorldObjectStatusChangeList sc, ushort matk) {
			return matk;
		}

		private ushort CalculateBaseAmotion(WorldObjectStatus status) {
			return 0;
		}

		private short CalculateAspdRate(WorldObjectStatusChangeList sc, short aspdRate) {
			return aspdRate;
		}

		private ushort CalculateDmotion(WorldObjectStatusChangeList sc, ushort dmotion) {
			return dmotion;
		}

		private short CalculateFlee2(WorldObjectStatusChangeList sc, short flee2) {
			return flee2;
		}

		private short CalculateCrit(WorldObjectStatusChangeList sc, short crit) {
			return crit;
		}

		private ushort CalculateSpeed(WorldObjectStatusChangeList sc, ushort speed) {
			return speed;
		}

		private short CalculateMdef2(WorldObjectStatusChangeList sc, short mdef2) {
			return mdef2;
		}

		private byte CalculateMdef(WorldObjectStatusChangeList sc, byte mdef) {
			return mdef;
		}

		private short CalculateDef2(WorldObjectStatusChangeList sc, short def2) {
			return def2;
		}

		private byte CalculateDef(WorldObjectStatusChangeList sc, byte def) {
			return def;
		}

		private short CalculateFlee(WorldObjectStatusChangeList sc, short flee) {
			return flee;
		}

		private short CalculateHit(WorldObjectStatusChangeList sc, short hit) {
			return hit;
		}

		private ushort CalculateWatk(WorldObjectStatusChangeList sc, ushort watk) {
			return watk;
		}

		private ushort CalculateBatk(WorldObjectStatusChangeList sc, ushort batk) {
			return batk;
		}

		private ushort CalculateBaseAtk(WorldObjectStatus status) {
			return status.AtkBase;
		}

		private ushort CalculateLuk(WorldObjectStatusChangeList sc, ushort luk) {
			return luk;
		}

		private ushort CalculateDex(WorldObjectStatusChangeList sc, ushort dex) {
			return dex;
		}

		private ushort CalculateInt(WorldObjectStatusChangeList sc, ushort int_) {
			return int_;
		}

		private ushort CalculateVit(WorldObjectStatusChangeList sc, ushort vit) {
			return vit;
		}

		private ushort CalculateAgi(WorldObjectStatusChangeList sc, ushort agi) {
			return agi;
		}

		private ushort CalculateStr(WorldObjectStatusChangeList sc, ushort str) {
			return str;
		}


		private void CalculateRegenRate(WorldObjectRegenerationData data, WorldObjectStatusChangeList sc) {

		}

		private void CalculateRegenData(WorldObjectStatus status, WorldObjectRegenerationData data) {

		}


		/// <summary>
		/// Calculates player data from scratch without counting SC adjustments.
		/// Should be invoked whenever players raise stats, learn passive skills or change equipment.
		/// </summary>
		/// <param name="first"></param>
		private void CalculateChar_(bool first) {
			// TODO: eAthena uses a static here.. check the recursion and convert it
			int calculating = 0; //Check for recursive call preemption
			Character character = (Object as Character);
			WorldObjectStatus status; // pointer to the player's base status
			WorldObjectStatusChangeList sc = character.StatusChange;
			CharacterSkillTree skills; // previous skill tree
			uint b_weight, b_max_weight; // previous weight
			int i, index;
			int skill, refinedef = 0;

			// Too many recursive calls!
			if (++calculating > 10) {
				return;
			}

			// remember player-specific values that are currently being shown to the client (for refresh purposes)
			skills = new CharacterSkillTree(character.Status.Skills);
			b_weight = character.Weight;
			b_max_weight = character.MaxWeight;

			character.CalculateSkillTree();

			character.MaxWeight = (uint)CharacterJobModifer.Modifer[character.Status.Class][ECharacterJobModifer.Weight];
			character.MaxWeight += (uint)(character.Status.Str * 300);

			if (first) {
				// Load Hp/SP from char-received data.
				// TODO: compare the damn datatype!
				character.BattleStatus.HP = (uint)character.Status.HP;
				character.BattleStatus.SP = (uint)character.Status.SP;
				// TODO: needs to be pointer, check this (changes on "character.Regen.SkillRegen" should affect "character.SRegen" too)
				character.Regen.SkillRegen = character.SRegen;
				character.Regen.SittingSkillRegen = character.SSRegen;
				character.Weight = 0;

				// Calc inventory weight
				for (i = 0; i < character.Status.Inventory.Count; i++) {
					var item = character.Status.Inventory[i];
					if (item.NameID > 0 && item.Amount > 0) {
						character.Weight += (uint)(item.Data.Weight * item.Amount);
					}
				}

				// Calc cart weight
				character.CartWeight = 0;
				character.CartNum = 0;
				for (i = 0; i < character.Status.Cart.Count; i++) {
					var item = character.Status.Cart[i];
					if (item.NameID > 0 && item.Amount > 0) {
						character.CartWeight += (int)(item.Data.Weight * item.Amount);
						character.CartNum++;
					}
				}

				// Set base values..
				// TODO: pointer here, check this
				status = character.BaseStatus;

				// these are not zeroed
				character.HPRate = 100;
				character.SPRate = 100;
				character.CastRate = 100;
				character.DelayRate = 100;
				character.DSPRate = 100;
				character.HPRecoverRate = 100;
				character.SPRecoverRate = 100;
				character.MatkRate = 100;
				character.CriticalRate = character.HitRate = character.FleeRate = character.Flee2Rate = 100;
				character.DefRate = character.Def2Rate = character.MdefRate = character.Mdef2Rate = 100;
				character.Regen.StateBlock = 0;

				// Lists and arrays are always initialized, just clear them
				Array.Clear(character.ParamBonus, 0, character.ParamBonus.Length);
				Array.Clear(character.ParamEquip, 0, character.ParamEquip.Length);
				Array.Clear(character.Subele, 0, character.Subele.Length);
				Array.Clear(character.Subrace, 0, character.Subrace.Length);
				Array.Clear(character.Subrace2, 0, character.Subrace2.Length);
				Array.Clear(character.Subsize, 0, character.Subsize.Length);
				Array.Clear(character.Reseff, 0, character.Reseff.Length);
				Array.Clear(character.WeaponComaEle, 0, character.WeaponComaEle.Length);
				Array.Clear(character.WeaponComaRace, 0, character.WeaponComaRace.Length);
				Array.Clear(character.WeaponAtk, 0, character.WeaponAtk.Length);
				Array.Clear(character.WeaponAtkRate, 0, character.WeaponAtkRate.Length);
				Array.Clear(character.ArrowAddEle, 0, character.ArrowAddEle.Length);
				Array.Clear(character.ArrowAddRace, 0, character.ArrowAddRace.Length);
				Array.Clear(character.ArrowAddSize, 0, character.ArrowAddSize.Length);
				Array.Clear(character.MagicAddEle, 0, character.MagicAddEle.Length);
				Array.Clear(character.MagicAddRace, 0, character.MagicAddRace.Length);
				Array.Clear(character.MagicAddSize, 0, character.MagicAddSize.Length);
				Array.Clear(character.CritAddRace, 0, character.CritAddRace.Length);
				Array.Clear(character.ExpAddRace, 0, character.ExpAddRace.Length);
				Array.Clear(character.IgnoreMdef, 0, character.IgnoreMdef.Length);
				Array.Clear(character.IgnoreDef, 0, character.IgnoreDef.Length);
				character.ItemGroupHealRate.Clear();
				Array.Clear(character.SpGainRace, 0, character.SpGainRace.Length);

				// TODO: clear them the same way
				//character.WeaponRight.OverRefine
				//memset (&character.right_weapon.overrefine, 0, sizeof(character.right_weapon) - sizeof(character.right_weapon.atkmods));
				//memset (&character.left_weapon.overrefine, 0, sizeof(character.left_weapon) - sizeof(character.left_weapon.atkmods));

				//Clear status change.
				if (character.SpecialState.intravision) {
					//clif_status_load(&character.bl, SI_INTRAVISION, 0);
				}

				// TODO: find a way .. 
				//memset(&character.special_state,0,sizeof(character.special_state));
				//memset(&status->max_hp, 0, sizeof(struct status_data)-(sizeof(status->hp)+sizeof(status->sp)));

				//FIXME: Most of these stuff should be calculated once, but how do I fix the memset above to do that? [Skotlex]
				status.Speed = (ushort)Global.DEFAULT_WALK_SPEED;
				// Give them all modes except these (useful for clones)
				status.Mode = EMonsterMode.Mask & ~(EMonsterMode.Boss | EMonsterMode.Plant | EMonsterMode.Detector | EMonsterMode.Angry | EMonsterMode.TargetWeak);
				status.Size = ((character.Class & EClass.JOBl_BABY) > 0 ? ESize.Tiny : ESize.Normal);

				if (Config.CharacterSize > 0 && character.IsRiding()) {
					if ((character.Class & EClass.JOBl_BABY) > 0) {
						if ((Config.CharacterSize & 2) > 0) {
							status.Size = (ESize)((int)status.Size + 1);
						}
					} else if ((Config.CharacterSize & 1) > 0) {
						status.Size = (ESize)((int)status.Size + 1);
					}
				}
				status.AspdRate = 1000;
				status.EleLv = 1;
				status.Race = ERace.Demihuman;

				// zero up structures...
				Array.Clear(character.AutoSpell, 0, character.AutoSpell.Length);
				Array.Clear(character.AutoSpell2, 0, character.AutoSpell2.Length);
				Array.Clear(character.AutoSpell3, 0, character.AutoSpell3.Length);
				character.AddEff.Clear();
				character.AddEff2.Clear();
				character.AddEff3.Clear();
				character.SkillAtk.Clear();
				character.SkillHeal.Clear();
				character.SkillHeal2.Clear();
				character.HPLoss.Clear();
				character.SPLoss.Clear();
				character.HPRegen.Clear();
				character.SPRegen.Clear();
				character.SkillBlown.Clear();
				character.SkillCast.Clear();
				character.AddDef.Clear();
				character.AddMDamage.Clear();
				character.AddDrop.Clear();
				character.ItemHealRate.Clear();
				character.SubEle2.Clear();


				// vars zeroing
				character.AtkRate = 0;
				character.ArrowAtk = 0;
				character.ArrowEle = 0;
				character.ArrowCri = 0;
				character.ArrowHit = 0;
				character.Nsshealhp = 0;
				character.Nsshealsp = 0;
				character.CriticalDef = 0;
				character.DoubleRate = 0;
				character.LongAttackAtkRate = 0;
				character.NearAttackDefRate = 0;
				character.LongAttackDefRate = 0;
				character.MagicDefRate = 0;
				character.MiscDefRate = 0;
				character.IgnoreMdefEle = 0;
				character.IgnoreMdefRace = 0;
				character.PerfectHit = 0;
				character.PerfectHitAdd = 0;
				character.GetZenyRate = 0;
				character.GetZenyNum = 0;
				character.DoubleAddRate = 0;
				character.ShortWeaponDamageReturn = 0;
				character.LongWeaponDamageReturn = 0;
				character.MagicDamageReturn = 0;
				character.RandomAttackIncreaseAdd = 0;
				character.RandomAttackIncreasePer = 0;
				character.BreakWeaponRate = 0;
				character.BreakArmorRate = 0;
				character.CritAtkRate = 0;
				character.Classchange = 0;
				character.SpeedRate = 0;
				character.SpeedAddRate = 0;
				character.AspdAdd = 0;
				character.SetitemHash = 0;
				character.SetitemHash2 = 0;
				character.Itemhealrate2 = 0;
				character.SplashRange = 0;
				character.SplashAddRange = 0;
				character.AddStealRate = 0;
				character.AddHealRate = 0;
				character.AddHeal2Rate = 0;
				character.HpGainValue = 0;
				character.SpGainValue = 0;
				character.MagicHpGainValue = 0;
				character.MagicSpGainValue = 0;
				character.SpVanishRate = 0;
				character.SpVanishPer = 0;
				character.Unbreakable = 0;
				character.UnbreakableEquip = 0;
				character.UnstripableEquip = 0;

				// Autobonus
				//pc_delautobonus(sd,character.autobonus,ARRAYLENGTH(character.autobonus),true);
				//pc_delautobonus(sd,character.autobonus2,ARRAYLENGTH(character.autobonus2),true);
				//pc_delautobonus(sd,character.autobonus3,ARRAYLENGTH(character.autobonus3),true);


				// Parse equipment
				int current_equip_item_index;
				for (i = 0; i < (int)EItemEquipIndex.Max - 1; i++) {
					EItemEquipIndex iEnum = (EItemEquipIndex)i;
					// We pass INDEX to current_equip_item_index - for EQUIP_SCRIPT (new cards solution) 
					current_equip_item_index = index = character.EquipIndex[i];
					if (index < 0) {
						continue;
					}
					if (iEnum == EItemEquipIndex.HandR && character.EquipIndex[(int)EItemEquipIndex.HandL] == index) {
						continue;
					}
					if (iEnum == EItemEquipIndex.HeadMid && character.EquipIndex[(int)EItemEquipIndex.HeadLow] == index) {
						continue;
					}
					if (iEnum == EItemEquipIndex.HeadTop && (character.EquipIndex[(int)EItemEquipIndex.HeadMid] == index || character.EquipIndex[(int)EItemEquipIndex.HeadLow] == index)) {
						continue;
					}
					if (character.Inventory.Count <= index) {
						continue;
					}

					status.Def += (byte)character.Inventory[index].Data.Def;

					// TODO: callbacks for item script
					/*
					if(first && character.Inventory[index].Data.EquipScript)
					{	//Execute equip-script on login
						run_script(character.inventory_data[index]->equip_script,0,character.bl.id,0);
						if (!calculating)
							return 1;
					}
					*/
					if (character.Inventory[index].Data.Type == EItemType.Weapon) {
						int r, wlv = (int)character.Inventory[index].Data.WeaponLevel;
						WeaponData wd;
						WeaponAtk wa;

						if (wlv >= Global.MAX_REFINE_BONUS)
							wlv = Global.MAX_REFINE_BONUS - 1;
						if (iEnum == EItemEquipIndex.HandL && character.Inventory[index].Equip == EItemEquipLocation.HandLeft) {
							wd = character.WeaponLeft; // Left-hand weapon
							wa = status.Lhw;
						} else {
							wd = character.WeaponRight;
							wa = status.Rhw;
						}
						if (wd == null) {
							wd = new WeaponData();
						}
						if (wa == null) {
							wa = new WeaponAtk();
						}

						wa.AtkMin += (ushort)character.Inventory[index].Data.Atk;
						// TODO: load refinebonus
						wa.AtkMax = (ushort)(r = character.Inventory[index].Refine); // *refinebonus[wlv][0];
						//if((r-=refinebonus[wlv][2])>0) //Overrefine bonus.
						//	wd->overrefine = r*refinebonus[wlv][1];

						// TODO: hier weiter machen!
						//		 Klammern } nur zum compile geadded (alle 3!)
					}
				}
			}
			/*
				wa->range += character.inventory_data[index]->range;
				if(character.inventory_data[index]->script) {
					if (wd == &character.left_weapon) {
						character.state.lr_flag = 1;
						run_script(character.inventory_data[index]->script,0,character.bl.id,0);
						character.state.lr_flag = 0;
					} else
						run_script(character.inventory_data[index]->script,0,character.bl.id,0);
					if (!calculating) //Abort, run_script retriggered this. [Skotlex]
						return 1;
				}

				if(character.status.inventory[index].card[0]==CARD0_FORGE)
				{	// Forged weapon
					wd->star += (character.status.inventory[index].card[1]>>8);
					if(wd->star >= 15) wd->star = 40; // 3 Star Crumbs now give +40 dmg
					if(pc_famerank(MakeDWord(character.status.inventory[index].card[2],character.status.inventory[index].card[3]) ,MAPID_BLACKSMITH))
						wd->star += 10;
				
					if (!wa->ele) //Do not overwrite element from previous bonuses.
						wa->ele = (character.status.inventory[index].card[1]&0x0f);
				}
			}
			else if(character.inventory_data[index]->type == IT_ARMOR) {
				refinedef += character.status.inventory[index].refine*refinebonus[0][0];
				if(character.inventory_data[index]->script) {
					run_script(character.inventory_data[index]->script,0,character.bl.id,0);
					if (!calculating) //Abort, run_script retriggered this. [Skotlex]
						return 1;
				}
			}
		}

		if(character.equip_index[EQI_AMMO] >= 0){
			index = character.equip_index[EQI_AMMO];
			if(character.inventory_data[index]){		// Arrows
				character.arrow_atk += character.inventory_data[index]->atk;
				character.state.lr_flag = 2;
				run_script(character.inventory_data[index]->script,0,character.bl.id,0);
				character.state.lr_flag = 0;
				if (!calculating) //Abort, run_script retriggered status_calc_pc. [Skotlex]
					return 1;
			}
		}

		//Store equipment script bonuses 
		memcpy(character.param_equip,character.param_bonus,sizeof(character.param_equip));
		memset(character.param_bonus, 0, sizeof(character.param_bonus));

		status->def += (refinedef+50)/100;

		//Parse Cards
		for(i=0;i<EQI_MAX-1;i++) {
			current_equip_item_index = index = character.equip_index[i]; //We pass INDEX to current_equip_item_index - for EQUIP_SCRIPT (new cards solution) [Lupus]
			if(index < 0)
				continue;
			if(i == EQI_HAND_R && character.equip_index[EQI_HAND_L] == index)
				continue;
			if(i == EQI_HEAD_MID && character.equip_index[EQI_HEAD_LOW] == index)
				continue;
			if(i == EQI_HEAD_TOP && (character.equip_index[EQI_HEAD_MID] == index || character.equip_index[EQI_HEAD_LOW] == index))
				continue;

			if(character.inventory_data[index]) {
				int j,c;
				struct item_data *data;

				//Card script execution.
				if(itemdb_isspecial(character.status.inventory[index].card[0]))
					continue;
				for(j=0;j<MAX_SLOTS;j++){ // Uses MAX_SLOTS to support Soul Bound system [Inkfish]
					current_equip_card_id= c= character.status.inventory[index].card[j];
					if(!c)
						continue;
					data = itemdb_exists(c);
					if(!data)
						continue;
					if(first && data->equip_script)
					{	//Execute equip-script on login
						run_script(data->equip_script,0,character.bl.id,0);
						if (!calculating)
							return 1;
					}
					if(!data->script)
						continue;
					if(data->flag.no_equip) { //Card restriction checks.
						if(map[character.bl.m].flag.restricted && data->flag.no_equip&map[character.bl.m].zone)
							continue;
						if(map[character.bl.m].flag.pvp && data->flag.no_equip&1)
							continue;
						if(map_flag_gvg(character.bl.m) && data->flag.no_equip&2) 
							continue;
					}
					if(i == EQI_HAND_L && character.status.inventory[index].equip == EQP_HAND_L)
					{	//Left hand status.
						character.state.lr_flag = 1;
						run_script(data->script,0,character.bl.id,0);
						character.state.lr_flag = 0;
					} else
						run_script(data->script,0,character.bl.id,0);
					if (!calculating) //Abort, run_script his function. [Skotlex]
						return 1;
				}
			}
		}

		if( sc->count && sc->data[SC_ITEMSCRIPT] )
		{
			struct item_data *data = itemdb_exists(sc->data[SC_ITEMSCRIPT]->val1);
			if( data && data->script )
				run_script(data->script,0,character.bl.id,0);
		}

		if( character.pd )
		{ // Pet Bonus
			struct pet_data *pd = character.pd;
			if( pd && pd->petDB && pd->petDB->equip_script && pd->pet.intimate >= battle_config.pet_equip_min_friendly )
				run_script(pd->petDB->equip_script,0,character.bl.id,0);
			if( pd && pd->pet.intimate > 0 && (!battle_config.pet_equip_required || pd->pet.equip > 0) && pd->state.skillbonus == 1 && pd->bonus )
				pc_bonus(sd,pd->bonus->type, pd->bonus->val);
		}

		//param_bonus now holds card bonuses.
		if(status->rhw.range < 1) status->rhw.range = 1;
		if(status->lhw.range < 1) status->lhw.range = 1;
		if(status->rhw.range < status->lhw.range)
			status->rhw.range = status->lhw.range;

		character.double_rate += character.double_add_rate;
		character.perfect_hit += character.perfect_hit_add;
		character.splash_range += character.splash_add_range;

		// Damage modifiers from weapon type
		character.right_weapon.atkmods[0] = atkmods[0][character.weapontype1];
		character.right_weapon.atkmods[1] = atkmods[1][character.weapontype1];
		character.right_weapon.atkmods[2] = atkmods[2][character.weapontype1];
		character.left_weapon.atkmods[0] = atkmods[0][character.weapontype2];
		character.left_weapon.atkmods[1] = atkmods[1][character.weapontype2];
		character.left_weapon.atkmods[2] = atkmods[2][character.weapontype2];

		if(pc_isriding(sd) &&
			(character.status.weapon==W_1HSPEAR || character.status.weapon==W_2HSPEAR))
		{	//When Riding with spear, damage modifier to mid-class becomes 
			//same as versus large size.
			character.right_weapon.atkmods[1] = character.right_weapon.atkmods[2];
			character.left_weapon.atkmods[1] = character.left_weapon.atkmods[2];
		}

	// ----- STATS CALCULATION -----

		// Job bonuses
		index = pc_class2idx(character.status.class_);
		for(i=0;i<(int)character.status.job_level && i<MAX_LEVEL;i++){
			if(!job_bonus[index][i])
				continue;
			switch(job_bonus[index][i]) {
				case 1: status->str++; break;
				case 2: status->agi++; break;
				case 3: status->vit++; break;
				case 4: status->int_++; break;
				case 5: status->dex++; break;
				case 6: status->luk++; break;
			}
		}

		// If a Super Novice has never died and is at least joblv 70, he gets all stats +10
		if((character.class_&MAPID_UPPERMASK) == MAPID_SUPER_NOVICE && character.die_counter == 0 && character.status.job_level >= 70){
			status->str += 10;
			status->agi += 10;
			status->vit += 10;
			status->int_+= 10;
			status->dex += 10;
			status->luk += 10;
		}

		// Absolute modifiers from passive skills
		if(pc_checkskill(sd,BS_HILTBINDING)>0)
			status->str++;
		if((skill=pc_checkskill(sd,SA_DRAGONOLOGY))>0)
			status->int_ += (skill+1)/2; // +1 INT / 2 lv
		if((skill=pc_checkskill(sd,AC_OWL))>0)
			status->dex += skill;

		// Bonuses from cards and equipment as well as base stat, remember to avoid overflows.
		i = status->str + character.status.str + character.param_bonus[0] + character.param_equip[0];
		status->str = cap_value(i,0,USHRT_MAX);
		i = status->agi + character.status.agi + character.param_bonus[1] + character.param_equip[1];
		status->agi = cap_value(i,0,USHRT_MAX);
		i = status->vit + character.status.vit + character.param_bonus[2] + character.param_equip[2];
		status->vit = cap_value(i,0,USHRT_MAX);
		i = status->int_+ character.status.int_+ character.param_bonus[3] + character.param_equip[3];
		status->int_ = cap_value(i,0,USHRT_MAX);
		i = status->dex + character.status.dex + character.param_bonus[4] + character.param_equip[4];
		status->dex = cap_value(i,0,USHRT_MAX);
		i = status->luk + character.status.luk + character.param_bonus[5] + character.param_equip[5];
		status->luk = cap_value(i,0,USHRT_MAX);

	// ------ BASE ATTACK CALCULATION ------

		// Base batk value is set on status_calc_misc
		// weapon-type bonus (FIXME: Why is the weapon_atk bonus applied to base attack?)
		if (character.status.weapon < MAX_WEAPON_TYPE && character.weapon_atk[character.status.weapon])
			status->batk += character.weapon_atk[character.status.weapon];
		// Absolute modifiers from passive skills
		if((skill=pc_checkskill(sd,BS_HILTBINDING))>0)
			status->batk += 4;

	// ----- HP MAX CALCULATION -----

		// Basic MaxHP value
		//We hold the standard Max HP here to make it faster to recalculate on vit changes.
		character.status.max_hp = status_base_pc_maxhp(sd,status);
		//This is done to handle underflows from negative Max HP bonuses
		i = character.status.max_hp + (int)status->max_hp;
		status->max_hp = cap_value(i, 0, INT_MAX);

		// Absolute modifiers from passive skills
		if((skill=pc_checkskill(sd,CR_TRUST))>0)
			status->max_hp += skill*200;

		// Apply relative modifiers from equipment
		if(character.hprate < 0)
			character.hprate = 0;
		if(character.hprate!=100)
			status->max_hp = status->max_hp * character.hprate/100;
		if(battle_config.hp_rate != 100)
			status->max_hp = status->max_hp * battle_config.hp_rate/100;

		if(status->max_hp > (unsigned int)battle_config.max_hp)
			status->max_hp = battle_config.max_hp;
		else if(!status->max_hp)
			status->max_hp = 1;

	// ----- SP MAX CALCULATION -----

		// Basic MaxSP value
		character.status.max_sp = status_base_pc_maxsp(sd,status);
		//This is done to handle underflows from negative Max SP bonuses
		i = character.status.max_sp + (int)status->max_sp;
		status->max_sp = cap_value(i, 0, INT_MAX);

		// Absolute modifiers from passive skills
		if((skill=pc_checkskill(sd,SL_KAINA))>0)
			status->max_sp += 30*skill;
		if((skill=pc_checkskill(sd,HP_MEDITATIO))>0)
			status->max_sp += status->max_sp * skill/100;
		if((skill=pc_checkskill(sd,HW_SOULDRAIN))>0)
			status->max_sp += status->max_sp * 2*skill/100;

		// Apply relative modifiers from equipment
		if(character.sprate < 0)
			character.sprate = 0;
		if(character.sprate!=100)
			status->max_sp = status->max_sp * character.sprate/100;
		if(battle_config.sp_rate != 100)
			status->max_sp = status->max_sp * battle_config.sp_rate/100;

		if(status->max_sp > (unsigned int)battle_config.max_sp)
			status->max_sp = battle_config.max_sp;
		else if(!status->max_sp)
			status->max_sp = 1;

	// ----- RESPAWN HP/SP -----
	// 
		//Calc respawn hp and store it on base_status
		if (character.special_state.restart_full_recover)
		{
			status->hp = status->max_hp;
			status->sp = status->max_sp;
		} else {
			if((character.class_&MAPID_BASEMASK) == MAPID_NOVICE && !(character.class_&JOBL_2) 
				&& battle_config.restart_hp_rate < 50) 
				status->hp=status->max_hp>>1;
			else 
				status->hp=status->max_hp * battle_config.restart_hp_rate/100;
			if(!status->hp)
				status->hp = 1;

			status->sp = status->max_sp * battle_config.restart_sp_rate /100;
		}

	// ----- MISC CALCULATION -----
		status_calc_misc(&character.bl, status, character.status.base_level);

		//Equipment modifiers for misc settings
		if(character.matk_rate < 0)
			character.matk_rate = 0;
		if(character.matk_rate != 100){
			status->matk_max = status->matk_max * character.matk_rate/100;
			status->matk_min = status->matk_min * character.matk_rate/100;
		}

		if(character.hit_rate < 0)
			character.hit_rate = 0;
		if(character.hit_rate != 100)
			status->hit = status->hit * character.hit_rate/100;

		if(character.flee_rate < 0)
			character.flee_rate = 0;
		if(character.flee_rate != 100)
			status->flee = status->flee * character.flee_rate/100;

		if(character.def2_rate < 0)
			character.def2_rate = 0;
		if(character.def2_rate != 100)
			status->def2 = status->def2 * character.def2_rate/100;

		if(character.mdef2_rate < 0)
			character.mdef2_rate = 0;
		if(character.mdef2_rate != 100)
			status->mdef2 = status->mdef2 * character.mdef2_rate/100;

		if(character.critical_rate < 0) 
			character.critical_rate = 0;
		if(character.critical_rate != 100)
			status->cri = status->cri * character.critical_rate/100;

		if(character.flee2_rate < 0)
			character.flee2_rate = 0;
		if(character.flee2_rate != 100)
			status->flee2 = status->flee2 * character.flee2_rate/100;

	// ----- HIT CALCULATION -----

		// Absolute modifiers from passive skills
		if((skill=pc_checkskill(sd,BS_WEAPONRESEARCH))>0)
			status->hit += skill*2;
		if((skill=pc_checkskill(sd,AC_VULTURE))>0){
			status->hit += skill;
			if(character.status.weapon == W_BOW)
				status->rhw.range += skill;
		}
		if(character.status.weapon >= W_REVOLVER && character.status.weapon <= W_GRENADE)
		{
			if((skill=pc_checkskill(sd,GS_SINGLEACTION))>0)
				status->hit += 2*skill;
			if((skill=pc_checkskill(sd,GS_SNAKEEYE))>0) {
				status->hit += skill;
				status->rhw.range += skill;
			}
		}

	// ----- FLEE CALCULATION -----

		// Absolute modifiers from passive skills
		if((skill=pc_checkskill(sd,TF_MISS))>0)
			status->flee += skill*(character.class_&JOBL_2 && (character.class_&MAPID_BASEMASK) == MAPID_THIEF? 4 : 3);
		if((skill=pc_checkskill(sd,MO_DODGE))>0)
			status->flee += (skill*3)>>1;

	// ----- EQUIPMENT-DEF CALCULATION -----

		// Apply relative modifiers from equipment
		if(character.def_rate < 0)
			character.def_rate = 0;
		if(character.def_rate != 100) {
			i =  status->def * character.def_rate/100;
			status->def = cap_value(i, CHAR_MIN, CHAR_MAX);
		}

		if (!battle_config.weapon_defense_type && status->def > battle_config.max_def)
		{
			status->def2 += battle_config.over_def_bonus*(status->def -battle_config.max_def);
			status->def = (unsigned char)battle_config.max_def;
		}

	// ----- EQUIPMENT-MDEF CALCULATION -----

		// Apply relative modifiers from equipment
		if(character.mdef_rate < 0)
			character.mdef_rate = 0;
		if(character.mdef_rate != 100) {
			i =  status->mdef * character.mdef_rate/100;
			status->mdef = cap_value(i, CHAR_MIN, CHAR_MAX);
		}

		if (!battle_config.magic_defense_type && status->mdef > battle_config.max_def)
		{
			status->mdef2 += battle_config.over_def_bonus*(status->mdef -battle_config.max_def);
			status->mdef = (signed char)battle_config.max_def;
		}

	// ----- ASPD CALCULATION -----
	// Unlike other stats, ASPD rate modifiers from skills/SCs/items/etc are first all added together, then the final modifier is applied

		// Basic ASPD value
		i = status_base_amotion_pc(sd,status);
		status->amotion = cap_value(i,battle_config.max_aspd,2000);

		// Relative modifiers from passive skills
		if((skill=pc_checkskill(sd,SA_ADVANCEDBOOK))>0 && character.status.weapon == W_BOOK)
			status->aspd_rate -= 5*skill;
		if((skill = pc_checkskill(sd,SG_DEVIL)) > 0 && !pc_nextjobexp(sd))
			status->aspd_rate -= 30*skill;
		if((skill=pc_checkskill(sd,GS_SINGLEACTION))>0 &&
			(character.status.weapon >= W_REVOLVER && character.status.weapon <= W_GRENADE))
			status->aspd_rate -= ((skill+1)/2) * 10;
		if(pc_isriding(sd))
			status->aspd_rate += 500-100*pc_checkskill(sd,KN_CAVALIERMASTERY);

		status->adelay = 2*status->amotion;


	// ----- DMOTION -----
	//
		i =  800-status->agi*4;
		status->dmotion = cap_value(i, 400, 800);
		if(battle_config.pc_damage_delay_rate != 100)
			status->dmotion = status->dmotion*battle_config.pc_damage_delay_rate/100;

	// ----- MISC CALCULATIONS -----

		// Weight
		if((skill=pc_checkskill(sd,MC_INCCARRY))>0)
			character.max_weight += 2000*skill;
		if(pc_isriding(sd) && pc_checkskill(sd,KN_RIDING)>0)
			character.max_weight += 10000;
		if(sc->data[SC_KNOWLEDGE])
			character.max_weight += character.max_weight*sc->data[SC_KNOWLEDGE]->val1/10;
		if((skill=pc_checkskill(sd,ALL_INCCARRY))>0)
			character.max_weight += 2000*skill;

		if (pc_checkskill(sd,SM_MOVINGRECOVERY)>0)
			character.regen.state.walk = 1;
		else
			character.regen.state.walk = 0;

		// Skill SP cost
		if((skill=pc_checkskill(sd,HP_MANARECHARGE))>0 )
			character.dsprate -= 4*skill;

		if(sc->data[SC_SERVICE4U])
			character.dsprate -= sc->data[SC_SERVICE4U]->val3;

		if(sc->data[SC_SPCOST_RATE])
			character.dsprate -= sc->data[SC_SPCOST_RATE]->val1;

		//Underflow protections.
		if(character.dsprate < 0)
			character.dsprate = 0;
		if(character.castrate < 0)
			character.castrate = 0;
		if(character.delayrate < 0)
			character.delayrate = 0;
		if(character.hprecov_rate < 0)
			character.hprecov_rate = 0;
		if(character.sprecov_rate < 0)
			character.sprecov_rate = 0;

		// Anti-element and anti-race
		if((skill=pc_checkskill(sd,CR_TRUST))>0)
			character.subele[ELE_HOLY] += skill*5;
		if((skill=pc_checkskill(sd,BS_SKINTEMPER))>0) {
			character.subele[ELE_NEUTRAL] += skill;
			character.subele[ELE_FIRE] += skill*4;
		}
		if((skill=pc_checkskill(sd,SA_DRAGONOLOGY))>0 ){
			skill = skill*4;
			character.right_weapon.addrace[RC_DRAGON]+=skill;
			character.left_weapon.addrace[RC_DRAGON]+=skill;
			character.magic_addrace[RC_DRAGON]+=skill;
			character.subrace[RC_DRAGON]+=skill;
		}

		if(sc->count){
			if(sc->data[SC_CONCENTRATE])
			{	//Update the card-bonus data
				sc->data[SC_CONCENTRATE]->val3 = character.param_bonus[1]; //Agi
				sc->data[SC_CONCENTRATE]->val4 = character.param_bonus[4]; //Dex
			}
			if(sc->data[SC_SIEGFRIED]){
				i = sc->data[SC_SIEGFRIED]->val2;
				character.subele[ELE_WATER] += i;
				character.subele[ELE_EARTH] += i;
				character.subele[ELE_FIRE] += i;
				character.subele[ELE_WIND] += i;
				character.subele[ELE_POISON] += i;
				character.subele[ELE_HOLY] += i;
				character.subele[ELE_DARK] += i;
				character.subele[ELE_GHOST] += i;
				character.subele[ELE_UNDEAD] += i;
			}
			if(sc->data[SC_PROVIDENCE]){
				character.subele[ELE_HOLY] += sc->data[SC_PROVIDENCE]->val2;
				character.subrace[RC_DEMON] += sc->data[SC_PROVIDENCE]->val2;
			}
			if(sc->data[SC_ARMOR_ELEMENT])
			{	//This status change should grant card-type elemental resist.
				character.subele[ELE_WATER] += sc->data[SC_ARMOR_ELEMENT]->val1;
				character.subele[ELE_EARTH] += sc->data[SC_ARMOR_ELEMENT]->val2;
				character.subele[ELE_FIRE] += sc->data[SC_ARMOR_ELEMENT]->val3;
				character.subele[ELE_WIND] += sc->data[SC_ARMOR_ELEMENT]->val4;
			}
			if(sc->data[SC_ARMOR_RESIST])
			{ // Undead Scroll
				character.subele[ELE_WATER] += sc->data[SC_ARMOR_RESIST]->val1;
				character.subele[ELE_EARTH] += sc->data[SC_ARMOR_RESIST]->val2;
				character.subele[ELE_FIRE] += sc->data[SC_ARMOR_RESIST]->val3;
				character.subele[ELE_WIND] += sc->data[SC_ARMOR_RESIST]->val4;
			}
		}

		status_cpy(&character.battle_status, status);

	// ----- CLIENT-SIDE REFRESH -----
		if(!character.bl.prev) {
			//Will update on LoadEndAck
			calculating = 0;
			return 0;
		}
		if(memcmp(b_skill,character.status.skill,sizeof(character.status.skill)))
			clif_skillinfoblock(sd);
		if(b_weight != character.weight)
			clif_updatestatus(sd,SP_WEIGHT);
		if(b_max_weight != character.max_weight) {
			clif_updatestatus(sd,SP_MAXWEIGHT);
			pc_updateweightstatus(sd);
		}

		calculating = 0;
	*/
		}

		private void CalculateMob_(bool first) {
			Monster mob = (Object as Monster);
			if (first == true) {
				// Set basic level on spawn/respawn
				mob.Level = mob.Database.Level;
			}

			// TODO: check for guardians ect
			int flag = 0;


			// No spesial states?
			if (flag == 0) {
				// Clear base status
				// TODO: check if we need one!
				if (mob.BaseStatus != null) {
					mob.BaseStatus = null;
				}
				if (first) {
					// First run, get basic status data
					mob.Status.LoadFromStatus(mob.Database.Status);
				}
				return;
			}

			if (mob.BaseStatus == null) {
				mob.BaseStatus = new WorldObjectStatus(mob);
			}

			// Copy base values
			mob.BaseStatus.LoadFromStatus(mob.Database.Status);
		}

		private void CalculatePet_(bool first) {
			/*
				if (first) {
					memcpy(&pd->status, &pd->db->status, sizeof(struct status_data));
					pd->status.mode = MD_CANMOVE; // pets discard all modes, except walking
					pd->status.speed = pd->petDB->speed;

					if(battle_config.pet_attack_support || battle_config.pet_damage_support)
					{// attack support requires the pet to be able to attack
						pd->status.mode|= MD_CANATTACK;
					}
				}

				if (battle_config.pet_lv_rate && pd->msd)
				{
					struct map_session_data *sd = pd->msd;
					int lv;

					lv =character.status.base_level*battle_config.pet_lv_rate/100;
					if (lv < 0)
						lv = 1;
					if (lv != pd->pet.level || first)
					{
						struct status_data *bstat = &pd->db->status, *status = &pd->status;
						pd->pet.level = lv;
						if (!first) //Lv Up animation
							clif_misceffect(&pd->bl, 0);
						status->rhw.atk = (bstat->rhw.atk*lv)/pd->db->lv;
						status->rhw.atk2 = (bstat->rhw.atk2*lv)/pd->db->lv;
						status->str = (bstat->str*lv)/pd->db->lv;
						status->agi = (bstat->agi*lv)/pd->db->lv;
						status->vit = (bstat->vit*lv)/pd->db->lv;
						status->int_ = (bstat->int_*lv)/pd->db->lv;
						status->dex = (bstat->dex*lv)/pd->db->lv;
						status->luk = (bstat->luk*lv)/pd->db->lv;

						status->rhw.atk = cap_value(status->rhw.atk, 1, battle_config.pet_max_atk1);
						status->rhw.atk2 = cap_value(status->rhw.atk2, 2, battle_config.pet_max_atk2);
						status->str = cap_value(status->str,1,battle_config.pet_max_stats);
						status->agi = cap_value(status->agi,1,battle_config.pet_max_stats);
						status->vit = cap_value(status->vit,1,battle_config.pet_max_stats);
						status->int_= cap_value(status->int_,1,battle_config.pet_max_stats);
						status->dex = cap_value(status->dex,1,battle_config.pet_max_stats);
						status->luk = cap_value(status->luk,1,battle_config.pet_max_stats);

						status_calc_misc(&pd->bl, &pd->status, lv);

						if (!first)	//Not done the first time because the pet is not visible yet
							clif_send_petstatus(sd);
					}
				} else if (first) {
					status_calc_misc(&pd->bl, &pd->status, pd->db->lv);
					if (!battle_config.pet_lv_rate && pd->pet.level != pd->db->lv)
						pd->pet.level = pd->db->lv;
				}
	
				//Support rate modifier (1000 = 100%)
				pd->rate_fix = 1000*(pd->pet.intimate - battle_config.pet_support_min_friendly)/(1000- battle_config.pet_support_min_friendly) +500;
				if(battle_config.pet_support_rate != 100)
					pd->rate_fix = pd->rate_fix*battle_config.pet_support_rate/100;

			*/
		}

		private void CalculateHom_(bool first) {
			/*
				struct status_data *status = &hd->base_status;
				struct s_homunculus *hom = &hd->homunculus;
				int skill;
				int amotion;

				status->str = hom->str / 10;
				status->agi = hom->agi / 10;
				status->vit = hom->vit / 10;
				status->dex = hom->dex / 10;
				status->int_ = hom->int_ / 10;
				status->luk = hom->luk / 10;

				if (first) {	//[orn]
					const struct s_homunculus_db *db = hd->homunculusDB;
					status->def_ele =  db->element;
					status->ele_lv = 1;
					status->race = db->race;
					status->size = (hom->class_ == db->evo_class)?db->evo_size:db->base_size;
					status->rhw.range = 1 + status->size;
					status->mode = MD_CANMOVE|MD_CANATTACK;
					status->speed = DEFAULT_WALK_SPEED;
					if (battle_config.hom_setting&0x8 && hd->master)
						status->speed = status_get_speed(&hd->master->bl);

					status->hp = 1;
					status->sp = 1;
				}
				skill = hom->level/10 + status->vit/5;
				status->def = cap_value(skill, 0, 99);

				skill = hom->level/10 + status->int_/5;
				status->mdef = cap_value(skill, 0, 99);

				status->max_hp = hom->max_hp ;
				status->max_sp = hom->max_sp ;

				merc_hom_calc_skilltree(hd);

				if((skill=merc_hom_checkskill(hd,HAMI_SKIN)) > 0)
					status->def +=	skill * 4;

				if((skill = merc_hom_checkskill(hd,HVAN_INSTRUCT)) > 0)
				{
					status->int_ += 1 +skill/2 +skill/4 +skill/5;
					status->str  += 1 +skill/3 +skill/3 +skill/4;
				}

				if((skill=merc_hom_checkskill(hd,HAMI_SKIN)) > 0)
					status->max_hp += skill * 2 * status->max_hp / 100;

				if((skill = merc_hom_checkskill(hd,HLIF_BRAIN)) > 0)
					status->max_sp += (1 +skill/2 -skill/4 +skill/5) * status->max_sp / 100 ;

				if (first) {
					hd->battle_status.hp = hom->hp ;
					hd->battle_status.sp = hom->sp ;
				}

				status->rhw.atk = status->dex;
				status->rhw.atk2 = status->str + hom->level;

				status->aspd_rate = 1000;

				amotion = (1000 -4*status->agi -status->dex) * hd->homunculusDB->baseASPD/1000;
				status->amotion = cap_value(amotion,battle_config.max_aspd,2000);
				status->adelay = status->amotion; //It seems adelay = amotion for Homunculus.

				status_calc_misc(&hd->bl, status, hom->level);
				status_cpy(&hd->battle_status, status);

			*/
		}

		private void CalculateMerc_(bool first) {
			/*
				struct status_data *status = &md->base_status;
				struct s_mercenary *merc = &md->mercenary;

				if( first )
				{
					memcpy(status, &md->db->status, sizeof(struct status_data));
					status->mode = MD_CANMOVE|MD_CANATTACK;
					status->hp = status->max_hp;
					status->sp = status->max_sp;
					md->battle_status.hp = merc->hp;
					md->battle_status.sp = merc->sp;
				}

				status_calc_misc(&md->bl, status, md->db->lv);
				status_cpy(&md->battle_status, status);

			*/
		}


		private ushort CalcBaseMagicAtkMin() {
			return (ushort)(Int + (Int / 7) * (Int / 7));
		}

		private ushort CalcBaseMagicAtkMax() {
			return (ushort)(Int + (Int / 5) * (Int / 5));
		}

		private ushort CalcBaseAtk() {
			int flag = 0;
			ushort str, dex, dstr;

			// Calc strength based of weapon type
			// So a Bow-/Range-class got more power through DEX
			// While a melee through STR
			if (Object.Type == EDatabaseType.Char) {
				switch ((Object as Character).Status.Weapon) {
					case EWeaponType.Bow:
					case EWeaponType.Musical:
					case EWeaponType.Whip:
					case EWeaponType.Revolver:
					case EWeaponType.Rifle:
					case EWeaponType.Gatling:
					case EWeaponType.Shotgun:
					case EWeaponType.Grenade:
						flag = 1;
						break;
				}
			}

			// Its a range class?
			if (flag == 1) {
				str = Dex;
				dex = Str;
			} else {
				str = Str;
				dex = Dex;
			}

			//Normally only players have base-atk, but homunc have a different batk
			// equation, hinting that perhaps non-players should use this for batk
			dstr = (ushort)(str / 10);
			str += (ushort)(dstr * dstr);
			if (Object.Type == EDatabaseType.Char) {
				str += (ushort)(dex / 5 + Luk / 5);
			}

			return str;
		}


		public object Clone() {
			WorldObjectStatus status = new WorldObjectStatus(Object);
			status.LoadFromStatus(this);

			return status;
		}

	}

}
