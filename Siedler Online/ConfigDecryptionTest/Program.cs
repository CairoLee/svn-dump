using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConfigDecryptionTest {

	public class Program {

		public static void Main(string[] args) {
			if (args.Length == 0) {
				Console.WriteLine("Please drop some encrypted files on me!");
				Console.WriteLine("Press any key to exit..");
				Console.Read();
				return;
			}

			foreach (string filepath in args) {
				try {
					DecryptFile(filepath);
				} catch (Exception ex) {
					Console.WriteLine("Failed!");
					Console.WriteLine(ex.Message);
				}
			}

			Console.WriteLine("-------------------------");
			Console.WriteLine("Done.");
			Console.Read();
		}

		private static void DecryptFile(string filepath) {
			Console.WriteLine("-------------------------");
			Console.WriteLine("File: " + Path.GetFileName(filepath));
			Console.WriteLine("-------------------------");
			Console.WriteLine("Encrypt as flash object? (Y/N)");
			bool isFlashObj = Console.ReadLine().Trim().ToLower() == "y";

			string filename = Path.GetFileNameWithoutExtension(filepath);

			// Base64 decode
			byte[] encodedBuf;
			using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(filepath))) {
				FromBase64Transform trans = new FromBase64Transform();
				using (CryptoStream cryptStream = new CryptoStream(ms, trans, CryptoStreamMode.Read)) {
					byte[] buf = new byte[1024];
					int read = 0;
					using (MemoryStream msResult = new MemoryStream()) {
						do {
							read = cryptStream.Read(buf, 0, buf.Length);
							if (read > 0) {
								msResult.Write(buf, 0, read);
							}
						} while (read > 0);

						encodedBuf = msResult.ToArray();
					}
				}
			}

			// Flash objects needs to be pulled via Flash Decompiler..
			if (isFlashObj) {
				string flashObjPath = Path.Combine(Directory.GetCurrentDirectory(), filename + ".swf");
				if (File.Exists(flashObjPath)) {
					File.Delete(flashObjPath);
				}
				File.WriteAllBytes(flashObjPath, encodedBuf);

				Console.WriteLine("Data exported to \"" + Path.GetFileName(flashObjPath) + "\"");
				Console.Read();
				return;
			}

			// Decrypt real XML using BlowFish algo
			string keyFromDummyAs = "O99vUyAPaGXHNo";
			using (MemoryStream streamDataEncoded = new MemoryStream(encodedBuf)) {
				var keyData = Encoding.UTF8.GetBytes(keyFromDummyAs);
				var pkcs = new PKCS5();
				var blowKey = new BlowFishKey(keyData);
				var ecbMode = new ECBMode(blowKey, pkcs);
				pkcs.BlockSize = ecbMode.BlockSize;
				byte[] bufFinal = ecbMode.Decrypt(streamDataEncoded);

				string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), filename + ".xml");
				if (File.Exists(xmlPath)) {
					File.Delete(xmlPath);
				}
				File.WriteAllBytes(xmlPath, bufFinal);
			}

		}

	}

}
