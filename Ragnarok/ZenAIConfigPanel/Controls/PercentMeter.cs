using System;
using System.Windows.Forms;

namespace ZenAIConfigPanel.Controls {

	public partial class PercentMeter : UserControl {

		public int Minimum {
			get { return trackBar.Minimum; }
			set {
				if (value < 0)
					return;
				trackBar.Minimum = value;
				numPercent.Minimum = value;
			}
		}

		public int Maximum {
			get { return trackBar.Maximum; }
			set {
				if (value <= Minimum)
					return;
				trackBar.Maximum = value;
				numPercent.Maximum = value;
			}
		}

		public int Value {
			get { return trackBar.Value; }
			set {
				if (value < Minimum || value > Maximum)
					return;
				trackBar.Value = value;
				numPercent.Value = value;
			}
		}


		public PercentMeter() {
			InitializeComponent();
		}


		private void numPercent_ValueChanged(object sender, EventArgs e) {
			int intValue = (int)numPercent.Value;
			numPercent.Value = intValue;
			if (intValue < Minimum || intValue > Maximum) {
				numPercent.Value = trackBar.Value;
				return;
			}

			trackBar.Value = intValue;
		}

		private void trackBar_Scroll(object sender, EventArgs e) {
			numPercent.Value = trackBar.Value;
		}

		private void label1_MouseEnter(object sender, EventArgs e) {
			OnMouseEnter(e);
		}

		private void trackBar_MouseEnter(object sender, EventArgs e) {
			OnMouseEnter(e);
		}

	}

}
