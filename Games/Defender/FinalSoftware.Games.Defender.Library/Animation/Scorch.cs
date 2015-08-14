using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Animation {

	public struct Scorch : IDefenderDraw {
		private Rectangle mArea;
		private float mAngle;
		private float mScale;

		public Rectangle Area {
			get { return mArea; }
		}

		public float Angle {
			get { return mAngle; }
		}

		public float Scale {
			get { return mScale; }
		}


		public Scorch( Rectangle area, float angle, float scale ) {
			mArea = area;
			mAngle = angle;
			mScale = scale;
		}


		public void Initialize() {
		}

		public void LoadContent() {
		}


		public void Update( GameTime gameTime ) {
		}

		public void Draw( GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Graphics.SpriteBatch additiveBatch ) {
		}

	}

}
