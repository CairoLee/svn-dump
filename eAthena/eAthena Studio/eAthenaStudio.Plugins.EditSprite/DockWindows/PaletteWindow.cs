using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Docking;

namespace eAthenaStudio.Plugins.EditSprite {

	public partial class PaletteWindow : DockContent {

		public PaletteWindow() {
			InitializeComponent();
		}


		public void SetStatusRGB(string RgbInfo) {
			lblStatusColorRGB.Text = RgbInfo;
		}

	}

}
