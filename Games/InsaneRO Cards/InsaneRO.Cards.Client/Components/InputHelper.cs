using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InsaneRO.Cards.Client.Compontents {

	public class InputHelper : DrawableGameComponent {
		private SpriteBatch mSpriteBatch;
		private SpriteFont mSpriteFont;

		private KeyboardState mCurrentKeyState;
		private KeyboardState mPreviousKeyState;
		private MouseState mCurrentMouseState;
		private MouseState mPreviousMouseState;

		private bool mDebugPosition = false;
		private Vector2 mMousePosition;

		public Vector2 MousePosition {
			get { return mMousePosition; }
		}

		public bool DebugPosition {
			get { return mDebugPosition; }
			set { mDebugPosition = value; }
		}


		public float ScrollWheelDelta {
			get { return MathHelper.Clamp( ( mCurrentMouseState.ScrollWheelValue - mPreviousMouseState.ScrollWheelValue ), -1, 1 ); }
		}

		public Keys[] PressedKeys {
			get { return mCurrentKeyState.GetPressedKeys(); }
		}


		public InputHelper( Game game )
			: base( game ) {
			mPreviousKeyState = mCurrentKeyState = Keyboard.GetState();

			mPreviousMouseState = mCurrentMouseState = Mouse.GetState();
			mMousePosition = new Vector2( mCurrentMouseState.X, mCurrentMouseState.Y );
		}

		protected override void LoadContent() {
			mSpriteBatch = new SpriteBatch( Game.GraphicsDevice );
			mSpriteFont = Game.Content.Load<SpriteFont>( @"Fonts\FPS" );

			base.LoadContent();
		}

		public override void Update( GameTime gameTime ) {
			mPreviousMouseState = mCurrentMouseState;
			mCurrentMouseState = Mouse.GetState();

			mMousePosition.X = mCurrentMouseState.X;
			mMousePosition.Y = mCurrentMouseState.Y;

			mPreviousKeyState = mCurrentKeyState;
			mCurrentKeyState = Keyboard.GetState();

			base.Update( gameTime );
		}

		public override void Draw( GameTime gameTime ) {
			base.Draw( gameTime );
			if( Game.GraphicsDevice == null ) // Client exit
				return;

			if( DebugPosition == true ) {
				string state = String.Format( "X: {0}\nY: {1}", mMousePosition.X, mMousePosition.Y );
				Vector2 vector_state = mSpriteFont.MeasureString( state );
				Vector2 pos = new Vector2( Game.GraphicsDevice.Viewport.Width - 40f - vector_state.X, Game.GraphicsDevice.Viewport.Height - 40f - vector_state.Y );

				mSpriteBatch.Begin();
				mSpriteBatch.DrawString( mSpriteFont, state, pos, Color.White );
				mSpriteBatch.End();
			}

		}



		public bool WasMouseButtonPressed( EMouseButtons mb ) {
			return ( IsMouseButtonDown( mb ) && IsMouseButtonState( mb, ButtonState.Released, mPreviousMouseState ) );
		}

		public bool IsMouseButtonReleased( EMouseButtons mb ) {
			return ( IsMouseButtonUp( mb ) && IsMouseButtonState( mb, ButtonState.Pressed, mPreviousMouseState ) );
		}

		public bool IsMouseButtonDown( EMouseButtons mb ) {
			return IsMouseButtonState( mb, ButtonState.Pressed, mCurrentMouseState );
		}

		public bool IsMouseButtonUp( EMouseButtons mb ) {
			return IsMouseButtonState( mb, ButtonState.Released, mCurrentMouseState );
		}

		private bool IsMouseButtonState( EMouseButtons mb, ButtonState state, MouseState mouseState ) {
			switch( mb ) {
				case EMouseButtons.LeftButton:
					return ( mouseState.LeftButton == state );
				case EMouseButtons.MiddleButton:
					return ( mouseState.MiddleButton == state );
				case EMouseButtons.RightButton:
					return ( mouseState.RightButton == state );
				case EMouseButtons.XButton1:
					return ( mouseState.XButton1 == state );
				case EMouseButtons.XButton2:
					return ( mouseState.XButton2 == state );
			}
			return false;
		}


		public bool WasKeyPressed( Keys key ) {
			return ( mCurrentKeyState.IsKeyDown( key ) && mPreviousKeyState.IsKeyUp( key ) );
		}

		public bool IsKeyReleased( Keys key ) {
			return ( mCurrentKeyState.IsKeyUp( key ) && mPreviousKeyState.IsKeyDown( key ) );
		}

		public bool IsKeyDown( Keys key ) {
			return mCurrentKeyState.IsKeyDown( key );
		}

		public bool IsKeyUp( Keys key ) {
			return mCurrentKeyState.IsKeyUp( key );
		}

	}

	public enum EMouseButtons {
		LeftButton,
		MiddleButton,
		RightButton,
		XButton1,
		XButton2
	}

}
