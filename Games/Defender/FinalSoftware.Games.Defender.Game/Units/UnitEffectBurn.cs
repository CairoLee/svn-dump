using FinalSoftware.Games.Defender.Library.Units;

namespace FinalSoftware.Games.Defender.Game.Units {

	public class UnitEffectBurn : UnitEffect {
		protected int mBurnDmg;

		public UnitEffectBurn( int duration, int burnDmg ) {
			mDuration = duration;
			mBurnDmg = burnDmg;
			mType = "Burning";
		}


		public override void ApplyEffects( Unit unit ) {
			unit.Damage( mBurnDmg, EUnitDamageType.Burn );
		}

		public override void UndoEffect( Unit unit ) {

		}

	}

}
