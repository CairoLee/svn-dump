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

	public class Bomb : Objects {
		private Character owner;
		private float bombTimer = 2.5f;
		private float currentTime = 0.0f;
		private Animation timer;
		private Animation explosion;
		private Vector2 position = new Vector2( 0, 0 );
		private bool detonate = false;

		public Vector2 Position {
			get { return position; }
			set { position = value; }
		}
		public Animation TimerAnimation {
			get { return timer; }
		}
		public bool Detonate {
			get { return detonate; }
			set { detonate = value; }
		}
		public Character Owner {
			get { return owner; }
			set { owner = value; }
		}


		public Bomb( Character owner ) {
			this.owner = owner;
			timer = new Animation( new Vector2( 0, 0 ), new Vector2( 17, 16 ), 14, 0, 2, 0, 2 );
			explosion = new Animation();
		}


		public void CreateBomb( Vector2 position ) {
			this.position = position;
			BomberMan.bombs.Add( this );
		}

		public static void Update( GameTime gt ) {
			if( BomberMan.bombs.Count > 0 ) {
				for( int i = 0; i < BomberMan.bombs.Count; i++ ) {
					Bomb bomb = (Bomb)BomberMan.bombs[ i ];
					if( bomb.currentTime < bomb.bombTimer ) {
						bomb.currentTime += (float)gt.ElapsedGameTime.TotalSeconds;
					} else {
						// DETONATE
						Explosion ex = new Explosion( bomb.position );
						bomb.detonate = true;
						--bomb.owner.CurrentBombs;
					}
				}
			}
		}

		public void Draw( GameTime gt ) {

		}



		private static void Destroy( Objects obj ) {
			obj = null;
		}


	}

}