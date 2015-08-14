using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace InsaneRO.Cards.SpriteConvert {

	public class RoSpritePalette : List<Color> {
		public bool PaletteChanged {
			get;
			internal set;
		}


		public RoSpritePalette( int num )
			: base( num ) {
		}


		public void CreateColorChart( int RectSize, string Filepath ) {
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
					Pen p = new Pen( this[ index ], 1 );
					index++;

					g.FillRectangle( p.Brush, rect );

					int sx = ( x + ( RectSize / 5 ) - index.ToString().Length );
					int sy = ( y + ( RectSize / 5 ) );
					g.DrawString( index.ToString(), f, b, new Point( sx, sy ) );
				}

			img.Save( Filepath, System.Drawing.Imaging.ImageFormat.Png );
		}


		public void ApplyPalette( string Filepath ) {
			PaletteChanged = true;
			using( System.IO.FileStream stream = new System.IO.FileStream( Filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read ) ) {
				for( int i = 0; i < Count; i++ ) {
					byte r = (byte)stream.ReadByte();
					byte g = (byte)stream.ReadByte();
					byte b = (byte)stream.ReadByte();
					byte a = (byte)stream.ReadByte();
					this[ i ] = Color.FromArgb( a, r, g, b );
				}
			}
		}

		public void ExportPalette( string Filepath ) {
			using( System.IO.FileStream stream = new System.IO.FileStream( Filepath, System.IO.FileMode.Create, System.IO.FileAccess.Write ) ) {
				for( int i = 0; i < Count; i++ ) {
					stream.WriteByte( this[ i ].R );
					stream.WriteByte( this[ i ].G );
					stream.WriteByte( this[ i ].B );
					stream.WriteByte( this[ i ].A );
				}
			}
		}

	}

}
