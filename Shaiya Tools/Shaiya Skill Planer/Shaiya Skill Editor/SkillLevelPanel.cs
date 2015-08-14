using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shaiya_Skill_Ressources.Structs;

namespace Shaiya_Skill_Editor {

	public partial class SkillLevelPanel : UserControl {

		public SkillLevelPanel() {
			InitializeComponent();
		}



		public void Clear() {
			cbElement.SelectedIndex = 0;

			txtAoeRange.Text =
			txtCasttime.Text =
			txtCooldown.Text =
			txtDesc.Text =
			txtEffect.Text =
			txtHP.Text =
			txtMP.Text =
			txtName.Text =
			txtNeededLevel.Text =
			txtPoints.Text =
			txtRange.Text =
			txtSP.Text = string.Empty;

			chkHPPerc.Checked =
			chkMPPerc.Checked =
			chkSPPerc.Checked = false;
		}


		public void SetSkill( SkillLevel Level ) {
			cbElement.SelectedIndex = (int)Level.Element;

			txtAoeRange.Text = Level.AoE.ToString();
			txtCasttime.Text = Level.CastTime.ToString();
			txtCooldown.Text = Level.Delay.ToString();
			txtDesc.Text = Level.Description;
			txtEffect.Text = Level.Status;
			txtMP.Text = Level.Mana.ToString();
			txtName.Text = Level.Name;
			txtNeededLevel.Text = Level.RequiredLevel.ToString();
			txtPoints.Text = Level.SkillPunkte.ToString();
			txtRange.Text = Level.Range.ToString();
			txtSP.Text = Level.Stamina.ToString();

			chkHPPerc.Checked = false;
			chkMPPerc.Checked = ( Level.Mana < 0 );
			chkSPPerc.Checked = ( Level.Stamina < 0 );
		}

		public SkillLevel GetSkill() {
			SkillLevel s = new SkillLevel();

			s.AoE = txtAoeRange.Value;
			s.CastTime = txtCasttime.Value;
			s.Delay = txtCooldown.Value;
			s.Description = txtDesc.Text;
			s.Status = txtEffect.Text;
			s.Mana = ( chkMPPerc.Checked ? -txtMP.Value : txtMP.Value );
			s.Name = txtName.Text;
			s.RequiredLevel = txtNeededLevel.Value;
			s.SkillPunkte = txtPoints.Value;
			s.Range = txtRange.Value;
			s.Stamina = ( chkSPPerc.Checked ? -txtSP.Value : txtSP.Value );

			return s;
		}

	}

}
