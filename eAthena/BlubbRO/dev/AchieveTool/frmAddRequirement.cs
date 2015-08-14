using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AchieveTool {

	public partial class frmAddRequirement : Form {

		public int GetReqCount {
			get { return int.Parse( txtCount.Text ); }
		}

		public string GetReqParam {
			get { return txtParam.Text; }
		}


		public frmAddRequirement() {
			InitializeComponent();
		}

		private void btnOK_Click( object sender, EventArgs e ) {
			Close();
		}

	}

}
