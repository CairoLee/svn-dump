using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Editor.Lib;

namespace MassExtractor {

	public class Program {

		public static void Main( string[] args ) {
			string[] dirs = Directory.GetDirectories( @"D:\Spiele\Shaiya Copy\patches\" );
			foreach( string dir in dirs ) {
				string subdir = dir.Substring( dir.LastIndexOf( '\\' ) +1 );
				Console.Write( "parse dir " + subdir + "..." );

				if( File.Exists( dir + @"\update.sah" ) == false ) {
					Console.WriteLine( "\n\tNO DATA FOUND - delete dir..." );
					Directory.Delete( dir );
					continue;
				}

				ShaiyaData data = new ShaiyaData( dir + @"\update.sah" );
				if( data.ExtractAll( dir ) == false ) {
					Console.WriteLine( "\n\tfailed to extract Data or some of the Files.. abort deleting" );
					data.Dispose();
					continue;
				}
				Console.WriteLine( " extracted " + data.Files.Count + " Files" );
				data.Dispose();

				// delte update Files
				File.Delete( dir + @"\update.sah" );
				File.Delete( dir + @"\update.saf" );
			}

			Console.WriteLine( "\n\nfinished" );
			Console.ReadKey();

		}




	}

}
