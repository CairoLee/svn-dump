using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Logging;

namespace eAthenaStudio.Library {

	public static class MsgHelper {
		private static ILog mLogger;


		public static void Initialize(ILog log) {
			mLogger = log;
		}


		public static void Error(string title, string message) {
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			mLogger.Error(string.Format("[{0}] {1}", title, message));
		}

		public static void Error(string Message) {
			Error("Fehler", Message);
		}


		public static void Info(string Title, string Message) {
			MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
			mLogger.Info(string.Format("[{0}] {1}", Title, Message));
		}

		public static void Info(string Message) {
			Info("Information", Message);
		}


		public static void Warn(string Title, string Message) {
			MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			mLogger.Warn(string.Format("[{0}] {1}", Title, Message));
		}

		public static void Warn(string Message) {
			Warn("Warnung", Message);
		}

	}

}
