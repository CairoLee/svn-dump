using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace GLibary {
	public partial class Utility {
		public class VertexMeta {
			public short Stream = 0;
			public short Offset = 0;
			public VertexElementFormat Format;
			public VertexElementMethod Method = VertexElementMethod.Default;
			public VertexElementUsage Usage;
			public byte UsageIndex = 0;


			public VertexMeta( VertexElementFormat format,
							  VertexElementUsage usage ) {
				this.Format = format;
				this.Usage = usage;
			}

			public VertexMeta( VertexElementFormat format,
							  VertexElementUsage usage,
							  byte usageIndex ) {
				this.Format = format;
				this.Usage = usage;
				this.UsageIndex = usageIndex;
			}

			public VertexMeta( short stream,
							  VertexElementFormat format,
							  VertexElementUsage usage ) {
				this.Stream = stream;
				this.Format = format;
				this.Usage = usage;
			}

			public VertexMeta( short stream,
							  VertexElementFormat format,
							  VertexElementUsage usage,
							  byte usageIndex ) {
				this.Stream = stream;
				this.Format = format;
				this.Usage = usage;
				this.UsageIndex = usageIndex;
			}

			///
			public VertexMeta( VertexElementFormat format,
							  VertexElementUsage usage,
							  VertexElementMethod method ) {
				this.Format = format;
				this.Usage = usage;
				this.Method = method;
			}

			public VertexMeta( VertexElementFormat format,
							  VertexElementUsage usage,
							  VertexElementMethod method,
							  byte usageIndex ) {
				this.Format = format;
				this.Usage = usage;
				this.UsageIndex = usageIndex;
				this.Method = method;
			}

			public VertexMeta( short stream,
							  VertexElementFormat format,
							  VertexElementUsage usage,
							  VertexElementMethod method ) {
				this.Stream = stream;
				this.Format = format;
				this.Usage = usage;
				this.Method = method;
			}

			public VertexMeta( short stream,
							  VertexElementFormat format,
							  VertexElementUsage usage,
							  VertexElementMethod method,
							  byte usageIndex ) {
				this.Stream = stream;
				this.Format = format;
				this.Usage = usage;
				this.UsageIndex = usageIndex;
				this.Method = method;
			}
		}



		public static VertexElement[] CreateVertexElems(
										params VertexMeta[] elementList ) {
			VertexElement[] elems = new VertexElement[ elementList.Length ];
			int byteOffset = 0;
			int startStream = elementList[ 0 ].Stream;

			for( int x = 0; x < elementList.Length; x++ ) {
				VertexMeta meta = elementList[ x ];
				if( meta.Stream != startStream ) {
					startStream = meta.Stream;
					byteOffset = 0;
				}
				elems[ x ].VertexElementFormat = meta.Format;
				elems[ x ].VertexElementUsage = meta.Usage;
				elems[ x ].Stream = meta.Stream;
				elems[ x ].UsageIndex = meta.UsageIndex;
				elems[ x ].VertexElementMethod = meta.Method;
				elems[ x ].Offset = (short)byteOffset;

				byteOffset += VertexDeclaration.GetVertexStrideSize(
													elems, meta.Stream );
			}
			return elems;
		}
	}
	public static partial class Utility {



		public static int GetActiveVertexStrideSize( this GraphicsDevice GraphicsDevice ) {
			return GraphicsDevice.VertexDeclaration.GetVertexStrideSize( 0 );
		}

		public static VertexDeclaration CreateDeclaration(
			this GraphicsDevice GraphicsDevice,
			params VertexMeta[] elementList ) {
			return new VertexDeclaration( GraphicsDevice,
										 CreateVertexElems( elementList ) );
		}

		public static VertexDeclaration CreateDeclaration( this GraphicsDevice GraphicsDevice,
			VertexElement[] elems ) {
			return new VertexDeclaration( GraphicsDevice, elems );
		}

		//returns the size in bytes of the vertex element given its index
		public static short GetVertexElementOffset( this VertexDeclaration decl,
												   VertexElementUsage usage ) {
			short retVal = -1;
			foreach( VertexElement elem in decl.GetVertexElements() ) {
				if( elem.VertexElementUsage == usage ) {
					retVal = elem.Offset;
				}
			}
			return retVal;
		}

		public static short GetVertexElementOffset( this VertexDeclaration decl,
												   VertexElementUsage usage,
												   int usageIndex ) {
			short retVal = -1;
			foreach( VertexElement elem in decl.GetVertexElements() ) {
				if( elem.VertexElementUsage == usage &&
					elem.UsageIndex == usageIndex ) {
					retVal = elem.Offset;
				}
			}
			return retVal;
		}

		//returns the size in bytes of the vertex element given its index
		public static int GetVertexElementSize( this VertexDeclaration decl,
											   int elementIndex ) {
			int elemSize = 0;

			VertexElement[] elems = decl.GetVertexElements();

			if( elems.Length > elementIndex ) {
				VertexElement e = elems[ elementIndex ];

				//get the next element if there is one
				int iNextElem = -1;
				if( elems.Length > elementIndex + 1 ) {
					VertexElement tmp = elems[ elementIndex + 1 ];

					if( tmp.Stream == e.Stream ) {
						iNextElem = elementIndex + 1;
					}
				}

				if( iNextElem != -1 ) {
					elemSize = elems[ iNextElem ].Offset - e.Offset;
				} else {
					elemSize =
					   decl.GetVertexStrideSize( e.Stream ) - e.Offset;
				}
			}

			return elemSize;
		}



		public static bool IsPositionDecl( this VertexDeclaration decl ) {
			return ( decl.GetVertexElements()[ 0 ].Stream == 0 &&
					decl.GetVertexElements()[ 0 ].VertexElementUsage ==
					VertexElementUsage.Position );
		}

		public static bool IsNormalDecl( this VertexDeclaration decl ) {
			return ( decl.GetVertexElements()[ 0 ].Stream == 0 &&
					decl.GetVertexElements()[ 0 ].VertexElementUsage ==
					VertexElementUsage.Normal );
		}




		public unsafe static Vector3[] GetFlattenedPositionArray( this Model model ) {
			Matrix[] bones = model.GetAboluteBoneTransforms();

			int numModelVerts = model.VertexCount();
			Vector3[] Vertices = new Vector3[ numModelVerts ];

			int modelVertexIndex = 0;
			foreach( ModelMesh mesh in model.Meshes ) {
				int numMeshVertices = mesh.VertexCount();

				byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
				mesh.VertexBuffer.GetData<byte>( vb );

				int meshVertIndex = 0;

				fixed( byte* pBits = vb ) {
					foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
						VertexDeclaration decl = meshPart.VertexDeclaration;

						if( IsPositionDecl( decl ) ) {
							int strideSize = decl.GetVertexStrideSize( 0 );

							for( int x = 0; x < meshPart.NumVertices; x++ ) {
								Vector3 vec = *( (Vector3*)( pBits + x * strideSize ) );

								Vertices[ modelVertexIndex + meshVertIndex ] = vec;

								meshVertIndex++;
							}
						}
					}
				}

				Matrix worldBone = bones[ mesh.ParentBone.Index ];

				Vector3.Transform( Vertices,
								  modelVertexIndex,
								  ref worldBone,
								  Vertices,
								  modelVertexIndex,
								  numMeshVertices );

				modelVertexIndex += numMeshVertices;
			}
			return Vertices;
		}


		public unsafe static Vector3[] GetFlattenedPositionArray(
											this ModelMesh mesh, Matrix worldTrans ) {
			int numModelVerts = mesh.VertexCount();
			Vector3[] Vertices = new Vector3[ numModelVerts ];


			int numMeshVertices = mesh.VertexCount();

			byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
			mesh.VertexBuffer.GetData<byte>( vb );

			int meshVertIndex = 0;

			fixed( byte* pBits = vb ) {
				foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
					VertexDeclaration decl = meshPart.VertexDeclaration;

					if( IsPositionDecl( decl ) ) {
						int strideSize = decl.GetVertexStrideSize( 0 );

						for( int x = 0; x < meshPart.NumVertices; x++ ) {
							Vector3 vec = *( (Vector3*)( pBits + x * strideSize ) );

							Vertices[ meshVertIndex ] = vec;

							meshVertIndex++;
						}
					}
				}
			}

			Vector3.Transform( Vertices,
							  0,
							  ref worldTrans,
							  Vertices,
							  0,
							  numMeshVertices );

			return Vertices;
		}

		public unsafe static Vector2[] GetTexCoordArray( this Model model, int texIndex ) {
			int numModelVerts = model.VertexCount();
			Vector2[] Coords = new Vector2[ numModelVerts ];

			int modelVertexIndex = 0;
			foreach( ModelMesh mesh in model.Meshes ) {
				int numMeshVertices = mesh.VertexCount();

				byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
				mesh.VertexBuffer.GetData<byte>( vb );

				int meshVertIndex = 0;

				fixed( byte* pBits = vb ) {
					foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
						VertexDeclaration decl = meshPart.VertexDeclaration;

						int iOffset = Utility.GetVertexElementOffset(
										decl,
										VertexElementUsage.TextureCoordinate,
										texIndex );

						if( iOffset != -1 ) {
							int strideSize = decl.GetVertexStrideSize( 0 );

							for( int x = 0; x < meshPart.NumVertices; x++ ) {
								Vector2 vec =
									*( (Vector2*)( pBits + x * strideSize + iOffset ) );

								Coords[ modelVertexIndex + meshVertIndex ] = vec;

								meshVertIndex++;
							}
						}
					}
				}

				modelVertexIndex += numMeshVertices;
			}
			return Coords;
		}

		public unsafe static Color[] GetColorArray( this Model model, int colorIndex ) {
			int numModelVerts = model.VertexCount();
			Color[] Colors = new Color[ numModelVerts ];

			int modelVertexIndex = 0;
			foreach( ModelMesh mesh in model.Meshes ) {
				int numMeshVertices = mesh.VertexCount();

				byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
				mesh.VertexBuffer.GetData<byte>( vb );

				int meshVertIndex = 0;

				fixed( byte* pBits = vb ) {
					foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
						VertexDeclaration decl = meshPart.VertexDeclaration;

						int iOffset = Utility.GetVertexElementOffset(
								decl, VertexElementUsage.Color, colorIndex );

						if( iOffset != -1 ) {
							int strideSize = decl.GetVertexStrideSize( 0 );

							for( int x = 0; x < meshPart.NumVertices; x++ ) {
								Color vec =
									*(Color*)( (Int32*)( pBits + x * strideSize + iOffset ) );

								Colors[ modelVertexIndex + meshVertIndex ] = vec;

								meshVertIndex++;
							}
						}
					}
				}

				modelVertexIndex += numMeshVertices;
			}
			return Colors;
		}
		public unsafe static Color[] GetColorArray( this ModelMesh mesh, int colorIndex ) {

			int numMeshVertices = mesh.VertexCount();
			Color[] Colors = new Color[ numMeshVertices ];

			byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
			mesh.VertexBuffer.GetData<byte>( vb );

			int meshVertIndex = 0;

			fixed( byte* pBits = vb ) {
				foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
					VertexDeclaration decl = meshPart.VertexDeclaration;

					int iOffset = Utility.GetVertexElementOffset(
						decl, VertexElementUsage.Color, colorIndex );

					if( iOffset != -1 ) {
						int strideSize = decl.GetVertexStrideSize( 0 );

						for( int x = 0; x < meshPart.NumVertices; x++ ) {
							Color vec =
								*(Color*)( (Int32*)( pBits + x * strideSize + iOffset ) );

							Colors[ meshVertIndex ] = vec;

							meshVertIndex++;
						}
					}
				}
			}

			return Colors;
		}
		public unsafe static Color[] GetColorArray( this ModelMesh mesh,
												   int colorIndex,
												   Color defaultColor ) {

			int numMeshVertices = mesh.VertexCount();
			Color[] Colors = new Color[ numMeshVertices ];

			byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
			mesh.VertexBuffer.GetData<byte>( vb );

			int meshVertIndex = 0;

			fixed( byte* pBits = vb ) {
				foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
					VertexDeclaration decl = meshPart.VertexDeclaration;

					int iOffset = Utility.GetVertexElementOffset(
							decl, VertexElementUsage.Color, colorIndex );

					if( iOffset != -1 ) {
						int strideSize = decl.GetVertexStrideSize( 0 );

						for( int x = 0; x < meshPart.NumVertices; x++ ) {
							Color vec =
								*(Color*)( (Int32*)( pBits + x * strideSize + iOffset ) );

							Colors[ meshVertIndex ] = vec;

							meshVertIndex++;
						}
					} else {
						for( int x = 0; x < meshPart.NumVertices; x++ ) {
							Colors[ meshVertIndex ] = defaultColor;
							meshVertIndex++;
						}
					}
				}
			}

			return Colors;
		}

		public unsafe static Vector2[] GetTexCoordArray( this ModelMesh mesh, int texIndex ) {
			int numMeshVertices = mesh.VertexCount();

			byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
			mesh.VertexBuffer.GetData<byte>( vb );
			Vector2[] Coords = new Vector2[ numMeshVertices ];
			int meshVertIndex = 0;

			fixed( byte* pBits = vb ) {
				foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
					VertexDeclaration decl = meshPart.VertexDeclaration;

					int iOffset = Utility.GetVertexElementOffset(
							decl, VertexElementUsage.TextureCoordinate, texIndex );

					if( iOffset != -1 ) {
						int strideSize = decl.GetVertexStrideSize( 0 );

						for( int x = 0; x < meshPart.NumVertices; x++ ) {
							Vector2 vec =
								*( (Vector2*)( pBits + x * strideSize + iOffset ) );

							Coords[ meshVertIndex ] = vec;

							meshVertIndex++;
						}
					}
				}
			}

			return Coords;
		}

		public unsafe static Vector3[] GetFlattenedNormalArray( this Model model ) {
			Matrix[] bones = model.GetAboluteBoneTransforms();

			int numModelVerts = model.VertexCount();
			Vector3[] Normals = new Vector3[ numModelVerts ];

			int modelVertexIndex = 0;
			foreach( ModelMesh mesh in model.Meshes ) {
				int numMeshVertices = mesh.VertexCount();

				byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
				mesh.VertexBuffer.GetData<byte>( vb );

				int meshVertIndex = 0;

				fixed( byte* pBits = vb ) {
					foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
						VertexDeclaration decl = meshPart.VertexDeclaration;

						int normalOffset =
								GetVertexElementOffset( decl,
										VertexElementUsage.Normal );

						if( normalOffset != -1 ) {
							int strideSize = decl.GetVertexStrideSize( 0 );

							for( int x = 0; x < meshPart.NumVertices; x++ ) {
								Vector3 vec =
										*( (Vector3*)( pBits +
													 x * strideSize +
													 normalOffset ) );

								Normals[ modelVertexIndex + meshVertIndex ] = vec;

								meshVertIndex++;
							}
						}
					}
				}

				Matrix worldBone = bones[ mesh.ParentBone.Index ];

				Vector3 scale;
				Quaternion rot;
				Vector3 trans;
				worldBone.Decompose( out scale, out rot, out trans );

				Matrix mat = Matrix.CreateFromQuaternion( rot );

				Vector3.Transform( Normals,
								  modelVertexIndex,
								  ref mat,
								  Normals,
								  modelVertexIndex,
								  numMeshVertices );

				modelVertexIndex += numMeshVertices;
			}
			return Normals;
		}


		public unsafe static Vector3[] GetFlattenedNormalArray( this ModelMesh mesh,
															   Matrix worldTrans ) {
			int numModelVerts = mesh.VertexCount();
			Vector3[] Normals = new Vector3[ numModelVerts ];


			int numMeshVertices = mesh.VertexCount();

			byte[] vb = new byte[ mesh.VertexBuffer.SizeInBytes ];
			mesh.VertexBuffer.GetData<byte>( vb );

			int meshVertIndex = 0;

			fixed( byte* pBits = vb ) {
				foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
					VertexDeclaration decl = meshPart.VertexDeclaration;

					int normalOffset =
							GetVertexElementOffset( decl,
									VertexElementUsage.Normal );

					if( normalOffset != -1 ) {
						int strideSize = decl.GetVertexStrideSize( 0 );

						for( int x = 0; x < meshPart.NumVertices; x++ ) {
							Vector3 vec =
									*( (Vector3*)( pBits +
												 x * strideSize +
												 normalOffset ) );

							Normals[ meshVertIndex ] = vec;

							meshVertIndex++;
						}
					}
				}
			}


			Vector3 scale;
			Quaternion rot;
			Vector3 trans;
			worldTrans.Decompose( out scale, out rot, out trans );

			Matrix mat = Matrix.CreateFromQuaternion( rot );

			Vector3.Transform( Normals,
							  0,
							  ref mat,
							  Normals,
							  0,
							  numMeshVertices );


			return Normals;
		}


		public static unsafe int[] GetFlattenedIndexArray( this Model model ) {
			int numModelIndices = model.IndexCount();
			int[] Indices = new int[ numModelIndices ];
			int modelIndiceIndex = 0;
			int indexOffset = 0;


			foreach( ModelMesh mesh in model.Meshes ) {
				int indexElementSize = mesh.IndexBuffer.GetIndexBufferElementSize();

				int numModelMeshIndices = mesh.IndexCount();

				byte[] indices = new byte[ numModelMeshIndices * indexElementSize ];

				mesh.IndexBuffer.GetData<byte>( indices );

				foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
					int numIndicesInMeshPart = meshPart.PrimitiveCount * 3;

					fixed( byte* pIndices = indices ) {
						for( int x = 0; x < numIndicesInMeshPart; x++ ) {
							int indexVal = 0;
							if( indexElementSize == 2 ) {
								indexVal =
									(int)*(short*)( pIndices +
										( x + meshPart.StartIndex ) * indexElementSize );

							} else {
								indexVal = *(int*)( pIndices +
										( x + meshPart.StartIndex ) * indexElementSize );
							}
							Indices[ modelIndiceIndex + x ] = indexVal + indexOffset;
						}
					}


					indexOffset += meshPart.NumVertices;
					modelIndiceIndex += numIndicesInMeshPart;
				}
			}
			return Indices;
		}


		public static unsafe int[] GetFlattenedIndexArray( this ModelMesh mesh ) {
			int numModelIndices = mesh.IndexCount();
			int[] Indices = new int[ numModelIndices ];
			int modelIndiceIndex = 0;
			int indexOffset = 0;

			int indexElementSize = mesh.IndexBuffer.GetIndexBufferElementSize();

			int numModelMeshIndices = mesh.IndexCount();

			byte[] indices = new byte[ numModelMeshIndices * indexElementSize ];

			mesh.IndexBuffer.GetData<byte>( indices );

			foreach( ModelMeshPart meshPart in mesh.MeshParts ) {
				int numIndicesInMeshPart = meshPart.PrimitiveCount * 3;

				fixed( byte* pIndices = indices ) {
					for( int x = 0; x < numIndicesInMeshPart; x++ ) {
						int indexVal = 0;
						if( indexElementSize == 2 ) {
							indexVal =
								(int)*(short*)( pIndices +
									( x + meshPart.StartIndex ) * indexElementSize );

						} else {
							indexVal = *(int*)( pIndices +
									( x + meshPart.StartIndex ) * indexElementSize );
						}
						Indices[ modelIndiceIndex + x ] = indexVal + indexOffset;
					}
				}


				indexOffset += meshPart.NumVertices;
				modelIndiceIndex += numIndicesInMeshPart;
			}

			return Indices;
		}


	}
}
