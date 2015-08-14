using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rovolution.Server.Database;
using Rovolution.Server.Geometry;

namespace Rovolution.Server.Objects {

	public class CharacterDatabaseData : DatabaseObject {

		public WorldID PartnerID {
			get;
			set;
		}

		public WorldID FatherID {
			get;
			set;
		}

		public WorldID MotherID {
			get;
			set;
		}

		public WorldID ChildrenID {
			get;
			set;
		}


		public WorldID PartyID {
			get;
			set;
		}

		public WorldID GuildID {
			get;
			set;
		}

		public WorldID PetID {
			get;
			set;
		}

		public WorldID HomID {
			get;
			set;
		}

		public WorldID MercenaryID {
			get;
			set;
		}

		public WorldID ChatID {
			get;
			set;
		}

		public string Name {
			get;
			internal set;
		}

		public uint LevelBase {
			get;
			set;
		}

		public uint LevelJob {
			get;
			set;
		}

		public short Str {
			get;
			set;
		}

		public short Agi {
			get;
			set;
		}

		public short Vit {
			get;
			set;
		}

		public short Int {
			get;
			set;
		}

		public short Dex {
			get;
			set;
		}

		public short Luk {
			get;
			set;
		}

		public byte Slot {
			get;
			set;
		}

		public EAccountSex Sex {
			get;
			set;
		}

		public uint ExpBase {
			get;
			set;
		}

		public uint ExpJob {
			get;
			set;
		}

		public int Zeny {
			get;
			set;
		}


		public EClientClass Class {
			get;
			set;
		}

		public uint StatusPoints {
			get;
			set;
		}

		public uint SkillPoints {
			get;
			set;
		}

		public int HP {
			get;
			set;
		}

		public int HPMax {
			get;
			set;
		}

		public int SP {
			get;
			set;
		}

		public int SPMax {
			get;
			set;
		}

		public EStatusOption Option {
			get;
			set;
		}

		public short Manner {
			get;
			set;
		}

		public byte Karma {
			get;
			set;
		}

		public short HairStyle {
			get;
			set;
		}

		public short HairColor {
			get;
			set;
		}

		public short ClothColor {
			get;
			set;
		}

		public bool IsOnline {
			get;
			set;
		}

		public int Fame {
			get;
			set;
		}

		// Mercenary Guilds Rank
		/*
		int arch_faith, arch_calls;
		int spear_faith, spear_calls;
		int sword_faith, sword_calls;
		*/

		public EWeaponType Weapon {
			get;
			set;
		}

		public short Shield {
			get;
			set;
		}

		public short HeadTop {
			get;
			set;
		}

		public short HeadMid {
			get;
			set;
		}

		public short HeadBottom {
			get;
			set;
		}

		// Takeover from MoveableWorldObject
		public Location Location {
			get;
			set;
		}

		public Location SavePoint {
			get;
			set;
		}

		public List<Location> MemoPoints {
			get;
			set;
		}


		public ItemInventory Inventory {
			get;
			set;
		}

		public ItemInventoryCart Cart {
			get;
			set;
		}

		public ItemStorage Storage {
			get;
			set;
		}

		public CharacterSkillTree Skills {
			get;
			set;
		}

		public CharacterFriendList Friends {
			get;
			set;
		}

		public CharacterHotkey[] Hotkeys {
			get;
			set;
		}


		public bool ShowEquip {
			get;
			set;
		}

		public short Rename {
			get;
			set;
		}

		public DateTime DeleteDate {
			get;
			set;
		}


		public CharacterDatabaseData()
			: this(null) {
		}

		public CharacterDatabaseData(DataRow row)
			: base() {
			Skills = new CharacterSkillTree();
			Storage = new ItemStorage();
			Inventory = new ItemInventory();
			Cart = new ItemInventoryCart();
			Hotkeys = new CharacterHotkey[Global.MAX_HOTKEYS];
			Friends = new CharacterFriendList();

			if (row != null) {
				LoadFromDatabase(row);
			}
		}


		public static CharacterDatabaseData Load(DataRow row) {
			CharacterDatabaseData ch = new CharacterDatabaseData();
			if (ch.LoadFromDatabase(row) == false) {
				return null;
			}

			return ch;
		}


