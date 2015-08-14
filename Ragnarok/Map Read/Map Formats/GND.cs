using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map_Formats {
	public class GND {

		public struct TextureData {
			public string TexturePath;	// size: 40 [cap at \0]
			public char[] Unknown;		// size: 40

			public Bitmap TextureBmp;
			public Texture2D TextureTex;
		};

		public struct LitghmapData {
			public char[] brightness;	// size: 64
			public char[] colorrbg;		// size: 192
		};

		public struct TileData {
			/// <summary>
			/// 2 Linien, definiert mit jeweils 2 Punkten
			/// <para>Linie 1: P1 - P2 (oben)</para>
			/// <para>Linie 2: P3 - P4 (unten)</para>
			/// <para>[<c>P1</c>: Start Oben]  [<c>P2</c>: Ende Oben]</para>
			/// <para></para>
			/// <para></para>
			/// <para>[<c>P3</c>: Start Unten] [<c>P4</c>: Ende Unten]</para>
			/// </summary>
			public Vector4 VectorWidth;
			/// <summary>
			/// 2 Linien, definiert mit jeweils 2 Punkten
			/// <para>Linie 1: P1 - P3 (links)</para>
			/// <para>Linie 2: P2 - P4 (rechts)</para>
			/// <para>[<c>P1</c>: Start Links] [<c>P2</c>: Start Rechts]</para>
			/// <para></para>
			/// <para></para>
			/// <para>[<c>P3</c>: Ende Links]  [<c>P4</c>: Ende Rechts]</para>
			/// </summary>
			public Vector4 VectorHeight;
			public ushort TextureIndex;
			public ushort Lightmap;
			public char[] color;			// BGRA -- "A" seems to be ignored by the official client
		};

		public struct CubeData {
			public Vector4 Height;
			public int TileUp;
			public int TileSide;
			public int TileAside;
		};

		public struct GridData {
			public uint X;
			public uint Y;
			public uint Cells;
		};

		public struct GndFile {
			public uint Width;
			public uint Height;
			public uint Ratio;
			public uint TextureCount;
			public uint TextureSize;

			public int LightmapCount;
			public int TileCount;
			public uint CubeCount;

			public TextureData[] Textures;
			public GridData Grid;
			public LitghmapData[] Lightmaps;
			public TileData[] Tiles;
			public CubeData[] Cubes;
		};


		public static GraphicsDevice GraphicsDevice;
		private GndFile mFile;
		public ExportedTextureData ExportedTexture = new ExportedTextureData();
		public Texture2D TexturesAll;

		public GndFile File {
			get { return mFile; }
		}

		public GND( string Filename, string TextureRoot ) {
			Read( Filename, TextureRoot );
		}

		private void Read( string Filename, string TextureRoot ) {
			mFile = new GndFile();

			using( FileStream s = System.IO.File.OpenRead( Filename ) ) {
				using( BinaryReader bin = new BinaryReader( s, Encoding.GetEncoding( "ISO-8859-1" ) ) ) {
					bin.BaseStream.Position += 6;

					mFile.Width = bin.ReadUInt32();
					mFile.Height = bin.ReadUInt32();
					mFile.Ratio = bin.ReadUInt32();
					mFile.TextureCount = bin.ReadUInt32();
					mFile.TextureSize = bin.ReadUInt32();

					mFile.Textures = new TextureData[ mFile.TextureCount ];
					for( int i = 0; i < mFile.TextureCount; i++ ) {
						mFile.Textures[ i ] = new TextureData();
						mFile.Textures[ i ].TexturePath = Tools.ReadWord( bin, 40 ).ToLower();
						mFile.Textures[ i ].Unknown = Tools.ReadWord( bin, 40 ).ToCharArray();

						mFile.Textures[ i ].TextureBmp = Bitmap.FromFile( TextureRoot + @"\" + mFile.Textures[ i ].TexturePath ) as Bitmap;
						if( GraphicsDevice != null )
							mFile.Textures[ i ].TextureTex = Convert.Image2Texture( mFile.Textures[ i ].TextureBmp, GraphicsDevice );
					}

					mFile.LightmapCount = bin.ReadInt32();

					mFile.Grid = new GridData();
					mFile.Grid.X = bin.ReadUInt32();
					mFile.Grid.Y = bin.ReadUInt32();
					mFile.Grid.Cells = bin.ReadUInt32();

					mFile.Lightmaps = new LitghmapData[ mFile.LightmapCount ];
					for( int i = 0; i < mFile.LightmapCount; i++ ) {
						mFile.Lightmaps[ i ] = new LitghmapData();
						mFile.Lightmaps[ i ].brightness = bin.ReadChars( 64 );
						mFile.Lightmaps[ i ].colorrbg = bin.ReadChars( 192 );
					}


					mFile.TileCount = bin.ReadInt32();
					mFile.Tiles = new TileData[ mFile.TileCount ];
					for( int i = 0; i < mFile.TileCount; i++ ) {
						mFile.Tiles[ i ] = new TileData();
						mFile.Tiles[ i ].VectorWidth = Tools.ReadVector4( bin );
						mFile.Tiles[ i ].VectorHeight = Tools.ReadVector4( bin );
						mFile.Tiles[ i ].TextureIndex = bin.ReadUInt16();
						mFile.Tiles[ i ].Lightmap = bin.ReadUInt16();
						mFile.Tiles[ i ].color = bin.ReadChars( 4 );
					}

					mFile.CubeCount = mFile.Width * mFile.Height;
					mFile.Cubes = new CubeData[ mFile.CubeCount ];
					for( int i = 0; i < mFile.CubeCount; i++ ) {
						mFile.Cubes[ i ] = new CubeData();
						mFile.Cubes[ i ].Height = Tools.ReadVector4( bin );
						mFile.Cubes[ i ].TileUp = bin.ReadInt32();
						mFile.Cubes[ i ].TileSide = bin.ReadInt32();
						mFile.Cubes[ i ].TileAside = bin.ReadInt32();
					}

				}

			}
		}




		[Serializable]
		public struct ExportedTextureDataValue {
			[XmlAttribute()]
			public int Width;
			[XmlAttribute()]
			public int Height;

			public ExportedTextureDataValue( int w, int h ) {
				Width = w;
				Height = h;
			}
		}

		[Serializable]
		public struct ExportedTextureData {
			[XmlArrayItem( "Data" )]
			public List<ExportedTextureDataValue> Positions;

			public ExportedTextureDataValue this[ int index ] {
				get { return Positions[ index ]; }
			}

			public int Count {
				get { return Positions.Count; }
			}

			public void Add( int w, int h ) {
				Add( new ExportedTextureDataValue( w, h ) );
			}

			public void Add( ExportedTextureDataValue pos ) {
				if( Positions == null )
					Positions = new List<ExportedTextureDataValue>();

				Positions.Add( pos );
			}
		}

		public void ExportTextureMap( string Filename ) {
			ExportedTexture = new ExportedTextureData();
			TexturesAll = null;
			
			Microsoft.Xna.Framework.Vector2 maxSize = Microsoft.Xna.Framework.Vector2.Zero;
			for( int i = 0; i < mFile.TextureCount; i++ ) {
				ExportedTexture.Add( mFile.Textures[ i ].TextureBmp.Width, mFile.Textures[ i ].TextureBmp.Height );
				maxSize.X += mFile.Textures[ i ].TextureBmp.Width;
				maxSize.Y = Math.Max( mFile.Textures[ i ].TextureBmp.Height, maxSize.Y );
			}

			Bitmap newImg = new Bitmap( (int)maxSize.X, (int)maxSize.Y );
			int drawnWidth = 0;
			using( Graphics g = Graphics.FromImage( newImg ) ) {
				for( int i = 0; i < mFile.TextureCount; i++ ) {
					g.DrawImage( mFile.Textures[ i ].TextureBmp, drawnWidth, 0 );
					drawnWidth += (int)ExportedTexture[ i ].Width;
				}
				g.Save();
			}

			TexturesAll = Convert.Image2Texture( newImg, GND.GraphicsDevice );

			if( Filename != string.Empty ) {
				System.IO.File.Delete( Filename );
				newImg.Save( Filename );

				string FilenameXml = Path.Combine( Path.GetDirectoryName( Filename ), Path.GetFileNameWithoutExtension( Filename ) ) + @".xml";
				System.IO.File.Delete( FilenameXml );

				try {
					XmlSerializer xml = new XmlSerializer( typeof( ExportedTextureData ) );
					using( FileStream s = System.IO.File.OpenWrite( FilenameXml ) )
						xml.Serialize( s, ExportedTexture );
				} catch( Exception e ) {
					Debug.WriteLine( e );
				}
			}
		}



	}
}
