using System;
using System.Collections.Generic;
using System.Text;
using InsaneRO.Cards.Library.Formats;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace InsaneRO.Cards.Tests {

	public class AnimationHandler {
		private SpriteAnimation[] mAnimation;
		private RagnarokAnimation mRagnarokAnimation;
		private int mCurrentAction = 0;

		public int ActionCount {
			get { return ( mAnimation == null ? 0 : mAnimation.Length ); }
		}

		public float FrameLength {
			get {
				if( mAnimation == null || mAnimation.Length == 0 )
					throw new Exception( "Animtion is null or has no Actions!" );
				return mAnimation[ 0 ].FrameLength;
			}
			set { SetFrameLength( value ); }
		}


		public AnimationHandler( RagnarokAnimation baseAnimation ) {
			mRagnarokAnimation = baseAnimation;
			mAnimation = new SpriteAnimation[ mRagnarokAnimation.Actions.Count ];
		}


		public void Initialize( GraphicsDevice GraphicsDevice ) {
			// fetch all Actions & build SpriteAnimations from it
			for( int a = 0; a < mRagnarokAnimation.Actions.Count; a++ ) {
				mAnimation[ a ] = new SpriteAnimation();
				for( int f = 0; f < mRagnarokAnimation.Actions[ a ].Frames.Count; f++ ) {
					SpriteAnimationFrame frame = new SpriteAnimationFrame();
					for( int i = 0; i < mRagnarokAnimation.Actions[ a ].Frames[ f ].Images.Count; i++ ) {
						RagnarokAnimationActionFrameImage roImg = mRagnarokAnimation.Actions[ a ].Frames[ f ].Images[ i ];
						SpriteAnimationFrameImage img = new SpriteAnimationFrameImage();
						img.Size = new Point( (int)( roImg.Width * roImg.ScaleX ), (int)( roImg.Height * roImg.ScaleY ) );
						img.Position = new Point( roImg.X, roImg.Y );
						img.Rotation = roImg.Rotation;
						img.Texture = mRagnarokAnimation.Images[ roImg.Number ].BuildTexture2D( mRagnarokAnimation.Palette, GraphicsDevice );
						img.Color = Color.White;
						img.Mirror = ( roImg.Mirror ? SpriteEffects.FlipHorizontally : SpriteEffects.None );


						frame.Images.Add( img );
					}

					mAnimation[ a ].Frames.Add( frame );
				}
			}
		}


		public void SetFrameLength( float value ) {
			for( int i = 0; i < mAnimation.Length; i++ )
				mAnimation[ i ].FrameLength = value;
		}

		public void SetFrameLength( float value, int action ) {
			if( IsValidAction( action ) == false )
				return;
			mAnimation[ action ].FrameLength = value;
		}


		/// <summary>
		/// Draw an Action
		/// </summary>
		/// <param name="action"></param>
		/// <param name="spriteBatch"></param>
		/// <param name="basePos"></param>
		public void DrawAction( int action, SpriteBatch spriteBatch, Point basePos ) {
			if( IsValidAction( action ) == false )
				return;

			mAnimation[ action ].Draw( spriteBatch, basePos );
		}

		/// <summary>
		/// Draw all Actions in a row
		/// </summary>
		/// <param name="action"></param>
		/// <param name="spriteBatch"></param>
		/// <param name="basePos"></param>
		public void DrawAction( SpriteBatch spriteBatch, Point basePos ) {
			mAnimation[ mCurrentAction ].Draw( spriteBatch, basePos );
		}

		/// <summary>
		/// Update one single Action
		/// </summary>
		/// <param name="action"></param>
		/// <param name="totalTime"></param>
		public void Update( int action, double totalTime ) {
			if( IsValidAction( action ) == false )
				return;
			mAnimation[ action ].Update( totalTime );
		}
		/// <summary>
		/// Update all Actions
		/// </summary>
		/// <param name="totalTime"></param>
		public void Update( double totalTime ) {
			// save old frame
			int oldFrame = mAnimation[ mCurrentAction ].CurrentFrame;

			// update alle Frames
			for( int i = 0; i < mAnimation.Length; i++ )
				mAnimation[ i ].Update( totalTime );

			// check if Action has been reseted
			if( oldFrame != 0 && mAnimation[ mCurrentAction ].CurrentFrame == 0 )
				mCurrentAction = ( mCurrentAction + 1 ) % mAnimation[ mCurrentAction ].Frames.Count;
		}


		public bool IsValidAction( int action ) {
			return ( action >= 0 && action < mAnimation.Length );
		}

	}

}
