using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Healbot {

	public partial class frmHealsettings : Form {

		public frmHealsettings() {
			InitializeComponent();
		}



		private void btnSave_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.HealPlayer1 = numHeal1.Value;
			Properties.Settings.Default.HealPlayer2 = numHeal2.Value;
			Properties.Settings.Default.HealPlayer3 = numHeal3.Value;
			Properties.Settings.Default.HealPlayer4 = numHeal4.Value;
			Properties.Settings.Default.HealPlayer5 = numHeal5.Value;
			Properties.Settings.Default.HealPlayer6 = numHeal6.Value;
			Properties.Settings.Default.HealPlayer7 = numHeal7.Value;

			this.Close();
		}

	}

}