		protected override bool LoadFromDatabase(DataRow row) {
			// Load serials
			base.Serial = new DatabaseID(row.Field<uint>("charID"), EDatabaseType.Char);
			if (row.Field<uint>("partyID") > 0) {
				PartyID = new WorldID(row.Field<uint>("partyID"), EDatabaseType.Party);
			}
			if (row.Field<uint>("guildID") > 0) {
				GuildID = new WorldID(row.Field<uint>("guildID"), EDatabaseType.Guild);
			}
			if (row.Field<uint>("petID") > 0) {
				PetID = new WorldID(row.Field<uint>("petID"), EDatabaseType.Pet);
			}
			if (row.Field<uint>("homunID") > 0) {
				HomID = new WorldID(row.Field<uint>("homunID"), EDatabaseType.Homunculus);
			}
			if (row.Field<uint>("partnerID") > 0) {
				PartnerID = new WorldID(row.Field<uint>("partnerID"), EDatabaseType.Char);
			}
			if (row.Field<uint>("fatherID") > 0) {
				FatherID = new WorldID(row.Field<uint>("fatherID"), EDatabaseType.Char);
			}
			if (row.Field<uint>("motherID") > 0) {
				MotherID = new WorldID(row.Field<uint>("motherID"), EDatabaseType.Char);
			}
			if (row.Field<uint>("childID") > 0) {
				ChildrenID = new WorldID(row.Field<uint>("childID"), EDatabaseType.Char);
			}
			if (row.Field<uint>("childID") > 0) {
				MercenaryID = new WorldID(row.Field<uint>("mercID"), EDatabaseType.Mercenary);
			}

			Name = row.Field<string>("name");
			LevelBase = row.Field<ushort>("levelBase");
			LevelJob = row.Field<ushort>("levelJob");
			// TODO: rework all datatypes..
			Str = (short)row.Field<ushort>("str");
			Agi = (short)row.Field<ushort>("agi");
			Vit = (short)row.Field<ushort>("vit");
			Int = (short)row.Field<ushort>("int");
			Dex = (short)row.Field<ushort>("dex");
			Luk = (short)row.Field<ushort>("luk");
			Slot = (byte)row.Field<short>("slot");
			//Sex = (EAccountSex)row.Field<int>("sex");
			ExpBase = (uint)row.Field<ulong>("expBase");
			ExpJob = (uint)row.Field<ulong>("expJob");
			Zeny = (int)row.Field<uint>("zeny");
			Class = (EClientClass)row.Field<ushort>("class");
			StatusPoints = row.Field<uint>("statusPoint");
			SkillPoints = row.Field<uint>("skillPoint");
			HP = (int)row.Field<uint>("hp");
			HPMax = (int)row.Field<uint>("hpMax");
			SP = (int)row.Field<uint>("sp");
			SPMax = (int)row.Field<uint>("spMax");
			Option = (EStatusOption)row.Field<int>("option");
			Manner = row.Field<short>("manner");
			Karma = (byte)row.Field<sbyte>("karma");
			HairStyle = row.Field<byte>("hair");
			HairColor = (short)row.Field<ushort>("hairColor");
			ClothColor = (short)row.Field<ushort>("clothesColor");
			IsOnline = (row.Field<sbyte>("isOnline") > 0? true : false);
			Fame = (int)row.Field<uint>("fame");

			// Mercenary Guilds Rank
			/*
			int arch_faith, arch_calls;
			int spear_faith, spear_calls;
			int sword_faith, sword_calls;
			*/

			Weapon = (EWeaponType)row.Field<ushort>("weapon");
			Shield = (short)row.Field<ushort>("shield");
			HeadTop = (short)row.Field<ushort>("headTop");
			HeadMid = (short)row.Field<ushort>("headMid");
			HeadBottom = (short)row.Field<ushort>("headBottom");
			Rename = (short)row.Field<ushort>("rename");


			// Load locations
			Location = new Location(Mapcache.GetID(row.Field<string>("lastMap")), row.Field<ushort>("lastX"), row.Field<ushort>("lastY"));
			SavePoint = new Location(Mapcache.GetID(row.Field<string>("saveMap")), row.Field<ushort>("saveX"), row.Field<ushort>("saveY"));

			// Other crap
			DeleteDate = row.FieldDateTime("deleteDate");

			return true;
		}

		public override bool UpdateDatabase(string table, string keyField, uint entryID) {
			bool result = base.UpdateDatabase(table, keyField, entryID);

			// Update Items etc


			return result;
		}

