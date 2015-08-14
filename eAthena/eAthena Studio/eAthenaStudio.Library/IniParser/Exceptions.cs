using System;

namespace eAthenaStudio.Library.IniParser {

	public class ParsingException : Exception {

		public ParsingException() {
		}

		public ParsingException(string msg)
			: base(msg) {
		}

		public ParsingException(string msg, Exception innerException)
			: base(msg, innerException) {
		}

	}

}
