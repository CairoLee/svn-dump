using System;
using System.IO;
using GodLesZ.FunRO.Patcher.Patches;
using GodLesZ.Library.BlubbZip.Blubb;


namespace GodLesZ.FunRO.Patcher {

	public class DataHelper {

		public static bool AddFiles(ClientPatch patch) {
			string abPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

			return UnpackFile(patch.FilePath, abPath);
		}

		public static bool DeleteFile(string Filepath) {
			string abPath = "";

			if (Filepath.EndsWith("|dir") == true) {
				// It's a folder
				abPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Filepath.Substring(0, Filepath.IndexOf("|dir")));
				if (Directory.Exists(abPath) == true)
					try {
						Directory.Delete(abPath, true);
					} catch {
						return false;
					}
				return true;
			}

			abPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Filepath);
			if (File.Exists(abPath) == true) {
				try {
					File.Delete(abPath);
				} catch {
					return false;
				}
			}
			return true;
		}



		private static bool UnpackFile(string APath, string BasePath) {
			try {
				using (BlubbZipInputStream s = new BlubbZipInputStream(File.OpenRead(APath))) {

					BlubbZipEntry theEntry;
					while ((theEntry = s.GetNextEntry()) != null) {
						string fileName = Path.Combine(BasePath, theEntry.Name);
						string directoryName = Path.GetDirectoryName(fileName);

						if (directoryName.Length > 0 && Directory.Exists(directoryName) == false) {
							Directory.CreateDirectory(directoryName);
						}
						if (theEntry.IsFile == true && File.Exists(fileName)) {
							File.Delete(fileName);
						}

						if (theEntry.IsFile == true)
							using (FileStream streamWriter = File.Create(fileName)) {

								int size = 2048;
								byte[] data = new byte[2048];
								while (true) {
									if ((size = s.Read(data, 0, data.Length)) == 0) {
										break;
									}
									streamWriter.Write(data, 0, size);
								}
							}

					}

				}
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
				return false;
			}

			return true;
		}


	}

}
