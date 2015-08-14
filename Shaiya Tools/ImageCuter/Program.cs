using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace ImageCuter {

	public class Program {

		public static void Main( string[] args ) {
			try {
				Console.WriteLine( "Ich liebe dich. <3" );
				Console.WriteLine( "\n\n" );
				if( args.Length == 0 ) {
					Console.WriteLine( "Bitte zieh ein Image auf die Exe, nicht direkt starten :*" );
					Console.Read();
					return;
				}

				Console.Write( "Icon Breite: " );
				int iconWidth = int.Parse( Console.ReadLine() );
				Console.Write( "Icon Hoehe: " );
				int iconHeight = int.Parse( Console.ReadLine() );

				Console.WriteLine( "Bearbeite..." );
				for( int i = 0; i < args.Length; i++ ) {
					Console.WriteLine( "\t" + Path.GetFileNameWithoutExtension( args[ i ] ) );
					ParseImage( args[ i ], new Size( iconWidth, iconHeight ) );
				}

				Console.WriteLine( "Fertig!\n\nIch liebe dich. <3" );
				Console.Read();
			} catch( Exception e ) {
				Console.WriteLine( "\n\nFEHLER!" );
				Console.WriteLine( e );
				Console.Read();
			}
		}

		private static void ParseImage( string Imagename, Size IconSize ) {
			Image baseImg = Image.FromFile( Imagename );
			int xCount = baseImg.Width / IconSize.Width;
			int yCount = baseImg.Height / IconSize.Height;
			int i = 0;

			string pathName = AppDomain.CurrentDomain.BaseDirectory + @"Liiiebe-" + Path.GetFileNameWithoutExtension( Imagename ) + @"\";
			Directory.CreateDirectory( pathName );
			for( int y = 0; y < yCount; y++ ) {
				for( int x = 0; x < xCount; x++ ) {
					Rectangle src = new Rectangle( IconSize.Width * x, IconSize.Height * y, IconSize.Width, IconSize.Height );
					using( Image newImg = GetImagePart( baseImg, src, IconSize ) ) {
						newImg.Save( pathName + "icon-" + ( i++ ) + ".png" );
					}

				}
			}

		}



		private static Image GetImagePart( Image BaseImage, Rectangle SourceRectangle, Size Size ) {
			Image newImg = new Bitmap( Size.Width, Size.Height );
			using( Graphics g = Graphics.FromImage( newImg ) ) {
				g.DrawImage( BaseImage, new Rectangle( 0, 0, Size.Width, Size.Height ), SourceRectangle, GraphicsUnit.Pixel );
			}

			return newImg;
		}

	}

}
