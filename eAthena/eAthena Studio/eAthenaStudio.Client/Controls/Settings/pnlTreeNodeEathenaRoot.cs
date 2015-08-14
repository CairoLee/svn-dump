using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace eAthenaStudio.Client {

	public partial class pnlTreeNodeEathenaRoot : pnlTreeNode {
		public string EathenaRootFolder {
			get;
			set;
		}


		public pnlTreeNodeEathenaRoot() {
			InitializeComponent();
		}


		private void btnOpen_Click(object sender, EventArgs e) {
			using (FolderBrowserDialog dlg = new FolderBrowserDialog()) {
				dlg.Description = "Wähle dein eAthena Verzeichnis aus";
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return;

				txtPath.Text = EathenaRootFolder = dlg.SelectedPath;
			}
		}

	}

}
