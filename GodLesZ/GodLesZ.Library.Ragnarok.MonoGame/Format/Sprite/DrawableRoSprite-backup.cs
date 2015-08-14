using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.Ragnarok.Palette;
using GodLesZ.Library.Ragnarok.Sprite;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Ragnarok.Xna.Sprite {

	public class DrawableRoSprite : RoSprite {

		public new List<DrawableRoSpriteImagePal> ImagesPal {
			get;
			protected set;
		}

		public new List<DrawableRoSpriteImageRgba> ImagesRgba {
			get;
			protected set;
		}

		public new DrawableRoSpriteImage this[int index, bool rgba] {
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


		public DrawableRoSprite(byte[] data)
			: base(data) {
		}

		public DrawableRoSprite(Stream stream)
			: base(stream) {
		}

		public DrawableRoSprite(string filepath)
			: base(filepath) {
		}

		public DrawableRoSprite() :
			base() {
		}


		protected override bool ReadInternal() {
			ImagesPal = new List<DrawableRoSpriteImagePal>();
			ImagesRgba = new List<DrawableRoSpriteImageRgba>();
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
			DrawableRoSpriteImagePal imgPal;
			for (int i = 0; i < imgPalCount; i++) {
				imgPal = new DrawableRoSpriteImagePal() {
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
			DrawableRoSpriteImageRgba imgRgba;
			for (int i = 0; i < imgRgbaCount; i++) {
				imgRgba = new DrawableRoSpriteImageRgba() {
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


		public Texture2D GetImageTransparent(int index, bool rgba, GraphicsDevice device) {
			if (rgba) {
				return GetImageTransparentRgba(index, device);
			} else {
				return GetImageTransparentPal(index, device);
			}

		}

		public Texture2D GetImageTransparentPal(int index, GraphicsDevice device) {
			Bitmap bmp = GetImageTransparentPal(index);
			if (bmp == null) {
				return null;
			}
			if (ImagesPal[index].Texture != null) {
				return ImagesPal[index].Texture;
			}

			using (MemoryStream ms = new MemoryStream()) {
				bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				ImagesPal[index].Texture = Texture2D.FromStream(device, ms);
			}
			return ImagesPal[index].Texture;
		}

		public Texture2D GetImageTransparentRgba(int index, GraphicsDevice device) {
			Bitmap bmp = GetImageTransparentRgba(index);
			if (bmp == null) {
				return null;
			}
			if (ImagesRgba[index].Texture != null) {
				return ImagesRgba[index].Texture;
			}

			using (MemoryStream ms = new MemoryStream()) {
				bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				ImagesRgba[index].Texture = Texture2D.FromStream(device, ms);
			}
			return ImagesRgba[index].Texture;
		}

	}

}
