using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Shaiya_Model_Viewer.Library;

namespace Shaiya_Model_Viewer.Test {

	public class Viewer : Microsoft.Xna.Framework.Game {
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private Format3DC mModel;

		private KeyboardState mOldKeyboardState;
		private KeyboardState mNewKeyboardState;
		private MouseState mOldMouseState;
		private MouseState mNewMouseState;

		private Vector3 mPosition = Vector3.One;
		private float mZoom = 100;
		private float mRotationY = 0.0f;
		private float mRotationX = 0.0f;
		private Matrix mGameWorldRotation;


		public Viewer() {
			graphics = new GraphicsDeviceManager( this );
			Content.RootDirectory = "Content";

			IsMouseVisible = true;
		}


		protected override void Initialize() {
			base.Initialize();
		}

		protected override void LoadContent() {
			spriteBatch = new SpriteBatch( GraphicsDevice );
			mModel = new Format3DC( @"D:\Spiele\Shaiya\data\Character\DeathEater\3DC\demf_boots001.3DC" );
			mModel.Read();
		}


		protected override void UnloadContent() {
			Content.Unload();
		}

		protected override void Update( GameTime gameTime ) {
			if( mNewKeyboardState.IsKeyDown( Keys.Escape ) == true )
				this.Exit();

			UpdateKeyAndMouse();

			base.Update( gameTime );
		}

		private void UpdateKeyAndMouse() {
			mOldKeyboardState = mNewKeyboardState;
			mNewKeyboardState = Keyboard.GetState();
			mOldMouseState = mNewMouseState;
			mNewMouseState = Mouse.GetState();

			if( mNewKeyboardState.IsKeyDown( Keys.Escape ) == true ) {
				Exit();
				return;
			}

			if( mNewKeyboardState.IsKeyDown( Keys.Left ) == true )
				mPosition.X -= 0.1f;
			if( mNewKeyboardState.IsKeyDown( Keys.Right ) == true )
				mPosition.X += 0.1f;
			if( mNewKeyboardState.IsKeyDown( Keys.Up ) == true )
				mPosition.Y += 0.1f;
			if( mNewKeyboardState.IsKeyDown( Keys.Down ) == true )
				mPosition.Y -= 0.1f;

			if( mNewMouseState.RightButton == ButtonState.Pressed ) {
				float deltaX = mNewMouseState.X - mOldMouseState.X;
				float deltaY = mNewMouseState.Y - mOldMouseState.Y;
				if( deltaX != 0 )
					mRotationY -= deltaX / 100f;
				if( deltaY != 0 )
					mRotationX -= deltaY / 100f;
			}

			float deltaZoom = mNewMouseState.ScrollWheelValue - mOldMouseState.ScrollWheelValue;
			if( deltaZoom != 0 ) {
				mZoom += deltaZoom / 100f;
				System.Diagnostics.Debug.WriteLine( "Zoom = " + mZoom );
			}


			mGameWorldRotation = Matrix.CreateRotationX( mRotationX ) * Matrix.CreateRotationY( mRotationY );
		}

		protected override void Draw( GameTime gameTime ) {
			GraphicsDevice.Clear( Color.CornflowerBlue );

			mModel.Draw( GraphicsDevice, mGameWorldRotation, mPosition, mZoom );			
		}


	}

}
