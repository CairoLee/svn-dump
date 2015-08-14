using System.Drawing;
using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.Gat {

	public class RoGatFile : GenericFileFormat {
		public const string FormatExtension = ".gat";

		public int Width {
			get;
			private set;
		}

		public int Height {
			get;
			private set;
		}

		public RoGatCell[] Cells {
			get;
			private set;
		}

		public char[] MagicHead {
			get;
			set;
		}


		public RoGatFile(byte[] data)
			: base() {
			using (MemoryStream ms = new MemoryStream(data)) {
				Read(ms);
			}
		}


		protected override bool ReadInternal() {
			Width = -1;
			Height = -1;

			MagicHead = Reader.ReadChars(6); // GRAT..
			if (MagicHead[0] != 'G' || MagicHead[1] != 'R' || MagicHead[2] != 'A' || MagicHead[3] != 'T') {
				return false;
			}

			Width = Reader.ReadInt32();
			Height = Reader.ReadInt32();
			Cells = new RoGatCell[Width * Height];

			for (int i = 0; i < Cells.Length; i++) {
				Cells[i] = new RoGatCell(
					Reader.ReadSingle(),
					Reader.ReadSingle(),
					Reader.ReadSingle(),
					Reader.ReadSingle(),
					Reader.ReadByte()
				);
				Reader.BaseStream.Position += 3; // 3x unknown Char
			}

			return true;
		}


		public Bitmap DrawImage(Color[] Colors) {
			if (Width < 1 || Height < 1) {
				return null;
			}

			Bitmap Image = new Bitmap(Width, Height);
			FastBitmap fastBmp = new FastBitmap(Image);

			using (Graphics g = Graphics.FromImage(Image)) {

				fastBmp.LockImage();
				for (int y = 0, i = 0; y < Height; y++) {
					for (int x = 0; x < Width; x++) {
						fastBmp.SetPixel(x, y, Colors[(int)Cells[i++].Type]);
					}
				}
				fastBmp.UnlockImage();
			}

			return Image;
		}

	}

}
