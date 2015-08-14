using System;
using System.Drawing;
using System.Windows.Forms;

using Smd.Structs;
using Smd.Enumerations;

namespace Smd.Components {

	public class MobToolTip : ToolTip {
		private SolidBrush mBackgroundBrush;
		private Pen mBorderPen;
		private SMobPoint mMobPoint;

		public SMobPoint MobPoint {
			get { return mMobPoint; }
			set { mMobPoint = value; }
		}

		public MobToolTip() {
			OwnerDraw = true;
			Draw += new DrawToolTipEventHandler( MobToolTip_Draw );
			Popup += new PopupEventHandler( MobToolTip_Popup );
		}


		private void MobToolTip_Draw( object sender, DrawToolTipEventArgs e ) {
			if( mBackgroundBrush == null )
				mBackgroundBrush = new SolidBrush( BackColor );
			if( mBorderPen == null )
				mBorderPen = new Pen( Color.Black, 2 );

			Size size = new Size( e.Bounds.Width, e.Bounds.Height );

			e.Graphics.FillRectangle( mBackgroundBrush, 0, 0, size.Width, size.Height );
			e.Graphics.DrawRectangle( mBorderPen, 0, 0, size.Width, size.Height );
			DrawMobInfo( e.Graphics, e.Font, true );
		}

		private void MobToolTip_Popup( object sender, PopupEventArgs e ) {
			Size s;
			using( Font f = new Font( "Tahoma", 9 ) )
			using( Image img = new Bitmap( e.ToolTipSize.Width, e.ToolTipSize.Height ) )
			using( Graphics g = Graphics.FromImage( img ) )
				s = DrawMobInfo( g, f, false );

			e.ToolTipSize = new Size( s.Width + 4, s.Height + 4 );
		}


		private Size DrawMobInfo( Graphics g, Font Font, bool DrawIt ) {
			SizeF tmpSize = g.MeasureString( "A", Font );
			Font fontBase = new Font( Font, FontStyle.Regular );
			Font fontBold = new Font( Font, FontStyle.Bold );

			string drawText = string.Empty;
			Size letterSize = new Size( (int)tmpSize.Width, (int)tmpSize.Height );
			int startX = 2;
			int x = startX, maxX = 0;
			int y = startX;

			x = startX;

			// Bossinfo
			if( mMobPoint.IsBoss == true ) {
				x += DrawText( g, fontBase, ForeColor, x, y, "-{ Boss Monster }-", DrawIt );
				maxX = Math.Max( x, maxX );
				y += letterSize.Height;
				x = startX;
			}

			// Name
			x += DrawText( g, fontBase, ForeColor, x, y, "Name", DrawIt );
			// : X
			x += DrawText( g, fontBase, ForeColor, x, y, ": " + mMobPoint.Name, DrawIt );
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			// Level
			x += DrawText( g, fontBase, ForeColor, x, y, "Level", DrawIt );
			// : X
			x += DrawText( g, fontBase, ForeColor, x, y, ": " + mMobPoint.Level, DrawIt );
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			// Anzahl
			x += DrawText( g, fontBase, ForeColor, x, y, "Anzahl", DrawIt );
			// : X
			x += DrawText( g, fontBase, ForeColor, x, y, ": " + mMobPoint.Anzahl, DrawIt );
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			// Element
			x += DrawText( g, fontBase, ForeColor, x, y, "Element", DrawIt );
			// : [to avoid colored :]
			x += DrawText( g, fontBase, ForeColor, x, y, ": ", DrawIt );
			// X
			x += DrawText( g, fontBase, mMobPoint.Element.ToColor( true ), x, y, mMobPoint.Element.ToString(), DrawIt );
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			// MobInfo
			if( mMobPoint.InfoDesc != string.Empty ) {
				x += DrawText( g, fontBase, ForeColor, x, y, "MobInfo", DrawIt );
				// : X			
				x += DrawText( g, fontBase, ForeColor, x, y, ": " + mMobPoint.InfoDesc, DrawIt );
				maxX = Math.Max( x, maxX );
				y += letterSize.Height;
			}

			return new Size( maxX, y - 5 );
		}


		private int DrawText( Graphics g, Font font, Color col, int x, int y, string Text, bool DrawIt ) {
			if( DrawIt == true )
				g.DrawString( Text, font, new SolidBrush( col ), x, y );
			int width = (int)g.MeasureString( Text, font ).Width;
			if( font.Style == FontStyle.Bold )
				width -= 4;
			return width;
		}

	}

}
