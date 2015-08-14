#region Using Statements
using Microsoft.Xna.Framework;
using Paddles.GameScreens;
#endregion

namespace Paddles {
	public enum GameState {
		Menu,
		Play,
		Pause,
		GameOver
	}

	public class ScreenManager : DrawableGameComponent {

		public static GameState gameState = GameState.Menu;
		public static KeyboardManager keyboard;
		Menu menuScreen;
		GameScreen gScreen;
		public ScreenManager(Game game)
			: base(game) {
			menuScreen = new Menu();
			gScreen = new GameScreen();

			keyboard = new KeyboardManager();
		}

		public override void Update(GameTime gameTime) {
			keyboard.Update();
			switch (gameState) {
				case GameState.Menu:
					menuScreen.update(gameTime);
					break;
				case GameState.Play:
					gScreen.Update(gameTime);
					break;
			}
			base.Update(gameTime);
		}
		public override void Draw(GameTime gameTime) {
			switch (gameState) {
				case GameState.Menu:
					menuScreen.draw();
					break;
				case GameState.Play:
					gScreen.Draw();
					break;
			}
			base.Draw(gameTime);
		}
	}
}
