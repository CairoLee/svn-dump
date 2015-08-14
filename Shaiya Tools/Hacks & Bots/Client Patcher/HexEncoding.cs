using System;
using System.Text;

namespace ClientPatcher {

	public class Hex {
		private static int HexRangeMin = Convert.ToInt32( 'A' );
		private static int HexRangeMax = Convert.ToInt32( '0' );

		public static byte[] Decode( string hexString ) {
			string newString = hexString;
			if( newString.Length % 2 != 0 ) 
				newString = newString.Substring( 0, newString.Length - 1 );

			int byteLength = newString.Length / 2;
			byte[] bytes = new byte[ byteLength ];
			for( int i = 0, j = 0; i < byteLength; i++, j += 2 )
				bytes[ i ] = SingleHexToByte( new String( new Char[] { newString[ j ], newString[ j + 1 ] } ) );

			return bytes;
		}

		public static string Encode( byte[] bytes ) {
			string hexString = "";
			for( int i = 0; i < bytes.Length; i++ ) {
				hexString += bytes[ i ].ToString( "X2" );
			}
			return hexString;
		}
	
		public static byte SingleHexToByte( string hex ) {
			if( hex.Length != 2 )
				throw new ArgumentException( "The String has to be 2 Bytes!", "hex" );
			if( Hex.IsHexString( hex ) == false )
				throw new ArgumentException( "\"" + hex + "\" is not a valid Hex String!", "hex" );

			return byte.Parse( hex, System.Globalization.NumberStyles.HexNumber );
		}



		public static bool IsHexString( string String ) {
			foreach( char c in String ) {
				if( IsHexDigit( c ) == false )
					return false;
			}
			return true;
		}

		private static bool IsHexDigit( char c ) {
			int numChar = Convert.ToInt32( char.ToUpper( c ) );

			if( numChar >= HexRangeMin && numChar < ( HexRangeMin + 6 ) )
				return true;
			if( numChar >= HexRangeMax && numChar < ( HexRangeMax + 10 ) )
				return true;

			return false;
		}

	}
}
