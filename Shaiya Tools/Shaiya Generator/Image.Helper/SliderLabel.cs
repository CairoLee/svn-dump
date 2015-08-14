using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageHelper {

	public partial class SliderLabel : UserControl {
		private string mText = "{0}";

		[Browsable( true )]
		public int Minimum {
			get { return progressBar.Minimum; }
			set { progressBar.Minimum = value; }
		}

		[Browsable( true )]
		public int Maximum {
			get { return progressBar.Maximum; }
			set { progressBar.Maximum = value; }
		}

		[Browsable( true )]
		public int Value {
			get { return progressBar.Value; }
			set { progressBar.Value = value; }
		}

		[Browsable( true )]
		public string Text {
			get { return mText; }
			set {
				mText = value;
				lblProgress.Text = string.Format( mText, progressBar.Value );
			}
		}

		[Browsable( true )]
		public event EventHandler ValueChanged;


		public SliderLabel() {
			InitializeComponent();

			lblProgress.Text = string.Format( mText, progressBar.Value );
		}

		private void SliderLabel_SizeChanged( object sender, EventArgs e ) {
			int sliderDiff = 34;
			int labelPosDiff = 1;

			progressBar.Size = new Size( this.Size.Width - sliderDiff, this.Size.Height );
			lblProgress.Location = new Point( progressBar.Size.Width + labelPosDiff, lblProgress.Location.Y );
		}

		private void SliderLabel_BackColorChanged( object sender, EventArgs e ) {
			try { progressBar.BackColor = this.BackColor; } catch { }
			try { lblProgress.BackColor = this.BackColor; } catch { }
		}

		private void progressBar_ValueChanged( object sender, EventArgs e ) {
			lblProgress.Text = string.Format( mText, progressBar.Value );
			if( ValueChanged != null )
				ValueChanged( sender, e );
		}

	}

}
