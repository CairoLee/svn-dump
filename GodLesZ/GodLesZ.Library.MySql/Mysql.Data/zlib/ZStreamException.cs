using System;
using System.IO;

namespace GodLesZ.Library.MySql.Zlib {

	internal class ZStreamException : IOException {
		public ZStreamException() {
		}

		public ZStreamException(string s)
			: base(s) {
		}
	}
}

