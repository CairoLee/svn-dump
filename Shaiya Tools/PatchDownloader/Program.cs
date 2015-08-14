using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PatchDownloader {

	public class Program {

		public static void Main( string[] args ) {
			Subroutine2();
			return;


			using( TimeoutWebclient client = new TimeoutWebclient() ) {
				string baseAddy = "http://shaiya-de.patch.aeriagames.com/Shaiya/patch/ps{0:0000}.patch";
				int i = 0;
				try {
					client.TimeOut = 3000;

					for( i = 2; i < 100; i++ ) {
						string addy = string.Format( baseAddy, i );
						client.DownloadFile( addy, AppDomain.CurrentDomain.BaseDirectory + @"\patch_" + i + ".zip" );
						Console.WriteLine( "Patch " + i + " successfull" );
					}
				} catch( Exception e ) {
					Console.WriteLine( "FAILED @ Patch " + i );
					Console.WriteLine( "\n" + e.ToString() );
					Console.ReadKey();
				}
			}


		}

		private static void Subroutine() {
			List<string> dirs = new List<string>();
			dirs.AddRange( Directory.GetDirectories( @"D:\Spiele\Shaiya Copy\patches\" ) );
			dirs.Sort( new DirComparer() );
			// got all in the right order <3
			foreach( string dir in dirs ) {
				Console.WriteLine( dir );

				string[] files = Directory.GetFiles( dir, "*.SData", SearchOption.AllDirectories );
				foreach( string file in files ) {
					string newDir = AppDomain.CurrentDomain.BaseDirectory + @"\" + Path.GetFileName( file );
					File.Copy( file, newDir, true );
				}
			}

			Console.WriteLine( "\nfinished" );
			Console.ReadKey();
		}

		private static void Subroutine2() {
			string[] files = Directory.GetFiles( AppDomain.CurrentDomain.BaseDirectory + @"\" );
			foreach( string file in files ) {
				string ext = Path.GetExtension( file );
				if( ext != ".SData" && ext != ".exe" && ext != ".pdb" )
					File.Delete( file );
			}

			Console.WriteLine( "\nfinished" );
			Console.ReadKey();
		}

	}


	public class DirComparer : IComparer<string> {

		public int Compare( string Dir1, string Dir2 ) {
			Dir1 = Dir1.Substring( Dir1.LastIndexOf( '\\' ) + 1 );
			Dir2 = Dir2.Substring( Dir2.LastIndexOf( '\\' ) + 1 );

			int num1 = int.Parse( Dir1.Replace( "patch_", "" ) );
			int num2 = int.Parse( Dir2.Replace( "patch_", "" ) );

			return num1.CompareTo( num2 );
		}

	}

}
