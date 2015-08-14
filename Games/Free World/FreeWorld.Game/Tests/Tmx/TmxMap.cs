using System;
using System.Linq;
using System.Xml.Linq;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Game.Tests.Tmx {

	public class TmxMap : TmxDocument {

		public string Version {
			get;
			protected set;
		}

		public EOrientationType Orientation {
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

		public int TileWidth {
			get;
			protected set;
		}

		public int TileHeight {
			get;
			protected set;
		}

		public uint? BackgroundColor {
			get;
			protected set;
		}


		public TmxList<TmxTileset> Tilesets {
			get;
			protected set;
		}

		public TmxList<TmxLayer> Layers {
			get;
			protected set;
		}

		public TmxList<TmxObjectGroup> ObjectGroups {
			get;
			protected set;
		}

		public TmxList<TmxImageLayer> ImageLayers {
			get;
			protected set;
		}

		public PropertyDict Properties {
			get;
			protected set;
		}


		public TmxMap() {
			Tilesets = new TmxList<TmxTileset>();
			Layers = new TmxList<TmxLayer>();
			ObjectGroups = new TmxList<TmxObjectGroup>();
			ImageLayers = new TmxList<TmxImageLayer>();
			Properties = new PropertyDict();
		}

		public TmxMap(string filename)
			: this() {
			XDocument xDoc = ReadXml(filename);
			var xMap = xDoc.Element("map");
			if (xMap == null) {
				throw new ArgumentOutOfRangeException("filename", "The given file is ether invalid xml or dos not contain a map element");
			}

			Version = (string)xMap.Attribute("version");
			Orientation = (EOrientationType)Enum.Parse(typeof(EOrientationType), xMap.Attribute("orientation").Value, true);
			Width = (int)xMap.Attribute("width");
			Height = (int)xMap.Attribute("height");
			TileWidth = (int)xMap.Attribute("tilewidth");
			TileHeight = (int)xMap.Attribute("tileheight");

			var xBackgroundColor = (string)xMap.Attribute("backgroundcolor");
			if (xBackgroundColor != null) {
				xBackgroundColor = xBackgroundColor.TrimStart("#".ToCharArray());
				BackgroundColor = UInt32.Parse(xBackgroundColor, NumberStyles.HexNumber);
			}

			foreach (var e in xMap.Elements("tileset"))
				Tilesets.Add(new TmxTileset(e, TmxDirectory));

			foreach (var e in xMap.Elements("layer"))
				Layers.Add(new TmxLayer(this, e, Width, Height));

			foreach (var e in xMap.Elements("objectgroup"))
				ObjectGroups.Add(new TmxObjectGroup(e));

			foreach (var e in xMap.Elements("imagelayer"))
				ImageLayers.Add(new TmxImageLayer(this, e, TmxDirectory));

			Properties.AddRange(xMap.Element("properties"));
		}


		public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GameCamera camera) {

			foreach (var layer in Layers.Select(iLayer => iLayer)) {
				layer.Draw(spriteBatch, gameTime, camera);
			}

		}

		public TmxTileset GetTilesetByGid(int gid) {
			if (Tilesets.Count == 0) {
				return null;
			}

			return Tilesets
				.Where((t, i) =>
					gid >= t.FirstGid && ((i + 1) >= Tilesets.Count || Tilesets[i + 1].FirstGid > gid)
				)
				.FirstOrDefault();
		}


		/// <summary>
		/// Gibt einen <see cref="T:System.String"/> zurück, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </summary>
		/// <returns>
		/// Ein <see cref="T:System.String"/>, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </returns>
		public override string ToString() {
			return string.Format("{0} x {1} ({2}), {3} layer, {4} tilesets", Width, Height, Orientation, Layers.Count, Tilesets.Count);
		}

	}

}
