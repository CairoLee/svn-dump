using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using GodLesZ.Library.Compression;
using GodLesZ.Library.Formats;
using GodLesZ.Library.Ragnarok.Palette;

namespace GodLesZ.Library.Ragnarok.Sprite {

	public class RoSprite : GenericFileFormat {
		public const string FormatExtension = ".spr";

		public char[] MagicHead {
			get;
			protected set;
		}

		public virtual List<RoSpriteImagePal> ImagesPal {
			get;
			protected set;
		}

		public virtual List<RoSpriteImageRgba> ImagesRgba {
			get;
			protected set;
		}

		public virtual List<RoSpriteImage> Images {
			get {
				var images = new List<RoSpriteImage>();
				if (ImagesPal != null) {
					images.AddRange(ImagesPal.Cast<RoSpriteImage>());
				}
				if (ImagesRgba != null) {
					images.AddRange(ImagesRgba.Cast<RoSpriteImage>());
				}
				return images;
			}
		}

		public RoPalette Palette {
			get;
			protected set;
		}

		public virtual RoSpriteImage this[int index, bool rgba] {
			get {
				if (rgba) {
					if (index < 0 || index >= ImagesRgba.Count) {
						throw new ArgumentOutOfRangeException("index", "RGBA Index is out of range: " + index);
					}
					return ImagesRgba[index];
				} else {
					if (index < 0 || index >= ImagesPal.Count) {
						throw new ArgumentOutOfRangeException("index", "PAL Index is out of range: " + index);
					}
					return ImagesPal[index];
				}
			}
		}

		public virtual RoSpriteImage this[int index] {
			get {
				if (index < 0) {
					throw new ArgumentOutOfRangeException("index", "Index is out of range: " + index);
				}

				// Try to identify pal or rgba using index
				if (ImagesPal != null && index >= ImagesPal.Count) {
					index -= ImagesPal.Count;
					return this[index, true];
				}

				return this[index, false];
			}
		}


		public RoSprite(byte[] data)
			: base() {
			using (MemoryStream ms = new MemoryStream(data)) {
				Read(ms);
			}
		}

		public RoSprite(Stream stream)
			: base(stream) {
		}

		public RoSprite(string filepath)
			: base(filepath) {
		}

		public RoSprite() :
			base() {
		}



		protected override bool ReadInternal() {
			ImagesPal = new List<RoSpriteImagePal>();
			ImagesRgba = new List<RoSpriteImageRgba>();
			Palette = new RoPalette();

			MagicHead = Reader.ReadChars(2);
			if (MagicHead[0] != 0x53 || MagicHead[1] != 0x50) {
				// Invalid header
				return false;
			}
			Version = new GenericFileFormatVersion(Reader);
			if (Version.Major > 2) {
				// Unsupported version
				return false;
			}

			int imgPalCount = Reader.ReadUInt16();
			int imgRgbaCount = 0;
			if (Version >= 0x201) {
				imgRgbaCount = Reader.ReadUInt16();
			}

			// Images - Palette \\
			RoSpriteImagePal imgPal;
			for (int i = 0; i < imgPalCount; i++) {
				imgPal = new RoSpriteImagePal() {
					Width = Reader.ReadUInt16(),
					Height = Reader.ReadUInt16()
				};
				if (Version >= 0x201) {
					imgPal.Size = Reader.ReadUInt16();
				} else {
					imgPal.Size = (ushort)(imgPal.Width * imgPal.Height);
				}
				imgPal.Data = Reader.ReadBytes(imgPal.Size);

				ImagesPal.Add(imgPal);
			}

			// Images - RGBA \\
			RoSpriteImageRgba imgRgba;
			for (int i = 0; i < imgRgbaCount; i++) {
				imgRgba = new RoSpriteImageRgba() {
					Width = Reader.ReadUInt16(),
					Height = Reader.ReadUInt16()
				};

				int size = (imgRgba.Width * imgRgba.Height * 4);
				imgRgba.Data = Reader.ReadBytes(size);

				ImagesRgba.Add(imgRgba);
			}

			// Palette \\
			Reader.BaseStream.Position = (Reader.BaseStream.Length - (4 * RoPalette.ColorCount));

			Palette.Read(Reader.BaseStream);

			Flush();
			return true;
		}

		public override bool Write(string filePath, bool overwrite) {
			return base.Write(filePath, overwrite);
		}


