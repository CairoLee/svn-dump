using System;
using System.Threading;
using System.Globalization;

namespace ShaiyaLoader {

	/// <summary>
	/// Console Color Array
	/// </summary>
	public enum EConsoleColor {
		/// <summary>
		/// Basic Gray Color
		/// </summary>
		None = ConsoleColor.Gray,
		/// <summary>
		/// Lime Green Color
		/// </summary>
		Status = ConsoleColor.Green,
		/// <summary>
		/// Bright White Color
		/// </summary>
		Info = ConsoleColor.White,
		/// <summary>
		/// Bright Magenta Color
		/// </summary>
		Error = ConsoleColor.Magenta,
		/// <summary>
		/// Bright Cyan Color
		/// </summary>
		Debug = ConsoleColor.Cyan,


		// ConsoleColor orgin
		DarkBlue = ConsoleColor.DarkBlue,
		DarkGreen = ConsoleColor.DarkGreen,
		DarkCyan = ConsoleColor.DarkCyan,
		DarkRed = ConsoleColor.DarkRed,
		DarkMagenta = ConsoleColor.DarkMagenta,
		DarkYellow = ConsoleColor.DarkYellow,
		DarkGray = ConsoleColor.DarkGray,
		Blue = ConsoleColor.Blue,
		Red = ConsoleColor.Red,
		Yellow = ConsoleColor.Yellow,

		Black = ConsoleColor.Black,
	}


	/// <summary>
	/// Console Class overwrite to allow colored output
	/// </summary>
	public static class CConsole {

		private static EConsoleColor mBackgroundColor = EConsoleColor.Black;
		private static string mPrefix = "[";
		private static string mSufix = "] ";
		private static bool mColoredPreSuf = true;
		private static string mDateString = "[HH:mm:ss]";
		private static Mutex mConsoleMutex = new Mutex( false, "ConsoleMutex" );


		public static EConsoleColor BackgroundColor {
			get { return mBackgroundColor; }
			set {
				mBackgroundColor = value;
				System.Console.BackgroundColor = (ConsoleColor)value;
			}
		}
		/// <summary>
		/// Status Prefix
		/// </summary>
		public static string Prefix {
			get { return mPrefix; }
			set { mPrefix = value; }
		}
		/// <summary>
		/// Status Sufix
		/// </summary>
		public static string Sufix {
			get { return mSufix; }
			set { mSufix = value; }
		}
		/// <summary>
		/// Using Prefix/Sufix
		/// </summary>
		public static bool ColoredPreSuf {
			get { return mColoredPreSuf; }
			set { mColoredPreSuf = value; }
		}
		/// <summary>
		/// String to Format the DateTime
		/// </summary>
		public static string DateString {
			get { return mDateString; }
			set { mDateString = value; }
		}
		/// <summary>
		/// Mutex to allow Multi-Threaded access
		/// </summary>
		public static Mutex Mutex {
			get { return mConsoleMutex; }
		}



		public static void WriteColored( string Text, EConsoleColor ColorPart ) {
			mConsoleMutex.WaitOne();
			if( DateString != null ) {
				string s = DateTime.Now.ToString( DateString, CultureInfo.CreateSpecificCulture( "de-DE" ) );
				System.Console.Write( s );
			}


			if( ColoredPreSuf == true )
				Text = String.Format( "{0}{1}{2}", Prefix, Text, Sufix );
			else
				System.Console.Write( Prefix );

			System.Console.ForegroundColor = (ConsoleColor)ColorPart;
			System.Console.Write( Text );
			System.Console.ResetColor();
			System.Console.BackgroundColor = (ConsoleColor)mBackgroundColor;

			if( ColoredPreSuf == false )
				System.Console.Write( Sufix );
			mConsoleMutex.ReleaseMutex();
		}



		#region base Method defines
		public static void Write( object Object ) {
			System.Console.Write( Object );
		}

		public static void Write( string Text ) {
			System.Console.Write( Text );
		}

		public static void Write( string Text, params object[] args ) {
			System.Console.Write( string.Format( Text, args ) );
		}

		public static void WriteLine( object Object ) {
			System.Console.WriteLine( Object );
		}

		public static void WriteLine( string Text ) {
			System.Console.WriteLine( Text );
		}

		public static void WriteLine( string Text, params object[] args ) {
			System.Console.WriteLine( string.Format( Text, args ) );
		}

