using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace SDataDecryptTest {

	public class Program {

		public static void Main( string[] args ) {
			string dataPath = @"D:\Spiele\Shaiya\data\Cash.SData";
			int startOffset = 40;
			byte[] data;
			using( FileStream fs = File.OpenRead( dataPath ) ) {
				data = new byte[ fs.Length - startOffset ];
				fs.Seek( startOffset, SeekOrigin.Begin );
				fs.Read( data, 0, data.Length );
			}
			byte[] newData = GZipDecompress( data );

		}





		public static byte[] ReadAllBytesFromStream( Stream stream ) {
			int totalCount = 0;
			int bytesRead = 0;
			byte[] buffer = new byte[ 1024 ];

			using( MemoryStream ms = new MemoryStream() ) {
				while( true ) {
					if( ( bytesRead = stream.Read( buffer, 0, buffer.Length ) ) == 0 ) {
						break;
					}
					ms.Write( buffer, 0, bytesRead );
					totalCount += bytesRead;
				}

				ms.Position = 0;
				buffer = new byte[ (int)ms.Length ];
				ms.Read( buffer, 0, buffer.Length );
			}
			return buffer;
		}

		public static byte[] GZipDecompress( byte[] data ) {
			byte[] decompressedBuffer;
			using( MemoryStream ms = new MemoryStream( data ) ) {
				GZipStream zip = new GZipStream( ms, CompressionMode.Decompress );

				 decompressedBuffer = ReadAllBytesFromStream( zip );
			}

			return decompressedBuffer;
		}

	}
}