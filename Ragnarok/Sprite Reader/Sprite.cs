using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Sprite_Reader {

	public struct SpriteImage {
		public UInt16 Width;				// 0
		public UInt16 Height;				// 2
		public UInt16 Size;					// 4 {nur wenn Compressed}
		public char[] Data;					// 6

		public Bitmap Image;
	}

	public struct SpritePalette {
		public byte red;					// 0
		public byte green;					// 1
		public byte blue;					// 2
		public byte alpha;					// 4
	}

	public struct SpriteData {
		public string MagicHead;			// 0
		public bool Compression;			// 2
		public byte Unknown;				// 3
		public UInt16 ImageCount;			// 4
		public SpriteImage[] Images;		// 6
		public SpritePalette[] Palette;		// EOF - 1024

		public UInt16 MaxWidth;
		public UInt16 MaxHeight;
	}

	class SpriteRead {
		public string SpriteFile = String.Empty;
		public BinaryReader BinaryData = null;
		private FileStream SpriteStream = null;

		public SpriteData Sprite;
		public Form1 Form;


		public SpriteRead( Form1 F, string FileName ) {
			Form = F;
			SpriteStream = File.OpenRead( FileName );
			BinaryData = new BinaryReader( SpriteStream, System.Text.Encoding.Default );

			Sprite = new SpriteData();

			// Head
			Sprite.MagicHead = new String( BinaryData.ReadChars( 2 ) );
			Sprite.Compression = ( BinaryData.ReadByte() > 0 ? true : false );
			Sprite.Unknown = BinaryData.ReadByte();
			Sprite.ImageCount = BinaryData.ReadUInt16();

			Form.AddStatus( " * - Head Data -" );
			Form.AddStatus( " * - * MagicHead: " + Sprite.MagicHead );
			Form.AddStatus( " * - * Compression: " + Sprite.Compression );
			Form.AddStatus( " * - * Unknown: " + Sprite.Unknown );
			Form.AddStatus( " * - * ImageCount: " + Sprite.ImageCount );

			BinaryData.ReadBytes( 2 ); // skip 2 bytes
			// Images
			Stopwatch watch = new Stopwatch();
			watch.Start();
			ReadImageData();
			Form.AddStatus( " * - Image read needed: " + watch.ElapsedMilliseconds + " ms" );

			watch.Reset();
			watch.Start();
			// Palette
			ReadPalette();

			CreateColorChart( 20 );
			Form.AddStatus( " * - Pal create & write needed: " + watch.ElapsedMilliseconds + " ms" );
			watch.Stop();

			DrawImage( 0 );
			//DrawAllImages();

			DrawBmp( 0 );
		}

		private void ReadImageData() {
			if( Sprite.Images == null )
				Sprite.Images = new SpriteImage[ Sprite.ImageCount ];

			for( int i = 0; i < Sprite.ImageCount; i++ ) {
				Sprite.Images[ i ].Width = BinaryData.ReadUInt16();
				Sprite.Images[ i ].Height = BinaryData.ReadUInt16();
				if( Sprite.Compression == true )
					Sprite.Images[ i ].Size = BinaryData.ReadUInt16();
				else
					Sprite.Images[ i ].Size = (UInt16)( Sprite.Images[ i ].Width * Sprite.Images[ i ].Height );
				Sprite.Images[ i ].Data = BinaryData.ReadChars( Sprite.Images[ i ].Size );

				if( Sprite.Images[ i ].Width > Sprite.MaxWidth )
					Sprite.MaxWidth = Sprite.Images[ i ].Width;
				if( Sprite.Images[ i ].Height > Sprite.MaxHeight )
					Sprite.MaxHeight = Sprite.Images[ i ].Height;

				//Form.AddStatus( " * "+i+" - " + Sprite.Images[ i ].Width + " x " + Sprite.Images[ i ].Height + " -" );
			}

		}

		private void CreateColorChart( int RectSize ) {
			int SizeX = ( 16 * RectSize );
			int SizeY = ( 16 * RectSize );
			int index = 0;
			Bitmap img = new Bitmap( SizeX, SizeY );
			Graphics g = Graphics.FromImage( img );
			Font f = new Font( FontFamily.GenericSerif.Name, 8.0f );
			Brush b = Brushes.Black;

			for( int y = 0; y < SizeY; y += RectSize )
				for( int x = 0; x < SizeX; x += RectSize ) {
					Rectangle rect = new Rectangle( x, y, ( x + RectSize ), ( y + RectSize ) );
					Pen p = new Pen( MakeColorRgb( Sprite.Palette[ index ].red, Sprite.Palette[ index ].green, Sprite.Palette[ index ].blue ), 1 );
					index++;

					g.FillRectangle( p.Brush, rect );

					int sx = ( x + ( RectSize / 5 ) - index.ToString().Length );
					int sy = ( y + ( RectSize / 5 ) );
					g.DrawString( index.ToString(), f, b, new Point( sx, sy ) );
				}

			img.Save( AppDomain.CurrentDomain.BaseDirectory + @"\ColorChart.png", System.Drawing.Imaging.ImageFormat.Png );
		}


		public void ReadPalette() {
			Sprite.Palette = new SpritePalette[ 256 ];
			BinaryData.BaseStream.Position = ( BinaryData.BaseStream.Length - ( 4 * 256 ) );
			for( int i = 0; i < 256; i++ ) {
				Sprite.Palette[ i ].red = BinaryData.ReadByte();
				Sprite.Palette[ i ].green = BinaryData.ReadByte();
				Sprite.Palette[ i ].blue = BinaryData.ReadByte();
				Sprite.Palette[ i ].alpha = BinaryData.ReadByte();
			}
		}

		public void DrawImage( int Num ) {
			Stopwatch watch = new Stopwatch();
			watch.Start();

			if( Sprite.Compression == true ) {
				Sprite.Images[ Num ].Data = RLE.Decode( Sprite.Images[ Num ].Data );
			}
			

			Sprite.Images[ Num ].Image = new Bitmap( Sprite.Images[ Num ].Width, Sprite.Images[ Num ].Height );
			FastBitmap fb = new FastBitmap( Sprite.Images[ Num ].Image );
			fb.LockImage();

			int index;
			byte dump;
			for( int x = 0; x < Sprite.Images[ Num ].Width; x++ ) {
				for( int y = 0; y < Sprite.Images[ Num ].Height; y++ ) {
					Application.DoEvents();
					dump = 0;
					index = ( x + ( y * Sprite.Images[ Num ].Width ) );

					if( index < Sprite.Images[ Num ].Data.Length ) {
						dump = (byte)Sprite.Images[ Num ].Data[ index ];
						fb.SetPixel( x, y, MakeColorArgb( Sprite.Palette[ dump ].alpha, Sprite.Palette[ dump ].red, Sprite.Palette[ dump ].green, Sprite.Palette[ dump ].blue ) );
					} else
						fb.SetPixel( x, y, Color.Transparent );
				}
			}
			fb.UnlockImage();

			Form.AddStatus( " * - Image " + Num + " write needed: " + watch.ElapsedMilliseconds + " ms" );
			watch.Stop();

			Sprite.Images[ Num ].Image.Save( AppDomain.CurrentDomain.BaseDirectory + @"\Sprite Img " + Num + ".png", System.Drawing.Imaging.ImageFormat.Png );

		}

		public void DrawAllImages() {
			for( int Num = 0; Num < Sprite.ImageCount; Num++ ) {
				Form.AddStatus( "Start reading Image " + Num );
				DrawImage( Num );
			}

			Form.AddStatus( "Finshed reading Images!" );
		}

		public Color MakeColorArgb( byte A, byte R, byte G, byte B ) {
			Color c = Color.FromArgb( 255 - A, R, G, B );
			return c;
		}
		public Color MakeColorRgb( byte R, byte G, byte B ) {
			Color c = Color.FromArgb( R, G, B );
			return c;
		}

		

		public unsafe void DrawBmp( int i ) {
			Stopwatch watch = new Stopwatch();
			watch.Stop();
			SpriteImage img = Sprite.Images[ i ];
			using( FileStream fs = File.Open( AppDomain.CurrentDomain.BaseDirectory + @"\Sprite Img " + i + ".bmp", FileMode.OpenOrCreate ) )
				using( BinaryWriter writer = new BinaryWriter( fs ) ) {

					uint k;
					int wscan = img.Width;
					while( wscan % 4 != 0 )
						wscan++;
					/*
					public struct fileHeader {
						public ushort reserved1;
						public ushort reserved2;
						public uint offset;
					};
					*/

					uint s_filehead = (uint)( sizeof( ushort ) + sizeof( uint ) + sizeof( ushort ) + sizeof( ushort ) + sizeof( uint ) );
					uint s_dibhead = (uint)( sizeof( uint ) + sizeof( int ) + sizeof( ushort ) + sizeof( ushort ) + sizeof( uint ) + sizeof( uint ) + sizeof( uint ) + sizeof( uint ) + sizeof( uint ) );
					uint s_both = s_filehead + s_dibhead;

					uint pos = (uint)s_both + 256 * 4;
					uint size = (uint)pos + (uint)( wscan * img.Height );

					writer.Write( (ushort)0x4D42 );
					writer.Write( (uint)40 );
					writer.Write( (ushort)1 );
					writer.Write( (ushort)8 );
					writer.Write( (uint)0 );
					writer.Write( (uint)1 );
					writer.Write( (uint)1 );
					writer.Write( (uint)256 );
					writer.Write( (uint)0 );
					writer.Write( (int)img.Width );
					writer.Write( (int)img.Height );
					writer.Write( (uint)wscan * img.Width );
					writer.Write( (uint)pos );
					writer.Write( (uint)size );
					for( k = 0; k < 256; k++ ) {
						writer.Write( Sprite.Palette[ k ].blue );
						writer.Write( Sprite.Palette[ k ].green );
						writer.Write( Sprite.Palette[ k ].green );
						writer.Write( ( k != 0 ? Sprite.Palette[ k ].alpha : 0 ) );
					}

					char[] dbuf = new char[ wscan ];
					for( int ii = img.Height - 1; ii >= 0; ii-- ) {
						Array.Copy( img.Data, ii * img.Width, dbuf, 0, img.Width );
						writer.Write( dbuf );
					}
				}

			Form.AddStatus( " * - write BMP finished in " + watch.ElapsedMilliseconds + "ms" );
			watch.Stop();
		}



	}

}
