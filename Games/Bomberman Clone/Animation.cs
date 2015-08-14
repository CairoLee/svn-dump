using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace Bomberman_Clone {

	public class Animation {
		private int currentRow = 0;
		private double elapsed = 0;
		private Vector2 firstFrame = new Vector2( 0, 0 );

		public int numRows = 0;
		public int numCols = 0;
		public int verticalSpace = 0;
		public int horizontalSpace = 0;
		public int numFrames = 0;
		public Vector2 frameSize = new Vector2( 0, 0 );
		public Vector2 currentFrame = new Vector2( 0, 0 );
		public Texture2D sprite;
		public int actualFrame = 0;

		public Animation() {

		}

		public Animation( Vector2 currentFrame, Vector2 frameSize, int verticalSpace, int horizontalSpace, int numRows, int numCols, int numFrames ) {
			this.frameSize = frameSize;
			this.currentFrame = currentFrame;
			this.verticalSpace = verticalSpace;
			this.horizontalSpace = horizontalSpace;
			this.numRows = numRows;
			this.numCols = numCols;
			this.numFrames = numFrames;
			this.firstFrame = currentFrame;
		}


		public static void DrawAnimation( SpriteBatch sb, Texture2D spriteSheet, Character character, Animation animation, GameTime gt, float animationSpeed ) {
			animation.elapsed += gt.ElapsedGameTime.TotalSeconds;
			if( animation.elapsed > animationSpeed ) {
				if( animation.numFrames > 0 ) {
					animation.currentFrame.X += animation.frameSize.X + animation.horizontalSpace;
					animation.elapsed = 0;
					++animation.actualFrame;
					if( animation.actualFrame >= animation.numFrames ) {
						animation.actualFrame = 0;
						animation.currentFrame = animation.firstFrame;
					}
				}
			}

			sb.Draw( spriteSheet, new Vector2( character.PlayerPosition.X, character.PlayerPosition.Y ), new Rectangle( (int)animation.currentFrame.X, (int)animation.currentFrame.Y, (int)animation.frameSize.X, (int)animation.frameSize.Y ), Color.White );
		}

		public static void DrawAnimation( SpriteBatch sb, Texture2D spriteSheet, Animation animation, GameTime gt, Vector2 position, Boolean vertical, float animationSpeed ) {
			animation.elapsed += gt.ElapsedGameTime.TotalSeconds;
			if( animation.elapsed > animationSpeed ) {
				if( vertical == false ) {
					if( animation.numFrames > 0 ) {
						animation.currentFrame.X += animation.frameSize.X + animation.horizontalSpace;
						animation.elapsed = 0;
						++animation.actualFrame;
						if( animation.actualFrame >= animation.numFrames ) {
							animation.actualFrame = 0;
							animation.currentFrame = animation.firstFrame;
						}
					}
				} else {
					if( animation.numFrames > 0 ) {
						animation.currentFrame.Y += animation.frameSize.Y + animation.verticalSpace;
						animation.elapsed = 0;
						++animation.currentRow;
						++animation.actualFrame;
						if( animation.currentRow >= animation.numRows ) {
							animation.currentRow = 0;
							animation.actualFrame = 0;
							animation.currentFrame = animation.firstFrame;
						}
					}
				}
			}

			sb.Draw( spriteSheet, new Vector2( position.X, position.Y ), new Rectangle( (int)animation.currentFrame.X, (int)animation.currentFrame.Y, (int)animation.frameSize.X, (int)animation.frameSize.Y ), Color.White );
		}

	}

}