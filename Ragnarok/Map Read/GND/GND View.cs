using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

namespace MapRead.GND {

	public partial class GNDViewer : Form {

		public struct TextureInfo {
			public string TexPath;			// size: 40 [cap at \0]
			public char[] Unknown;			// size: 40

			public Bitmap TextureBmp;
		};

		public struct LitghmapInfo {
			public char[] brightness;	// size: 64
			public char[] colorrbg;		// size: 192
		};

		public struct TileInfo {
			/// <summary>
			/// 2 Linien, definiert mit jeweils 2 Punkten
			/// <para>Linie 1: P1 - P2 (oben)</para>
			/// <para>Linie 2: P3 - P4 (unten)</para>
			/// <para>[<c>P1</c>: Start Oben]  [<c>P2</c>: Ende Oben]</para>
			/// <para></para>
			/// <para></para>
			/// <para>[<c>P3</c>: Start Unten] [<c>P4</c>: Ende Unten]</para>
			/// </summary>
			public VectorTU VectorWidth;
			/// <summary>
			/// 2 Linien, definiert mit jeweils 2 Punkten
			/// <para>Linie 1: P1 - P3 (links)</para>
			/// <para>Linie 2: P2 - P4 (rechts)</para>
			/// <para>[<c>P1</c>: Start Links] [<c>P2</c>: Start Rechts]</para>
			/// <para></para>
			/// <para></para>
			/// <para>[<c>P3</c>: Ende Links]  [<c>P4</c>: Ende Rechts]</para>
			/// </summary>
			public VectorTU VectorHeight;
			public ushort TextureIndex;
			public ushort Lightmap;
			public char[] color;			// BGRA -- "A" seems to be ignored by the official client
		};

		public struct CubeInfo {
			public VectorTU Height;
			public int tile_up;
			public int tile_side;
			public int tile_aside;
		};

		public struct HeaderInfo {
			public uint Width;
			public uint Height;
			public uint Ratio;
			public uint TextureCount;
			public uint TextureSize;
		};

		public struct GridInfo {
			public uint X;
			public uint Y;
			public uint Cells;
		};



		HeaderInfo mHeader;
		GridInfo mGrid;

		TextureInfo[] mTextures;
		LitghmapInfo[] mLightmaps;
		TileInfo[] mTiles;
		CubeInfo[] mCubes;

		uint mTileCount;
		uint mLightmapCount;
		uint mCubeCount;


		public GNDViewer() {

			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Ragnarok GND File (*.gnd)|*.gnd";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			textBox1.Text = dlg.FileName;


			ReadGndFile();

			DrawGND( 60, 60, false, true );
		}

		private void button2_Click( object sender, EventArgs e ) {
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			textBox2.Text = dlg.SelectedPath;
		}


