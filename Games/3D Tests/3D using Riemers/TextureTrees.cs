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
using System.Diagnostics;


namespace Engine3DFromRiemersTutorial {

	public class TextureTrees : DrawableGameComponent, IViewDrawable {
		Effect mBBEffect;
		VertexBuffer mTreeVertexBuffer;
		VertexDeclaration mTreeVertexDeclaration;
		Texture2D mTreeTexture;
		Camera mCamera;
		ITerrain mTerrain;

		public TextureTrees( Game game, Camera cam, ITerrain terrain )
			: base( game ) {
			mCamera = cam;
			mTerrain = terrain;
			Visible = false;

		}

		private void CreateBillboardVerticesFromList( List<Vector3> treeList ) {
			VertexPositionTexture[] billboardVertices = new VertexPositionTexture[ treeList.Count * 6 ];
			int i = 0;
			foreach( Vector3 currentV3 in treeList ) {
				billboardVertices[ i++ ] = new VertexPositionTexture( currentV3, new Vector2( 0, 0 ) );
				billboardVertices[ i++ ] = new VertexPositionTexture( currentV3, new Vector2( 1, 0 ) );
				billboardVertices[ i++ ] = new VertexPositionTexture( currentV3, new Vector2( 1, 1 ) );

				billboardVertices[ i++ ] = new VertexPositionTexture( currentV3, new Vector2( 0, 0 ) );
				billboardVertices[ i++ ] = new VertexPositionTexture( currentV3, new Vector2( 1, 1 ) );
				billboardVertices[ i++ ] = new VertexPositionTexture( currentV3, new Vector2( 0, 1 ) );
			}

			mTreeVertexBuffer = new VertexBuffer( GraphicsDevice, billboardVertices.Length * VertexPositionTexture.SizeInBytes, BufferUsage.WriteOnly );
			mTreeVertexBuffer.SetData( billboardVertices );
			mTreeVertexDeclaration = new VertexDeclaration( GraphicsDevice, VertexPositionTexture.VertexElements );
		}

		private List<Vector3> GenerateTreePositions( Texture2D treeMap, VertexMultiTextured[] terrainVertices ) {
			Color[] treeMapColors = new Color[ treeMap.Width * treeMap.Height ];
			treeMap.GetData( treeMapColors );

			int[ , ] noiseData = new int[ treeMap.Width, treeMap.Height ];
			for( int x = 0; x < treeMap.Width; x++ )
				for( int y = 0; y < treeMap.Height; y++ )
					noiseData[ x, y ] = treeMapColors[ y + x * treeMap.Height ].R;


			List<Vector3> treeList = new List<Vector3>();
			Random random = new Random();

			for( int x = 0; x < mTerrain.Width; x++ ) {
				for( int y = 0; y < mTerrain.Length; y++ ) {
					float terrainHeight = mTerrain.HeightAt( x, y );
					if( ( terrainHeight > 8 ) && ( terrainHeight < 14 ) ) {
						float flatness = Vector3.Dot( terrainVertices[ x + y * mTerrain.Width ].Normal, new Vector3( 0, 1, 0 ) );
						float minFlatness = (float)Math.Cos( MathHelper.ToRadians( 15 ) );
						if( flatness > minFlatness ) {
							float relx = (float)x / (float)mTerrain.Width;
							float rely = (float)y / (float)mTerrain.Length;

							float noiseValueAtCurrentPosition = noiseData[ (int)( relx * treeMap.Width ), (int)( rely * treeMap.Height ) ];
							float treeDensity;
							if( noiseValueAtCurrentPosition > 200 )
								treeDensity = 5;
							else if( noiseValueAtCurrentPosition > 150 )
								treeDensity = 4;
							else if( noiseValueAtCurrentPosition > 100 )
								treeDensity = 3;
							else
								treeDensity = 0;

							for( int currDetail = 0; currDetail < treeDensity; currDetail++ ) {
								float rand1 = (float)random.Next( 1000 ) / 1000.0f;
								float rand2 = (float)random.Next( 1000 ) / 1000.0f;
								Vector3 treePos = new Vector3( (float)x - rand1, 0, -(float)y - rand2 );
								treePos.Y = mTerrain.HeightAt( x, y );
								treeList.Add( treePos );
							}

						}

					}
				}
			}

			return treeList;
		}

