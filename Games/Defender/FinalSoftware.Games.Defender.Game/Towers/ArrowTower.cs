using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class ArrowTower : GameTower {

		public ArrowTower( Rectangle towerBase )
			: base( towerBase ) {
			mName = "Arrow Tower";
			texture = GameWorld.TexTower;

			mFiringRate = 700.0f;
			mDmg = 30;
			mRange = 150;
			mImprecision = 7;
			mProjectileSpeed = 10;
			mDefaultRange = mRange;
			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;

			SetDrawRectangle();
		}

	}

}