		protected override List<StoreableObjectUpdateParam> GetUpdateParams() {
			// TODO: eA checks for changes of old values
			//		 but i think its faster to send everytime an update
			//		 We should test this..

			List<StoreableObjectUpdateParam> updateParams = new List<StoreableObjectUpdateParam>();
			updateParams.Add(new StoreableObjectUpdateParam("name", Name));
			updateParams.Add(new StoreableObjectUpdateParam("levelBase", LevelBase));
			updateParams.Add(new StoreableObjectUpdateParam("levelJob", LevelJob));
			updateParams.Add(new StoreableObjectUpdateParam("str", Str));
			updateParams.Add(new StoreableObjectUpdateParam("agi", Agi));
			updateParams.Add(new StoreableObjectUpdateParam("vit", Vit));
			updateParams.Add(new StoreableObjectUpdateParam("int", Int));
			updateParams.Add(new StoreableObjectUpdateParam("dex", Dex));
			updateParams.Add(new StoreableObjectUpdateParam("luk", Luk));
			updateParams.Add(new StoreableObjectUpdateParam("slot", Slot));
			//mUpdateParams.Add(new StoreableObjectUpdateParam("sex", Sex));
			updateParams.Add(new StoreableObjectUpdateParam("expBase", ExpBase));
			updateParams.Add(new StoreableObjectUpdateParam("expJob", ExpJob));
			updateParams.Add(new StoreableObjectUpdateParam("zeny", Zeny));
			updateParams.Add(new StoreableObjectUpdateParam("class", Class));
			updateParams.Add(new StoreableObjectUpdateParam("statusPoint", StatusPoints));
			updateParams.Add(new StoreableObjectUpdateParam("skillPoint", SkillPoints));
			updateParams.Add(new StoreableObjectUpdateParam("hp", HP));
			updateParams.Add(new StoreableObjectUpdateParam("hpMax", HPMax));
			updateParams.Add(new StoreableObjectUpdateParam("sp", SP));
			updateParams.Add(new StoreableObjectUpdateParam("spMax", SPMax));
			updateParams.Add(new StoreableObjectUpdateParam("option", Option));
			updateParams.Add(new StoreableObjectUpdateParam("manner", Manner));
			updateParams.Add(new StoreableObjectUpdateParam("karma", Karma));
			updateParams.Add(new StoreableObjectUpdateParam("hair", HairStyle));
			updateParams.Add(new StoreableObjectUpdateParam("hairColor", HairColor));
			updateParams.Add(new StoreableObjectUpdateParam("clothesColor", ClothColor));
			updateParams.Add(new StoreableObjectUpdateParam("isOnline", IsOnline));
			updateParams.Add(new StoreableObjectUpdateParam("fame", Fame));

			// Mercenary Guilds Rank
			/*
			int arch_faith, arch_calls;
			int spear_faith, spear_calls;
			int sword_faith, sword_calls;
			*/

			updateParams.Add(new StoreableObjectUpdateParam("weapon", Weapon));
			updateParams.Add(new StoreableObjectUpdateParam("shield", Shield));
			updateParams.Add(new StoreableObjectUpdateParam("headTop", HeadTop));
			updateParams.Add(new StoreableObjectUpdateParam("headMid", HeadMid));
			updateParams.Add(new StoreableObjectUpdateParam("headBottom", HeadBottom));
			updateParams.Add(new StoreableObjectUpdateParam("rename", Rename));

			// Locations
			updateParams.Add(new StoreableObjectUpdateParam("lastMap", Location.Map.Name.ToLower()));
			updateParams.Add(new StoreableObjectUpdateParam("lastX", Location.X));
			updateParams.Add(new StoreableObjectUpdateParam("lastY", Location.Y));
			updateParams.Add(new StoreableObjectUpdateParam("saveMap", SavePoint.Map.Name.ToLower()));
			updateParams.Add(new StoreableObjectUpdateParam("saveX", SavePoint.X));
			updateParams.Add(new StoreableObjectUpdateParam("saveY", SavePoint.Y));

			// Other crap
			//updateParams.Add(new StoreableObjectUpdateParam("deleteDate", DeleteDate));

			return updateParams;
		}

