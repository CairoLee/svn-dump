using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eAthenaStudio.Plugins.EditSprite {

	public partial class frmSpriteExtract : Form {
		public string ExtractPath {
			get { return textBox1.Text; }
		}

		public bool Transparency {
			get { return chkTransparency.Checked; }
		}


		public frmSpriteExtract(int Frames) {
			InitializeComponent();

			for (int i = 0; i < Frames; i++)
				checkedFrames.Items.Add("Frame " + (i + 1), false);
			checkedFrames.SetItemChecked(0, true);
		}


		public int[] GetCheckedFrames() {
			if (checkedFrames.CheckedItems.Count == 0)
				return new int[0];
			int[] checks = new int[checkedFrames.CheckedItems.Count];
			for (int i = 0; i < checks.Length; i++)
				checks[i] = checkedFrames.CheckedIndices[i];
			return checks;
		}


		private void checkedFrames_ItemCheck(object sender, ItemCheckEventArgs e) {
			if (e.NewValue != CheckState.Checked) {
				btnExtract.Enabled = (checkedFrames.CheckedItems.Count > 0 && textBox1.Text.Length > 0);
				return;
			}
			btnExtract.Enabled = (textBox1.Text.Length > 0);
		}

		private void chkAllFrames_CheckedChanged(object sender, EventArgs e) {
			bool check = chkAllFrames.Checked;
			for (int i = 0; i < checkedFrames.Items.Count; i++)
				checkedFrames.SetItemChecked(i, check);
			btnExtract.Enabled = (checkedFrames.CheckedItems.Count > 0 && textBox1.Text.Length > 0);
		}

		private void btnOpenFolder_Click(object sender, EventArgs e) {
			using (FolderBrowserDialog dlg = new FolderBrowserDialog()) {
				dlg.Description = "Wähle eine Zielordner. In diesem wird ein neuer Ordner stellt, wenn du mehr als eine Frame entpackst.";
				if (dlg.ShowDialog() != DialogResult.OK)
					return;

				textBox1.Text = dlg.SelectedPath;
				btnExtract.Enabled = btnExtract.Enabled = (checkedFrames.CheckedItems.Count > 0);
			}
		}

		private void btnExtract_Click(object sender, EventArgs e) {
			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Hide();
		}

	}

}
