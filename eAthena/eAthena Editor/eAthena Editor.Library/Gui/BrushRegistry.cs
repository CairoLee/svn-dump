using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GodLesZ.eAthenaEditor.Library {

	/// <summary>
	/// Contains brushes/pens for the text editor to speed up drawing. Re-Creation of brushes and pens seems too costly.
	/// </summary>
	public class BrushRegistry {
		private static Hashtable brushes = new Hashtable();
		private static Hashtable pens = new Hashtable();
		private static Hashtable dotPens = new Hashtable();


		public static Brush GetBrush(Color color) {
			if (!brushes.Contains(color)) {
				brushes.Add(color, new SolidBrush(color));
			}
			return brushes[color] as Brush;
		}

		public static Pen GetPen(Color color) {
			if (!pens.Contains(color)) {
				pens.Add(color, new Pen(color));
			}
			return pens[color] as Pen;
		}

		public static Pen GetDotPen(Color bgColor, Color fgColor) {
			bool containsBgColor = dotPens.Contains(bgColor);
			if (!containsBgColor || !((Hashtable)dotPens[bgColor]).Contains(fgColor)) {
				if (!containsBgColor) {
					dotPens[bgColor] = new Hashtable();
				}

				HatchBrush hb = new HatchBrush(HatchStyle.Percent50, bgColor, fgColor);
				Pen newPen = new Pen(hb);
				((Hashtable)dotPens[bgColor])[fgColor] = newPen;
			}

			return ((Hashtable)dotPens[bgColor])[fgColor] as Pen;
		}

	}

}
