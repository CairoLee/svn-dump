using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Puzzle3D {

	public class Camera {
		public enum BoardSide {
			Front,
			Back,
		};

		public enum FlipDirection {
			Left = -1,
			Right = 1
		}


		bool isFlipping = false;

		BoardSide side = BoardSide.Front;

		Vector3 position;
		Matrix viewMatrix;
		Matrix projectionMatrix;

		float baseXZ;
		float previousXZ;
		float previousY;
		float targetXZ;
		float targetY;
		float currentXZ;
		float currentY;
		float cameraMovementCurrentTime;
		float cameraMovementTotalTime;

		const float MaxDeviation = MathHelper.Pi / 8.0f;

		float cameraDistance;


		public bool IsFlipping {
			get { return isFlipping; }
		}

		public float CurrentXZ {
			get { return currentXZ; }
		}

		public float CurrentY {
			get { return currentY; }
		}

		public Matrix ViewMatrix {
			get { return viewMatrix; }
		}

		public Matrix ProjectionMatrix {
			get { return projectionMatrix; }
		}

		public Vector3 Position {
			get { return position; }
		}

		public BoardSide Side {
			get { return side; }
		}


		public Camera( float cameraDistance ) {
			this.cameraDistance = cameraDistance;

			position = new Vector3( 0.0f, 0.0f, cameraDistance );
			viewMatrix = Matrix.CreateLookAt( position, Vector3.Zero, Vector3.Up );

			ChooseTargetPosition();
		}


		public void Update( GameTime gameTime ) {
			cameraMovementCurrentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
			if( cameraMovementCurrentTime >= cameraMovementTotalTime ) {
				ChooseTargetPosition();
				isFlipping = false;
			}

			float fraction = cameraMovementCurrentTime / cameraMovementTotalTime;
			currentXZ = MathHelper.SmoothStep( previousXZ, targetXZ, fraction );
			currentY = MathHelper.SmoothStep( previousY, targetY, fraction );

			position.X = (float)Math.Sin( currentXZ );
			position.Y = (float)Math.Sin( currentY );
			position.Z = (float)Math.Cos( currentXZ );
			position *= cameraDistance;

			viewMatrix = Matrix.CreateLookAt( position, Vector3.Zero, Vector3.UnitY );

			Viewport viewport = Puzzle3D.Instance.GraphicsDevice.Viewport;
			float aspectRatio = (float)viewport.Width / viewport.Height;

			projectionMatrix = Matrix.CreatePerspectiveFieldOfView( MathHelper.ToRadians( 45.0f ), aspectRatio, 1.0f, 10000.0f );
		}

		void ChooseTargetPosition() {
			previousXZ = targetXZ;
			previousY = targetY;
			targetXZ = baseXZ + RandomHelper.Next( -MaxDeviation, MaxDeviation );
			targetY = RandomHelper.Next( -MaxDeviation, MaxDeviation );
			cameraMovementCurrentTime = 0.0f;
			cameraMovementTotalTime = RandomHelper.Next( 10.0f, 20.0f );
		}

		public void Flip( FlipDirection direction ) {
			side = ( side == BoardSide.Front ) ? BoardSide.Back : BoardSide.Front;
			baseXZ += (float)Math.PI * (int)direction;

			previousXZ = currentXZ;
			targetXZ = baseXZ;
			cameraMovementCurrentTime = 0.0f;
			cameraMovementTotalTime = 0.6f;

			Audio.Play( "Flip Board" );
			isFlipping = true;
		}

	}

}
