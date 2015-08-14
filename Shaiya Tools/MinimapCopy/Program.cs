using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MinimapCopy {

	public class Program {

		public static void Main( string[] args ) {
			Font f = new Font( "Tahoma", 70 );
			Point drawPos;
			string saveDir = AppDomain.CurrentDomain.BaseDirectory + @"\Minimap\";

			System.IO.Directory.CreateDirectory( saveDir );
			for( int i = 0; i < 200; i++ ) {
				Console.WriteLine( "build Image " + i + ".." );
				using( Bitmap bmp = new Bitmap( 512, 512 ) ) {
					using( Graphics g = Graphics.FromImage( bmp ) ) {
						SizeF stringSize = g.MeasureString( i.ToString(), f );

						drawPos = new Point( 256 - (int)stringSize.Width / 2, 256 - (int)stringSize.Height / 2 );
						g.DrawString( i.ToString(), f, Brushes.White, drawPos );

					}

					DevIL.DevIL.SaveBitmap( saveDir + i + ".tga", bmp );
				}
			}


			Console.WriteLine( "\nfinished" );
			Console.ReadKey();
		}

	}

}
