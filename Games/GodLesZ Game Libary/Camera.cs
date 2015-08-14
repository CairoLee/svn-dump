//Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GLibary {
	public partial class Utility {
		private static Camera camera = null;

		public static Camera Camera {
			get {
				if( camera == null ) {
					Camera = new Camera();
				}
				return camera;
			}
			set {
				if( camera != null ) {
					RemoveService<CameraService>();
				}
				camera = value;
				AddService<CameraService>( new CameraService( camera ) );
			}
		}
	}

	public interface ICameraService {
		Camera Camera {
			get;
		}
	}

	public class CameraService : ICameraService {

		public CameraService( Camera camera ) {
			this.camera = camera;
		}

		private Camera camera;

		public Camera Camera {
			get {
				return camera;
			}
		}

		public static implicit operator Camera( CameraService cs ) {
			return cs.Camera;
		}
	}



	public class Camera {
		[Flags()]
		enum DirtyState {
			None = 0,
			ViewDirty = 1,
			ProjDirty = 2,
			ViewProjDirty = 4,
			InvViewDirty = 8,
			InvProjDirty = 16,
			InvViewProjDirty = 32,
			AllView = ViewDirty | InvViewDirty | ViewProjDirty | InvViewProjDirty,

			AllProj = ProjDirty | InvProjDirty | ViewProjDirty | InvViewProjDirty,

			All = ViewDirty | ProjDirty | ViewProjDirty | InvViewDirty | InvProjDirty | InvViewProjDirty,
		}

		DirtyState dirtyState = DirtyState.All;


		public Camera()	: this( Vector3.Zero, Vector3.Forward, Vector3.Up, Utility.GetViewportAspectRatio(), MathHelper.PiOver4, 1.0f, 10000.0f ) {

		}

		public Camera( Vector3 position, Vector3 direction ) : this( position, direction, Vector3.Up, Utility.GetViewportAspectRatio(), MathHelper.PiOver4, 1.0f, 10000.0f ) {

		}

		public Camera( Vector3 position, Vector3 direction, Vector3 up, float aspectRatio, float fieldOfView, float nearPlane, float farPlane ) {
			Position = position;
			Direction = direction;
			Up = up;
			AspectRatio = aspectRatio;
			FieldOfView = fieldOfView;
			NearPlane = nearPlane;
			FarPlane = farPlane;

			dirtyState = DirtyState.All;
		}

		//Near Plane

		private float nearPlane;
		public float NearPlane {
			get {
				return nearPlane;
			}
			set {
				nearPlane = value;

				dirtyState |= DirtyState.AllProj;
			}
		}

		//Far Plane

		private float farPlane;
		public float FarPlane {
			get {
				return farPlane;
			}
			set {
				farPlane = value;

				dirtyState |= DirtyState.AllProj;
			}
		}

		//Field Of View

		private float fieldOfView;
		public float FieldOfView {
			get {
				return fieldOfView;
			}
			set {
				fieldOfView = value;

				dirtyState |= DirtyState.AllProj;
			}
		}

		//Aspect Ratio

		private float aspectRatio;
		public float AspectRatio {
			get {
				return aspectRatio;
			}
			set {
				aspectRatio = value;

				dirtyState |= DirtyState.AllProj;
			}
		}

		//Matrix Projection

		private Matrix projectionMatrix;
		public Matrix Projection {
			get {
				if( ( dirtyState & DirtyState.ProjDirty ) == DirtyState.ProjDirty ) {
					projectionMatrix = Matrix.CreatePerspectiveFieldOfView( fieldOfView, aspectRatio, nearPlane, farPlane );

					dirtyState |= DirtyState.AllProj;
					dirtyState ^= DirtyState.ProjDirty;
				}

				return projectionMatrix;
			}
		}




		//Matrix View

		private Matrix viewMatrix;
		public Matrix View {
			get {
				if( ( dirtyState & DirtyState.ViewDirty ) == DirtyState.ViewDirty ) {
					viewMatrix = Matrix.CreateLookAt( position, position + direction, up );

					dirtyState |= DirtyState.AllView;
					dirtyState ^= DirtyState.ViewDirty;
				}
				return viewMatrix;
			}
		}




		//Matrix ViewProjection

		private Matrix viewProjectionMatrix;
		public Matrix ViewProjection {
			get {
				if( ( dirtyState & DirtyState.ViewProjDirty ) == DirtyState.ViewProjDirty ) {
					viewProjectionMatrix = View * Projection;

					dirtyState ^= DirtyState.ViewProjDirty;

					dirtyState |= DirtyState.InvViewProjDirty;
				}
				return viewProjectionMatrix;
			}
		}





		//Matrix InvProjection

		private Matrix invProjectionMatrix;
		public Matrix InvProjection {
			get {
				if( ( dirtyState & DirtyState.InvProjDirty ) == DirtyState.InvProjDirty ) {
					invProjectionMatrix = Matrix.Invert( Projection );

					dirtyState ^= DirtyState.InvProjDirty;
				}

				return invProjectionMatrix;
			}
		}




		//Matrix InvView

		private Matrix invViewMatrix;
		public Matrix InvView {
			get {
				if( ( dirtyState & DirtyState.InvViewDirty ) == DirtyState.InvViewDirty ) {
					invViewMatrix = Matrix.Invert( View );

					dirtyState ^= DirtyState.InvViewDirty;
				}
				return invViewMatrix;
			}
		}




		//Matrix InvViewProjection

		private Matrix invViewProjectionMatrix;
		public Matrix InvViewProjection {
			get {
				if( ( dirtyState & DirtyState.InvViewProjDirty ) == DirtyState.InvViewProjDirty ) {
					invViewProjectionMatrix = Matrix.Invert( ViewProjection );

					dirtyState ^= DirtyState.InvViewProjDirty;
				}
				return invViewProjectionMatrix;
			}
		}






		//Camera Position

		private Vector3 position;
		public Vector3 Position {
			get {
				return position;
			}
			set {
				position = value;

				dirtyState |= DirtyState.AllView;
			}
		}




		//Camera Target
		public Vector3 Target {
			get {
				return position + direction;
			}
			set {
				direction = Vector3.Normalize( value - position );

				dirtyState |= DirtyState.AllView;
			}
		}



		private Vector3 direction;
		public Vector3 Direction {
			get {
				return direction;
			}
			set {
				direction = value;

				dirtyState |= DirtyState.AllView;
			}
		}

		//Camera Up Vector

		private Vector3 up;
		public Vector3 Up {
			get {
				return up;
			}
			set {
				up = value;

				dirtyState |= DirtyState.AllView;
			}
		}
	}

	public class CameraMovements {

		static public Vector3 CameraResult; //This Vector3 holds the general camera movements
		static public Vector3 LookAtResult; //This Vector3 holds the movements of the LookAt and only them.

		/// <summary>
		/// The standard camera movements (Output: Vector3 CameraResut / Vector3 LookAtResult)
		/// </summary>
		/// <param name="CameraPosition">Current camera position</param>
		/// <param name="LookAt">Current lookat position</param>
		/// <param name="Speed">Velocity of the camera movements</param>
		static public void Hover( Vector3 CameraPosition, Vector3 LookAt, float Speed ) {
			KeyboardState keyboard = Keyboard.GetState();
			MouseState mouse = Mouse.GetState();

			//Create all needed values:
			#region Create Values

			//The direction from the Camera to the LookAt:
			Vector3 Direction = LookAt - CameraPosition;

			Direction.Normalize();

			//This Vector3 defines the relative X-axis of the view (Forward).
			Vector3 RelativeX = Direction;

			//AlphaY holds the rotation of RelativeX around the absolut Y-axis, starting at the absolut X-axis.
			float AlphaY = 0.0f;

			if( RelativeX.Z >= 0 ) {
				AlphaY = (float)Math.Atan2( RelativeX.Z, RelativeX.X );
			} else if( RelativeX.Z < 0 ) {
				AlphaY = (float)Math.Atan2( RelativeX.Z, RelativeX.X ) + ( 2 * (float)Math.PI );
			}

			//AlphaZ holds the rotation of RelativeX around the RelativeZ axis (Right).
			//RelativeZ will be defined later, based on RelativeX.
			float AlphaZ = -(float)Math.Atan( RelativeX.Y /
				(float)Math.Sqrt( Math.Pow( RelativeX.X, 2f ) + Math.Pow( RelativeX.Z, 2f ) ) );

			//The RelativeZ axis holds the driection Right. It will be used for movements.
			Vector3 RelativeZ;

			RelativeZ.X = RelativeX.Z;
			RelativeZ.Y = 0.0f;
			RelativeZ.Z = -RelativeX.X;

			RelativeZ.Normalize();

			//The RelativeY axis holds the direction Up. Again it will be used for movements.
			Vector3 RelativeY = new Vector3( 0, 1, 0 );

			RelativeY.X = -RelativeX.Y;
			RelativeY.Y = (float)Math.Sqrt( Math.Pow( RelativeX.X, 2f ) + Math.Pow( RelativeX.Z, 2f ) );

			RelativeY = Vector3.Transform( RelativeY, Matrix.CreateRotationY( -AlphaY ) );

			RelativeY.Normalize();

			//Two integers to indicate who far the mouse has moved since the last fram:
			float mousemoveX = 0;
			float mousemoveY = 0;

			// This float holds the Angle the camera has moved around the Z.axis since last frame.
			float AngleAddZ = 0;

			// This float holds the Angle the camera has moved around the Y.axis since last frame.
			float AngleAddY = 0;

			//This Vektor holds the relative position of the LookAt based on the CameraPosition,
			//It will be importent to calculate the new LookAt position.
			Vector3 Before = CameraPosition - LookAt;

			//After is the vector holding the new relative position of the LookAt.
			Vector3 After;

			//Velocity holds the movement of the Camera and the LookAt in the absolut space.
			Vector3 Velocity = Vector3.Zero;

			//This Vector will hold the movement of the LookAt that, when applayed, will the LookAt
			//rotate around the camera.
			Vector3 Rotation;

			#endregion

			//Handle the Input by the Keyboard (A/W/S/D) to move the Camera:
			#region Handle Keyboard

			//Handle W/S as a control for the forward movements of the Camera:
			if( keyboard.IsKeyDown( Keys.W ) && keyboard.IsKeyUp( Keys.S ) ) {
				Velocity += RelativeX * Speed;
			} else if( keyboard.IsKeyDown( Keys.S ) && keyboard.IsKeyUp( Keys.W ) ) {
				Velocity -= RelativeX * Speed;
			}

			//Handle A/D as a control for the left/right movements of the Camera:
			if( keyboard.IsKeyDown( Keys.D ) && keyboard.IsKeyUp( Keys.A ) ) {
				Velocity -= RelativeZ * Speed;
			} else if( keyboard.IsKeyDown( Keys.A ) && keyboard.IsKeyUp( Keys.D ) ) {
				Velocity += RelativeZ * Speed;
			}

			//Handle E/Q as a control for the up/down movements of the Camera:
			if( keyboard.IsKeyDown( Keys.E ) && keyboard.IsKeyUp( Keys.Q ) ) {
				Velocity += RelativeY * Speed;
			} else if( keyboard.IsKeyDown( Keys.Q ) && keyboard.IsKeyUp( Keys.E ) ) {
				Velocity -= RelativeY * Speed;
			}

			#endregion

			//Handle the Input by the Mouse and the Arrow Keys to rotate the Camera:
			#region Handle Mouse

			//For this movement control code we will look at the position of the coursor
			//relative to the center of the screen, so you'll need two values for this MonitorWidth
			// and MonitorHeight.
			//For this example I will take the dimensions 1440 to 900.

			int MonitorWidth = 1440;
			int MonitorHeight = 900;

			mousemoveX = mouse.Y - ( MonitorHeight / 2 );
			mousemoveY = mouse.X - ( MonitorWidth / 2 );

			AngleAddZ = (float)MathHelper.ToRadians( mousemoveX / 3 );
			AngleAddY = -(float)MathHelper.ToRadians( mousemoveY / 3 );

			//Note: The next call will set the mouse into the center of the screen
			// again, in that case you will have to close the window with Alt + F4.

			Mouse.SetPosition( MonitorWidth / 2, MonitorHeight / 2 );

			//Now applay the mousemovements:

			Matrix RotationMatrix =
					Matrix.CreateFromAxisAngle( RelativeZ, AngleAddZ ) *
					Matrix.CreateRotationY( AngleAddY );

			After = Vector3.Transform( Before, RotationMatrix );

			Rotation = Before - After;

			#endregion

			CameraResult = Velocity;

			LookAtResult = Rotation;
		}
	}
}
