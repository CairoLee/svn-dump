using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Ragnarok.SkillCalculator.Library;
using GodLesZ.Library.Ragnarok.Grf;

namespace GodLesZ.Ragnarok.SkillCalculator {

	public partial class frmMain : Form {
		public MobDBMobList MobDB;
		public SkillDBSkillList SkillDB;


		public frmMain() {
			InitializeComponent();
		}


		private void frmMain_Load(object sender, EventArgs e) {

			cmbSkills.Items.AddRange(SkillDB.ToArray());
			mobPanel.Mob = null;
		}

		private void btnChooseMob_Click(object sender, EventArgs e) {
			using (frmChooseMob frm = new frmChooseMob(MobDB)) {
				if (frm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) {
					return;
				}

				mobPanel.Mob = frm.SelectedMob;
			}
		}

	}

}
