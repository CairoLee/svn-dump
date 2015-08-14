using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sbt {

	public partial class frmOverlaySetting : Form {
		public OverlayChanged OnOverlayChanged;


		public frmOverlaySetting() {
			InitializeComponent();

			numX.Enabled = numY.Enabled = Properties.Settings.Default.OverlayActive;
		}

		private void btnOkay_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.Save();
			this.Close();
		}


		private void chkActive_CheckedChanged( object sender, EventArgs e ) {
			numX.Enabled = numY.Enabled = chkActive.Checked;
			Properties.Settings.Default.OverlayActive = chkActive.Checked;
			if( OnOverlayChanged != null )
				OnOverlayChanged( chkActive.Checked, (int)numX.Value, (int)numY.Value );
		}

		private void numX_ValueChanged( object sender, EventArgs e ) {
			Properties.Settings.Default.OverlayX = numX.Value;
			if( OnOverlayChanged != null )
				OnOverlayChanged( chkActive.Checked, (int)numX.Value, (int)numY.Value );
		}

		private void numY_ValueChanged( object sender, EventArgs e ) {
			Properties.Settings.Default.OverlayY = numY.Value;
			if( OnOverlayChanged != null )
				OnOverlayChanged( chkActive.Checked, (int)numX.Value, (int)numY.Value );
		}

	}

	public delegate void OverlayChanged( bool Active, int X, int Y );

}
