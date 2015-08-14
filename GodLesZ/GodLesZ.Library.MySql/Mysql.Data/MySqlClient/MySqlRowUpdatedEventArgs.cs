using System.Data;
using System.Data.Common;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	public sealed class MySqlRowUpdatedEventArgs : RowUpdatedEventArgs {
		public MySqlRowUpdatedEventArgs(DataRow row, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
			: base(row, command, statementType, tableMapping) {
		}

		new public MySqlCommand Command {
			get { return (MySqlCommand)base.Command; }
		}

	}

}

