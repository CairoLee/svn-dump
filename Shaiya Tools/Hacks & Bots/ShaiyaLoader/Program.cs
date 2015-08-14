using System;
using System.Collections.Generic;
using System.Text;

using ProcessEditAPI;
using System.IO;
using System.Diagnostics;


namespace ShaiyaLoader {

	public class Program {

		public static void Main( string[] args ) {
			try {
				WriteInfo( "initialize Shaiya Loader.." );

				using( ProcessEdit shaiya = new ProcessEdit() ) {
					if( File.Exists( "game.exe" ) == false ) {
						WriteError( "Game.exe not found in this location?" );
						Console.ReadKey();
						return;
					}

					int tryCount = 0;
					Process p = Process.Start( "game.exe" );
					System.Threading.Thread.Sleep( 50 );
					while( shaiya.OpenProcessAndThread( p.Id ) == false && tryCount < 1000 )
						;
					if( shaiya.IsThreadOpen == false || shaiya.IsProcessOpen == false ) {
						WriteError( "failed to attach Shaiya Process.. oO" );
						p.Kill();
						Console.ReadKey();
						return;
					}

					Console.Clear();
					WriteStatus( "Shaiya Loader initialized." );


					WriteInfo( "start reading Debug Values..." );
					byte[] testBuf1 = shaiya.ReadBytes( 0x0040AB0F, 2 );
					byte[] testBuf2 = shaiya.ReadBytes( 0x0040AB33, 2 );
					byte[] testBuf3 = shaiya.ReadBytes( 0x0040AB7A, 6 );
					byte[] testBuf4 = shaiya.ReadBytes( 0x0040AE6D, 6 );

					WriteDebug( "buf1: " + HexHelper.Encode( testBuf1 ) );
					WriteDebug( "buf2: " + HexHelper.Encode( testBuf2 ) );
					WriteDebug( "buf3: " + HexHelper.Encode( testBuf3 ) );
					WriteDebug( "buf4: " + HexHelper.Encode( testBuf4 ) );

					WriteInfo( "start writing Climb Patch Values..." );
					shaiya.WriteBytes( 0x004416BA, new byte[ 6 ] { 0, 0, 0, 0, 0, 0 } );


					WriteStatus( "All Operations finished - Press any Key to exit" );
					Console.ReadKey();
				}
			} catch( Exception e ) {
				WriteError( "Exception thrown!\n\n" );
				Console.WriteLine( e );
				Console.ReadKey();
			}
		}


		private static void WriteStatus( string Text ) {
			CConsole.WriteColored( "Status", EConsoleColor.Status );
			Console.WriteLine( Text );
		}

		private static void WriteInfo( string Text ) {
			CConsole.WriteColored( "Info", EConsoleColor.Info );
			Console.WriteLine( Text );
		}

		private static void WriteDebug( string Text ) {
			CConsole.WriteColored( "Debug", EConsoleColor.Debug );
			Console.WriteLine( Text );
		}

		private static void WriteError( string Text ) {
			CConsole.WriteColored( "Error", EConsoleColor.Error );
			Console.WriteLine( Text );
		}

	}

}
