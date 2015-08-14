using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FreeWorld.Engine {

	public class Constants {

		public const int TileWidth = 32;
		public const int TileHeight = 32;
		public const int TileDepth = 32;
		public const int CharTileWidth = 32;
		public const int CharTileHeight = 48;

		// Image/Tileset size
		//public const int AnimationTilesetWidth = 192; // RPG Maker XP
		public const int AnimationTilesetWidth = 96; // Pixel art
		//public const int AnimationTilesetHeight = 192;
		public const int AnimationTilesetHeight = 128;
		// Drawn size
		public const int AnimationWidth = 96;
		public const int AnimationHeight = 128;


		// Needs initialisation!
		public static GraphicsDevice GraphicsDevice;

		public static Texture2D TextureMoveable;
		public static Texture2D TextureNotMoveable;
		public static Texture2D TextureWater;
		public static Texture2D TextureUnderwater;
		public static Texture2D TexturePixel;
		public static Color ColorMoveable;
		public static Color ColorNotMoveable;
		public static Color ColorWater;
		public static Color ColorUnderwater;

	}

}
