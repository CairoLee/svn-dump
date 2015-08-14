using System;
using System.Collections.Generic;
using System.IO;

namespace NDSExtractor.Library {

	public class NDSFile : NDSFileEntry {
		private BinaryReader mReader;

		private uint mHeadOffset;
		private uint mHeadSize;
		private uint mDataOffset;
		private uint mDataSize;
		private uint mHighestOffset;


		public NDSFile(string filepath) : base() {
			using (FileStream fs = new FileStream(filepath, FileMode.Open)) {
				using (mReader = new BinaryReader(fs)) {
					mReader.BaseStream.Seek(64, SeekOrigin.Begin);
					mHeadOffset = mReader.ReadUInt32();
					mHeadSize = mReader.ReadUInt32();
					mDataOffset = mReader.ReadUInt32();
					mDataSize = mReader.ReadUInt32();

					NDSFileEntry root = LoadDir("Root", /*0xf000*/61440, 0);
					
				}
			}

		}

		private NDSFileEntry LoadDir(string DirName, ushort DirID, ushort Parent) {
			long position = mReader.BaseStream.Position;
			NDSFileEntry root = new NDSFileEntry();

			mReader.BaseStream.Seek(mHeadOffset + (8 * (DirID & /*0xfff*/4095)), SeekOrigin.Begin);
			uint num2 = mReader.ReadUInt32();
			ushort num3 = mReader.ReadUInt16();
			mReader.ReadUInt16();

			root.ID = DirID;
			root.Name = DirName;
			root.Offset = num2;
			root.Size = 0;

			mReader.BaseStream.Seek((long)(mHeadOffset + num2), SeekOrigin.Begin);
			ushort fileID = num3;
			while (true) {
				byte num5 = (byte)mReader.ReadByte();
				byte stringLength = (byte)(num5 & 127);
				if (stringLength == 0) {
					break;
				}
				string dirName = new String(mReader.ReadChars(stringLength));
				if (num5 > 127) {
					ushort dirID = mReader.ReadUInt16();
					root.Files.Add(dirID, LoadDir(dirName, dirID, DirID));
				} else {
					root.Files.Add(LoadFile(dirName, fileID, DirID));
				}
				fileID++;
			}

			mReader.BaseStream.Seek(position, SeekOrigin.Begin);

			return root;
		}

		private NDSFileEntry LoadFile(string FileName, ushort FileID, ushort Parent) {
			long position = mReader.BaseStream.Position;

			mReader.BaseStream.Seek(mHeadOffset + (FileID * 8), SeekOrigin.Begin);
			uint num2 = mReader.ReadUInt32();
			uint num3 = mReader.ReadUInt32();

			var file = new NDSFileEntry {
				ID = FileID,
				Name = FileName,
				Offset = num2,
				Size = (num3 - num2),
			};
			if (num3 > mHighestOffset) {
				mHighestOffset = num3;
			}

			mReader.BaseStream.Seek(position, SeekOrigin.Begin);

			return file;
		}

	}

}
