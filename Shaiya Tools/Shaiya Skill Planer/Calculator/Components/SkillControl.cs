using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Shaiya_Skill_Ressources.Structs;

namespace Ssc.Components {
	public partial class SkillControl : UserControl {

		private int mLevel = 0;
		private int mMaxLvl = 1;
		private int mRecLevel = 0;
		private int mUsedSp = 0;
		private SkillLevel[] mSkillLevel;
		private Skill mSkill;


		public SkillLevel this[ int Index ] {
			get { return mSkillLevel[ Index ]; }
		}

		public SkillLevel CurrentLevel {
			get { return mSkillLevel[ mLevel ]; }
		}

		public SkillLevel LastLevel {
			get { return mSkillLevel[ mLevel - 1 ]; }
		}

		public int CurrentLevelNum {
			get { return mLevel; }
			set { mLevel = value; }
		}

		public int MaximumLevel {
			get { return mMaxLvl; }
			set { mMaxLvl = value; }
		}

		public int RequiredLevel {
			get { return mRecLevel; }
			set { mRecLevel = value; }
		}

		public Skill Skill {
			get { return mSkill; }
		}

		public SkillLevel[] SkillLevel {
			get { return mSkillLevel; }
		}

		public int UsedSp {
			get { return mUsedSp; }
			set { mUsedSp = value; }
		}

		public string SkillName {
			get { return lblName.Text; }
		}


		public SkillControl( Skill skill ) {
			InitializeComponent();

			mSkill = skill;
			mSkillLevel = mSkill.Level.ToArray();

			pbIcon.Image = mSkill.Icon;
			lblName.Text = mSkill.Name;
			lblReqLvl.Text = "Benötigtes Level: " + mSkillLevel[ 0 ].RequiredLevel.ToString();
			lblSp.Text = "Benötigte Skillpunkte: " + mSkillLevel[ 0 ].SkillPunkte.ToString();
			mMaxLvl = mSkill.MaxLvl;
			mRecLevel = mSkillLevel[ 0 ].RequiredLevel;
		}


		public void LevelDown() {
			if( mLevel == 0 )
				return;
			mLevel--;
			mUsedSp -= mSkillLevel[ mLevel ].SkillPunkte;
			mRecLevel = mSkillLevel[ mLevel ].RequiredLevel;
			lblReqLvl.Text = "Benötigtes Level: " + mSkillLevel[ mLevel ].RequiredLevel;
			lblSp.Text = "Benötigte Skillpunkte: " + mSkillLevel[ mLevel ].SkillPunkte;
			lblName.Text = ( mLevel > 0 ? mSkillLevel[ mLevel - 1 ].Name + " (Lv. " + mLevel + ")" : mSkill.Name );
		}

		public void LevelUp() {
			if( mLevel >= mMaxLvl )
				return;
			mUsedSp += mSkillLevel[ mLevel ].SkillPunkte;
			mLevel++;
			if( mLevel < mMaxLvl ) {
				lblName.Text = mSkillLevel[ mLevel - 1 ].Name + " (Lv. " + mLevel + ")";
				lblReqLvl.Text = "Benötigtes Level: " + mSkillLevel[ mLevel ].RequiredLevel;
				lblSp.Text = "Benötigte Skillpunkte: " + mSkillLevel[ mLevel ].SkillPunkte;
				mRecLevel = mSkillLevel[ mLevel ].RequiredLevel;
				return;
			}

			lblReqLvl.Text = "Max Level";
			lblSp.Text = "Verbrauchte Skillpunkte: " + mUsedSp;
			lblName.Text = mSkillLevel[ mLevel - 1 ].Name + " (Lv. " + mLevel + ")";
		}

		public void Mark() {
			//this.BackgroundImage = Properties.Resources.border_select;
			this.BackColor = Color.FromArgb( 227, 240, 254 );
		}

		public void Unmark() {
			//this.BackgroundImage = Properties.Resources.border;
			this.BackColor = Color.Transparent;
		}

		#region Control Events
		private void Controls_MouseEnter( object sender, EventArgs e ) {
			this.OnMouseEnter( e );
		}

		private void btnUp_EnabledChanged( object sender, EventArgs e ) {
			if( btnUp.Enabled == true )
				btnUp.Image = global::Ssc.Properties.Resources.btnUp;
			else
				btnUp.Image = global::Ssc.Properties.Resources.btnUp_Disabled;
		}

		private void btnDown_EnabledChanged( object sender, EventArgs e ) {
			if( btnDown.Enabled == true )
				btnDown.Image = global::Ssc.Properties.Resources.btnDown;
			else
				btnDown.Image = global::Ssc.Properties.Resources.btnDown_Disabled;
		}
		#endregion


	}
}
