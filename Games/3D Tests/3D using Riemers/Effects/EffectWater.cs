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
	public class EffectWater : EffectComponent {
		private VertexBuffer mWaterVertexBuffer;
		private VertexDeclaration mWaterVertexDeclaration;
		private ReflectionMap mReflectionMap;
		private RefractionMap mRefractionMap;
		private ITerrain mTerrain;
		private RiemersFirstPersonCamera mCamera;
		private Texture2D mWaterBumpMap;


		public EffectWater( Game game, RiemersFirstPersonCamera cam, ITerrain terrain, ReflectionMap reflex, RefractionMap refrax )
			: base( game ) {
			mCamera = cam;
			mReflectionMap = reflex;
			mRefractionMap = refrax;
			mTerrain = terrain;
		}


		protected override void LoadContent() {
			VertexPositionTexture[] waterVertices = new VertexPositionTexture[ 6 ];
			var h = mReflectionMap.Height;
			var tw = mTerrain.Width;
			var tl = mTerrain.Length;

			waterVertices[ 0 ] = new VertexPositionTexture( new Vector3( 0, h, 0 ), new Vector2( 0, 1 ) );
			waterVertices[ 2 ] = new VertexPositionTexture( new Vector3( tw, h, -tl ), new Vector2( 1, 0 ) );
			waterVertices[ 1 ] = new VertexPositionTexture( new Vector3( 0, h, -tl ), new Vector2( 0, 0 ) );

			waterVertices[ 3 ] = new VertexPositionTexture( new Vector3( 0, h, 0 ), new Vector2( 0, 1 ) );
			waterVertices[ 5 ] = new VertexPositionTexture( new Vector3( tw, h, 0 ), new Vector2( 1, 1 ) );
			waterVertices[ 4 ] = new VertexPositionTexture( new Vector3( tw, h, -tl ), new Vector2( 1, 0 ) );

			mWaterVertexBuffer = new VertexBuffer( GraphicsDevice, waterVertices.Length * VertexPositionTexture.SizeInBytes, BufferUsage.WriteOnly );
			mWaterVertexBuffer.SetData( waterVertices );

			mWaterVertexDeclaration = new VertexDeclaration( GraphicsDevice, VertexPositionTexture.VertexElements );

			mWaterBumpMap = Game.Content.Load<Texture2D>( @"Textures\waterbump" );
		}

		public override void Draw( GameTime gameTime ) {
			effect.CurrentTechnique = effect.Techniques[ "Water" ];
			Matrix worldMatrix = Matrix.Identity;
			effect.Parameters[ "xWorld" ].SetValue( worldMatrix );
			effect.Parameters[ "xView" ].SetValue( mCamera.ViewMatrix );
			effect.Parameters[ "xReflectionView" ].SetValue( mReflectionMap.ViewMatrix );
			effect.Parameters[ "xProjection" ].SetValue( mCamera.ProjectionMatrix );
			effect.Parameters[ "xReflectionMap" ].SetValue( mReflectionMap.TextureMap );
			effect.Parameters[ "xRefractionMap" ].SetValue( mRefractionMap.TextureMap );
			effect.Parameters[ "xWaterBumpMap" ].SetValue( mWaterBumpMap );
			effect.Parameters[ "xWaveLength" ].SetValue( 0.1f );
			effect.Parameters[ "xWaveHeight" ].SetValue( 0.1f );
			effect.Parameters[ "xCamPos" ].SetValue( mCamera.Position );

			effect.Begin();
			foreach( EffectPass pass in effect.CurrentTechnique.Passes ) {
				pass.Begin();

				GraphicsDevice.Vertices[ 0 ].SetSource( mWaterVertexBuffer, 0, VertexPositionTexture.SizeInBytes );
				GraphicsDevice.VertexDeclaration = mWaterVertexDeclaration;
				int noVertices = mWaterVertexBuffer.SizeInBytes / VertexPositionTexture.SizeInBytes;
				GraphicsDevice.DrawPrimitives( PrimitiveType.TriangleList, 0, noVertices / 3 );

				pass.End();
			}
			effect.End();

			base.Draw( gameTime );
		}

	}
}