using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace GodLesZ.Library.Ragnarok.Grf {

	public class Deflate {
		public static byte B1 = 0x78; // 120
		public static byte B2 = 0x9C; // 156

		public static byte[] Decompress(byte[] input) {
			if (input.Length < 3) {
				return input;
			}

			bool stripBytes = (input[0] == B1 && input[1] == B2);
			byte[] output = new byte[0];
			using (MemoryStream toDeflate = Tools.Byte2Stream(input)) {
				output = Decompress(toDeflate, stripBytes);
			}

			return output;
		}
		public static byte[] Decompress(Stream input, bool stripBytes) {
			if (stripBytes == true) {
				byte b1 = (byte)input.ReadByte(); // 0x78 | 120
				byte b2 = (byte)input.ReadByte(); // 0x9C | 156
			}

			MemoryStream output = new MemoryStream();
			using (DeflateStream Deflate = new DeflateStream(input, CompressionMode.Decompress)) {
				byte[] buffer = new byte[input.Length];
				int count = 0;

				try {
					while ((count = Deflate.Read(buffer, 0, buffer.Length)) > 0) {
						output.Write(buffer, 0, count);
					}
				} catch (Exception e) {
					System.Diagnostics.Debug.WriteLine(e);
				}
			}

			return output.ToArray();
		}

		public static byte[] Compress(byte[] input, bool addFirst2Bytes) {
			if (input.Length == 0) {
				return input;
			}


			MemoryStream output = new MemoryStream();
			if (addFirst2Bytes) {
				output.Write(new byte[] { B1, B2 }, 0, 2); // 0x78 0x9C
			}

			using (DeflateStream Deflate = new DeflateStream(output, CompressionMode.Compress)) {
				try {
					Deflate.Write(input, 0, input.Length);
				} catch (Exception e) {
					System.Diagnostics.Debug.WriteLine(e);
				}
			}

			return output.ToArray();
		}






		public static long GetDecompressedLength(byte[] input) {
			byte[] decompressedBuf = Decompress(input);
			int len = decompressedBuf.Length;
			decompressedBuf = null;

			return len;
		}

		public static long GetCompressedLength(byte[] input) {
			byte[] compressedBuf = Compress(input, true);
			int len = compressedBuf.Length;
			compressedBuf = null;

			return len;
		}

	}

}
