//======================================================================
// XNA Terrain Editor
// Copyright (C) 2008 Eric Grossinger
// http://psycad007.spaces.live.com/
//======================================================================
using System;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cam_Test {

	public class ConsoleInfo {
		SpriteBatch spriteBatch;
		SpriteFont textFont;

		Timer timer;
		int fpsCount = 0;
		int fps = 0;

		public ConsoleInfo() {
			textFont = CamTest.content.Load<SpriteFont>(@"Fonts\tahoma");
			spriteBatch = new SpriteBatch(CamTest.graphics.GraphicsDevice);

			timer = new Timer(1000);
			timer.Elapsed += new ElapsedEventHandler(timer_tick);
			timer.Enabled = true;
		}

		private void timer_tick(Object obj, ElapsedEventArgs v_args) {
			fps = fpsCount;
			fpsCount = 0;
		}

		public void Update() {
		}

		public void Draw() {
			fpsCount++;

			spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

			if (CamTest.console != null) {
				spriteBatch.DrawString(textFont, "FPS:" + fps, new Vector2(CamTest.graphics.PreferredBackBufferWidth - 50, 0f), Color.White);
				spriteBatch.DrawString(textFont, "Cam Mode : " + CamTest.camera.state.ToString(), new Vector2(5f, 15f), Color.White);
			}

			/*
			if( CamTest.Ani != null ) {
				spriteBatch.DrawString( textFont, "Animation Position X:" + CamTest.Ani.Position.X, new Vector2( 5f, 30f ), Color.White );
				spriteBatch.DrawString( textFont, "Animation Position Y:" + CamTest.Ani.Position.Y, new Vector2( 5f, 45f ), Color.White );
				spriteBatch.DrawString( textFont, "Animation Position FPS:" + CamTest.Ani.CurrentAnimation.FramesPerSecond, new Vector2( 5f, 60f ), Color.White );
			}
			*/
			if (CamTest.camera != null) {
				spriteBatch.DrawString(textFont, "Camera Position X: " + Math.Round(CamTest.camera.position.X, 5), new Vector2(5f, CamTest.graphics.PreferredBackBufferHeight - 115), Color.White);
				spriteBatch.DrawString(textFont, "Camera Position Y: " + Math.Round(CamTest.camera.position.Y, 5), new Vector2(5f, CamTest.graphics.PreferredBackBufferHeight - 90), Color.White);
				spriteBatch.DrawString(textFont, "Camera Position Z: " + Math.Round(CamTest.camera.position.Z, 5), new Vector2(5f, CamTest.graphics.PreferredBackBufferHeight - 75), Color.White);

				spriteBatch.DrawString(textFont, "Camera Rotation X: " + Math.Round(CamTest.camera.rotation.X, 5), new Vector2(5f, CamTest.graphics.PreferredBackBufferHeight - 60), Color.White);
				spriteBatch.DrawString(textFont, "Camera Rotation Y: " + Math.Round(CamTest.camera.rotation.Y, 5), new Vector2(5f, CamTest.graphics.PreferredBackBufferHeight - 45), Color.White);
				spriteBatch.DrawString(textFont, "Camera Rotation Z: " + Math.Round(CamTest.camera.rotation.Z, 5), new Vector2(5f, CamTest.graphics.PreferredBackBufferHeight - 30), Color.White);
			}

			spriteBatch.End();
		}
	}
}
