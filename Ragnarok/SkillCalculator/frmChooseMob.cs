using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Ragnarok.SkillCalculator.Library;
using GodLesZ.Ragnarok.SkillCalculator.Library.Controls;

namespace GodLesZ.Ragnarok.SkillCalculator {

	public partial class frmChooseMob : Form {
		private MobDBMob mSelectedMob = null;

		public MobDBMob SelectedMob {
			get { return mSelectedMob; }
		}


		public frmChooseMob(MobDBMobList mobs) {
			InitializeComponent();

			pnlMobs.Controls.Clear();
			for (int i = 0; i < mobs.Count; i++) {
				MobPanel pnl = new MobPanel();
				pnl.Mob = mobs[i];
				pnl.Location = new Point((pnl.Width + 2) * pnlMobs.Controls.Count, 2);

				pnlMobs.Controls.Add(pnl);
			}
		}


		private void btnSelect_Click(object sender, EventArgs e) {
			Close();
		}

	}

}
