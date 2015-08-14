using System.Drawing;
using System.Windows.Forms;
using ZenAIConfigPanel.Library;

namespace ZenAIConfigPanel.Controls {

	public partial class SkillPanel : UserControl {
		private HomuSkill mSkill = HomuSkill.Empty;

		public Image SkillImage {
			get { return imgSkill.Image; }
			set { imgSkill.Image = value; }
		}

		public HomuSkill Skill {
			get {
				mSkill.Level = cmbSkillLevel.SelectedIndex;
				int minSP;
				if (int.TryParse(txtSkillMinSP.Text, out minSP) == false)
					minSP = 0;
				mSkill.MinSP = minSP;
				return mSkill;
			}
			set {
				if (value == null)
					return;
				mSkill = value;
				ApplySkill();
			}
		}


		public SkillPanel() {
			InitializeComponent();
		}


		private void ApplySkill() {
			cmbSkillLevel.SelectedIndex = mSkill.Level;
			txtSkillMinSP.Text = mSkill.MinSP.ToString();
			lblSkillName.Text = mSkill.NameInternal;
		}

	}

}
