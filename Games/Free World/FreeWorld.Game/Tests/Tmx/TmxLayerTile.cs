using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Game.Tests.Tmx {

	public class TmxLayerTile {

		public TmxLayer ParentLayer {
			get;
			protected set;
		}

		public int Gid {
			get;
			protected set;
		}

		public int X {
			get;
			protected set;
		}

		public int Y {
			get;
			protected set;
		}

		public ETmxLayerTileFlip Flip {
			get;
			protected set;
		}


		public bool HorizontalFlip {
			get { return (Flip & ETmxLayerTileFlip.Horizontally) == ETmxLayerTileFlip.Horizontally; }
		}

		public bool VerticalFlip {
			get { return (Flip & ETmxLayerTileFlip.Vertically) == ETmxLayerTileFlip.Vertically; }
		}

		public bool DiagonalFlip {
			get { return (Flip & ETmxLayerTileFlip.Diagonally) == ETmxLayerTileFlip.Diagonally; }
		}


		public TmxLayerTile(TmxLayer layer, uint id, int x, int y) {
			ParentLayer = layer;

			X = x;
			Y = y;

			var rawGid = id;
			Flip = ETmxLayerTileFlip.None;
			// Scan for tile flip bit flags
			if ((rawGid & (uint)ETmxLayerTileFlip.Horizontally) != 0) {
				Flip |= ETmxLayerTileFlip.Horizontally;
			}
			if ((rawGid & (uint)ETmxLayerTileFlip.Vertically) != 0) {
				Flip |= ETmxLayerTileFlip.Vertically;
			}
			if ((rawGid & (uint)ETmxLayerTileFlip.Diagonally) != 0) {
				Flip |= ETmxLayerTileFlip.Diagonally;
			}

			// Zero the bit flags
			rawGid &= ~(uint)(ETmxLayerTileFlip.Horizontally | ETmxLayerTileFlip.Vertically | ETmxLayerTileFlip.Diagonally);

			// Save GID remainder to int
			Gid = (int)rawGid;
		}


		public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GameCamera camera) {
			if (Gid == 0) {
				return;
			}

			var tileset = ParentLayer.ParentMap.GetTilesetByGid(Gid);
			var relativeGid = tileset.GetRelativeGid(this);
			var rectSrc = tileset.GetSourceRectangleByGid(relativeGid);
			var rectDest = new Rectangle(X * tileset.TileWidth, Y * tileset.TileHeight, tileset.TileWidth, tileset.TileHeight);
			// Apply camera position
			rectDest.X += camera.X * tileset.TileWidth;
			rectDest.Y += camera.Y * tileset.TileHeight;
			if (camera.IsInViewport(rectDest) == false) {
				return;
			}

			var opacityColor = Color.White * (float)ParentLayer.Opacity;
			spriteBatch.Draw(tileset.Image.Texture, rectDest, rectSrc, opacityColor);
		}

		
		/// <summary>
		/// Gibt einen <see cref="T:System.String"/> zurück, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </summary>
		/// <returns>
		/// Ein <see cref="T:System.String"/>, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </returns>
		public override string ToString() {
			return string.Format("{0} ({1} / {2}), horizontal flip {3}, vertical flip {4}, diagonal flip {5}", Gid, X, Y, HorizontalFlip, VerticalFlip, DiagonalFlip);
		}
	}

}