using System.Data;
using System.Data.Common;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	public sealed class MySqlRowUpdatingEventArgs : RowUpdatingEventArgs {
		public MySqlRowUpdatingEventArgs(DataRow row, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
			: base(row, command, statementType, tableMapping) {
		}

		new public MySqlCommand Command {
			get { return (MySqlCommand)base.Command; }
			set { base.Command = value; }
		}
	}
}

