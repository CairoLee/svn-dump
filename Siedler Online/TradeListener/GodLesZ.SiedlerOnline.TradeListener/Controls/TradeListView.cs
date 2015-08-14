using System;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Library;
using GodLesZ.Library.Controls;
using GodLesZ.SiedlerOnline.TradeListener.Library;

namespace GodLesZ.SiedlerOnline.TradeListener.Controls {

	public class TradeListView : FilterableFastListView {

		public static ImageList ResourceImages {
			get;
			private set;
		}

		public TradeListViewFilterList TradeFilterList {
			get { return ModelFilter as TradeListViewFilterList; }
			set { ModelFilter = value; }
		}


		public TradeListView()
			: base() {
			#region ImageList
			if (ResourceImages == null) {
				ResourceImages = new ImageList();
				ResourceImages.TransparentColor = Color.Transparent;
				ResourceImages.ImageSize = new System.Drawing.Size(16, 16);
				ResourceImages.ColorDepth = ColorDepth.Depth32Bit;
				ResourceImages.Images.Add(EResource.Beer.ToString(), Properties.Resources.Beer);
				ResourceImages.Images.Add(EResource.Bow.ToString(), Properties.Resources.Bow);
				ResourceImages.Images.Add(EResource.Bread.ToString(), Properties.Resources.Bread);
				ResourceImages.Images.Add(EResource.Bronze.ToString(), Properties.Resources.Bronze);
				ResourceImages.Images.Add(EResource.BronzeOre.ToString(), Properties.Resources.BronzeOre);
				ResourceImages.Images.Add(EResource.BronzeSword.ToString(), Properties.Resources.BronzeSword);
				ResourceImages.Images.Add(EResource.Cannon.ToString(), Properties.Resources.Cannon);
				ResourceImages.Images.Add(EResource.Carriage.ToString(), Properties.Resources.Carriage);
				ResourceImages.Images.Add(EResource.ChristmasResource.ToString(), Properties.Resources.ChristmasResource);
				ResourceImages.Images.Add(EResource.Coal.ToString(), Properties.Resources.Coal);
				ResourceImages.Images.Add(EResource.Coin.ToString(), Properties.Resources.Coin);
				ResourceImages.Images.Add(EResource.Corn.ToString(), Properties.Resources.Corn);
				ResourceImages.Images.Add(EResource.Crossbow.ToString(), Properties.Resources.Crossbow);
				ResourceImages.Images.Add(EResource.Deer.ToString(), Properties.Resources.Deer);
				ResourceImages.Images.Add(EResource.ExoticPlank.ToString(), Properties.Resources.ExoticPlank);
				ResourceImages.Images.Add(EResource.ExoticWood.ToString(), Properties.Resources.ExoticWood);
				ResourceImages.Images.Add(EResource.Fish.ToString(), Properties.Resources.Fish);
				ResourceImages.Images.Add(EResource.Flour.ToString(), Properties.Resources.Flour);
				ResourceImages.Images.Add(EResource.Gold.ToString(), Properties.Resources.Gold);
				ResourceImages.Images.Add(EResource.GoldOre.ToString(), Properties.Resources.GoldOre);
				ResourceImages.Images.Add(EResource.Granite.ToString(), Properties.Resources.Granite);
				ResourceImages.Images.Add(EResource.GunPowder.ToString(), Properties.Resources.GunPowder);
				ResourceImages.Images.Add(EResource.HaloweenResource.ToString(), Properties.Resources.HaloweenResource);
				ResourceImages.Images.Add(EResource.Horse.ToString(), Properties.Resources.Horse);
				ResourceImages.Images.Add(EResource.Iron.ToString(), Properties.Resources.Iron);
				ResourceImages.Images.Add(EResource.IronOre.ToString(), Properties.Resources.IronOre);
				ResourceImages.Images.Add(EResource.IronSword.ToString(), Properties.Resources.IronSword);
				ResourceImages.Images.Add(EResource.Longbow.ToString(), Properties.Resources.Longbow);
				ResourceImages.Images.Add(EResource.MapPart.ToString(), Properties.Resources.MapPart);
				ResourceImages.Images.Add(EResource.Marble.ToString(), Properties.Resources.Marble);
				ResourceImages.Images.Add(EResource.Meat.ToString(), Properties.Resources.Meat);
				ResourceImages.Images.Add(EResource.Plank.ToString(), Properties.Resources.Plank);
				ResourceImages.Images.Add(EResource.RealPlank.ToString(), Properties.Resources.RealPlank);
				ResourceImages.Images.Add(EResource.RealWood.ToString(), Properties.Resources.RealWood);
				ResourceImages.Images.Add(EResource.Salpeter.ToString(), Properties.Resources.Salpeter);
				ResourceImages.Images.Add(EResource.Sausage.ToString(), Properties.Resources.Sausage);
				ResourceImages.Images.Add(EResource.Steel.ToString(), Properties.Resources.Steel);
				ResourceImages.Images.Add(EResource.SteelSword.ToString(), Properties.Resources.SteelSword);
				ResourceImages.Images.Add(EResource.Stone.ToString(), Properties.Resources.Stone);
				ResourceImages.Images.Add(EResource.Titanium.ToString(), Properties.Resources.Titanium);
				ResourceImages.Images.Add(EResource.TitaniumOre.ToString(), Properties.Resources.TitaniumOre);
				ResourceImages.Images.Add(EResource.TitaniumSword.ToString(), Properties.Resources.TitaniumSword);
				ResourceImages.Images.Add(EResource.Tool.ToString(), Properties.Resources.Tool);
				ResourceImages.Images.Add(EResource.Water.ToString(), Properties.Resources.Water);
				ResourceImages.Images.Add(EResource.Wheel.ToString(), Properties.Resources.Wheel);
				ResourceImages.Images.Add(EResource.Wood.ToString(), Properties.Resources.Wood);
			}
			#endregion

			RowHeight = 20;
			Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				new OLVColumn {
					AspectName = "Timestamp",
					IsEditable = false,
					Name = "colDate",
					Text = "Date",
					Width = 65,
					AspectToStringConverter = delegate(object x) {
						return FormatDate((DateTime)x);
					}
				},
				new OLVColumn {
					AspectName = "OfferedItemAmount",
					IsEditable = false,
					Name = "colOfferedItem",
					Text = "Offer",
					Width = 80,
					ImageGetter = delegate(object x) {
						//return (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(((DsoTrade)x).OfferedItem.ToString());
						string resName = ((DsoTrade)x).OfferedItem.ToString();
						if (ResourceImages.Images.ContainsKey(resName)) {
							return ResourceImages.Images[resName];
						}
						return null;
					}
				},
				new OLVColumn {
					AspectName = "DemandedItemAmount",
					IsEditable = false,
					Name = "colDemandedItem",
					Text = "Cost",
					Width = 80,
					ImageGetter = delegate(object x) {
						//return (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(((DsoTrade)x).DemandedItem.ToString());
						string resName = ((DsoTrade)x).DemandedItem.ToString();
						if (ResourceImages.Images.ContainsKey(resName)) {
							return ResourceImages.Images[resName];
						}
						System.Diagnostics.Debug.WriteLine("Unknown image: " + resName);
						return null;
					}
				},
				new OLVColumn {
					AspectName = "Ratio",
					IsEditable = false,
					Name = "colRatio",
					Text = "Ratio",
					Width = 80,
					AspectToStringConverter = delegate(object x) {
						return AverageCounter.FormatDouble((double)x);
					}
				},
				new OLVColumn {
					IsEditable = false,
					Name = "colAverage",
					Text = "∅ Avg",
					Width = 80,
					AspectGetter = delegate(object x) {
						DsoTrade trade = (DsoTrade)x;
						AverageCounter avg = frmMain.ItemStats.GetAverage(trade.OfferedItem, trade.DemandedItem);
						if (avg == null) {
							return AverageCounter.FormatDouble(trade.Ratio);
						}

						return avg.ValueFormatted;
					}
				},
				new OLVColumn {
					AspectName = "Player",
					IsEditable = false,
					Name = "colPlayer",
					Text = "Player",
					Width = 120
				}
			});

