using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Games.Match3 {

	public class Sprite {
		private readonly Texture2D mTexture;
		private readonly int mWidth;
		private readonly int mFrameCount;
		private readonly int mHeight;
		private int mCurrentFrame;
		private int mElapsedTime;
		private Rectangle mSourceRect;

		public bool Active;
		public bool Loop;
		public Color Color;
		public int Speed;
		public Vector2 SrcPosition;

		private int mFrameTime {
			get { return (1000 / Speed); }
		}


		public Sprite(Texture2D texture)
			: this(texture, texture.Width, texture.Height, Vector2.Zero) {
		}

		public Sprite(Texture2D texture, int width, int height, Vector2 srcPosition)
			: this(texture, width, height, srcPosition, 1, 0, true) {
		}

		public Sprite(Texture2D texture, int frameCount, int speed, bool loop)
			: this(texture, texture.Width / frameCount, texture.Height, Vector2.Zero, frameCount, speed, loop) {
		}

		public Sprite(Texture2D texture, int width, int height, Vector2 srcPosition, int frameCount, int speed, bool loop) {
			mTexture = texture;
			Speed = speed;
			mWidth = width;
			mHeight = height;
			SrcPosition = srcPosition;
			Color = Color.White;
			Active = true;
			Loop = loop;
			mFrameCount = frameCount;
			mCurrentFrame = 0;
		}


		public void Draw(SpriteBatch spriteBatch, Vector2 position, float scale) {
			var destinationRectangle = new Rectangle {
				Width = (int)(mWidth * scale),
				Height = (int)(mHeight * scale),
				X = (int)position.X,
				Y = (int)position.Y
			};

			if (Active) {
				spriteBatch.Draw(mTexture, destinationRectangle, mSourceRect, Color);
			}
		}

		public void Update(GameTime gameTime) {
			if (!Active) {
				return;
			}

			if (Speed > 0) {
				mElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
				if (mElapsedTime >= mFrameTime) {
					mCurrentFrame++;
					mElapsedTime = 0;
					if (mCurrentFrame == mFrameCount) {
						mCurrentFrame = 0;
						if (!Loop) {
							Active = false;
						}
					}
				}
			}

			mSourceRect.X = ((int)SrcPosition.X) + (mCurrentFrame * mWidth);
			mSourceRect.Y = (int)SrcPosition.Y;
			mSourceRect.Width = mWidth;
			mSourceRect.Height = mHeight;
		}

	}

}