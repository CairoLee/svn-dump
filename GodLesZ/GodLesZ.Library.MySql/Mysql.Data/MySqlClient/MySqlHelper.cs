using System;
using System.Data;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	public sealed class MySqlHelper {
		private MySqlHelper() {
		}

		public static string EscapeString(string value) {
			value = value.Replace(@"\", @"\\");
			value = value.Replace("'", @"\'");
			value = value.Replace("\"", "\\\"");
			value = value.Replace("`", @"\`");
			value = value.Replace("\x00b4", "\\\x00b4");
			value = value.Replace("’", @"\’");
			value = value.Replace("‘", @"\‘");
			return value;
		}

		public static DataRow ExecuteDataRow(string connectionString, string commandText, params MySqlParameter[] parms) {
			DataSet set = ExecuteDataset(connectionString, commandText, parms);
			if (set == null) {
				return null;
			}
			if (set.Tables.Count == 0) {
				return null;
			}
			if (set.Tables[0].Rows.Count == 0) {
				return null;
			}
			return set.Tables[0].Rows[0];
		}

		public static DataSet ExecuteDataset(MySqlConnection connection, string commandText) {
			return ExecuteDataset(connection, commandText, null);
		}

		public static DataSet ExecuteDataset(string connectionString, string commandText) {
			return ExecuteDataset(connectionString, commandText, null);
		}

		public static DataSet ExecuteDataset(MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters) {
			MySqlCommand selectCommand = new MySqlCommand();
			selectCommand.Connection = connection;
			selectCommand.CommandText = commandText;
			selectCommand.CommandType = CommandType.Text;
			if (commandParameters != null) {
				foreach (MySqlParameter parameter in commandParameters) {
					selectCommand.Parameters.Add(parameter);
				}
			}
			MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			adapter.Fill(dataSet);
			selectCommand.Parameters.Clear();
			return dataSet;
		}

		public static DataSet ExecuteDataset(string connectionString, string commandText, params MySqlParameter[] commandParameters) {
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				connection.Open();
				return ExecuteDataset(connection, commandText, commandParameters);
			}
		}

		public static int ExecuteNonQuery(MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters) {
			MySqlCommand command = new MySqlCommand();
			command.Connection = connection;
			command.CommandText = commandText;
			command.CommandType = CommandType.Text;
			if (commandParameters != null) {
				foreach (MySqlParameter parameter in commandParameters) {
					command.Parameters.Add(parameter);
				}
			}
			int num = command.ExecuteNonQuery();
			command.Parameters.Clear();
			return num;
		}

		public static int ExecuteNonQuery(string connectionString, string commandText, params MySqlParameter[] parms) {
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				connection.Open();
				return ExecuteNonQuery(connection, commandText, parms);
			}
		}

		public static MySqlDataReader ExecuteReader(string connectionString, string commandText) {
			return ExecuteReader(connectionString, commandText, null);
		}

		public static MySqlDataReader ExecuteReader(string connectionString, string commandText, params MySqlParameter[] commandParameters) {
			MySqlDataReader reader;
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();
			try {
				reader = ExecuteReader(connection, null, commandText, commandParameters, false);
			} catch {
				connection.Close();
				throw;
			}
			return reader;
		}

		private static MySqlDataReader ExecuteReader(MySqlConnection connection, MySqlTransaction transaction, string commandText, MySqlParameter[] commandParameters, bool ExternalConn) {
			MySqlDataReader reader;
			MySqlCommand command = new MySqlCommand();
			command.Connection = connection;
			command.Transaction = transaction;
			command.CommandText = commandText;
			command.CommandType = CommandType.Text;
			if (commandParameters != null) {
				foreach (MySqlParameter parameter in commandParameters) {
					command.Parameters.Add(parameter);
				}
			}
			if (ExternalConn) {
				reader = command.ExecuteReader();
			} else {
				reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			}
			command.Parameters.Clear();
			return reader;
		}

		public static object ExecuteScalar(MySqlConnection connection, string commandText) {
			return ExecuteScalar(connection, commandText, null);
		}

		public static object ExecuteScalar(string connectionString, string commandText) {
			return ExecuteScalar(connectionString, commandText, null);
		}

		public static object ExecuteScalar(MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters) {
			MySqlCommand command = new MySqlCommand();
			command.Connection = connection;
			command.CommandText = commandText;
			command.CommandType = CommandType.Text;
			if (commandParameters != null) {
				foreach (MySqlParameter parameter in commandParameters) {
					command.Parameters.Add(parameter);
				}
			}
			object obj2 = command.ExecuteScalar();
			command.Parameters.Clear();
			return obj2;
		}

		public static object ExecuteScalar(string connectionString, string commandText, params MySqlParameter[] commandParameters) {
			using (MySqlConnection connection = new MySqlConnection(connectionString)) {
				connection.Open();
				return ExecuteScalar(connection, commandText, commandParameters);
			}
		}

		public static void UpdateDataSet(string connectionString, string commandText, DataSet ds, string tablename) {
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();
			MySqlDataAdapter adapter = new MySqlDataAdapter(commandText, connection);
			new MySqlCommandBuilder(adapter).ToString();
			adapter.Update(ds, tablename);
			connection.Close();
		}
	}
}

