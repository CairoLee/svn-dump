using System;
using System.Xml.Serialization;
using GodLesZ.Library.Controls;
using GodLesZ.SiedlerOnline.TradeListener.Library;

namespace GodLesZ.SiedlerOnline.TradeListener.Controls {

	public class TradeListViewFilter : IModelFilter {
		private string mItemOfferOperator = null;
		private string mItemDemandedOperator = null;
		private string mRatioOperator = null;

		public EResource ItemOffer {
			get;
			set;
		}

		public int ItemOfferAmount {
			get;
			set;
		}

		public ETradeListViewFilterType ItemOfferOperator {
			get;
			set;
		}

		[XmlIgnore()]
		public string ItemOfferOperatorString {
			get {
				if (mItemOfferOperator == null) {
					mItemOfferOperator = GetOperator(ItemOfferOperator);
				}
				return mItemOfferOperator;
			}
		}

		public EResource ItemDemanded {
			get;
			set;
		}

		public int ItemDemandedAmount {
			get;
			set;
		}

		public ETradeListViewFilterType ItemDemandedOperator {
			get;
			set;
		}

		[XmlIgnore()]
		public string ItemDemandedOperatorString {
			get {
				if (mItemDemandedOperator == null) {
					mItemDemandedOperator = GetOperator(ItemDemandedOperator);
				}
				return mItemDemandedOperator;
			}
		}

		public double Ratio {
			get;
			set;
		}

		public ETradeListViewFilterType RatioOperator {
			get;
			set;
		}

		[XmlIgnore()]
		public string RatioOperatorString {
			get {
				if (mRatioOperator == null) {
					mRatioOperator = GetOperator(RatioOperator);
				}
				return mRatioOperator;
			}
		}

		public string Player {
			get;
			set;
		}

		public bool IsActive {
			get;
			set;
		}


		public TradeListViewFilter() {
			IsActive = false;
			ItemOffer = EResource.None;
			ItemOfferAmount = 0;
			ItemOfferOperator = ETradeListViewFilterType.Higher;
			ItemDemanded = EResource.None;
			ItemDemandedAmount = 0;
			ItemDemandedOperator = ETradeListViewFilterType.Higher;
			Ratio = 0;
			RatioOperator = ETradeListViewFilterType.Higher;
			Player = null;
		}


		public bool Filter(object obj) {
			// Invalid trade
			if (obj == null || (obj is DsoTrade) == false) {
				return false;
			}
			// Filter empty or not active
			if (IsActive == false || IsEmpty() == true) {
				return true;
			}

			DsoTrade trade = obj as DsoTrade;

			if (ItemOffer != Library.EResource.None) {
				if (trade.OfferedItem != ItemOffer) {
					return false;
				}
			}
			if (string.IsNullOrEmpty(ItemOfferOperatorString) == false) {
				if (CompareAgainstOp(ItemOfferOperatorString, trade.OfferedItemAmount, ItemOfferAmount) == false) {
					return false;
				}
			}
			if (string.IsNullOrEmpty(ItemDemandedOperatorString) == false) {
				if (CompareAgainstOp(ItemDemandedOperatorString, trade.DemandedItemAmount, ItemDemandedAmount) == false) {
					return false;
				}
			}
			if (string.IsNullOrEmpty(RatioOperatorString) == false) {
				if (CompareAgainstOp(RatioOperatorString, trade.Ratio, Ratio) == false) {
					return false;
				}
			}
			if (string.IsNullOrEmpty(Player) == false) {
				if (Player != null && trade.Player.Contains(Player) == false) {
					return false;
				}
			}

			return true;
		}

		public bool IsEmpty() {
			if (ItemOffer == EResource.None && ItemDemanded == EResource.None && Ratio == 0) {
				return true;
			}
			return false;
		}


		public static string GetOperator(ETradeListViewFilterType op) {
			string opString = "";
			if ((op & ETradeListViewFilterType.Higher) == ETradeListViewFilterType.Higher) {
				opString += ">";
			}
			if ((op & ETradeListViewFilterType.Lower) == ETradeListViewFilterType.Lower) {
				opString += ">";
			}
			if ((op & ETradeListViewFilterType.Equal) == ETradeListViewFilterType.Equal) {
				opString += "=";
			}

			if (opString == "=") {
				opString = "==";
			}
			return opString;
		}

		public static ETradeListViewFilterType GetOperator(string op) {
			switch (op) {
				case "=":
				case "==":
					return ETradeListViewFilterType.Equal;
				case ">":
					return ETradeListViewFilterType.Higher;
				case ">=":
					return (ETradeListViewFilterType.Higher | ETradeListViewFilterType.Equal);
				case "<":
					return ETradeListViewFilterType.Lower;
				case "<=":
					return (ETradeListViewFilterType.Lower | ETradeListViewFilterType.Equal);

				default:
					throw new Exception("Unknown operator: " + op);
			}
		}

		public static bool CompareAgainstOp(string op, int valueX, int valueY) {
			return CompareAgainstOp(op, (double)valueX, (double)valueY);
		}

		public static bool CompareAgainstOp(string op, double valueX, double valueY) {
			switch (op) {
				case ">":
					return (valueX > valueY);
				case "<":
					return (valueX < valueY);
				case ">=":
					return (valueX >= valueY);
				case "<=":
					return (valueX <= valueY);
				case "=":
				case "==":
					return (valueX == valueY);
				default:
					throw new Exception("Unknown operator: " + op);
			}
		}

	}

}
