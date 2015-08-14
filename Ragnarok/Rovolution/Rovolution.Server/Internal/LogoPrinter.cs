using System;
using System.Collections.Generic;
using System.Text;
using GodLesZ.Library;

namespace Rovolution.Server {

	public class LogoPrinter {
		private static List<string> mLines = new List<string>();
		private static string mLogoStart = "";
		private static string mLogoEnd = "";

		public static EConsoleColor TextColor {
			get;
			set;
		}

		public static EConsoleColor PrefixColor {
			get;
			set;
		}

		public static EConsoleColor SufixColor {
			get;
			set;
		}

		public static EConsoleColor StartEndColor {
			get;
			set;
		}

		public static EConsoleColor CopyrightColor {
			get;
			set;
		}

		public static string PrefixSign {
			get;
			set;
		}

		public static string SufixSign {
			get;
			set;
		}



		public LogoPrinter() {
		}


		public static void Initialize() {
			PrefixSign = "(";
			SufixSign = ")";

			mLines.Add(@" ____                            ___             __                           ");
			mLines.Add(@"/\  _`\                         /\_ \           /\ \__  __                    ");
			mLines.Add(@"\ \ \L\ \    ___   __  __    ___\//\ \    __  __\ \ ,_\/\_\    ___     ___    ");
			mLines.Add(@" \ \ ,  /   / __`\/\ \/\ \  / __`\\ \ \  /\ \/\ \\ \ \/\/\ \  / __`\ /' _ `\  ");
			mLines.Add(@"  \ \ \\ \ /\ \L\ \ \ \_/ |/\ \L\ \\_\ \_\ \ \_\ \\ \ \_\ \ \/\ \L\ \/\ \/\ \ ");
			mLines.Add(@"   \ \_\ \_\ \____/\ \___/ \ \____//\____\\ \____/ \ \__\\ \_\ \____/\ \_\ \_\");
			mLines.Add(@"    \/_/\/ /\/___/  \/__/   \/___/ \/____/ \/___/   \/__/ \/_/\/___/  \/_/\/_/");
			mLines.Add(@"                                                                              ");
			mLines.Add(@"                                                                              ");
			mLines.Add(@"                                  by GodLesZ                                  ");

			int len = mLines[0].Length;
			mLogoStart = "";
			for (int i = 0; i < len; i += 2) {
				mLogoStart += "-=";
			}

			if (mLogoStart.Length < len) {
				mLogoStart += "-";
			} else if (mLogoStart.Length > len) {
				mLogoStart = mLogoStart.Substring(0, len);
			}
			mLogoEnd = mLogoStart;
		}


		public static void PrintLogo() {
			if (mLines.Count == 0)
				LogoPrinter.Initialize();

			PrintColoredLine(mLogoStart, PrefixColor);
			for (int i = 0; i < mLines.Count - 1; i++) {
				PrintColoredLine(mLines[i], TextColor);
			}
			PrintColoredLine(mLines[mLines.Count - 1], CopyrightColor);

			PrintColoredLine(mLogoEnd, PrefixColor);
		}

		private static void PrintColoredLine(string Text, EConsoleColor Color) {
			ServerConsole.Write(PrefixColor, PrefixSign);
			ServerConsole.Write(Color, Text);
			ServerConsole.WriteLine(SufixColor, SufixSign);
		}

	}

}