		private void DrawGND( int ScaleX, int ScaleY, bool FixxSize, bool DrawPosition ) {
			Font font = new Font( "Aial", 6 );
			Bitmap bmp = null;
			if( FixxSize == true )
				bmp = new Bitmap( Math.Min( this.Width + 10, (int)mHeader.Width * ScaleX + 2 ), Math.Min( this.Height + 10, (int)mHeader.Height * ScaleY + 2 ) );
			else
				bmp = new Bitmap( (int)mHeader.Width * ScaleX + 2, (int)mHeader.Height * ScaleY + 2 );
			string Root = textBox2.Text;
			int x = -1, y = (int)mHeader.Height - 1, yPos = 0, cubeNum = 0, tileNum = 0;

			//pictureBox1.Width = bmp.Width;
			//pictureBox1.Height = bmp.Height;
			//pictureBox1.Image = bmp;

			lblData.Text = "Image W/H: [" + bmp.Width + "/" + bmp.Height + "]; ";

			Stopwatch watch = Stopwatch.StartNew();
			using( Graphics g = Graphics.FromImage( bmp ) ) {
				g.DrawRectangle( new Pen( Color.Red ), 0, 0, bmp.Width - 1, bmp.Height - 1 );
				g.Save();

				for( int i = 0; i < mCubes.Length; i++ ) {
					Application.DoEvents();

					if( ++x >= mHeader.Width ) {
						x = 0;
						y--;
						yPos++;
					}

					cubeNum = ( x + ( y * (int)mHeader.Width ) );
					tileNum = mCubes[ cubeNum ].tile_up;
					Debug.WriteLine( "Cube: " + cubeNum + " (Up " + mCubes[ cubeNum ].tile_up + ", Side " + mCubes[ cubeNum ].tile_side + ", aSide " + mCubes[ cubeNum ].tile_aside + "), X/Y: " + x + "/" + y + ( FixxSize == true ? ( ( x * ScaleX + 1 ) > this.Width ? " [skipping - zu breit]" : ( yPos * ScaleY + 1 ) > this.Height ? " [skipping - zu hoch]" : "" ) : "" ) );

					if( tileNum == -1 ) {
						if( mCubes[ cubeNum ].tile_side != -1 )
							tileNum = mCubes[ cubeNum ].tile_side;
						else if( mCubes[ cubeNum ].tile_aside != -1 )
							tileNum = mCubes[ cubeNum ].tile_aside;
						else
							continue;
					}

					if( FixxSize == true ) {
						if( ( x * ScaleX + 1 ) > this.Width && ( yPos * ScaleY + 1 ) > this.Height )
							break;
						if( ( x * ScaleX + 1 ) > this.Width || ( yPos * ScaleY + 1 ) > this.Height )
							continue;
					}

					Bitmap tex = GetTextureImage( tileNum, false );
					VectorTU vWidth = mTiles[ tileNum ].VectorWidth;
					VectorTU vHeight = mTiles[ tileNum ].VectorHeight;


					int startX = (int)( vWidth.P1 * (float)tex.Width );
					int startY = (int)( vHeight.P1 * (float)tex.Height );
					int endX = (int)( vWidth.P2 * (float)tex.Width );
					int endY = (int)( vHeight.P3 * (float)tex.Height );

					// Image Spiegeln
					if( startX > endX ) {
						startX.Swap( ref startX, ref endX );
						tex = tex.MirrorVertical();
					}

					if( startY > endY ) {
						startY.Swap( ref startY, ref endY );
						tex = tex.MirrorHorizontal();
					}

					int sizeX = endX - startX;
					int sizeY = endY - startY;
					Rectangle srcRect = new Rectangle( startX, startY, ( sizeX < 0 ? -sizeX : sizeX ), ( sizeY < 0 ? -sizeY : sizeY ) );


					g.DrawImage( tex, new Rectangle( x * ScaleX + 1, yPos * ScaleY + 1, ScaleX, ScaleY ), srcRect, GraphicsUnit.Pixel );
					//g.DrawImage( tex, new Rectangle( x * ScaleX + 1, yPos * ScaleY + 1, ScaleX, ScaleY ) );
					/*
					if( DrawPosition == true ) {
						g.DrawString( vWidth.ToString(), font, Brushes.White, new PointF( x * ScaleX + 2, yPos * ScaleY + 2 ) );
						g.DrawString( vHeight.ToString(), font, Brushes.White, new PointF( x * ScaleX + 2, yPos * ScaleY + 17 ) );
						g.DrawString( "X/Y [" + x + "/" + y + "] Cube [" + cubeNum + "]", font, Brushes.White, new PointF( x * ScaleX + 2, yPos * ScaleY + 32 ) );
						g.DrawString( "Start [" + startX + "/" + startY + "] End [" + endX + "/" + endY + "]", font, Brushes.White, new PointF( x * ScaleX + 2, yPos * ScaleY + 47 ) );
					}
					*/
					//pictureBox1.Image = bmp;
				}
			}


			CreateGrid( bmp, ScaleX, ScaleY, bmp.Width, bmp.Height );

			//pictureBox1.Image = bmp;

			string testImage = AppDomain.CurrentDomain.BaseDirectory + Path.GetFileNameWithoutExtension( textBox1.Text ) + @".png";
			try {
				bmp.Save( testImage, System.Drawing.Imaging.ImageFormat.Jpeg );
			} catch( Exception e ) {
				Debug.WriteLine( e );
			}

			string end = "finished in " + watch.ElapsedMilliseconds + " ms...";
			Debug.WriteLine( end );
			MessageBox.Show( end );
			watch = null;
		}






