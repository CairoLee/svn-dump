using System;
using System.Timers;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Shaiya.Extended.Client.Library;

namespace Shaiya.Extended.Client {

	public class FPS : DrawableGameComponent {
		private SpriteFont mSpriteFont;

		private float mPosX = 40f;
		private float mPosY = 40f;

		private bool mIsActive = true;

		private double mElapsedTime = 0f;
		private float mThisFps = 0f;
		private float mLowestFps = 9999f;
		private float mHighestFps = 0f;

		/// <summary>
		/// Enable/Disable the FPS Component
		/// Default: Enabled
		/// </summary>
		public bool Active {
			get { return mIsActive; }
			set { mIsActive = value; }
		}

		/// <summary>
		/// Position Manipulating from the Left
		/// </summary>
		public float PosX {
			get { return mPosX; }
			set { mPosX = value; }
		}

		/// <summary>
		/// Position Manipulating from the Bottom
		/// </summary>
		public float PosY {
			get { return mPosY; }
			set { mPosY = value; }
		}



		public FPS( Game game )
			: base( game ) {
		}

		protected override void LoadContent() {
			mSpriteFont = Constants.Content.Load<SpriteFont>( @"Fonts\FPS" );

			base.LoadContent();
		}

		public override void Draw( GameTime gameTime ) {
			base.Draw( gameTime );

			if( Active == false )
				return;

			Vector2 vecPos = new Vector2( PosX, Constants.GraphicsDevice.Viewport.Height - PosY - mSpriteFont.MeasureString( mThisFps.ToString() ).Y );
			Constants.SpriteBatch.Begin();
			Constants.SpriteBatch.DrawStringShadowed( mSpriteFont, this.ToString(), new Vector2( vecPos.X, vecPos.Y ), Color.White, Color.Black );
			Constants.SpriteBatch.End();

		}

		public override void Update( GameTime gameTime ) {
			mElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
			if( mElapsedTime < 0.25 ) // update interval
				return;
			
			mElapsedTime -= 0.25;
			mThisFps = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
			if( mThisFps < mLowestFps )
				mLowestFps = mThisFps;
			if( mThisFps > mHighestFps )
				mHighestFps = mThisFps;

		}



		public override string ToString() {
			string state = string.Format( "FPS: {0}\nLow: {1}\nHigh: {2}", mThisFps, mLowestFps, mHighestFps );
			return state;
		}

	}

}
