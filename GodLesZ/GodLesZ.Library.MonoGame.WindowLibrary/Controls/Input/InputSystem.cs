using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class InputSystem : Disposable {

		private class InputKey {
			public Keys Key = Keys.None;
			public bool Pressed = false;
			public double Countdown = RepeatDelay;
		}

		private class InputMouseButton {
			public EMouseButton Button = EMouseButton.None;
			public bool Pressed = false;
			public double Countdown = RepeatDelay;

			public InputMouseButton() {
			}

			public InputMouseButton(EMouseButton button) {
				Button = button;
			}
		}

		private class InputMouse {
			public MouseState State = new MouseState();
			public Point Position = new Point(0, 0);
		}

		private class InputGamePadButton {
			public EGamePadButton Button = EGamePadButton.None;
			public bool Pressed = false;
			public double Countdown = RepeatDelay;

			public InputGamePadButton() {
			}

			public InputGamePadButton(EGamePadButton button) {
				Button = button;
			}
		}

		private const int RepeatDelay = 500;
		private const int RepeatRate = 50;
		private float ClickThreshold = 0.5f;

#if (!XBOX && !XBOX_FAKE)
		private System.Windows.Forms.Form window = null;
#endif

		private List<InputKey> keys = new List<InputKey>();
		private List<InputMouseButton> mouseButtons = new List<InputMouseButton>();
		private List<InputGamePadButton> gamePadButtons = new List<InputGamePadButton>();
		private MouseState mouseState = new MouseState();
		private GamePadState gamePadState = new GamePadState();
		private Manager manager = null;
		private InputOffset inputOffset = new InputOffset(0, 0, 1.0f, 1.0f);
		private EInputMethods inputMethods = EInputMethods.All;
		private EActivePlayer activePlayer = EActivePlayer.None;

		/// <summary>
		/// Sets or gets input offset and ratio when rescaling controls in render target.
		/// </summary>
		public virtual InputOffset InputOffset {
			get { return inputOffset; }
			set { inputOffset = value; }
		}

		/// <summary>
		/// Sets or gets input methods allowed for navigation.
		/// </summary>
		public virtual EInputMethods InputMethods {
			get { return inputMethods; }
			set { inputMethods = value; }
		}

		public virtual EActivePlayer ActivePlayer {
			get { return activePlayer; }
			set { activePlayer = value; }
		}

		public event KeyEventHandler KeyDown;
		public event KeyEventHandler KeyPress;
		public event KeyEventHandler KeyUp;

		public event MouseEventHandler MouseDown;
		public event MouseEventHandler MousePress;
		public event MouseEventHandler MouseUp;
		public event MouseEventHandler MouseMove;

		public event GamePadEventHandler GamePadUp;
		public event GamePadEventHandler GamePadDown;
		public event GamePadEventHandler GamePadPress;
		public event GamePadEventHandler GamePadMove;

		public InputSystem(Manager manager, InputOffset offset) {
			this.inputOffset = offset;
			this.manager = manager;
#if (!XBOX && !XBOX_FAKE)
			window = manager.Window;
#endif
		}

		public InputSystem(Manager manager)
			: this(manager, new InputOffset(0, 0, 1.0f, 1.0f)) {
		}

		public virtual void Initialize() {
			keys.Clear();
			mouseButtons.Clear();
			gamePadButtons.Clear();

#if (!XBOX && !XBOX_FAKE)
			foreach (string str in Enum.GetNames(typeof(Keys))) {
				InputKey key = new InputKey();
				key.Key = (Keys)Enum.Parse(typeof(Keys), str);
				keys.Add(key);
			}

			foreach (string str in Enum.GetNames(typeof(EMouseButton))) {
				InputMouseButton btn = new InputMouseButton();
				btn.Button = (EMouseButton)Enum.Parse(typeof(EMouseButton), str);
				mouseButtons.Add(btn);
			}

			foreach (string str in Enum.GetNames(typeof(EGamePadButton))) {
				InputGamePadButton btn = new InputGamePadButton();
				btn.Button = (EGamePadButton)Enum.Parse(typeof(EGamePadButton), str);
				gamePadButtons.Add(btn);
			}
#else             
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.None));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.Start));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.Back));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.Up));        
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.Down));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.Left));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.Right));       
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.A));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.B));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.X));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.Y));         
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.BigButton)); 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.LeftShoulder)); 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.RightShoulder)); 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.LeftTrigger)); 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.RightTrigger));         
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.LeftStick)); 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.RightStick));         
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.LeftStickLeft));         
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.LeftStickRight));                 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.LeftStickUp));
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.LeftStickDown));                         
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.RightStickLeft));                 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.RightStickRight));                 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.RightStickUp));                 
        gamePadButtons.Add(new InputGamePadButton(GamePadButton.RightStickDown));                 
