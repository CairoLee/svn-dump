using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace Engine3DFromRiemersTutorial {
	public delegate void MatrixDelegate( ref Matrix m );

	public interface ICamera {
		Matrix ViewMatrix { get; }
		BoundingFrustum Frustum { get; }
	}

	public class Camera : EffectComponent, ICamera {
		private Matrix mViewMatrix;
		private Matrix mProjectionMatrix;
		protected Vector3 mCameraPosition = new Vector3( 80, 30, -50 );
		private BoundingFrustum mFrustum;


		public Matrix ViewMatrix {
			get { return mViewMatrix; }
			protected set {
				mViewMatrix = value;
				if( OnViewUpdate != null )
					OnViewUpdate( ref mViewMatrix );
			}
		}

		public Vector3 Position {
			get { return mCameraPosition; }
		}

		public Matrix ProjectionMatrix {
			get { return mProjectionMatrix; }
		}

		public BoundingFrustum Frustum {
			get { return mFrustum; }
			set { mFrustum = value; }
		}


		public event MatrixDelegate OnViewUpdate;

		public Matrix TranslationMatrix = Matrix.Identity;
		protected Matrix WorldMatrix = Matrix.Identity;

		public Camera( Game game )
			: base( game ) {
		}

		protected override void LoadContent() {
			mViewMatrix = Matrix.CreateLookAt( new Vector3( 130, 30, -50 ), new Vector3( 0, 0, -40 ), new Vector3( 0, 1, 0 ) );
			mProjectionMatrix = Matrix.CreatePerspectiveFieldOfView( MathHelper.PiOver4, GraphicsDevice.Viewport.AspectRatio, 0.3f, 1000.0f );
			base.LoadContent();
		}


		public override void Draw( GameTime gameTime ) {
			GraphicsDevice.Clear( ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0 );

			effect.Parameters[ "xEnableLighting" ].SetValue( true );
			effect.Parameters[ "xAmbient" ].SetValue( 0.1f );
			var ld = new Vector3( -0.5f, -1, -0.5f );
			ld.Normalize();
			effect.Parameters[ "xLightDirection" ].SetValue( ld );

			effect.Parameters[ "xView" ].SetValue( mViewMatrix );
			effect.Parameters[ "xProjection" ].SetValue( mProjectionMatrix );
			effect.Parameters[ "xWorld" ].SetValue( WorldMatrix );

			base.Draw( gameTime );
		}
	}

	public class RiemersRotatingCamera : Camera {
		private float angle = 0f;

		public RiemersRotatingCamera( Game g ) : base( g ) { }

		public override void Update( GameTime gameTime ) {
			KeyboardState keyState = Keyboard.GetState();
			if( keyState.IsKeyDown( Keys.Delete ) )
				angle += 0.05f;
			if( keyState.IsKeyDown( Keys.PageDown ) )
				angle -= 0.05f;
			WorldMatrix = TranslationMatrix * Matrix.CreateRotationY( angle );

			base.Update( gameTime );
		}

	}

	public class RiemersFirstPersonCamera : Camera {
		private Vector3 cameraFinalTarget;
		Matrix cameraRotation;

		public Matrix Rotation {
			get { return cameraRotation; }
		}

		public Vector3 FinalTarget {
			get { return cameraFinalTarget; }
		}

		float leftrightRot = MathHelper.PiOver2;
		float updownRot = -MathHelper.Pi / 10.0f;
		const float rotationSpeed = 0.3f;
		const float moveSpeed = 30.0f;
		MouseState originalMouseState;

		public RiemersFirstPersonCamera( Game g ) : base( g ) { }


		private void UpdateViewMatrix() {
			cameraRotation = Matrix.CreateRotationX( updownRot ) * Matrix.CreateRotationY( leftrightRot );

			Vector3 cameraOriginalTarget = new Vector3( 0, 0, -1 );
			Vector3 cameraRotatedTarget = Vector3.Transform( cameraOriginalTarget, cameraRotation );
			cameraFinalTarget = Position + cameraRotatedTarget;

			Vector3 cameraOriginalUpVector = new Vector3( 0, 1, 0 );
			Vector3 cameraRotatedUpVector = Vector3.Transform( cameraOriginalUpVector, cameraRotation );

			ViewMatrix = Matrix.CreateLookAt( Position, cameraFinalTarget, cameraRotatedUpVector );
			Frustum = new BoundingFrustum( ViewMatrix * ProjectionMatrix );
		}

		protected override void LoadContent() {
			base.LoadContent();
			UpdateViewMatrix();
			Mouse.SetPosition( GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 );
			originalMouseState = Mouse.GetState();

		}

		private void ProcessInput( float amount ) {
			MouseState currentMouseState = Mouse.GetState();
			if( currentMouseState.RightButton == ButtonState.Pressed && currentMouseState != originalMouseState ) {
				float xDifference = currentMouseState.X - originalMouseState.X;
				float yDifference = currentMouseState.Y - originalMouseState.Y;
				leftrightRot -= rotationSpeed * xDifference * amount;
				updownRot -= rotationSpeed * yDifference * amount;
				Mouse.SetPosition( GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 );
				UpdateViewMatrix();
			}

			Vector3 moveVector = new Vector3( 0, 0, 0 );
			KeyboardState keyState = Keyboard.GetState();
			if( keyState.IsKeyDown( Keys.Up ) || keyState.IsKeyDown( Keys.W ) )
				moveVector += new Vector3( 0, 0, -1 );
			if( keyState.IsKeyDown( Keys.Down ) || keyState.IsKeyDown( Keys.S ) )
				moveVector += new Vector3( 0, 0, 1 );
			if( keyState.IsKeyDown( Keys.Right ) || keyState.IsKeyDown( Keys.D ) )
				moveVector += new Vector3( 1, 0, 0 );
			if( keyState.IsKeyDown( Keys.Left ) || keyState.IsKeyDown( Keys.A ) )
				moveVector += new Vector3( -1, 0, 0 );
			if( keyState.IsKeyDown( Keys.Q ) )
				moveVector += new Vector3( 0, 1, 0 );
			if( keyState.IsKeyDown( Keys.Z ) )
				moveVector += new Vector3( 0, -1, 0 );
			AddToCameraPosition( moveVector * amount );
		}

		private void AddToCameraPosition( Vector3 vectorToAdd ) {
			Matrix cameraRotation = Matrix.CreateRotationX( updownRot ) * Matrix.CreateRotationY( leftrightRot );
			Vector3 rotatedVector = Vector3.Transform( vectorToAdd, cameraRotation );
			mCameraPosition += moveSpeed * rotatedVector;
			UpdateViewMatrix();
		}


		public override void Update( GameTime gameTime ) {
			float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
			ProcessInput( timeDifference );
			base.Update( gameTime );
		}
	}

}