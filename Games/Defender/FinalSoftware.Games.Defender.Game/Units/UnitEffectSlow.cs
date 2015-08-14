using FinalSoftware.Games.Defender.Library.Units;

namespace FinalSoftware.Games.Defender.Game.Units {

	public class UnitEffectSlow : UnitEffect {
		protected float mSlowEffect;

		public UnitEffectSlow( int duration, float slowEffect ) {
			mDuration = duration;
			mSlowEffect = slowEffect;
			mType = "Slowing";
		}


		public override void ApplyEffects( Unit unit ) {
			unit.Speed = unit.DSpeed * ( 1 - mSlowEffect );
		}

		public override void UndoEffect( Unit unit ) {
			unit.Speed = unit.DSpeed;
		}

	}

}
