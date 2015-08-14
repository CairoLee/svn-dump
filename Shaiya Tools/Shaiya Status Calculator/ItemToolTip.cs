using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ssc {

	public class ItemToolTip : ToolTip {
		private SolidBrush mBackgroundBrush;
		private Pen mBorderPen;
		private Size mSockelSize = new Size( 20, 20 );
		private SItem mItem;
		private Point mPosition;

		public SItem Item {
			get { return mItem; }
			set { mItem = value; }
		}

		public Point Position {
			get { return mPosition; }
			set { mPosition = value; }
		}


		public ItemToolTip() {
			OwnerDraw = true;
			Active = false;
			AutoPopDelay = 5000;
			InitialDelay = 0;
			ReshowDelay = 0;
			UseAnimation = false;
			UseFading = false;

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
			DrawItemInfo( e.Graphics, e.Font, true );
		}

		private void MobToolTip_Popup( object sender, PopupEventArgs e ) {
			Size s;
			using( Font f = new Font( "Tahoma", 9 ) )
			using( Image img = new Bitmap( e.ToolTipSize.Width, e.ToolTipSize.Height ) )
			using( Graphics g = Graphics.FromImage( img ) )
				s = DrawItemInfo( g, f, false );

			e.ToolTipSize = new Size( s.Width + 4, s.Height + 4 );
		}


		private Size DrawItemInfo( Graphics g, Font Font, bool DrawIt ) {
			SizeF tmpSize = g.MeasureString( "A", Font );

			string drawText = string.Empty;
			Size letterSize = new Size( (int)tmpSize.Width, (int)tmpSize.Height );
			int startX = 2;
			int x = startX, maxX = 0;
			int y = startX;

			x = startX;

			// Name
			x += DrawText( g, new Font( Font, FontStyle.Bold ), ForeColor, x, y, "Name", DrawIt );
			// : X
			x += DrawText( g, new Font( Font, FontStyle.Regular ), ForeColor, x, y, ": " + mItem.Name, DrawIt );
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			for( int i = 0; i < mItem.Bonus.Count; i++ ) {
				x += DrawText( g, new Font( Font, FontStyle.Bold ), ForeColor, x, y, mItem.Bonus[ i ].Type.ToString(), DrawIt );
				x += DrawText( g, new Font( Font, FontStyle.Regular ), ForeColor, x, y, ": ", DrawIt );
				x += DrawText( g, new Font( Font, FontStyle.Regular ), ( mItem.Bonus[ i ].Value < 0 ? Color.Red : mItem.Bonus[ i ].Value > 0 ? Color.Green : ForeColor ), x, y, mItem.Bonus[ i ].Value.ToString(), DrawIt );
				maxX = Math.Max( x, maxX );
				y += letterSize.Height;
				x = startX;
			}

			if( mItem.Sockel > 0 ) {
				y += 2; // some Top-padding
				x += 1; // some Left-padding
				for( int i = 0; i < mItem.Sockel; i++ ) {
					g.FillRectangle( Brushes.Black, new Rectangle( x, y, mSockelSize.Width, mSockelSize.Height ) );
					x += mSockelSize.Width + 5;
				}

				y += mSockelSize.Height; // some Bottom-padding
				if( mItem.Bonus.Count < 3 )
					y += 2;
			}

			y -= mItem.Bonus.Count / 2;

			maxX = Math.Max( x, maxX );

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
