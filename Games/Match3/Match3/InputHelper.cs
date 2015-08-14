using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GodLesZ.Games.Match3 {

	public class InputHelper {
		protected MouseState mCurrentMouseState = new MouseState();
		protected MouseState mLastMouseState = new MouseState();
		protected KeyboardState mCurrentKeyState = new KeyboardState();
		protected KeyboardState mLastKeyState = new KeyboardState();


		public bool IsNewLeftPressed() {
			return (mLastMouseState.LeftButton == ButtonState.Released && mCurrentMouseState.LeftButton == ButtonState.Pressed);
		}

		public bool IsNewPressed(Keys key) {
			return mLastKeyState.IsKeyDown(key) && mCurrentKeyState.IsKeyUp(key);
		}

		public void Update() {
			mLastMouseState = mCurrentMouseState;
			mLastKeyState = mCurrentKeyState;
			mCurrentMouseState = Mouse.GetState();
			mCurrentKeyState = Keyboard.GetState();
		}

	}

}