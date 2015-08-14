using System;
using FinalSoftware.Games.Defender.Library.Map;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Units {

	/// <summary>
	/// todo..
	/// </summary>
	public class FlyingUnit : Unit {

		public FlyingUnit( Crossroad spawn, Vector2 offset, Vector2 movement, float speed, int tier, Texture2D textureLiving, Texture2D textureDead, int value, int maxHP, World world )
			: base( spawn, offset, movement, speed, tier, textureLiving, textureDead, value, maxHP ) {
			mTint = Color.Yellow;
			mDSpeed *= 1.5f;
			mSpeed = mDSpeed;
			mMoney = 2;

			mDestination = world.Spawns[ 0 ];

			movement = new Vector2( 0, 0 );

			Vector2 toMove;
			float divisor;
			toMove = mDestination.Position - mPosition;
			divisor = Math.Max( Math.Abs( toMove.X ), Math.Abs( toMove.Y ) );
			movement = ( toMove / divisor );
			tier = mDestination.Tier;
		}


		protected override void ChangeMovement() {
			Vector2 toMove;
			float divisor;

			if( mDestination == null )
				mMovement = Vector2.Zero;
			else {
				toMove = mDestination.Position + mOffset - mPosition;
				divisor = Math.Max( Math.Abs( toMove.X ), Math.Abs( toMove.Y ) );
				mMovement = ( toMove / divisor );

				mTier = mDestination.Tier;
			}
		}

	}

}
