using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace GLibary {
	public class CameraControllerFreeRoam {
		public static void Update( GameTime gt ) {
			Camera camera = Utility.Camera;
			InputState inputState = Utility.InputState;

			float elapsedTime = gt.ElapsedSeconds();

			Vector2 lookDelta = Vector2.Zero;
			lookDelta = inputState.MousePositionDelta;
			if( lookDelta != Vector2.Zero ) {
				lookDelta.Normalize();
			}


			if( lookDelta == Vector2.Zero ) {
				lookDelta = new Vector2(
					inputState.IsKeyDown( Keys.Right ) ? 1 : inputState.IsKeyDown( Keys.Left ) ? -1 : 0,
					inputState.IsKeyDown( Keys.Up ) ? 1 : inputState.IsKeyDown( Keys.Down ) ? -1 : 0 );
			}

			float rotateSpeed = elapsedTime * 2.0f;
			float moveSpeed = 0;
			if( inputState.IsKeyDown( Keys.LeftShift ) ) {
				moveSpeed = elapsedTime * 100.0f * ( inputState.IsKeyDown( Keys.LeftShift ) ? 10.0f : 1.0f );
			} else {
				moveSpeed = elapsedTime * 100.0f * 1.0f;
			}

			camera.Direction = Vector3.TransformNormal( camera.Direction, Matrix.CreateRotationY( lookDelta.X * -rotateSpeed ) );

			camera.Direction = Vector3.TransformNormal( camera.Direction, Matrix.CreateFromAxisAngle( Vector3.Cross( Vector3.Up, camera.Direction ), -lookDelta.Y * rotateSpeed ) );

			Vector3 moveVec = Vector3.Zero;

			if( inputState.IsKeyDown( Keys.W ) || inputState.IsKeyDown( Keys.Up ) ) {
				moveVec += camera.Direction;
			}
			if( inputState.IsKeyDown( Keys.S ) || inputState.IsKeyDown( Keys.Down ) ) {
				moveVec -= camera.Direction;
			}
			if( inputState.IsKeyDown( Keys.A ) || inputState.IsKeyDown( Keys.Right ) ) {
				moveVec += Vector3.Cross( Vector3.Up, camera.Direction );
			}
			if( inputState.IsKeyDown( Keys.D ) || inputState.IsKeyDown( Keys.Left ) ) {
				moveVec -= Vector3.Cross( Vector3.Up, camera.Direction );
			}

			if( moveVec.Length() > 0.0f )
				moveVec.Normalize();

			Utility.Camera.Position += moveVec * moveSpeed;

			if( Utility.Game.IsActive ) {
				Rectangle windowBounds = Utility.Game.Window.ClientBounds;
				Vector2 windowCenter = new Vector2( (float)( windowBounds.Width / 2 ), (float)( windowBounds.Height / 2 ) );

				inputState.MousePosition = windowCenter;
			}

		}
	}
}