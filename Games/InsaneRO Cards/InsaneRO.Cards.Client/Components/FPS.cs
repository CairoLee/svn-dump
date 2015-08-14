using System;
using System.Timers;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace InsaneRO.Cards.Client.Components {

	public class FPS : DrawableGameComponent {
		private SpriteBatch mSpriteBatch;
		private SpriteFont mSpriteFont;

		private float mPosX = 40f;
		private float mPosY = 40f;

		private bool mIsActive = true;

		private int afps = 0;
		private int fps = 0;
		private double et = 0;
		public static long Frames = 0;

		public bool Active {
			get { return mIsActive; }
			set { mIsActive = value; }
		}

		public float PosX {
			get { return mPosX; }
			set { mPosX = value; }
		}

		public float PosY {
			get { return mPosY; }
			set { mPosY = value; }
		}


		public FPS( Game game )
			: base( game ) {
		}


		protected override void LoadContent() {
			mSpriteBatch = new SpriteBatch( GraphicsDevice );
			mSpriteFont = Game.Content.Load<SpriteFont>( @"Fonts\FPS" );

			base.LoadContent();
		}

		public override void Draw( GameTime gameTime ) {
			base.Draw( gameTime );

			if( Active == false )
				return;

			if( Frames >= long.MaxValue - 1 )
				Frames = 0; // prevent overflow
			Frames++;

			Vector2 vecPos = new Vector2( PosX, Game.GraphicsDevice.Viewport.Height - PosY - mSpriteFont.MeasureString( fps.ToString() ).Y );
			mSpriteBatch.Begin();
			mSpriteBatch.DrawStringShadowed( mSpriteFont, "FPS: " + fps.ToString(), vecPos, Color.White, Color.Black );
			mSpriteBatch.DrawStringShadowed( mSpriteFont, "Avg: " + afps.ToString(), new Vector2( vecPos.X, vecPos.Y + 15f ), Color.White, Color.Black );
			mSpriteBatch.End();

		}

		public override void Update( GameTime gameTime ) {
			if( et >= 500 || et == 0 ) {
				if( gameTime.TotalGameTime.TotalSeconds != 0 )
					afps = (int)( Frames / gameTime.TotalGameTime.TotalSeconds );
				if( gameTime.ElapsedGameTime.TotalMilliseconds != 0 )
					fps = (int)( 1000 / gameTime.ElapsedGameTime.TotalMilliseconds );
				et = 1;
			}
			et += gameTime.ElapsedGameTime.TotalMilliseconds;
		}

	}

}
