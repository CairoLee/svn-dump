using System;
using System.Windows.Forms;

namespace GrfEditor.Client {
	public partial class FrmSettings : Form {
		public FrmSettings() {
			InitializeComponent();
		}


		private void btnOK_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
