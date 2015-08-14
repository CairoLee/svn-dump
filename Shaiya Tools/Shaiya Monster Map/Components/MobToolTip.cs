using System;
using System.Drawing;
using System.Windows.Forms;

using ShaiyaMonsterMap.Structs;
using ShaiyaMonsterMap.Enumerations;

namespace ShaiyaMonsterMap.Components {

	public class MobToolTip : ColorToolTip {

		public override SizeF DrawTooltip( Graphics g, Font Font, bool DrawIt ) {
			SizeF tmpSize = g.MeasureString( "A", Font );
			Font fontBase = new Font( Font, FontStyle.Regular );
			Font fontBold = new Font( Font, FontStyle.Bold );
			SMobPoint p = InfoPoint as SMobPoint;

			string drawText = string.Empty;
			Size letterSize = new Size( (int)tmpSize.Width, (int)tmpSize.Height );
			int startX = 2;
			float x = startX, maxX = 0;
			float y = startX;

			x = startX;

			// Bossinfo
			if( p.IsBoss == true ) {
				x += DrawText( g, fontBold, ForeColor, x, y, "-{ Boss Monster }-", DrawIt );
				maxX = Math.Max( x, maxX );
				y += letterSize.Height;
				x = startX;
			}

			// Name
			x += DrawText( g, fontBold, ForeColor, x, y, "Name", DrawIt );
			// : X
			x += DrawText( g, fontBase, ForeColor, x, y, ": " + p.Name, DrawIt );
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			// Level
			x += DrawText( g, fontBold, ForeColor, x, y, "Level", DrawIt );
			// : X
			x += DrawText( g, fontBase, ForeColor, x, y, ": " + p.Level, DrawIt );
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			// Anzahl
			x += DrawText( g, fontBold, ForeColor, x, y, "Anzahl", DrawIt );
			// : X
			x += DrawText( g, fontBase, ForeColor, x, y, ": " + p.Anzahl, DrawIt );
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			// Element
			x += DrawText( g, fontBold, ForeColor, x, y, "Element", DrawIt );
			// : [to avoid colored :]
			x += DrawText( g, fontBase, ForeColor, x, y, ": ", DrawIt );
			// X
			x += DrawText( g, fontBase, p.Element.ToColor( true ), x, y, p.Element.ToString() + " ", DrawIt );
			if( p.Element != EMobElement.Unbekannt ){
				g.DrawImage( p.Element.ToImage(), new Rectangle( (int)x, (int)y, letterSize.Height, letterSize.Height ) );
				x += p.Element.ToImage().Width;
			}
			maxX = Math.Max( x, maxX );
			y += letterSize.Height;
			x = startX;

			// MobInfo
			if( p.InfoDesc != string.Empty ) {
				x += DrawText( g, fontBold, ForeColor, x, y, "MobInfo", DrawIt );
				// : X			
				x += DrawText( g, fontBase, ForeColor, x, y, ": " + p.InfoDesc, DrawIt );
				maxX = Math.Max( x, maxX );
				y += letterSize.Height;
			}

			return new SizeF( maxX, y );
		}

	}

}
