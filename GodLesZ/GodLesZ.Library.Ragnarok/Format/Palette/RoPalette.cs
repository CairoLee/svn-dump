using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.Palette {

	public class RoPalette : GenericFileFormat, IList<Color> {
		public const string FormatExtension = ".pal";
		public const int ColorCount = 256;

		private List<Color> mColors;

		public bool PaletteChanged {
			get;
			internal set;
		}

		public Color this[int index] {
			get { return mColors[index]; }
			set { mColors[index] = value; }
		}


		public RoPalette(byte[] data)
			: base() {
			using (MemoryStream ms = new MemoryStream(data)) {
				Read(ms);
			}
		}

		public RoPalette(Stream stream)
			: base(stream) {
		}

		public RoPalette(string filepath)
			: base(filepath) {
		}

		public RoPalette() :
			base() {
		}


		protected override bool ReadInternal() {
			if (mColors != null) {
				Clear();
			} else {
				mColors = new List<Color>(ColorCount);
			}

			for (int i = 0; i < ColorCount; i++) {
				byte r = (byte)Reader.ReadByte();
				byte g = (byte)Reader.ReadByte();
				byte b = (byte)Reader.ReadByte();
				byte a = (byte)Reader.ReadByte();
				Add(Color.FromArgb(255 - a, r, g, b));
			}

			return true;
		}


		public override bool Write(string destinationPath) {
			if (base.Write(destinationPath) == false) {
				return false;
			}

			for (int i = 0; i < ColorCount; i++) {
				Writer.Write(this[i].R);
				Writer.Write(this[i].G);
				Writer.Write(this[i].B);
				Writer.Write(this[i].A);
			}

			return true;
		}


		public void CreateColorChart(int rectSize, Stream stream) {
			int SizeX = (16 * rectSize);
			int SizeY = (16 * rectSize);
			int index = 0;
			using (Bitmap img = new Bitmap(SizeX, SizeY)) {
				using (Graphics g = Graphics.FromImage(img)) {
					Font font = new Font(FontFamily.GenericSerif.Name, 8.0f);
					Brush brush = Brushes.Black;
					Brush brushAlt = Brushes.White;

					for (int y = 0; y < SizeY; y += rectSize) {
						for (int x = 0; x < SizeX; x += rectSize) {
							Rectangle rect = new Rectangle(x, y, (x + rectSize), (y + rectSize));
							Pen p = new Pen(this[index], 1);
							index++;

							g.FillRectangle(p.Brush, rect);

							SizeF indexSize = g.MeasureString(index.ToString(), font);
							int sx = (x + (rectSize / 2) - (int)(indexSize.Width / 2f));
							int sy = (y + (rectSize / 2) - (int)(indexSize.Height / 2f));
							if (p.Color.R < 30 && p.Color.G < 30 && p.Color.B < 30) {
								g.DrawString(index.ToString(), font, brushAlt, new Point(sx, sy));
							} else {
								g.DrawString(index.ToString(), font, brush, new Point(sx, sy));
							}
						}
					}

					img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
				}
			}
		}

		public void CreateColorChart(int rectSize, string Filepath) {
			using (FileStream fs = File.OpenWrite(Filepath)) {
				CreateColorChart(rectSize, fs);
			}
		}

		public void ApplyPalette(string filePath) {
			var pal = new RoPalette(filePath);
			Clear();
			AddRange(pal);
		}


		#region IList Implementation
		public void Add(Color col) {
			mColors.Add(col);
		}

		public void AddRange(IEnumerable<Color> col) {
			mColors.AddRange(col);
		}

		public int IndexOf(Color item) {
			return mColors.IndexOf(item);
		}

		public void Insert(int index, Color item) {
			mColors.Insert(index, item);
		}

		public void RemoveAt(int index) {
			mColors.RemoveAt(index);
		}


		public void Clear() {
			mColors.Clear();
		}

		public bool Contains(Color item) {
			return mColors.Contains(item);
		}

		public void CopyTo(Color[] array, int arrayIndex) {
			mColors.CopyTo(array, arrayIndex);
		}

		public int Count {
			get { return mColors.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public bool Remove(Color item) {
			return mColors.Remove(item);
		}

		public IEnumerator<Color> GetEnumerator() {
			return mColors.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return mColors.GetEnumerator();
		}
		#endregion

	}

}
