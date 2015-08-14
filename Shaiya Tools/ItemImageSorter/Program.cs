using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ItemImageSorter {

	class Program {
		private static FileListComparer fileListComparer;

		static void Main( string[] args ) {
			string searchDir = @"D:\Desktop\C# Projects\Shaiya Tools\MarketTool\armor\";
			string newDir = searchDir + @"_new_\";
			if( Directory.Exists( newDir ) )
				Directory.Delete( newDir, true );
			List<string> dirs = new List<string>( Directory.GetDirectories( searchDir ) );
			Directory.CreateDirectory( newDir );

			dirs.Sort();

			fileListComparer = new FileListComparer();
			for( int i = 0, f = 0; i < dirs.Count; i++ ) {
				string dirBase = dirs[ i ].Substring( dirs[ i ].LastIndexOf( '\\' ) + 1 );
				List<string> files = new List<string>( Directory.GetFiles( dirs[ i ], "*.png" ) );
				files.Sort( fileListComparer );
				for( int ii = 0; ii < files.Count; ii++, f++ ) {
					CopyFile( files[ ii ], newDir, "Icon_" + dirBase + "_" + f );
				}
			}

		}

		private static void CopyFile( string Filename, string NewDir, string NewName ) {
			string newFilename = NewDir + NewName + Path.GetExtension( Filename );

			File.Copy( Filename, newFilename );
		}

	}


	public class FileListComparer : IComparer<string> {

		public int Compare( string x, string y ) {
			string number1 = x.Substring( x.LastIndexOf( "icon-" ) + 5 ).Replace( ".png", "" );
			string number2 = y.Substring( y.LastIndexOf( "icon-" ) + 5 ).Replace( ".png", "" );

			int ix = int.Parse( number1 );
			int iy = int.Parse( number2 );

			int result = ix.CompareTo( iy );
			return result;
		}

	}



}
