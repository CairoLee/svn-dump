using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rovolution.Server.Network;
using Rovolution.Server.Scripting;
using System.Data;

namespace Rovolution.Server.Objects {

	public class Item : WorldObject {
		public const short Card0Forge = 0x00FF;
		public const short Card0Create = 0x00FE;
		public const ushort Card0Pet = 0xFF00;


		public ItemDatabaseData Database {
			get { return (ItemDatabaseData)GetDatabaseData(); }
		}


		public Item(DatabaseID dbID, bool addToWorld)
			: base(dbID, addToWorld) {
		}

		public Item(DatabaseID dbID)
			: base(dbID) {
		}

	}

}
