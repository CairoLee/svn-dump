using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class MonsterDropList : List<MonsterDrop> {

		public MonsterDropList() {
		}

		public MonsterDropList(int mobID) {
			LoadFromDatabase(mobID);
		}


		public void LoadFromDatabase(uint mobID) {
			LoadFromDatabase((int)mobID);
		}

		public void LoadFromDatabase(int mobID) {
			DataTable table = Core.Database.Query("SELECT * FROM dbmob_drop WHERE mobID = {0}", mobID);
			if (table == null | table.Rows.Count == 0) {
				return;
			}

			foreach (DataRow row in table.Rows) {
				// No storeable interface, just a simple holder-class
				Add(new MonsterDrop(row));
			}
		}

	}

}
