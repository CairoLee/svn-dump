using System;
using System.Text;
using GodLesZ.Library.MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace GodLesZ.Library.MySql {

	public class MySqlWrapper : IDisposable {
		internal string mServer;
		internal int mPort;
		internal string mUser;
		internal string mPassword;
		private string mDatabase;


		/// <summary>
		/// Gets the <see cref="EMysqlConnectionState"/> state
		/// </summary>
		public EMysqlConnectionState State {
			get;
			internal set;
		}

		/// <summary>
		/// Gets the last thrown exception
		/// </summary>
		public Exception LastError {
			get;
			internal set;
		}

		/// <summary>
		/// Gets the <see cref="MySqlConnection"/> object
		/// </summary>
		public MySqlConnection Connection {
			get;
			internal set;
		}

		/// <summary>
		/// Gets the last <see cref="MySqlCommand"/> object
		/// </summary>
		public MySqlCommand Command {
			get;
			internal set;
		}

		/// <summary>
		/// Gets the last <see cref="MySqlDataAdapter"/> object
		/// </summary>
		public MySqlDataAdapter Adapter {
			get;
			internal set;
		}

		/// <summary>
		/// Gets the last <see cref="MySqlDataReader"/> object
		/// </summary>
		public MySqlDataReader Reader {
			get;
			internal set;
		}

		/// <summary>
		/// Gets or sets the Connection string
		/// </summary>
		public string ConnectionString {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets addintional connection settings
		/// <para>See <see cref="MySqlConnectionStringBuilder"/> for possible settings</para>
		/// </summary>
		public string AdditionalSettings {
			get;
			set;
		}

		/// <summary>
		/// Gets the database
		/// </summary>
		public string Database {
			get { return mDatabase; }
		}

		/// <summary>
		/// Gets true or false if successfull connected
		/// </summary>
		public bool IsConnected {
			get { return Connection != null && Connection.State == ConnectionState.Open; }
		}


		/// <summary>
		/// Main Constructor - will instance a new <see cref="MySqlConnection"/> without Open.
		/// </summary>
		/// <param name="server"></param>
		/// <param name="port"></param>
		/// <param name="user"></param>
		/// <param name="password"></param>
		/// <param name="database"></param>
		public MySqlWrapper(string server, int port, string user, string password, string database)
			: this() {
			mServer = server;
			mPort = port;
			mUser = user;
			mPassword = password;
			mDatabase = database;
		}

		/// <summary>
		/// Main Constructor - will instance a new <see cref="MySqlConnection"/> without Open.
		/// </summary>
		public MySqlWrapper() {
			State = EMysqlConnectionState.Closed;
			AdditionalSettings = "allowzerodatetime=yes";
		}


		#region Prepare(), Open(), Close()
		/// <summary>
		/// Tests the connection details and try to open a <see cref="MySqlConnection"/>
		/// <para>If opened successfully, its closed afterwards</para>
		/// <para>Also, if opened, the returned value will be the return from <see cref="Close"/> method</para>
		/// </summary>
		public EMysqlConnectionError Prepare() {
			ConnectionString = String.Format("SERVER={0};PORT={1};UID={2};PASSWORD={3};DATABASE={4};", mServer, mPort, mUser, mPassword, mDatabase);
			if (AdditionalSettings != "") {
				ConnectionString += ";" + AdditionalSettings;
			}
			Connection = new MySqlConnection(ConnectionString);

			EMysqlConnectionError result = Open();
			if (result == EMysqlConnectionError.None) {
				result = Close(false);
			}

			return result;
		}

		/// <summary>
		/// Opens the <see cref="MySqlConnection"/>
		/// <para>Warning: You dont need this! Just test the connection with <see cref="Prepare"/> and use the Query* Methods</para>
		/// <para>The connection will be opened and closed automatically</para>
		/// </summary>
		/// <returns></returns>
		public EMysqlConnectionError Open() {
			LastError = null;

			if (Connection == null) {
				return EMysqlConnectionError.OpenBeforeInit;
			}

			// no need to open if allready done
			if (Connection.State == ConnectionState.Open) {
				State = EMysqlConnectionState.Open;
				return EMysqlConnectionError.None;
			}

			try {
				Connection.Open();

				if (Connection.State != ConnectionState.Open) {
					State = EMysqlConnectionState.Error;
					return EMysqlConnectionError.FailedToOpen;
				}
			} catch (MySqlException e) {
				State = EMysqlConnectionState.Error;
				LastError = e;
				return EMysqlConnectionError.CanNotConnectToDB;
			} catch (Exception e) {
				State = EMysqlConnectionState.Error;
				LastError = e;
				return EMysqlConnectionError.UnknownOpen;
			}

			State = EMysqlConnectionState.Open;
			return EMysqlConnectionError.None;
		}

		/// <summary>
		/// internal method to Close an instanced Connection
		/// </summary>
		/// <param name="freeConnection"></param>
		/// <returns></returns>
		public EMysqlConnectionError Close(bool freeConnection) {
			LastError = null;

			if (Connection == null) {
				State = EMysqlConnectionState.Error;
				return EMysqlConnectionError.CloseBeforeInit;
			}

			try {
				Connection.Close();

				if (Connection.State != ConnectionState.Closed) {
					State = EMysqlConnectionState.Error;
					return EMysqlConnectionError.FailedToClose;
				}
			} catch (MySqlException e) {
				State = EMysqlConnectionState.Error;
				LastError = e;
				return EMysqlConnectionError.CanNotDisconnectFromDB;
			} catch (Exception e) {
				State = EMysqlConnectionState.Error;
				LastError = e;
				return EMysqlConnectionError.UnknownClose;
			} finally {
				// free Memory
				if (Command != null)
					Command.Dispose();
				if (Adapter != null)
					Adapter.Dispose();
				if (freeConnection && Connection != null)
					Connection.Dispose();
			}

			State = EMysqlConnectionState.Closed;
			return EMysqlConnectionError.None;
		}
		#endregion


		/// <summary>
		/// Sets a new database
		/// <para>The connection will be tested through <see cref="Prepare"/> and the result returned</para>
		/// </summary>
		/// <param name="database"></param>
		/// <returns></returns>
		public virtual EMysqlConnectionError SetDatabase(string database) {
			database = database.Trim();
			if (mDatabase.Equals(database)) {
				return EMysqlConnectionError.None;
			}

			Close(false);
			mDatabase = database;
			return Prepare();
		}


		/// <summary>
		/// Returns the MySQL LAST_INSERT_ID() Statement
		/// </summary>
		/// <returns></returns>
		public virtual int GetLastInsertID() {
			DataTable table = Query("SELECT LAST_INSERT_ID() AS id");
			if (table.Rows.Count == 0) {
				return -1;
			}

			return table.Rows[0].Field<int>("id");
		}

		#region Query Methods
		/// <summary>
		/// Executes a Query and returns the Affected Rows
		/// </summary>
		/// <param name="query"></param>
		/// <param name="arg"></param>
		/// <returns></returns>
		public virtual int QuerySimple(string query, params object[] arg) {
			query = string.Format(query, arg);

			var result = 0;
			LastError = null;
			if (query.Length == 0) {
				return result;
			}

			try {
				Open();
				Command = Connection.CreateCommand();
				Command.CommandText = query;

				result = Command.ExecuteNonQuery();
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
				LastError = ex;
				return 0;
			}

			return result;
		}

		/// <summary>
		/// Loads all Text from an File and try to Execute the Query(s)
		/// <para>Used <see cref="Encoding.Default"/></para>
		/// <para>Used <see cref="QuerySimple"/>, so the return will be the Affected Rows</para>
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns>Affected Row Count</returns>
		public virtual int QueryFromFile(string filePath) {
			return QueryFromFile(filePath, Encoding.Default);
		}

		/// <summary>
		/// Loads all Text from an File and try to Execute the Query(s)
		/// <para>Used <see cref="QuerySimple"/>, so the return will be the Affected Rows</para>
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="enc"></param>
		/// <returns>Affected Row Count</returns>
		public virtual int QueryFromFile(string filePath, Encoding enc) {
			return QuerySimple(File.ReadAllText(filePath, enc));
		}

		/// <summary>
		/// Executes a Query and Reads the first <see cref="Int32"/> Value
		/// </summary>
		/// <param name="query"></param>
		/// <param name="arg"></param>
		/// <returns>the first <see cref="Int32"/> Value ( Value > 0 )</returns>
		public virtual bool QueryBool(string query, params object[] arg) {
			query = string.Format(query, arg);

			var result = false;
			LastError = null;
			if (query.Length == 0) {
				return false;
			}

			try {
				Open();
				Command = Connection.CreateCommand();
				Command.CommandText = query;

				Reader = Command.ExecuteReader();
				while (Reader.Read()) {
					result = (Reader.GetInt32(0) > 0);
				}
				Reader.Close();
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
				LastError = ex;
				return false;
			}

			return result;
		}

		/// <summary>
		/// Executes a Query and returns all Results in a <see cref="DataTable"/>
		/// </summary>
		/// <param name="query"></param>
		/// <param name="arg"></param>
		/// <returns>
		/// DataTable withh all Results
		/// <para>NOTE: the DataTable will be empty if an Error occours</para>
		/// </returns>
		public virtual DataTable Query(string query, params object[] arg) {
			query = string.Format(query, arg);

			var result = new DataTable();
			LastError = null;
			if (query.Length == 0) {
				return result;
			}

			Open();

			Adapter = new MySqlDataAdapter {
				SelectCommand = new MySqlCommand(query, Connection)
			};
			try {
				Adapter.Fill(result);
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
				LastError = ex;
				return new DataTable();
			}

			return result;
		}
		#endregion


		/// <summary>
		/// prints all DataTypes of the Table Fields (for Debug and Tests)
		/// </summary>
		/// <param name="table"></param>
		public static void PrintTableTypes(DataTable table) {
			for (int i = 0; i < table.Columns.Count; i++) {
				Console.WriteLine("{0}: {1}", table.Columns[i].ColumnName, table.Columns[i].DataType);
			}
		}


		/// <summary>
		/// Close the connection and free all ressources
		/// </summary>
		public virtual void Dispose() {
			Close(true);
		}

		/// <summary>
		/// Close the connection and free all ressources
		/// </summary>
		void IDisposable.Dispose() {
			Dispose();
		}

	}

}
