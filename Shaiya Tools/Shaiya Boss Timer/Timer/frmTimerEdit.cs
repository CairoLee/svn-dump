using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sbt {

	public partial class frmTimerEdit : Form {

		public frmTimerEdit() {
			InitializeComponent();

			cbMode.SelectedIndex = 0;
		}

		private void btnCancle_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void btnSave_Click( object sender, EventArgs e ) {
			this.Close();
		}

	}

}
