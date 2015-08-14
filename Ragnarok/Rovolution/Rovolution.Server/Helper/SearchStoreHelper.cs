using System.Collections.Generic;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Helper {

	public class SearchStoreHelper {
		public struct SearchStoreSearchData {
			public Character SearchChar;
			public List<DatabaseID> Items;
			public List<DatabaseID> Cards;
			public uint PriceMin;
			public uint PriceMax;
		}

		public struct SearchStoreItemInfo {
			public WorldID StoreID;
			public WorldID AccountID;
			public string Name;
			public DatabaseID NameID;
			public ushort Amount;
			public uint Price;
			public short[] Card;
			public byte Refine;
		}

		public struct SearchStoreInfo {
			public uint Count;
			public List<SearchStoreItemInfo> Items;
			// amount of pages already sent to client
			public uint Pages;
			public uint Uses;
			public int RemoteID;
			public long NextQueryTime;
			// 0 = Normal (display coords), 1 = Cash (remote open store)
			public ushort Effect;
			// 0 = Vending, 1 = Buying Store
			public byte Type;
			public bool Open;
		}

	}

}
