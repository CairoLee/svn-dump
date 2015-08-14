using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Editor.Lib {

	public class Deflate {

		public static byte[] Decompress( byte[] input ) {
			MemoryStream output = new MemoryStream();
			using( MemoryStream toDeflate = Tools.Byte2Stream( input ) ) {
				byte b1 = (byte)toDeflate.ReadByte();
				byte b2 = (byte)toDeflate.ReadByte();

				using( DeflateStream Deflate = new DeflateStream( toDeflate, CompressionMode.Decompress ) ) {

					byte[] buffer = new byte[ input.Length ];
					int count = 0;

					while( ( count = Deflate.Read( buffer, 0, buffer.Length ) ) > 0 )
						output.Write( buffer, 0, count );
				}
			}

			return output.ToArray();
		}

		public static byte[] Compress( byte[] input, bool addFirst2Bytes ) {
			MemoryStream output = new MemoryStream();
			output.Write( new byte[] { 120, 156 }, 0, 2 );

			using( DeflateStream Deflate = new DeflateStream( output, CompressionMode.Compress ) ) {
				Deflate.Write( input, 0, input.Length );
			}

			return output.ToArray();
		}

	}

}
