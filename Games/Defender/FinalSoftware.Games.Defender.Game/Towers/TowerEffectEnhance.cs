using FinalSoftware.Games.Defender.Library.Towers;

namespace FinalSoftware.Games.Defender.Game.Towers {

	class TowerEffectEnhance : TowerEffects {

		protected float mDamageInc;
		protected float mRangeInc;

		public TowerEffectEnhance( int duration, float damageInc, float rangeInc ) {
			mDuration = duration;
			mDamageInc = damageInc;
			mRangeInc = rangeInc;
			mType = "Enhancement 1";
		}


		public override void ApplyEffect( Tower tower ) {
			if( tower.DefaultDmg != 0 )
				tower.Dmg = (int)( tower.DefaultDmg * ( 1 + mDamageInc ) );
			tower.Range = (int)( tower.DefaultRange * ( 1 + mRangeInc ) );
		}

		public override void UndoEffect( Tower tower ) {
			tower.Dmg = tower.DefaultDmg;
			tower.Range = tower.DefaultRange;
		}

	}

}
