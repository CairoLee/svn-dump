using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rovolution.Server.Database;
using Rovolution.Server.Network;

namespace Rovolution.Server.Objects {

	public class CharacterItem : StoreableObject {

		public int EntryID {
			get;
			set;
		}

		public int CharID {
			get;
			set;
		}

		public short NameID {
			get;
			set;
		}

		public short Amount {
			get;
			set;
		}

		public EItemEquipLocation Equip {
			get;
			set;
		}

		public bool Identify {
			get;
			set;
		}

		public byte Refine {
			get;
			set;
		}

		public byte Attribute {
			get;
			set;
		}

		public ushort[] Cards {
			get;
			set;
		}

		public DateTime ExpireTime {
			get;
			set;
		}


		public Character Character {
			get { return (Character)World.Objects[EDatabaseType.Char, CharID]; }
		}


		public ItemDatabaseData Data {
			get { return (ItemDatabaseData)World.Database[EDatabaseType.Item, NameID]; }
		}


		public CharacterItem() {
		}


		public static CharacterItem Load(DataRow row) {
			CharacterItem item = new CharacterItem();
			if (item.LoadFromDatabase(row) == false) {
				return null;
			}

			return item;
		}


		public EItemEquipLocation GetEquipLocation() {
			if (Data.IsEquip == false) {
				return EItemEquipLocation.None;
			}

			EItemEquipLocation ep = Equip;
			// Beware of assassin's dual's
			if (Data.ViewID == EWeaponType.Dagger ||
				Data.ViewID == EWeaponType.Sword1Hand ||
				Data.ViewID == EWeaponType.Axe1Hand
			) {
				if (ep == EItemEquipLocation.HandRight/* && (Character.Skills.HasSkill(AS_LEFT) || IsAssassin)*/) {
					return EItemEquipLocation.Arms;
				}
			}
			return ep;
		}



		/// <summary>
		/// Simplifies inventory/cart/storage packets by handling the packet section relevant to items
		/// </summary>
		/// <param name="p"></param>
		public void WriteItemData(Packet p, int equip) {
			if (Data.ViewID > 0) {
				p.Write((short)Data.ViewID);
			} else {
				p.Write((short)NameID);
			}
			p.Write((byte)(Data.Type == EItemType.PetEgg ? EItemType.Weapon : Data.Type));
			p.Write((byte)(Identify == true ? 1 : 0));
			if (equip >= 0) {
				// Equippable item 
				p.Write((short)equip);
				p.Write((short)Equip);
				p.Write((byte)Attribute);
				p.Write((byte)Refine);
			} else {
				// Stackable item.
				p.Write((short)Amount);
				if (equip == -2 && Equip == EItemEquipLocation.Ammo) {
					p.Write((ushort)EItemEquipLocation.Ammo);
				} else {
					p.Write((short)0);
				}
			}
		}

		public void WriteItemCardData(Packet p) {
			// Blank data
			if (Cards == null) {
				for (int i = 0; i < Global.MAX_SLOTS; i++) {
					p.Write((short)0);
				}
				return;
			}

			// Pet eggs
			if (Cards[0] == Item.Card0Pet) {
				p.Write((short)0);
				p.Write((short)0);
				p.Write((short)0);
				p.Write((short)Cards[3]); // Pet renamed flag.
				return;
			}

			// Forged/created items
			if (Cards[0] == Item.Card0Create || Cards[0] == Item.Card0Forge) {
				for (int i = 0; i < Global.MAX_SLOTS; i++) {
					p.Write((short)Cards[i]);
				}
				return;
			}

			// Normal items
			for (int i = 0; i < Global.MAX_SLOTS; i++) {
				// Write viewID of cards
				ItemDatabaseData item = (Cards[i] > 0 ? (ItemDatabaseData)World.Database[EDatabaseType.Item, Cards[i]] : null);
				p.Write((ushort)(item != null && item.ViewID != EWeaponType.Fist ? (ushort)item.ViewID : Cards[i]));
			}

		}


		protected override bool LoadFromDatabase(DataRow row) {
			EntryID = row.Field<int>("id");
			CharID = row.Field<int>("charID");
			NameID = row.Field<short>("nameID");
			Amount = row.Field<short>("amount");
			Equip = (EItemEquipLocation)row.Field<int>("equip");
			Identify = row.Field<bool>("identify");
			Refine = row.Field<byte>("refine");
			Attribute = row.Field<byte>("attribute");

			// Load cards
			Cards = new ushort[Global.MAX_SLOTS];
			for (int i = 0; i < Global.MAX_SLOTS; i++) {
				Cards[i] = row.Field<ushort>("card" + i);
			}

			// Expire time
			ExpireTime = DateTime.Parse(row.Field<string>("expireTime"));

			return true;
		}

	}

}
