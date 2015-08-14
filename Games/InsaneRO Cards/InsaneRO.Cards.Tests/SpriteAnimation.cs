using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace InsaneRO.Cards.Tests {

	public class SpriteAnimation : ICloneable {
		public List<SpriteAnimationFrame> Frames = new List<SpriteAnimationFrame>();

		private float mFrameLength = 0.050f;
		private int mCurrentFrame = -1;
		private float mFrameTimer = 0f;

		public float FrameLength {
			get { return mFrameLength; }
			set { mFrameLength = value; }
		}

		public int CurrentFrame {
			get { return mCurrentFrame; }
			set { mCurrentFrame = value; }
		}

		public SpriteAnimationFrame this[ int Index ] {
			get { return Frames[ Index ]; }
		}


		public SpriteAnimation() {
		}

		public SpriteAnimation( SpriteAnimationFrame[] frames ) {
			Frames = new List<SpriteAnimationFrame>();
			Frames.AddRange( frames.Clone() as SpriteAnimationFrame[] );
		}

		public SpriteAnimation( List<SpriteAnimationFrame> frames ) {
			Frames = new List<SpriteAnimationFrame>();
			Frames.AddRange( frames.ToArray() );
		}


		public void Update( double TotalSeconds ) {
			if( Frames.Count == 0 ) {
				mCurrentFrame = -1;
				return;
			}

			mFrameTimer += (float)TotalSeconds;
			if( mFrameTimer >= mFrameLength ) {
				mFrameTimer = 0f;

				mCurrentFrame = ( mCurrentFrame + 1 ) % Frames.Count;
			}
		}

		public void Draw( SpriteBatch spriteBatch, Point basePos ) {
			if( mCurrentFrame == -1 )
				return;

			SpriteAnimationFrameImage img;
			Rectangle destRect, srcRect;
			for( int i = 0; i < Frames[ mCurrentFrame ].Images.Count; i++ ) {
				img = Frames[ mCurrentFrame ][ i ];
				srcRect = img.Bounds;
				destRect = new Rectangle( basePos.X + img.Position.X, basePos.Y + img.Position.Y, srcRect.Width, srcRect.Height );
				if( img.Rotation > 0 )
					spriteBatch.Draw( img.Texture, destRect, srcRect, Color.White, img.Rotation, new Vector2( (float)srcRect.Width / 2f, (float)srcRect.Height / 2f ), img.Mirror, 0f );
				else
					spriteBatch.Draw( img.Texture, destRect, srcRect, Color.White, img.Rotation, Vector2.Zero, img.Mirror, 0f );
			}

		}


		public object Clone() {
			return new SpriteAnimation( this.Frames );
		}

	}

}
