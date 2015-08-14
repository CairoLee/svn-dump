namespace ZenAIConfigPanel {
	partial class frmMain {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			ZenAIConfigPanel.Library.HomuSkill homuSkill1 = new ZenAIConfigPanel.Library.HomuSkill();
			ZenAIConfigPanel.Library.HomuSkill homuSkill2 = new ZenAIConfigPanel.Library.HomuSkill();
			ZenAIConfigPanel.Library.HomuSkill homuSkill3 = new ZenAIConfigPanel.Library.HomuSkill();
			ZenAIConfigPanel.Library.HomuSkill homuSkill4 = new ZenAIConfigPanel.Library.HomuSkill();
			ZenAIConfigPanel.Library.HomuSkill homuSkill5 = new ZenAIConfigPanel.Library.HomuSkill();
			ZenAIConfigPanel.Library.HomuSkill homuSkill6 = new ZenAIConfigPanel.Library.HomuSkill();
			ZenAIConfigPanel.Library.HomuSkill homuSkill7 = new ZenAIConfigPanel.Library.HomuSkill();
			ZenAIConfigPanel.Library.HomuSkill homuSkill8 = new ZenAIConfigPanel.Library.HomuSkill();
			ZenAIConfigPanel.Library.HomuSkill homuSkill9 = new ZenAIConfigPanel.Library.HomuSkill();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.MenuMain = new System.Windows.Forms.MenuStrip();
			this.MenuMainProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuMainProgramExit = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuMainExtras = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuMainExtrasEditAggroList = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuMainExtrasEditPatrol = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuMainAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusMain = new System.Windows.Forms.StatusStrip();
			this.StatusMainStatusImage = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusMainStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblDescription = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageHomu = new System.Windows.Forms.TabPage();
			this.OWNER_HP_PERC_lbl = new System.Windows.Forms.Label();
			this.OWNER_HP_PERC = new ZenAIConfigPanel.Controls.PercentMeter();
			this.ADV_MOTION_CHECK = new System.Windows.Forms.CheckBox();
			this.NO_MOVING_TARGETS = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.SKILL_TIME_OUT = new System.Windows.Forms.TextBox();
			this.SKILL_TIME_OUT_lbl = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.TOO_FAR_TARGET = new System.Windows.Forms.TextBox();
			this.TOO_FAR_TARGET_lbl = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.OWNER_CLOSEDISTANCE = new System.Windows.Forms.TextBox();
			this.OWNER_CLOSEDISTANCE_lbl = new System.Windows.Forms.Label();
			this.tabControlHomu = new System.Windows.Forms.TabControl();
			this.tabPageHomuSkills = new System.Windows.Forms.TabPage();
			this.skillVALBlessing = new ZenAIConfigPanel.Controls.SkillPanel();
			this.skillVALCaprice = new ZenAIConfigPanel.Controls.SkillPanel();
			this.label8 = new System.Windows.Forms.Label();
			this.skillLIFEscape = new ZenAIConfigPanel.Controls.SkillPanel();
			this.skillLIFHeal = new ZenAIConfigPanel.Controls.SkillPanel();
			this.label7 = new System.Windows.Forms.Label();
			this.skillFILFlitting = new ZenAIConfigPanel.Controls.SkillPanel();
			this.skillFLIFlight = new ZenAIConfigPanel.Controls.SkillPanel();
			this.skillFILMoonlight = new ZenAIConfigPanel.Controls.SkillPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.skillAMICastling = new ZenAIConfigPanel.Controls.SkillPanel();
			this.skillAMIBullwark = new ZenAIConfigPanel.Controls.SkillPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPageHomuTact = new System.Windows.Forms.TabPage();
			this.DEFAULT_WITH = new ZenAIConfigPanel.Controls.HomuSkillUsageComboBox();
			this.DEFAULT_BEHA = new ZenAIConfigPanel.Controls.HomuBehaviorComboBox();
			this.DEFAULT_BEHA_lbl = new System.Windows.Forms.Label();
			this.DEFAULT_WITH_lbl = new System.Windows.Forms.Label();
			this.pnlTactEdit = new System.Windows.Forms.Panel();
			this.btnTactAdd = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.cmbTactListSkillLvl = new System.Windows.Forms.ComboBox();
			this.txtTactListID = new System.Windows.Forms.TextBox();
			this.cmbTactListSkill = new ZenAIConfigPanel.Controls.HomuSkillUsageComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.cmbTactListBehav = new ZenAIConfigPanel.Controls.HomuBehaviorComboBox();
			this.txtTactListName = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.listTacts = new ZenAIConfigPanel.Controls.HomuTactListView();
			this.colID = new System.Windows.Forms.ColumnHeader();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.colTact = new System.Windows.Forms.ColumnHeader();
			this.colSkillUsage = new System.Windows.Forms.ColumnHeader();
			this.colSkillLevel = new System.Windows.Forms.ColumnHeader();
			this.contextMenuListTacts = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextMenuListTactsDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageHomuMod = new System.Windows.Forms.TabPage();
			this.txtHomuModEditor = new Moonlight.SyntaxRichTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.listHomuMods = new System.Windows.Forms.ListBox();
			this.HP_PERC_SAFE2ATK_lbl = new System.Windows.Forms.Label();
			this.HP_PERC_SAFE2ATK = new ZenAIConfigPanel.Controls.PercentMeter();
			this.HP_PERC_DANGER_lbl = new System.Windows.Forms.Label();
			this.HP_PERC_DANGER = new ZenAIConfigPanel.Controls.PercentMeter();
			this.LONG_RANGE_SHOOTER = new System.Windows.Forms.CheckBox();
			this.KILL_YOUR_ENEMIES_1ST = new System.Windows.Forms.CheckBox();
			this.HELP_OWNER_1ST = new System.Windows.Forms.CheckBox();
			this.FOLLOW_AT_ONCE = new System.Windows.Forms.CheckBox();
			this.CIRCLE_ON_IDLE = new System.Windows.Forms.CheckBox();
			this.btnSaveHomu = new System.Windows.Forms.Button();
			this.imageListTabPages = new System.Windows.Forms.ImageList(this.components);
			this.tabPageMerc = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSaveMerc = new System.Windows.Forms.Button();
			this.MenuMain.SuspendLayout();
			this.StatusMain.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageHomu.SuspendLayout();
			this.tabControlHomu.SuspendLayout();
			this.tabPageHomuSkills.SuspendLayout();
			this.tabPageHomuTact.SuspendLayout();
			this.pnlTactEdit.SuspendLayout();
			this.contextMenuListTacts.SuspendLayout();
			this.tabPageHomuMod.SuspendLayout();
			this.tabPageMerc.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuMain
			// 
			this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MenuMainProgram,
			this.MenuMainExtras,
			this.MenuMainAbout});
			this.MenuMain.Location = new System.Drawing.Point(0, 0);
			this.MenuMain.Name = "MenuMain";
			this.MenuMain.Size = new System.Drawing.Size(777, 24);
			this.MenuMain.TabIndex = 0;
			this.MenuMain.Text = "menuStrip1";
			// 
			// MenuMainProgram
			// 
			this.MenuMainProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MenuMainProgramExit});
			this.MenuMainProgram.Image = global::ZenAIConfigPanel.Properties.Resources.application;
			this.MenuMainProgram.Name = "MenuMainProgram";
			this.MenuMainProgram.Size = new System.Drawing.Size(83, 20);
			this.MenuMainProgram.Text = "Programm";
			// 
			// MenuMainProgramExit
			// 
			this.MenuMainProgramExit.Image = global::ZenAIConfigPanel.Properties.Resources.cancel;
			this.MenuMainProgramExit.Name = "MenuMainProgramExit";
			this.MenuMainProgramExit.Size = new System.Drawing.Size(127, 22);
			this.MenuMainProgramExit.Text = "Beenden";
			this.MenuMainProgramExit.Click += new System.EventHandler(this.MenuMainProgramExit_Click);
			// 
			// MenuMainExtras
			// 
			this.MenuMainExtras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MenuMainExtrasEditAggroList,
			this.MenuMainExtrasEditPatrol});
			this.MenuMainExtras.Image = global::ZenAIConfigPanel.Properties.Resources.plugin;
			this.MenuMainExtras.Name = "MenuMainExtras";
			this.MenuMainExtras.Size = new System.Drawing.Size(66, 20);
			this.MenuMainExtras.Text = "Extras";
			// 
			// MenuMainExtrasEditAggroList
			// 
			this.MenuMainExtrasEditAggroList.Image = global::ZenAIConfigPanel.Properties.Resources.application_edit;
			this.MenuMainExtrasEditAggroList.Name = "MenuMainExtrasEditAggroList";
			this.MenuMainExtrasEditAggroList.Size = new System.Drawing.Size(257, 22);
			this.MenuMainExtrasEditAggroList.Text = "Aggro-Liste bearbeiten";
			this.MenuMainExtrasEditAggroList.Click += new System.EventHandler(this.MenuMainExtrasEditAggroList_Click);
			// 
			// MenuMainExtrasEditPatrol
			// 
			this.MenuMainExtrasEditPatrol.Image = global::ZenAIConfigPanel.Properties.Resources.application_edit;
			this.MenuMainExtrasEditPatrol.Name = "MenuMainExtrasEditPatrol";
			this.MenuMainExtrasEditPatrol.Size = new System.Drawing.Size(257, 22);
			this.MenuMainExtrasEditPatrol.Text = "Bewegung um den Alche bearbeiten";
			this.MenuMainExtrasEditPatrol.Click += new System.EventHandler(this.MenuMainExtrasEditPatrol_Click);
			// 
			// MenuMainAbout
			// 
			this.MenuMainAbout.Image = global::ZenAIConfigPanel.Properties.Resources.application_form_magnify;
			this.MenuMainAbout.Name = "MenuMainAbout";
			this.MenuMainAbout.Size = new System.Drawing.Size(66, 20);
			this.MenuMainAbout.Text = "Über..";
			this.MenuMainAbout.Click += new System.EventHandler(this.MenuMainAbout_Click);
			// 
			// StatusMain
			// 
			this.StatusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.StatusMainStatusImage,
			this.StatusMainStatus});
			this.StatusMain.Location = new System.Drawing.Point(0, 531);
			this.StatusMain.Name = "StatusMain";
			this.StatusMain.Size = new System.Drawing.Size(777, 25);
			this.StatusMain.TabIndex = 1;
			this.StatusMain.Text = "statusStrip1";
			// 
			// StatusMainStatusImage
			// 
			this.StatusMainStatusImage.Image = global::ZenAIConfigPanel.Properties.Resources.warn;
			this.StatusMainStatusImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.StatusMainStatusImage.Name = "StatusMainStatusImage";
			this.StatusMainStatusImage.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.StatusMainStatusImage.Size = new System.Drawing.Size(21, 20);
			// 
			// StatusMainStatus
			// 
			this.StatusMainStatus.AutoSize = false;
			this.StatusMainStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.StatusMainStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.StatusMainStatus.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
			this.StatusMainStatus.Name = "StatusMainStatus";
			this.StatusMainStatus.Size = new System.Drawing.Size(180, 20);
			this.StatusMainStatus.Text = "Lade ZenAI config..";
			this.StatusMainStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription.BackColor = System.Drawing.SystemColors.Info;
			this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblDescription.Location = new System.Drawing.Point(6, 474);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Padding = new System.Windows.Forms.Padding(2);
			this.lblDescription.Size = new System.Drawing.Size(764, 51);
			this.lblDescription.TabIndex = 2;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageHomu);
			this.tabControl.Controls.Add(this.tabPageMerc);
			this.tabControl.ImageList = this.imageListTabPages;
			this.tabControl.Location = new System.Drawing.Point(6, 27);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(764, 444);
			this.tabControl.TabIndex = 3;
			// 
			// tabPageHomu
			// 
			this.tabPageHomu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.tabPageHomu.Controls.Add(this.OWNER_HP_PERC_lbl);
			this.tabPageHomu.Controls.Add(this.OWNER_HP_PERC);
			this.tabPageHomu.Controls.Add(this.ADV_MOTION_CHECK);
			this.tabPageHomu.Controls.Add(this.NO_MOVING_TARGETS);
			this.tabPageHomu.Controls.Add(this.label13);
			this.tabPageHomu.Controls.Add(this.SKILL_TIME_OUT);
			this.tabPageHomu.Controls.Add(this.SKILL_TIME_OUT_lbl);
			this.tabPageHomu.Controls.Add(this.label11);
			this.tabPageHomu.Controls.Add(this.TOO_FAR_TARGET);
			this.tabPageHomu.Controls.Add(this.TOO_FAR_TARGET_lbl);
			this.tabPageHomu.Controls.Add(this.label10);
			this.tabPageHomu.Controls.Add(this.OWNER_CLOSEDISTANCE);
			this.tabPageHomu.Controls.Add(this.OWNER_CLOSEDISTANCE_lbl);
			this.tabPageHomu.Controls.Add(this.tabControlHomu);
			this.tabPageHomu.Controls.Add(this.HP_PERC_SAFE2ATK_lbl);
			this.tabPageHomu.Controls.Add(this.HP_PERC_SAFE2ATK);
			this.tabPageHomu.Controls.Add(this.HP_PERC_DANGER_lbl);
			this.tabPageHomu.Controls.Add(this.HP_PERC_DANGER);
			this.tabPageHomu.Controls.Add(this.LONG_RANGE_SHOOTER);
			this.tabPageHomu.Controls.Add(this.KILL_YOUR_ENEMIES_1ST);
			this.tabPageHomu.Controls.Add(this.HELP_OWNER_1ST);
			this.tabPageHomu.Controls.Add(this.FOLLOW_AT_ONCE);
			this.tabPageHomu.Controls.Add(this.CIRCLE_ON_IDLE);
			this.tabPageHomu.Controls.Add(this.btnSaveHomu);
			this.tabPageHomu.ImageIndex = 0;
			this.tabPageHomu.Location = new System.Drawing.Point(4, 23);
			this.tabPageHomu.Name = "tabPageHomu";
			this.tabPageHomu.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHomu.Size = new System.Drawing.Size(756, 417);
			this.tabPageHomu.TabIndex = 0;
			this.tabPageHomu.Text = "Homunculus";
			// 
			// OWNER_HP_PERC_lbl
			// 
			this.OWNER_HP_PERC_lbl.AutoSize = true;
			this.OWNER_HP_PERC_lbl.Location = new System.Drawing.Point(4, 362);
			this.OWNER_HP_PERC_lbl.Name = "OWNER_HP_PERC_lbl";
			this.OWNER_HP_PERC_lbl.Size = new System.Drawing.Size(123, 13);
			this.OWNER_HP_PERC_lbl.TabIndex = 25;
			this.OWNER_HP_PERC_lbl.Text = "Lif\'s Healing, wenn HP <";
			// 
			// OWNER_HP_PERC
			// 
			this.OWNER_HP_PERC.Location = new System.Drawing.Point(130, 358);
			this.OWNER_HP_PERC.Maximum = 100;
			this.OWNER_HP_PERC.Minimum = 0;
			this.OWNER_HP_PERC.Name = "OWNER_HP_PERC";
			this.OWNER_HP_PERC.Size = new System.Drawing.Size(169, 22);
			this.OWNER_HP_PERC.TabIndex = 24;
			this.OWNER_HP_PERC.Value = 0;
			// 
			// ADV_MOTION_CHECK
			// 
			this.ADV_MOTION_CHECK.AutoSize = true;
			this.ADV_MOTION_CHECK.Location = new System.Drawing.Point(7, 148);
			this.ADV_MOTION_CHECK.Name = "ADV_MOTION_CHECK";
			this.ADV_MOTION_CHECK.Size = new System.Drawing.Size(252, 17);
			this.ADV_MOTION_CHECK.TabIndex = 23;
			this.ADV_MOTION_CHECK.Text = "Versuche frozen und traped Status zu erkennen";
			this.ADV_MOTION_CHECK.UseVisualStyleBackColor = true;
			// 
			// NO_MOVING_TARGETS
			// 
			this.NO_MOVING_TARGETS.AutoSize = true;
			this.NO_MOVING_TARGETS.Location = new System.Drawing.Point(7, 125);
			this.NO_MOVING_TARGETS.Name = "NO_MOVING_TARGETS";
			this.NO_MOVING_TARGETS.Size = new System.Drawing.Size(189, 17);
			this.NO_MOVING_TARGETS.TabIndex = 22;
			this.NO_MOVING_TARGETS.Text = "Greife keine bewegenden Ziele an";
			this.NO_MOVING_TARGETS.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(160, 253);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(71, 13);
			this.label13.TabIndex = 21;
			this.label13.Text = "Millisekunden";
			// 
			// SKILL_TIME_OUT
			// 
			this.SKILL_TIME_OUT.Location = new System.Drawing.Point(130, 250);
			this.SKILL_TIME_OUT.Name = "SKILL_TIME_OUT";
			this.SKILL_TIME_OUT.Size = new System.Drawing.Size(30, 20);
			this.SKILL_TIME_OUT.TabIndex = 20;
			this.SKILL_TIME_OUT.Text = "1000";
			// 
			// SKILL_TIME_OUT_lbl
			// 
			this.SKILL_TIME_OUT_lbl.AutoSize = true;
			this.SKILL_TIME_OUT_lbl.Location = new System.Drawing.Point(7, 253);
			this.SKILL_TIME_OUT_lbl.Name = "SKILL_TIME_OUT_lbl";
			this.SKILL_TIME_OUT_lbl.Size = new System.Drawing.Size(103, 13);
			this.SKILL_TIME_OUT_lbl.TabIndex = 19;
			this.SKILL_TIME_OUT_lbl.Text = "Aggro Skills Timeout";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(160, 221);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(36, 13);
			this.label11.TabIndex = 18;
			this.label11.Text = "Zellen";
			// 
			// TOO_FAR_TARGET
			// 
			this.TOO_FAR_TARGET.Location = new System.Drawing.Point(130, 218);
			this.TOO_FAR_TARGET.Name = "TOO_FAR_TARGET";
			this.TOO_FAR_TARGET.Size = new System.Drawing.Size(30, 20);
			this.TOO_FAR_TARGET.TabIndex = 17;
			this.TOO_FAR_TARGET.Text = "14";
			// 
			// TOO_FAR_TARGET_lbl
			// 
			this.TOO_FAR_TARGET_lbl.AutoSize = true;
			this.TOO_FAR_TARGET_lbl.Location = new System.Drawing.Point(7, 221);
			this.TOO_FAR_TARGET_lbl.Name = "TOO_FAR_TARGET_lbl";
			this.TOO_FAR_TARGET_lbl.Size = new System.Drawing.Size(119, 13);
			this.TOO_FAR_TARGET_lbl.TabIndex = 16;
			this.TOO_FAR_TARGET_lbl.Text = "max. Distanz zum Alche";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(160, 199);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(36, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "Zellen";
			// 
			// OWNER_CLOSEDISTANCE
			// 
			this.OWNER_CLOSEDISTANCE.Location = new System.Drawing.Point(130, 196);
			this.OWNER_CLOSEDISTANCE.Name = "OWNER_CLOSEDISTANCE";
			this.OWNER_CLOSEDISTANCE.Size = new System.Drawing.Size(30, 20);
			this.OWNER_CLOSEDISTANCE.TabIndex = 14;
			this.OWNER_CLOSEDISTANCE.Text = "2";
			// 
			// OWNER_CLOSEDISTANCE_lbl
			// 
			this.OWNER_CLOSEDISTANCE_lbl.AutoSize = true;
			this.OWNER_CLOSEDISTANCE_lbl.Location = new System.Drawing.Point(7, 199);
			this.OWNER_CLOSEDISTANCE_lbl.Name = "OWNER_CLOSEDISTANCE_lbl";
			this.OWNER_CLOSEDISTANCE_lbl.Size = new System.Drawing.Size(116, 13);
			this.OWNER_CLOSEDISTANCE_lbl.TabIndex = 13;
			this.OWNER_CLOSEDISTANCE_lbl.Text = "min. Distanz zum Alche";
			// 
			// tabControlHomu
			// 
			this.tabControlHomu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlHomu.Controls.Add(this.tabPageHomuSkills);
			this.tabControlHomu.Controls.Add(this.tabPageHomuTact);
			this.tabControlHomu.Controls.Add(this.tabPageHomuMod);
			this.tabControlHomu.Location = new System.Drawing.Point(319, 6);
			this.tabControlHomu.Name = "tabControlHomu";
			this.tabControlHomu.SelectedIndex = 0;
			this.tabControlHomu.Size = new System.Drawing.Size(431, 375);
			this.tabControlHomu.TabIndex = 12;
			// 
			// tabPageHomuSkills
			// 
			this.tabPageHomuSkills.Controls.Add(this.skillVALBlessing);
			this.tabPageHomuSkills.Controls.Add(this.skillVALCaprice);
			this.tabPageHomuSkills.Controls.Add(this.label8);
			this.tabPageHomuSkills.Controls.Add(this.skillLIFEscape);
			this.tabPageHomuSkills.Controls.Add(this.skillLIFHeal);
			this.tabPageHomuSkills.Controls.Add(this.label7);
			this.tabPageHomuSkills.Controls.Add(this.skillFILFlitting);
			this.tabPageHomuSkills.Controls.Add(this.skillFLIFlight);
			this.tabPageHomuSkills.Controls.Add(this.skillFILMoonlight);
			this.tabPageHomuSkills.Controls.Add(this.label6);
			this.tabPageHomuSkills.Controls.Add(this.skillAMICastling);
			this.tabPageHomuSkills.Controls.Add(this.skillAMIBullwark);
			this.tabPageHomuSkills.Controls.Add(this.label5);
			this.tabPageHomuSkills.Location = new System.Drawing.Point(4, 22);
			this.tabPageHomuSkills.Name = "tabPageHomuSkills";
			this.tabPageHomuSkills.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHomuSkills.Size = new System.Drawing.Size(423, 349);
			this.tabPageHomuSkills.TabIndex = 0;
			this.tabPageHomuSkills.Text = "Skills";
			this.tabPageHomuSkills.UseVisualStyleBackColor = true;
			// 
			// skillVALBlessing
			// 
			this.skillVALBlessing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillVALBlessing.BackColor = System.Drawing.Color.Transparent;
			this.skillVALBlessing.Location = new System.Drawing.Point(7, 321);
			this.skillVALBlessing.Name = "skillVALBlessing";
			this.skillVALBlessing.Size = new System.Drawing.Size(410, 24);
			homuSkill1.Level = -1;
			homuSkill1.MinSP = 0;
			homuSkill1.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillVALBlessing.Skill = homuSkill1;
			this.skillVALBlessing.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hvan_chaotic;
			this.skillVALBlessing.TabIndex = 12;
			// 
			// skillVALCaprice
			// 
			this.skillVALCaprice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillVALCaprice.BackColor = System.Drawing.Color.Transparent;
			this.skillVALCaprice.Location = new System.Drawing.Point(7, 294);
			this.skillVALCaprice.Name = "skillVALCaprice";
			this.skillVALCaprice.Size = new System.Drawing.Size(410, 24);
			homuSkill2.Level = -1;
			homuSkill2.MinSP = 0;
			homuSkill2.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillVALCaprice.Skill = homuSkill2;
			this.skillVALCaprice.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hvan_caprice;
			this.skillVALCaprice.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label8.BackColor = System.Drawing.Color.Silver;
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(0, 268);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(423, 21);
			this.label8.TabIndex = 10;
			this.label8.Text = "Valnimirth";
			// 
			// skillLIFEscape
			// 
			this.skillLIFEscape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillLIFEscape.BackColor = System.Drawing.Color.Transparent;
			this.skillLIFEscape.Location = new System.Drawing.Point(7, 241);
			this.skillLIFEscape.Name = "skillLIFEscape";
			this.skillLIFEscape.Size = new System.Drawing.Size(410, 24);
			homuSkill3.Level = -1;
			homuSkill3.MinSP = 0;
			homuSkill3.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillLIFEscape.Skill = homuSkill3;
			this.skillLIFEscape.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hlif_avoid;
			this.skillLIFEscape.TabIndex = 9;
			// 
			// skillLIFHeal
			// 
			this.skillLIFHeal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillLIFHeal.BackColor = System.Drawing.Color.Transparent;
			this.skillLIFHeal.Location = new System.Drawing.Point(7, 214);
			this.skillLIFHeal.Name = "skillLIFHeal";
			this.skillLIFHeal.Size = new System.Drawing.Size(410, 24);
			homuSkill4.Level = -1;
			homuSkill4.MinSP = 0;
			homuSkill4.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillLIFHeal.Skill = homuSkill4;
			this.skillLIFHeal.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hlif_heal;
			this.skillLIFHeal.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label7.BackColor = System.Drawing.Color.Silver;
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(0, 188);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(423, 21);
			this.label7.TabIndex = 7;
			this.label7.Text = "Lif";
			// 
			// skillFILFlitting
			// 
			this.skillFILFlitting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillFILFlitting.BackColor = System.Drawing.Color.Transparent;
			this.skillFILFlitting.Location = new System.Drawing.Point(7, 161);
			this.skillFILFlitting.Name = "skillFILFlitting";
			this.skillFILFlitting.Size = new System.Drawing.Size(410, 24);
			homuSkill5.Level = -1;
			homuSkill5.MinSP = 0;
			homuSkill5.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillFILFlitting.Skill = homuSkill5;
			this.skillFILFlitting.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hfli_fleet;
			this.skillFILFlitting.TabIndex = 6;
			// 
			// skillFLIFlight
			// 
			this.skillFLIFlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillFLIFlight.BackColor = System.Drawing.Color.Transparent;
			this.skillFLIFlight.Location = new System.Drawing.Point(7, 134);
			this.skillFLIFlight.Name = "skillFLIFlight";
			this.skillFLIFlight.Size = new System.Drawing.Size(410, 24);
			homuSkill6.Level = -1;
			homuSkill6.MinSP = 0;
			homuSkill6.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillFLIFlight.Skill = homuSkill6;
			this.skillFLIFlight.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hfli_speed;
			this.skillFLIFlight.TabIndex = 5;
			// 
			// skillFILMoonlight
			// 
			this.skillFILMoonlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillFILMoonlight.BackColor = System.Drawing.Color.Transparent;
			this.skillFILMoonlight.Location = new System.Drawing.Point(7, 107);
			this.skillFILMoonlight.Name = "skillFILMoonlight";
			this.skillFILMoonlight.Size = new System.Drawing.Size(410, 24);
			homuSkill7.Level = -1;
			homuSkill7.MinSP = 0;
			homuSkill7.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillFILMoonlight.Skill = homuSkill7;
			this.skillFILMoonlight.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hfli_moon;
			this.skillFILMoonlight.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label6.BackColor = System.Drawing.Color.Silver;
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(0, 83);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(423, 21);
			this.label6.TabIndex = 3;
			this.label6.Text = "Filir";
			// 
			// skillAMICastling
			// 
			this.skillAMICastling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillAMICastling.BackColor = System.Drawing.Color.Transparent;
			this.skillAMICastling.Location = new System.Drawing.Point(7, 53);
			this.skillAMICastling.Name = "skillAMICastling";
			this.skillAMICastling.Size = new System.Drawing.Size(410, 24);
			homuSkill8.Level = -1;
			homuSkill8.MinSP = 0;
			homuSkill8.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillAMICastling.Skill = homuSkill8;
			this.skillAMICastling.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hami_castle;
			this.skillAMICastling.TabIndex = 2;
			// 
			// skillAMIBullwark
			// 
			this.skillAMIBullwark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.skillAMIBullwark.BackColor = System.Drawing.Color.Transparent;
			this.skillAMIBullwark.Location = new System.Drawing.Point(7, 26);
			this.skillAMIBullwark.Name = "skillAMIBullwark";
			this.skillAMIBullwark.Size = new System.Drawing.Size(410, 24);
			homuSkill9.Level = -1;
			homuSkill9.MinSP = 0;
			homuSkill9.Name = "TraceAI,MoveToOwner,Move,Attack,GetV,GetActors,GetTick,GetMsg,GetResMsg,SkillObje" +
				"ct,SkillGround,IsMonster";
			this.skillAMIBullwark.Skill = homuSkill9;
			this.skillAMIBullwark.SkillImage = global::ZenAIConfigPanel.Properties.Resources.hami_defence;
			this.skillAMIBullwark.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label5.BackColor = System.Drawing.Color.Silver;
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(423, 21);
			this.label5.TabIndex = 0;
			this.label5.Text = "Amistr";
			// 
			// tabPageHomuTact
			// 
			this.tabPageHomuTact.Controls.Add(this.DEFAULT_WITH);
			this.tabPageHomuTact.Controls.Add(this.DEFAULT_BEHA);
			this.tabPageHomuTact.Controls.Add(this.DEFAULT_BEHA_lbl);
			this.tabPageHomuTact.Controls.Add(this.DEFAULT_WITH_lbl);
			this.tabPageHomuTact.Controls.Add(this.pnlTactEdit);
			this.tabPageHomuTact.Controls.Add(this.listTacts);
			this.tabPageHomuTact.Location = new System.Drawing.Point(4, 22);
			this.tabPageHomuTact.Name = "tabPageHomuTact";
			this.tabPageHomuTact.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHomuTact.Size = new System.Drawing.Size(423, 349);
			this.tabPageHomuTact.TabIndex = 1;
			this.tabPageHomuTact.Text = "Taktiken";
			this.tabPageHomuTact.UseVisualStyleBackColor = true;
			// 
			// DEFAULT_WITH
			// 
			this.DEFAULT_WITH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DEFAULT_WITH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.DEFAULT_WITH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DEFAULT_WITH.FormattingEnabled = true;
			this.DEFAULT_WITH.Location = new System.Drawing.Point(304, 5);
			this.DEFAULT_WITH.Name = "DEFAULT_WITH";
			this.DEFAULT_WITH.Size = new System.Drawing.Size(113, 21);
			this.DEFAULT_WITH.TabIndex = 12;
			// 
			// DEFAULT_BEHA
			// 
			this.DEFAULT_BEHA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.DEFAULT_BEHA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DEFAULT_BEHA.FormattingEnabled = true;
			this.DEFAULT_BEHA.Location = new System.Drawing.Point(103, 5);
			this.DEFAULT_BEHA.Name = "DEFAULT_BEHA";
			this.DEFAULT_BEHA.Size = new System.Drawing.Size(103, 21);
			this.DEFAULT_BEHA.TabIndex = 11;
			// 
			// DEFAULT_BEHA_lbl
			// 
			this.DEFAULT_BEHA_lbl.AutoSize = true;
			this.DEFAULT_BEHA_lbl.Location = new System.Drawing.Point(2, 8);
			this.DEFAULT_BEHA_lbl.Name = "DEFAULT_BEHA_lbl";
			this.DEFAULT_BEHA_lbl.Size = new System.Drawing.Size(95, 13);
			this.DEFAULT_BEHA_lbl.TabIndex = 12;
			this.DEFAULT_BEHA_lbl.Text = "Standart Verhalten";
			// 
			// DEFAULT_WITH_lbl
			// 
			this.DEFAULT_WITH_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DEFAULT_WITH_lbl.AutoSize = true;
			this.DEFAULT_WITH_lbl.Location = new System.Drawing.Point(229, 8);
			this.DEFAULT_WITH_lbl.Name = "DEFAULT_WITH_lbl";
			this.DEFAULT_WITH_lbl.Size = new System.Drawing.Size(69, 13);
			this.DEFAULT_WITH_lbl.TabIndex = 11;
			this.DEFAULT_WITH_lbl.Text = "Standart Skill";
			// 
			// pnlTactEdit
			// 
			this.pnlTactEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlTactEdit.Controls.Add(this.btnTactAdd);
			this.pnlTactEdit.Controls.Add(this.label16);
			this.pnlTactEdit.Controls.Add(this.cmbTactListSkillLvl);
			this.pnlTactEdit.Controls.Add(this.txtTactListID);
			this.pnlTactEdit.Controls.Add(this.cmbTactListSkill);
			this.pnlTactEdit.Controls.Add(this.label17);
			this.pnlTactEdit.Controls.Add(this.cmbTactListBehav);
			this.pnlTactEdit.Controls.Add(this.txtTactListName);
			this.pnlTactEdit.Controls.Add(this.label19);
			this.pnlTactEdit.Controls.Add(this.label18);
			this.pnlTactEdit.Enabled = false;
			this.pnlTactEdit.Location = new System.Drawing.Point(0, 38);
			this.pnlTactEdit.Name = "pnlTactEdit";
			this.pnlTactEdit.Size = new System.Drawing.Size(417, 53);
			this.pnlTactEdit.TabIndex = 10;
			// 
			// btnTactAdd
			// 
			this.btnTactAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTactAdd.Image = global::ZenAIConfigPanel.Properties.Resources.add;
			this.btnTactAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTactAdd.Location = new System.Drawing.Point(359, 27);
			this.btnTactAdd.Name = "btnTactAdd";
			this.btnTactAdd.Size = new System.Drawing.Size(55, 23);
			this.btnTactAdd.TabIndex = 10;
			this.btnTactAdd.Text = "Add";
			this.btnTactAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTactAdd.UseVisualStyleBackColor = true;
			this.btnTactAdd.Click += new System.EventHandler(this.btnTactAdd_Click);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(3, 6);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(18, 13);
			this.label16.TabIndex = 1;
			this.label16.Text = "ID";
			// 
			// cmbTactListSkillLvl
			// 
			this.cmbTactListSkillLvl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTactListSkillLvl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTactListSkillLvl.FormattingEnabled = true;
			this.cmbTactListSkillLvl.Items.AddRange(new object[] {
			"Off",
			"Lvl 1",
			"Lvl 2",
			"Lvl 3",
			"Lvl 4",
			"Lvl 5"});
			this.cmbTactListSkillLvl.Location = new System.Drawing.Point(359, 3);
			this.cmbTactListSkillLvl.Name = "cmbTactListSkillLvl";
			this.cmbTactListSkillLvl.Size = new System.Drawing.Size(55, 21);
			this.cmbTactListSkillLvl.TabIndex = 9;
			this.cmbTactListSkillLvl.SelectedIndexChanged += new System.EventHandler(this.cmbTactListSkillLvl_SelectedIndexChanged);
			// 
			// txtTactListID
			// 
			this.txtTactListID.Location = new System.Drawing.Point(44, 3);
			this.txtTactListID.Name = "txtTactListID";
			this.txtTactListID.Size = new System.Drawing.Size(45, 20);
			this.txtTactListID.TabIndex = 2;
			this.txtTactListID.TextChanged += new System.EventHandler(this.txtTactListID_TextChanged);
			// 
			// cmbTactListSkill
			// 
			this.cmbTactListSkill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTactListSkill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbTactListSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTactListSkill.FormattingEnabled = true;
			this.cmbTactListSkill.Location = new System.Drawing.Point(225, 3);
			this.cmbTactListSkill.Name = "cmbTactListSkill";
			this.cmbTactListSkill.Size = new System.Drawing.Size(128, 21);
			this.cmbTactListSkill.TabIndex = 8;
			this.cmbTactListSkill.SelectedIndexChanged += new System.EventHandler(this.cmbTactListSkill_SelectedIndexChanged);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(3, 32);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(35, 13);
			this.label17.TabIndex = 3;
			this.label17.Text = "Name";
			// 
			// cmbTactListBehav
			// 
			this.cmbTactListBehav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTactListBehav.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbTactListBehav.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTactListBehav.FormattingEnabled = true;
			this.cmbTactListBehav.Location = new System.Drawing.Point(225, 28);
			this.cmbTactListBehav.Name = "cmbTactListBehav";
			this.cmbTactListBehav.Size = new System.Drawing.Size(128, 21);
			this.cmbTactListBehav.TabIndex = 7;
			this.cmbTactListBehav.SelectedIndexChanged += new System.EventHandler(this.cmbTactListBehav_SelectedIndexChanged);
			// 
			// txtTactListName
			// 
			this.txtTactListName.Location = new System.Drawing.Point(44, 29);
			this.txtTactListName.Name = "txtTactListName";
			this.txtTactListName.Size = new System.Drawing.Size(102, 20);
			this.txtTactListName.TabIndex = 4;
			this.txtTactListName.TextChanged += new System.EventHandler(this.txtTactListName_TextChanged);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(167, 6);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(26, 13);
			this.label19.TabIndex = 6;
			this.label19.Text = "Skill";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(167, 32);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(52, 13);
			this.label18.TabIndex = 5;
			this.label18.Text = "Verhalten";
			// 
			// listTacts
			// 
			this.listTacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listTacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.colID,
			this.colName,
			this.colTact,
			this.colSkillUsage,
			this.colSkillLevel});
			this.listTacts.ContextMenuStrip = this.contextMenuListTacts;
			this.listTacts.FullRowSelect = true;
			this.listTacts.GridLines = true;
			this.listTacts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listTacts.HideSelection = false;
			this.listTacts.Location = new System.Drawing.Point(3, 94);
			this.listTacts.MultiSelect = false;
			this.listTacts.Name = "listTacts";
			this.listTacts.OwnerDraw = true;
			this.listTacts.Size = new System.Drawing.Size(417, 252);
			this.listTacts.TabIndex = 0;
			this.listTacts.UseCompatibleStateImageBehavior = false;
			this.listTacts.View = System.Windows.Forms.View.Details;
			this.listTacts.SelectedIndexChanged += new System.EventHandler(this.listTacts_SelectedIndexChanged);
			// 
			// colID
			// 
			this.colID.Text = "MobID";
			this.colID.Width = 48;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 147;
			// 
			// colTact
			// 
			this.colTact.Text = "Verhalten";
			this.colTact.Width = 81;
			// 
			// colSkillUsage
			// 
			this.colSkillUsage.Text = "Skills";
			this.colSkillUsage.Width = 84;
			// 
			// colSkillLevel
			// 
			this.colSkillLevel.Text = "Lvl";
			this.colSkillLevel.Width = 28;
			// 
			// contextMenuListTacts
			// 
			this.contextMenuListTacts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.contextMenuListTactsDelete});
			this.contextMenuListTacts.Name = "contextMenuListTacts";
			this.contextMenuListTacts.Size = new System.Drawing.Size(153, 26);
			this.contextMenuListTacts.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuListTacts_Opening);
			// 
			// contextMenuListTactsDelete
			// 
			this.contextMenuListTactsDelete.Name = "contextMenuListTactsDelete";
			this.contextMenuListTactsDelete.Size = new System.Drawing.Size(152, 22);
			this.contextMenuListTactsDelete.Text = "Taktik löschen";
			this.contextMenuListTactsDelete.Click += new System.EventHandler(this.contextMenuListTactsDelete_Click);
			// 
			// tabPageHomuMod
			// 
			this.tabPageHomuMod.Controls.Add(this.txtHomuModEditor);
			this.tabPageHomuMod.Controls.Add(this.label3);
			this.tabPageHomuMod.Controls.Add(this.label1);
			this.tabPageHomuMod.Controls.Add(this.listHomuMods);
			this.tabPageHomuMod.Location = new System.Drawing.Point(4, 22);
			this.tabPageHomuMod.Name = "tabPageHomuMod";
			this.tabPageHomuMod.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHomuMod.Size = new System.Drawing.Size(423, 349);
			this.tabPageHomuMod.TabIndex = 2;
			this.tabPageHomuMod.Text = "AI Mod";
			this.tabPageHomuMod.UseVisualStyleBackColor = true;
			// 
			// txtHomuModEditor
			// 
			this.txtHomuModEditor.AcceptsTab = true;
			this.txtHomuModEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHomuModEditor.AutoWordSelection = true;
			this.txtHomuModEditor.CodeColorComment = System.Drawing.Color.DarkGreen;
			this.txtHomuModEditor.CodeColorFunction = System.Drawing.Color.Red;
			this.txtHomuModEditor.CodeColorKeyword = System.Drawing.Color.Blue;
			this.txtHomuModEditor.CodeColorPlainText = System.Drawing.Color.Black;
			this.txtHomuModEditor.CodeColorType = System.Drawing.Color.Maroon;
			this.txtHomuModEditor.CodeWordsComments = ((System.Collections.Generic.List<string>)(resources.GetObject("txtHomuModEditor.CodeWords_Comments")));
			this.txtHomuModEditor.CodeWordsFunctions = ((System.Collections.Generic.List<string>)(resources.GetObject("txtHomuModEditor.CodeWords_Functions")));
			this.txtHomuModEditor.CodeWordsKeywords = ((System.Collections.Generic.List<string>)(resources.GetObject("txtHomuModEditor.CodeWords_Keywords")));
			this.txtHomuModEditor.CodeWordsScopeOperators = ((System.Collections.Generic.List<string>)(resources.GetObject("txtHomuModEditor.CodeWords_ScopeOperators")));
			this.txtHomuModEditor.CodeWordsTypes = ((System.Collections.Generic.List<string>)(resources.GetObject("txtHomuModEditor.CodeWords_Types")));
			this.txtHomuModEditor.DetectUrls = false;
			this.txtHomuModEditor.Enabled = false;
			this.txtHomuModEditor.Font = new System.Drawing.Font("Courier New", 9F);
			this.txtHomuModEditor.Location = new System.Drawing.Point(6, 159);
			this.txtHomuModEditor.Name = "txtHomuModEditor";
			this.txtHomuModEditor.Size = new System.Drawing.Size(411, 184);
			this.txtHomuModEditor.TabIndex = 4;
			this.txtHomuModEditor.Text = "-- Mod";
			this.txtHomuModEditor.WordWrap = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(316, 26);
			this.label3.TabIndex = 3;
			this.label3.Text = "Dies ist ein kleiner Editor für die markierte Modifikation.\r\nAchtung! Jede Änderu" +
				"ng wird erst beim [Speichern] übernommen.";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(410, 40);
			this.label1.TabIndex = 1;
			this.label1.Text = "Hier kannst du eine Modifiktationen für deine AI auswählen.\r\nDie Datei muss mit _" +
				"Mod.lua enden um als Modifikation erkannt zu werden.";
			// 
			// listHomuMods
			// 
			this.listHomuMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listHomuMods.FormattingEnabled = true;
			this.listHomuMods.Location = new System.Drawing.Point(6, 50);
			this.listHomuMods.Name = "listHomuMods";
			this.listHomuMods.Size = new System.Drawing.Size(411, 56);
			this.listHomuMods.TabIndex = 0;
			this.listHomuMods.SelectedIndexChanged += new System.EventHandler(this.listHomuMods_SelectedIndexChanged);
			// 
			// HP_PERC_SAFE2ATK_lbl
			// 
			this.HP_PERC_SAFE2ATK_lbl.AutoSize = true;
			this.HP_PERC_SAFE2ATK_lbl.Location = new System.Drawing.Point(4, 318);
			this.HP_PERC_SAFE2ATK_lbl.Name = "HP_PERC_SAFE2ATK_lbl";
			this.HP_PERC_SAFE2ATK_lbl.Size = new System.Drawing.Size(117, 13);
			this.HP_PERC_SAFE2ATK_lbl.TabIndex = 11;
			this.HP_PERC_SAFE2ATK_lbl.Text = "Angreifen, wenn HP >=";
			// 
			// HP_PERC_SAFE2ATK
			// 
			this.HP_PERC_SAFE2ATK.Location = new System.Drawing.Point(130, 314);
			this.HP_PERC_SAFE2ATK.Maximum = 100;
			this.HP_PERC_SAFE2ATK.Minimum = 0;
			this.HP_PERC_SAFE2ATK.Name = "HP_PERC_SAFE2ATK";
			this.HP_PERC_SAFE2ATK.Size = new System.Drawing.Size(169, 22);
			this.HP_PERC_SAFE2ATK.TabIndex = 10;
			this.HP_PERC_SAFE2ATK.Value = 0;
			// 
			// HP_PERC_DANGER_lbl
			// 
			this.HP_PERC_DANGER_lbl.AutoSize = true;
			this.HP_PERC_DANGER_lbl.Location = new System.Drawing.Point(4, 290);
			this.HP_PERC_DANGER_lbl.Name = "HP_PERC_DANGER_lbl";
			this.HP_PERC_DANGER_lbl.Size = new System.Drawing.Size(107, 13);
			this.HP_PERC_DANGER_lbl.TabIndex = 9;
			this.HP_PERC_DANGER_lbl.Text = "Flüchten, wenn HP <";
			// 
			// HP_PERC_DANGER
			// 
			this.HP_PERC_DANGER.Location = new System.Drawing.Point(130, 286);
			this.HP_PERC_DANGER.Maximum = 100;
			this.HP_PERC_DANGER.Minimum = 0;
			this.HP_PERC_DANGER.Name = "HP_PERC_DANGER";
			this.HP_PERC_DANGER.Size = new System.Drawing.Size(169, 22);
			this.HP_PERC_DANGER.TabIndex = 8;
			this.HP_PERC_DANGER.Value = 0;
			// 
			// LONG_RANGE_SHOOTER
			// 
			this.LONG_RANGE_SHOOTER.AutoSize = true;
			this.LONG_RANGE_SHOOTER.Location = new System.Drawing.Point(7, 102);
			this.LONG_RANGE_SHOOTER.Name = "LONG_RANGE_SHOOTER";
			this.LONG_RANGE_SHOOTER.Size = new System.Drawing.Size(297, 17);
			this.LONG_RANGE_SHOOTER.TabIndex = 7;
			this.LONG_RANGE_SHOOTER.Text = "Nur Distanzskills verwenden, den Gegner kommen lassen";
			this.LONG_RANGE_SHOOTER.UseVisualStyleBackColor = true;
			// 
			// KILL_YOUR_ENEMIES_1ST
			// 
			this.KILL_YOUR_ENEMIES_1ST.AutoSize = true;
			this.KILL_YOUR_ENEMIES_1ST.Location = new System.Drawing.Point(7, 78);
			this.KILL_YOUR_ENEMIES_1ST.Name = "KILL_YOUR_ENEMIES_1ST";
			this.KILL_YOUR_ENEMIES_1ST.Size = new System.Drawing.Size(220, 17);
			this.KILL_YOUR_ENEMIES_1ST.TabIndex = 6;
			this.KILL_YOUR_ENEMIES_1ST.Text = "Töte erst alle meine Ziele, bevor ich helfe";
			this.KILL_YOUR_ENEMIES_1ST.UseVisualStyleBackColor = true;
			// 
			// HELP_OWNER_1ST
			// 
			this.HELP_OWNER_1ST.AutoSize = true;
			this.HELP_OWNER_1ST.Location = new System.Drawing.Point(7, 54);
			this.HELP_OWNER_1ST.Name = "HELP_OWNER_1ST";
			this.HELP_OWNER_1ST.Size = new System.Drawing.Size(258, 17);
			this.HELP_OWNER_1ST.TabIndex = 5;
			this.HELP_OWNER_1ST.Text = "Kann das Ziel wechseln, um dem Alche zu helfen";
			this.HELP_OWNER_1ST.UseVisualStyleBackColor = true;
			// 
			// FOLLOW_AT_ONCE
			// 
			this.FOLLOW_AT_ONCE.AutoSize = true;
			this.FOLLOW_AT_ONCE.Location = new System.Drawing.Point(7, 30);
			this.FOLLOW_AT_ONCE.Name = "FOLLOW_AT_ONCE";
			this.FOLLOW_AT_ONCE.Size = new System.Drawing.Size(177, 17);
			this.FOLLOW_AT_ONCE.TabIndex = 4;
			this.FOLLOW_AT_ONCE.Text = "Folge dem Alche, sobald er läuft";
			this.FOLLOW_AT_ONCE.UseVisualStyleBackColor = true;
			// 
			// CIRCLE_ON_IDLE
			// 
			this.CIRCLE_ON_IDLE.AutoSize = true;
			this.CIRCLE_ON_IDLE.Location = new System.Drawing.Point(7, 7);
			this.CIRCLE_ON_IDLE.Name = "CIRCLE_ON_IDLE";
			this.CIRCLE_ON_IDLE.Size = new System.Drawing.Size(203, 17);
			this.CIRCLE_ON_IDLE.TabIndex = 3;
			this.CIRCLE_ON_IDLE.Text = "Lauf um den Alche, wenn HP/SP voll";
			this.CIRCLE_ON_IDLE.UseVisualStyleBackColor = true;
			// 
			// btnSaveHomu
			// 
			this.btnSaveHomu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveHomu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSaveHomu.ImageIndex = 0;
			this.btnSaveHomu.ImageList = this.imageListTabPages;
			this.btnSaveHomu.Location = new System.Drawing.Point(674, 387);
			this.btnSaveHomu.Name = "btnSaveHomu";
			this.btnSaveHomu.Size = new System.Drawing.Size(76, 24);
			this.btnSaveHomu.TabIndex = 2;
			this.btnSaveHomu.Text = "Speichern";
			this.btnSaveHomu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSaveHomu.UseVisualStyleBackColor = true;
			this.btnSaveHomu.Click += new System.EventHandler(this.btnSaveHomu_Click);
			// 
			// imageListTabPages
			// 
			this.imageListTabPages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabPages.ImageStream")));
			this.imageListTabPages.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListTabPages.Images.SetKeyName(0, "am_callhomun.bmp");
			this.imageListTabPages.Images.SetKeyName(1, "merc_scroll.png");
			// 
			// tabPageMerc
			// 
			this.tabPageMerc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.tabPageMerc.Controls.Add(this.label2);
			this.tabPageMerc.Controls.Add(this.btnSaveMerc);
			this.tabPageMerc.ImageIndex = 1;
			this.tabPageMerc.Location = new System.Drawing.Point(4, 23);
			this.tabPageMerc.Name = "tabPageMerc";
			this.tabPageMerc.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMerc.Size = new System.Drawing.Size(756, 417);
			this.tabPageMerc.TabIndex = 1;
			this.tabPageMerc.Text = "Mercenary";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Enabled = false;
			this.label2.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(263, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(199, 58);
			this.label2.TabIndex = 2;
			this.label2.Text = "in Abyte";
			// 
			// btnSaveMerc
			// 
			this.btnSaveMerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveMerc.Enabled = false;
			this.btnSaveMerc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSaveMerc.ImageIndex = 1;
			this.btnSaveMerc.ImageList = this.imageListTabPages;
			this.btnSaveMerc.Location = new System.Drawing.Point(643, 387);
			this.btnSaveMerc.Name = "btnSaveMerc";
			this.btnSaveMerc.Size = new System.Drawing.Size(76, 24);
			this.btnSaveMerc.TabIndex = 1;
			this.btnSaveMerc.Text = "Speichern";
			this.btnSaveMerc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSaveMerc.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(777, 556);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.StatusMain);
			this.Controls.Add(this.MenuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MenuMain;
			this.Name = "frmMain";
			this.Text = "ZenAI 1.1a Config Panel [v 0.1b] - by GodLesZ";
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.MenuMain.ResumeLayout(false);
			this.MenuMain.PerformLayout();
			this.StatusMain.ResumeLayout(false);
			this.StatusMain.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageHomu.ResumeLayout(false);
			this.tabPageHomu.PerformLayout();
			this.tabControlHomu.ResumeLayout(false);
			this.tabPageHomuSkills.ResumeLayout(false);
			this.tabPageHomuTact.ResumeLayout(false);
			this.tabPageHomuTact.PerformLayout();
			this.pnlTactEdit.ResumeLayout(false);
			this.pnlTactEdit.PerformLayout();
			this.contextMenuListTacts.ResumeLayout(false);
			this.tabPageHomuMod.ResumeLayout(false);
			this.tabPageHomuMod.PerformLayout();
			this.tabPageMerc.ResumeLayout(false);
			this.tabPageMerc.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuMain;
		private System.Windows.Forms.ToolStripMenuItem MenuMainProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuMainProgramExit;
		private System.Windows.Forms.ToolStripMenuItem MenuMainAbout;
		private System.Windows.Forms.StatusStrip StatusMain;
		private System.Windows.Forms.ToolStripStatusLabel StatusMainStatus;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageHomu;
		private System.Windows.Forms.TabPage tabPageMerc;
		private System.Windows.Forms.ImageList imageListTabPages;
		private System.Windows.Forms.Button btnSaveMerc;
		private System.Windows.Forms.Button btnSaveHomu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox LONG_RANGE_SHOOTER;
		private System.Windows.Forms.CheckBox KILL_YOUR_ENEMIES_1ST;
		private System.Windows.Forms.CheckBox HELP_OWNER_1ST;
		private System.Windows.Forms.CheckBox FOLLOW_AT_ONCE;
		private System.Windows.Forms.CheckBox CIRCLE_ON_IDLE;
		private ZenAIConfigPanel.Controls.PercentMeter HP_PERC_DANGER;
		private System.Windows.Forms.Label HP_PERC_DANGER_lbl;
		private System.Windows.Forms.Label HP_PERC_SAFE2ATK_lbl;
		private ZenAIConfigPanel.Controls.PercentMeter HP_PERC_SAFE2ATK;
		private System.Windows.Forms.TabControl tabControlHomu;
		private System.Windows.Forms.TabPage tabPageHomuSkills;
		private System.Windows.Forms.TabPage tabPageHomuTact;
		private System.Windows.Forms.Label label5;
		private ZenAIConfigPanel.Controls.SkillPanel skillAMIBullwark;
		private ZenAIConfigPanel.Controls.SkillPanel skillVALBlessing;
		private ZenAIConfigPanel.Controls.SkillPanel skillVALCaprice;
		private System.Windows.Forms.Label label8;
		private ZenAIConfigPanel.Controls.SkillPanel skillLIFEscape;
		private ZenAIConfigPanel.Controls.SkillPanel skillLIFHeal;
		private System.Windows.Forms.Label label7;
		private ZenAIConfigPanel.Controls.SkillPanel skillFILFlitting;
		private ZenAIConfigPanel.Controls.SkillPanel skillFLIFlight;
		private ZenAIConfigPanel.Controls.SkillPanel skillFILMoonlight;
		private System.Windows.Forms.Label label6;
		private ZenAIConfigPanel.Controls.SkillPanel skillAMICastling;
		private System.Windows.Forms.ToolStripMenuItem MenuMainExtras;
		private System.Windows.Forms.ToolStripMenuItem MenuMainExtrasEditAggroList;
		private System.Windows.Forms.Label OWNER_CLOSEDISTANCE_lbl;
		private System.Windows.Forms.CheckBox ADV_MOTION_CHECK;
		private System.Windows.Forms.CheckBox NO_MOVING_TARGETS;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox SKILL_TIME_OUT;
		private System.Windows.Forms.Label SKILL_TIME_OUT_lbl;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox TOO_FAR_TARGET;
		private System.Windows.Forms.Label TOO_FAR_TARGET_lbl;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox OWNER_CLOSEDISTANCE;
		private ZenAIConfigPanel.Controls.HomuTactListView listTacts;
		private System.Windows.Forms.ColumnHeader colID;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colTact;
		private System.Windows.Forms.ColumnHeader colSkillUsage;
		private System.Windows.Forms.ColumnHeader colSkillLevel;
		private System.Windows.Forms.ContextMenuStrip contextMenuListTacts;
		private System.Windows.Forms.ToolStripMenuItem contextMenuListTactsDelete;
		private System.Windows.Forms.Label OWNER_HP_PERC_lbl;
		private ZenAIConfigPanel.Controls.PercentMeter OWNER_HP_PERC;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtTactListName;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtTactListID;
		private System.Windows.Forms.Label label16;
		private ZenAIConfigPanel.Controls.HomuBehaviorComboBox cmbTactListBehav;
		private ZenAIConfigPanel.Controls.HomuSkillUsageComboBox cmbTactListSkill;
		private System.Windows.Forms.ComboBox cmbTactListSkillLvl;
		private System.Windows.Forms.Panel pnlTactEdit;
		private System.Windows.Forms.Button btnTactAdd;
		private System.Windows.Forms.ToolStripStatusLabel StatusMainStatusImage;
		private ZenAIConfigPanel.Controls.HomuSkillUsageComboBox DEFAULT_WITH;
		private ZenAIConfigPanel.Controls.HomuBehaviorComboBox DEFAULT_BEHA;
		private System.Windows.Forms.Label DEFAULT_BEHA_lbl;
		private System.Windows.Forms.Label DEFAULT_WITH_lbl;
		private System.Windows.Forms.TabPage tabPageHomuMod;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listHomuMods;
		private System.Windows.Forms.Label label3;
		private Moonlight.SyntaxRichTextBox txtHomuModEditor;
		private System.Windows.Forms.ToolStripMenuItem MenuMainExtrasEditPatrol;
	}
}