		public static int Read() {
			return System.Console.Read();
		}
		#endregion


		#region basic colored Write/WriteLine
		public static void Write( EConsoleColor ColorPart, string Text ) {
			System.Console.ForegroundColor = (ConsoleColor)ColorPart;
			System.Console.Write( Text );
			System.Console.ResetColor();
			System.Console.BackgroundColor = (ConsoleColor)mBackgroundColor;
		}

		public static void Write( EConsoleColor ColorPart, string Text, params object[] args ) {
			System.Console.ForegroundColor = (ConsoleColor)ColorPart;
			System.Console.Write( String.Format( Text, args ) );
			System.Console.ResetColor();
			System.Console.BackgroundColor = (ConsoleColor)mBackgroundColor;
		}

		public static void WriteLine( EConsoleColor ColorPart, string Text ) {
			System.Console.ForegroundColor = (ConsoleColor)ColorPart;
			System.Console.WriteLine( Text );
			System.Console.ResetColor();
			System.Console.BackgroundColor = (ConsoleColor)mBackgroundColor;
		}

		public static void WriteLine( EConsoleColor ColorPart, string Text, params object[] args ) {
			System.Console.ForegroundColor = (ConsoleColor)ColorPart;
			System.Console.WriteLine( String.Format( Text, args ) );
			System.Console.ResetColor();
			System.Console.BackgroundColor = (ConsoleColor)mBackgroundColor;
		}
		#endregion

		#region Status [EConsoleColor.Status]
		public static void Status( string Text ) {
			WriteColored( "State", EConsoleColor.Status );
			System.Console.Write( Text );
		}
		public static void Status( string Text, params object[] arg ) {
			WriteColored( "State", EConsoleColor.Status );
			System.Console.Write( String.Format( Text, arg ) );
		}
		public static void StatusLine( string Text ) {
			WriteColored( "State", EConsoleColor.Status );
			System.Console.WriteLine( Text );
		}
		public static void StatusLine( string Text, params object[] arg ) {
			WriteColored( "State", EConsoleColor.Status );
			System.Console.WriteLine( String.Format( Text, arg ) );
		}
		#endregion

		#region Info [EConsoleColor.Info]
		public static void Info( string Text ) {
			WriteColored( "Info", EConsoleColor.Info );
			System.Console.Write( Text );
		}
		public static void Info( string Text, params object[] arg ) {
			WriteColored( "Info", EConsoleColor.Info );
			System.Console.Write( String.Format( Text, arg ) );
		}
		public static void InfoLine( string Text ) {
			WriteColored( "Info", EConsoleColor.Info );
			System.Console.WriteLine( Text );
		}
		public static void InfoLine( string Text, params object[] arg ) {
			WriteColored( "Info", EConsoleColor.Info );
			System.Console.WriteLine( String.Format( Text, arg ) );
		}
		#endregion

		#region Error [EConsoleColor.Error]
		public static void Error( string Text ) {
			WriteColored( "Error", EConsoleColor.Error );
			System.Console.Write( Text );
		}
		public static void Error( string Text, params object[] arg ) {
			WriteColored( "Error", EConsoleColor.Error );
			System.Console.Write( String.Format( Text, arg ) );
		}
		public static void ErrorLine( string Text ) {
			WriteColored( "Error", EConsoleColor.Error );
			System.Console.WriteLine( Text );
		}
		public static void ErrorLine( string Text, params object[] arg ) {
			WriteColored( "Error", EConsoleColor.Error );
			System.Console.WriteLine( String.Format( Text, arg ) );
		}
		#endregion

		#region Debug [EConsoleColor.Debug]
		public static void Debug( string Text ) {
			WriteColored( "Debug", EConsoleColor.Debug );
			System.Console.Write( Text );
		}
		public static void Debug( string Text, params object[] arg ) {
			WriteColored( "Debug", EConsoleColor.Debug );
			System.Console.Write( String.Format( Text, arg ) );
		}
		public static void DebugLine( string Text ) {
			WriteColored( "Debug", EConsoleColor.Debug );
			System.Console.WriteLine( Text );
		}
		public static void DebugLine( string Text, params object[] arg ) {
			WriteColored( "Debug", EConsoleColor.Debug );
			System.Console.WriteLine( String.Format( Text, arg ) );
		}
		#endregion

	}

}
