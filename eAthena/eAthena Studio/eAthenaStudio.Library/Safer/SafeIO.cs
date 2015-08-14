using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using GodLesZ.Library.Logging;

namespace eAthenaStudio.Library {

	public static class SafeIo {
		public static bool DefaultSilent = false;
		private static ILog mLogger;


		public static void Initialize(ILog log) {
			mLogger = log;
		}

		#region DeleteFile
		public static bool DeleteFile(string Filepath) {
			return DeleteFile(Filepath, DefaultSilent);
		}

		public static bool DeleteFile(string Filepath, bool Silent) {
			if (!File.Exists(Filepath))
				return true;
			try {
				File.Delete(Filepath);
				return true;
			} catch (Exception ex) {
				if (Silent == false)
					MsgHelper.Error("Fehler beim löschen", "Konnte die Datei \"" + Path.GetFileName(Filepath) + "\" nicht löschen.\n\n" + ex);
				else
					mLogger.Error("Konnte die Datei \"" + Path.GetFileName(Filepath) + "\" nicht löschen.\n\n" + ex);
				return false;
			}
		}
		#endregion

		#region CreateFile
		public static bool CreateFile(string Filepath) {
			return CreateFile(Filepath, DefaultSilent);
		}

		public static bool CreateFile(string Filepath, bool Silent) {
			if (File.Exists(Filepath))
				return true;
			try {
				File.Create(Filepath).Dispose();
				return true;
			} catch (Exception ex) {
				if (Silent == false)
					MsgHelper.Error("Fehler beim erstellen", "Konnte die Datei \"" + Path.GetFileName(Filepath) + "\" nicht erstellen.\n\n" + ex);
				else
					mLogger.Error("Konnte die Datei \"" + Path.GetFileName(Filepath) + "\" nicht erstellen.\n\n" + ex);
				return false;
			}
		}
		#endregion


		#region DeleteFolder
		public static bool DeleteFolder(string Dirpath) {
			return DeleteFolder(Dirpath, true, false);
		}

		public static bool DeleteFolder(string Dirpath, bool Silent) {
			return DeleteFolder(Dirpath, true, Silent);
		}

		public static bool DeleteFolder(string Dirpath, bool Recursive, bool Silent) {
			if (!Directory.Exists(Dirpath))
				return true;
			try {
				Directory.Delete(Dirpath, Recursive);
				return true;
			} catch (Exception ex) {
				if (Silent == false)
					MsgHelper.Error("Fehler beim löschen", "Konnte den Ordner \"" + Dirpath + "\" nicht löschen.\n\n" + ex);
				else
					mLogger.Error("Konnte den Ordner \"" + Dirpath + "\" nicht löschen.\n\n" + ex);
				return false;
			}
		}
		#endregion

		#region CreateFolder
		public static bool CreateFolder(string Filepath) {
			return CreateFolder(Filepath, DefaultSilent);
		}

		public static bool CreateFolder(string Dirpath, bool Silent) {
			if (Directory.Exists(Dirpath))
				return true;
			try {
				Directory.CreateDirectory(Dirpath);
				return true;
			} catch (Exception ex) {
				if (Silent == false)
					MsgHelper.Error("Fehler beim erstellen", "Konnte den Ordner \"" + Dirpath + "\" nicht erstellen.\n\n" + ex);
				else
					mLogger.Error("Konnte den Ordner \"" + Dirpath + "\" nicht erstellen.\n\n" + ex);
				return false;
			}
		}
		#endregion

	}

}
