using System;
using System.IO;
using System.Windows.Forms;

namespace eAthenaStudio.Library.Forms {
	public partial class frmRenameFile : Form {
		public frmRenameFile(string OldFileName, string FilePath, string FileExtension) {
			InitializeComponent();
			this.labelOldName.Text = this.labelOldName.Text.Replace("#", OldFileName);
			this.labelPath.Text = FilePath;
			this.labelExtension.Text = FileExtension;
			this.toolTip1.SetToolTip(labelOldName, this.labelOldName.Text);
			this.toolTip1.SetToolTip(labelPath, FilePath);
		}

		private void textBoxNewName_TextChanged(object sender, EventArgs e) {
			this.buttonOK.Enabled = !(File.Exists(this.labelPath.Text + this.textBoxNewName.Text + this.labelExtension.Text));
		}

		private void buttonOK_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
