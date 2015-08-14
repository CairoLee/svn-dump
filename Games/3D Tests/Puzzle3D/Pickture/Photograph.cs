using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Puzzle3D {

	public class Photograph {
		Texture2D texture;

		Vector3 position;
		Matrix worldTransform;

		float age;

		float initialX;
		float initialY;
		const float InitialZ = 1000.0f;
		float fallSpeed;

		float maxHorizontalPendulumAngle;
		float horizontalPendulumLength;
		float maxVerticalPendulumAngle;
		float verticalPendulumLength;


		public Matrix WorldTransform {
			get { return worldTransform; }
		}

		public Vector3 Position {
			get { return position; }
		}

		public Texture2D Texture {
			get { return texture; }
			set { texture = value; }
		}


		public void Reset() {
			float maxDeviation = CompletedScreen.ResetZValue * (float)Math.Sin( MathHelper.ToRadians( 22.5f ) );
			initialX = RandomHelper.Next( -maxDeviation, maxDeviation );
			initialY = RandomHelper.Next( -maxDeviation, maxDeviation );

			age = 0.0f;

			position = new Vector3( initialX, initialY, InitialZ );
			fallSpeed = RandomHelper.Next( 100.0f, 400.0f );

			maxHorizontalPendulumAngle = (float)RandomHelper.Random.NextDouble() * MathHelper.PiOver4 / 2.0f;
			horizontalPendulumLength = RandomHelper.Next( 2.0f, 4.0f );
			maxVerticalPendulumAngle = (float)RandomHelper.Random.NextDouble() * MathHelper.PiOver4 / 2.0f;
			verticalPendulumLength = RandomHelper.Next( 2.0f, 4.0f );
		}

		public void Update( GameTime gameTime ) {
			age += (float)gameTime.ElapsedGameTime.TotalSeconds;

			float baseZPosition = InitialZ - ( age * fallSpeed );

			float horizontalPendulumAngle = maxHorizontalPendulumAngle * (float)Math.Sin( Math.Sqrt( 9.81f / horizontalPendulumLength ) * age );
			float verticalPendulumAngle = maxVerticalPendulumAngle * (float)Math.Sin( Math.Sqrt( 9.81f / verticalPendulumLength ) * age );

			float positionModificationMultiplier = 75.0f;
			float zPositionModification = -( (float)Math.Cos( horizontalPendulumAngle ) * horizontalPendulumLength ) - ( (float)Math.Cos( verticalPendulumAngle ) * verticalPendulumLength );
			zPositionModification *= positionModificationMultiplier;

			position = new Vector3( initialX + ( (float)Math.Sin( verticalPendulumAngle ) * verticalPendulumLength * positionModificationMultiplier ), initialY + ( (float)Math.Sin( horizontalPendulumAngle ) * horizontalPendulumLength * positionModificationMultiplier ), baseZPosition + zPositionModification );
			worldTransform = Matrix.CreateRotationX( horizontalPendulumAngle ) * Matrix.CreateRotationY( verticalPendulumAngle ) * Matrix.CreateTranslation( Position );
		}

	}

}
