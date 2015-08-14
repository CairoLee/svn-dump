using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HeadRename {

	public class Program {
		const string Folder_M = @"D:\Desktop\insane_sprite\data\sprite\ÀÎ°£Á·\¸Ó¸®Åë\³²\";
		const string Folder_F = @"D:\Desktop\insane_sprite\data\sprite\ÀÎ°£Á·\¸Ó¸®Åë\¿©\";
		const string Folder_New = @"D:\Desktop\insane_sprite\new_sprite\head\";

		public static void Main( string[] args ) {
			string[] files;

			files = Directory.GetFiles( Folder_M, "*.spr" );
			for( int i = 0; i < files.Length; i++ ) {
				string newPath = Folder_New + Path.GetFileNameWithoutExtension( files[ i ] ).Replace( "_³²", "" );
				File.Copy( files[ i ], newPath + "_m.spr" );
				File.Copy( files[ i ].Replace( ".spr", "" ) + ".act", newPath + "_m.act" );
			}

			files = Directory.GetFiles( Folder_F, "*.spr" );
			for( int i = 0; i < files.Length; i++ ) {
				string newPath = Folder_New + Path.GetFileNameWithoutExtension( files[ i ] ).Replace( "_¿©", "" );
				File.Copy( files[ i ], newPath + "_f.spr" );
				File.Copy( files[ i ].Replace( ".spr", "" ) + ".act", newPath + "_f.act" );
			}

			Console.WriteLine( "done" );
			Console.Read();

		}

	}

}
