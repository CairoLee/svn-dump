using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ShaiyaMonsterMap.Forms;

namespace ShaiyaMonsterMap {
	public class ListViewColumnSorter : IComparer {
		/// <summary>
		/// Specifies the column to be sorted
		/// </summary>
		private int ColumnToSort;
		/// <summary>
		/// Specifies the order in which to sort
		/// </summary>
		private SortOrder OrderOfSort;
		/// <summary>
		/// Case insensitive comparer object
		/// </summary>
		private CaseInsensitiveComparer ObjectCompare;


		/// <summary>
		/// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
		/// </summary>
		public int SortColumn {
			set { ColumnToSort = value; }
			get { return ColumnToSort; }
		}

		/// <summary>
		/// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
		/// </summary>
		public SortOrder Order {
			set { OrderOfSort = value; }
			get { return OrderOfSort; }
		}


		/// <summary>
		/// Class constructor.  Initializes various elements
		/// </summary>
		public ListViewColumnSorter() {
			// Initialize the column to '0'
			ColumnToSort = 0;

			// Initialize the sort order to 'none'
			//OrderOfSort = SortOrder.None;
			OrderOfSort = SortOrder.Ascending;

			// Initialize the CaseInsensitiveComparer object
			ObjectCompare = new CaseInsensitiveComparer();
		}

		/// <summary>
		/// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
		/// </summary>
		/// <param name="x">First object to be compared</param>
		/// <param name="y">Second object to be compared</param>
		/// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
		public int Compare( object x, object y ) {
			int compareResult;
			ListViewItem listviewX, listviewY;

			listviewX = (ListViewItem)x;
			listviewY = (ListViewItem)y;

			if( SortColumn == 3 ) {
				// Anzahl
				int c1 = frmMobPoint.CountToInt( listviewX.SubItems[ ColumnToSort ].Text.Trim() );
				int c2 = frmMobPoint.CountToInt( listviewY.SubItems[ ColumnToSort ].Text.Trim() );
				compareResult = ( c1 - c2 );
			} else if( SortColumn == 1 ) {
				// Level
				string s1 = listviewX.SubItems[ ColumnToSort ].Text.Trim();
				string s2 = listviewY.SubItems[ ColumnToSort ].Text.Trim();
				int i1 = s1.IndexOf( "-" );
				int i2 = s2.IndexOf( "-" );
				// beides eine Zahl
				if( i1 == -1 && i2 == -1 )
					compareResult = ( int.Parse( s1 ) - int.Parse( s2 ) );
				else if( i1 != -1 && i2 != -1 ) {
					// beides X-X
					int l11 = int.Parse( s1.Substring( 0, i1 ) );
					int l12 = int.Parse( s2.Substring( 0, i2 ) );
					int l21 = int.Parse( s1.Substring( i1 + 1 ) );
					int l22 = int.Parse( s2.Substring( i2 + 1 ) );
					compareResult = ( l11 - l12 ) + ( l21 - l22 );
				} else {
					// eines X-X, andere Zahl
					int l11 = int.Parse( s1.Substring( 0, i1 == -1 ? s1.Length : i1 ) );
					int l12 = int.Parse( s2.Substring( 0, i2 == -1 ? s2.Length : i2 ) );
					int l21 = ( i1 == -1 ? 0 : int.Parse( s1.Substring( i1 + 1 ) ) );
					int l22 = ( i2 == -1 ? 0 : int.Parse( s2.Substring( i2 + 1 ) ) );
					compareResult = ( l11 - l12 ) + ( l21 - l22 );
				}
			} else
				compareResult = ObjectCompare.Compare( listviewX.SubItems[ ColumnToSort ].Text, listviewY.SubItems[ ColumnToSort ].Text );

			if( OrderOfSort == SortOrder.Ascending )
				return compareResult;
			if( OrderOfSort == SortOrder.Descending )
				return ( -compareResult );

			return 0;
		}

	}


}
