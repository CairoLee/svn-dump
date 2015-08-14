using System;
using System.Collections;
using System.Windows.Forms;
using GodLesZ.Library.Controls;
using GodLesZ.SiedlerOnline.TradeListener.Library;

namespace GodLesZ.SiedlerOnline.TradeListener.Controls {

	public class TradeColumnComparer : IComparer {
		private OLVColumn mColumn;
		private SortOrder mSortOrder;


		public TradeColumnComparer(OLVColumn col, SortOrder order) {
			mColumn = col;
			mSortOrder = order;
		}


		public int Compare(object x, object y) {
			int result = 0;
			if (mSortOrder == SortOrder.None) {
				return 0;
			}

			DsoTrade tradeX = (x as DsoTrade);
			DsoTrade tradeY = (y as DsoTrade);

			// Handle nulls
			bool xIsNull = (x == null);
			bool yIsNull = (y == null);
			if (xIsNull || yIsNull) {
				if (xIsNull && yIsNull) {
					result = 0;
				} else {
					result = (xIsNull ? -1 : 1);
				}
			} else {
				// @TODO: Uses hardcoded column names..

				if (mColumn.Name == "colDate") {
					result = tradeX.Timestamp.CompareTo(tradeY.Timestamp);
				} else if (mColumn.Name == "colOfferedItem") {
					result = tradeX.OfferedItem.CompareTo(tradeY.OfferedItem);
					if (result == 0) {
						result = tradeX.OfferedItemAmount.CompareTo(tradeY.OfferedItemAmount);
					}
				} else if (mColumn.Name == "colDemandedItem") {
					result = tradeX.DemandedItem.CompareTo(tradeY.DemandedItem);
					if (result == 0) {
						result = tradeX.DemandedItemAmount.CompareTo(tradeY.DemandedItemAmount);
					}
				} else if (mColumn.Name == "colRatio") {
					result = tradeX.Ratio.CompareTo(tradeY.Ratio);
				} else if (mColumn.Name == "colAverage") {
					AverageCounter avgX = frmMain.ItemStats.GetAverage(tradeX.OfferedItem, tradeX.DemandedItem);
					AverageCounter avgY = frmMain.ItemStats.GetAverage(tradeY.OfferedItem, tradeY.DemandedItem);
					if (avgX == null && avgY == null) {
						result = 0;
					} else {
						result = (avgX == null ? -1 : (avgY == null ? 1 : avgX.Value.CompareTo(avgY.Value)));
					}
				} else if (mColumn.Name == "colPlayer") {
					result = string.Compare(tradeX.Player, tradeY.Player, StringComparison.CurrentCultureIgnoreCase);
				} else {
					result = CompareValues(x, y);
				}
			}

			if (mSortOrder == SortOrder.Descending) {
				result = 0 - result;
			}
			return result;
		}

		public int CompareValues(object x, object y) {
			// DsoTrade is comapareable
			if (x is IComparable) {
				return (x as IComparable).CompareTo(y);
			}

			// Force case insensitive compares on strings
			string xStr = x as string;
			if (xStr != null) {
				return string.Compare(xStr, (string)y, StringComparison.CurrentCultureIgnoreCase);
			} else {
				IComparable comparable = x as IComparable;
				if (comparable != null) {
					return comparable.CompareTo(y);
				}

				return 0;
			}
		}

	}

}
