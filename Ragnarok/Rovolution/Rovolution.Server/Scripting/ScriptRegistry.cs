using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Scripting {

	/// <summary>
	/// Implements read and write logic for variables, stored binary in the database
	/// </summary>
	public class ScriptRegistry : Dictionary<string, ScriptRegistryEntry> {
		public const int DEFAULT_INT32 = -1;
		public const string DEFAULT_STRING = "NULL";

		protected string mTable = "registry";


		public ScriptRegistry()
			: base() {
		}

		public ScriptRegistry(IDictionary<string, ScriptRegistryEntry> reg)
			: base(reg) {
		}


		public void LoadFromDatabase(int id, string column) {
			DataTable table = Core.Database.Query("SELECT * FROM `` WHERE `{1}` = '{2}'", mTable, column, id);
			if (table == null || table.Rows == null || table.Rows.Count == 0) {
				return;
			}

			foreach (DataRow row in table.Rows) {
				Add(row.Field<string>("name"),
					new ScriptRegistryEntry(
						id,
						row.Field<int>("id"),
						row["value"]
					)
				);
			}
		}

		public void Save() {

		}


		public int GetInt32(string name) {
			ScriptRegistryEntry entry = GetEntry(name);
			if (entry == null) {
				return DEFAULT_INT32;
			}

			return int.Parse(entry.Value.ToString());
		}

		public string GetString(string name) {
			ScriptRegistryEntry entry = GetEntry(name);
			if (entry == null) {
				return DEFAULT_STRING;
			}

			return entry.Value.ToString();
		}




		public ScriptRegistryEntry GetEntry(string name) {
			ScriptRegistryEntry entry;
			if (TryGetValue(name, out entry) == false) {
				return null;
			}

			return entry;
		}

	}

}
