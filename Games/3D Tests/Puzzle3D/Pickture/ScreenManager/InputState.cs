using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Puzzle3D {

	public class InputState {
		public const int MaxInputs = 4;

		public readonly KeyboardState[] CurrentKeyboardStates;
		public readonly GamePadState[] CurrentGamePadStates;

		public readonly KeyboardState[] LastKeyboardStates;
		public readonly GamePadState[] LastGamePadStates;

		public bool MenuUp {
			get { return IsNewKeyPress( Keys.Up ) || IsNewButtonPress( Buttons.DPadUp ) || IsNewButtonPress( Buttons.LeftThumbstickUp ); }
		}

		public bool MenuDown {
			get { return IsNewKeyPress( Keys.Down ) || IsNewButtonPress( Buttons.DPadDown ) || IsNewButtonPress( Buttons.LeftThumbstickDown ); }
		}

		public bool MenuLeft {
			get { return IsNewKeyPress( Keys.Left ) || IsNewButtonPress( Buttons.DPadLeft ) || IsNewButtonPress( Buttons.LeftThumbstickLeft ); }
		}

		public bool MenuRight {
			get { return IsNewKeyPress( Keys.Right ) || IsNewButtonPress( Buttons.DPadRight ) || IsNewButtonPress( Buttons.LeftThumbstickRight ); }
		}

		public bool FlipUp {
			get { return IsNewKeyPress( Keys.W ) || IsNewButtonPress( Buttons.RightThumbstickUp ); }
		}

		public bool FlipDown {
			get { return IsNewKeyPress( Keys.S ) || IsNewButtonPress( Buttons.RightThumbstickDown ); }
		}

		public bool FlipLeft {
			get { return IsNewKeyPress( Keys.A ) || IsNewButtonPress( Buttons.RightThumbstickLeft ); }
		}

		public bool FlipRight {
			get { return IsNewKeyPress( Keys.D ) || IsNewButtonPress( Buttons.RightThumbstickRight ); }
		}

		public bool FlipCameraLeft {
			get { return IsNewKeyPress( Keys.Q ) || IsNewButtonPress( Buttons.LeftTrigger ); }
		}

		public bool FlipCameraRight {
			get { return IsNewKeyPress( Keys.E ) || IsNewButtonPress( Buttons.RightTrigger ); }
		}

		public bool ShiftActiveChip {
			get { return IsNewKeyPress( Keys.Space ) || IsNewButtonPress( Buttons.A ); }
		}

		public bool MenuSelect {
			get { return IsNewKeyPress( Keys.Space ) || IsNewKeyPress( Keys.Enter ) || IsNewButtonPress( Buttons.A ) || IsNewButtonPress( Buttons.Start ); }
		}

		public bool MenuCancel {
			get { return IsNewKeyPress( Keys.Escape ) || IsNewButtonPress( Buttons.B ) || IsNewButtonPress( Buttons.Back ); }
		}

		public bool PauseGame {
			get { return IsNewKeyPress( Keys.Escape ) || IsNewButtonPress( Buttons.Back ) || IsNewButtonPress( Buttons.Start ); }
		}


		public InputState() {
			CurrentKeyboardStates = new KeyboardState[ MaxInputs ];
			CurrentGamePadStates = new GamePadState[ MaxInputs ];

			LastKeyboardStates = new KeyboardState[ MaxInputs ];
			LastGamePadStates = new GamePadState[ MaxInputs ];
		}


		public void Update() {
			for( int i = 0; i < MaxInputs; i++ ) {
				LastKeyboardStates[ i ] = CurrentKeyboardStates[ i ];
				LastGamePadStates[ i ] = CurrentGamePadStates[ i ];

				CurrentKeyboardStates[ i ] = Keyboard.GetState( (PlayerIndex)i );
				CurrentGamePadStates[ i ] = GamePad.GetState( (PlayerIndex)i );
			}
		}


		public bool IsNewKeyPress( Keys key ) {
			for( int i = 0; i < MaxInputs; i++ )
				if( IsNewKeyPress( key, (PlayerIndex)i ) )
					return true;
			return false;
		}


		public bool IsNewKeyPress( Keys key, PlayerIndex playerIndex ) {
			return ( CurrentKeyboardStates[ (int)playerIndex ].IsKeyDown( key ) && LastKeyboardStates[ (int)playerIndex ].IsKeyUp( key ) );
		}


		public bool IsNewButtonPress( Buttons button ) {
			for( int i = 0; i < MaxInputs; i++ )
				if( IsNewButtonPress( button, (PlayerIndex)i ) )
					return true;
			return false;
		}


		public bool IsNewButtonPress( Buttons button, PlayerIndex playerIndex ) {
			return ( CurrentGamePadStates[ (int)playerIndex ].IsButtonDown( button ) && LastGamePadStates[ (int)playerIndex ].IsButtonUp( button ) );
		}


		public bool IsMenuSelect( PlayerIndex playerIndex ) {
			return IsNewKeyPress( Keys.Space, playerIndex ) || IsNewKeyPress( Keys.Enter, playerIndex ) || IsNewButtonPress( Buttons.A, playerIndex ) || IsNewButtonPress( Buttons.Start, playerIndex );
		}


		public bool IsMenuCancel( PlayerIndex playerIndex ) {
			return IsNewKeyPress( Keys.Escape, playerIndex ) || IsNewButtonPress( Buttons.B, playerIndex ) || IsNewButtonPress( Buttons.Back, playerIndex );
		}

	}

}
