using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using GodLesZ.Library.Network;

namespace GodLesZ.Library.AutoUpdater.Library {

	public class UpdateHandler {
		public static string VersionFileName = "_appVersion.xml";
		public static string UpdaterFileName = "_update.exe";

		public static string VersionFilePath {
			get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, VersionFileName); }
		}

		public static string UpdaterFilePath {
			get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UpdaterFileName); }
		}

		private SVersionFile mVersionFile;
		private string mUrl;


		public UpdateHandler() {
			CleanUp();
		}


		public static void CleanUp() {
			if (File.Exists(VersionFileName)) {
				try { File.Delete(VersionFileName); } catch { }
			}
			if (File.Exists(UpdaterFileName)) {
				try { File.Delete(UpdaterFileName); } catch { }
			}
		}


		public bool CheckVersion(Assembly Asm, string Url) {
			mUrl = Url;
			CleanUp();

			DownloadVersionfile();
			if (mVersionFile == null) {
				CleanUp();
				return false;
			}

			Version thisVersion = Asm.GetName().Version;
			int iThisVersion = thisVersion.ToInt();
			Version fileVersion = new Version(mVersionFile.Version);
			int iFileVersion = fileVersion.ToInt();
			if (iFileVersion <= iThisVersion) {
				CleanUp();
				return false;
			}

			return true;
		}

		public bool StartUpdate() {
			if (DownloadUpdaterExe() == false) {
				CleanUp();
				return false;
			}

			System.Diagnostics.Process.Start(UpdaterFilePath);
			return true;
		}



		private void DownloadVersionfile() {
			string fileUrl = Path.Combine(mUrl, VersionFileName);
			if (DownloadFile(fileUrl, VersionFilePath) == true) {
				XmlSerializer xml = new XmlSerializer(typeof(SVersionFile));
				using (FileStream fs = File.OpenRead(VersionFilePath))
					mVersionFile = xml.Deserialize(fs) as SVersionFile;

				return;
			}

			mVersionFile = null;
		}

		private bool DownloadUpdaterExe() {
			string fileUrl = Path.Combine(mUrl, UpdaterFileName);
			return DownloadFile(fileUrl, UpdaterFilePath);
		}

		private bool DownloadFile(string Url, string SavePath) {
			try {
				TimeoutWebClient client = new TimeoutWebClient();
				client.TimeOut = 5000;
				client.DownloadFile(Url, SavePath);

				return true;
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
				return false;
			}

		}

	}

}
