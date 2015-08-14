using System;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Library.Controls;

namespace GodLesZ.SiedlerOnline.TradeListener.Controls {

	public class FilterableFastListView : FastObjectListView {

		public FilterableFastListView()
			: base() {
			AlternateRowBackColor = Color.Lavender;
			EmptyListMsg = "No messages.";
			EmptyListMsgFont = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
			FullRowSelect = true;
			GridLines = true;
			HideSelection = false;
			HighlightBackgroundColor = Color.Tan;
			HighlightForegroundColor = Color.Black;
			HeaderStyle = ColumnHeaderStyle.Clickable;
			Location = new Point(0, 0);
			Name = "filterableFastListView";
			MultiSelect = false;
			PreserveSelectionOnChange = false;
			ShowGroups = false;
			UseAlternatingBackColors = true;
			UseCompatibleStateImageBehavior = false;
			UseCustomSelectionColors = true;
			UseFiltering = true;
			View = System.Windows.Forms.View.Details;
			VirtualMode = true;

			DataSource = new FilterableFastListViewDataSource(this);
		}


		public void FilterObjects() {
			(DataSource as FilterableFastListViewDataSource).FilterObjects();
			BuildList();
		}

		protected virtual string FormatDate(DateTime date) {
			DateTime now = DateTime.Now;
			if (date.DayOfYear == now.DayOfYear) {
				return date.ToString("HH:mm:ss");
			} else if (date.DayOfYear == now.DayOfYear - 1) {
				return "Yesterday, " + date.ToString("HH:mm:ss");
			}

			return now.ToString("dd.MM.yyyy HH:mm:ss");
		}

	}

}
