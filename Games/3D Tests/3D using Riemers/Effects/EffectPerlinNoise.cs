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

	public class EffectPerlinNoise : EffectComponent {
		RenderTarget2D mCloudsRenderTarget;
		Texture2D mCloudStaticMap;
		VertexPositionTexture[] mFullScreenVertices;
		VertexDeclaration mFullScreenVertexDeclaration;
		Texture2D mTexture;

		public Texture2D Texture {
			get { return mTexture; }
		}

		private Texture2D CreateStaticMap( int resolution ) {
			Random rand = new Random();
			Color[] noisyColors = new Color[ resolution * resolution ];
			for( int x = 0; x < resolution; x++ )
				for( int y = 0; y < resolution; y++ )
					noisyColors[ x + y * resolution ] = new Color( new Vector3( (float)rand.Next( 1000 ) / 1000.0f, 0, 0 ) );

			Texture2D noiseImage = new Texture2D( GraphicsDevice, resolution, resolution, 1, TextureUsage.None, SurfaceFormat.Color );
			noiseImage.SetData( noisyColors );
			return noiseImage;
		}

		private VertexPositionTexture[] SetUpFullscreenVertices() {
			VertexPositionTexture[] vertices = new VertexPositionTexture[ 4 ];

			vertices[ 0 ] = new VertexPositionTexture( new Vector3( -1, 1, 0f ), new Vector2( 0, 1 ) );
			vertices[ 1 ] = new VertexPositionTexture( new Vector3( 1, 1, 0f ), new Vector2( 1, 1 ) );
			vertices[ 2 ] = new VertexPositionTexture( new Vector3( -1, -1, 0f ), new Vector2( 0, 0 ) );
			vertices[ 3 ] = new VertexPositionTexture( new Vector3( 1, -1, 0f ), new Vector2( 1, 0 ) );

			return vertices;
		}


		protected override void LoadContent() {
			PresentationParameters pp = GraphicsDevice.PresentationParameters;
			mCloudsRenderTarget = new RenderTarget2D( GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, 1,
				GraphicsDevice.DisplayMode.Format );
			mCloudStaticMap = CreateStaticMap( 32 );
			mFullScreenVertices = SetUpFullscreenVertices();
			mFullScreenVertexDeclaration = new VertexDeclaration( GraphicsDevice, VertexPositionTexture.VertexElements );
			base.LoadContent();
		}

		public EffectPerlinNoise( Game game )
			: base( game ) {
		}

		public override void Draw( GameTime gameTime ) {
			GraphicsDevice.SetRenderTarget( 0, mCloudsRenderTarget );
			GraphicsDevice.Clear( ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0 );

			effect.CurrentTechnique = effect.Techniques[ "PerlinNoise" ];
			effect.Parameters[ "xTexture" ].SetValue( mCloudStaticMap );
			effect.Parameters[ "xOvercast" ].SetValue( 1.1f );
			effect.Begin();
			foreach( EffectPass pass in effect.CurrentTechnique.Passes ) {
				pass.Begin();

				GraphicsDevice.VertexDeclaration = mFullScreenVertexDeclaration;
				GraphicsDevice.DrawUserPrimitives( PrimitiveType.TriangleStrip, mFullScreenVertices, 0, 2 );

				pass.End();
			}
			effect.End();

			GraphicsDevice.SetRenderTarget( 0, null );
			mTexture = mCloudsRenderTarget.GetTexture();

			base.Draw( gameTime );
		}
	}
}