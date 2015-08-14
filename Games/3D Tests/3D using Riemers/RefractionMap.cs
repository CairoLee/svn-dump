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

	public class ImageRendering : EffectComponent {
		protected readonly Camera mCamera;
		protected RenderTarget2D mRenderTarget;
		protected Texture2D mRenderTexture;

		public Texture2D TextureMap {
			get { return mRenderTexture; }
		}



		public ImageRendering( Game game, Camera cam )
			: base( game ) {
			mCamera = cam;
		}

		protected override void LoadContent() {
			PresentationParameters pp = GraphicsDevice.PresentationParameters;
			mRenderTarget = new RenderTarget2D( GraphicsDevice,
				pp.BackBufferWidth, pp.BackBufferHeight, 1, GraphicsDevice.DisplayMode.Format );
		}

		protected Plane CreatePlane( float height, Vector3 planeNormalDirection, Matrix currentViewMatrix, bool clipSide ) {
			planeNormalDirection.Normalize();
			Vector4 planeCoeffs = new Vector4( planeNormalDirection, height );
			if( clipSide )
				planeCoeffs *= -1;

			Matrix worldViewProjection = currentViewMatrix * mCamera.ProjectionMatrix;
			Matrix inverseWorldViewProjection = Matrix.Invert( worldViewProjection );
			inverseWorldViewProjection = Matrix.Transpose( inverseWorldViewProjection );

			planeCoeffs = Vector4.Transform( planeCoeffs, inverseWorldViewProjection );
			Plane finalPlane = new Plane( planeCoeffs );

			return finalPlane;
		}


	}

	public class RefractionMap : ImageRendering {
		readonly float mHeight;

		public List<IDrawable> RenderedComponents = new List<IDrawable>();

		public RefractionMap( Game game, Camera cam, float height )
			: base( game, cam ) {
			mHeight = height;
		}


		public override void Draw( GameTime gameTime ) {
			Plane refractionPlane = CreatePlane( mHeight + 1.5f, new Vector3( 0, -1, 0 ),
	mCamera.ViewMatrix, false );
			GraphicsDevice.ClipPlanes[ 0 ].Plane = refractionPlane;
			GraphicsDevice.ClipPlanes[ 0 ].IsEnabled = true;
			GraphicsDevice.SetRenderTarget( 0, mRenderTarget );
			GraphicsDevice.Clear( ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0 );

			foreach( var d in RenderedComponents )
				d.Draw( gameTime );

			GraphicsDevice.ClipPlanes[ 0 ].IsEnabled = false;

			GraphicsDevice.SetRenderTarget( 0, null );
			mRenderTexture = mRenderTarget.GetTexture();


			base.Draw( gameTime );
		}
	}
}