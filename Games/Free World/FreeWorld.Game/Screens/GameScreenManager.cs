using FreeWorld.Engine.Screen;

namespace FreeWorld.Game.Screens {
	
	public class GameScreenManager : EngineScreenManager  {

		public GameCamera GameCamera {
			get { return Camera as GameCamera; }
		}


		public GameScreenManager(Microsoft.Xna.Framework.Game game)
			: base(game) {
		}


		protected override void LoadContent() {
			base.LoadContent();

			Camera = new GameCamera(GraphicsDevice);
		}

	}

}