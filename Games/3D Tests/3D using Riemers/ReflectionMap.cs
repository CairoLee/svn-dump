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

	public interface IViewDrawable {
		void Draw( Matrix viewMatrix );
	}

	public class ReflectionMap : ImageRendering {
		RiemersFirstPersonCamera mFpCam;
		public readonly float Height;


		Matrix reflectionViewMatrix;

		public Matrix ViewMatrix {
			get { return reflectionViewMatrix; }
		}


		public List<IViewDrawable> RenderedComponents = new List<IViewDrawable>();

		public ReflectionMap( Game game, RiemersFirstPersonCamera cam, float h )
			: base( game, cam ) {
			mCamera.OnViewUpdate += new MatrixDelegate( mCamera_OnViewUpdate );
			Height = h;
			mFpCam = cam;
		}

		void mCamera_OnViewUpdate( ref Matrix m ) {
			Vector3 reflCameraPosition = mCamera.Position;
			reflCameraPosition.Y = -mCamera.Position.Y + Height * 2;
			Vector3 reflTargetPos = mFpCam.FinalTarget;
			reflTargetPos.Y = -mFpCam.FinalTarget.Y + Height * 2;

			Vector3 cameraRight = Vector3.Transform( new Vector3( 1, 0, 0 ), mFpCam.Rotation );
			Vector3 invUpVector = Vector3.Cross( cameraRight, reflTargetPos - reflCameraPosition );

			reflectionViewMatrix = Matrix.CreateLookAt( reflCameraPosition, reflTargetPos, invUpVector );

		}

		public override void Draw( GameTime gameTime ) {
			Plane reflectionPlane = CreatePlane( Height - 0.5f, new Vector3( 0, -1, 0 ), reflectionViewMatrix, true );
			GraphicsDevice.ClipPlanes[ 0 ].Plane = reflectionPlane;
			GraphicsDevice.ClipPlanes[ 0 ].IsEnabled = true;
			GraphicsDevice.SetRenderTarget( 0, mRenderTarget );
			GraphicsDevice.Clear( ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0 );

			foreach( var d in RenderedComponents )
				d.Draw( reflectionViewMatrix );

			GraphicsDevice.ClipPlanes[ 0 ].IsEnabled = false;

			GraphicsDevice.SetRenderTarget( 0, null );
			mRenderTexture = mRenderTarget.GetTexture();
			base.Draw( gameTime );
		}
	}

	public class ClearComponent : DrawableGameComponent, IViewDrawable {
		readonly Color _background = new Color( Color.WhiteSmoke.ToVector3() * 0.87f + ( Color.SkyBlue ).ToVector3() * 0.13f );
		public ClearComponent( Game g ) : base( g ) { }

		public override void Draw( GameTime gameTime ) {
			GraphicsDevice.Clear( ClearOptions.Target | ClearOptions.DepthBuffer, _background, 1.0f, 0 );
			base.Draw( gameTime );
		}

		public void Draw( Matrix viewMatrix ) {
			GraphicsDevice.Clear( ClearOptions.Target | ClearOptions.DepthBuffer, _background, 1.0f, 0 );
		}
	}
}