using System.Windows.Forms;

namespace eAthenaStudio.Library.Forms {
	public partial class frmOverwriteFile : Form {
		public frmOverwriteFile(string FileName) {
			InitializeComponent();
			this.labelText.Text = this.labelText.Text.Replace("#", FileName);
		}

		private void buttonOverwrite_Click(object sender, System.EventArgs e) {
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void buttonRename_Click(object sender, System.EventArgs e) {
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		private void buttonCancel_Click(object sender, System.EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
