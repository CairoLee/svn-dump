using System.Collections.Generic;
using System.Data;

namespace Rovolution.Server.Database {

	/// <summary>Abstract class representing a storeable object.</summary>
	public abstract class StoreableObject {

		public StoreableObject()
			: this(null) {
		}

		public StoreableObject(DataRow row) {
			if (row != null) {
				LoadFromDatabase(row);
			}
		}



		protected virtual void Create(string table, params object[] args) {
		}

		/// <summary>Build a query besed on all fields returned by <see cref="GetUpdateParams()"/> and updates the database.</summary>
		/// <param name="table">   The table.</param>
		/// <param name="keyField">The key field.</param>
		/// <param name="entryID"> Identifier for the entry.</param>
		/// <returns>true if it succeeds, false if it fails.</returns>
		public virtual bool UpdateDatabase(string table, string keyField, uint entryID) {
			var updateParams = GetUpdateParams();
			if (updateParams == null || updateParams.Count == 0) {
				return false;
			}

			List<string> queryParts = new List<string>();
			StoreableObjectUpdateParam p;
			for (int i = 0; i < updateParams.Count; i++) {
				p = updateParams[i];
				queryParts.Add(string.Format("`{0}` = '{1}'", p.Column, p.Value));
			}

			if (queryParts.Count == 0) {
				return false;
			}

			string query = queryParts.Implode(",");
			query = "UPDATE `" + table + "` SET " + query + " WHERE `" + keyField + "` = '" + entryID + "'";
			Core.Database.Query(query);

			return true;
		}

		protected virtual List<StoreableObjectUpdateParam> GetUpdateParams() {
			return null;
		}

		protected virtual bool LoadFromDatabase(DataRow row) {
			return true;
		}

	}

}
