using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using GodLesZ.Library.BlubbZip.Checksums;
using GodLesZ.Library.BlubbZip.Blubb;

namespace FreeWorld.Engine {

	public static class BlubbZipHelper {
		private static readonly Crc32 mCrc = new Crc32();

		public static void FetchAllFromFile(string fileName, string password, EBlubbZipHelperLoadType loadType, out Dictionary<int, Stream> streamList, out Dictionary<int, string> fileList, out Dictionary<int, BlubbZipEntry> entryList) {
			fileList = new Dictionary<int, string>();
			streamList = new Dictionary<int, Stream>();
			entryList = new Dictionary<int, BlubbZipEntry>();

			if (File.Exists(fileName) == false)
				throw new Exception("File not Found!\n" + fileName);

			using (FileStream fs = File.OpenRead(fileName)) {
				BlubbZipFile blubb = new BlubbZipFile(fs);
				blubb.Password = password;

				for (int cz = 0; cz < blubb.Count; cz++) {
					if (blubb[cz].IsFile == false)
						continue;
					if ((loadType & EBlubbZipHelperLoadType.Streams) > 0)
						streamList.Add(cz, blubb.GetInputStream(cz));
					if ((loadType & EBlubbZipHelperLoadType.FileList) > 0)
						fileList.Add(cz, blubb[cz].Name.ToString(CultureInfo.InvariantCulture).Replace("/", @"\"));
					if ((loadType & EBlubbZipHelperLoadType.Entrys) > 0)
						entryList.Add(cz, blubb[cz].Clone() as BlubbZipEntry);
				}

				blubb.Close();
			}

		}

		public static void FetchAllFromFile(string fileName, string password, out Dictionary<int, Stream> streams) {
			Dictionary<int, string> tempFileList;
			Dictionary<int, BlubbZipEntry> tempEntryList;

			FetchAllFromFile(fileName, password, EBlubbZipHelperLoadType.Streams, out streams, out tempFileList, out tempEntryList);
		}


		public static void FetchAllFromFile(string fileName, string password, out Dictionary<int, string> fileList) {
			Dictionary<int, Stream> tempStreamList;
			Dictionary<int, BlubbZipEntry> tempEntryList;

			FetchAllFromFile(fileName, password, EBlubbZipHelperLoadType.Streams, out tempStreamList, out fileList, out tempEntryList);
		}


		public static void FetchAllFromFile(string fileName, string password, out Dictionary<int, BlubbZipEntry> entryList) {
			Dictionary<int, Stream> tempStreamList;
			Dictionary<int, string> tempFileList;

			FetchAllFromFile(fileName, password, EBlubbZipHelperLoadType.Streams, out tempStreamList, out tempFileList, out entryList);
		}



		public static Stream GetFileStream(string fromZip, string password, int index) {
			using (FileStream fs = File.OpenRead(fromZip)) {
				BlubbZipFile blubb = new BlubbZipFile(fs);
				blubb.Password = password;

				Stream s = blubb.GetInputStream(index);
				Stream writer = new MemoryStream();
				byte[] data = new byte[4096];
				int size = s.Read(data, 0, data.Length);

				while (size > 0) {
					writer.Write(data, 0, size);
					size = s.Read(data, 0, data.Length);
				}

				blubb.Close();
				return writer;
			}

		}

		public static Stream[] GetFileStreams(string fromZip, string password, int[] list) {
			using (FileStream fs = File.OpenRead(fromZip)) {
				BlubbZipFile blubb = new BlubbZipFile(fs);
				blubb.Password = password;

				Stream[] streams = new Stream[list.Length];
				int counter = 0;
				foreach (int index in list) {
					Stream s = blubb.GetInputStream(index);
					Stream writer = new MemoryStream();
					byte[] data = new byte[4096];
					int size = s.Read(data, 0, data.Length);

					while (size > 0) {
						writer.Write(data, 0, size);
						size = s.Read(data, 0, data.Length);
					}

					streams[counter++] = writer;
				}
				blubb.Close();

				return streams;
			}

		}



		public static void CreateBlubbZip(string SaveToFile, string Password, string[] FileNames, Stream[] Entrys) {
			using (FileStream filStream = File.OpenWrite(SaveToFile)) {
				using (BlubbZipOutputStream outputStream = new BlubbZipOutputStream(filStream)) {
					try {
						outputStream.Password = Password;
						outputStream.SetLevel(9);

						for (int i = 0; i < Entrys.Length; i++) {
							ZipStream("", FileNames[i], Entrys[i], outputStream);
						}

					} catch (Exception e) {
						System.Diagnostics.Debug.WriteLine(e);
					} finally {
						if (outputStream != null)
							outputStream.Finish(); // don't close, will close also underlying Stream!
					}
				}
			}

		}

		public static void CreateBlubbZip(string SaveToFile, string Password, string FileName, Stream Entry) {
			CreateBlubbZip(SaveToFile, Password, new string[] { FileName }, new Stream[] { Entry });
		}

		public static Stream CreateBlubbZip(string Password, string[] FileNames, Stream[] Entrys) {
			Stream SaveStream = new MemoryStream();
			using (BlubbZipOutputStream outputStream = new BlubbZipOutputStream(SaveStream)) {
				try {
					outputStream.Password = Password;
					outputStream.SetLevel(9);

					for (int i = 0; i < Entrys.Length; i++) {
						ZipStream("", FileNames[i], Entrys[i], outputStream);
					}

				} catch (Exception e) {
					System.Diagnostics.Debug.WriteLine(e);
				} finally {
					if (outputStream != null)
						outputStream.Finish(); // don't close, will close also underlying Stream!
				}
			}

			return SaveStream;
		}

		public static Stream CreateBlubbZip(string Password, string FileName, Stream Entry) {
			return CreateBlubbZip(Password, new string[] { FileName }, new Stream[] { Entry });
		}

		public static void CreateBlubbZip(Stream SaveToStream, string Password, string[] FileNames, Stream[] Entrys) {
			BlubbZipOutputStream outputStream = new BlubbZipOutputStream(SaveToStream);
			try {
				outputStream.Password = Password;
				outputStream.SetLevel(9);

				for (int i = 0; i < Entrys.Length; i++) {
					ZipStream("", FileNames[i], Entrys[i], outputStream);
				}

			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
			} finally {
				if (outputStream != null)
					outputStream.Finish(); // don't close, will close also underlying Stream!
			}

		}

		public static void CreateBlubbZip(Stream Stream, string Password, string FileName, Stream Entry) {
			CreateBlubbZip(Stream, Password, new string[] { FileName }, new Stream[] { Entry });
		}



		public static Dictionary<string, Stream> ExtractBlubbZip(Stream FromStream, string Password) {
			Dictionary<string, Stream> streams = new Dictionary<string, Stream>();

			BlubbZipInputStream zipStream = new BlubbZipInputStream(FromStream);
			try {
				zipStream.Password = Password;

				BlubbZipEntry entry;
				byte[] buff = new byte[65536];
				while ((entry = zipStream.GetNextEntry()) != null) {
					if (entry.IsDirectory) {
						while (zipStream.Read(buff, 0, buff.Length) > 0) { }
					} else {
						streams.Add(entry.Name, ExtractStream(zipStream, entry.Size));
					}
				}
			} finally {
				zipStream.Close();
			}

			return streams;
		}

		public static Dictionary<string, Stream> ExtractBlubbZip(string FileName, string Password) {
			Dictionary<string, Stream> streams;
			using (FileStream fileStream = File.OpenRead(FileName)) {
				streams = ExtractBlubbZip(fileStream, Password);
				fileStream.Close();
			}

			return streams;
		}


		#region CreateBlubbZip Helper
		private static void ZipFile(string sourceFolder, string fileName, BlubbZipOutputStream outputStream) {
			using (FileStream fileStream = File.OpenRead(fileName)) {
				ZipStream(sourceFolder, fileName, fileStream, outputStream);

				fileStream.Close();
			}
		}

		public static void ZipStream(string sourceFolder, string fileName, Stream streamData, BlubbZipOutputStream outputStream) {
			if (streamData.CanRead == false || streamData.CanSeek == false)
				return;

			byte[] buffer = new byte[65535];
			int readCount;
			BlubbZipEntry entry = new BlubbZipEntry(BlubbZipEntry.CleanName(GodLesZ.Library.BlubbZip.Tools.PatchKnownProblems(GodLesZ.Library.BlubbZip.Tools.MakePathRelative(sourceFolder, fileName))));

			streamData.Seek(0, SeekOrigin.Begin);

			entry.DateTime = DateTime.Now;
			entry.Size = streamData.Length;

			outputStream.PutNextEntry(entry);
			mCrc.Reset();
			while ((readCount = streamData.Read(buffer, 0, buffer.Length)) > 0) {
				mCrc.Update(buffer, 0, readCount);
				outputStream.Write(buffer, 0, readCount);
			}

			entry.Crc = mCrc.Value;
		}

		private static long SizeOf(Stream[] streams) {
			long size = 0;
			for (int i = 0; i < streams.Length; i++)
				size += streams[i].Length;
			return size;
		}

		#endregion

		#region ExtractBlubbZip Helper
		private static Stream ExtractStream(Stream stream, long uncompressedSize) {
			if (!stream.CanRead || stream.Length <= 0)
				return Stream.Null;

			MemoryStream memStream = new MemoryStream();
			try {
				byte[] buff = new byte[65536];
				int res;
				if (uncompressedSize > 0) {
					while ((res = stream.Read(buff, 0, buff.Length)) > 0) {
						memStream.Write(buff, 0, res);
					}
				}
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
			}

			return memStream;
		}
		#endregion

	}

}
