using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace PakExtractor {

	public class Program {
		private static char[] mCursorData = "|/-\\".ToCharArray();

		public static void Main(string[] args) {
			args = new string[]{
				@"D:\Spiele\Eden Eternal\pkg\pkg007.pkg"
			};

			if (args == null || args.Length == 0) {
				Console.WriteLine("Drag some *.pkg files on me!");
				Console.ReadKey();
				return;
			}

			LoadOffzip(Environment.CurrentDirectory + "\\");
			foreach (string filepath in args) {
				ExtractPkg(Environment.CurrentDirectory + "\\", filepath);
			}

			try {
				File.Delete(Environment.CurrentDirectory + "\\offzip.exe");
			} catch { }
			Console.WriteLine(Environment.NewLine + "finished");
			Console.ReadKey();
		}


		private static void ExtractPkg(string basepath, string filepath) {
			string filename = Path.GetFileNameWithoutExtension(filepath);
			string targetDir = Path.GetDirectoryName(filepath) + @"\" + filename + @"\";
			if (Directory.Exists(targetDir) == true) {
				Directory.Delete(targetDir, true);
			}
			if (Directory.Exists(targetDir) == false) {
				Directory.CreateDirectory(targetDir);
			}

			/*
			FileInfo info = new FileInfo(filepath);
			string filenameCur = "";
			long offset = 0;
			int fileCount = 0;
			int _iteration = 0;
			do {
				try {
					using (Stream compressed = File.OpenRead(filepath)) {
						compressed.Seek(offset, SeekOrigin.Begin);
						using (MemoryStream decompressed = new MemoryStream()) {
							using (ZlibStream zlib = new ZlibStream(compressed, CompressionMode.Decompress)) {
								byte[] buf = new byte[short.MaxValue];
								int bufLength;
								while ((bufLength = zlib.Read(buf, 0, buf.Length)) > 0) {
									decompressed.Write(buf, 0, bufLength);
								}
								offset += zlib.Position;
								filenameCur = offset.ToString("X2").ToLower().PadLeft(7, '0') + ".dat";
							}
							File.WriteAllBytes(targetDir + filenameCur, decompressed.ToArray());
							fileCount++;
						}
					}
					_iteration++;
				} catch {
					break;
				}
			} while ((offset + 1) < info.Length && _iteration < 1000000);
			*/

			string output = "";

			ProcessStartInfo sInfo = new ProcessStartInfo(basepath + "offzip.exe");
			//sInfo.WindowStyle = ProcessWindowStyle.Hidden;
			sInfo.UseShellExecute = false;
			sInfo.ErrorDialog = true;
			sInfo.CreateNoWindow = true;
			sInfo.RedirectStandardOutput = true;
			sInfo.RedirectStandardError = true;
			sInfo.WorkingDirectory = Path.GetDirectoryName(filepath);
			sInfo.Arguments = "-a " + Path.GetFileName(filepath) + " " + Path.GetFileNameWithoutExtension(filepath) + " 0";

			Process p = new Process();
			p.StartInfo = sInfo;
			p.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e) {
				output += e.Data;
			};
			p.Start();
			p.BeginOutputReadLine();

			Console.Write("Extracting " + filepath + " ");
			int i = 0;
			do {
				Console.Write("{0}{1}", (i > 0 ? "\b" : ""), mCursorData[i % mCursorData.Length]);

				System.Threading.Thread.Sleep(200);
				i++;

				p.Refresh();
			} while (p.HasExited == false);
			//} while (p.HasExited == false && (p.StandardOutput.EndOfStream == false && p.StandardError.EndOfStream == false));
			Console.WriteLine("\b ");

			Console.WriteLine("Identify file types..");
			RenameFiles(targetDir);


			output += p.StandardOutput.ReadToEnd();
			output += p.StandardError.ReadToEnd();

			Console.WriteLine("#-------------------------------------------------------------#");
			if (output.Contains("no valid full zip data found") == true) {
				Console.WriteLine("- no files extracted");
			} else {
				System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex("- ([0-9]+) valid zip blocks found");
				System.Text.RegularExpressions.Match m = re.Match(output);
				if (m.Success == false) {
					Console.WriteLine("- unknown file count extracted");
				} else {
					string foundFiles = m.Groups[1].Captures[0].Value;
					Console.WriteLine("- " + foundFiles + " files extracted");
				}
			}
			//Console.WriteLine(streamData);
			Console.WriteLine("#-------------------------------------------------------------#");
		}

		private static void RenameFiles(string targetDir) {
			foreach (string filepath in Directory.GetFiles(targetDir, "*.dat")) {
				string filepathNew = Path.GetDirectoryName(filepath) + @"\" + Path.GetFileNameWithoutExtension(filepath);

				byte[] buf = new byte[short.MaxValue];
				using (FileStream fs = File.OpenRead(filepath)) {
					fs.Read(buf, 0, Math.Min(buf.Length, (int)fs.Length));
				}

				string head = Encoding.Default.GetString(buf, 0, 50);
				if (head.Substring(0, 3) == "DDS") {
					File.Copy(filepath, filepathNew + ".dds");
				} else if (head.Substring(0, 26) == ";Gamebryo KFM File Version") {
					File.Copy(filepath, filepathNew + ".kfm");
				} else if (head.Substring(0, 20) == "Gamebryo File Format") {
					File.Copy(filepath, filepathNew + ".nif");
				} else {
					continue;
				}

				File.Delete(filepath);
			}
		}




		private static void LoadOffzip(string filepath) {
			filepath = filepath + "offzip.exe";
			if (File.Exists(filepath) == true) {
				return;
			}

			Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			using (Stream stream = asm.GetManifestResourceStream("PakExtractor.Resources.offzip.exe")) {
				byte[] buf = new byte[stream.Length];
				stream.Read(buf, 0, buf.Length);

				File.WriteAllBytes(filepath, buf);
			}
		}


	}

}
