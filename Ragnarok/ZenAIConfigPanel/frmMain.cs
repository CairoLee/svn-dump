using System;
using System.ComponentModel;
using System.Windows.Forms;
using ZenAIConfigPanel.Controls;
using ZenAIConfigPanel.Library;

namespace ZenAIConfigPanel {

	public partial class frmMain : Form {
		public static string APP_VERSION = "Config Panel 0.2b";

		private HomuConfig mConfig;


		public frmMain() {
			InitializeComponent();
			InitializeEvents();

			cmbTactListBehav.Items.Clear();
			cmbTactListSkill.Items.Clear();
			DEFAULT_BEHA.Items.Clear();
			DEFAULT_WITH.Items.Clear();
			string[] homuBehaves = Enum.GetNames(typeof(EHomuBehavior));
			string[] homuSkillUsage = Enum.GetNames(typeof(EHomuSkillUsage));
			cmbTactListBehav.Items.AddRange(homuBehaves);
			DEFAULT_BEHA.Items.AddRange(homuBehaves);
			cmbTactListSkill.Items.AddRange(homuSkillUsage);
			DEFAULT_WITH.Items.AddRange(homuSkillUsage);

			cmbTactListBehav.SelectedIndex = 0;
			cmbTactListSkill.SelectedIndex = 0;
			cmbTactListSkillLvl.SelectedIndex = 0;

			string versionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			Text = "ZenAI 1.1a " + APP_VERSION + " - by GodLesZ";
		}


		private void InitializeEvents() {
			CIRCLE_ON_IDLE.MouseEnter += new EventHandler(HomControls_MouseEnter);
			CIRCLE_ON_IDLE.MouseLeave += new EventHandler(HomControls_MouseLeave);
			FOLLOW_AT_ONCE.MouseEnter += new EventHandler(HomControls_MouseEnter);
			FOLLOW_AT_ONCE.MouseLeave += new EventHandler(HomControls_MouseLeave);
			HELP_OWNER_1ST.MouseEnter += new EventHandler(HomControls_MouseEnter);
			HELP_OWNER_1ST.MouseLeave += new EventHandler(HomControls_MouseLeave);
			KILL_YOUR_ENEMIES_1ST.MouseEnter += new EventHandler(HomControls_MouseEnter);
			KILL_YOUR_ENEMIES_1ST.MouseLeave += new EventHandler(HomControls_MouseLeave);
			LONG_RANGE_SHOOTER.MouseEnter += new EventHandler(HomControls_MouseEnter);
			LONG_RANGE_SHOOTER.MouseLeave += new EventHandler(HomControls_MouseLeave);
			HP_PERC_DANGER.MouseEnter += new EventHandler(HomControls_MouseEnter);
			HP_PERC_DANGER.MouseLeave += new EventHandler(HomControls_MouseLeave);
			HP_PERC_DANGER_lbl.MouseEnter += new EventHandler(HomControls_MouseEnter);
			HP_PERC_DANGER_lbl.MouseLeave += new EventHandler(HomControls_MouseLeave);
			HP_PERC_SAFE2ATK.MouseEnter += new EventHandler(HomControls_MouseEnter);
			HP_PERC_SAFE2ATK.MouseEnter += new EventHandler(HomControls_MouseEnter);
			HP_PERC_SAFE2ATK_lbl.MouseEnter += new EventHandler(HomControls_MouseEnter);
			HP_PERC_SAFE2ATK_lbl.MouseLeave += new EventHandler(HomControls_MouseLeave);
			OWNER_CLOSEDISTANCE.MouseEnter += new EventHandler(HomControls_MouseEnter);
			OWNER_CLOSEDISTANCE.MouseLeave += new EventHandler(HomControls_MouseLeave);
			OWNER_CLOSEDISTANCE_lbl.MouseEnter += new EventHandler(HomControls_MouseEnter);
			OWNER_CLOSEDISTANCE_lbl.MouseLeave += new EventHandler(HomControls_MouseLeave);
			TOO_FAR_TARGET.MouseEnter += new EventHandler(HomControls_MouseEnter);
			TOO_FAR_TARGET.MouseLeave += new EventHandler(HomControls_MouseLeave);
			TOO_FAR_TARGET_lbl.MouseEnter += new EventHandler(HomControls_MouseEnter);
			TOO_FAR_TARGET_lbl.MouseLeave += new EventHandler(HomControls_MouseLeave);
			SKILL_TIME_OUT.MouseEnter += new EventHandler(HomControls_MouseEnter);
			SKILL_TIME_OUT.MouseLeave += new EventHandler(HomControls_MouseLeave);
			SKILL_TIME_OUT_lbl.MouseEnter += new EventHandler(HomControls_MouseEnter);
			SKILL_TIME_OUT_lbl.MouseLeave += new EventHandler(HomControls_MouseLeave);
			NO_MOVING_TARGETS.MouseEnter += new EventHandler(HomControls_MouseEnter);
			NO_MOVING_TARGETS.MouseLeave += new EventHandler(HomControls_MouseLeave);
			ADV_MOTION_CHECK.MouseEnter += new EventHandler(HomControls_MouseEnter);
			ADV_MOTION_CHECK.MouseLeave += new EventHandler(HomControls_MouseLeave);
			OWNER_HP_PERC.MouseEnter += new EventHandler(HomControls_MouseEnter);
			OWNER_HP_PERC.MouseLeave += new EventHandler(HomControls_MouseLeave);
			OWNER_HP_PERC_lbl.MouseEnter += new EventHandler(HomControls_MouseEnter);
			OWNER_HP_PERC_lbl.MouseLeave += new EventHandler(HomControls_MouseLeave);
		}

