using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rovolution.Server.Database;

namespace Rovolution.Server.Objects {

	public class ItemDatabaseData : DatabaseObject {
		public struct HighestMobDrop {
			public uint ID {
				get;
				set;
			}

			public int Chance {
				get;
				set;
			}
		};

		private static Dictionary<ECharacterClass, int> mClassBits = new Dictionary<ECharacterClass, int>();


		public uint NameID {
			get { return base.ID; }
			protected set { base.Serial = new DatabaseID(value, EDatabaseType.Item); }
		}

		public string NameClient {
			get;
			protected set;
		}

		public string Name {
			get;
			protected set;
		}

		public EItemType Type {
			get;
			protected set;
		}

		public uint PriceBuy {
			get;
			protected set;
		}

		public uint PriceSell {
			get;
			protected set;
		}

		public uint Weight {
			get;
			protected set;
		}

		public uint Atk {
			get;
			protected set;
		}

		public uint Def {
			get;
			protected set;
		}

		public uint Range {
			get;
			protected set;
		}

		public uint Slots {
			get;
			protected set;
		}

		public ECharacterClassUpper Upper {
			get;
			protected set;
		}

		public EAccountSex Sex {
			get;
			protected set;
		}

		public EItemEquipLocation EquipLocation {
			get;
			protected set;
		}

		public uint EquipLevel {
			get;
			protected set;
		}

		public uint WeaponLevel {
			get;
			protected set;
		}

		public bool NoRefine {
			get;
			protected set;
		}

		public EWeaponType ViewID {
			get;
			protected set;
		}

		public EWeaponType Look {
			get { return ViewID; }
			protected set { ViewID = value; }
		}

		// struct script_code *script;	//Default script for everything.
		// struct script_code *equip_script;	//Script executed once when equipping.
		// struct script_code *unequip_script;//Script executed once when unequipping.

		public EItemRestriction NoTrade {
			get;
			protected set;
		}

		public int GmLvOverride {
			get;
			protected set;
		}

		public EItemEquipRestriction EquipRestriction {
			get;
			protected set;
		}


		public int Delay {
			get;
			protected set;
		}

		public int[] ClassBase {
			get;
			protected set;
		}

		public int MaxChance {
			get;
			protected set;
		}

		public HighestMobDrop[] Mob {
			get;
			protected set;
		}

		public bool Available {
			get;
			protected set;
		}

		public bool DelayConsume {
			get;
			protected set;
		}

		public bool AutoEquip {
			get;
			protected set;
		}

		public bool BuyIgnore {
			get;
			protected set;
		}

		public int ExpireTime {
			get;
			protected set;
		}


		public bool IsEquip {
			get {
				switch (Type) {
					case EItemType.Weapon:
					case EItemType.Armor:
					case EItemType.Ammo:
						return true;
				}
				return false;
			}
		}

		public bool IsStackable {
			get {
				switch (Type) {
					case EItemType.Weapon:
					case EItemType.Armor:
					case EItemType.PetEgg:
					case EItemType.PetArmor:
						return false;
				}
				return true;
			}
		}


		public bool IsDropable {
			get { return CanDrop(100); }
		}

		public bool IsTradeable {
			get { return CanTrade(100, 100); }
		}

		public bool IsPartnerTradeable {
			get { return CanPartnerTrade(100, 100); }
		}

		public bool IsSellable {
			get { return CanSell(100); }
		}

		public bool IsStoreable {
			get { return CanStore(100); }
		}

		public bool IsStoreableCart {
			get { return CanStoreCart(100); }
		}

		public bool IsStoreableGuild {
			get { return CanStoreGuild(100); }
		}


		public ItemDatabaseData()
			: this(null) {
		}

		public ItemDatabaseData(DataRow row)
			: base() {
			if (row != null) {
				LoadFromDatabase(row);
			}
		}


		public static ItemDatabaseData Load(DataRow row) {
			ItemDatabaseData item = new ItemDatabaseData();
			if (item.LoadFromDatabase(row) == false) {
				return null;
			}

			return item;
		}


		public bool CanDrop(int gmlv) {
			return (gmlv >= GmLvOverride || !((NoTrade & EItemRestriction.NoDrop) == EItemRestriction.NoDrop));
		}

		public bool CanTrade(int gmlv, int gmlv2) {
			return (gmlv >= GmLvOverride || gmlv2 >= GmLvOverride || !((NoTrade & EItemRestriction.NoTradeVend) == EItemRestriction.NoTradeVend));
		}

