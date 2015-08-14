using System.Windows.Forms;
using GodLesZ.Library.Controls;

namespace GodLesZ.SiedlerOnline.TradeListener.Controls {

	public class FilterableFastListViewDataSource : FastObjectListDataSource {

		public FilterableFastListViewDataSource(FastObjectListView folv)
			: base(folv) {
		}


		public override void Sort(OLVColumn column, SortOrder sortOrder) {
			if (sortOrder != SortOrder.None)
				filteredObjectList.Sort(new TradeColumnComparer(column, sortOrder));
			this.RebuildIndexMap();
		}

	}

}
