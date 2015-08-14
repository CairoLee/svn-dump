using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Bomberman_Clone {

	class Animator {
		private Hashtable animations = new Hashtable();
		private SpriteBatch sb;
		private Vector2 position = new Vector2( 0, 0 );
		private float animationSpeed = 0.1f;
		private float elapsed = 0;


		public Animator( SpriteBatch sb, Animation animation, string animationName ) {
			this.sb = sb;
			animations.Add( (object)animationName, animation );
		}

		public void Animate( string animationName, GameTime gt ) {
			elapsed += (float)gt.ElapsedGameTime.TotalSeconds;
			Animation animation = (Animation)animations[ animationName ];
			sb.Draw( animation.sprite, position, new Rectangle( (int)animation.currentFrame.X, (int)animation.currentFrame.Y, (int)animation.frameSize.X, (int)animation.frameSize.Y ), Color.White );
			if( elapsed > animationSpeed ) {
				if( animation.actualFrame <= animation.numFrames ) {
					animation.currentFrame.X += animation.frameSize.X + animation.horizontalSpace;
					animation.actualFrame++;
				} else {
					animation.actualFrame = 0;
				}
				elapsed = 0;
			}
		}

	}

}
