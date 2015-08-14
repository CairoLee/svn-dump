using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

	public partial class FrameRateCounter {

		int frameRate = 0;
		int frameCounter = 0;
		TimeSpan elapsedTime = TimeSpan.Zero;

		public void Update( GameTime gameTime ) {
			elapsedTime += gameTime.ElapsedGameTime;

			if( elapsedTime > TimeSpan.FromSeconds( 1 ) ) {
				elapsedTime -= TimeSpan.FromSeconds( 1 );
				frameRate = frameCounter;
				frameCounter = 0;
			}
		}


		public void DrawFps( float X, float Y, SpriteFont Font, SpriteBatch spriteBatch, bool UseShadow ) {
			frameCounter++;

			string fps = string.Format( "Frames per Second: {0}", frameRate );

			spriteBatch.Begin();

			spriteBatch.DrawString( Font, fps, new Vector2( X, Y ), Color.Black );
			if( UseShadow == true )
				spriteBatch.DrawString( Font, fps, new Vector2( X + 1, Y + 1 ), Color.White );

			spriteBatch.End();
		}

	}

}
