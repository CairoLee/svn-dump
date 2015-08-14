using System;
using System.Collections.Generic;
using System.Text;

using Shaiya.Extended.Server.Objects;

namespace Shaiya.Extended.Server.Scripting {

	public partial class Item : BaseItem {
		private EItemType mItemType = EItemType.Crap;
		private EItemWeaponType mWeaponType = EItemWeaponType.Hand;

		public EItemType ItemType {
			get { return mItemType; }
			set { mItemType = value; }
		}

		public EItemWeaponType WeaponType {
			get { return mWeaponType; }
			set { mWeaponType = value; }
		}


		public Item()
			: base() {
		}

	}

	public enum EItemType {
		Useable = 1,
		Equipment = 2,
		Weapon = 3,
		Crap = 4
	}

	public enum EItemWeaponType {
		Hand = 1,
		Dagger = 2,
		Sword = 3
	}

}