		public bool CanPartnerTrade(int gmlv, int gmlv2) {
			return (gmlv >= GmLvOverride || gmlv2 >= GmLvOverride || !((NoTrade & EItemRestriction.PartnerCanOverride) == EItemRestriction.PartnerCanOverride));
		}

		public bool CanSell(int gmlv) {
			return (gmlv >= GmLvOverride || !((NoTrade & EItemRestriction.NoSoldToNpc) > 0));
		}

		public bool CanStore(int gmlv) {
			return (gmlv >= GmLvOverride || !((NoTrade & EItemRestriction.NoPlacedInStorage) == EItemRestriction.NoPlacedInStorage));
		}

		public bool CanStoreCart(int gmlv) {
			return (gmlv >= GmLvOverride || !((NoTrade & EItemRestriction.NoPlacedInCart) == EItemRestriction.NoPlacedInCart));
		}

		public bool CanStoreGuild(int gmlv) {
			return (gmlv >= GmLvOverride || !((NoTrade & EItemRestriction.NoPlacedInGuildStorage) == EItemRestriction.NoPlacedInGuildStorage));
		}


		protected override bool LoadFromDatabase(DataRow row) {

			base.Serial = new DatabaseID(row.Field<ushort>("itemID"), EDatabaseType.Item);
			NameClient = row.Field<string>("nameEnglish");
			Name = row.Field<string>("nameJapanese");
			Type = (EItemType)row.Field<byte>("type");
			PriceBuy = row.FieldNull<uint>("priceBuy");
			PriceSell = row.FieldNull<uint>("priceSell");
			Weight = row.FieldNull<ushort>("weight");
			Atk = row.FieldNull<ushort>("attack");
			Def = row.FieldNull<byte>("defence");
			Range = row.FieldNull<byte>("range");
			Slots = row.FieldNull<byte>("slots");
			Upper = (ECharacterClassUpper)row.FieldNull<byte>("equipUpper");
			Sex = (EAccountSex)row.FieldNull<byte>("equipGenders");
			EquipLocation = (EItemEquipLocation)row.FieldNull<ushort>("equipLocations");
			EquipLevel = row.FieldNull<byte>("equipLevel");
			WeaponLevel = row.FieldNull<byte>("weaponLevel");
			NoRefine = row.FieldNull<bool>("refineable");
			ViewID = (EWeaponType)row.FieldNull<ushort>("view");
			NoTrade = (EItemRestriction)row.FieldNull<int>("noTrade");
			GmLvOverride = row.FieldNull<int>("noTradeOverride");
			EquipRestriction = (EItemEquipRestriction)row.FieldNull<int>("noEquip");

			// Type - delay consumed
			if (Type == EItemType.DelayConsumed) {
				Type = EItemType.Useable;
				DelayConsume = true;
			}

			// Buy/sell
			if (PriceBuy == 0) {
				PriceBuy = PriceSell * 2;
			}
			if (PriceSell == 0) {
				PriceSell = PriceBuy / 2;
			}
			if (PriceBuy / 124f < PriceSell / 75f) {
				ServerConsole.WarningLine("Buying/Selling [{0}/{1}] price of item {2} ({3}) allows Zeny making exploit through buying/selling at discounted/overcharged prices!", PriceBuy, PriceSell, ID, Name);
			}

			// Class conversion
			int classBase = (int)row.FieldNull<uint>("equipJobs");
			ClassBase = ConvertClass(classBase);

			// Miss config
			if (IsEquip == true && EquipLocation == EItemEquipLocation.None) {
				ServerConsole.WarningLine("Item {0} ({1}) is an equipment with no equip-field! Making it an etc item", NameID, Name);
				Type = EItemType.Etc;
			}

			// Gender checks
			if (NameID == Global.WEDDING_RING_M) {
				Sex = EAccountSex.Male;
			}
			if (NameID == Global.WEDDING_RING_F) {
				Sex = EAccountSex.Female;
			}
			if (ViewID == EWeaponType.Musical && Type == EItemType.Weapon) {
				Sex = EAccountSex.Male;
			}
			if (ViewID == EWeaponType.Whip && Type == EItemType.Weapon) {
				Sex = EAccountSex.Female;
			}

			return true;
		}

