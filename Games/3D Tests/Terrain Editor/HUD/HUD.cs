using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ragnarok3D.Editor {
	class HUD {
		SpriteBatch spriteBatch;
		SpriteFont textFont;

		Timer timer;
		int fpsCount = 0;
		int fps = 0;

		public HUD() {
			textFont = Editor.Content.Load<SpriteFont>( @"Fonts\tahoma" );
			spriteBatch = new SpriteBatch( Editor.graphics.GraphicsDevice );

			timer = new Timer( 1000 );
			timer.Elapsed += new ElapsedEventHandler( timer_tick );
			timer.Enabled = true;
		}

		private void timer_tick( Object obj, ElapsedEventArgs v_args ) {
			fps = fpsCount;
			fpsCount = 0;
		}

		public void Update() {
		}

		public void Draw() {
			fpsCount++;

			spriteBatch.Begin( SpriteBlendMode.AlphaBlend );

			if( Editor.console != null && Editor.console.state == ConsoleHUD.State.Closed ) {
				//FPS Count
				spriteBatch.DrawString( textFont, "FPS:" + fps, new Vector2( 750f, 0f ), Color.White );

				//Tool shortcuts
				spriteBatch.DrawString( textFont, "CTRL-S: Settings", new Vector2( 5f, 0f ), Color.White );
				spriteBatch.DrawString( textFont, "[C]: Camera Mode", new Vector2( 5f, 15f ), Color.White );
				spriteBatch.DrawString( textFont, "Mode : " + Editor.camera.state.ToString(), new Vector2( 5f, 30f ), Color.White );
			}

			//Camera information
			if( Editor.camera != null ) {
				spriteBatch.DrawString( textFont, "Camera X: " + Math.Round( Editor.camera.position.X, 5 ), new Vector2( 5f, 540f ), Color.White );
				spriteBatch.DrawString( textFont, "Camera Y: " + Math.Round( Editor.camera.position.Y, 5 ), new Vector2( 5f, 555f ), Color.White );
				spriteBatch.DrawString( textFont, "Camera Z: " + Math.Round( Editor.camera.position.Z, 5 ), new Vector2( 5f, 570f ), Color.White );
			}

			//Ground Cursor information
			if( Editor.heightmap != null ) {
				spriteBatch.DrawString( textFont, "Cursor X: " + Math.Round( Editor.heightmap.groundCursorPosition.X, 5 ), new Vector2( 5f, 485f ), Color.White );
				spriteBatch.DrawString( textFont, "Cursor Y: " + Math.Round( Editor.heightmap.groundCursorPosition.Y, 5 ), new Vector2( 5f, 500f ), Color.White );
				spriteBatch.DrawString( textFont, "Cursor Z: " + Math.Round( Editor.heightmap.groundCursorPosition.Z, 5 ), new Vector2( 5f, 515f ), Color.White );
			}

			spriteBatch.End();
		}
	}
}
