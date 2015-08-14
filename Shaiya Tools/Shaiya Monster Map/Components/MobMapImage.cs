using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ShaiyaMonsterMap.Structs;
using ShaiyaMonsterMap.Forms;

namespace ShaiyaMonsterMap.Components {

	public class MobMapImage : MapImage {

		public override void InitToolTip() {
			mToolTip = new MobToolTip();
			base.InitToolTip();
			mToolTip.SetToolTip( this, "Dummy" );
		}

		public override int InRange( int x, int y ) {
			if( Factory == null )
				return -1;

			SMobPoint p;
			for( int i = 0; i < Factory.Points.Count; i++ ) {
				p = Factory[ i ] as SMobPoint;
				if( x >= p.RectX && x <= p.RectWidth && y >= p.RectY && y <= p.RectHeight )
					return i;
			}

			return -1;
		}


		public override void MapImage_MouseClick( object sender, MouseEventArgs e ) {
			if( MapControl.CanEdit == false )
				return;

			int i = InRange( e.X, e.Y );
			if( i == -1 && e.Button != MouseButtons.Left )
				return;

			// remove a Point
			if( e.Button == MouseButtons.Right ) {
				if( RemovePoint != null )
					RemovePoint( i );
				return;
			}

			// edit a Point
			if( e.Button == MouseButtons.Middle ) {
				mToolTip.Active = false;
				if( EditPoint != null )
					EditPoint( i, Factory[ i ].X, Factory[ i ].Y );

				return;
			}

			// add a Point
			frmMobPoint frm = new frmMobPoint( "hinzufügen..." );
			if( frm.ShowDialog() != DialogResult.OK )
				return;

			Factory.AddToList( SMobPoint.FromForm( e.X, e.Y, frm ) );

			this.Invalidate();
		}



	}

}
