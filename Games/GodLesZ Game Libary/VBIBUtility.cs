using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace GLibary {
	public static class GraphicsExtensions {
		public static VertexBuffer CreateVB<TVert>( this GraphicsDevice GraphicsDevice,
			int numVertices ) {
			return new VertexBuffer( GraphicsDevice,
				typeof( TVert ), numVertices,
				BufferUsage.None );
		}

		public static VertexBuffer CreateVB<TVert>( this GraphicsDevice GraphicsDevice,
												   int numVertices,
												   BufferUsage usage ) {
			return new VertexBuffer( GraphicsDevice,
				typeof( TVert ), numVertices,
				usage );
		}



		public static IndexBuffer CreateIB<T>( this GraphicsDevice GraphicsDevice, int numIndices ) {
			return new IndexBuffer( GraphicsDevice,
				typeof( T ), numIndices, BufferUsage.None );
		}

		public static IndexBuffer CreateIB<T>( this GraphicsDevice GraphicsDevice, int numIndices,
											  BufferUsage usage ) {
			return new IndexBuffer( GraphicsDevice,
				typeof( T ), numIndices, usage );
		}



		public static int VertexCount( this VertexBuffer vb,
											   int vertexStride ) {
			return vb.SizeInBytes / vertexStride;
		}

		public static int GetVertexBufferCount( this VertexBuffer vb ) {
			return vb.SizeInBytes / Utility.GraphicsDevice.GetActiveVertexStrideSize();
		}

		public static int GetIndexBufferPrimitiveCount( this IndexBuffer ib ) {
			return ib.SizeInBytes / GetIndexBufferElementSize( ib );
		}



		public static void SetVertexBuffer( this VertexBuffer vb,
										   int vertexStride,
										   int vertexStream,
										   int offsetInBytes ) {
			Utility.GraphicsDevice.Vertices[ vertexStream ].SetSource(
								vb,
								offsetInBytes,
								vertexStride );
		}

		public static void SetVertexBuffer( this VertexBuffer vb,
										   int vertexStride,
										   int vertexStream ) {
			Utility.GraphicsDevice.Vertices[ vertexStream ].SetSource(
										vb, 0, vertexStride );
		}

		public static void SetVertexBuffer( this VertexBuffer vb,
										   int vertexStride ) {
			Utility.GraphicsDevice.Vertices[ 0 ].SetSource( vb, 0, vertexStride );
		}

		public static void SetVertexBufferStream( this VertexBuffer vb,
												 int vertexStream ) {
			Utility.GraphicsDevice.Vertices[ vertexStream ].SetSource(
				vb,
				0,
				Utility.GraphicsDevice.GetActiveVertexStrideSize() );
		}

		public static void SetVertexBuffer( VertexBuffer vb,
										   VertexDeclaration decl ) {
			Utility.GraphicsDevice.VertexDeclaration = decl;
			Utility.GraphicsDevice.Vertices[ 0 ].SetSource(
						vb, 0, decl.GetVertexStrideSize( 0 ) );
		}

		public static void SetVertexBuffer( VertexBuffer vb,
										   int vertexStream,
										   VertexDeclaration decl ) {
			Utility.GraphicsDevice.VertexDeclaration = decl;
			Utility.GraphicsDevice.Vertices[ vertexStream ].SetSource(
				vb,
				0,
				decl.GetVertexStrideSize( 0 ) );
		}



		public static void SetVertexBuffer( this GraphicsDevice GraphicsDevice,
			VertexBuffer vb ) {
			GraphicsDevice.Vertices[ 0 ].SetSource(
						vb, 0, GraphicsDevice.GetActiveVertexStrideSize() );
		}

		public static void SetVertexBuffer( this GraphicsDevice GraphicsDevice,
										   VertexBuffer vb,
										   VertexDeclaration decl,
										   IndexBuffer ib ) {
			SetVertexBuffer( vb, decl );
			GraphicsDevice.Indices = ib;
		}

		public static void SetIndexBuffer( this GraphicsDevice GraphicsDevice, IndexBuffer ib ) {
			GraphicsDevice.Indices = ib;
		}

		public static int GetIndexBufferElementSize( this IndexBuffer ib ) {
			return ( ib.IndexElementSize ==
							IndexElementSize.SixteenBits ? 2 : 4 );
		}

		public static void ConvertVB( ref VertexBuffer vb,
							  VertexDeclaration fromDecl,
							  VertexDeclaration toDecl ) {
			ConvertVB( vb, fromDecl, 0, toDecl, 0 );
		}

		public static void ConvertVB( ref VertexBuffer vb,
							  VertexDeclaration fromDecl,
							  int fromStreamIndex,
							  VertexDeclaration toDecl,
							  int toStreamIndex ) {
			vb = ConvertVB( vb,
						   fromDecl,
						   fromStreamIndex,
						   toDecl,
						   toStreamIndex );
		}

		public static VertexBuffer ConvertVB( VertexBuffer vb,
							  VertexDeclaration fromDecl,
							  VertexDeclaration toDecl ) {
			return ConvertVB( vb,
							 fromDecl,
							 0,
							 toDecl,
							 0 );
		}

		public static VertexBuffer ConvertVB( VertexBuffer vb,
							  VertexDeclaration fromDecl,
							  int fromStreamIndex,
							  VertexDeclaration toDecl,
							  int toStreamIndex ) {
			byte[] fromData = new byte[ vb.SizeInBytes ];
			vb.GetData<byte>( fromData );

			int fromNumVertices = vb.SizeInBytes /
									fromDecl.GetVertexStrideSize( 0 );

			List<int> vertMap = new List<int>();

			//find mappings
			for( int x = 0; x < fromDecl.GetVertexElements().Length; x++ ) {
				VertexElement thisElem = fromDecl.GetVertexElements()[ x ];

				bool bFound = false;

				int i = 0;
				for( i = 0; i < toDecl.GetVertexElements().Length; i++ ) {
					VertexElement elem = toDecl.GetVertexElements()[ i ];

					if( elem.Stream == toStreamIndex )
						if( thisElem.VertexElementUsage == elem.VertexElementUsage &&
							thisElem.UsageIndex == elem.UsageIndex &&
							thisElem.VertexElementFormat == elem.VertexElementFormat ) {
							bFound = true;
							break;
						}
				}
				if( bFound ) {
					vertMap.Add( i );
				} else {
					vertMap.Add( -1 );
				}
			}


			int newBufferSize = fromNumVertices *
									toDecl.GetVertexStrideSize( toStreamIndex );



			byte[] toData = new byte[ newBufferSize ];

			int toDeclVertexStride = toDecl.GetVertexStrideSize( toStreamIndex );
			int fromDeclVertexStride = fromDecl.GetVertexStrideSize( fromStreamIndex );

			for( int x = 0; x < vertMap.Count; x++ ) {
				int i = vertMap[ x ];

				if( i != -1 ) {
					VertexElement fromElem = fromDecl.GetVertexElements()[ x ];
					VertexElement toElem = toDecl.GetVertexElements()[ i ];

					for( int k = 0; k < fromNumVertices; k++ ) {
						for( int j = 0;
							 j < Utility.GetVertexElementSize( fromDecl, x );
							 j++ ) {
							toData[ k * toDeclVertexStride + toElem.Offset + j ] =
								fromData[ k * fromDeclVertexStride + fromElem.Offset + j ];
						}
					}
				}
			}

			VertexBuffer newVB = new VertexBuffer(
				Utility.GraphicsDevice,
				fromNumVertices * toDecl.GetVertexStrideSize( toStreamIndex ),
				BufferUsage.None ); // in xna 1.0 use vb.ResourceUsage instead

			newVB.SetData<byte>( toData );

			return newVB;
		}
	}

}
