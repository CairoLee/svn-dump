using System;
using System.IO;

namespace Shaiya.Extended.Server.MySql.Zlib {

	internal class ZStreamException : IOException {
		public ZStreamException() {
		}

		public ZStreamException( string s )
			: base( s ) {
		}
	}
}

