using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Engine3DFromRiemersTutorial {

	public class TerrainCell {
		private Game mGame;
		private BoundingBox mBoundingBox;

		private VertexMultiTextured[] mPatchVertices;
		private VertexBuffer mVertexBuffer;
		private IndexBuffer mIndexBuffer;
		private VertexDeclaration mTerrainVertexDeclaration;
		private int[] mPatchIndices;

		private int mWidth;
		private int mLength;

		private int mOffsetX;
		private int mOffsetZ;

		/// <summary>
		/// Get the bounding box.
		/// </summary>
		public BoundingBox BoundingBox {
			get { return mBoundingBox; }
		}



		/// <summary>
		/// Default constructor.
		/// </summary>
		public TerrainCell( Game g ) {
			mBoundingBox = new BoundingBox();
			mGame = g;
		}


		/// <summary>
		/// Draw the terrain patch.
		/// </summary>
		public void Draw() {
			int primitivePerStrip = ( mLength - 1 ) * 2;
			int stripCount = mWidth - 1;
			int vertexPerStrip = mLength * 2;

			for( int s = 0; s < stripCount; ++s ) {
				mGame.GraphicsDevice.VertexDeclaration = mTerrainVertexDeclaration;
				mGame.GraphicsDevice.Indices = mIndexBuffer;
				mGame.GraphicsDevice.Vertices[ 0 ].SetSource( mVertexBuffer, 0, VertexMultiTextured.SizeInBytes );
				int noVertices = mVertexBuffer.SizeInBytes / VertexMultiTextured.SizeInBytes;
				int noTriangles = mIndexBuffer.SizeInBytes / sizeof( int ) / 3;
				mGame.GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleList, 0, 0, noVertices, 0, noTriangles );

				/*
				mGame.GraphicsDevice.Vertices[ 0 ].SetSource( mVertexBuffer, 0, VertexPositionNormalTexture.SizeInBytes );
				mGame.GraphicsDevice.Indices = mIndexBuffer;
				mGame.GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleStrip, 0, 0, mVertexPosition.Length, vertexPerStrip * s, primitivePerStrip );
				*/
			}

		}


		/// <summary>
		/// Build a terrain patch.
		/// </summary>
		/// <param name="heightmap"></param>
		/// <param name="worldMatrix"></param>
		/// <param name="width"></param>
		/// <param name="depth"></param>
		/// <param name="offsetX"></param>
		/// <param name="offsetZ"></param>
		public void BuildPatch( IHeightMap heightmap, Matrix worldMatrix, int width, int length, int offsetX, int offsetZ ) {
			mWidth = width;
			mLength = length;

			mOffsetX = offsetX;
			mOffsetZ = offsetZ;

			mBoundingBox.Min = new Vector3( mOffsetX, float.MaxValue, mOffsetZ );
			mBoundingBox.Max = new Vector3( mOffsetX + mWidth, float.MinValue, mOffsetZ + mLength );

			BuildBoundingBox( heightmap );

			BuildVertexBuffer( heightmap );
			BuildIndexBuffer( heightmap );
			BuildNormals();
			BuildTerrainTexWeights( heightmap );

			mVertexBuffer = new VertexBuffer( mGame.GraphicsDevice, VertexMultiTextured.SizeInBytes * mPatchVertices.Length, BufferUsage.WriteOnly );
			mVertexBuffer.SetData( mPatchVertices );

			mIndexBuffer = new IndexBuffer( mGame.GraphicsDevice, sizeof( int ) * mPatchIndices.Length, BufferUsage.WriteOnly, IndexElementSize.SixteenBits );
			mIndexBuffer.SetData( mPatchIndices );

			mTerrainVertexDeclaration = new VertexDeclaration( mGame.GraphicsDevice, VertexMultiTextured.VertexElements );

			// Apply the world matrix transformation to the bounding box.
			mBoundingBox.Min = Vector3.Transform( mBoundingBox.Min, worldMatrix );
			mBoundingBox.Max = Vector3.Transform( mBoundingBox.Max, worldMatrix );
		}

		private void BuildBoundingBox( IHeightMap heightmap ) {
			float height = 0f;

			for( int z = mOffsetZ; z < mOffsetZ + mLength; z++ ) {
				for( int x = mOffsetX; x < mOffsetX + mWidth; x++ ) {
					height = heightmap[ x, z ];

					mBoundingBox.Min.Y = Math.Min( height, mBoundingBox.Min.Y );
					mBoundingBox.Max.Y = Math.Max( height, mBoundingBox.Max.Y );
				}
			}
		}

		/// <summary>
		/// Build the vertex buffer as well as the bounding box.
		/// </summary>
		/// <param name="heightmap"></param>
		private void BuildVertexBuffer( IHeightMap heightmap ) {
			int index = 0;
			float height = 0f;

			mPatchVertices = new VertexMultiTextured[ mWidth * mLength ];

			for( int x = mOffsetX; x < mOffsetX + mWidth; x++ ) {
				for( int y = mOffsetZ; y < mOffsetZ + mLength; y++, index++ ) {
					height = heightmap[ x, y ];

					mBoundingBox.Min.Y = Math.Min( height, mBoundingBox.Min.Y );
					mBoundingBox.Max.Y = Math.Max( height, mBoundingBox.Max.Y );

					//ComputeVertexNormal( heightmap, x, y, out normal );

					mPatchVertices[ index ].Position = new Vector3( (float)x, heightmap[ x, y ], (float)-y );
					mPatchVertices[ index ].TextureCoordinate.X = (float)x / 30.0f;
					mPatchVertices[ index ].TextureCoordinate.Y = (float)y / 30.0f;
				}
			}
		}

		/// <summary>
		/// Build the index buffer.
		/// </summary>
		private void BuildIndexBuffer( IHeightMap mHeightMap ) {

			mPatchIndices = new int[ ( mWidth - 1 ) * ( mLength - 1 ) * 6 ];
			int counter = 0;
			for( int x = 0; x < mWidth - 1; x++ ) {
				for( int y = 0; y < mLength - 1; y++ ) {
					int lowerLeft = x + y * mWidth;
					int lowerRight = ( x + 1 ) + y * mWidth;
					int topLeft = x + ( y + 1 ) * mWidth;
					int topRight = ( x + 1 ) + ( y + 1 ) * mWidth;

					mPatchIndices[ counter++ ] = topLeft;
					mPatchIndices[ counter++ ] = lowerRight;
					mPatchIndices[ counter++ ] = lowerLeft;

					mPatchIndices[ counter++ ] = topLeft;
					mPatchIndices[ counter++ ] = topRight;
					mPatchIndices[ counter++ ] = lowerRight;
				}
			}
		}

		private void BuildNormals() {
			// Calculate Normals
			for( int i = 0; i < mPatchVertices.Length; i++ )
				mPatchVertices[ i ].Normal = new Vector3( 0, 1, 2 );

			for( int i = 0; i < mPatchIndices.Length / 3; i++ ) {
				int index1 = mPatchIndices[ i * 3 ];
				int index2 = mPatchIndices[ i * 3 + 1 ];
				int index3 = mPatchIndices[ i * 3 + 2 ];

				Vector3 side1 = mPatchVertices[ index2 ].Position - mPatchVertices[ index1 ].Position;
				Vector3 side2 = mPatchVertices[ index2 ].Position - mPatchVertices[ index3 ].Position;
				Vector3 normal = Vector3.Cross( side1, side2 );

				mPatchVertices[ index1 ].Normal += normal;
				mPatchVertices[ index2 ].Normal += normal;
				mPatchVertices[ index3 ].Normal += normal;
			}

			for( int i = 0; i < mPatchVertices.Length; i++ )
				mPatchVertices[ i ].Normal.Normalize();

		}

		private void BuildTerrainTexWeights( IHeightMap mHeightMap ) {
			int index = 0;

			for( int x = 0; x < mWidth; x++ ) {
				for( int y = 0; y < mLength; y++ ) {
					index = x + y * mWidth;

					if( mPatchVertices[ index ].Normal.Y > 0.6f ) {
						mPatchVertices[ index ].TexWeights.X = GetTexWeight( mHeightMap, x, y, 0f, 8f );
						mPatchVertices[ index ].TexWeights.Y = GetTexWeight( mHeightMap, x, y, 12f, 6f );
						mPatchVertices[ index ].TexWeights.Z = 1.0f - mPatchVertices[ index ].Normal.Y;
						mPatchVertices[ index ].TexWeights.W = GetTexWeight( mHeightMap, x, y, 30f, 6f );
					} else {
						mPatchVertices[ index ].TexWeights.Z = 1.0f;
						mPatchVertices[ index ].TexWeights.W = GetTexWeight( mHeightMap, x, y, 30f, 6f );
					}
					// normalise fuzzy weights -- to sum up to one
					float total = mPatchVertices[ index ].TexWeights.X + mPatchVertices[ index ].TexWeights.Y + mPatchVertices[ index ].TexWeights.Z + mPatchVertices[ index ].TexWeights.W;

					mPatchVertices[ index ].TexWeights.X /= total;
					mPatchVertices[ index ].TexWeights.Y /= total;
					mPatchVertices[ index ].TexWeights.Z /= total;
					mPatchVertices[ index ].TexWeights.W /= total;

				}
			}
		}

		/// <summary>
		/// Compute vertex normal at the given x,z coordinate.
		/// </summary>
		/// <param name="heightmap"></param>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <param name="normal"></param>
		private void ComputeVertexNormal( IHeightMap heightmap, int x, int z, out Vector3 normal ) {
			int width = heightmap.Width;
			int depth = heightmap.Length;

			Vector3 center;
			Vector3 p1;
			Vector3 p2;
			Vector3 avgNormal = Vector3.Zero;

			int avgCount = 0;

			bool spaceAbove = false;
			bool spaceBelow = false;
			bool spaceLeft = false;
			bool spaceRight = false;

			Vector3 tmpNormal;
			Vector3 v1;
			Vector3 v2;

			center = new Vector3( (float)x, heightmap[ x, z ], (float)z );

			if( x > 0 )
				spaceLeft = true;

			if( x < width - 1 )
				spaceRight = true;

			if( z > 0 )
				spaceAbove = true;

			if( z < depth - 1 )
				spaceBelow = true;

			if( spaceAbove && spaceLeft ) {
				p1 = new Vector3( x - 1, heightmap[ x - 1, z ], z );
				p2 = new Vector3( x - 1, heightmap[ x - 1, z - 1 ], z - 1 );

				v1 = p1 - center;
				v2 = p2 - p1;

				tmpNormal = Vector3.Cross( v1, v2 );
				avgNormal += tmpNormal;

				++avgCount;
			}

			if( spaceAbove && spaceRight ) {
				p1 = new Vector3( x, heightmap[ x, z - 1 ], z - 1 );
				p2 = new Vector3( x + 1, heightmap[ x + 1, z - 1 ], z - 1 );

				v1 = p1 - center;
				v2 = p2 - p1;

				tmpNormal = Vector3.Cross( v1, v2 );
				avgNormal += tmpNormal;

				++avgCount;
			}

			if( spaceBelow && spaceRight ) {
				p1 = new Vector3( x + 1, heightmap[ x + 1, z ], z );
				p2 = new Vector3( x + 1, heightmap[ x + 1, z + 1 ], z + 1 );

				v1 = p1 - center;
				v2 = p2 - p1;

				tmpNormal = Vector3.Cross( v1, v2 );
				avgNormal += tmpNormal;

				++avgCount;
			}

			if( spaceBelow && spaceLeft ) {
				p1 = new Vector3( x, heightmap[ x, z + 1 ], z + 1 );
				p2 = new Vector3( x - 1, heightmap[ x - 1, z + 1 ], z + 1 );

				v1 = p1 - center;
				v2 = p2 - p1;

				tmpNormal = Vector3.Cross( v1, v2 );
				avgNormal += tmpNormal;

				++avgCount;
			}

			normal = avgNormal / avgCount;
		}

		private float GetTexWeight( IHeightMap heightMap, int x, int y, float i, float j ) {
			return MathHelper.Clamp( 1.0f - Math.Abs( heightMap[ x, y ] - i ) / j, 0.0f, 1.0f );
		}

	}

}
