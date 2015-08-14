using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GodLesZ.Ragnarok.SkillCalculator.Library.Controls {

	public partial class MobPanel : UserControl {
		private bool mIsSelected = false;
		private bool mHovered = false;
		private MobDBMob mMob = null;

		public MobDBMob Mob {
			get { return mMob; }
			set {
				mMob = value;
				UpdateControl();
			}
		}

		public bool IsSelected {
			get { return mIsSelected; }
			set {
				if (mIsSelected == value) {
					return;
				}
				MobPanelAll_Click(null, EventArgs.Empty);
			}
		}


		public MobPanel() {
			InitializeComponent();
		}


		#region MobPanel Events
		private void MobPanelAll_Click(object sender, EventArgs e) {
			mIsSelected = !mIsSelected;
			RefreshSelection();
		}

		private void MobPanelAll_MouseEnter(object sender, EventArgs e) {
			mHovered = true;
			RefreshSelection();
		}

		private void MobPanelAll_MouseLeave(object sender, EventArgs e) {
			mHovered = false;
			RefreshSelection();
		}
		#endregion


		private void RefreshSelection() {
			if (mIsSelected == false) {
				if (mHovered == true) {
					BackColor = SystemColors.ActiveCaption;
				} else {
					BackColor = Color.Transparent;
				}
			} else {
				BackColor = SystemColors.Highlight;
			}
		}

		public void UpdateControl() {
			if (Mob == null) {
				imgMob.Image = null;
				lblMobName.Text = "Name";
				pnlElement.Element = default(EElement);
				pnlElement.ElementLevel = 1;

				lblLevel.Text = lblRace.Text = "";
				lblHP.Text = lblSP.Text = "";
				return;
			}

			if (Mob.ImageExists == true) {
				imgMob.Image = Mob.Image;
			} else {
				imgMob.Image = null;
			}
			lblMobName.Text = "[" + Mob.ID + "] " + Mob.Name;
			pnlElement.Element = Mob.Element;
			pnlElement.ElementLevel = Mob.ElementLevel;

			lblLevel.Text = Mob.LV.ToString();
			lblRace.Text = Mob.Race.ToString();
			lblHP.Text = Mob.HP.ToString("###.###");
			lblSP.Text = Mob.SP.ToString("###.###");
		}

	}

	public delegate void OnMobPanelSelectHandler(bool selected);

}
