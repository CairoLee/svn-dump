using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Library.Controls;
using GodLesZ.SiedlerOnline.TradeListener.Controls;
using GodLesZ.SiedlerOnline.TradeListener.Library;

namespace GodLesZ.SiedlerOnline.TradeListener {

	public partial class frmTradeListFilter : Form {
		private Dictionary<string, EResource> mResourceCache = new Dictionary<string, EResource>();

		public TradeListViewFilter TradeFilter {
			get;
			private set;
		}


		public frmTradeListFilter() {
			InitializeComponent();

			TradeFilter = null;

			// Resource image list
			cmbItemOffer.ImageList = TradeListView.ResourceImages;
			cmbItemDemanded.ImageList = TradeListView.ResourceImages;

			// Fill image combobox
			int i = -1;
			EImageComboBoxTextAlign textAlign = EImageComboBoxTextAlign.Right;
			Font font = cmbItemOffer.Font;
			Color fontColor = cmbItemOffer.ForeColor;
			foreach (string resource in Enum.GetNames(typeof(EResource))) {
				if ((i = cmbItemOffer.ImageList.Images.IndexOfKey(resource)) != -1) {
					string name = Program.Language.GetString(resource);
					cmbItemOffer.Items.Add(new ImageComboBoxItem(name, font, fontColor, i, textAlign));
					cmbItemDemanded.Items.Add(new ImageComboBoxItem(name, font, fontColor, i, textAlign));
					// Add to cache (to find localized resource)
					if (mResourceCache.ContainsKey(name) == false) {
						mResourceCache.Add(name, (EResource)Enum.Parse(typeof(EResource), resource));
					}
				}
			}
			// First item: None
			cmbItemOffer.Items.Insert(0, "None");
			cmbItemOffer.SelectedIndex = 0;
			cmbItemDemanded.Items.Insert(0, "None");
			cmbItemDemanded.SelectedIndex = 0;

			// Defaul value for operator: > (Higher)
			cmbItemOfferOperator.SelectedIndex = 0;
			cmbItemDemandedOperator.SelectedIndex = 0;
			cmbRatioOperator.SelectedIndex = 0;
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			try {
				TradeFilter = new TradeListViewFilter();
				if (cmbItemOffer.SelectedIndex > 0) {
					TradeFilter.ItemOffer = mResourceCache[cmbItemOffer.SelectedItem.ToString()];
				}
				if (cmbItemOfferOperator.SelectedIndex != -1) {
					TradeFilter.ItemOfferOperator = TradeListViewFilter.GetOperator(cmbItemOfferOperator.SelectedItem.ToString());
				}
				if (txtItemOfferAmount.Text.Length > 0) {
					TradeFilter.ItemOfferAmount = int.Parse(txtItemOfferAmount.Text.Trim());
				}

				if (cmbItemDemanded.SelectedIndex > 0) {
					TradeFilter.ItemDemanded = mResourceCache[cmbItemDemanded.SelectedItem.ToString()];
				}
				if (cmbItemDemandedOperator.SelectedIndex != -1) {
					TradeFilter.ItemDemandedOperator = TradeListViewFilter.GetOperator(cmbItemDemandedOperator.SelectedItem.ToString());
				}
				if (txtItemDemandedAmount.Text.Length > 0) {
					TradeFilter.ItemDemandedAmount = int.Parse(txtItemDemandedAmount.Text.Trim());
				}

				if (cmbRatioOperator.SelectedIndex != -1) {
					TradeFilter.RatioOperator = TradeListViewFilter.GetOperator(cmbRatioOperator.SelectedItem.ToString());
				}
				if (txtRatioAmount.Text.Length > 0) {
					TradeFilter.Ratio = int.Parse(txtRatioAmount.Text.Trim());
				}

				if (txtPlayer.Text.Length > 0) {
					TradeFilter.Player = txtPlayer.Text.Trim();
				}

				TradeFilter.IsActive = chkActive.Checked;
				if (TradeFilter.IsEmpty()) {
					if (MessageBox.Show("Given filter is not valid or maybe empty." + Environment.NewLine + "Do you want to try again?", "Wrong input", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.OK) {
						TradeFilter = null;
						DialogResult = System.Windows.Forms.DialogResult.None;
						return;
					}
				}
			} catch {
				TradeFilter = null;
				DialogResult = System.Windows.Forms.DialogResult.Cancel;
				if (MessageBox.Show("Failed to parse input." + Environment.NewLine + "Do you want to try again?", "Wrong input", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.OK) {
					DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
			}

			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Hide();
		}

	}

}
