using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FPSgame {

	public class Bug : OBJ {
		private readonly Random mRandom;
		private readonly float mSpeed;
		private float mTimeAi;

		public Vector3 Target;
		public int HP = 500;
		public int DeadTime;


		public Bug(Game game, Vector3 pos, Random rand) {
			mSpeed = 0.3f;
			mRandom = rand;
			Model = game.Content.Load<Model>("Models/bug/bug");
			Position = pos;
			SetWorld();
			Target = new Vector3(mRandom.Next(-10000, 10000), 0, mRandom.Next(-10000, 10000));
			SkinningSetting("Run");

		}


		public override void Update(GameTime gameTime) {
			Bound = new BoundingSphere(Position + new Vector3(0, 5, 0), 10);
			if (mTimeAi <= 0) {
				Target = new Vector3(mRandom.Next(-1000, 1000), 0, mRandom.Next(-1000, 1000));
				mTimeAi = mRandom.Next(1000);
			} else {
				mTimeAi -= 1;
			}


			Position.X -= (float)Math.Sin(Rotation.Y) * mSpeed;
			Position.Z -= (float)Math.Cos(Rotation.Y) * mSpeed;
			Rotation.Y = (float)(Math.Atan2(Position.X - (double)Target.X, Position.Z - (double)Target.Z));

			UpdateSkinngin(gameTime, true);

		}

	}

}
