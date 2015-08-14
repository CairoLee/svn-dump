using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Units {

	public abstract class UnitEffect {

		protected string mType;
		protected int mCreated = 0;
		protected int mDuration;
		protected int mLife;

		public string Type {
			get { return mType; }
		}

		public abstract void ApplyEffects( Unit unit );
		public abstract void UndoEffect( Unit unit );

		public bool IsValid( GameTime time ) {
			mLife += time.ElapsedGameTime.Milliseconds;
			if( mLife < mDuration * 1000 )
				return true;
			else
				return false;
		}

		public string toString() {
			return "This tower is " + mType;
		}

	}

}
