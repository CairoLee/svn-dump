using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Shaiya.Extended.Library.Utility {

	public class Tools {
		public static void EnsureDirectory( string dir ) {
			string path = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, dir );

			if( !Directory.Exists( path ) )
				Directory.CreateDirectory( path );
		}


		
		public static T ParseEnum<T>( string input ) {
			try {
				return (T)Enum.Parse( typeof( T ), input );
			} catch {
				return default( T );
			}
		}





		public static void FormatBuffer( TextWriter output, Stream input, int length ) {
			output.WriteLine( "        0  1  2  3  4  5  6  7   8  9  A  B  C  D  E  F" );
			output.WriteLine( "       -- -- -- -- -- -- -- --  -- -- -- -- -- -- -- --" );

			int byteIndex = 0;

			int whole = length >> 4;
			int rem = length & 0xF;

			for( int i = 0; i < whole; ++i, byteIndex += 16 ) {
				StringBuilder bytes = new StringBuilder( 49 );
				StringBuilder chars = new StringBuilder( 16 );

				for( int j = 0; j < 16; ++j ) {
					int c = input.ReadByte();

					bytes.Append( c.ToString( "X2" ) );

					if( j != 7 ) {
						bytes.Append( ' ' );
					} else {
						bytes.Append( "  " );
					}

					if( c >= 32 && c < 128 ) {
						chars.Append( (char)c );
					} else {
						chars.Append( '.' );
					}
				}

				output.Write( byteIndex.ToString( "X4" ) );
				output.Write( "   " );
				output.Write( bytes.ToString() );
				output.Write( "  " );
				output.WriteLine( chars.ToString() );
			}

			if( rem != 0 ) {
				StringBuilder bytes = new StringBuilder( 49 );
				StringBuilder chars = new StringBuilder( rem );

				for( int j = 0; j < 16; ++j ) {
					if( j < rem ) {
						int c = input.ReadByte();

						bytes.Append( c.ToString( "X2" ) );

						if( j != 7 ) {
							bytes.Append( ' ' );
						} else {
							bytes.Append( "  " );
						}

						if( c >= 32 && c < 128 ) {
							chars.Append( (char)c );
						} else {
							chars.Append( '.' );
						}
					} else {
						bytes.Append( "   " );
					}
				}

				output.Write( byteIndex.ToString( "X4" ) );
				output.Write( "   " );
				output.Write( bytes.ToString() );
				output.Write( "  " );
				output.WriteLine( chars.ToString() );
			}
		}




	}

}
