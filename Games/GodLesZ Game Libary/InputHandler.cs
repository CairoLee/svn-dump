using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace GLibary {
	public partial class Utility {
		private static InputState inputState = null;

		public static InputState InputState {
			get {
				if( inputState == null ) {
					inputState = new InputState( game );
					game.Components.Add( InputState );
				}
				return inputState;
			}
			set {
				if( inputState != null ) {
					RemoveService<InputService>();
				}
				inputState = value;
				AddService<InputService>( new InputService( inputState ) );
			}
		}
	}

	public interface IInputService {
		InputState InputState {
			get;
		}
	}

	public class InputService : IInputService {

		public InputService( InputState inputState ) {
			this.inputState = inputState;
		}

		private InputState inputState;

		public InputState InputState {
			get {
				return inputState;
			}
		}

		public static implicit operator InputState( InputService cs ) {
			return cs.InputState;
		}
	}

	public enum MouseButtons {
		LeftButton,
		MiddleButton,
		RightButton,
		XButton1,
		XButton2
	}

	public class InputState : GameComponent {
		public bool FreeRoam {
			get;
			set;
		}

		private KeyboardState currentKeyState;
		private KeyboardState previousKeyState;



		private readonly Keys[] keyArray = Utility.GetValuesArray<Keys>();
		private readonly Buttons[] buttonArray = Utility.GetValuesArray<Buttons>();

		private MouseState currentMouseState;
		private MouseState previousMouseState;

		public InputState( Game g )	: base( g ) {
			FreeRoam = false;

			previousKeyState = Keyboard.GetState();
			currentKeyState = previousKeyState;

			previousMouseState = Mouse.GetState();
			currentMouseState = previousMouseState;
			mousePosition = new Vector2( currentMouseState.X, currentMouseState.Y );
		}

		public override void Update( GameTime gameTime ) {
			previousMouseState = currentMouseState;
			currentMouseState = Mouse.GetState();

			mousePosition.X = currentMouseState.X;
			mousePosition.Y = currentMouseState.Y;

			previousKeyState = currentKeyState;
			currentKeyState = Keyboard.GetState();

			if( FreeRoam ) {
				CameraControllerFreeRoam.Update( gameTime );
			}
		}

		public bool IsEscapeDown() {
			return IsKeyDown( Keys.Escape );
		}


		// Latest Mouse Position as Vector2.
		private Vector2 mousePosition;
		public Vector2 MousePosition {
			get {
				return mousePosition;
			}
			set {
				mousePosition = value;
				Mouse.SetPosition( (int)mousePosition.X, (int)mousePosition.Y );

				Utility.SetPrivateMemberValueType<MouseState, int>( ref currentMouseState, "x", (int)mousePosition.X );
				Utility.SetPrivateMemberValueType<MouseState, int>(	ref currentMouseState, "y", (int)mousePosition.Y );
				Utility.SetPrivateMemberValueType<MouseState, int>(	ref previousMouseState, "x", (int)mousePosition.X );
				Utility.SetPrivateMemberValueType<MouseState, int>(	ref previousMouseState, "y", (int)mousePosition.Y );
			}
		}

		Vector2 mousePositionDelta = Vector2.Zero;
		public Vector2 MousePositionDelta {
			get {
				mousePositionDelta.X = (float)currentMouseState.X - (float)previousMouseState.X;
				mousePositionDelta.Y = (float)currentMouseState.Y - (float)previousMouseState.Y;

				return mousePositionDelta;
			}
		}

		// Normalized Delta ScrollWheelValue.
		public float ScrollWheelDelta {
			get {
				return MathHelper.Clamp( ( currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue ), -1, 1 );
			}
		}

		// Newly Pressed Button
		public bool IsMouseButtonPress( MouseButtons mb ) {
			return ( IsMouseButtonDown( mb ) && IsMouseButtonState( mb, ButtonState.Released, ref previousMouseState ) );
		}

		// Newly Released Button
		public bool IsMouseButtonRelease( MouseButtons mb ) {
			return ( IsMouseButtonUp( mb ) && IsMouseButtonState( mb, ButtonState.Pressed, ref previousMouseState ) );
		}

		// Continuously Pressed Button.
		public bool IsMouseButtonDown( MouseButtons mb ) {
			return IsMouseButtonState( mb, ButtonState.Pressed,	ref currentMouseState );
		}

		// Continuously Released Button.
		public bool IsMouseButtonUp( MouseButtons mb ) {
			return IsMouseButtonState( mb, ButtonState.Released, ref currentMouseState );
		}

		// Base method
		private bool IsMouseButtonState( MouseButtons mb, ButtonState state, ref MouseState mouseState ) {
			switch( mb ) {
				case MouseButtons.LeftButton:
					return ( mouseState.LeftButton == state );
				case MouseButtons.MiddleButton:
					return ( mouseState.MiddleButton == state );
				case MouseButtons.RightButton:
					return ( mouseState.RightButton == state );
				case MouseButtons.XButton1:
					return ( mouseState.XButton1 == state );
				case MouseButtons.XButton2:
					return ( mouseState.XButton2 == state );
			}
			return false;
		}

		// Newly Pressed Key
		public bool IsKeyPress( Keys key ) {
			return ( currentKeyState.IsKeyDown( key ) && previousKeyState.IsKeyUp( key ) );
		}

		// Newly Released Key
		public bool IsKeyRelease( Keys key ) {
			return ( currentKeyState.IsKeyUp( key ) && previousKeyState.IsKeyDown( key ) );
		}

		// Continuously Pressed Key
		public bool IsKeyDown( Keys key ) {
			return currentKeyState.IsKeyDown( key );
		}

		// Continuously Released Key
		public bool IsKeyUp( Keys key ) {
			return currentKeyState.IsKeyUp( key );
		}

	}

}