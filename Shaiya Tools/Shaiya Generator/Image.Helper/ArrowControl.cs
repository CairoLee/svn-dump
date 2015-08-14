using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageHelper {

	public partial class ArrowControl : UserControl {

		[Browsable( true )]
		public int MinimumX {
			get { return (int)numX.Minimum; }
			set { numX.Minimum = value; }
		}

		[Browsable( true )]
		public int MaximumX {
			get { return (int)numX.Maximum; }
			set { numX.Maximum = value; }
		}

		[Browsable( true )]
		public int ValueX {
			get { return (int)numX.Value; }
			set { numX.Value = value; }
		}

		[Browsable( true )]
		public int MinimumY {
			get { return (int)numY.Minimum; }
			set { numY.Minimum = value; }
		}

		[Browsable( true )]
		public int MaximumY {
			get { return (int)numY.Maximum; }
			set { numY.Maximum = value; }
		}

		[Browsable( true )]
		public int ValueY {
			get { return (int)numY.Value; }
			set { numY.Value = value; }
		}

		[Browsable( true )]
		public event EventHandler ValueChangedX;
		[Browsable( true )]
		public event EventHandler ValueChangedY;



		public ArrowControl() {
			InitializeComponent();
		}



		private void arrowTop_Click( object sender, EventArgs e ) {
			if( numY.Value - 1 >= numY.Minimum )
				numY.Value--;
		}

		private void arrowRight_Click( object sender, EventArgs e ) {
			if( numX.Value + 1 <= numX.Maximum )
				numX.Value++;
		}

		private void arrowDown_Click( object sender, EventArgs e ) {
			if( numY.Value + 1 <= numY.Maximum )
				numY.Value++;
		}

		private void arrowLeft_Click( object sender, EventArgs e ) {
			if( numX.Value - 1 >= numY.Minimum )
				numX.Value--;
		}

		private void numX_ValueChanged( object sender, EventArgs e ) {
			if( ValueChangedX != null )
				ValueChangedX( sender, e );
		}

		private void numY_ValueChanged( object sender, EventArgs e ) {
			if( ValueChangedY != null )
				ValueChangedY( sender, e );
		}

	}

}