		public virtual void ResetImages() {
			for (int i = 0; i < ImagesPal.Count; i++) {
				ImagesPal[i].Image = null;
			}
			for (int i = 0; i < ImagesRgba.Count; i++) {
				ImagesRgba[i].Image = null;
			}
		}


		public bool DrawPalImage(int imageIndex) {
			if (ImagesPal == null || ImagesPal.Count <= imageIndex) {
				return false;
			}
			if (imageIndex < 0 || imageIndex >= ImagesPal.Count) {
				return false;
			}

			RoSpriteImagePal sprImg = ImagesPal[imageIndex];
			if (Version >= 0x201 && sprImg.Decoded == false) {
				sprImg.Data = RLE.Decode(sprImg.Data);
				sprImg.Decoded = true;
			}
			if (sprImg.Data == null || sprImg.Data.Length == 0 || sprImg.Width < 1 || sprImg.Height < 1) {
				return false;
			}

			sprImg.Image = new Bitmap(sprImg.Width, sprImg.Height);
			FastBitmap fb = new FastBitmap(sprImg.Image);

			int index;
			fb.LockImage();
			for (int x = 0; x < sprImg.Width; x++) {
				for (int y = 0; y < sprImg.Height; y++) {
					index = (x + (y * sprImg.Width));
					if (index >= sprImg.Data.Length) {
						fb.SetPixel(x, y, Color.Transparent);
						continue;
					}
					fb.SetPixel(x, y, Palette[sprImg.Data[index]]);
				}
			}
			fb.UnlockImage();

			return true;
		}

		public bool DrawRgbaImage(int imageIndex) {
			if (ImagesRgba == null || ImagesRgba.Count <= imageIndex) {
				return false;
			}
			if (imageIndex < 0 || imageIndex >= ImagesRgba.Count) {
				return false;
			}

			RoSpriteImageRgba sprImg = ImagesRgba[imageIndex];
			if (sprImg == null || sprImg.Data == null || sprImg.Data.Length == 0 || sprImg.Width < 1 || sprImg.Height < 1) {
				return false;
			}

			sprImg.Image = new Bitmap(sprImg.Width, sprImg.Height);
			FastBitmap fb = new FastBitmap(sprImg.Image);

			int index = 0, alpha = 0, red = 0, green = 0, blue = 0;
			Color col;
			fb.LockImage();
			for (int y = 0; y < sprImg.Height; y++) {
				for (int x = 0; x < sprImg.Width; x++, index += 4) {
					// A B G R
					alpha = sprImg.Data[index];
					blue = sprImg.Data[index + 1];
					green = sprImg.Data[index + 2];
					red = sprImg.Data[index + 3];
					col = Color.FromArgb(alpha, red, green, blue);
					fb.SetPixel(x, y, col);
				}
			}
			fb.UnlockImage();

			return true;
		}

		public bool DrawImage(int imageIndex) {
			if (imageIndex < 0) {
				return false;
			}

			// Try to identify pal or rgba using index
			if (ImagesPal != null && imageIndex >= ImagesPal.Count) {
				imageIndex -= ImagesPal.Count;
				return DrawRgbaImage(imageIndex);
			}

			return DrawPalImage(imageIndex);
		}


		public bool IsDrawnPal(int imageIndex) {
			return (ImagesPal != null && ImagesPal.Count > imageIndex && ImagesPal[imageIndex].Image != null);
		}

		public bool IsDrawnRgba(int imageIndex) {
			return (ImagesRgba != null && ImagesRgba.Count > imageIndex && ImagesRgba[imageIndex].Image != null);
		}

		public bool IsDrawn(int imageIndex) {
			if (imageIndex < 0) {
				return false;
			}

			// Try to identify pal or rgba using index
			if (ImagesPal != null && imageIndex >= ImagesPal.Count) {
				imageIndex -= ImagesPal.Count;
				return IsDrawnRgba(imageIndex);
			}

			return IsDrawnPal(imageIndex);
		}


