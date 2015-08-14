using System;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	public class MySqlInfoMessageEventArgs : EventArgs {
		public MySqlError[] errors;
	}
}

