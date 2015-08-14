using System;
using System.Collections.Generic;
using System.Text;

using ProcessEditAPI;

namespace CharnameHack {

	public class Program {

		public static void Main( string[] args ) {
			using( ProcessEdit shaiya = new ProcessEdit() ) {
				do {
					Console.WriteLine( "Please start Shaiya.." );
					System.Threading.Thread.Sleep( 1000 );
				} while( shaiya.OpenProcessAndThread( "game" ) == false );

				Console.Clear();

				Console.WriteLine( "Shaiya successful attached!" );
				Console.WriteLine( "\nPlease enter your desired Charname (the full length!)" );
				Console.Write( "Charname: " );
				string charname = Console.ReadLine();
				if( charname.Length <= 13 ) {
					Console.WriteLine( "\n\nCharname only contains " + charname.Length + " (max is 13) and is already valid!" );
				} else {
					string validCharname = charname.Substring( 0, 13 );
					string patternMask = new string( 'x', 13 ); // all chars must match!
					byte[] baCharname = System.Text.ASCIIEncoding.Default.GetBytes( validCharname );
					uint patLoc = shaiya.FindPattern( baCharname, patternMask );
					if( patLoc != 0 ) {
						string patData = "";
						if( patLoc > 0 )
							patData = shaiya.ReadASCIIString( patLoc, 13 );

#if DEBUG
						Console.WriteLine( "[Debug] Pattern Location: 0x{0:X08}", patLoc );
						Console.WriteLine( "[Debug] Pattern Data (13 chars): {0}", patData );
#endif

						Console.Write( "\ntry to update Memory with real name.." );
						if( shaiya.WriteASCIIString( patLoc, charname ) == true )
							Console.WriteLine( " success!" );
						else
							Console.WriteLine( " failed.." );
					} else {
						Console.WriteLine( "FAILED to find Namestring?" );
					}
				}

				Console.WriteLine( "\n\nPress any Key to exit" );
				Console.ReadKey();
			}

		}

	}

}
