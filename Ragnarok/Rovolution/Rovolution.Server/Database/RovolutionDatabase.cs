using System.Data;
using GodLesZ.Library.MySql;

namespace Rovolution.Server.Database {

	/// <summary>
	/// Extends MysqlWrapper, but may be later split up into more Database types
	/// <para>to support also MSSQL and other Databas Systems</para>
	/// <para>For now its just a child of MysqlWrapper checking for exceptions after query execution</para>
	/// </summary>
	public class RovolutionDatabase : MySqlWrapper {

		public RovolutionDatabase(string server, int port, string username, string password, string database)
			: base(server, port, username, password, database) {
		}

		/// <summary>
		/// Create a ny mysql connection using the default port 3306
		/// </summary>
		/// <param name="server"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="database"></param>
		public RovolutionDatabase(string server, string username, string password, string database)
			: this(server, 3306, username, password, database) {
		}


		public DataTable Query(string query) {
			DataTable result = base.Query(query);
			if (LastError != null) {
				ServerConsole.ErrorLine(LastError.ToString());
#if !DEBUG
				Core.Kill(false);
#endif
			}

			return result;
		}

		public override DataTable Query(string query, params object[] args) {
			DataTable result = base.Query(query, args);
			if (LastError != null) {
				ServerConsole.ErrorLine(LastError.ToString());
#if !DEBUG
				Core.Kill(false);
#endif
			}

			return result;
		}

	}

}