		public void AddImagePal(Bitmap image, int position) {
			RoSpriteImagePal img = new RoSpriteImagePal();
			img.Width = (ushort)image.Width;
			img.Height = (ushort)image.Height;
			img.Image = image.Clone() as Bitmap;
			img.Decoded = true;
			img.Size = (ushort)(img.Width * img.Height);
			img.Data = new byte[img.Size];

			// build data
			for (int x = 0; x < img.Width; x++) {
				for (int y = 0; y < img.Height; y++) {
					Color c = image.GetPixel(x, y);
					int i = Palette.IndexOf(c);
					if (i == -1)
						continue; // TODO: color not found?
					img.Data[(x + (y * img.Width))] = (byte)i;
				}
			}

			if (position >= ImagesPal.Count) {
				ImagesPal.Add(img);
			} else {
				ImagesPal[position].Image = null; // force redraw
				ImagesPal.Insert(position, img);
			}
		}


		public void RemoveImagePal(int imageIndex) {
			if (imageIndex < 0 || imageIndex >= ImagesPal.Count) {
				return;
			}

			ImagesPal.RemoveAt(imageIndex);
		}

		public void RemoveImageRgba(int imageIndex) {
			if (imageIndex < 0 || imageIndex >= ImagesRgba.Count) {
				return;
			}

			ImagesRgba.RemoveAt(imageIndex);
		}

		public void RemoveImage(int imageIndex) {
			if (imageIndex < 0) {
				return;
			}

			// Try to identify pal or rgba using index
			if (ImagesPal != null && imageIndex >= ImagesPal.Count) {
				imageIndex -= ImagesPal.Count;
				RemoveImageRgba(imageIndex);
				return;
			}

			RemoveImagePal(imageIndex);
		}


		public Bitmap GetImageTransparentPal(int index) {
			if (ImagesPal == null || ImagesPal.Count <= index) {
				return null;
			}
			if (IsDrawnPal(index) == false) {
				if (DrawPalImage(index) == false) {
					// TODO: Exception?
					return null;
				}
			}

			Bitmap img = ImagesPal[index].Image.Clone() as Bitmap;
			Color bg = Palette[0];
			FastBitmap fb = new FastBitmap(img);

			fb.LockImage();
			for (int x = 0; x < img.Width; x++) {
				for (int y = 0; y < img.Height; y++) {
					if (fb.GetPixel(x, y) == bg) {
						fb.SetPixel(x, y, Color.Transparent);
					}
				}
			}
			fb.UnlockImage();

			return img;
		}

		public Bitmap GetImageTransparentRgba(int index) {
			if (ImagesRgba == null || ImagesRgba.Count <= index) {
				return null;
			}
			if (IsDrawnRgba(index) == false) {
				DrawRgbaImage(index);
			}

			Bitmap img = ImagesRgba[index].Image.Clone() as Bitmap;
			Color bg = Color.Fuchsia;
			FastBitmap fb = new FastBitmap(img);

			fb.LockImage();
			for (int x = 0; x < img.Width; x++) {
				for (int y = 0; y < img.Height; y++) {
					if (fb.GetPixel(x, y) == bg) {
						fb.SetPixel(x, y, Color.Transparent);
					}
				}
			}
			fb.UnlockImage();

			return img;
		}

		public Bitmap GetImageTransparent(int imageIndex, bool rgba) {
			if (rgba) {
				return GetImageTransparentRgba(imageIndex);
			} else {
				return GetImageTransparentPal(imageIndex);
			}
		}

		public Bitmap GetImageTransparent(int imageIndex) {
			if (imageIndex < 0) {
				return null;
			}

			// Try to identify pal or rgba using index
			if (ImagesPal != null && imageIndex >= ImagesPal.Count) {
				imageIndex -= ImagesPal.Count;
				return GetImageTransparent(imageIndex, true);
			}

			return GetImageTransparent(imageIndex, false);
		}


		public override void Flush(bool onDestruct) {
			if (onDestruct == false) {
				// cleanup only on destruct!
				base.Flush(onDestruct);
				return;
			}

			if (Palette != null) {
				aFree(Palette);
			}
			if (ImagesPal != null) {
				for (int i = 0; i < ImagesPal.Count; i++) {
					aFree(ImagesPal[i].Image);
					aFree(ImagesPal[i].Data);
				}
			}
			if (ImagesRgba != null) {
				for (int i = 0; i < ImagesRgba.Count; i++) {
					aFree(ImagesRgba[i].Image);
					aFree(ImagesRgba[i].Data);
				}
			}

			base.Flush(onDestruct);
			return;
		}

		public override string ToString() {
			return string.Format("0x{0:X2}, {1}x pal, {2}x rgba", Version, ImagesPal.Count, ImagesRgba.Count);
		}
	}

}
