using System;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	[StructLayout(LayoutKind.Sequential)]
	internal struct ScriptStatement {
		public string text;
		public int line;
		public int position;
	}
}

