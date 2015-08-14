using Microsoft.Xna.Framework.Input;

namespace Paddles {

	public class KeyboardManager {

		public KeyboardState CurrentKeyboardState;
		public KeyboardState LastKeyboardState;

		public bool Quit {
			get {
				return (IsNewKeyPress(Keys.Escape) && (ScreenManager.gameState == GameState.Menu));
			}
		}
		public bool MenuUp {
			get {
				return IsNewKeyPress(Keys.Up) && (ScreenManager.gameState == GameState.Menu);
			}
		}
		public bool MenuDown {
			get {
				return IsNewKeyPress(Keys.Down) && (ScreenManager.gameState == GameState.Menu);
			}
		}
		public bool MenuSelect {
			get {
				return IsNewKeyPress(Keys.Enter) && (ScreenManager.gameState == GameState.Menu);
			}
		}
		public bool MenuBack {
			get {
				return (IsNewKeyPress(Keys.Back) && (ScreenManager.gameState == GameState.Menu));
			}
		}
		public bool MoveUp {
			get {
				return IsPressedKey(Keys.Up) && (ScreenManager.gameState == GameState.Play);
			}
		}
		public bool MoveDown {
			get {
				return IsPressedKey(Keys.Down) && (ScreenManager.gameState == GameState.Play);
			}
		}
		public bool Pause {
			get {
				return IsNewKeyPress(Keys.Escape) && (ScreenManager.gameState == GameState.Play);
			}
		}


		public KeyboardManager() {
		}


		public void Update() {
			LastKeyboardState = CurrentKeyboardState;

			CurrentKeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
		}

		public bool IsNewKeyPress(Keys key) {
			return (CurrentKeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key));
		}

		public bool IsPressedKey(Keys key) {
			if (CurrentKeyboardState.IsKeyDown(key))
				return true;
			return false;
		}

	}

}
