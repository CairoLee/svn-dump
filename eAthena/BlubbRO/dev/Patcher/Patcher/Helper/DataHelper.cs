using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GodLesZ.Library.BlubbZip.Blubb;


namespace GodLesZ.BlubbRO.Patcher {

	public class DataHelper {

		public static void ValidateInstallDir() {
			string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BlubbRO Patcher.dat");
			bool firstStart = File.Exists(filename);
			if (firstStart == true) {
				return;
			}

			// first install, reset patches
			RegHelper.PatchReset(0);
			// write "check file"
			File.WriteAllLines(filename, new string[1] { filename });
		}


		public static bool AddFiles(string APath) {
			string abPath = AppDomain.CurrentDomain.BaseDirectory;

			return UnpackFile(APath, abPath);
		}

		public static bool DeleteFile(string Filepath) {
			string abPath = "";

			if (Filepath.EndsWith("|dir") == true) {
				// its a Directory :O
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

						if (directoryName.Length > 0 && Directory.Exists(directoryName) == false)
							Directory.CreateDirectory(directoryName);
						if (theEntry.IsFile == true && File.Exists(fileName))
							File.Delete(fileName);

						if (theEntry.IsFile == true)
							using (FileStream streamWriter = File.Create(fileName)) {

								int size = 2048;
								byte[] data = new byte[2048];
								while (true) {
									if ((size = s.Read(data, 0, data.Length)) == 0)
										break;
									streamWriter.Write(data, 0, size);
								}
							}

					}

				}
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
				System.Windows.Forms.MessageBox.Show("Failed to extract Patch \"" + Path.GetFileName(APath) + "\"!\nPlease inform an Administrator about this.", "Extract Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}

			return true;
		}


	}

}
