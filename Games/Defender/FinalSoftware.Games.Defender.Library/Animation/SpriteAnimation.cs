using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Library.Animation {

	public class SpriteAnimation : IDefenderDraw {
		private Texture2D mTexture;
		private Rectangle mArea;
		private Rectangle mSource;
		private Vector2 mOrigin;
		private bool mAdditive;
		private Color mColor;
		private bool mFinished = false;

		private int mXFrames;
		private int mRows;
		private int mFrame;
		private int mRow;
		private int mFSize;

		private float mFDuration;
		private float mScale;
		private float mTimer;
		private float mAngle;

		public Texture2D Texture {
			get { return mTexture; }
		}

		public Rectangle Area {
			get { return mArea; }
		}

		public Rectangle Source {
			get { return mSource; }
		}

		public bool IsAdditive {
			get { return mAdditive; }
		}

		public bool Finished {
			get { return mFinished; }
		}

		public float Scale {
			get { return mScale; }
		}

		public float Angle {
			get { return mAngle; }
		}

		public Vector2 Origin {
			get { return mOrigin; }
		}

		public virtual Color Color {
			get { return mColor; }
		}


		public SpriteAnimation( Texture2D texture, Vector2 position, float fDuration, float scale, int fSize, float angle, bool additive, Color color ) {
			int side;
			mTexture = texture;
			mFDuration = fDuration;
			mScale = scale;
			mFSize = fSize;
			mAngle = angle;
			mAdditive = additive;
			mColor = color;

			mFrame = -1;
			mRow = 0;
			mTimer = 0.0f;
			side = (int)( fSize * scale );

			mXFrames = texture.Width / fSize;
			mRows = texture.Height / fSize;
			mSource = new Rectangle( -fSize, 0, fSize, fSize );
			mArea = new Rectangle( (int)position.X, (int)position.Y, side, side );

			mOrigin = new Vector2( fSize / 2, fSize / 2 );
		}


		public virtual void Initialize() {
		}

		public virtual void LoadContent() {
		}


		public virtual void Update( GameTime gameTime ) {
			if( mFinished )
				return;
			mTimer += 16;

			if( mTimer <= mFDuration )
				return;

			mFrame++;
			mSource.X += mFSize;
			if( mFrame > mXFrames - 1 ) {
				mRow++;
				if( mRow < mRows ) {
					mFrame = 0;
					mSource.X = 0;
					mSource.Y += mFSize;
				} else
					mFinished = true;
			}
			mTimer = 0f;
		}

		public virtual void Draw( GameTime gameTime, SpriteBatch spriteBatch, SpriteBatch additiveBatch ) {
			if( !IsAdditive )
				spriteBatch.Draw( Texture, Area, Source, Color, Angle, Origin, SpriteEffects.None, 1.0f );
			else
				additiveBatch.Draw( Texture, Area, Source, Color, Angle, Origin, SpriteEffects.None, 1.0f );
		}

	}

}
