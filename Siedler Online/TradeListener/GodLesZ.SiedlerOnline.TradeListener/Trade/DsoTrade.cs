using System;
using GodLesZ.SiedlerOnline.TradeListener.Library;

namespace GodLesZ.SiedlerOnline.TradeListener {

	public class DsoTrade : IComparable {

		public DateTime Timestamp {
			get;
			protected set;
		}

		public string Player {
			get;
			protected set;
		}

		public EResource OfferedItem {
			get;
			protected set;
		}

		public string OfferedItemLocalized {
			get { return (OfferedItem != EResource.None ? Program.Language.GetString(OfferedItem.ToString()) : string.Empty); }
		}

		public int OfferedItemAmount {
			get;
			protected set;
		}

		public EResource DemandedItem {
			get;
			protected set;
		}

		public string DemandedItemLocalized {
			get { return (DemandedItem != EResource.None ? Program.Language.GetString(DemandedItem.ToString()) : string.Empty); }
		}

		public int DemandedItemAmount {
			get;
			protected set;
		}

		public double Ratio {
			get;
			protected set;
		}

		public bool IsClear {
			get;
			protected set;
		}

		public bool IsExpired {
			get {
				return ((DateTime.Now - Timestamp).TotalSeconds > 600);
			}
		}


		public DsoTrade(DsoChatPacketMessage message, string player)
			: this(message.MessageBody, player) {
		}

		public DsoTrade(string message, string player) {
			Timestamp = DateTime.Now;
			Player = player;

			ParseMessage(message);
		}


		public static DsoTrade Create(DsoChatPacketMessage message, string player) {
			return Create(message.MessageBody, player);
		}

		public static DsoTrade Create(string message, string player) {
			DsoTrade trade = null;
			try {
				trade = new DsoTrade(message, player);
			} catch {
				return null;
			}
			return trade;
		}


		private void ParseMessage(string message) {
			if (string.IsNullOrEmpty(message)) {
				throw new ArgumentException("Invalid trade content: " + message, message);
			}
			string[] parts = message.Split('|');
			if (parts.Length != 4) {
				if (message.ToLower() == "clear") {
					IsClear = true;
					return;
				}
				throw new Exception("Invalid trade content: " + message);
			}

			OfferedItem = (EResource)Enum.Parse(typeof(EResource), parts[0]);
			OfferedItemAmount = int.Parse(parts[1].Trim());
			DemandedItem = (EResource)Enum.Parse(typeof(EResource), parts[2]);
			DemandedItemAmount = int.Parse(parts[3].Trim());
			Ratio = ((double)OfferedItemAmount / (double)DemandedItemAmount);
		}


		public int CompareTo(object obj) {
			if (obj is DsoTrade) {
				int comp = (obj as DsoTrade).OfferedItem.CompareTo(OfferedItem);
				if (comp == 0) {
					comp = (obj as DsoTrade).DemandedItem.CompareTo(DemandedItem);
					if (comp == 0) {
						comp = (obj as DsoTrade).OfferedItemAmount.CompareTo(OfferedItemAmount);
						if (comp == 0) {
							return (obj as DsoTrade).DemandedItemAmount.CompareTo(DemandedItemAmount);
						}
					}
				}
				return comp;
			}

			return 0;
		}

	}

}
