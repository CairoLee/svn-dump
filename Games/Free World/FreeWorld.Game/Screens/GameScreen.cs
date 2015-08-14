using GodLesZ.Library.Xna.ScreenSystem;

namespace FreeWorld.Game.Screens {

	public class GameScreen : AwesomiumAbstractScreen {

		public GameScreenManager ScreenManager {
			get { return mScreenManager as GameScreenManager; }
			protected set { mScreenManager = value; }
		}

		public string InterfaceBasePath {
			get { return "Interface/"; }
		}


		public override bool LoadInterface(string url) {
			return base.LoadInterface(InterfaceBasePath + url);
		}
	}

}