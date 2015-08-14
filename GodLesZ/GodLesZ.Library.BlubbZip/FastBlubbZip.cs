using System;
using System.Collections.Generic;
using System.IO;
using GodLesZ.Library.BlubbZip.Blubb;
using GodLesZ.Library.BlubbZip.Checksums;

namespace GodLesZ.Library.BlubbZip {

	[Flags()]
	public enum EFastBlubbZipLoadType {
		Streams = 1,
		FileList = 2,
		Entrys = 4,

		All = (EFastBlubbZipLoadType.Streams | EFastBlubbZipLoadType.FileList | EFastBlubbZipLoadType.Entrys)
	}

	public static class FastBlubbZip {
		private static readonly Crc32 crc = new Crc32();

		public static void FetchAllFromFile(string blubbzipFilePath, string blubbzipPassword, EFastBlubbZipLoadType loadType, out Dictionary<int, Stream> StreamList, out Dictionary<int, string> FileList, out Dictionary<int, BlubbZipEntry> EntryList) {
			FileList = new Dictionary<int, string>();
			StreamList = new Dictionary<int, Stream>();
			EntryList = new Dictionary<int, BlubbZipEntry>();

			if (File.Exists(blubbzipFilePath) == false)
				throw new Exception("File not Found!\n" + blubbzipFilePath);

			using (FileStream fs = File.OpenRead(blubbzipFilePath)) {
				BlubbZipFile blubb = new BlubbZipFile(fs);
				blubb.Password = blubbzipPassword;

				for (int cz = 0; cz < blubb.Count; cz++) {
					if (blubb[cz].IsFile == false)
						continue;
					if ((loadType & EFastBlubbZipLoadType.Streams) > 0)
						StreamList.Add(cz, blubb.GetInputStream(cz));
					if ((loadType & EFastBlubbZipLoadType.FileList) > 0)
						FileList.Add(cz, blubb[cz].Name.ToString().Replace("/", @"\"));
					if ((loadType & EFastBlubbZipLoadType.Entrys) > 0)
						EntryList.Add(cz, blubb[cz].Clone() as BlubbZipEntry);
				}

				blubb.Close();
			}

		}

		public static void FetchAllFromFile(string blubbzipFilePath, string blubbzipPassword, out Dictionary<int, Stream> Streams) {
			Dictionary<int, string> tempFileList;
			Dictionary<int, BlubbZipEntry> tempEntryList;

			FetchAllFromFile(blubbzipFilePath, blubbzipPassword, EFastBlubbZipLoadType.Streams, out Streams, out tempFileList, out tempEntryList);
		}


		public static void FetchAllFromFile(string blubbzipFilePath, string blubbzipPassword, out Dictionary<int, string> FileList) {
			Dictionary<int, Stream> tempStreamList;
			Dictionary<int, BlubbZipEntry> tempEntryList;

			FetchAllFromFile(blubbzipFilePath, blubbzipPassword, EFastBlubbZipLoadType.Streams, out tempStreamList, out FileList, out tempEntryList);
		}


		public static void FetchAllFromFile(string blubbzipFilePath, string blubbzipPassword, out Dictionary<int, BlubbZipEntry> EntryList) {
			Dictionary<int, Stream> tempStreamList;
			Dictionary<int, string> tempFileList;

			FetchAllFromFile(blubbzipFilePath, blubbzipPassword, EFastBlubbZipLoadType.Streams, out tempStreamList, out tempFileList, out EntryList);
		}



		public static MemoryStream FetchFromFile(string blubbzipFilePath, string blubbzipPassword, int entryIndex) {
			using (FileStream fs = File.OpenRead(blubbzipFilePath)) {
				BlubbZipFile blubb = new BlubbZipFile(fs);
				blubb.Password = blubbzipPassword;

				Stream s = blubb.GetInputStream(entryIndex);
				MemoryStream Writer = new MemoryStream();
				byte[] data = new byte[4096];
				int size = s.Read(data, 0, data.Length);

				while (size > 0) {
					Writer.Write(data, 0, size);
					size = s.Read(data, 0, data.Length);
				}

				blubb.Close();
				return Writer;
			}

		}

		public static MemoryStream[] FetchListFromFile(string fromZip, string Password, int[] list) {
			using (FileStream fs = File.OpenRead(fromZip)) {
				BlubbZipFile blubb = new BlubbZipFile(fs);
				blubb.Password = Password;

				MemoryStream[] Streams = new MemoryStream[list.Length];
				int counter = 0;
				foreach (int index in list) {
					Stream s = blubb.GetInputStream(index);
					MemoryStream Writer = new MemoryStream();
					byte[] data = new byte[4096];
					int size = s.Read(data, 0, data.Length);

					while (size > 0) {
						Writer.Write(data, 0, size);
						size = s.Read(data, 0, data.Length);
					}

					Streams[counter++] = Writer;
				}
				blubb.Close();

				return Streams;
			}

		}



		public static void CreateBlubbZip(string destinationFilepath, string blubbzipPassword, string[] contentFilenames, Stream[] contentData) {
			using (FileStream filStream = File.OpenWrite(destinationFilepath)) {
				using (MemoryStream ms = CreateBlubbZip(blubbzipPassword, contentFilenames, contentData)) {
					ms.WriteTo(filStream);
				}
			}

		}

		public static void CreateBlubbZip(string destinationFilepath, string blubbzipPassword, string contetnFilename, Stream contentData) {
			CreateBlubbZip(destinationFilepath, blubbzipPassword, new string[] { contetnFilename }, new Stream[] { contentData });
		}

		public static MemoryStream CreateBlubbZip(string blubbzipPassword, string[] contentFilenames, Stream[] contentData) {
			MemoryStream saveStream = new MemoryStream();
			using (MemoryStream tempStream = new MemoryStream()) {
				using (BlubbZipOutputStream outputStream = new BlubbZipOutputStream(tempStream)) {
					try {
						outputStream.Password = blubbzipPassword;
						outputStream.SetLevel(9);

						for (int i = 0; i < contentData.Length; i++) {
							ZipStream("", contentFilenames[i], contentData[i], outputStream);
						}

					} catch (Exception e) {
						System.Diagnostics.Debug.WriteLine(e);
					} finally {
						if (outputStream != null)
							outputStream.Finish(); // don't close, will close also underlying Stream!
					}

					tempStream.WriteTo(saveStream);
				}
			}

			return saveStream;
		}

		public static MemoryStream CreateBlubbZip(string blubbzipPassword, string contentFilename, Stream contentData) {
			return CreateBlubbZip(blubbzipPassword, new string[] { contentFilename }, new Stream[] { contentData });
		}


		public static Dictionary<string, Stream> ExtractBlubbZip(Stream blubbzipStream, string blubbzipPassword) {
			Dictionary<string, Stream> streams = new Dictionary<string, Stream>();

			BlubbZipInputStream zipStream = new BlubbZipInputStream(blubbzipStream);
			try {
				zipStream.Password = blubbzipPassword;

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

		public static Dictionary<string, Stream> ExtractBlubbZip(string blubbzipFilepath, string blubbzipPassword) {
			Dictionary<string, Stream> streams;
			using (FileStream fileStream = File.OpenRead(blubbzipFilepath)) {
				streams = ExtractBlubbZip(fileStream, blubbzipPassword);
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
			BlubbZipEntry entry = new BlubbZipEntry(BlubbZipEntry.CleanName(Tools.PatchKnownProblems(Tools.MakePathRelative(sourceFolder, fileName))));

			streamData.Seek(0, SeekOrigin.Begin);

			entry.DateTime = DateTime.Now;
			entry.Size = streamData.Length;

			outputStream.PutNextEntry(entry);
			crc.Reset();
			while ((readCount = streamData.Read(buffer, 0, buffer.Length)) > 0) {
				crc.Update(buffer, 0, readCount);
				outputStream.Write(buffer, 0, readCount);
			}

			entry.Crc = crc.Value;
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
