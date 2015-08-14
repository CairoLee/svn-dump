using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Cam_Test {

	public class MouseCam : Camera {
		private KeyboardState keys;
		private MouseState currentMouseState, previousMouseState;

		Point oldMousePosition = Point.Zero;
		public Vector3 lastPosition;

		public MouseCam() {
			currentMouseState = Mouse.GetState();
			previousMouseState = currentMouseState;
		}

		public override void Update( GameTime gameTime ) {
			PollInput( (float)gameTime.ElapsedGameTime.Milliseconds / 1.0f );
		
			base.Update( gameTime );
		}

		private void PollInput( float amountOfMovement ) {
			keys = Keyboard.GetState();
			currentMouseState = Mouse.GetState();
			Vector3 moveVector = new Vector3();

			if( keys.IsKeyDown( Keys.Right ) || keys.IsKeyDown( Keys.D ) )
				moveVector.X -= amountOfMovement;
			if( keys.IsKeyDown( Keys.Left ) || keys.IsKeyDown( Keys.A ) )
				moveVector.X += amountOfMovement;
			if( keys.IsKeyDown( Keys.Down ) || keys.IsKeyDown( Keys.S ) )
				moveVector.Z -= amountOfMovement;
			if( keys.IsKeyDown( Keys.Up ) || keys.IsKeyDown( Keys.W ) )
				moveVector.Z += amountOfMovement;
			
			if( currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue > 0 )
				moveVector.Z += amountOfMovement * 10;
			if( currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue < 0 )
				moveVector.Z -= amountOfMovement * 10;

			lastPosition = position;
			rotationMatrix = Matrix.CreateRotationX( rotation.X ) * Matrix.CreateRotationY( rotation.Y );
			position += Vector3.Transform( moveVector, rotationMatrix );

			speed = Vector3.Distance( position, lastPosition );


			if( state != State.Fixed ) {

				if( currentMouseState.X != previousMouseState.X )
					rotation.Y -= amountOfMovement * .35f / CamTest.graphics.PreferredBackBufferWidth * ( currentMouseState.X - previousMouseState.X );
				if( currentMouseState.Y != previousMouseState.Y )
					rotation.X += amountOfMovement * .35f / CamTest.graphics.PreferredBackBufferWidth * ( currentMouseState.Y - previousMouseState.Y );

				//Mouse.SetPosition( screenCenter.X, screenCenter.Y );
			}



			if( currentMouseState.RightButton == ButtonState.Pressed ) {
				state = State.FirstPerson;
				if( oldMousePosition == Point.Zero )
					oldMousePosition = new Point( currentMouseState.X, currentMouseState.Y );
			} else if( currentMouseState.LeftButton == ButtonState.Pressed ) {
				state = State.ThirdPerson;
				if( oldMousePosition == Point.Zero )
					oldMousePosition = new Point( currentMouseState.X, currentMouseState.Y );
			} else {
				state = State.Fixed;
				if( oldMousePosition != Point.Zero ) {
					Mouse.SetPosition( oldMousePosition.X, oldMousePosition.Y );
					currentMouseState = previousMouseState = Mouse.GetState();
				}
				oldMousePosition = Point.Zero;
			}


			previousMouseState = Mouse.GetState();

		}
	}
}
