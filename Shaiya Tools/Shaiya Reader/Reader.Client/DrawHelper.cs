using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Shaiya.Reader.Client {

	public class DrawHelper {
		public static Pen BorderPen;
		public static Brush BrushStringBlack;
		public static Brush BrushStringWhite;
		public static Font Font;


		public static Bitmap Drawbar( int Width, int Height, int Value, int MaxValue, Brush Brush ) {
			Bitmap img = new Bitmap( Width, Height );
			float drawWidth = 0f;
			if( MaxValue > 0 )
				drawWidth = (float)( (float)( (float)Width - 2 ) / (float)MaxValue ) * (float)Value;
			using( Graphics g = Graphics.FromImage( img ) ) {
				g.DrawRectangle( BorderPen, 0, 0, Width - 1, Height - 1 );
				if( drawWidth > 0f )
					g.FillRectangle( Brush, 1f, 1f, drawWidth, Height - 2 );
				g.DrawString( Value + " / " + MaxValue, Font, BrushStringBlack, 11, 2 );
				g.DrawString( Value + " / " + MaxValue, Font, BrushStringWhite, 10, 1 );
			}

			return img;
		}

	}

}
