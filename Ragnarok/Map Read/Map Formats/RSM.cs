using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map_Formats {
	public static class Extensions {

		/// <summary>
		/// is the Parent from <see cref="Mesh"/> == MainMesh ?
		/// </summary>
		/// <param name="MainMesh"></param>
		/// <param name="Mesh"></param>
		/// <returns></returns>
		public static bool IsParent( this RSM.Mesh MainMesh, RSM.Mesh Mesh ) {
			return ( MainMesh.Head.Name == Mesh.Head.ParentName );
		}

		public static Vector3 MaxFrom( this Vector3 v, Vector3 v2 ) {
			v.X = Math.Max( v.X, v2.X );
			v.Y = Math.Max( v.Y, v2.Y );
			v.Z = Math.Max( v.Z, v2.Z );

			return v;
		}

		public static Vector3 MinFrom( this Vector3 v, Vector3 v2 ) {
			v.X = Math.Min( v.X, v2.X );
			v.Y = Math.Min( v.Y, v2.Y );
			v.Z = Math.Min( v.Z, v2.Z );

			return v;
		}

		public static Vector3 MultipleMatrix( this Vector3 Vin, Vector4[] Matrix ) {
			Vector3 Vout = Vector3.Zero;

			Vout.X = ( Vin.X * Matrix[ 0 ].X ) + ( Vin.Y * Matrix[ 0 ].Y ) + ( Vin.Z * Matrix[ 0 ].Z ) + ( 1f * Matrix[ 0 ].W );
			Vout.Y = ( Vin.X * Matrix[ 1 ].X ) + ( Vin.Y * Matrix[ 1 ].Y ) + ( Vin.Z * Matrix[ 1 ].Z ) + ( 1f * Matrix[ 1 ].W );
			Vout.X = ( Vin.X * Matrix[ 2 ].X ) + ( Vin.Y * Matrix[ 2 ].Y ) + ( Vin.Z * Matrix[ 2 ].Z ) + ( 1f * Matrix[ 2 ].W );

			return Vout;
		}

		public static void CalcBoundingBox( this RSM.Mesh m, ref BoundingBox box ) {
			Vector4[] Matrix = m.Matrix.Matrix3x3;
			Vector3 vi = Vector3.Zero;
			Vector3 v = Vector3.Zero;

			box.Min.X = box.Min.Y = box.Min.Z = 999999.0f;
			box.Max.X = box.Max.Y = box.Max.Z = -999999.0f;

			for( int i = 0; i < m.MainVectorCount; i++ ) {
				v = m.MainVectors[ i ].MultipleMatrix( Matrix );
				if( m.IsOnly == false ) {
					v.X += m.Matrix.Translate1.X + m.Matrix.Translate2.X;
					v.Y += m.Matrix.Translate1.Y + m.Matrix.Translate2.Y;
					v.Z += m.Matrix.Translate1.Z + m.Matrix.Translate2.Z;

					box.Min = box.Min.MinFrom( v );
					box.Max = box.Max.MaxFrom( v );
				}
			}

		}
	}


	public class RSM {

		public class Mesh {
			public struct Header {
				public string Name;				// 40 bytes
				public int UnknownInt;			// 4 bytes
				public string ParentName;		// 40 bytes
				// skip 10 * 4 (float) bytes
			};

			public struct TransMatrix {
				public Vector4[] Matrix3x3;		// 36 bytes (9x float)
				public Vector3 Translate1;		// 12 bytes (3x float)
				public Vector3 Translate2;		// 12 bytes (3x float)
				public float RotationAngle;		// 4 bytes
				public Vector3 RotationVector;	// 12 bytes (3x float)
				public Vector3 Scale;			// 12 bytes (3x float)
			};

			public struct Surface {
				public ushort[] SurfaceVector;	// 3 * 2 bytes
				public ushort[] TextureVector;	// 3 * 2 bytes
				public ushort TextureID;		// 2 bytes
				public ushort UnknownShort;		// 2 bytes
				public uint UnknownUint;		// 4 bytes
				public uint SurfaceNumber;		// 4 bytes
			};

			public struct Frame {
				public int Time;				// 4 bytes
				public Vector4 Orientation;		// 16 bytes (4x float)
			};

			public bool IsOnly;
			public bool IsMain;


			public Header Head;
			public TransMatrix Matrix;

			/// <summary>
			/// Texture Index ( 4 * TextureIndexCount )
			/// </summary>
			public int TextureIndexCount;		// 4 bytes
			public List<int> TextureIndexs;		// ( 4 * TextureIndexCount ) bytes

			/// <summary>
			/// Vector Count
			/// </summary>
			public int MainVectorCount;				// 4 bytes
			public List<Vector3> MainVectors;		// ( 12 * MainVectorCount ) bytes
			public int TextureVectorCount;			// 4 bytes
			public List<Vector3> TextureVectors;	// ( 12 * TextureVectorCount ) bytes

			/// <summary>
			/// Surface ( SurfaceCount * 24 )
			/// </summary>
			public int SurfaceCount;				// 4 bytes
			public List<Surface> Surfaces;			// ( SurfaceCount * 24 ) bytes

			/// <summary>
			/// Frames ( FrameCount * 20 )
			/// </summary>
			public int FrameCount;					// 4 bytes
			public List<Frame> Frames;				// ( FrameCount * 20 ) bytes


			public BoundingBox Boundingbox;
		}

		public struct RsmFile {
			public char[] MagicHead;	// 0: 4x Char
			public int MajorVer;		// 4
			public int MinorVer;		// 5

			// 1.2 && 1.3 == 24 bytes FREE, others == 25 bytes FREE

			/// <summary>
			/// Texture Names ( 40 * TextureNameC )
			/// </summary>
			public int TextureNameCount;	// 4 bytes
			public string[] TextureNames;	// ( 40 * TextureNameCount ) bytes

			/// <summary>
			/// Meshes ( 94 bytes )
			/// </summary>
			public List<Mesh> Meshes;
		}


		private RsmFile mRsmFile;
		private BoundingBox MaxBox;


		public RsmFile File {
			get { return mRsmFile; }
		}

		public RSM( string Filename, bool Init ) {
			Read( Filename );

			if( Init == true )
				Initialize();
		}

		public void Initialize() {
			CalcBoundingBox();
		}




		private void CalcBoundingBox() {
			MaxBox = new BoundingBox();

			mRsmFile.Meshes[ 0 ].CalcBoundingBox( ref MaxBox );

			for( int i = 1; i < mRsmFile.Meshes.Count; i++ )
				if( mRsmFile.Meshes[ 0 ].IsParent( mRsmFile.Meshes[ i ] ) == true )
					mRsmFile.Meshes[ i ].CalcBoundingBox( ref MaxBox );
			

			MaxBox = mRsmFile.Meshes[ 0 ].Boundingbox;
			for( int i = 1; i < mRsmFile.Meshes.Count; i++ )
				if( mRsmFile.Meshes[ 0 ].IsParent( mRsmFile.Meshes[ i ] ) == true ) {
					MaxBox.Min = MaxBox.Min.MinFrom( mRsmFile.Meshes[ i ].Boundingbox.Min );
					MaxBox.Max = MaxBox.Max.MaxFrom( mRsmFile.Meshes[ i ].Boundingbox.Max );
				}

		}







		private void Read( string Filename ) {
			mRsmFile = new RsmFile();

			using( FileStream s = System.IO.File.OpenRead( Filename ) ) {
				using( BinaryReader bin = new BinaryReader( s, Encoding.GetEncoding( "ISO-8859-1" ) ) ) {
					mRsmFile.MagicHead = bin.ReadChars( 4 );
					mRsmFile.MajorVer = (int)bin.ReadChar();
					mRsmFile.MinorVer = (int)bin.ReadChar();

					// 1.2 && 1.3 == 24 bytes FREE, others == 25 bytes FREE
					byte skip = 25;
					if( mRsmFile.MajorVer == 1 && ( mRsmFile.MinorVer == 2 || mRsmFile.MinorVer == 3 ) )
						skip = 24;
					bin.BaseStream.Position += skip;

					mRsmFile.TextureNameCount = (int)bin.ReadUInt32();
					mRsmFile.TextureNames = new string[ mRsmFile.TextureNameCount ];
					for( int i = 0; i < mRsmFile.TextureNameCount; i++ )
						mRsmFile.TextureNames[ i ] = Tools.ReadWord( bin, 40 );

					bool isMain = true;
					mRsmFile.Meshes = new List<Mesh>();
					while( bin.PeekChar() >= 0 ) {
						ReadMesh( isMain, bin );
						isMain = false;

						if( bin.BaseStream.Length - bin.BaseStream.Position < 100 )
							break;
					}

					if( mRsmFile.Meshes.Count == 1 )
						mRsmFile.Meshes[ 0 ].IsOnly = true;

				}
			}

		}

		private void ReadMesh( bool isMain, BinaryReader bin ) {
			Mesh m = new Mesh();
			m.IsMain = isMain;

			m.Head = new Mesh.Header();
			if( m.IsMain == true ) {
				m.Head.Name = Tools.ReadWord( bin, 40 );
				m.Head.UnknownInt = bin.ReadInt32();
				m.Head.ParentName = Tools.ReadWord( bin, 40 );
				bin.BaseStream.Position += 10 * 4;
			} else {
				m.Head.Name = Tools.ReadWord( bin, 40 );
				m.Head.ParentName = Tools.ReadWord( bin, 40 );
			}


			m.TextureIndexCount = bin.ReadInt32();
			m.TextureIndexs = new List<int>();
			for( int i = 0; i < m.TextureIndexCount; i++ ) {
				int texIndex = bin.ReadInt32();
				m.TextureIndexs.Add( texIndex );
			}

			if( m.TextureIndexCount == 0 || bin.PeekChar() < 0 )
				return;

			m.Matrix = ReadMatrix( bin );


			m.MainVectorCount = bin.ReadInt32();
			m.MainVectors = new List<Vector3>();
			for( int i = 0; i < m.MainVectorCount; i++ ) {
				Vector3 vec = Tools.ReadVector3( bin );
				m.MainVectors.Add( vec );
			}

			if( bin.PeekChar() < 0 )
				return;
			
			m.TextureVectorCount = bin.ReadInt32();
			m.TextureVectors = new List<Vector3>();
			for( int i = 0; i < m.TextureVectorCount; i++ ) {
				Vector3 vec = Tools.ReadVector3( bin );
				m.TextureVectors.Add( vec );
			}

			if( bin.PeekChar() < 0 )
				return;


			m.SurfaceCount = bin.ReadInt32();
			m.Surfaces = new List<Mesh.Surface>();
			for( int i = 0; i < m.SurfaceCount; i++ ) {
				m.Surfaces.Add( ReadSurface( bin ) );
			}

			if( bin.PeekChar() < 0 )
				return;


			m.FrameCount = bin.ReadInt32();
			m.Frames = new List<Mesh.Frame>();
			for( int i = 0; i < m.FrameCount; i++ ) {
				m.Frames.Add( ReadFrame( bin ) );
			}



			mRsmFile.Meshes.Add( m );
		}

		private Mesh.TransMatrix ReadMatrix( BinaryReader bin ) {
			Mesh.TransMatrix m = new Mesh.TransMatrix();

			Vector3[] v = new Vector3[ 3 ]{
				Tools.ReadVector3( bin ),
				Tools.ReadVector3( bin ),
				Tools.ReadVector3( bin )
			};
			
			m.Matrix3x3 = new Vector4[ 4 ] {
				new Vector4( v[0], 0f ),
				new Vector4( v[1], 0f ),
				new Vector4( v[2], 0f ),
				new Vector4( 0f, 0f, 0f, 1f )
			};


			m.Translate1 = Tools.ReadVector3( bin );
			m.Translate2 = Tools.ReadVector3( bin );
			m.RotationAngle = bin.ReadSingle();
			m.RotationVector = Tools.ReadVector3( bin );
			m.Scale = Tools.ReadVector3( bin );

			return m;
		}

		private Mesh.Surface ReadSurface( BinaryReader bin ) {
			Mesh.Surface s = new Mesh.Surface();

			s.SurfaceVector = new ushort[ 3 ];
			s.TextureVector = new ushort[ 3 ];
			for( int i = 0; i < s.SurfaceVector.Length; i++ )
				s.SurfaceVector[ i ] = bin.ReadUInt16();
			for( int i = 0; i < s.TextureVector.Length; i++ )
				s.TextureVector[ i ] = bin.ReadUInt16();

			s.TextureID = bin.ReadUInt16();
			s.UnknownShort = bin.ReadUInt16();
			s.UnknownUint = bin.ReadUInt32();
			s.SurfaceNumber = bin.ReadUInt32();
			
			return s;
		}

		private Mesh.Frame ReadFrame( BinaryReader bin ) {
			Mesh.Frame f = new Mesh.Frame();

			f.Time = bin.ReadInt32();
			f.Orientation = Tools.ReadVector4( bin );

			return f;
		}


	}
}
