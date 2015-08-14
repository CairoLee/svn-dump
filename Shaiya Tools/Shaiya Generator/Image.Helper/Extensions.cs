using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageHelper {

	[Flags]
	public enum ETextShadow {
		Top = 1,
		TopLeft = 2,
		TopRight = 4,
		Bottom = 8,
		BottomLeft = 16,
		BottomRight = 32,
		Left = 64,
		Right = 128,

		_All = ETextShadow.Top | ETextShadow.TopLeft | ETextShadow.TopRight | ETextShadow.Bottom | ETextShadow.BottomLeft | ETextShadow.BottomRight | ETextShadow.Left | ETextShadow.Right,
	}

	public static class GraphicsExtensions {

		public static void DrawStringBordered( this Graphics g, string Text, Font font, Brush Color, Brush ShadowColor, int x, int y ) {
			g.DrawStringBordered( Text, font, Color, ShadowColor, (float)x, (float)y );
		}

		public static void DrawStringBordered( this Graphics g, string Text, Font font, Brush Color, Brush ShadowColor, float x, float y ) {
			g.DrawStringShadowed( Text, font, Color, ShadowColor, x - 1, y, ETextShadow._All );
		}



		public static void DrawStringShadowed( this Graphics g, string Text, Font font, Brush Color, Brush ShadowColor, int x, int y, ETextShadow Position ) {
			g.DrawStringShadowed( Text, font, Color, ShadowColor, (float)x, (float)y, Position );
		}

		public static void DrawStringShadowed( this Graphics g, string Text, Font font, Brush Color, Brush ShadowColor, float x, float y, ETextShadow Position ) {
			if( ( Position & ETextShadow.Top ) == ETextShadow.Top )
				g.DrawString( Text, font, ShadowColor, x, y - 1 );
			if( ( Position & ETextShadow.Top ) == ETextShadow.TopLeft )
				g.DrawString( Text, font, ShadowColor, x - 1, y - 1 );
			if( ( Position & ETextShadow.Top ) == ETextShadow.TopRight )
				g.DrawString( Text, font, ShadowColor, x + 1, y - 1 );

			if( ( Position & ETextShadow.Bottom ) == ETextShadow.Bottom )
				g.DrawString( Text, font, ShadowColor, x, y + 1 );
			if( ( Position & ETextShadow.Bottom ) == ETextShadow.BottomLeft )
				g.DrawString( Text, font, ShadowColor, x - 1, y + 1 );
			if( ( Position & ETextShadow.Bottom ) == ETextShadow.BottomRight )
				g.DrawString( Text, font, ShadowColor, x + 1, y + 1 );

			if( ( Position & ETextShadow.Left ) == ETextShadow.Left )
				g.DrawString( Text, font, ShadowColor, x - 1, y );
			if( ( Position & ETextShadow.Right ) == ETextShadow.Right )
				g.DrawString( Text, font, ShadowColor, x + 1, y );

			g.DrawString( Text, font, Color, x, y );
		}


		public static void DrawRectangleRounded( this Graphics g, Pen p, int d, Rectangle r ) {
			g.DrawArc( p, r.X, r.Y, d, d, 180, 90 );
			g.DrawLine( p, r.X + d / 2, r.Y, r.X + r.Width - d / 2, r.Y );
			g.DrawArc( p, r.X + r.Width - d, r.Y, d, d, 270, 90 );
			g.DrawLine( p, r.X, r.Y + d / 2, r.X, r.Y + r.Height - d / 2 );
			g.DrawLine( p, r.X + r.Width, r.Y + d / 2, r.X + r.Width, r.Y + r.Height - d / 2 );
			g.DrawLine( p, r.X + d / 2, r.Y + r.Height, r.X + r.Width - d / 2, r.Y + r.Height );
			g.DrawArc( p, r.X, r.Y + r.Height - d, d, d, 90, 90 );
			g.DrawArc( p, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90 );

		}

		public static void FillRectangleRounded( this Graphics g, Brush b, int d, Rectangle r ) {
			System.Drawing.Drawing2D.SmoothingMode mode = g.SmoothingMode;

			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

			g.FillPie( b, r.X, r.Y, d, d, 180, 90 );
			g.FillPie( b, r.X + r.Width - d, r.Y, d, d, 270, 90 );
			g.FillPie( b, r.X, r.Y + r.Height - d, d, d, 90, 90 );
			g.FillPie( b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90 );
			g.FillRectangle( b, r.X + d / 2, r.Y, r.Width - d, d / 2 );
			g.FillRectangle( b, r.X, r.Y + d / 2, r.Width, r.Height - d );
			g.FillRectangle( b, r.X + d / 2, r.Y + r.Height - d / 2, r.Width - d, d / 2 );

			g.SmoothingMode = mode;

		}

	}

	public static class GraphicsPathExtensions {

		public static void AddRectangleRounded( this GraphicsPath gp, Rectangle r, int d ) {
			gp.AddArc( r.X, r.Y, d, d, 180, 90 );
			gp.AddArc( r.X + r.Width - d, r.Y, d, d, 270, 90 );
			gp.AddArc( r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90 );
			gp.AddArc( r.X, r.Y + r.Height - d, d, d, 90, 90 );
		}

	}

	public static class IntegerExtensions {

		public static float Percent( this int Base, int Satz ) {
			float result = ( (float)Satz / 100f ) * (float)Base;
			return result;
		}

	}


	public static class ListExtensions {

		public static void Swap<T>( this IList<T> List, int ToSwap, int AddToIndex ) {
			int futureDir = ToSwap + AddToIndex;
			T temp = List[ ToSwap ];

			List[ ToSwap ] = List[ futureDir ];
			List[ futureDir ] = temp;
		}

	}

	public static class AssemblyExtensions {

		public static string ShortVersion( this System.Reflection.Assembly Asm ) {
			Version v = Asm.GetName().Version;
			return string.Format( "{0}.{1}", v.Major, v.Minor );
		}

	}

}
