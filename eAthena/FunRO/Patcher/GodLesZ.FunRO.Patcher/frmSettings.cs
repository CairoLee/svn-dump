using System;
using System.Windows.Forms;

namespace GodLesZ.FunRO.Patcher {

	public partial class frmSettings : Form {

		public ELayout SelectedLayout {
			get {
				ELayout ret = ELayout.Default;
				if (rdbLayoutGray.Checked) {
					ret = ELayout.Gray;
				} else if (rdbLayoutGreen.Checked) {
					ret = ELayout.Green;
				} else if (rdbLayoutRed.Checked) {
					ret = ELayout.Red;
				}

				return ret;
			}
		}

		public frmSettings() {
			InitializeComponent();

			switch (Properties.Settings.Default.Layout) {
				case ELayout.Gray:
					rdbLayoutGray.Checked = true;
					break;
				case ELayout.Red:
					rdbLayoutRed.Checked = true;
					break;
				case ELayout.Green:
					rdbLayoutGreen.Checked = true;
					break;
				case ELayout.Default:
				default:
					rdbLayoutDefault.Checked = true;
					break;
			}
		}


		private void imgLayoutDefault_Click(object sender, EventArgs e) {
			rdbLayoutDefault.Checked = true;
		}

		private void imgLayoutRed_Click(object sender, EventArgs e) {
			rdbLayoutRed.Checked = true;
		}

		private void imgLayoutGreen_Click(object sender, EventArgs e) {
			rdbLayoutGreen.Checked = true;
		}

		private void imgLayoutGray_Click(object sender, EventArgs e) {
			rdbLayoutGray.Checked = true;
		}


		private void btnSave_Click(object sender, EventArgs e) {
			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Hide();
		}

	}

}
