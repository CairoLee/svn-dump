using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using FreeWorld.Engine;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Game.Tests.Tmx {
	public class TmxImage {
		protected Texture2D mTexture;

		public string Source {get; private set;}
		public uint? Trans {get; private set;}
		public int Width {get; private set;}
		public int Height {get; private set;}


		public Texture2D Texture {
			get {
				if (mTexture != null) {
					return mTexture;
				}

				var filename = Path.GetFileName(Source);
				return mTexture = EngineCore.ContentLoader.GetTileset(filename);
			}
		}

		public TmxImage(XElement xImage, string tmxDir = "")
		{
			Source = (string)xImage.Attribute("source");

			// Append directory if present
			Source = Path.Combine(tmxDir, Source);

			var xTrans = (string)xImage.Attribute("trans");
			if (xTrans != null)
				Trans = UInt32.Parse(xTrans, NumberStyles.HexNumber);

			Width = (int)xImage.Attribute("width");
			Height = (int)xImage.Attribute("height");
		}

		/// <summary>
		/// Gibt einen <see cref="T:System.String"/> zurück, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </summary>
		/// <returns>
		/// Ein <see cref="T:System.String"/>, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </returns>
		public override string ToString() {
			return string.Format("{0} ({1} x {2}){3}", Source, Width, Height, (Trans.HasValue ? ", trans color " + Trans.Value.ToString("X2") : ""));
		}
	}
}