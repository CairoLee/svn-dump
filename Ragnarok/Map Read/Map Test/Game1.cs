using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using Map_Formats;

namespace Map_Test {

	public class Game1 : Game {
		GraphicsDeviceManager graphics;
		SpriteBatch Batch;
		SpriteFont font;
		Stopwatch watch;

		GND Gnd;
		GAT Gat;

		Matrix viewMatrix;
		Matrix projectionMatrix;
		Vector2 view;
		Timer timer;

		KeyboardState oldKeyboardState;
		KeyboardState curKeyboardState;

		MouseState oldMouseState;
		MouseState curMouseState;


		int ScaleX = 100, ScaleY = 100;
		int StartX = 0, StartY = 0;
		int fpsCount = 0, fps = 0;
		float rotation = 0f;


		public Game1() {
			graphics = new GraphicsDeviceManager( this );
			Content.RootDirectory = "Content";
			IsMouseVisible = true;

		}

		protected override void Initialize() {

			base.Initialize();
		}

		protected override void LoadContent() {
			Batch = new SpriteBatch( GraphicsDevice );
			font = Content.Load<SpriteFont>( "Arial" );
			view = new Vector2( graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height );

			watch = Stopwatch.StartNew();
			GND.GraphicsDevice = GraphicsDevice;
			Gnd = new GND( @"C:\Dokumente und Einstellungen\Administrator\Desktop\alberta.gnd", @"D:\Spiele\Data Crap\Content_Texture\" );
			Debug.WriteLine( "GND.Read() needed " + watch.ElapsedMilliseconds + " ms" );

			watch = Stopwatch.StartNew();
			Gnd.ExportTextureMap( @"C:\Dokumente und Einstellungen\Administrator\Desktop\alberta.bmp" );
			Debug.WriteLine( "GND.ExportTextureMap() needed " + watch.ElapsedMilliseconds + " ms" );

			watch = Stopwatch.StartNew();
			Gat = new GAT( @"C:\Dokumente und Einstellungen\Administrator\Desktop\alberta.gat" );
			Debug.WriteLine( "GAT.Read() needed " + watch.ElapsedMilliseconds + " ms" );

			watch.Stop();

			timer = new Timer( 1000 );
			timer.Elapsed += new ElapsedEventHandler( timer_tick );
			timer.Enabled = true;
		}

		private void timer_tick( Object obj, ElapsedEventArgs v_args ) {
			fps = fpsCount;
			fpsCount = 0;
		}

		protected override void UnloadContent() {
			Content.Unload();
		}

		private bool WasPressed( Keys Key ) {
			return ( oldKeyboardState.IsKeyDown( Key ) == true && oldKeyboardState.IsKeyDown( Key ) == true );
		}

		public enum EMouseButton {
			LeftButton = 1,
			MiddleButton = 2,
			RightButton = 3,
		}
		private bool WasPressed( EMouseButton Button ) {
			switch( Button ) {
				case EMouseButton.LeftButton:
					return ( oldMouseState.LeftButton == ButtonState.Pressed && curMouseState.LeftButton == ButtonState.Released );
				case EMouseButton.MiddleButton:
					return ( oldMouseState.MiddleButton == ButtonState.Pressed && curMouseState.MiddleButton == ButtonState.Released );
				case EMouseButton.RightButton:
					return ( oldMouseState.RightButton == ButtonState.Pressed && curMouseState.RightButton == ButtonState.Released );
			}

			return false;
		}

		private int GetScroll() {
			return oldMouseState.ScrollWheelValue - curMouseState.ScrollWheelValue;
		}

		protected override void Update( GameTime gameTime ) {
			oldKeyboardState = curKeyboardState;
			curKeyboardState = Keyboard.GetState();
			oldMouseState = curMouseState;
			curMouseState = Mouse.GetState();

			if( WasPressed( Keys.Escape ) == true )
				this.Exit();

			if( WasPressed( Keys.R ) == true ) {
				StartX = StartY = 0;
				ScaleX = ScaleY = 100;
				rotation = 0f;
			}

			if( WasPressed( Keys.Down ) == true )
				StartY--;
			if( WasPressed( Keys.Up ) == true )
				StartY++;
			if( WasPressed( Keys.Left ) == true )
				StartX++;
			if( WasPressed( Keys.Right ) == true )
				StartX--;

			int scroll = GetScroll();
			if( scroll != 0 ) {
				ScaleX = Math.Max( 0, ScaleX - ( scroll / 100 ) );
				ScaleY = Math.Max( 0, ScaleY - ( scroll / 100 ) );
			}

			if( WasPressed( EMouseButton.LeftButton ) == true )
				rotation -= 0.01f;
			if( WasPressed( EMouseButton.RightButton ) == true )
				rotation += 0.01f;


			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime ) {
			GraphicsDevice.Clear( Color.SteelBlue );

			Batch.Begin();

			DrawGND();
			DrawInfo();

			Batch.End();

			base.Draw( gameTime );
		}

		private void DrawInfo() {
			fpsCount++;

			Batch.DrawString( font, "Scale: " + ScaleX + "/" + ScaleY, new Vector2( 5f, 5f ), Color.White );
			Batch.DrawString( font, "Start: " + StartX + "/" + StartY, new Vector2( 5f, 25f ), Color.White );
			Batch.DrawString( font, "Rotation: " + rotation, new Vector2( 5f, 45f ), Color.White );
			Batch.DrawString( font, "FPS: " + fps, new Vector2( 5f, 65f ), Color.White );
		}

		private void DrawGND() {
			int x = -1, y = (int)Gnd.File.Height - 1, yPos = 0 + StartY;
			int cubeNum = 0, tileNum = 0;

			for( int i = 0; i < Gnd.File.Cubes.Length; i++ ) {

				if( ++x >= Gnd.File.Width ) {
					x = 0;
					y--;
					yPos++;
				}

				cubeNum = ( x + ( y * (int)Gnd.File.Width ) );
				if( cubeNum < 0 || cubeNum >= Gnd.File.Cubes.Length )
					continue;
				tileNum = Gnd.File.Cubes[ cubeNum ].TileUp;

				if( tileNum == -1 )
					continue;

				if( view.X < ( ( x + StartX ) * ScaleX + 1 ) && view.Y < ( yPos * ScaleY + 1 ) )
					break;
				else if( view.X < ( ( x + StartX ) * ScaleX + 1 ) || view.Y < ( yPos * ScaleY + 1 ) )
					continue;

				Texture2D tex = Gnd.File.Textures[ Gnd.File.Tiles[ tileNum ].TextureIndex ].TextureTex;
				Vector4 vWidth = Gnd.File.Tiles[ tileNum ].VectorWidth;
				Vector4 vHeight = Gnd.File.Tiles[ tileNum ].VectorHeight;

				int destRectX = (int)( vWidth.X * (float)tex.Width );
				int destRectY = (int)( vHeight.X * (float)tex.Height );
				int endX = (int)( vWidth.Y * (float)tex.Width );
				int endY = (int)( vHeight.Z * (float)tex.Height );

				Rectangle srcRect = new Rectangle( destRectX, destRectY, endX - destRectX, endY - destRectY );
				Rectangle destRect = new Rectangle( ( StartX + x ) * ScaleX + 1, yPos * ScaleY + 1, ScaleX, ScaleY );

				Batch.Draw( tex, destRect, srcRect, Color.White, rotation, Vector2.Zero, SpriteEffects.None, 0 );
			}
		}












		private void InitializeTransform() {

			viewMatrix = Matrix.CreateLookAt(
				new Vector3( 0.0f, 0.0f, 1.0f ),
				Vector3.Zero,
				Vector3.Up
			);

			projectionMatrix = Matrix.CreateOrthographicOffCenter(
				0,
				(float)GraphicsDevice.Viewport.Width,
				(float)GraphicsDevice.Viewport.Height,
				0,
				1.0f, 1000.0f 
			);
		}



	}
}