			// Format rows different based on ratio and average
			UseCellFormatEvents = true;
			// Show tooltips (TODO: maybe replace all tooltips with overlays? More customizeable)
			ShowItemToolTips = true;

			// Format cell tooltip delay and getter
			CellToolTip.AutoPopDelay = 30000;
			//CellToolTip.BackColor = Color.FromArgb(50, Color.Black);
			CellToolTip.HasBorder = true;
			//CellToolTip.InitialDelay = 100;
			CellToolTip.IsBalloon = false;
			//CellToolTip.ReshowDelay = 200;
			//CellToolTip.StandardIcon = (Environment.OSVersion.Version.Major >= 6 ? ToolTipControl.StandardIcons.InfoLarge : ToolTipControl.StandardIcons.Info);
			CellToolTipGetter = new CellToolTipGetterDelegate(OnCellToolTipGetter);

			// Model filter
			UseFiltering = true;
		}


		public void AddTrade(DsoTrade trade) {
			AddObject(trade);
		}

		public bool RemoveTrade(DsoTrade trade) {
			bool found = false;
			foreach (object obj in Objects) {
				if ((obj as DsoTrade) == null) {
					continue;
				}
				if ((obj as DsoTrade).Player == trade.Player) {
					found = true;
					break;
				}
			}

			if (found) {
				RemoveObject(trade);
			}
			return found;
		}

		protected override string FormatDate(DateTime date) {
			// Only need the current time, because a trade is valid for 10 minutes
			return date.ToStringToday();
		}

		private string OnCellToolTipGetter(OLVColumn column, object x) {
			DsoTrade trade = (DsoTrade)x;
			AverageCounter avg = frmMain.ItemStats.GetAverage(trade.OfferedItem, trade.DemandedItem);

			string tooltip = "";
			if (column.Name == "colRatio") {
				CellToolTip.Title = "Average Statistics: [" + trade.OfferedItemLocalized + "] -> [" + trade.DemandedItemLocalized + "]";

				tooltip = string.Format(Program.Language.GetString("TradeListRatioToolTip"),
					AverageCounter.FormatDouble(trade.Ratio),
					avg.ValueFormatted,
					avg.Count,
					avg.Created.ToStringToday(),
					avg.Min,
					avg.MinTime.ToStringToday(),
					avg.Max,
					avg.MaxTime.ToStringToday()
				);
			} else if (column.Name == "colOfferedItem") {
				CellToolTip.Title = "Top 10 Resources demanded for [" + trade.OfferedItemLocalized + "]";

				var list = frmMain.ItemStats.GetSortedStorage(trade.OfferedItem, false);
				if (list.Count == 0) {
					tooltip += "-- Nothing found --";
				} else {
					for (int i = 0; i < 10 && i < list.Count; i++) {
						string resDemandedLocal = Program.Language.GetString(list[i].ResourceDemanded.ToString());
						double valueDemanded = (1d / list[i].Value);
						tooltip += string.Format("{0:00}\t{1} {2} for 1 {3} ({4} values)\n", i + 1, AverageCounter.FormatDouble(valueDemanded), resDemandedLocal, trade.OfferedItemLocalized, list[i].Count);
					}
				}
			} else if (column.Name == "colDemandedItem") {
				CellToolTip.Title = "Top 10 Resources offered for [" + trade.DemandedItemLocalized + "]";

				var list = frmMain.ItemStats.GetSortedStorage(trade.DemandedItem, true);
				if (list.Count == 0) {
					tooltip += "-- Nothing found --";
				} else {
					for (int i = 0; i < 10 && i < list.Count; i++) {
						string resOfferedLocal = Program.Language.GetString(list[i].Resource.ToString());
						tooltip += string.Format("{0:00}\t{1} {2} for 1 {3} ({4} values)\n", i + 1, list[i].ValueFormatted, resOfferedLocal, trade.DemandedItemLocalized, list[i].Count);
					}
				}
			}

			return tooltip;
		}

		protected override void OnFormatRow(FormatRowEventArgs args) {
			base.OnFormatRow(args);

			DsoTrade trade = (DsoTrade)args.Model;
			AverageCounter avg = frmMain.ItemStats.GetAverage(trade.OfferedItem, trade.DemandedItem);
			// Highlight good trades (ratio is lower than average)
			if (avg != null && avg.Value > trade.Ratio) {
				args.Item.BackColor = Color.FromArgb(192, 255, 192); // Light green
			}
			// Highligh bad trades (ratio is higher than average)
			if (avg != null && avg.Value < trade.Ratio) {
				args.Item.BackColor = Color.FromArgb(255, 192, 192); // Light red
			}
		}

	}

}
