using System;
using System.Collections.Generic;
using System.Text;

using ProcessEditAPI;

namespace MemoryBot {

	public class Program {

		public static void Main( string[] args ) {
			InjectTest.Inject();
			return;
			/*

			WriteStatus( "initialize Shaiya Memory Bot.." );

			ProcessEdit shaiya = new ProcessEdit();
			do {
				WriteStatus( "Please start Shaiya." );
				Console.CursorTop--;
				System.Threading.Thread.Sleep( 150 );
			} while( shaiya.OpenProcessAndThread( "game" ) == false );

			Console.Clear();

			WriteStatus( "Shaiya Memory Bot initialized." );

			// 00707054 [no-freeze]



			Console.ReadKey();
			shaiya.Dispose();
			shaiya = null;
			*/
		}






		private static void WriteStatus( string Text ) {
			CConsole.WriteColored( "Status", EConsoleColor.Status );
			Console.WriteLine( Text );
		}

		private static void WriteInfo( string Text ) {
			CConsole.WriteColored( "Info", EConsoleColor.Info );
			Console.WriteLine( Text );
		}

	}

}
