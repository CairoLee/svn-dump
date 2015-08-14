using System.Collections.Generic;

namespace Rovolution.Server.Helper {

	public class BuyingStoreHelper {
		public struct BuyingStoreItemData {
			public int Price;
			public ushort Amount;
			public ushort NameID;
		}

		public struct BuyingStoreData {
			public List<BuyingStoreItemData> Items;
			public int ZenyLimit;
			public byte Slots;
		}

	}

}