		private void ReadGndFile() {
			string Root = textBox2.Text;
			using( FileStream s = File.OpenRead( textBox1.Text ) ) {
				using( BinaryReader bin = new BinaryReader( s, Encoding.GetEncoding( "ISO-8859-1" ) ) ) {
					bin.BaseStream.Position += 6;

					mHeader = new HeaderInfo();
					mHeader.Width = bin.ReadUInt32();
					mHeader.Height = bin.ReadUInt32();
					mHeader.Ratio = bin.ReadUInt32();
					mHeader.TextureCount = bin.ReadUInt32();
					mHeader.TextureSize = bin.ReadUInt32();

					mTextures = new TextureInfo[ mHeader.TextureCount ];
					for( int i = 0; i < mTextures.Length; i++ ) {
						mTextures[ i ] = new TextureInfo();
						mTextures[ i ].TexPath = ReadWord( bin, 40 ).ToLower();
						mTextures[ i ].Unknown = ReadWord( bin, 40 ).ToCharArray();

						mTextures[ i ].TextureBmp = Bitmap.FromFile( Root + @"\" + mTextures[ i ].TexPath ) as Bitmap;
					}

					mLightmapCount = (uint)bin.ReadInt32();

					mGrid = new GridInfo();
					mGrid.X = bin.ReadUInt32();
					mGrid.Y = bin.ReadUInt32();
					mGrid.Cells = bin.ReadUInt32();

					mLightmaps = new LitghmapInfo[ mLightmapCount ];
					for( int i = 0; i < mLightmaps.Length; i++ ) {
						mLightmaps[ i ] = new LitghmapInfo();
						mLightmaps[ i ].brightness = bin.ReadChars( 64 );
						mLightmaps[ i ].colorrbg = bin.ReadChars( 192 );
					}


					mTileCount = (uint)bin.ReadInt32();
					mTiles = new TileInfo[ mTileCount ];
					for( int i = 0; i < mTiles.Length; i++ ) {
						mTiles[ i ] = new TileInfo();
						mTiles[ i ].VectorWidth = ReadVector4( bin );
						mTiles[ i ].VectorHeight = ReadVector4( bin );
						mTiles[ i ].TextureIndex = bin.ReadUInt16();
						mTiles[ i ].Lightmap = bin.ReadUInt16();
						mTiles[ i ].color = bin.ReadChars( 4 );
					}

					mCubeCount = mHeader.Width * mHeader.Height;
					mCubes = new CubeInfo[ mCubeCount ];
					for( int i = 0; i < mCubes.Length; i++ ) {
						mCubes[ i ] = new CubeInfo();
						mCubes[ i ].Height = ReadVector4( bin );
						mCubes[ i ].tile_up = bin.ReadInt32();
						mCubes[ i ].tile_side = bin.ReadInt32();
						mCubes[ i ].tile_aside = bin.ReadInt32();
					}

				}

			}

		}


		private string ReadWord( BinaryReader bin, int max ) {
			StringBuilder sb = new StringBuilder();

			while( sb.Length < max && bin.BaseStream.CanRead == true && bin.PeekChar() != '\0' )
				sb.Append( bin.ReadChar() );

			bin.BaseStream.Position += ( max - sb.Length );
			return sb.ToString();
		}

		private unsafe VectorTU ReadVector4( BinaryReader bin ) {
			if( ( bin.BaseStream.Length - bin.BaseStream.Position ) < 12 )
				return VectorTU.Zero;

			VectorTU vec = new VectorTU(
				bin.ReadSingle(),
				bin.ReadSingle(),
				bin.ReadSingle(),
				bin.ReadSingle()
			);

			return vec;
		}




		private string GetTexturePath( int tileNum ) {
			return mTextures[ mTiles[ tileNum ].TextureIndex ].TexPath.ToLower();
		}

		private Bitmap GetTextureImage( int tileNum, bool Grid ) {
			if( Grid == false )
				return mTextures[ mTiles[ tileNum ].TextureIndex ].TextureBmp;

			Bitmap oldImg = mTextures[ mTiles[ tileNum ].TextureIndex ].TextureBmp;
			Bitmap newImg = new Bitmap( oldImg.Width, oldImg.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb );
			using( Graphics g = Graphics.FromImage( newImg ) ) {
				g.DrawImage( oldImg, new Point( 0, 0 ) );
				g.DrawRectangle( new Pen( Color.Blue ), 0, 0, newImg.Width - 1, newImg.Height - 1 );
				g.Save();
			}
			return newImg;
		}

		private void CreateGrid( Bitmap grid, int ScaleX, int ScaleY, int RectMaxWidth, int RectMaxHeight ) {
			Pen bluePen = new Pen( Color.Blue );

			using( Graphics g = Graphics.FromImage( grid ) ) {
				for( int y = 0; y < RectMaxHeight; y += ScaleY ) {
					for( int x = 0; x < RectMaxWidth; x += ScaleX ) {
						Application.DoEvents();

						g.DrawLine( bluePen, new Point( x, y ), new Point( x + ScaleX - 1, y ) );
						g.DrawLine( bluePen, new Point( x, y ), new Point( x, y + ScaleY - 1 ) );

						if( y >= RectMaxHeight - 1 )
							g.DrawLine( bluePen, new Point( x, RectMaxHeight - 1 ), new Point( x + ScaleX - 1, RectMaxHeight - 1 ) );
					}

					g.DrawLine( bluePen, new Point( RectMaxWidth - 1, y ), new Point( RectMaxWidth - 1, y + ScaleY - 1 ) );
				}
				g.Save();
			}

		}

		private void ModTexture( Bitmap Texture, ref Graphics g, VectorTU StartMod, VectorTU EndMod ) {
			int startX = (int)( Texture.Width * StartMod.P1 );
			int startY = (int)( Texture.Height * StartMod.P2 );
			int endX = (int)( Texture.Width * EndMod.P1 );
			int endY = (int)( Texture.Height * EndMod.P2 );

			g.DrawImage( Texture, new Rectangle( startX, startY, endX, endY ) );
		}

		private void btnMinus_Click( object sender, EventArgs e ) {

		}

		private void btnPlus_Click( object sender, EventArgs e ) {

		}

	}


