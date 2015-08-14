using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Engine3DFromRiemersTutorial {
	public class Fps : DrawableGameComponent {
		private int mFramesPerSecond = 0;
		private int mFrameCounter = 0;
		private TimeSpan mElapsedTime = TimeSpan.Zero;
		private SpriteBatch mBatch;
		private SpriteFont mFont;
		private Game mGame;
		private string BaseTitle = string.Empty;

		public Fps( Game game )
			: base( game ) {
			mGame = game;
		}

		protected override void LoadContent() {
			mFont = mGame.Content.Load<SpriteFont>( @"Fonts\Arial" );

			base.LoadContent();
		}

		public override void Initialize() {
			mBatch = new SpriteBatch( mGame.GraphicsDevice );

			base.Initialize();
		}

		public override void Update( GameTime gameTime ) {
			mElapsedTime += gameTime.ElapsedGameTime;

			if( mElapsedTime >= TimeSpan.FromSeconds( 1 ) ) {
				mElapsedTime -= TimeSpan.FromSeconds( 1 );
				mFramesPerSecond = mFrameCounter;
				mFrameCounter = 0;
			}

			base.Update( gameTime );
		}

		public override void Draw( GameTime gameTime ) {
			mFrameCounter++;
			if( BaseTitle == string.Empty )
				BaseTitle = mGame.Window.Title;

			mGame.Window.Title = BaseTitle + " - FPS[" + mFramesPerSecond + "]";

			//mBatch.Begin();
			//mBatch.DrawString( mFont, "FPS: " + mFramesPerSecond, new Vector2( 50f, 50f ), Color.Black );
			//mBatch.End();

			base.Draw( gameTime );
		}
	}
}
