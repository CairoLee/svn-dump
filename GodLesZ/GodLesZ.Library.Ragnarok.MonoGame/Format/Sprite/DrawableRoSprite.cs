using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GodLesZ.Library.Ragnarok.Sprite;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Sprite {

	public class DrawableRoSprite : RoSprite {

		public List<Texture2D> TexturesPal {
			get;
			protected set;
		}

		public List<Texture2D> TexturesRgba {
			get;
			protected set;
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


		public override void Flush() {
			if (TexturesPal != null && TexturesPal.Count > 0) {
				for (int i = 0; i < TexturesPal.Count; i++) {
					aFree(TexturesPal[i]);
				}
			}
			if (TexturesRgba != null && TexturesRgba.Count > 0) {
				for (int i = 0; i < TexturesRgba.Count; i++) {
					aFree(TexturesRgba[i]);
				}
			}

			base.Flush();
		}

		protected override bool ReadInternal() {
			bool result = base.ReadInternal();

			TexturesPal = new List<Texture2D>();
			TexturesRgba = new List<Texture2D>();
			// Need to add empty values..
			if (ImagesPal != null) {
				for (int i = 0; i < ImagesPal.Count; i++) {
					TexturesPal.Add(null);
				}
			}
			if (ImagesRgba != null) {
				for (int i = 0; i < ImagesRgba.Count; i++) {
					TexturesRgba.Add(null);
				}
			}

			return result;
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
			if (TexturesPal[index] != null) {
				return TexturesPal[index];
			}

			using (MemoryStream ms = new MemoryStream()) {
				bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				TexturesPal[index] = Texture2D.FromStream(device, ms);
			}
			return TexturesPal[index];
		}

		public Texture2D GetImageTransparentRgba(int index, GraphicsDevice device) {
			Bitmap bmp = GetImageTransparentRgba(index);
			if (bmp == null) {
				return null;
			}
			if (TexturesRgba[index] != null) {
				return TexturesRgba[index];
			}

			using (MemoryStream ms = new MemoryStream()) {
				bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				TexturesRgba[index] = Texture2D.FromStream(device, ms);
			}
			return TexturesRgba[index];
		}

	}

}
