using System.Drawing;
using System.Windows.Forms;

namespace ZenAIConfigPanel.Controls {

	public class ShadowLabel : Label {
		private Color mShadowColor = Color.Black;
		private Point mShadowPosition = new Point(1, 1);
		private bool mShadowToBorder = false;

		public Color ShadowColor {
			get { return mShadowColor; }
			set { mShadowColor = value; }
		}

		public Point ShadowPosition {
			get { return mShadowPosition; }
			set { mShadowPosition = value; }
		}

		public bool ShadowToBorder {
			get { return mShadowToBorder; }
			set { mShadowToBorder = value; }
		}

		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x20;
				return cp;
			}
		}


		public ShadowLabel() {
			SetStyle(ControlStyles.Opaque, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
		}


		protected override void OnPaint(PaintEventArgs e) {
			if (ShadowToBorder == false)
				e.Graphics.DrawString(Text, Font, new SolidBrush(ShadowColor), new Point(e.ClipRectangle.X + ShadowPosition.X, e.ClipRectangle.Y + ShadowPosition.Y));
			else {
				e.Graphics.DrawString(Text, Font, new SolidBrush(ShadowColor), new Point(e.ClipRectangle.X + ShadowPosition.X, e.ClipRectangle.Y));
				e.Graphics.DrawString(Text, Font, new SolidBrush(ShadowColor), new Point(e.ClipRectangle.X, e.ClipRectangle.Y + ShadowPosition.Y));
				e.Graphics.DrawString(Text, Font, new SolidBrush(ShadowColor), new Point(e.ClipRectangle.X - ShadowPosition.X, e.ClipRectangle.Y));
				e.Graphics.DrawString(Text, Font, new SolidBrush(ShadowColor), new Point(e.ClipRectangle.X, e.ClipRectangle.Y - ShadowPosition.Y));
			}
			e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(e.ClipRectangle.X, e.ClipRectangle.Y));
		}

	}

}