		protected override void LoadContent() {
			mBBEffect = Game.Content.Load<Effect>( @"Effects\bbEffect" );
			mTreeTexture = Game.Content.Load<Texture2D>( @"Textures\tree" );
			Texture2D treeMap = Game.Content.Load<Texture2D>( @"Textures\Maps\treeMap" );
			List<Vector3> treeList = GenerateTreePositions( treeMap, mTerrain.Vertices );
			if( treeList.Count != 0 ) {
				CreateBillboardVerticesFromList( treeList );
				Visible = true;
			}
			base.LoadContent();
		}


		public void Draw( Matrix viewMatrix ) {
			if( !Visible )
				return;
			GraphicsDevice.RenderState.AlphaBlendEnable = true;
			GraphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
			GraphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

			mBBEffect.CurrentTechnique = mBBEffect.Techniques[ "CylBillboard" ];
			mBBEffect.Parameters[ "xWorld" ].SetValue( Matrix.Identity );
			mBBEffect.Parameters[ "xView" ].SetValue( viewMatrix );
			mBBEffect.Parameters[ "xProjection" ].SetValue( mCamera.ProjectionMatrix );
			mBBEffect.Parameters[ "xCamPos" ].SetValue( mCamera.Position );
			mBBEffect.Parameters[ "xAllowedRotDir" ].SetValue( new Vector3( 0, 1, 0 ) );
			mBBEffect.Parameters[ "xBillboardTexture" ].SetValue( mTreeTexture );

			mBBEffect.Begin();
			GraphicsDevice.Vertices[ 0 ].SetSource( mTreeVertexBuffer, 0, VertexPositionTexture.SizeInBytes );
			GraphicsDevice.VertexDeclaration = mTreeVertexDeclaration;
			int noVertices = mTreeVertexBuffer.SizeInBytes / VertexPositionTexture.SizeInBytes;
			int noTriangles = noVertices / 3;
			{
				GraphicsDevice.RenderState.AlphaTestEnable = true;
				GraphicsDevice.RenderState.AlphaFunction = CompareFunction.GreaterEqual;
				GraphicsDevice.RenderState.ReferenceAlpha = 200;

				mBBEffect.CurrentTechnique.Passes[ 0 ].Begin();
				GraphicsDevice.DrawPrimitives( PrimitiveType.TriangleList, 0, noTriangles );
				mBBEffect.CurrentTechnique.Passes[ 0 ].End();
			}

			{
				GraphicsDevice.RenderState.DepthBufferWriteEnable = false;

				GraphicsDevice.RenderState.AlphaBlendEnable = true;
				GraphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
				GraphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

				GraphicsDevice.RenderState.AlphaTestEnable = true;
				GraphicsDevice.RenderState.AlphaFunction = CompareFunction.Less;
				GraphicsDevice.RenderState.ReferenceAlpha = 200;

				mBBEffect.CurrentTechnique.Passes[ 0 ].Begin();
				GraphicsDevice.DrawPrimitives( PrimitiveType.TriangleList, 0, noTriangles );
				mBBEffect.CurrentTechnique.Passes[ 0 ].End();
			}

			GraphicsDevice.RenderState.AlphaBlendEnable = false;
			GraphicsDevice.RenderState.DepthBufferWriteEnable = true;
			GraphicsDevice.RenderState.AlphaTestEnable = false;
			mBBEffect.End();

		}

		public override void Draw( GameTime gameTime ) {
			Draw( mCamera.ViewMatrix );
			base.Draw( gameTime );
		}

	}
}