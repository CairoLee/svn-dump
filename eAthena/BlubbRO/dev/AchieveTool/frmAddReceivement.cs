using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AchieveTool {

	public partial class frmAddReceivement : Form {
		public static List<string> Types = new List<string>(
			new string[ 3 ]{
				"Base EXP",
				"Job EXP",
				"Zeny"
			}
		);

		public int GetRecvType {
			get { return cmbTyp.SelectedIndex + 1; }
		}

		public string GetRecvTypeName {
			get { return cmbTyp.SelectedItem.ToString(); }
		}

		public string GetRecvParam {
			get { return txtParam.Text; }
		}


		public frmAddReceivement() {
			InitializeComponent();

			cmbTyp.Items.AddRange( Types.ToArray() );
		}

		private void frmAddReceivement_Load( object sender, EventArgs e ) {
			cmbTyp.SelectedIndex = 0;
		}

		private void btnOK_Click( object sender, EventArgs e ) {
			Close();
		}

	}

}
