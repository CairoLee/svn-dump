using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using eAthenaStudio.Library.Plugin;

namespace eAthenaStudio.Plugins.EditSprite {

	public class SpritePlugin : PluginBase {

		public SpritePlugin(frmPluginClient Owner)
			: base(Owner, "Sprite Editor", "Tool for Sprite edit", "GodLesZ", new Version(1, 0)) {
			mActive = true;
			mButtonImage = Properties.Resources.spriteEditor;
			mButtonImageHover = Properties.Resources.spriteEditorHover;
		}


		public override void OnPluginAddPage(Form Owner, List<string> PluginArgs) {
			frmSpriteEditor frm = new frmSpriteEditor(this, PluginArgs);
			frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
			frm.Show();
		}


		private void frm_FormClosed(object sender, FormClosedEventArgs e) {
			OnPluginPageClose();
		}

	}

}
