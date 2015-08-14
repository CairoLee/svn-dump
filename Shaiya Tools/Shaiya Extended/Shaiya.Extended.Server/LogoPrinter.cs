using System;
using System.Collections.Generic;
using System.Text;

using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server {

	public class LogoPrinter {
		private static EConsoleColor mTextColor = EConsoleColor.None;
		private static EConsoleColor mPrefixColor = EConsoleColor.None;
		private static EConsoleColor mSufixColor = EConsoleColor.None;
		private static EConsoleColor mStartEndColor = EConsoleColor.None;
		private static string mPrefixSign = "(";
		private static string mSufixSign = ")";

		private static List<string> mLines = new List<string>();
		private static int mCurrentLine = 0;
		private static string mLogoStart = "";
		private static string mLogoEnd = "";

		public static EConsoleColor TextColor {
			get { return mTextColor; }
			set { mTextColor = value; }
		}

		public static EConsoleColor PrefixColor {
			get { return mPrefixColor; }
			set { mPrefixColor = value; }
		}

		public static EConsoleColor SufixColor {
			get { return mSufixColor; }
			set { mSufixColor = value; }
		}

		public static EConsoleColor StartEndColor {
			get { return mStartEndColor; }
			set { mStartEndColor = value; }
		}

		public static string PrefixSign {
			get { return mPrefixSign; }
			set { mPrefixSign = value; }
		}

		public static string SufixSign {
			get { return mSufixSign; }
			set { mSufixSign = value; }
		}



		public LogoPrinter() {
		}


		public static void Initialize() {
			mLines.Add( @"   _____ __          _                 ______      __                 __          __" );
			mLines.Add( @"  / ___// /_  ____ _(_)__  ______ _   / ____/_  __/ /____  ____  ____/ /___  ____/ /" );
			mLines.Add( @"  \__ \/ __ \/ __ `/ // / / / __ `/  / __/  | |/_/ __/ _ \/ __ \/ __  // _ \/ __  / " );
			mLines.Add( @" ___/ / / / / /_/ / // /_/ / /_/ /_ / /___ _>  </ /_/  __/ / / / /_/ //  __/ /_/ /  " );
			mLines.Add( @"/____/_/ /_/\__,_/_/ \__, /\__,_/(_)_____//_/|_|\__/\___/_/ /_/\__,_/ \___/\__,_/   " );
			mLines.Add( @"                    /____/                                                          " );
			mLines.Add( @"                                 by GodLesZ & r0xy.                                 " );

			int len = mLines[ 0 ].Length;
			mLogoStart = "";
			for( int i = 0; i < len; i += 2 )
				mLogoStart += "-=";
			if( mLogoStart.Length < len )
				mLogoStart += "-";
			else if( mLogoStart.Length > len )
				mLogoStart = mLogoStart.Substring( 0, len );
			mLogoEnd = mLogoStart;
		}


		public static void PrintLogo() {
			if( mLines.Count == 0 )
				LogoPrinter.Initialize();

			PrintColoredLine( mLogoStart, mPrefixColor );
			while( PrintNextLine() )
				;
			PrintColoredLine( mLogoEnd, mPrefixColor );
		}



		private static bool PrintNextLine() {
			if( mCurrentLine >= mLines.Count )
				return false;

			PrintColoredLine( mLines[ mCurrentLine++ ], mTextColor );
			return true;
		}

		private static void PrintColoredLine( string Text, EConsoleColor Color ) {
			CConsole.Write( mPrefixColor, mPrefixSign );
			CConsole.Write( Color, Text );
			CConsole.WriteLine( mSufixColor, mSufixSign );
		}

	}

}
