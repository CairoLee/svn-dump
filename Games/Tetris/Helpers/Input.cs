using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Tetris.Helpers {

	public class Input {
		private static KeyboardState keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
		private static List<Keys> keysPressedLastFrame = new List<Keys>();
		private static GamePadState gamePadState, gamePadStateLastFrame;

		#region Keyboard
		public static KeyboardState Keyboard {
			get { return keyboardState; }
		}

		public static bool KeyboardSpaceJustPressed {
			get { return keyboardState.IsKeyDown(Keys.Space) && keysPressedLastFrame.Contains(Keys.Space) == false; }
		}

		public static bool KeyboardEscapeJustPressed {
			get { return keyboardState.IsKeyDown(Keys.Escape) && keysPressedLastFrame.Contains(Keys.Escape) == false; }
		}

		public static bool KeyboardLeftJustPressed {
			get { return keyboardState.IsKeyDown(Keys.Left) && keysPressedLastFrame.Contains(Keys.Left) == false; }
		}

		public static bool KeyboardRightJustPressed {
			get { return keyboardState.IsKeyDown(Keys.Right) && keysPressedLastFrame.Contains(Keys.Right) == false; }
		}

		public static bool KeyboardUpJustPressed {
			get { return keyboardState.IsKeyDown(Keys.Up) && keysPressedLastFrame.Contains(Keys.Up) == false; }
		}

		public static bool KeyboardDownJustPressed {
			get { return keyboardState.IsKeyDown(Keys.Down) && keysPressedLastFrame.Contains(Keys.Down) == false; }
		}

		public static bool KeyboardEnterJustPressed {
			get { return keyboardState.IsKeyDown(Keys.Enter) && keysPressedLastFrame.Contains(Keys.Enter) == false; }
		}

		public static bool KeyboardSounduteJustPressed {
			get { return keyboardState.IsKeyDown(Keys.S) && keysPressedLastFrame.Contains(Keys.S) == false; }
		}

		public static bool KeyboardLeftPressed {
			get { return keyboardState.IsKeyDown(Keys.Left); }
		}

		public static bool KeyboardRightPressed {
			get { return keyboardState.IsKeyDown(Keys.Right); }
		}

		public static bool KeyboardUpPressed {
			get { return keyboardState.IsKeyDown(Keys.Up); }
		}

		public static bool KeyboardDownPressed {
			get { return keyboardState.IsKeyDown(Keys.Down); }
		}
		#endregion

		#region GamePad
		public static bool GamePadAPressed {
			get { return gamePadState.Buttons.A == ButtonState.Pressed; }
		}

		public static bool GamePadBPressed {
			get { return gamePadState.Buttons.B == ButtonState.Pressed; }
		}

		public static bool GamePadXPressed {
			get { return gamePadState.Buttons.X == ButtonState.Pressed; }
		}

		public static bool GamePadYPressed {
			get { return gamePadState.Buttons.Y == ButtonState.Pressed; }
		}

		public static bool GamePadLeftPressed {
			get { return gamePadState.DPad.Left == ButtonState.Pressed || gamePadState.ThumbSticks.Left.X < -0.75f; }
		}

		public static bool GamePadRightPressed {
			get { return gamePadState.DPad.Left == ButtonState.Pressed || gamePadState.ThumbSticks.Left.X > 0.75f; }
		}

		public static bool GamePadLeftJustPressed {
			get { return (gamePadState.DPad.Left == ButtonState.Pressed && gamePadStateLastFrame.DPad.Left == ButtonState.Released) || (gamePadState.ThumbSticks.Left.X < -0.75f && gamePadStateLastFrame.ThumbSticks.Left.X > -0.75f); }
		}

		public static bool GamePadRightJustPressed {
			get { return (gamePadState.DPad.Right == ButtonState.Pressed && gamePadStateLastFrame.DPad.Right == ButtonState.Released) || (gamePadState.ThumbSticks.Left.X > 0.75f && gamePadStateLastFrame.ThumbSticks.Left.X < 0.75f); }
		}

		public static bool GamePadUpJustPressed {
			get { return (gamePadState.DPad.Up == ButtonState.Pressed && gamePadStateLastFrame.DPad.Up == ButtonState.Released) || (gamePadState.ThumbSticks.Left.Y > 0.75f && gamePadStateLastFrame.ThumbSticks.Left.Y < 0.75f); }
		}

		public static bool GamePadDownJustPressed {
			get { return (gamePadState.DPad.Down == ButtonState.Pressed && gamePadStateLastFrame.DPad.Down == ButtonState.Released) || (gamePadState.ThumbSticks.Left.Y < -0.75f && gamePadStateLastFrame.ThumbSticks.Left.Y > -0.75f); }
		}

		public static bool GamePadUpPressed {
			get { return gamePadState.DPad.Down == ButtonState.Pressed || gamePadState.ThumbSticks.Left.Y > 0.75f; }
		}

		public static bool GamePadDownPressed {
			get { return gamePadState.DPad.Up == ButtonState.Pressed || gamePadState.ThumbSticks.Left.Y < -0.75f; }
		}

		public static bool GamePadAJustPressed {
			get { return gamePadState.Buttons.A == ButtonState.Pressed && gamePadStateLastFrame.Buttons.A == ButtonState.Released; }
		}

		public static bool GamePadBJustPressed {
			get { return gamePadState.Buttons.B == ButtonState.Pressed && gamePadStateLastFrame.Buttons.B == ButtonState.Released; }
		}

		public static bool GamePadXJustPressed {
			get { return gamePadState.Buttons.X == ButtonState.Pressed && gamePadStateLastFrame.Buttons.X == ButtonState.Released; }
		}

		public static bool GamePadYJustPressed {
			get { return gamePadState.Buttons.Y == ButtonState.Pressed && gamePadStateLastFrame.Buttons.Y == ButtonState.Released; }
		}

		public static bool GamePadBackJustPressed {
			get { return gamePadState.Buttons.Back == ButtonState.Pressed && gamePadStateLastFrame.Buttons.Back == ButtonState.Released; }
		}
		#endregion


		internal static void Update() {
			keysPressedLastFrame = new List<Keys>(keyboardState.GetPressedKeys());
			keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();

			gamePadStateLastFrame = gamePadState;
			gamePadState = Microsoft.Xna.Framework.Input.GamePad.GetState(PlayerIndex.One);
		}


		public static bool KeyboardKeyJustPressed(Keys key) {
			return keyboardState.IsKeyDown(key) && keysPressedLastFrame.Contains(key) == false;
		}

	}

}
