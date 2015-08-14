using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Ragnarok3D.Editor {
	public class Camera {
		public Matrix view;
		public Matrix projection;
		public Matrix rotationMatrix;
		public Matrix reflectionView;
		public Matrix reflectionProjection;

		public Vector3 position = Vector3.Zero;
		public Vector3 rotation = Vector3.Zero;
		public Vector3 targetPos = Vector3.Zero;
		public Vector3 upVector = Vector3.Zero;

		public Vector3 direction = Vector3.Forward;

		public float aspectRatio = 0f;
		public float fov = (float)Math.PI / 4.0f;
		public float NearPlane = .1f;
		public float FarPlane = 100000f;

		public State state = State.FirstPerson;
		public State lastState = State.FirstPerson;
		public enum State {
			FirstPerson = 0,
			ThirdPerson,
			Fixed
		}

		public float speed = 0f;

		public BoundingFrustum boundingFrustrum;
		public float viewDistance = 12000f;

		public Camera() {
			aspectRatio = (float)Editor.graphics.GraphicsDevice.Viewport.Width / (float)Editor.graphics.GraphicsDevice.Viewport.Height;
		}

		public virtual void Update( GameTime gameTime ) {
			UpdateMatrices();
			boundingFrustrum = new BoundingFrustum( view * projection );
		}

		public void SetPosition( Vector3 newPosition ) {
			position = newPosition;
		}

		public virtual void UpdateMatrices() {
			rotationMatrix = Matrix.CreateRotationX( rotation.X ) * Matrix.CreateRotationY( rotation.Y );
			targetPos = position + Vector3.Transform( new Vector3( 0, 0, 1 ), rotationMatrix );
			upVector = Vector3.Transform( new Vector3( 0, 1, 0 ), rotationMatrix );

			direction = Vector3.Normalize( targetPos - position );

			view = Matrix.CreateLookAt( position, targetPos, upVector );
			projection = Matrix.CreatePerspectiveFieldOfView( fov, aspectRatio, NearPlane, FarPlane );
		}

		public void ToggleNextState() {
			switch( state ) {
				case State.FirstPerson:
					state = State.Fixed;
					break;
				case State.Fixed:
					state = State.FirstPerson; //Temp
					break;
				case State.ThirdPerson:
					state = State.FirstPerson;
					break;
			}
		}

		public void SetState( State newState ) {
			state = newState;
		}

		public Ray GetPickRay() {
			MouseState mouseState = Mouse.GetState();

			int mouseX = mouseState.X;
			int mouseY = mouseState.Y;

			float width = Editor.graphics.GraphicsDevice.Viewport.Width;
			float height = Editor.graphics.GraphicsDevice.Viewport.Height;

			double screenSpaceX = ( (float)mouseX / ( width / 2 ) - 1.0f ) * aspectRatio;
			double screenSpaceY = ( 1.0f - (float)mouseY / ( height / 2 ) );

			double viewRatio = Math.Tan( fov / 2 );

			screenSpaceX = screenSpaceX * viewRatio;
			screenSpaceY = screenSpaceY * viewRatio;

			Vector3 cameraSpaceNear = new Vector3( (float)( screenSpaceX * NearPlane ), (float)( screenSpaceY * NearPlane ), (float)( -NearPlane ) );
			Vector3 cameraSpaceFar = new Vector3( (float)( screenSpaceX * FarPlane ), (float)( screenSpaceY * FarPlane ), (float)( -FarPlane ) );

			Matrix invView = Matrix.Invert( view );
			Vector3 worldSpaceNear = Vector3.Transform( cameraSpaceNear, invView );
			Vector3 worldSpaceFar = Vector3.Transform( cameraSpaceFar, invView );

			Ray pickRay = new Ray( worldSpaceNear, worldSpaceFar - worldSpaceNear );

			return new Ray( pickRay.Position, Vector3.Normalize( pickRay.Direction ) );
		}
	}
}
