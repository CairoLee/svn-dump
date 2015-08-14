using System;
using System.Collections;
using System.Collections.Generic;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class MySqlPoolManager {
		private static List<MySqlPool> clearingPools = new List<MySqlPool>();
		private static Hashtable pools = new Hashtable();

		public static void ClearAllPools() {
			lock (pools.SyncRoot) {
				List<string> list = new List<string>(pools.Count);
				foreach (string str in pools.Keys) {
					list.Add(str);
				}
				foreach (string str2 in list) {
					ClearPoolByText(str2);
				}
			}
		}

		public static void ClearPool(MySqlConnectionStringBuilder settings) {
			ClearPoolByText(settings.GetConnectionString(true));
		}

		private static void ClearPoolByText(string key) {
			lock (pools.SyncRoot) {
				MySqlPool item = pools[key] as MySqlPool;
				clearingPools.Add(item);
				item.Clear();
				pools.Remove(key);
			}
		}

		public static MySqlPool GetPool(MySqlConnectionStringBuilder settings) {
			string connectionString = settings.GetConnectionString(true);
			lock (pools.SyncRoot) {
				MySqlPool pool = pools[connectionString] as MySqlPool;
				if (pool == null) {
					pool = new MySqlPool(settings);
					pools.Add(connectionString, pool);
				} else {
					pool.Settings = settings;
				}
				return pool;
			}
		}

		public static void ReleaseConnection(Driver driver) {
			MySqlPool pool = driver.Pool;
			if (pool != null) {
				pool.ReleaseConnection(driver);
			}
		}

		public static void RemoveClearedPool(MySqlPool pool) {
			clearingPools.Remove(pool);
		}

		public static void RemoveConnection(Driver driver) {
			MySqlPool pool = driver.Pool;
			if (pool != null) {
				pool.RemoveConnection(driver);
			}
		}
	}
}

