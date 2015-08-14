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

	public struct VertexMultiTextured {
		public Vector3 Position;
		public Vector3 Normal;
		public Vector4 TextureCoordinate;
		public Vector4 TexWeights;

		public static int SizeInBytes = ( 3 + 3 + 4 + 4 ) * sizeof( float );
		public static VertexElement[] VertexElements = new VertexElement[] {
			new VertexElement( 0, 0, VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Position, 0 ),
			new VertexElement( 0, sizeof( float ) * 3, VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Normal, 0 ),
			new VertexElement( 0, sizeof( float ) * 6, VertexElementFormat.Vector4, VertexElementMethod.Default, VertexElementUsage.TextureCoordinate, 0 ),
			new VertexElement( 0, sizeof( float ) * 10, VertexElementFormat.Vector4, VertexElementMethod.Default, VertexElementUsage.TextureCoordinate, 1 ),
		};
	}


	public interface ITerrain {
		int Width { get; }
		int Length { get; }
		List<TerrainCell> Cells { get; set; }
		float HeightAt( int x, int y );
		VertexMultiTextured[] Vertices { get; }
	}

	public class Terrain : EffectComponent, IViewDrawable, ITerrain {
		private readonly IHeightMap mHeightMap;
		private readonly ICamera mCamera;
		private readonly Game mGame;

		private bool UsePatches = true;

		private List<TerrainCell> mTerrainCells;
		private VertexBuffer mTerrainVertexBuffer;
		private IndexBuffer mTerrainIndexBuffer;
		private VertexMultiTextured[] mTerrainVertices;
		private VertexDeclaration mTerrainVertexDeclaration;
		private Texture2D mGrassTexture;
		private Texture2D mSandTexture;
		private Texture2D mRockTexture;
		private Texture2D mSnowTexture;


		public List<TerrainCell> Cells {
			get { return mTerrainCells; }
			set { mTerrainCells = value; }
		}

		public VertexMultiTextured[] Vertices {
			get { return mTerrainVertices; }
		}

		public int Width {
			get { return mHeightMap.Width; }
		}

		public int Length {
			get { return mHeightMap.Length; }
		}

		public float HeightAt( int x, int y ) {
			return mHeightMap[ x, y ];
		}


		public Terrain( Game game, IHeightMap heightMap, ICamera camera )
			: base( game ) {
			mGame = game;
			mHeightMap = heightMap;
			mCamera = camera;
			mTerrainCells = new List<TerrainCell>();
		}



		protected override void LoadContent() {
			mHeightMap.Initialise();

			if( UsePatches == true )
				SetupTerrainPatches();
			else
				LoadVertices();
			LoadTextures();
		}


		public void Draw( Matrix viewMatrix, BoundingFrustum frustum ) {

			effect.CurrentTechnique = effect.Techniques[ "MultiTextured" ];
			effect.Parameters[ "xTexture0" ].SetValue( mSandTexture );
			effect.Parameters[ "xTexture1" ].SetValue( mGrassTexture );
			effect.Parameters[ "xTexture2" ].SetValue( mRockTexture );
			effect.Parameters[ "xTexture3" ].SetValue( mSnowTexture );
			effect.Parameters[ "xView" ].SetValue( viewMatrix );

			effect.Begin();
			foreach( EffectPass pass in effect.CurrentTechnique.Passes ) {
				pass.Begin();

				if( UsePatches == true ) {
					int drawn = 0;
					for( int i = 0; i < mTerrainCells.Count; ++i )
						if( frustum.Contains( mTerrainCells[ i ].BoundingBox ) != ContainmentType.Disjoint ) {
							mTerrainCells[ i ].Draw();
							drawn++;
						}
					Debug.WriteLine( "Drawn Cells: " + drawn );
				} else {

					GraphicsDevice.VertexDeclaration = mTerrainVertexDeclaration;
					GraphicsDevice.Indices = mTerrainIndexBuffer;
					GraphicsDevice.Vertices[ 0 ].SetSource( mTerrainVertexBuffer, 0, VertexMultiTextured.SizeInBytes );
					int noVertices = mTerrainVertexBuffer.SizeInBytes / VertexMultiTextured.SizeInBytes;
					int noTriangles = mTerrainIndexBuffer.SizeInBytes / sizeof( int ) / 3;
					GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleList, 0, 0, noVertices, 0, noTriangles );
				}

				pass.End();
			}
			effect.End();
		}


		public void Draw( Matrix viewMatrix ) {
			Draw( viewMatrix, mCamera.Frustum );
		}

		public override void Draw( GameTime gameTime ) {
			Draw( mCamera.ViewMatrix, mCamera.Frustum );
		}



		private void LoadVertices() {

			// Setup TerrainVertices
			mTerrainVertices = new VertexMultiTextured[ mHeightMap.Width * mHeightMap.Length ];
			for( int x = 0; x < mHeightMap.Width; x++ ) {
				for( int y = 0; y < mHeightMap.Length; y++ ) {
					mTerrainVertices[ x + y * mHeightMap.Width ].Position = GetPositionAt( x, y );
					mTerrainVertices[ x + y * mHeightMap.Width ].TextureCoordinate.X = (float)x / 30.0f;
					mTerrainVertices[ x + y * mHeightMap.Width ].TextureCoordinate.Y = (float)y / 30.0f;
				}
			}


			// Setup TerrainIndices
			int[] terrainIndices = new int[ ( mHeightMap.Width - 1 ) * ( mHeightMap.Length - 1 ) * 6 ];
			int counter = 0;
			for( int x = 0; x < mHeightMap.Width - 1; x++ ) {
				for( int y = 0; y < mHeightMap.Length - 1; y++ ) {
					int lowerLeft = x + y * mHeightMap.Width;
					int lowerRight = ( x + 1 ) + y * mHeightMap.Width;
					int topLeft = x + ( y + 1 ) * mHeightMap.Width;
					int topRight = ( x + 1 ) + ( y + 1 ) * mHeightMap.Width;

					terrainIndices[ counter++ ] = topLeft;
					terrainIndices[ counter++ ] = lowerRight;
					terrainIndices[ counter++ ] = lowerLeft;

					terrainIndices[ counter++ ] = topLeft;
					terrainIndices[ counter++ ] = topRight;
					terrainIndices[ counter++ ] = lowerRight;
				}
			}


			// Calculate Normals
			for( int i = 0; i < mTerrainVertices.Length; i++ )
				mTerrainVertices[ i ].Normal = new Vector3( 0, 1, 2 );

			for( int i = 0; i < terrainIndices.Length / 3; i++ ) {
				int index1 = terrainIndices[ i * 3 ];
				int index2 = terrainIndices[ i * 3 + 1 ];
				int index3 = terrainIndices[ i * 3 + 2 ];

				Vector3 side1 = mTerrainVertices[ index2 ].Position - mTerrainVertices[ index1 ].Position;
				Vector3 side2 = mTerrainVertices[ index2 ].Position - mTerrainVertices[ index3 ].Position;
				Vector3 normal = Vector3.Cross( side1, side2 );

				mTerrainVertices[ index1 ].Normal += normal;
				mTerrainVertices[ index2 ].Normal += normal;
				mTerrainVertices[ index3 ].Normal += normal;
			}

			for( int i = 0; i < mTerrainVertices.Length; i++ )
				mTerrainVertices[ i ].Normal.Normalize();


			// Setup TerrainTexWeights
			int index = 0;

			for( int x = 0; x < mHeightMap.Width; x++ ) {
				for( int y = 0; y < mHeightMap.Length; y++ ) {
					index = x + y * mHeightMap.Width;

					if( mTerrainVertices[ index ].Normal.Y > 0.6f ) {
						mTerrainVertices[ index ].TexWeights.X = GetTexWeight( x, y, 0f, 8f );
						mTerrainVertices[ index ].TexWeights.Y = GetTexWeight( x, y, 12f, 6f );
						mTerrainVertices[ index ].TexWeights.Z = 1.0f - mTerrainVertices[ index ].Normal.Y;
						mTerrainVertices[ index ].TexWeights.W = GetTexWeight( x, y, 30f, 6f );
					} else {
						mTerrainVertices[ index ].TexWeights.Z = 1.0f;
						mTerrainVertices[ index ].TexWeights.W = GetTexWeight( x, y, 30f, 6f );
					}
					// normalise fuzzy weights -- to sum up to one
					float total = mTerrainVertices[ index ].TexWeights.X + mTerrainVertices[ index ].TexWeights.Y + mTerrainVertices[ index ].TexWeights.Z + mTerrainVertices[ index ].TexWeights.W;

					mTerrainVertices[ index ].TexWeights.X /= total;
					mTerrainVertices[ index ].TexWeights.Y /= total;
					mTerrainVertices[ index ].TexWeights.Z /= total;
					mTerrainVertices[ index ].TexWeights.W /= total;

				}
			}

			// CopyTo Buffers
			mTerrainVertexBuffer = new VertexBuffer( GraphicsDevice, mTerrainVertices.Length * VertexMultiTextured.SizeInBytes, BufferUsage.WriteOnly );
			mTerrainVertexBuffer.SetData( mTerrainVertices );

			mTerrainIndexBuffer = new IndexBuffer( GraphicsDevice, typeof( int ), terrainIndices.Length, BufferUsage.WriteOnly );
			mTerrainIndexBuffer.SetData( terrainIndices );

			mTerrainVertexDeclaration = new VertexDeclaration( GraphicsDevice, VertexMultiTextured.VertexElements );
		}


		private void SetupTerrainPatches() {

			// Clear the terrain cells.
			if( mTerrainCells == null )
				mTerrainCells = new List<TerrainCell>();
			else
				mTerrainCells.Clear();

			// Compute the world matrix to place the terrain in the middle of the scene.
			Matrix WorldMatrix = Matrix.CreateTranslation( (float)mHeightMap.Width * -0.5f, 0.0f, (float)mHeightMap.Length * -0.5f );

			// Create the terrain patches.
			int patchWidth = 16;
			int patchLength = 16;
			int patchCountX = mHeightMap.Width / patchWidth;
			int patchCountZ = mHeightMap.Length / patchLength;
			int patchCount = patchCountX * patchCountZ;

			for( int x = 0; x < patchCountX; ++x ) {
				for( int z = 0; z < patchCountZ; ++z ) {
					TerrainCell patch = new TerrainCell( mGame );

					patch.BuildPatch( mHeightMap, WorldMatrix, patchWidth, patchLength, x * ( patchWidth - 1 ), z * ( patchLength - 1 ) );

					mTerrainCells.Add( patch );
				}
			}
		}



		private void LoadTextures() {
			mGrassTexture = Game.Content.Load<Texture2D>( @"Textures\grass" );
			mSandTexture = Game.Content.Load<Texture2D>( @"Textures\sand" );
			mRockTexture = Game.Content.Load<Texture2D>( @"Textures\rock" );
			mSnowTexture = Game.Content.Load<Texture2D>( @"Textures\snow" );
		}



		private float GetTexWeight( int x, int y, float i, float j ) {
			return MathHelper.Clamp( 1.0f - Math.Abs( mHeightMap[ x, y ] - i ) / j, 0.0f, 1.0f );
		}

		private Vector3 GetPositionAt( int x, int y ) {
			return new Vector3( (float)x, mHeightMap[ x, y ], (float)-y );
		}




	}
}
