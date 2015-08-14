using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Shaiya_Model_Viewer.Library {

	public class Format3DC {
		private string mFilename;

		private int mConstant00;
		private List<Matrix> mBones;
		private List<Vertice> mVertices;
		private List<Face> mFaces;

		private bool mInitialized = false;
		private BasicEffect mEffect;
		private List<VertexPositionTexture> mVertexPositionTextureList;


		public string Filename {
			get { return mFilename; }
		}

		public int Constant00 {
			get { return mConstant00; }
		}

		public List<Matrix> Bones {
			get { return mBones; }
		}

		public List<Vertice> Vertices {
			get { return mVertices; }
		}

		public List<Face> Faces {
			get { return mFaces; }
		}



		public Format3DC() {
		}

		public Format3DC( string Filename ) {
			mFilename = Filename;
		}



		public void Read() {

			using( FileStream fs = File.OpenRead( mFilename ) ) {
				using( BinaryReader bin = new BinaryReader( fs ) ) {

					mConstant00 = bin.ReadInt32();
					int bCount = bin.ReadInt32();
					mBones = new List<Matrix>();
					for( int i = 0; i < bCount; i++ ) {
						mBones.Add( bin.ReadMatrix() );
					}

					int vCount = bin.ReadInt32();
					mVertices = new List<Vertice>();
					for( int i = 0; i < vCount; i++ ) {
						mVertices.Add( bin.ReadVertice() );
					}

					int fCount = bin.ReadInt32();
					mFaces = new List<Face>();
					for( int i = 0; i < fCount; i++ ) {
						mFaces.Add( bin.ReadFace() );
					}


				}
			}

		}

		public void Draw( GraphicsDevice GraphicsDevice, Matrix GameWorldRotation, Vector3 Position, float Zoom ) {
			InitializeDraw( GraphicsDevice );

			GraphicsDevice.VertexDeclaration = new VertexDeclaration( GraphicsDevice, VertexPositionColor.VertexElements );
			
			mEffect.World = GameWorldRotation * Matrix.CreateTranslation( Position );
			mEffect.View = Matrix.CreateLookAt( new Vector3( 0, 0, Zoom ), new Vector3( 0, 0, -1 ), Vector3.Up );
			mEffect.Projection = Matrix.CreatePerspectiveFieldOfView( MathHelper.ToRadians( 45.0f ), GraphicsDevice.Viewport.AspectRatio, 1f, 10000f );

			mEffect.Begin();
			foreach( EffectPass pass in mEffect.CurrentTechnique.Passes ) {
				pass.Begin();
				GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>( PrimitiveType.TriangleList, mVertexPositionTextureList.ToArray(), 0, mVertexPositionTextureList.Count / 3 );
				pass.End();
			}
			mEffect.End();
		}

		private void InitializeDraw( GraphicsDevice GraphicsDevice ) {
			if( mInitialized == true )
				return;

			mInitialized = true;
			mVertexPositionTextureList = new List<VertexPositionTexture>();
			for( int i = 0; i < Vertices.Count; i++ ) 
				mVertexPositionTextureList.Add( new VertexPositionTexture( Vertices[ i ].CoordXYZ, Vector2.Zero ) );

			mEffect = new BasicEffect( GraphicsDevice, null );
			mEffect.VertexColorEnabled = true;
		}

	}

}
