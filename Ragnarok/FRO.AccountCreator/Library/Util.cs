using System.Text;
using System.IO;
using System.IO.Compression;

namespace FRO.AccountCreator.Library {

	public class Util {

		public static byte[] StringToByteArray( string str ) {
			return Encoding.Default.GetBytes( str );
		}

		public static string ByteArrayToString( byte[] arr ) {
			return Encoding.Default.GetString( arr );
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

		public static string GZipDecompress( string StringData ) {
			byte[] data = StringToByteArray( StringData );
			using( MemoryStream ms = new MemoryStream() ) {
				ms.Write( data, 0, data.Length );
				ms.Position = 0;
				GZipStream zip = new GZipStream( ms, CompressionMode.Decompress );

				byte[] decompressedBuffer = ReadAllBytesFromStream( zip );

				StringData = ByteArrayToString( decompressedBuffer ).TrimEnd( new char[] { '\0' } );
				decompressedBuffer = null;
			}

			return StringData;
		}

	}
}
