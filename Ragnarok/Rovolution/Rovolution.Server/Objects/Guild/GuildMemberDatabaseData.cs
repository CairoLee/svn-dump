using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class GuildMemberDatabaseData : DatabaseObject {

		public GuildMemberDatabaseData()
			: base() {
		}

		protected override bool LoadFromDatabase(DataRow row) {
			return true;
		}

	}

}
