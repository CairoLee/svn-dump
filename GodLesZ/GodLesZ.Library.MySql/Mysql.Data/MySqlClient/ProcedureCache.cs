using GodLesZ.Library.MySql.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class ProcedureCache {
		private Queue<int> hashQueue;
		private int maxSize;
		private Hashtable procHash;

		public ProcedureCache(int size) {
			this.maxSize = size;
			this.hashQueue = new Queue<int>(this.maxSize);
			this.procHash = new Hashtable(this.maxSize);
		}

		private DataSet AddNew(MySqlConnection connection, string spName) {
			DataSet procData = GetProcData(connection, spName);
			if (this.maxSize > 0) {
				int hashCode = spName.GetHashCode();
				lock (this.procHash.SyncRoot) {
					if (this.procHash.Keys.Count >= this.maxSize) {
						this.TrimHash();
					}
					if (!this.procHash.ContainsKey(hashCode)) {
						this.procHash[hashCode] = procData;
						this.hashQueue.Enqueue(hashCode);
					}
				}
			}
			return procData;
		}

		private static DataSet GetProcData(MySqlConnection connection, string spName) {
			int index = spName.IndexOf(".");
			string str = spName.Substring(0, index);
			string str2 = spName.Substring(index + 1, (spName.Length - index) - 1);
			string[] restrictionValues = new string[4];
			restrictionValues[1] = (str.Length > 0) ? str : connection.CurrentDatabase();
			restrictionValues[2] = str2;
			DataTable schema = connection.GetSchema("procedures", restrictionValues);
			if (schema.Rows.Count > 1) {
				throw new MySqlException(Resources.ProcAndFuncSameName);
			}
			if (schema.Rows.Count == 0) {
				throw new MySqlException(string.Format(Resources.InvalidProcName, str2, str));
			}
			DataTable procedureParameters = new ISSchemaProvider(connection).GetProcedureParameters(restrictionValues, schema);
			DataSet set = new DataSet();
			set.Tables.Add(schema);
			set.Tables.Add(procedureParameters);
			return set;
		}

		public DataSet GetProcedure(MySqlConnection conn, string spName) {
			int hashCode = spName.GetHashCode();
			DataSet set = null;
			lock (this.procHash.SyncRoot) {
				set = (DataSet)this.procHash[hashCode];
			}
			if (set == null) {
				set = this.AddNew(conn, spName);
				conn.PerfMonitor.AddHardProcedureQuery();
				if (conn.Settings.Logging) {
					Logger.LogInformation(string.Format(Resources.HardProcQuery, spName));
				}
				return set;
			}
			conn.PerfMonitor.AddSoftProcedureQuery();
			if (conn.Settings.Logging) {
				Logger.LogInformation(string.Format(Resources.SoftProcQuery, spName));
			}
			return set;
		}

		private void TrimHash() {
			int key = this.hashQueue.Dequeue();
			this.procHash.Remove(key);
		}
	}
}

