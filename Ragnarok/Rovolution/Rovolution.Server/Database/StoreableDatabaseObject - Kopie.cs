using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GodLesZ.Library.MySql;

namespace Rovolution.Server.Database {

	public abstract class StoreableDatabaseObject {
		protected static Dictionary<Type, Dictionary<PropertyInfo, StoreableDatabaseObjectAttribute>> mDatabaseProperties = new Dictionary<Type, Dictionary<PropertyInfo, StoreableDatabaseObjectAttribute>>();


		public StoreableDatabaseObject()
			: this(null) {
		}

		public StoreableDatabaseObject(ResultRow row) {
			if (row != null) {
				LoadFromDatabase(row);
			}
		}


		protected virtual void Create(string table, params object[] args) {
			// @FIXME: cant make a static method virtual.. ,,!,,
			//		   but instanced is a bit of shit

			// Something to save?
			if (CacheProperties() == false) {
				return;
			}

			foreach (var prop in mDatabaseProperties) {
			}
		}


		/// <summary>
		/// Updates all dynamic properties and field
		/// </summary>
		/// <param name="table"></param>
		/// <param name="entryID"></param>
		/// <returns></returns>
		protected virtual bool UpdateDatabase(string table, int entryID) {
			if (CacheProperties() == false) {
				return false;
			}

			string query = "UPDATE `" + table + "`";
			List<string> queryParams = GetUpdateParams();

			// Extend query
			if (queryParams.Count > 0) {
				query += " SET ";
				foreach (string param in queryParams) {
					query += param + ",";
				}
			}

			// Remove last ,
			if (query[query.Length - 1] == ',') {
				query = query.Substring(0, query.Length);
			}
			// Where clause
			query += " WHERE `id` = " + entryID;

			// Send it!
			Core.Database.QuerySimple(query);

			// Success?
			return Core.Database.LastError == null;
		}

		protected virtual List<string> GetUpdateParams() {
			List<string> updateParams = new List<string>();
			var dict = mDatabaseProperties[GetType()];
			foreach (KeyValuePair<PropertyInfo, StoreableDatabaseObjectAttribute> kvp in dict) {
				StoreableDatabaseObjectAttribute att = kvp.Value;
				// Dont update prop?
				if (att.NoUpdate == true) {
					continue;
				}

				PropertyInfo prop = kvp.Key;
				string dbName = att.DatabaseName;
				object value = null;

				value = prop.GetValue(this, null);

				// If type is null, no conversion is needed
				if (att.Type != null) {
					try {
						object valueNew = Convert.ChangeType(value, att.Type);
						// Conversion done without exception, copy back
						value = valueNew;
						valueNew = null; // Cleanup
					} catch {
						ServerConsole.ErrorLine("Failed to convert value " + value + " (" + value.GetType() + ") to " + att.Type);
						// Skip if failed to convert!
						continue;
					}
				}

				updateParams.Add("`" + dbName + "` = '" + value + "'");
			}

			return updateParams;
		}

		protected virtual bool LoadFromDatabase(ResultRow row) {
			if (CacheProperties() == false) {
				return false;
			}

			var dict = mDatabaseProperties[GetType()];
			foreach (KeyValuePair<PropertyInfo, StoreableDatabaseObjectAttribute> kvp in dict) {
				StoreableDatabaseObjectAttribute att = kvp.Value;
				PropertyInfo prop = kvp.Key;
				string dbName = att.DatabaseName;


				if (row.Table.Columns.Contains(dbName) == false) {
					ServerConsole.ErrorLine("Column '{0}' not found in table!", dbName);
					continue;
				}

				object value = row[dbName].Value;
				Type valueType = value.GetType();
				// Catch value "null"
				if (value is DBNull) {
					value = null;
				}
				// Enum's need the exact Enum value..
				if (prop.PropertyType.IsEnum == true) {
					Type enumType = prop.PropertyType;
					value = Enum.ToObject(enumType, (value == null ? 0 : value));
				}

				prop.SetValue(this, value, null);
			}

			return true;
		}


		#region Cache properties
		protected bool CacheProperties() {
			return CacheProperties(false);
		}

		protected bool CacheProperties(bool forced) {
			if (forced == false) {

				if (mDatabaseProperties.ContainsKey(GetType()) == true && mDatabaseProperties[GetType()].Count > 0) {
					return true;
				}
			}

			Dictionary<PropertyInfo,StoreableDatabaseObjectAttribute> dict;
			if (mDatabaseProperties.ContainsKey(GetType()) == false) {
				dict = new Dictionary<PropertyInfo, StoreableDatabaseObjectAttribute>();
				mDatabaseProperties.Add(GetType(), dict);
			} else {
				dict = mDatabaseProperties[GetType()];
			}
			dict.Clear();

			Type t = GetType();
			PropertyInfo[] props = t.GetProperties();
			for (int i = 0; i < props.Length; i++) {
				object[] atts = props[i].GetCustomAttributes(typeof(StoreableDatabaseObjectAttribute), true);
				if (atts == null || atts.Length == 0) {
					continue;
				}

				dict.Add(props[i], atts[0] as StoreableDatabaseObjectAttribute);
			}

			return dict.Count > 0;
		}

		#endregion
	}

}
