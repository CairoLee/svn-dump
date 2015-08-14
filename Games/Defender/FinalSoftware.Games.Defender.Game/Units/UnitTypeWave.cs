using FinalSoftware.Games.Defender.Library.Map;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Game.Units {

	public class UnitTypeWave : UnitWave {

		public UnitTypeWave( EUnitType unitType, Crossroad spawn, int numUnits, int tileSize, float interval )
			: base( unitType, spawn, numUnits, tileSize, interval ) {
		}



		public override void CreateUnit() {
			World.Instance.SpawnHealth = 100 + ( mThisWave * 20 );
			int value = 1;
			Vector2 offset = new Vector2( mRand.Next( mMaxX ), mRand.Next( mMaxY ) );

			if( mThisWave < 10 )
				mUnitType = EUnitType.Basic;
			if( mUnitType == EUnitType.Basic )
				Units.Add( new Unit( mSpawningPoint, offset, Vector2.Zero, 0.5f, mSpawningPoint.Tier, World.Instance.texUnit, World.Instance.texUnitDead, value, World.Instance.SpawnHealth ) );
			else if( mUnitType == EUnitType.Strong )
				Units.Add( new StrongUnit( mSpawningPoint, offset, Vector2.Zero, 0.5f, mSpawningPoint.Tier, World.Instance.texUnit, World.Instance.texUnitDead, value, World.Instance.SpawnHealth ) );
			else if( mUnitType == EUnitType.Fast )
				Units.Add( new FastUnit( mSpawningPoint, offset, Vector2.Zero, 0.5f, mSpawningPoint.Tier, World.Instance.texUnit, World.Instance.texUnitDead, value, World.Instance.SpawnHealth ) );
			else if( mUnitType == EUnitType.Regeneration )
				Units.Add( new RegenUnit( mSpawningPoint, offset, Vector2.Zero, 0.5f, mSpawningPoint.Tier, World.Instance.texUnit, World.Instance.texUnitDead, value, World.Instance.SpawnHealth ) );
			World.Instance.Status.Created++;
			mToCreate--;
		}

	}

}
