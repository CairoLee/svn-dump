using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Game.Tests.Tmx {

	public class TmxLayer : ITmxElement {

		public TmxMap ParentMap {
			get;
			protected set;
		}

		public string Name {
			get;
			protected set;
		}

		public int Width {
			get;
			protected set;
		}

		public int Height {
			get;
			protected set;
		}

		public List<TmxLayerTile> Tiles {
			get;
			protected set;
		}

		public PropertyDict Properties {
			get;
			protected set;
		}

		public double Opacity {
			get;
			set;
		}

		public bool Visible {
			get;
			set;
		}


		protected TmxLayer(TmxMap map) {
			ParentMap = map;
		}

		public TmxLayer(TmxMap map, XElement xLayer, int width, int height)
			: this(map) {
			Name = (string)xLayer.Attribute("name");
			Width = (int)xLayer.Attribute("width");
			Height = (int)xLayer.Attribute("height");

			var xOpacity = xLayer.Attribute("opacity");
			Opacity = xOpacity == null ? 1.0 : (double)xOpacity;

			var xVisible = xLayer.Attribute("visible");
			Visible = xVisible == null || (bool)xVisible;

			var xData = xLayer.Element("data");
			var encoding = (string)xData.Attribute("encoding");

			Tiles = new List<TmxLayerTile>();
			if (encoding == "base64") {
				var base64data = Convert.FromBase64String((string)xData.Value);
				Stream stream = new MemoryStream(base64data, false);

				var compression = (string)xData.Attribute("compression");
				/*
				if (compression == "gzip")
					stream = new GZipStream(stream, CompressionMode.Decompress,
											false);
				else if (compression == "zlib")
					stream = new Ionic.Zlib.ZlibStream(stream,
								Ionic.Zlib.CompressionMode.Decompress, false);
				else 
				*/
				if (compression != null)
					throw new Exception("Tiled: Unknown compression.");

				using (stream)
				using (var br = new BinaryReader(stream))
					for (int j = 0; j < height; j++)
						for (int i = 0; i < width; i++)
							Tiles.Add(new TmxLayerTile(this, br.ReadUInt32(), i, j));
			} else if (encoding == "csv") {
				var csvData = (string)xData.Value;
				int k = 0;
				foreach (var s in csvData.Split(',')) {
					var gid = uint.Parse(s.Trim());
					var x = k % width;
					var y = k / width;
					Tiles.Add(new TmxLayerTile(this, gid, x, y));
					k++;
				}
			} else if (encoding == null) {
				int k = 0;
				foreach (var e in xData.Elements("tile")) {
					var gid = (uint)e.Attribute("gid");
					var x = k % width;
					var y = k / width;
					Tiles.Add(new TmxLayerTile(this, gid, x, y));
					k++;
				}
			} else throw new Exception("Tiled: Unknown encoding.");

			Properties = new PropertyDict(xLayer.Element("properties"));
		}


		public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GameCamera camera) {
			if (Tiles == null || Tiles.Count == 0 || Visible == false || Opacity.Equals(0)) {
				return;
			}

			foreach (var tile in Tiles) {

				tile.Draw(spriteBatch, gameTime, camera);

			}

		}


		/// <summary>
		/// Gibt einen <see cref="T:System.String"/> zurück, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </summary>
		/// <returns>
		/// Ein <see cref="T:System.String"/>, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </returns>
		public override string ToString() {
			return string.Format("{0}, {1} tiles, visible {2}, opacity {3}", Name, Tiles.Count, Visible, Opacity);
		}

	}

}