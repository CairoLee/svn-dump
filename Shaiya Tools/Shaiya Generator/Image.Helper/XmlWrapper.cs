using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace ImageHelper {

	public static class FontConverter {

		public static string ToBase64String( Font font ) {
			try {
				using( MemoryStream stream = new MemoryStream() ) {
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize( stream, font );
					return Convert.ToBase64String( stream.ToArray() );
				}
			} catch { }
			return null;
		}

		public static Font FromBase64String( string font ) {
			try {
				using( MemoryStream stream = new MemoryStream( Convert.FromBase64String( font ) ) ) {
					BinaryFormatter formatter = new BinaryFormatter();
					return formatter.Deserialize( stream ) as Font;
				}
			} catch { }
			return null;
		}

	}
}
