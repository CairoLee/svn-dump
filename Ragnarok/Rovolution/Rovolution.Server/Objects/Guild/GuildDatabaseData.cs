using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class GuildDatabaseData : DatabaseObject {

		public GuildDatabaseData()
			: base() {
		}

		protected override bool LoadFromDatabase(DataRow row) {
			return true;
		}

	}

}
