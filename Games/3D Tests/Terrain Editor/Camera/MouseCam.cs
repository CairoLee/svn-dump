using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Ragnarok3D.Editor {
	public class MouseCam : Camera {
		private KeyboardState keys;
		private MouseState currentMouseState, previousMouseState;

		Point screenCenter = Point.Zero;
		public Vector3 lastPosition;

		public MouseCam() {
			screenCenter.X = Editor.graphics.GraphicsDevice.Viewport.Width / 2;
			screenCenter.Y = Editor.graphics.GraphicsDevice.Viewport.Height / 2;
			SetInitialValues();
		}

		private void SetInitialValues() {
			Mouse.SetPosition( screenCenter.X, screenCenter.Y );
			currentMouseState = Mouse.GetState();
			previousMouseState = Mouse.GetState();
		}

		public override void Update( GameTime gameTime ) {
			PollInput( (float)gameTime.ElapsedGameTime.Milliseconds / 4.0f );
			base.Update( gameTime );
		}

		//bool bToggleKeyDown = false;
		private void PollInput( float amountOfMovement ) {
			keys = Keyboard.GetState();
			currentMouseState = Mouse.GetState();

			if( state != State.Fixed ) {
				Vector3 moveVector = new Vector3();

				if( state == State.FirstPerson ) {
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
				}

				lastPosition = position;
				rotationMatrix = Matrix.CreateRotationX( rotation.X ) * Matrix.CreateRotationY( rotation.Y );
				position += Vector3.Transform( moveVector, rotationMatrix );

				speed = Vector3.Distance( position, lastPosition );

				if( currentMouseState.X != previousMouseState.X )
					rotation.Y -= amountOfMovement / 800.0f * ( currentMouseState.X - previousMouseState.X );
				if( currentMouseState.Y != previousMouseState.Y )
					rotation.X += amountOfMovement / 800.0f * ( currentMouseState.Y - previousMouseState.Y );

				Mouse.SetPosition( screenCenter.X, screenCenter.Y );
			}



			//if (keys.IsKeyDown(Keys.C))
			if( currentMouseState.RightButton == ButtonState.Pressed ) {
				state = State.FirstPerson;
				//if (!bToggleKeyDown)
				//{
				//    bToggleKeyDown = true;
				Mouse.SetPosition( screenCenter.X, screenCenter.Y );
				//ToggleNextState();
				//}
			} else {
				state = State.Fixed;
			}
			//else if (bToggleKeyDown)
			//    bToggleKeyDown = false;


			previousMouseState = Mouse.GetState();

		}
	}
}
