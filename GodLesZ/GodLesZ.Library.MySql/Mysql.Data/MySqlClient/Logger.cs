using System;
using System.Diagnostics;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class Logger {
		private Logger() {
		}

		public static void LogCommand(DBCmd cmd, string text) {
			WriteLine(string.Format("Executing command {0} with text ='{1}'", cmd, text));
		}

		public static void LogException(Exception ex) {
			WriteLine(string.Format("EXCEPTION: " + ex.Message, new object[0]));
		}

		public static void LogInformation(string msg) {
			Trace.WriteLine(msg);
		}

		public static void LogWarning(string s) {
			WriteLine("WARNING:" + s);
		}

		public static void Write(string s) {
			Trace.Write(s);
		}

		public static void WriteLine(string s) {
			Trace.WriteLine(string.Format("[{0}] - {1}", DateTime.Now, s));
		}
	}
}