		private void InitializeConfig() {
			mConfig = new HomuConfig();
			if (mConfig.LoadConfig() == -1) {
				MessageBox.Show("Die Datei '" + HomuConfig.Filename + "' konnte nicht gefunden werden!\nEs werden die Standarteinstellungen für ZenAI 1.1a geladen..", HomuConfig.Filename + " Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
				mConfig.LoadDefaultTact();
			}
			ApplyConfig();
		}

		private void InitializeModifications() {
			HomuModHandler.Initialize(AppDomain.CurrentDomain.BaseDirectory);
			listHomuMods.Items.AddRange(HomuModHandler.Mods.ToArray());
			if (HomuModHandler.SelectedMod != -1)
				listHomuMods.SelectedIndex = HomuModHandler.SelectedMod;
		}

		private void ApplyConfig() {
			ADV_MOTION_CHECK.Checked = mConfig.ADV_MOTION_CHECK;
			CIRCLE_ON_IDLE.Checked = mConfig.CIRCLE_ON_IDLE;
			FOLLOW_AT_ONCE.Checked = mConfig.FOLLOW_AT_ONCE;
			HELP_OWNER_1ST.Checked = mConfig.HELP_OWNER_1ST;
			KILL_YOUR_ENEMIES_1ST.Checked = mConfig.KILL_YOUR_ENEMIES_1ST;
			LONG_RANGE_SHOOTER.Checked = mConfig.LONG_RANGE_SHOOTER;
			NO_MOVING_TARGETS.Checked = mConfig.NO_MOVING_TARGETS;

			skillAMIBullwark.Skill = mConfig.AS_AMI_BULW;
			skillAMICastling.Skill = mConfig.AS_AMI_CAST;
			skillFLIFlight.Skill = mConfig.AS_FIL_ACCL;
			skillFILFlitting.Skill = mConfig.AS_FIL_FLTT;
			skillFILMoonlight.Skill = mConfig.AS_FIL_MOON;
			skillLIFEscape.Skill = mConfig.AS_LIF_ESCP;
			skillLIFHeal.Skill = mConfig.AS_LIF_HEAL;
			skillVALBlessing.Skill = mConfig.AS_VAN_BLES;
			skillVALCaprice.Skill = mConfig.AS_VAN_CAPR;

			HP_PERC_DANGER.Value = mConfig.HP_PERC_DANGER;
			HP_PERC_SAFE2ATK.Value = mConfig.HP_PERC_SAFE2ATK;
			OWNER_HP_PERC.Value = mConfig.OWNER_HP_PERC;

			OWNER_CLOSEDISTANCE.Text = mConfig.OWNER_CLOSEDISTANCE.ToString();
			TOO_FAR_TARGET.Text = mConfig.TOO_FAR_TARGET.ToString();
			SKILL_TIME_OUT.Text = mConfig.SKILL_TIME_OUT.ToString();

			listTacts.Items.Clear();
			for (int i = 0; i < mConfig.TactList.Count; i++) {
				listTacts.Items.Add(new HomuTactListViewItem(mConfig.TactList[i]));
			}
		}


		#region frmMain Events
		private void frmMain_Shown(object sender, EventArgs e) {
			SetStatus(ELoadingState.Warning, "Lade ZenAI 1.1a config..");
			InitializeConfig();
			SetStatus(ELoadingState.Warning, "Lade ZenAI 1.1a Mod's..");
			InitializeModifications();
			SetStatus(ELoadingState.Success, "Ready to rumble!");
		}
		#endregion

		#region MenuMainProgram Events
		private void MenuMainProgramExit_Click(object sender, EventArgs e) {
			// TODO: check for modification?
			Close();
		}
		#endregion

		#region MenuMainAbout Events
		private void MenuMainAbout_Click(object sender, EventArgs e) {
			using (frmAbout frm = new frmAbout())
				frm.ShowDialog(this);
		}
		#endregion

		#region MenuMainExtras Events
		private void MenuMainExtrasEditAggroList_Click(object sender, EventArgs e) {
			using (frmAggroEdit frm = new frmAggroEdit())
				frm.ShowDialog(this);
		}

		private void MenuMainExtrasEditPatrol_Click(object sender, EventArgs e) {
			using (frmPatrolEdit frm = new frmPatrolEdit())
				frm.ShowDialog(this);
		}
		#endregion

		#region listTacts Events
		private void listTacts_SelectedIndexChanged(object sender, EventArgs e) {
			if (listTacts.SelectedIndices.Count == 0 || listTacts.SelectedIndices[0] == -1) {
				if (pnlTactEdit.Enabled == true)
					pnlTactEdit.Enabled = false;
				return;
			}

			if (pnlTactEdit.Enabled == false)
				pnlTactEdit.Enabled = true;

			HomuTactListEntry entry = ((HomuTactListViewItem)listTacts.Items[listTacts.SelectedIndices[0]]).Entry;
			txtTactListID.Text = entry.ID.ToString();
			txtTactListName.Text = entry.Name;
			cmbTactListBehav.SelectedIndex = (int)entry.Behavior;
			cmbTactListSkill.SelectedIndex = (int)entry.Skill;
			cmbTactListSkillLvl.SelectedIndex = entry.Priority;
		}
		#endregion

		#region pnlTactEdit Events
		private void txtTactListID_TextChanged(object sender, EventArgs e) {
			HomuTactListEntry entry = ((HomuTactListViewItem)listTacts.Items[listTacts.SelectedIndices[0]]).Entry;
			int id;
			if (int.TryParse(txtTactListID.Text, out id) == false) {
				txtTactListID.Text = "0"; // should trigger it again
				return;
			}
			entry.ID = id;
			listTacts.Invalidate();
		}

		private void txtTactListName_TextChanged(object sender, EventArgs e) {
			if (listTacts.SelectedIndices.Count == 0 || listTacts.SelectedIndices[0] == -1)
				return;
			HomuTactListEntry entry = ((HomuTactListViewItem)listTacts.Items[listTacts.SelectedIndices[0]]).Entry;
			entry.Name = txtTactListName.Text;
			listTacts.Invalidate();
		}

		private void cmbTactListBehav_SelectedIndexChanged(object sender, EventArgs e) {
			if (listTacts.SelectedIndices.Count == 0 || listTacts.SelectedIndices[0] == -1)
				return;
			HomuTactListEntry entry = ((HomuTactListViewItem)listTacts.Items[listTacts.SelectedIndices[0]]).Entry;
			cmbTactListSkill.Enabled = cmbTactListSkillLvl.Enabled = (cmbTactListBehav.SelectedIndex > 0);
			entry.Behavior = (EHomuBehavior)cmbTactListBehav.SelectedIndex;
			listTacts.Invalidate();
		}

		private void cmbTactListSkill_SelectedIndexChanged(object sender, EventArgs e) {
			if (listTacts.SelectedIndices.Count == 0 || listTacts.SelectedIndices[0] == -1)
				return;
			HomuTactListEntry entry = ((HomuTactListViewItem)listTacts.Items[listTacts.SelectedIndices[0]]).Entry;
			entry.Skill = (EHomuSkillUsage)cmbTactListSkill.SelectedIndex;
			listTacts.Invalidate();
		}

		private void cmbTactListSkillLvl_SelectedIndexChanged(object sender, EventArgs e) {
			if (listTacts.SelectedIndices.Count == 0 || listTacts.SelectedIndices[0] == -1)
				return;
			HomuTactListEntry entry = ((HomuTactListViewItem)listTacts.Items[listTacts.SelectedIndices[0]]).Entry;
			cmbTactListSkill.Enabled = (cmbTactListSkillLvl.SelectedIndex > 0);
			entry.Priority = cmbTactListSkillLvl.SelectedIndex;
			listTacts.Invalidate();
		}

		private void btnTactAdd_Click(object sender, EventArgs e) {
			HomuTactListEntry entry = new HomuTactListEntry(int.Parse(txtTactListID.Text), txtTactListName.Text, (EHomuBehavior)cmbTactListBehav.SelectedIndex, (EHomuSkillUsage)cmbTactListSkill.SelectedIndex, cmbTactListSkillLvl.SelectedIndex);
			mConfig.TactList.Add(entry);
			listTacts.Items.Add(new HomuTactListViewItem(mConfig.TactList[mConfig.TactList.Count - 1]));
			// select me :o
			listTacts.SelectedIndices.Clear();
			listTacts.SelectedIndices.Add(listTacts.Items.Count - 1);
			listTacts.Items[listTacts.Items.Count - 1].EnsureVisible();
		}
		#endregion

		#region contextMenuListTacts Events
		private void contextMenuListTacts_Opening(object sender, CancelEventArgs e) {
			if (listTacts.SelectedIndices.Count == 0 || listTacts.SelectedIndices[0] == -1) {
				e.Cancel = true;
				return;
			}
		}

		private void contextMenuListTactsDelete_Click(object sender, EventArgs e) {
			if (listTacts.SelectedIndices.Count == 0 || listTacts.SelectedIndices[0] == -1)
				return;
			mConfig.TactList.RemoveAt(listTacts.SelectedIndices[0]);
			listTacts.Items.RemoveAt(listTacts.SelectedIndices[0]);
		}
		#endregion

		#region listHomuMods Events
		private void listHomuMods_SelectedIndexChanged(object sender, EventArgs e) {
			HomuModHandler.SelectedMod = listHomuMods.SelectedIndex;
			if (listHomuMods.SelectedIndex == -1) {
				txtHomuModEditor.Text = "";
				txtHomuModEditor.Enabled = false;
				return;
			}
			txtHomuModEditor.Enabled = true;
			txtHomuModEditor.Text = HomuModHandler.GetModContent();
			txtHomuModEditor.UpdateSyntaxHightlight();
			txtHomuModEditor.ScrollToCaret();
		}
		#endregion

		#region btnSaveHomu Homu
		private void btnSaveHomu_Click(object sender, EventArgs e) {
			SetStatus(ELoadingState.Warning, "Speichere ZenAI config..");
			mConfig.ADV_MOTION_CHECK = ADV_MOTION_CHECK.Checked;
			mConfig.CIRCLE_ON_IDLE = CIRCLE_ON_IDLE.Checked;
			mConfig.FOLLOW_AT_ONCE = FOLLOW_AT_ONCE.Checked;
			mConfig.HELP_OWNER_1ST = HELP_OWNER_1ST.Checked;
			mConfig.KILL_YOUR_ENEMIES_1ST = KILL_YOUR_ENEMIES_1ST.Checked;
			mConfig.LONG_RANGE_SHOOTER = LONG_RANGE_SHOOTER.Checked;
			mConfig.NO_MOVING_TARGETS = NO_MOVING_TARGETS.Checked;

			mConfig.AS_AMI_BULW = skillAMIBullwark.Skill;
			mConfig.AS_AMI_CAST = skillAMICastling.Skill;
			mConfig.AS_FIL_ACCL = skillFLIFlight.Skill;
			mConfig.AS_FIL_FLTT = skillFILFlitting.Skill;
			mConfig.AS_FIL_MOON = skillFILMoonlight.Skill;
			mConfig.AS_LIF_ESCP = skillLIFEscape.Skill;
			mConfig.AS_LIF_HEAL = skillLIFHeal.Skill;
			mConfig.AS_VAN_BLES = skillVALBlessing.Skill;
			mConfig.AS_VAN_CAPR = skillVALCaprice.Skill;

			mConfig.HP_PERC_DANGER = HP_PERC_DANGER.Value;
			mConfig.HP_PERC_SAFE2ATK = HP_PERC_SAFE2ATK.Value;
			mConfig.OWNER_HP_PERC = OWNER_HP_PERC.Value;

			mConfig.OWNER_CLOSEDISTANCE = int.Parse(OWNER_CLOSEDISTANCE.Text);
			mConfig.TOO_FAR_TARGET = int.Parse(TOO_FAR_TARGET.Text);
			mConfig.SKILL_TIME_OUT = int.Parse(SKILL_TIME_OUT.Text);

			mConfig.SaveConfig();

			if (HomuModHandler.SelectedMod != -1) {
				HomuModHandler.SaveModContent(txtHomuModEditor.Text);
				HomuModHandler.SaveSelectedMod();
			}
			SetStatus(ELoadingState.Success, "ZenAI config gespeichert!");
		}
		#endregion

		#region HomControls_Mouse Events
		private void HomControls_MouseLeave(object sender, EventArgs e) {
			lblDescription.Text = "";
		}

		private void HomControls_MouseEnter(object sender, EventArgs e) {
			if (!(sender is Control))
				return;
			Control con = sender as Control;
			if (con.Name.StartsWith("CIRCLE_ON_IDLE") == true)
				lblDescription.Text = "Der Homunculus dreht einen Kreis um den Alchemisten, wenn er volle HP und SP hat.";
			else if (con.Name.StartsWith("FOLLOW_AT_ONCE") == true)
				lblDescription.Text = "Der Homunculus folgt dem Alchemisten sofort, wenn er sich bewegt.";
			else if (con.Name.StartsWith("HELP_OWNER_1ST") == true)
				lblDescription.Text = "Auch wenn der Homunculus sich im Kampf befindet, kann er das Ziel wechseln um dem Alcemisten zu helfen.";
			else if (con.Name.StartsWith("KILL_YOUR_ENEMIES_1ST") == true)
				lblDescription.Text = "Der Homunculus muss immer erst alle eigenen Ziele töten, bevor der dem Alchemisten hiflt.";
			else if (con.Name.StartsWith("LONG_RANGE_SHOOTER") == true)
				lblDescription.Text = "Der Homunculus bewegt sich nicht zum Ziel, sondern wartet bis es herran kommt.\nWärend der Wartezeit werden Fernkampf Angriffe benutzt.";
			else if (con.Name.StartsWith("HP_PERC_DANGER") == true)
				lblDescription.Text = "Der Homunculus ergreift die Flucht, sobald er weniger Lebenspunkte als diese hat [prozentual].\nBei einem Wert von 0 flüchtet er nie.";
			else if (con.Name.StartsWith("HP_PERC_SAFE2ATK") == true)
				lblDescription.Text = "Der Homunculus ist erst aggressiv, sobald er mehr Lebenspunkte als diese hat [prozentual].\nBei einem Wert von 100 ist er nie aggressiv.";
			else if (con.Name.StartsWith("OWNER_CLOSEDISTANCE") == true)
				lblDescription.Text = "Der Homunculus versucht immer mindestens diese Distanz zum Alchemisten zu haben [in Zellen].";
			else if (con.Name.StartsWith("TOO_FAR_TARGET") == true)
				lblDescription.Text = "Der Homunculus entfernt sich niemals weiter als diese Distanz vom Alchemisten [in Zellen].\nDieser Wert zählt auch als maximale Sichtweite für Gegner [14 ist max im Client].";
			else if (con.Name.StartsWith("SKILL_TIME_OUT") == true)
				lblDescription.Text = "Der Homunculus benutzt nur in diesem Zeitraum aggressive Skills, gemessen ab dem ersten Angriff [in Millisekunden].\nIst die Taktik 'FullPower' für den Gegner ausgewählt, wird diese Zeit ignoriert.";
			else if (con.Name.StartsWith("NO_MOVING_TARGETS") == true)
				lblDescription.Text = "Der Homunculus wird keine Gegner angreifen, die sich gerade bewegen.\nZum Bleistift Monster, die bereits andere Spieler/Ziele verfolgen.";
			else if (con.Name.StartsWith("ADV_MOTION_CHECK") == true)
				lblDescription.Text = "Die AI versucht feststehende Monster und Area Spells zu erkennen.\nFunktioniert derzeit nur bei aggressiven Monster [PassiveDB.lua].";
			else if (con.Name.StartsWith("OWNER_HP_PERC") == true)
				lblDescription.Text = "Nur für Lif Homunculus.\nDer Homunculus benutzt 'Healing Touch', sobald die Lebenspunkte des Alchemister unter dem angegebenem Wert liegt.";
			else if (con.Name.StartsWith("DEFAULT_BEHA") == true)
				lblDescription.Text = "Diese Taktik wird für jedes Ziel benutzt, das keine eigene Taktik hat.";
			else if (con.Name.StartsWith("DEFAULT_WITH") == true)
				lblDescription.Text = "Dieses Verhalten wird für jedes Ziel benutzt, das keine eigene Taktik hat.";
		}
		#endregion


		#region SetStatus
		public void SetStatus(string Text) {
			SetStatus(ELoadingState.Information, Text);
		}

		public void SetStatus(ELoadingState Type, string Text) {
			StatusMainStatus.Text = Text;
			if (Type == ELoadingState.Information)
				StatusMainStatusImage.Image = Properties.Resources.info;
			else if (Type == ELoadingState.Success)
				StatusMainStatusImage.Image = Properties.Resources.success;
			else if (Type == ELoadingState.Warning)
				StatusMainStatusImage.Image = Properties.Resources.warn;
			else if (Type == ELoadingState.Error)
				StatusMainStatusImage.Image = Properties.Resources.error;
			Application.DoEvents(); // refresh Client
		}
		#endregion

	}

}
