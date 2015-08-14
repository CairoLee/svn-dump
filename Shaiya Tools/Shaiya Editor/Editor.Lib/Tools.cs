using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor.Lib {

	public static class Tools {

		public static System.IO.MemoryStream Byte2Stream( byte[] input ) {
			return new System.IO.MemoryStream( input );
		}

	}

}