	public static class ExtensionsINT {
		public static void Swap( this int mX, ref int m1, ref int m2 ) {
			int mN = m1;
			m1 = m2;
			m2 = mN;
		}
	}

	public static class ExtensionsBITMAP {
		private static int VerticalCount = 0;
		private static int HorizontalCount = 0;
		/// <summary>
		/// Spiegelt Links / Rechts (Vertikal)
		/// </summary>
		/// <param name="tex"></param>
		/// <returns></returns>
		public static Bitmap MirrorVertical( this Bitmap tex ) {

			Point[] destinationPoints = {
				new Point( tex.Width, 0 ),			// oben links => oben rechts
				new Point( 0, 0 ),					// oben rechts => oben links
				new Point( tex.Width, tex.Height )	// unten links => unten rechts
			};

			Bitmap newBmpMirrored = new Bitmap( tex.Width, tex.Height );
			using( Graphics gs = Graphics.FromImage( newBmpMirrored ) ) {
				gs.DrawImage( tex, destinationPoints );
				gs.Save();
			}

			return newBmpMirrored;
		}

		/// <summary>
		/// Spiegelt Unten / Oben (Horizontal)
		/// </summary>
		/// <param name="tex"></param>
		/// <returns></returns>
		public static Bitmap MirrorHorizontal( this Bitmap tex ) {

			Point[] destinationPoints = {
				new Point( 0, tex.Height ),			// oben links => unten rechts
				new Point( tex.Width, tex.Height ),	// oben rechts => unten rechts
				new Point( 0, 0 )					// unten links => oben links
			};

			Bitmap newBmpMirrored = new Bitmap( tex.Width, tex.Height );
			using( Graphics gs = Graphics.FromImage( newBmpMirrored ) ) {
				gs.DrawImage( tex, destinationPoints );
				gs.Save();
			}

			return newBmpMirrored;
		}
	}







	public class VectorTU {
		private float mP1;
		private float mP2;
		private float mP3;
		private float mP4;

		public static readonly VectorTU Zero = new VectorTU( 0, 0, 0, 0 );

		[XmlAttribute]
		public float P1 {
			get { return mP1; }
			set { mP1 = value; }
		}
		[XmlAttribute]
		public float P2 {
			get { return mP2; }
			set { mP2 = value; }
		}
		[XmlAttribute]
		public float P3 {
			get { return mP3; }
			set { mP3 = value; }
		}
		[XmlAttribute]
		public float P4 {
			get { return mP4; }
			set { mP4 = value; }
		}


		public VectorTU() {
		}
		public VectorTU( float X, float Y, float Z, float W ) {
			mP1 = X;
			mP2 = Y;
			mP3 = Z;
			mP4 = W;
		}


		public override string ToString() {
			return String.Format( "{0}/{1}/{2}/{3}", mP1, mP2, mP3, mP4 );
		}
	}

	public class GNDDebug {
		[XmlElement]
		public VectorTU StartVector;
		[XmlElement]
		public VectorTU EndVector;
		[XmlAttribute]
		public int X;
		[XmlAttribute]
		public int Y;
		[XmlAttribute]
		public int Cubes;

		public GNDDebug() {
		}

		public GNDDebug( VectorTU vecStart, VectorTU vecEnd, int coordX, int coordY, int CubeNum ) {
			StartVector = vecStart;
			EndVector = vecEnd;
			X = coordX;
			Y = coordY;
			Cubes = CubeNum;
		}
	}
}
