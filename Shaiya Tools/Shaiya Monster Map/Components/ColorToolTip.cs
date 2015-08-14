using System;
using System.Drawing;
using System.Windows.Forms;

using ShaiyaMonsterMap.Structs;
using ShaiyaMonsterMap.Enumerations;

namespace ShaiyaMonsterMap.Components {

	public class ColorToolTip : ToolTip {
		private SolidBrush mBackgroundBrush;
		private Pen mBorderPen;
		private IPoint mInfoPoint;
		private Timer mTimeout;
		private Font mDrawFont;

		public IPoint InfoPoint {
			get { return mInfoPoint; }
			set { mInfoPoint = value; }
		}


		public ColorToolTip() {
			OwnerDraw = true;

			mDrawFont = new Font( "Tahoma", 9 );

			mTimeout = new Timer();
			mTimeout.Interval = 100;
			mTimeout.Tick += new EventHandler( mTimeout_Tick );

			Draw += new DrawToolTipEventHandler( ColorToolTip_Draw );
			Popup += new PopupEventHandler( ColorToolTip_Popup );
		}


		private void mTimeout_Tick( object sender, EventArgs e ) {
			if( this.Active == true )
				return;
		}


		public virtual SizeF DrawTooltip( Graphics g, Font Font, bool DrawIt ) {
			return new SizeF( 0, 0 );
		}


		public void ColorToolTip_Draw( object sender, DrawToolTipEventArgs e ) {
			if( mBackgroundBrush == null )
				mBackgroundBrush = new SolidBrush( BackColor );
			if( mBorderPen == null )
				mBorderPen = new Pen( Color.Black, 2 );

			Size size = new Size( e.Bounds.Width, e.Bounds.Height );

			e.Graphics.FillRectangle( mBackgroundBrush, 0, 0, size.Width, size.Height );
			e.Graphics.DrawRectangle( mBorderPen, 0, 0, size.Width, size.Height );
			DrawTooltip( e.Graphics, mDrawFont, true );
		}

		public void ColorToolTip_Popup( object sender, PopupEventArgs e ) {
			SizeF s;
			// fake a Draw to get final Size
			using( Image img = new Bitmap( e.ToolTipSize.Width, e.ToolTipSize.Height ) ) {
				using( Graphics g = Graphics.FromImage( img ) ) {
					s = DrawTooltip( g, mDrawFont, false );
				}
			}

			e.ToolTipSize = new Size( (int)s.Width + 4, (int)s.Height + 4 );
		}


		public float DrawText( Graphics g, Font font, Color col, float x, float y, string Text, bool DrawIt ) {
			if( DrawIt == true )
				g.DrawString( Text, font, new SolidBrush( col ), x, y );
			float width = g.MeasureString( Text, font ).Width;
			//if( font.Style == FontStyle.Bold )
			//	width -= 4;
			return width;
		}

	}

}
