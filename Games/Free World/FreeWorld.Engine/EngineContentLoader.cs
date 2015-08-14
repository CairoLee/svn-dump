using System;
using System.IO;
using FreeWorld.Engine.TileEngine;
using FreeWorld.Engine.TileEngine.Animation;
using GodLesZ.Library.Xna.Content;
using GodLesZ.Library.Xna.Content.Extended;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine {

	public class EngineContentLoader : ContentLoader {

		public EngineContentLoader(string contentRoot, GraphicsDevice graphicsDevice, IServiceProvider provider)
			: base(contentRoot, graphicsDevice, provider) {
		}
		

		private TileAnimation GetTileAnimation(string Filename) {
			try {
				TileAnimation ani = null;
				if (Path.GetExtension(Filename) != ".bani")
					Filename += ".bani";

				ani = (TileAnimation)Load(Filename,
					delegate(AssetTracker Tracker) {
						TileAnimation tmpAni = null;
						byte[] buf = (byte[])Tracker.Asset;
						using (MemoryStream ms = new MemoryStream(buf))
							TileAnimation.Load(ms, out tmpAni);
						buf = null;
						return tmpAni;
					}
				);

				return ani;
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
				return null;
			}
		}

		private TileMap GetTileMap(string Filename) {
			try {
				TileMap map = null;
				if (Path.GetExtension(Filename) != ".bmap")
					Filename += ".bmap";

				map = (TileMap)Load(Filename,
					delegate(AssetTracker Tracker) {
						TileMap tmpMap = null;
						byte[] buf = (byte[])Tracker.Asset;
						using (MemoryStream ms = new MemoryStream(buf))
							TileMap.Load(ms, out tmpMap);
						buf = null;
						return tmpMap;
					}
				);

				return map;
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
				return null;
			}
		}


		#region Get<Type>() shorthands
		public Texture2D GetTileset(string Filename) {
			return GetTexture(Filename, @"Tilesets\");
		}

		public Texture2D GetAutotile(string Filename) {
			return GetTexture(Filename, @"Autotiles\");
		}

		public Texture2D GetCharacter(string Filename) {
			return GetTexture(Filename, @"Characters\");
		}

		public Texture2D GetFog(string Filename) {
			return GetTexture(Filename, @"Fogs\");
		}

		public Texture2D GetIcon(string Filename) {
			return GetTexture(Filename, @"Icons\");
		}

		public Texture2D GetAnimationTileset(string Filename) {
			return GetTexture(Filename, @"AnimationTilesets\");
		}

		public TileAnimation GetAnimation(string Filename) {
			return GetTileAnimation(Path.Combine(@"bAnimations\", Filename));
		}

		public TileMap GetMap(string Filename) {
			return GetTileMap(Path.Combine(@"bMaps\", Filename));
		}
		#endregion
		
	}

}
