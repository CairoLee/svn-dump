using System;

namespace GodLesZ.SiedlerOnline.TradeListener.Controls {

	[Flags()]
	public enum ETradeListViewFilterType : byte {
		Equal = 0,
		Higher = 1,
		Lower = 2
	}

}
