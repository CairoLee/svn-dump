using System;
using FreeWorld.Engine.Compontents.Input;
using FreeWorld.Engine.Tools;
using GodLesZ.Library.Xna.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FreeWorld.Engine.Compontents;

namespace FreeWorld.Engine {

	public class EngineCore {
		public static EngineContentLoader ContentLoader {
			get;
			protected set;
		}

		public static SpriteBatch SpriteBatch {
			get;
			set;
		}

		public static InputHelper InputHelper {
			get;
			protected set;
		}

		public static FileListLoader FileLists {
			get;
			protected set;
		}


		public static void Initialize(string contentRoot, GraphicsDevice device, IServiceProvider provider) {
			FileLists = new FileListLoader();
			FileLists.LoadLists(false);
			
			ContentLoader = new EngineContentLoader(contentRoot, device, provider);

			Constants.GraphicsDevice = device;

			Constants.ColorMoveable = Color.Green * 0.35f;
			Constants.ColorNotMoveable = new Color(new Vector4(Color.Red.ToVector3(), 0.35f));
			Constants.ColorWater = new Color(new Vector4(Color.LightBlue.ToVector3(), 0.35f));
			Constants.ColorUnderwater = new Color(new Vector4(Color.Blue.ToVector3(), 0.35f));
			Constants.TextureMoveable = DrawHelper.Rect2Texture(Constants.TileWidth, Constants.TileHeight, Constants.TileWidth / 2, Constants.ColorMoveable);
			Constants.TextureNotMoveable = DrawHelper.Rect2Texture(Constants.TileWidth, Constants.TileHeight, Constants.TileWidth / 2, Constants.ColorNotMoveable);
			Constants.TextureWater = DrawHelper.Rect2Texture(Constants.TileWidth, Constants.TileHeight, Constants.TileWidth / 2, Constants.ColorWater);
			Constants.TextureUnderwater = DrawHelper.Rect2Texture(Constants.TileWidth, Constants.TileHeight, Constants.TileWidth / 2, Constants.ColorUnderwater);
			Constants.TexturePixel = DrawHelper.Rect2Texture(1, 1, 0, Color.Transparent);

			Tools.ScreenshotHelper.Path = AppDomain.CurrentDomain.BaseDirectory + @"\Screeshot\";
		}

		public static void InitComponents(Game game) {
			game.Components.Add(InputHelper = new InputHelper(game));
		}


	}

}
