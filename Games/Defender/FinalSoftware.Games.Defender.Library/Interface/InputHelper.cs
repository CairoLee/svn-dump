using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalSoftware.Games.Defender.Library.Interface {

	public class InputHelper : DrawableGameComponent {
		private SpriteBatch mSpriteBatch;
		private SpriteFont mSpriteFont;

		private KeyboardState mCurrentKeyState;
		private KeyboardState mPreviousKeyState;

		private MouseState mCurrentMouseState;
		private MouseState mPreviousMouseState;

		private Vector2 mMousePosition;
		private Point mMousePositionReal;
		private Rectangle mMouseTile;
		private Rectangle mMouseBounds;
		private Rectangle mMouseBoundsReal;

		public bool DrawDebug {
			get;
			set;
		}

		public KeyboardState KeyState {
			get { return mCurrentKeyState; }
		}

		public KeyboardState KeyStatePrevious {
			get { return mPreviousKeyState; }
		}

		public MouseState MouseState {
			get { return mCurrentMouseState; }
		}

		public MouseState MouseStatePrevious {
			get { return mPreviousMouseState; }
		}


		public Vector2 Position {
			get { return mMousePosition; }
		}
		public Point PositionReal {
			get { return mMousePositionReal; }
		}

		public Rectangle Bounds {
			get { return mMouseBounds; }
		}
		public Rectangle BoundsReal {
			get { return mMouseBoundsReal; }
		}

		public Rectangle MouseTile {
			get { return mMouseTile; }
		}

		public float ScrollWheelDelta {
			get { return MathHelper.Clamp( ( mCurrentMouseState.ScrollWheelValue - mPreviousMouseState.ScrollWheelValue ), -1, 1 ); }
		}

		public Keys[] PressedKeys {
			get { return mCurrentKeyState.GetPressedKeys(); }
		}

		public Camera2D Camera {
			get { return DefenderWorld.Instance.Interface.Camera; }
		}


		public InputHelper( DefenderGame game )
			: base( game ) {
		}

		protected override void LoadContent() {
			mSpriteBatch = new SpriteBatch( Game.GraphicsDevice );
			mSpriteFont = Game.Content.Load<SpriteFont>( @"FPS" );

			base.LoadContent();
		}

		public override void Update( GameTime gameTime ) {
			mPreviousMouseState = mCurrentMouseState;
			mCurrentMouseState = Mouse.GetState();

			mMousePosition.X = mCurrentMouseState.X;
			mMousePosition.Y = mCurrentMouseState.Y;
			UpdateMouse();

			mPreviousKeyState = mCurrentKeyState;
			mCurrentKeyState = Keyboard.GetState();

			base.Update( gameTime );
		}

		private void UpdateMouse() {
			mMousePosition = new Vector2( mPreviousMouseState.X / Camera.Zoom + Camera.ViewArea.Left, mPreviousMouseState.Y / Camera.Zoom + Camera.ViewArea.Top );
			mMousePositionReal = new Point( mCurrentMouseState.X, mCurrentMouseState.Y );
			mMouseBounds = new Rectangle( (int)mMousePosition.X, (int)mMousePosition.Y, 1, 1 );
			mMouseBoundsReal = new Rectangle( mMousePositionReal.X, mMousePositionReal.Y, 1, 1 );
			mMouseTile = new Rectangle( (int)( mMousePosition.X / DefenderWorld.TileSize ) * DefenderWorld.TileSize, (int)( mMousePosition.Y / DefenderWorld.TileSize ) * DefenderWorld.TileSize, DefenderWorld.TileSize * 2, DefenderWorld.TileSize * 2 );
		}

		public override void Draw( GameTime gameTime ) {
			base.Draw( gameTime );
			if( DrawDebug == false || Game.GraphicsDevice == null )
				return;

			string state = String.Format( "X: {0}\nY: {1}", mMousePosition.X, mMousePosition.Y );
			Vector2 vector_state = mSpriteFont.MeasureString( state );
			Vector2 pos = new Vector2( Game.GraphicsDevice.Viewport.Width - 40f - vector_state.X, Game.GraphicsDevice.Viewport.Height - 40f - vector_state.Y );

			mSpriteBatch.Begin();
			mSpriteBatch.DrawString( mSpriteFont, state, pos, Color.White );
			mSpriteBatch.End();
		}



		public bool WasButtonPressed( EMouseButtons mb ) {
			return ( IsButtonUp( mb ) && IsMouseButtonState( mb, ButtonState.Pressed, mPreviousMouseState ) );
		}

		public bool IsButtonDown( EMouseButtons mb ) {
			return IsMouseButtonState( mb, ButtonState.Pressed, mCurrentMouseState );
		}

		public bool IsButtonUp( EMouseButtons mb ) {
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
			}
			return false;
		}


		public bool WasKeyPressed( Keys key ) {
			return ( mCurrentKeyState.IsKeyUp( key ) && mPreviousKeyState.IsKeyDown( key ) );
		}

		public bool IsKeyDown( Keys key ) {
			return mCurrentKeyState.IsKeyDown( key );
		}

		public bool IsKeyUp( Keys key ) {
			return mCurrentKeyState.IsKeyUp( key );
		}

	}

}
