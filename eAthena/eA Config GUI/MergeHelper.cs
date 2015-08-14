using System;
using System.Drawing;
using DevComponents.DotNetBar.Controls;

namespace eACGUI {

	public class MergeHelper {

		/// <summary>
		/// Compare 2 Grid Elements
		/// <para>Returns 0 if both are null or not compareable</para>
		/// <para>Returns 1 if GridBase was colored</para>
		/// <para>Returns 2 if GridTarget are colored</para>
		/// <para>Returns 3 if both Grids are colored</para>
		/// <para>Returns 4 if they are equal</para>
		/// </summary>
		/// <param name="GridBase"></param>
		/// <param name="GridTarget"></param>
		/// <param name="row"></param>
		/// <param name="cell"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		public static int Compare( ref DataGridViewX GridBase, ref DataGridViewX GridTarget, int row, int cell, ref Color color ) {
			color = Color.Empty;

			// first check for null, dont want highlight Comments...
			if( GridBase.Rows[ row ].Cells[ 1 ].Value == null )
				return 0;

			// is GridTarget in range?
			if( GridTarget.RowCount == 0 || row >= GridTarget.RowCount ) {
				GridBase.Rows[ row ].DefaultCellStyle.BackColor = color = Color.LightCyan;
				return 1;
			}

			// is Target Value null?
			if( GridTarget.Rows[ row ].Cells[ cell ].Value == null ) {
				// is GriddBase Value also null?
				if( GridBase.Rows[ row ].Cells[ cell ].Value == null ) // possible Comment
					return 0;
				GridBase.Rows[ row ].DefaultCellStyle.BackColor = color = Color.LightCyan;
				return 1;
			}

			// is Base Value null?
			if( GridBase.Rows[ row ].Cells[ cell ].Value == null ) {
				GridTarget.Rows[ row ].DefaultCellStyle.BackColor = color = Color.LightCyan;
				return 2;
			}

			// are they Equal?
			if( GridTarget.Rows[ row ].Cells[ cell ].Value.Equals( GridBase.Rows[ row ].Cells[ cell ].Value ) == false ) {
				GridBase.Rows[ row ].DefaultCellStyle.BackColor = color = Color.LightSalmon;
				GridTarget.Rows[ row ].DefaultCellStyle.BackColor = Color.LightSalmon;
				return 3;
			}

			// they are equal
			GridBase.Rows[ row ].DefaultCellStyle.BackColor = Color.Empty;
			GridTarget.Rows[ row ].DefaultCellStyle.BackColor = Color.Empty;

			return 4;
		}

	}

}
