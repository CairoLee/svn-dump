using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class EventArgs : System.EventArgs {

		public bool Handled = false;

		public EventArgs() {
		}

	}

	public class KeyEventArgs : EventArgs {
		public Keys Key = Keys.None;
		public bool Control = false;
		public bool Shift = false;
		public bool Alt = false;
		public bool Caps = false;

		public KeyEventArgs() {
		}

		public KeyEventArgs(Keys key) {
			Key = key;
			Control = false;
			Shift = false;
			Alt = false;
			Caps = false;
		}

		public KeyEventArgs(Keys key, bool control, bool shift, bool alt, bool caps) {
			Key = key;
			Control = control;
			Shift = shift;
			Alt = alt;
			Caps = caps;
		}

	}

	public class MouseEventArgs : EventArgs {
		public MouseState State = new MouseState();
		public EMouseButton Button = EMouseButton.None;
		public Point Position = new Point(0, 0);
		public Point Difference = new Point(0, 0);

		public MouseEventArgs() {
		}

		public MouseEventArgs(MouseState state, EMouseButton button, Point position) {
			State = state;
			Button = button;
			Position = position;
		}

		public MouseEventArgs(MouseEventArgs e) {
			State = e.State;
			Button = e.Button;
			Position = e.Position;
			Difference = e.Difference;
		}


	}

	public class GamePadEventArgs : EventArgs {
		public PlayerIndex PlayerIndex = PlayerIndex.One;
		public GamePadState State = new GamePadState();
		public EGamePadButton Button = EGamePadButton.None;
		public GamePadVectors Vectors;

		/*
		 public GamePadEventArgs()
		 {                      
		 }*/

		public GamePadEventArgs(PlayerIndex playerIndex) {
			PlayerIndex = playerIndex;
		}

		public GamePadEventArgs(PlayerIndex playerIndex, EGamePadButton button) {
			PlayerIndex = playerIndex;
			Button = button;
		}


	}

	public class DrawEventArgs : EventArgs {
		public Renderer Renderer = null;
		public Rectangle Rectangle = Rectangle.Empty;
		public GameTime GameTime = null;

		public DrawEventArgs() {
		}

		public DrawEventArgs(Renderer renderer, Rectangle rectangle, GameTime gameTime) {
			Renderer = renderer;
			Rectangle = rectangle;
			GameTime = gameTime;
		}

	}

	public class ResizeEventArgs : EventArgs {
		public int Width = 0;
		public int Height = 0;
		public int OldWidth = 0;
		public int OldHeight = 0;

		public ResizeEventArgs() {
		}

		public ResizeEventArgs(int width, int height, int oldWidth, int oldHeight) {
			Width = width;
			Height = height;
			OldWidth = oldWidth;
			OldHeight = oldHeight;
		}

	}

	public class MoveEventArgs : EventArgs {
		public int Left = 0;
		public int Top = 0;
		public int OldLeft = 0;
		public int OldTop = 0;

		public MoveEventArgs() {
		}

		public MoveEventArgs(int left, int top, int oldLeft, int oldTop) {
			Left = left;
			Top = top;
			OldLeft = oldLeft;
			OldTop = oldTop;
		}

	}

	public class DeviceEventArgs : EventArgs {
		public PreparingDeviceSettingsEventArgs DeviceSettings = null;

		public DeviceEventArgs() {
		}

		public DeviceEventArgs(PreparingDeviceSettingsEventArgs deviceSettings) {
			DeviceSettings = deviceSettings;
		}

	}

	public class WindowClosingEventArgs : EventArgs {
		public bool Cancel = false;

		public WindowClosingEventArgs() {
		}

	}

	public class WindowClosedEventArgs : EventArgs {
		public bool Dispose = false;

		public WindowClosedEventArgs() {
		}

	}

	public class ConsoleMessageEventArgs : EventArgs {
		public ConsoleMessage Message;

		public ConsoleMessageEventArgs() {
		}

		public ConsoleMessageEventArgs(ConsoleMessage message) {
			Message = message;
		}

	}


}
