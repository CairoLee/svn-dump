using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GodLesZ_Game_Libary {
	public class ArcBallCamera {

		public Matrix rotation = Matrix.Identity;
		public Vector3 position = Vector3.Zero;

		// Simply feed this camera the position of whatever you want its target to be
		public Vector3 targetPosition = Vector3.Zero;

		public Matrix viewMatrix = Matrix.Identity;
		public Matrix projectionMatrix = Matrix.Identity;

		private float horizontalAngle = MathHelper.PiOver2;
		private float verticalAngle = MathHelper.PiOver2;
		private const float verticalAngleMin = 0.01f;
		private const float verticalAngleMax = MathHelper.Pi - 0.01f;
		private const float zoomMin = 0.1f;
		private const float zoomMax = 50.0f;
		private float zoom = 30.0f;

		// FOV is in radians
		// screenWidth and screenHeight are pixel values. They're floats because we need to divide them to get an aspect ratio.
		public ArcBallCamera( float FOV, float screenWidth, float screenHeight, float nearPlane, float farPlane ) {
			if( screenHeight < float.Epsilon )
				throw new Exception( "screenHeight cannot be zero or a negative value" );

			if( screenWidth < float.Epsilon )
				throw new Exception( "screenWidth cannot be zero or a negative value" );

			if( nearPlane < 0.1f )
				throw new Exception( "nearPlane must be greater than 0.1" );

			this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView( MathHelper.ToRadians( FOV ), screenWidth / screenHeight,
																		nearPlane, farPlane );
		}

		public void Update( GameTime gameTime ) {
			// Keep vertical angle within tolerances
			verticalAngle = MathHelper.Clamp( verticalAngle, verticalAngleMin, verticalAngleMax );

			// Keep vertical angle within PI
			if( horizontalAngle > MathHelper.TwoPi )
				horizontalAngle -= MathHelper.TwoPi;
			else if( horizontalAngle < 0.0f )
				horizontalAngle += MathHelper.TwoPi;

			// Keep zoom within range
			zoom = MathHelper.Clamp( zoom, zoomMin, zoomMax );

			// Start with an initial offset
			Vector3 cameraPosition = new Vector3( 0.0f, zoom, 0.0f );

			// Rotate vertically
			cameraPosition = Vector3.Transform( cameraPosition, Matrix.CreateRotationX( verticalAngle ) );

			// Rotate horizontally
			cameraPosition = Vector3.Transform( cameraPosition, Matrix.CreateRotationY( horizontalAngle ) );

			position = cameraPosition + targetPosition;
			this.LookAt( targetPosition );

			// Compute view matrix
			this.viewMatrix = Matrix.CreateLookAt( this.position,
												  this.position + this.rotation.Forward,
												  this.rotation.Up );
		}

		/// <summary>
		/// Points camera in direction of any position.
		/// </summary>
		/// <param name="targetPos">Target position for camera to face.</param>
		public void LookAt( Vector3 targetPos ) {
			Vector3 newForward = targetPos - this.position;
			newForward.Normalize();
			this.rotation.Forward = newForward;

			Vector3 referenceVector = Vector3.UnitY;

			// On the slim chance that the camera is pointer perfectly parallel with the Y Axis, we cannot
			// use cross product with a parallel axis, so we change the reference vector to the forward axis (Z).
			if( this.rotation.Forward.Y == referenceVector.Y || this.rotation.Forward.Y == -referenceVector.Y ) {
				referenceVector = Vector3.UnitZ;
			}

			this.rotation.Right = Vector3.Cross( this.rotation.Forward, referenceVector );
			this.rotation.Up = Vector3.Cross( this.rotation.Right, this.rotation.Forward );
		}

	}
}
