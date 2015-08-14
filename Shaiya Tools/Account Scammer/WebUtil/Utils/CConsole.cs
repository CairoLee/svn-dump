using System;
using System.Threading;
using System.Globalization;

namespace WebUtil {

	public enum EConsoleColor {
		None = ConsoleColor.Gray,
		Status = ConsoleColor.Green,
		Info = ConsoleColor.Cyan,
		Error = ConsoleColor.Magenta,
		Debug = ConsoleColor.Cyan,
	}

	public static class CConsole {

		private static string Prefix = "[";
		private static string Sufix = "] ";
		private static bool ColoredPreSuf = true;
		private static string DateString = "[HH:mm:ss]";
		private static object mLock = new object();

		private static void WriteColored( string Text, EConsoleColor ColorPart ) {
			lock( mLock ) {
				if( DateString != null ) {
					string s = DateTime.Now.ToString( DateString, CultureInfo.CreateSpecificCulture( "de-DE" ) );
					Console.Write( s );
				}


				if( ColoredPreSuf == true )
					Text = String.Format( "{0}{1}{2}", Prefix, Text, Sufix );
				else
					Console.Write( Prefix );

				Console.ForegroundColor = (ConsoleColor)ColorPart;
				Console.Write( Text );
				Console.ResetColor();

				if( ColoredPreSuf == false )
					Console.Write( Sufix );
			}
		}



		#region Basic Write/WriteLine
		public static void Write( EConsoleColor ColorPart, string Text ) {
			Console.ForegroundColor = (ConsoleColor)ColorPart;
			Console.Write( Text );
			Console.ResetColor();
		}

		public static void Write( EConsoleColor ColorPart, string Text, params object[] args ) {
			Console.ForegroundColor = (ConsoleColor)ColorPart;
			Console.Write( String.Format( Text, args ) );
			Console.ResetColor();
		}

		public static void WriteLine( EConsoleColor ColorPart, string Text ) {
			Console.ForegroundColor = (ConsoleColor)ColorPart;
			Console.WriteLine( Text );
			Console.ResetColor();
		}

		public static void WriteLine( EConsoleColor ColorPart, string Text, params object[] args ) {
			Console.ForegroundColor = (ConsoleColor)ColorPart;
			Console.WriteLine( String.Format( Text, args ) );
			Console.ResetColor();
		}
		#endregion



		#region Status [EConsoleColor.Status]
		public static void Status( string Prefix, string Text ) {
			WriteColored( Prefix, EConsoleColor.Status );
			Console.Write( Text );
		}
		public static void Status( string Prefix, string Text, params object[] arg ) {
			WriteColored( Prefix, EConsoleColor.Status );
			Console.Write( String.Format( Text, arg ) );
		}
		public static void StatusLine( string Prefix, string Text ) {
			WriteColored( Prefix, EConsoleColor.Status );
			Console.WriteLine( Text );
		}
		public static void StatusLine( string Prefix, string Text, params object[] arg ) {
			WriteColored( Prefix, EConsoleColor.Status );
			Console.WriteLine( String.Format( Text, arg ) );
		}
		#endregion



		#region Info [EConsoleColor.Info]
		public static void Info( string Prefix, string Text ) {
			WriteColored( Prefix, EConsoleColor.Info );
			Console.Write( Text );
		}
		public static void Info( string Prefix, string Text, params object[] arg ) {
			WriteColored( Prefix, EConsoleColor.Info );
			Console.Write( String.Format( Text, arg ) );
		}
		public static void InfoLine( string Prefix, string Text ) {
			WriteColored( Prefix, EConsoleColor.Info );
			Console.WriteLine( Text );
		}
		public static void InfoLine( string Prefix, string Text, params object[] arg ) {
			WriteColored( Prefix, EConsoleColor.Info );
			Console.WriteLine( String.Format( Text, arg ) );
		}
		#endregion



		#region Error [EConsoleColor.Error]
		public static void Error( string Prefix, string Text ) {
			WriteColored( Prefix, EConsoleColor.Error );
			Console.Write( Text );
		}
		public static void Error( string Prefix, string Text, params object[] arg ) {
			WriteColored( Prefix, EConsoleColor.Error );
			Console.Write( String.Format( Text, arg ) );
		}
		public static void ErrorLine( string Prefix, string Text ) {
			WriteColored( Prefix, EConsoleColor.Error );
			Console.WriteLine( Text );
		}
		public static void ErrorLine( string Prefix, string Text, params object[] arg ) {
			WriteColored( Prefix, EConsoleColor.Error );
			Console.WriteLine( String.Format( Text, arg ) );
		}
		#endregion



		#region Debug [EConsoleColor.Debug]
		public static void Debug( string Prefix, string Text ) {
			WriteColored( Prefix, EConsoleColor.Debug );
			Console.Write( Text );
		}
		public static void Debug( string Prefix, string Text, params object[] arg ) {
			WriteColored( Prefix, EConsoleColor.Debug );
			Console.Write( String.Format( Text, arg ) );
		}
		public static void DebugLine( string Prefix, string Text ) {
			WriteColored( Prefix, EConsoleColor.Debug );
			Console.WriteLine( Text );
		}
		public static void DebugLine( string Prefix, string Text, params object[] arg ) {
			WriteColored( Prefix, EConsoleColor.Debug );
			Console.WriteLine( String.Format( Text, arg ) );
		}
		#endregion

	}

}
