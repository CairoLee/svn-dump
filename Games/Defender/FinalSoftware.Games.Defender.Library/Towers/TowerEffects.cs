using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Towers {

	public abstract class TowerEffects {

		protected string mType;
		protected int mCreated = 0;
		protected int mDuration;
		protected int mLife = 0;

		public string Type {
			get { return mType; }
		}

		public abstract void ApplyEffect( Tower tower );
		public abstract void UndoEffect( Tower tower );

		public bool IsValid( GameTime time ) {
			mLife += time.ElapsedGameTime.Milliseconds;
			if( mLife < mDuration * 1000 )
				return true;
			else
				return false;

		}

		public string toString() {
			return "This Tower is affected by " + mType;
		}

	}

}