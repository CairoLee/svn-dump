using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace GodLesZ.Library.Captcha {

	public class CaptchaKiller {
		private static object mutex = new object();


		public CaptchaKiller() {
		}


		public static string OCR(Bitmap image) {
			string tempPath = Path.GetTempPath() + @"\temp.png";
			image.Save(tempPath, System.Drawing.Imaging.ImageFormat.Png);

			string ocrString = OCR(tempPath);
			try {
				File.Delete(tempPath);
			} catch { }

			return ocrString;
		}

		public static string OCR(string filename) {
			string str2;
			object obj2;
			Monitor.Enter(obj2 = mutex);
			try {
				string str;

				string workingDirectory = Path.GetTempPath();
				if (File.Exists(workingDirectory + @"\tesseract.exe") == false) {
					using (Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("GodLesZ.Library.Captcha.tesseract.exe")) {
						byte[] buf = new byte[s.Length];
						s.Read(buf, 0, buf.Length);
						File.WriteAllBytes(workingDirectory + @"\tesseract.exe", buf);
					}
				}
				Run("tesseract.exe", Path.GetFileName(filename) + " tesseract-output", workingDirectory, 0);

				using (FileStream stream = new FileStream(workingDirectory + @"\tesseract-output.txt", FileMode.Open)) {
					str = new StreamReader(stream).ReadToEnd();
				}
				try {
					File.Delete(workingDirectory + @"\tesseract-output.txt");
				} catch { }
				try {
					File.Delete(workingDirectory + @"\tesseract.exe");
				} catch { }

				str = str.Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
				if (str.Length == 0) {
					return null;
				}
				str2 = str;
			} catch (ThreadAbortException) {
				throw;
			} catch (Exception) {
				str2 = null;
			} finally {
				Monitor.Exit(obj2);
			}
			return str2;
		}


		private static string Run(string exeName, string argsLine, string workingDirectory, int timeoutSeconds) {
			string str2;
			StreamReader @null = StreamReader.Null;
			try {
				Process process = new Process {
					StartInfo = {
						FileName = exeName,
						Arguments = argsLine,
						WorkingDirectory = workingDirectory,
						UseShellExecute = false,
						CreateNoWindow = true,
						RedirectStandardOutput = true
					}
				};

				process.Start();

				if (timeoutSeconds == 0) {
					string str = process.StandardOutput.ReadToEnd();
					process.WaitForExit();
					return str;
				}
				if (!process.WaitForExit(timeoutSeconds * 1000)) {
					throw new ApplicationException("process timed out");
				}
				@null = process.StandardOutput;
				str2 = @null.ReadToEnd();
			} catch (Exception exception) {
				throw new ApplicationException("CaptchaBreaker failed: " + exception.Message, exception);
			} finally {
				@null.Close();
			}

			return str2;
		}

	}

}