		#region Load methods
		public void LoadInventory() {
			Inventory.Clear();
			DataTable table = Core.Database.Query("SELECT * FROM `char_inventory` WHERE `charID` = {0}", ID);
			if (table == null || table.Rows.Count == 0) {
				return;
			}

			foreach (DataRow row in table.Rows) {
				CharacterItem item = CharacterItem.Load(row);
				if (item == null) {
					ServerConsole.ErrorLine("Failed to load char item #{0}", row.Field<int>("id"));
					continue;
				}

				Inventory.Add(item);
			}
		}

		public void LoadCart() {
			Cart.Clear();
			DataTable table = Core.Database.Query("SELECT * FROM `char_cart` WHERE `charID` = {0}", ID);
			if (table == null || table.Rows.Count == 0) {
				return;
			}

			foreach (DataRow row in table.Rows) {
				CharacterItem item = CharacterItem.Load(row);
				if (item == null) {
					ServerConsole.ErrorLine("Failed to load char cart item #{0}", row.Field<int>("id"));
					continue;
				}

				Cart.Add(item);
			}
		}

		public void LoadStorage() {
			Storage.Clear();
		}

		public void LoadSkills() {
			// TODO: rly needed? will be instanced in character constructor too
			//		 maybe only some custom clear implementation?
			Skills = new CharacterSkillTree();
			DataTable table = Core.Database.Query("SELECT * FROM `char_skill` WHERE `charID` = {0}", ID);
			if (table == null || table.Rows.Count == 0) {
				return;
			}

			foreach (DataRow row in table.Rows) {
				CharacterSkill skill = new CharacterSkill((ushort)row.Field<int>("skillID"), (ushort)row.Field<ushort>("skillLv"), ESkillFlag.Permanent);
				Skills.Add(skill);
			}
		}

		public void LoadPet() {
		}

		public void LoadMercenary() {
		}

		public void LoadOther() {
			DataTable table;
			int i = 0;
			// Hotkeys
			Hotkeys = new CharacterHotkey[Global.MAX_HOTKEYS];
			table = Core.Database.Query("SELECT * FROM `char_hotkey` WHERE `charID` = {0}", ID);
			if (table != null && table.Rows.Count > 0) {
				foreach (DataRow row in table.Rows) {
					CharacterHotkey key = CharacterHotkey.Load(row);
					if (key == null) {
						ServerConsole.ErrorLine("Failed to load hotkey #{0}", row.Field<int>("index"));
						continue;
					}

					Hotkeys[i++] = key;
				}
			}

			// Fill up until max
			for (; i < Hotkeys.Length; i++) {
				Hotkeys[i] = new CharacterHotkey();
			}

		}
		#endregion

		/// <summary>
		/// Returns a status param by type (str, agi, dex, vit, int, dex, luk)
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public int GetStat(EStatusParam type) {
			switch (type) {
				case EStatusParam.Str:
					return Str;
				case EStatusParam.Agi:
					return Agi;
				case EStatusParam.Vit:
					return Vit;
				case EStatusParam.Int:
					return Int;
				case EStatusParam.Dex:
					return Dex;
				case EStatusParam.Luk:
					return Luk;
				default:
					return -1;
			}
		}

		/// <summary>
		/// Sets a status param to the new value (str, agi, dex, vit, int, dex, luk)
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value"></param>
		public void SetStat(EStatusParam type, short value) {
			switch (type) {
				case EStatusParam.Str:
					Str = value;
					break;
				case EStatusParam.Agi:
					Agi = value;
					break;
				case EStatusParam.Vit:
					Vit = value;
					break;
				case EStatusParam.Int:
					Int = value;
					break;
				case EStatusParam.Dex:
					Dex = value;
					break;
				case EStatusParam.Luk:
					Luk = value;
					break;
			}
		}

		/// <summary>
		/// Calculates and returns the status points for the level 
		/// </summary>
		/// <param name="level"></param>
		/// <returns></returns>
		public int CalcNextStatusPoints(int level) {
			// TODO: handle config status table
			return ((level + 15) / 5);
		}

		/// <summary>
		/// Calculates the needed status points
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public int CalcNeededStatusPoints(EStatusParam type, int value) {
			int low, high, sp = 0;

			if (value == 0) {
				return 0;
			}

			low = GetStat(type);
			high = low + value;

			// Swap..
			if (value < 0) {
				int temp = high;
				high = low;
				low = temp;
			}

			for (; low < high; low++) {
				sp += (1 + (low + 9) / 10);
			}

			return sp;
		}


	}

}
