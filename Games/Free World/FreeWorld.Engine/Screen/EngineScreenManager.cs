using FreeWorld.Engine.Geometry.Camera;
using GodLesZ.Library.Xna.Content;
using GodLesZ.Library.Xna.ScreenSystem;
using Microsoft.Xna.Framework;

namespace FreeWorld.Engine.Screen {

	public class EngineScreenManager : ScreenManager {

		public ContentLoader ContentLoader {
			get;
			protected set;
		}


		public EngineScreenManager(Game game)
			: base(game) {
			// Content loader
			ContentLoader = new ContentLoader("Content", Game.GraphicsDevice, Game.Services);
		}


		public override void Initialize() {
			base.Initialize();

			if (Camera == null) {
				Camera = new EngineCamera(GraphicsDevice);
			}
		}

		public override void Draw(AbstractScreen screen, GameTime gameTime) {
			SpriteBatch.Begin();
			
			base.Draw(screen, gameTime);

			SpriteBatch.End();
		}
	}

}