#endif
		}

		public virtual void SendMouseState(MouseState state, GameTime gameTime) {
			UpdateMouse(state, gameTime);
		}

		public virtual void SendKeyboardState(KeyboardState state, GameTime gameTime) {
			UpdateKeys(state, gameTime);
		}

		public virtual void SendGamePadState(PlayerIndex playerIndex, GamePadState state, GameTime gameTime) {
			UpdateGamePad(playerIndex, state, gameTime);
		}

		public virtual void Update(GameTime gameTime) {
			if (manager.UseGuide && Guide.IsVisible)
				return;

#if (!XBOX && !XBOX_FAKE)
			MouseState ms = Mouse.GetState();
			KeyboardState ks = Keyboard.GetState(PlayerIndex.One);
#endif


#if (!XBOX && !XBOX_FAKE)
			if (window.Focused)
#endif
 {
#if (!XBOX && !XBOX_FAKE)
				if ((inputMethods & EInputMethods.Mouse) == EInputMethods.Mouse)
					UpdateMouse(ms, gameTime);
				if ((inputMethods & EInputMethods.Keyboard) == EInputMethods.Keyboard)
					UpdateKeys(ks, gameTime);
#endif

				if ((inputMethods & EInputMethods.GamePad) == EInputMethods.GamePad) {
					PlayerIndex index = PlayerIndex.One;
					if (Gamer.SignedInGamers.Count > 0 && activePlayer == EActivePlayer.None) {
						int i = 0; // Have to be done this way, else it crashes for player other than one
						index = Gamer.SignedInGamers[i].PlayerIndex;
					} else if (activePlayer != EActivePlayer.None) {
						index = (PlayerIndex)activePlayer;
					}
					GamePadState gs = GamePad.GetState(index);
					UpdateGamePad(index, gs, gameTime);
				}
			}
		}

		private ButtonState GetVectorState(EGamePadButton button, GamePadState state) {
			ButtonState ret = ButtonState.Released;
			bool down = false;
			float t = ClickThreshold;

			switch (button) {
				case EGamePadButton.LeftStickLeft:
					down = state.ThumbSticks.Left.X < -t;
					break;
				case EGamePadButton.LeftStickRight:
					down = state.ThumbSticks.Left.X > t;
					break;
				case EGamePadButton.LeftStickUp:
					down = state.ThumbSticks.Left.Y > t;
					break;
				case EGamePadButton.LeftStickDown:
					down = state.ThumbSticks.Left.Y < -t;
					break;

				case EGamePadButton.RightStickLeft:
					down = state.ThumbSticks.Right.X < -t;
					break;
				case EGamePadButton.RightStickRight:
					down = state.ThumbSticks.Right.X > t;
					break;
				case EGamePadButton.RightStickUp:
					down = state.ThumbSticks.Right.Y > t;
					break;
				case EGamePadButton.RightStickDown:
					down = state.ThumbSticks.Right.Y < -t;
					break;

				case EGamePadButton.LeftTrigger:
					down = state.Triggers.Left > t;
					break;
				case EGamePadButton.RightTrigger:
					down = state.Triggers.Right > t;
					break;
			}

			ret = down ? ButtonState.Pressed : ButtonState.Released;

			return ret;
		}

		private void UpdateGamePad(PlayerIndex playerIndex, GamePadState state, GameTime gameTime) {
			GamePadEventArgs e = new GamePadEventArgs(playerIndex);

			if (state.ThumbSticks.Left != gamePadState.ThumbSticks.Left ||
				state.ThumbSticks.Right != gamePadState.ThumbSticks.Right ||
				state.Triggers.Left != gamePadState.Triggers.Left ||
				state.Triggers.Right != gamePadState.Triggers.Right) {
				BuildGamePadEvent(state, EGamePadButton.None, ref e);
				if (GamePadMove != null)
					GamePadMove.Invoke(this, e);
			}

			foreach (InputGamePadButton btn in gamePadButtons) {
				ButtonState bs = ButtonState.Released;

				if (btn.Button == EGamePadButton.None)
					continue;
				else if (btn.Button == EGamePadButton.A)
					bs = state.Buttons.A;
				else if (btn.Button == EGamePadButton.B)
					bs = state.Buttons.B;
				else if (btn.Button == EGamePadButton.Back)
					bs = state.Buttons.Back;
				else if (btn.Button == EGamePadButton.Down)
					bs = state.DPad.Down;
				else if (btn.Button == EGamePadButton.Left)
					bs = state.DPad.Left;
				else if (btn.Button == EGamePadButton.Right)
					bs = state.DPad.Right;
				else if (btn.Button == EGamePadButton.Start)
					bs = state.Buttons.Start;
				else if (btn.Button == EGamePadButton.Up)
					bs = state.DPad.Up;
				else if (btn.Button == EGamePadButton.X)
					bs = state.Buttons.X;
				else if (btn.Button == EGamePadButton.Y)
					bs = state.Buttons.Y;
				else if (btn.Button == EGamePadButton.BigButton)
					bs = state.Buttons.BigButton;
				else if (btn.Button == EGamePadButton.LeftShoulder)
					bs = state.Buttons.LeftShoulder;
				else if (btn.Button == EGamePadButton.RightShoulder)
					bs = state.Buttons.RightShoulder;
				else if (btn.Button == EGamePadButton.LeftStick)
					bs = state.Buttons.LeftStick;
				else if (btn.Button == EGamePadButton.RightStick)
					bs = state.Buttons.RightStick;
				else
					bs = GetVectorState(btn.Button, state);

				bool pressed = (bs == ButtonState.Pressed);
				if (pressed) {
					double ms = gameTime.ElapsedGameTime.TotalMilliseconds;
					if (pressed)
						btn.Countdown -= ms;
				}

				if ((pressed) && (!btn.Pressed)) {
					btn.Pressed = true;
					BuildGamePadEvent(state, btn.Button, ref e);

					if (GamePadDown != null)
						GamePadDown.Invoke(this, e);
					if (GamePadPress != null)
						GamePadPress.Invoke(this, e);
				} else if ((!pressed) && (btn.Pressed)) {
					btn.Pressed = false;
					btn.Countdown = RepeatDelay;
					BuildGamePadEvent(state, btn.Button, ref e);

					if (GamePadUp != null)
						GamePadUp.Invoke(this, e);
				} else if (btn.Pressed && btn.Countdown < 0) {
					e.Button = btn.Button;
					btn.Countdown = RepeatRate;
					BuildGamePadEvent(state, btn.Button, ref e);

					if (GamePadPress != null)
						GamePadPress.Invoke(this, e);
				}
			}
			gamePadState = state;
		}

		private void BuildGamePadEvent(GamePadState state, EGamePadButton button, ref GamePadEventArgs e) {
			e.State = state;
			e.Button = button;
			e.Vectors.LeftStick = new Vector2(state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y);
			e.Vectors.RightStick = new Vector2(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
			e.Vectors.LeftTrigger = state.Triggers.Left;
			e.Vectors.RightTrigger = state.Triggers.Right;
		}

		private void UpdateKeys(KeyboardState state, GameTime gameTime) {
#if (!XBOX && !XBOX_FAKE)

			KeyEventArgs e = new KeyEventArgs();

			e.Caps = (((ushort)NativeMethods.GetKeyState(0x14)) & 0xffff) != 0;

			foreach (Keys key in state.GetPressedKeys()) {
				if (key == Keys.LeftAlt || key == Keys.RightAlt)
					e.Alt = true;
				else if (key == Keys.LeftShift || key == Keys.RightShift)
					e.Shift = true;
				else if (key == Keys.LeftControl || key == Keys.RightControl)
					e.Control = true;
			}

			foreach (InputKey key in keys) {
				if (key.Key == Keys.LeftAlt || key.Key == Keys.RightAlt ||
					key.Key == Keys.LeftShift || key.Key == Keys.RightShift ||
					key.Key == Keys.LeftControl || key.Key == Keys.RightControl) {
					continue;
				}

				bool pressed = state.IsKeyDown(key.Key);

				double ms = gameTime.ElapsedGameTime.TotalMilliseconds;
				if (pressed)
					key.Countdown -= ms;

				if ((pressed) && (!key.Pressed)) {
					key.Pressed = true;
					e.Key = key.Key;

					if (KeyDown != null)
						KeyDown.Invoke(this, e);
					if (KeyPress != null)
						KeyPress.Invoke(this, e);
				} else if ((!pressed) && (key.Pressed)) {
					key.Pressed = false;
					key.Countdown = RepeatDelay;
					e.Key = key.Key;

					if (KeyUp != null)
						KeyUp.Invoke(this, e);
				} else if (key.Pressed && key.Countdown < 0) {
					key.Countdown = RepeatRate;
					e.Key = key.Key;

					if (KeyPress != null)
						KeyPress.Invoke(this, e);
				}
			}
#endif
		}

		private Point RecalcPosition(Point pos) {
			return new Point((int)((pos.X - InputOffset.X) / InputOffset.RatioX), (int)((pos.Y - InputOffset.Y) / InputOffset.RatioY));
		}

		private void AdjustPosition(ref MouseEventArgs e) {
			Rectangle screen = manager.Game.Window.ClientBounds;

			if (e.Position.X < 0)
				e.Position.X = 0;
			if (e.Position.Y < 0)
				e.Position.Y = 0;
			if (e.Position.X >= screen.Width)
				e.Position.X = screen.Width - 1;
			if (e.Position.Y >= screen.Height)
				e.Position.Y = screen.Height - 1;
		}

		private void BuildMouseEvent(MouseState state, EMouseButton button, ref MouseEventArgs e) {
			e.State = state;
			e.Button = button;

			e.Position = new Point(state.X, state.Y);
			AdjustPosition(ref e);

			e.Position = RecalcPosition(e.Position);
			e.State = new MouseState(e.Position.X, e.Position.Y, e.State.ScrollWheelValue, e.State.LeftButton, e.State.MiddleButton, e.State.RightButton, e.State.XButton1, e.State.XButton2);

			Point pos = RecalcPosition(new Point(mouseState.X, mouseState.Y));
			e.Difference = new Point(e.Position.X - pos.X, e.Position.Y - pos.Y);
		}

		private void UpdateMouse(MouseState state, GameTime gameTime) {
#if (!XBOX && !XBOX_FAKE)

			if ((state.X != mouseState.X) || (state.Y != mouseState.Y)) {
				MouseEventArgs e = new MouseEventArgs();

				EMouseButton btn = EMouseButton.None;
				if (state.LeftButton == ButtonState.Pressed)
					btn = EMouseButton.Left;
				else if (state.RightButton == ButtonState.Pressed)
					btn = EMouseButton.Right;
				else if (state.MiddleButton == ButtonState.Pressed)
					btn = EMouseButton.Middle;
				else if (state.XButton1 == ButtonState.Pressed)
					btn = EMouseButton.XButton1;
				else if (state.XButton2 == ButtonState.Pressed)
					btn = EMouseButton.XButton2;

				BuildMouseEvent(state, btn, ref e);
				if (MouseMove != null) {
					MouseMove.Invoke(this, e);
				}
			}

			UpdateButtons(state, gameTime);

			mouseState = state;

#endif
		}

		private void UpdateButtons(MouseState state, GameTime gameTime) {
#if (!XBOX && !XBOX_FAKE)

			MouseEventArgs e = new MouseEventArgs();

			foreach (InputMouseButton btn in mouseButtons) {
				ButtonState bs = ButtonState.Released;

				if (btn.Button == EMouseButton.Left)
					bs = state.LeftButton;
				else if (btn.Button == EMouseButton.Right)
					bs = state.RightButton;
				else if (btn.Button == EMouseButton.Middle)
					bs = state.MiddleButton;
				else if (btn.Button == EMouseButton.XButton1)
					bs = state.XButton1;
				else if (btn.Button == EMouseButton.XButton2)
					bs = state.XButton2;
				else
					continue;

				bool pressed = (bs == ButtonState.Pressed);
				if (pressed) {
					double ms = gameTime.ElapsedGameTime.TotalMilliseconds;
					if (pressed)
						btn.Countdown -= ms;
				}

				if ((pressed) && (!btn.Pressed)) {
					btn.Pressed = true;
					BuildMouseEvent(state, btn.Button, ref e);

					if (MouseDown != null)
						MouseDown.Invoke(this, e);
					if (MousePress != null)
						MousePress.Invoke(this, e);
				} else if ((!pressed) && (btn.Pressed)) {
					btn.Pressed = false;
					btn.Countdown = RepeatDelay;
					BuildMouseEvent(state, btn.Button, ref e);

					if (MouseUp != null)
						MouseUp.Invoke(this, e);
				} else if (btn.Pressed && btn.Countdown < 0) {
					e.Button = btn.Button;
					btn.Countdown = RepeatRate;
					BuildMouseEvent(state, btn.Button, ref e);

					if (MousePress != null)
						MousePress.Invoke(this, e);
				}
			}

#endif
		}

	}

}