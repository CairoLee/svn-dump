using System;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class CharacterSet {
		public int byteCount;
		public string name;

		public CharacterSet(string name, int byteCount) {
			this.name = name;
			this.byteCount = byteCount;
		}
	}
}

