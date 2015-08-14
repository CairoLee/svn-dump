using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FreeWorld.Engine;

namespace FreeWorld.Game.Components {

	public class CompFpsDisplay : DrawableGameComponent {
		private SpriteBatch mSpriteBatch;
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



		public CompFpsDisplay(Core game)
			: base(game) {
		}

		protected override void LoadContent() {
			mSpriteBatch = new SpriteBatch(GraphicsDevice);
			mSpriteFont = EngineCore.ContentLoader.Load<SpriteFont>(@"Fonts\FPS");

			base.LoadContent();
		}

		public override void Draw(GameTime gameTime) {
			base.Draw(gameTime);

			if (Active == false)
				return;

			var vecPos = new Vector2(PosX, Constants.GraphicsDevice.Viewport.Height - PosY - mSpriteFont.MeasureString(mThisFps.ToString()).Y);
			mSpriteBatch.Begin();
			mSpriteBatch.DrawStringShadowed(mSpriteFont, "FPS: " + mThisFps.ToString(), vecPos, Color.White, Color.Black);
			mSpriteBatch.DrawStringShadowed(mSpriteFont, "Low: " + mLowestFps.ToString(), new Vector2(vecPos.X, vecPos.Y + 15f), Color.White, Color.Black);
			mSpriteBatch.DrawStringShadowed(mSpriteFont, "High: " + mHighestFps.ToString(), new Vector2(vecPos.X, vecPos.Y + 30f), Color.White, Color.Black);
			mSpriteBatch.End();

		}

		public override void Update(GameTime gameTime) {
			mElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
			if (mElapsedTime < 0.25) // update interval
				return;

			mElapsedTime -= 0.25;

			mThisFps = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (mThisFps < mLowestFps)
				mLowestFps = mThisFps;
			if (mThisFps > mHighestFps)
				mHighestFps = mThisFps;

		}

	}

}
