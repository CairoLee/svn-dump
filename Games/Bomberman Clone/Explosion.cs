using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace Bomberman_Clone {

	public class Explosion {
		private Vector2 position;
		public Vector2 positionLeft;
		public Vector2 positionRight;
		public Vector2 lefMiddle;
		public Vector2 rightMiddle;
		public Vector2 middleMiddle;
		private Animation flameMiddle;
		private Animation flameLeft;
		private Animation flameRight;
		private Animation flameUp;
		private float explosionTime = .4f;
		private float elapsed = 0.0f;

		public Animation FlameMiddle {
			get { return flameMiddle; }
		}
		public Animation FlameUp {
			get { return flameUp; }
		}
		public Animation FlameLeft {
			get { return flameLeft; }
		}
		public Animation FlameRight {
			get { return flameRight; }
		}
		public float Elapsed {
			get { return elapsed; }
			set { elapsed = value; }
		}
		public float ExplosionTime {
			get { return explosionTime; }
		}
		public Vector2 Position {
			get { return position; }
			set { position = value; }
		}

		public Explosion( Vector2 position ) {
			BomberMan.explosions.Add( this );
			this.position = position;
			flameMiddle = new Animation( new Vector2( 60, 30 ), new Vector2( 16, 16 ), 0, 74, 0, 0, 4 );
			flameLeft = new Animation( new Vector2( 28, 30 ), new Vector2( 16, 16 ), 0, 74, 0, 0, 4 );
			flameRight = new Animation( new Vector2( 92, 30 ), new Vector2( 16, 16 ), 0, 73, 0, 0, 4 );
			flameUp = new Animation( new Vector2( 60, 0 ), new Vector2( 16, 14 ), 0, 0, 74, 0, 4 );
			positionLeft = new Vector2( position.X - flameMiddle.frameSize.X, position.Y );
			positionRight = new Vector2( position.X + flameMiddle.frameSize.X - 1, position.Y );
			lefMiddle.X = positionLeft.X + 8;
			lefMiddle.Y = positionLeft.Y + 8;
			middleMiddle.X = position.X + 8;
			middleMiddle.Y = position.Y + 8;
			rightMiddle.Y = positionRight.Y + 8;
			rightMiddle.X = positionRight.X + 8;
		}


		public static void Update( GameTime gt ) {
			if( BomberMan.explosions.Count > 0 ) {
				for( int i = 0; i < BomberMan.explosions.Count; i++ ) {
					Explosion ex = (Explosion)BomberMan.explosions[ i ];
					if( ex.elapsed < ex.explosionTime ) {
						ex.elapsed += (float)gt.ElapsedGameTime.TotalSeconds;
					} else
						BomberMan.explosions.RemoveAt( i );
				}
			}
		}

	}

}