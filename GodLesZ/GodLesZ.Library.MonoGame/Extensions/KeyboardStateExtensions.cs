using Microsoft.Xna.Framework.Input;

namespace GodLesZ.Library.MonoGame.Extensions {

	public static class KeyboardStateExtensions {

		public static bool IsCtrlDown(this KeyboardState KeyState) {
			return KeyState.IsKeyDown(Keys.LeftControl) || KeyState.IsKeyDown(Keys.RightControl);
		}

		public static bool IsCtrlUp(this KeyboardState KeyState) {
			return KeyState.IsCtrlDown() == false;
		}

		public static bool IsShiftDown(this KeyboardState KeyState) {
			return KeyState.IsKeyDown(Keys.LeftShift) || KeyState.IsKeyDown(Keys.RightShift);
		}

		public static bool IsShiftUp(this KeyboardState KeyState) {
			return KeyState.IsShiftDown() == false;
		}

	}

}
