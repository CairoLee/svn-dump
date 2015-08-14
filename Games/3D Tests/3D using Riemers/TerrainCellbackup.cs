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

	public class TerrainCell_Backup {
		private Game mGame;
		private BoundingBox mBoundingBox;

		private VertexPositionNormalTexture[] mVertexPosition;
		private VertexBuffer mVertexBuffer;
		private IndexBuffer mIndexBuffer;
		private short[] mIndices;

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
		public TerrainCell_Backup( Game g ) {
			mBoundingBox = new BoundingBox();
			mGame = g;
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

			//BuildVertexBuffer( heightmap );
			/*
			mVertexBuffer = new VertexBuffer( mGame.GraphicsDevice, VertexPositionNormalTexture.SizeInBytes * mVertexPosition.Length, BufferUsage.WriteOnly );
			mVertexBuffer.SetData<VertexPositionNormalTexture>( mVertexPosition );

			BuildIndexBuffer();

			mIndexBuffer = new IndexBuffer( mGame.GraphicsDevice, sizeof( short ) * mIndices.Length, BufferUsage.WriteOnly, IndexElementSize.SixteenBits );
			mIndexBuffer.SetData<short>( mIndices );
			*/
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

			Vector3 position, normal;

			mVertexPosition = new VertexPositionNormalTexture[ mWidth * mLength ];

			for( int z = mOffsetZ; z < mOffsetZ + mLength; z++ ) {
				for( int x = mOffsetX; x < mOffsetX + mWidth; x++, index++ ) {
					height = heightmap[ x, z ];
					position = new Vector3( (float)x, height, (float)z );

					mBoundingBox.Min.Y = Math.Min( height, mBoundingBox.Min.Y );
					mBoundingBox.Max.Y = Math.Max( height, mBoundingBox.Max.Y );

					ComputeVertexNormal( heightmap, x, z, out normal );

					mVertexPosition[ index ] = new VertexPositionNormalTexture( position, normal, new Vector2( x, z ) );
				}
			}
		}

		/// <summary>
		/// Build the index buffer.
		/// </summary>
		private void BuildIndexBuffer() {
			int stripLength = 4 + ( mLength - 2 ) * 2;
			int stripCount = mWidth - 1;

			mIndices = new short[ stripLength * stripCount ];

			int index = 0;

			for( int s = 0; s < stripCount; ++s ) {
				for( int z = 0; z < mLength; ++z ) {
					mIndices[ index++ ] = (short)( s + mLength * z );
					mIndices[ index++ ] = (short)( s + mLength * z + 1 );
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

		/// <summary>
		/// Draw the terrain patch.
		/// </summary>
		public void Draw() {
			int primitivePerStrip = ( mLength - 1 ) * 2;
			int stripCount = mWidth - 1;
			int vertexPerStrip = mLength * 2;

			for( int s = 0; s < stripCount; ++s ) {
				mGame.GraphicsDevice.Vertices[ 0 ].SetSource( mVertexBuffer, 0, VertexPositionNormalTexture.SizeInBytes );
				mGame.GraphicsDevice.Indices = mIndexBuffer;
				mGame.GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleStrip, 0, 0, mVertexPosition.Length, vertexPerStrip * s, primitivePerStrip );
			}

		}
	}

}