		private int[] ConvertClass(int jobmask) {
			int[] bclass = new int[3];

			// Nothing todo?
			if (jobmask == 0) {
				return bclass;
			}

			// Fill shorthand list with all ECharacterClass values
			if (mClassBits.Count == 0) {
				string[] names = Enum.GetNames(typeof(ECharacterClass));
				for (int i = 0; i < names.Length; i++) {
					ECharacterClass c = (ECharacterClass)Enum.Parse(typeof(ECharacterClass), names[i]);
					mClassBits.Add(c, 1 << (int)c);
				}
			}

			// Base classes
			if ((jobmask & mClassBits[ECharacterClass.Novice]) == mClassBits[ECharacterClass.Novice]) {
				// Both Novice/Super-Novice are counted with the same ID
				bclass[0] |= 1 << (int)EClass.Novice;
				bclass[1] |= 1 << (int)EClass.Novice;
			}
			for (int i = (int)ECharacterClass.Novice + 1; i <= (int)ECharacterClass.Thief; i++) {
				if ((jobmask & mClassBits[(ECharacterClass)i]) == mClassBits[(ECharacterClass)i]) {
					bclass[0] |= 1 << ((int)EClass.Novice + i);
				}
			}
			// 2-1 classes
			if ((jobmask & mClassBits[ECharacterClass.Knight]) == mClassBits[ECharacterClass.Knight])
				bclass[1] |= 1 << (int)EClass.Swordman;
			if ((jobmask & mClassBits[ECharacterClass.Priest]) == mClassBits[ECharacterClass.Priest])
				bclass[1] |= 1 << (int)EClass.Acolyte;
			if ((jobmask & mClassBits[ECharacterClass.Wizard]) == mClassBits[ECharacterClass.Wizard])
				bclass[1] |= 1 << (int)EClass.Mage;
			if ((jobmask & mClassBits[ECharacterClass.Blacksmith]) == mClassBits[ECharacterClass.Blacksmith])
				bclass[1] |= 1 << (int)EClass.Merchant;
			if ((jobmask & mClassBits[ECharacterClass.Hunter]) == mClassBits[ECharacterClass.Hunter])
				bclass[1] |= 1 << (int)EClass.Archer;
			if ((jobmask & mClassBits[ECharacterClass.Assassin]) == mClassBits[ECharacterClass.Assassin])
				bclass[1] |= 1 << (int)EClass.Thief;
			// 2-2 classes
			if ((jobmask & mClassBits[ECharacterClass.Crusader]) == mClassBits[ECharacterClass.Crusader])
				bclass[2] |= 1 << (int)EClass.Swordman;
			if ((jobmask & mClassBits[ECharacterClass.Monk]) == mClassBits[ECharacterClass.Monk])
				bclass[2] |= 1 << (int)EClass.Acolyte;
			if ((jobmask & mClassBits[ECharacterClass.Sage]) == mClassBits[ECharacterClass.Sage])
				bclass[2] |= 1 << (int)EClass.Mage;
			if ((jobmask & mClassBits[ECharacterClass.Alchemist]) == mClassBits[ECharacterClass.Alchemist])
				bclass[2] |= 1 << (int)EClass.Merchant;
			if ((jobmask & mClassBits[ECharacterClass.Bard]) == mClassBits[ECharacterClass.Bard])
				bclass[2] |= 1 << (int)EClass.Archer;
			//	Bard/Dancer share the same slot now.
			//	if ((jobmask & mClassBits[ECharacterClass.DANCER]) == mClassBits[ECharacterClass.DANCER])
			//		bclass[2] |= 1<<EClass.ARCHER;
			if ((jobmask & mClassBits[ECharacterClass.Rogue]) == mClassBits[ECharacterClass.Rogue])
				bclass[2] |= 1 << (int)EClass.Thief;
			// Special classes that don't fit above.
			if ((jobmask & 1 << 21) == 1 << 21) //Taekwon boy
				bclass[0] |= 1 << (int)EClass.Taekwon;
			if ((jobmask & 1 << 22) == 1 << 22) //Star Gladiator
				bclass[1] |= 1 << (int)EClass.Taekwon;
			if ((jobmask & 1 << 23) == 1 << 23) //Soul Linker
				bclass[2] |= 1 << (int)EClass.Taekwon;
			if ((jobmask & mClassBits[ECharacterClass.Gunslinger]) == mClassBits[ECharacterClass.Gunslinger])
				bclass[0] |= 1 << (int)EClass.Gunslinger;
			if ((jobmask & mClassBits[ECharacterClass.Ninja]) == mClassBits[ECharacterClass.Ninja])
				bclass[0] |= 1 << (int)EClass.Ninja;

			return bclass;
		}


	}

}
