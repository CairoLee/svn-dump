using System;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Library;
using GodLesZ.Library.Controls;

namespace GodLesZ.SiedlerOnline.TradeListener {

	public partial class frmLanguage : Form {

		public string SelectedLanguage {
			get { return (cmbLanguage.SelectedIndex == -1 ? null : cmbLanguage.SelectedItem.ToString()); }
		}


		public frmLanguage()
			: this(ELanguage.None) {
		}

		public frmLanguage(ELanguage selectedLang) {
			InitializeComponent();

			// Fill image combobox
			int i = 0, selectedIndex = -1;
			EImageComboBoxTextAlign textAlign = EImageComboBoxTextAlign.Right;
			Font font = cmbLanguage.Font;
			Color fontColor = cmbLanguage.ForeColor;
			foreach (string langName in Enum.GetNames(typeof(ELanguage))) {
				if (langName != "None") {
					cmbLanguage.Items.Add(new ImageComboBoxItem(langName, font, fontColor, i, textAlign));

					if (langName == selectedLang.ToString()) {
						selectedIndex = i;
					}
					i++;
				}
			}

			if (selectedIndex != -1) {
				cmbLanguage.SelectedIndex = selectedIndex;

				// Hardcoded, sorry..
				switch (selectedLang.ToString().ToLower()) {
					case "german":
						imgLanguage.Image = Properties.Resources.flag_germany;
						Icon = Properties.Resources.flag_germany_icon;
						break;
					case "english":
						imgLanguage.Image = Properties.Resources.flag_great_britain;
						Icon = Properties.Resources.flag_great_britain_icon;
						break;
				}
			}
		}


		private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e) {
			btnChoose.Enabled = (cmbLanguage.SelectedIndex != -1);
		}

		private void btnChoose_Click(object sender, EventArgs e) {
			Hide();
		}

	}

}
