using System;
using FinalSoftware.Games.Defender.Library.Map;
using FinalSoftware.Games.Defender.Library.Towers;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace FinalSoftware.Games.Defender.Game.Units {

	public class AggressiveUnit : Unit {
		private int mDamage;
		private int mRange;
		private World mWorld;
		private Tower mTarget;
		private float mAttackRate;
		private float mAttackTimer;

		public AggressiveUnit( Crossroad spawn, Vector2 offset, Vector2 movement, float speed, int tier, Texture2D textureLiving, Texture2D textureDead, int value, int maxHP, World world, int damage, int range, float attackRate )
			: base( spawn, offset, movement, speed, tier, textureLiving, textureDead, value, maxHP ) {
			mTint = Color.Yellow;
			mDSpeed *= 1.5f;
			mSpeed = mDSpeed;
			mMoney = 2;
			mWorld = world;
			mDamage = damage;
			mRange = range;
			mAttackRate = attackRate;
			mAttackTimer = 0.0f;
		}


		protected float Distance( Tower target ) {
			return (float)( Math.Sqrt( Math.Pow( target.Center.X - mPosition.X, 2 ) + Math.Pow( target.Center.Y - mPosition.Y, 2 ) ) );
		}

		protected virtual Tower AcquireFirstTarget() {
			foreach( Tower t in mWorld.Towers )
				if( !t.Dead && Distance( t ) <= mRange )
					return t;
			return null;
		}

		protected virtual void Attack() {
			mTarget.Damage( mDamage );
			if( mDamage != 0 ) {
				mWorld.CreateAnimation( "explosion1", mTarget.Center, 3 / 10.0f, 0, 10.0f );
				if( !mTarget.Dead ) {
					mWorld.PlaySound( "Explosion 01", mPosition );
				} else {
					mWorld.PlaySound( "Explosion with Metal Debris", mPosition );
				}
			}

		}

		public override void Update( GameTime time ) {
			ArrayList keysToRemove = UpdateEffects( time );
			RemoveEffects( keysToRemove );

			Move();

			if( Lost ) {
				World.Instance.Status.Survived += 1;
				Die();
			} else {
				Reload( time );
				if( mAttackTimer >= mAttackRate ) {
					if( mTarget == null || mTarget.Dead || Distance( mTarget ) > mRange )
						mTarget = AcquireFirstTarget();
					else {
						Attack();
						mAttackTimer = 0;
					}
				}
			}
		}

		protected virtual void Reload( GameTime gameTime ) {
			if( mAttackTimer < mAttackRate )
				mAttackTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
		}

	}

}
