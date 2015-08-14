using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.Design;

namespace eAthenaStudio.Plugins.EditSprite.Controls {

	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
	public class ToolStripColorComboBox : ToolStripControlHost {
		private ColorComboBox mBox;
		private ImageList mImages;

		public ColorComboBox ColorBox {
			get { return mBox; }
			set { mBox = value; }
		}

		public ToolStripMenuItem IconMenuItem {
			get;
			set;
		}

		public Color SelectedColor {
			get { return ((ColorComboBox)base.Control).SelectedColor; }
		}

		public ColorComboBox ColorComboBox {
			get { return (ColorComboBox)base.Control; }
		}

		public event EventHandler SelectedColorChanged;

		public ToolStripColorComboBox()
			: base(new ColorComboBox()) {

			mBox = (ColorComboBox)base.Control;
			mBox.SelectedColorChanged += new EventHandler(mBox_SelectedColorChanged);
		}


		private void mBox_SelectedColorChanged(object sender, EventArgs e) {
			if (SelectedColorChanged != null)
				SelectedColorChanged(sender, e);
			if (IconMenuItem != null)
				IconMenuItem.Image = CreateImageIcon(SelectedColor);
		}


		private Image CreateImageIcon(Color SelectedColor) {
			Bitmap bmp = new Bitmap(16, 16);
			using (Graphics g = Graphics.FromImage(bmp))
				g.FillRectangle(new SolidBrush(SelectedColor), new Rectangle(0, 0, bmp.Width, bmp.Height));
			return bmp;
		}

	}

}
