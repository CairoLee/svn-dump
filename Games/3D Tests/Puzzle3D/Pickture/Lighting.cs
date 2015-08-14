using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Puzzle3D {

	public class Lighting {
		const float LightDistance = 300.0f;

		float previousXZ;
		float previousY;

		Vector3 position;

		float targetXZ;
		float targetY;

		float movementTime;
		float movementDuration;


		public Vector3 Position {
			get { return this.position; }
		}


		public Lighting() {
			ChooseTargetPosition();
		}

		public void Update( GameTime gameTime, Camera camera ) {
			movementTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

			if( movementTime >= movementDuration )
				ChooseTargetPosition();

			float fraction = movementTime / movementDuration;
			float currentXZ = camera.CurrentXZ + MathHelper.SmoothStep( previousXZ, targetXZ, fraction );
			float currentY = camera.CurrentY + MathHelper.SmoothStep( previousY, targetY, fraction );

			position.X = (float)Math.Sin( currentXZ );
			position.Y = (float)Math.Sin( currentY );
			position.Z = (float)Math.Cos( currentXZ );
			position *= LightDistance;
		}

		void ChooseTargetPosition() {
			previousXZ = targetXZ;
			previousY = targetY;
			targetXZ = RandomHelper.Next( -MathHelper.Pi / 5.0f, MathHelper.Pi / 5.0f );
			targetY = RandomHelper.Next( -MathHelper.Pi / 5.0f, MathHelper.Pi / 5.0f );
			movementTime = 0.0f;
			movementDuration = RandomHelper.Next( 4.0f, 8.0f );
		}

	}

}
