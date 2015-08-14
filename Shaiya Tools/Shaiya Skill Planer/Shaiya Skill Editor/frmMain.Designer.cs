namespace Shaiya_Skill_Editor {
	partial class frmMain {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMain ) );
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSkills = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSkillsOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSkillsSave = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSkillsSeperator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuSkillsAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSkillsDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.pageSkillBase = new System.Windows.Forms.TabPage();
			this.cbLevel = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSaveSkill = new System.Windows.Forms.Button();
			this.cbGameMode = new System.Windows.Forms.ComboBox();
			this.cbSkillType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbIcon = new Ssc.ImageComboBox();
			this.iconList = new System.Windows.Forms.ImageList( this.components );
			this.label1 = new System.Windows.Forms.Label();
			this.pageLevel1 = new System.Windows.Forms.TabPage();
			this.skillLevelPanel1 = new Shaiya_Skill_Editor.SkillLevelPanel();
			this.pageLevel2 = new System.Windows.Forms.TabPage();
			this.skillLevelPanel2 = new Shaiya_Skill_Editor.SkillLevelPanel();
			this.pageLevel3 = new System.Windows.Forms.TabPage();
			this.skillLevelPanel3 = new Shaiya_Skill_Editor.SkillLevelPanel();
			this.listSkills = new System.Windows.Forms.ListView();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.pageSkillBase.SuspendLayout();
			this.pageLevel1.SuspendLayout();
			this.pageLevel2.SuspendLayout();
			this.pageLevel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusText,
            this.lblStatus} );
			this.statusStrip1.Location = new System.Drawing.Point( 0, 387 );
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size( 753, 22 );
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblStatusText
			// 
			this.lblStatusText.Name = "lblStatusText";
			this.lblStatusText.Size = new System.Drawing.Size( 42, 17 );
			this.lblStatusText.Text = "Status:";
			// 
			// lblStatus
			// 
			this.lblStatus.ForeColor = System.Drawing.Color.ForestGreen;
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size( 38, 17 );
			this.lblStatus.Text = "Ready";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram,
            this.MenuSkills,
            this.MenuAbout} );
			this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size( 753, 24 );
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// MenuProgram
			// 
			this.MenuProgram.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgramClose} );
			this.MenuProgram.Name = "MenuProgram";
			this.MenuProgram.Size = new System.Drawing.Size( 67, 20 );
			this.MenuProgram.Text = "Programm";
			// 
			// MenuProgramClose
			// 
			this.MenuProgramClose.Name = "MenuProgramClose";
			this.MenuProgramClose.Size = new System.Drawing.Size( 116, 22 );
			this.MenuProgramClose.Text = "Beenden";
			this.MenuProgramClose.Click += new System.EventHandler( this.MenuProgramClose_Click );
			// 
			// MenuSkills
			// 
			this.MenuSkills.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuSkillsOpen,
            this.MenuSkillsSave,
            this.MenuSkillsSeperator1,
            this.MenuSkillsAdd,
            this.MenuSkillsDelete} );
			this.MenuSkills.Name = "MenuSkills";
			this.MenuSkills.Size = new System.Drawing.Size( 43, 20 );
			this.MenuSkills.Text = "Skillls";
			// 
			// MenuSkillsOpen
			// 
			this.MenuSkillsOpen.Name = "MenuSkillsOpen";
			this.MenuSkillsOpen.Size = new System.Drawing.Size( 147, 22 );
			this.MenuSkillsOpen.Text = "Öffnen...";
			this.MenuSkillsOpen.Click += new System.EventHandler( this.MenuSkillsOpen_Click );
			// 
			// MenuSkillsSave
			// 
			this.MenuSkillsSave.Enabled = false;
			this.MenuSkillsSave.Name = "MenuSkillsSave";
			this.MenuSkillsSave.Size = new System.Drawing.Size( 147, 22 );
			this.MenuSkillsSave.Text = "Speichern...";
			this.MenuSkillsSave.Click += new System.EventHandler( this.MenuSkillsSave_Click );
			// 
			// MenuSkillsSeperator1
			// 
			this.MenuSkillsSeperator1.Name = "MenuSkillsSeperator1";
			this.MenuSkillsSeperator1.Size = new System.Drawing.Size( 144, 6 );
			this.MenuSkillsSeperator1.Visible = false;
			// 
			// MenuSkillsAdd
			// 
			this.MenuSkillsAdd.Name = "MenuSkillsAdd";
			this.MenuSkillsAdd.Size = new System.Drawing.Size( 147, 22 );
			this.MenuSkillsAdd.Text = "Skill hinzufügen";
			this.MenuSkillsAdd.Visible = false;
			this.MenuSkillsAdd.Click += new System.EventHandler( this.MenuSkillsAdd_Click );
			// 
			// MenuSkillsDelete
			// 
			this.MenuSkillsDelete.Enabled = false;
			this.MenuSkillsDelete.Name = "MenuSkillsDelete";
			this.MenuSkillsDelete.Size = new System.Drawing.Size( 147, 22 );
			this.MenuSkillsDelete.Text = "Skill löschen";
			this.MenuSkillsDelete.Visible = false;
			this.MenuSkillsDelete.Click += new System.EventHandler( this.MenuSkillsDelete_Click );
			// 
			// MenuAbout
			// 
			this.MenuAbout.Name = "MenuAbout";
			this.MenuAbout.Size = new System.Drawing.Size( 54, 20 );
			this.MenuAbout.Text = "Über...";
			this.MenuAbout.Click += new System.EventHandler( this.MenuAbout_Click );
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tabControl1.Controls.Add( this.pageSkillBase );
			this.tabControl1.Controls.Add( this.pageLevel1 );
			this.tabControl1.Controls.Add( this.pageLevel2 );
			this.tabControl1.Controls.Add( this.pageLevel3 );
			this.tabControl1.Location = new System.Drawing.Point( 236, 27 );
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size( 505, 353 );
			this.tabControl1.TabIndex = 3;
			// 
			// pageSkillBase
			// 
			this.pageSkillBase.Controls.Add( this.cbLevel );
			this.pageSkillBase.Controls.Add( this.label4 );
			this.pageSkillBase.Controls.Add( this.btnSaveSkill );
			this.pageSkillBase.Controls.Add( this.cbGameMode );
			this.pageSkillBase.Controls.Add( this.cbSkillType );
			this.pageSkillBase.Controls.Add( this.label3 );
			this.pageSkillBase.Controls.Add( this.label2 );
			this.pageSkillBase.Controls.Add( this.cbIcon );
			this.pageSkillBase.Controls.Add( this.label1 );
			this.pageSkillBase.Location = new System.Drawing.Point( 4, 22 );
			this.pageSkillBase.Name = "pageSkillBase";
			this.pageSkillBase.Padding = new System.Windows.Forms.Padding( 3 );
			this.pageSkillBase.Size = new System.Drawing.Size( 497, 327 );
			this.pageSkillBase.TabIndex = 3;
			this.pageSkillBase.Text = "Skill Basis";
			this.pageSkillBase.UseVisualStyleBackColor = true;
			// 
			// cbLevel
			// 
			this.cbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLevel.FormattingEnabled = true;
			this.cbLevel.Items.AddRange( new object[] {
            "1",
            "2",
            "3"} );
			this.cbLevel.Location = new System.Drawing.Point( 54, 101 );
			this.cbLevel.Name = "cbLevel";
			this.cbLevel.Size = new System.Drawing.Size( 44, 21 );
			this.cbLevel.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 7, 104 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 33, 13 );
			this.label4.TabIndex = 7;
			this.label4.Text = "Level";
			// 
			// btnSaveSkill
			// 
			this.btnSaveSkill.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.btnSaveSkill.Enabled = false;
			this.btnSaveSkill.Location = new System.Drawing.Point( 3, 298 );
			this.btnSaveSkill.Name = "btnSaveSkill";
			this.btnSaveSkill.Size = new System.Drawing.Size( 75, 23 );
			this.btnSaveSkill.TabIndex = 6;
			this.btnSaveSkill.Text = "Speichern";
			this.btnSaveSkill.UseVisualStyleBackColor = true;
			this.btnSaveSkill.Click += new System.EventHandler( this.btnSaveSkill_Click );
			// 
			// cbGameMode
			// 
			this.cbGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGameMode.FormattingEnabled = true;
			this.cbGameMode.Location = new System.Drawing.Point( 54, 74 );
			this.cbGameMode.Name = "cbGameMode";
			this.cbGameMode.Size = new System.Drawing.Size( 127, 21 );
			this.cbGameMode.TabIndex = 5;
			// 
			// cbSkillType
			// 
			this.cbSkillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSkillType.FormattingEnabled = true;
			this.cbSkillType.Location = new System.Drawing.Point( 54, 47 );
			this.cbSkillType.Name = "cbSkillType";
			this.cbSkillType.Size = new System.Drawing.Size( 127, 21 );
			this.cbSkillType.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 7, 77 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 34, 13 );
			this.label3.TabIndex = 3;
			this.label3.Text = "Mode";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 7, 50 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 25, 13 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Typ";
			// 
			// cbIcon
			// 
			this.cbIcon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbIcon.FormattingEnabled = true;
			this.cbIcon.ImageList = this.iconList;
			this.cbIcon.ImagePlace = 0;
			this.cbIcon.ItemHeight = 32;
			this.cbIcon.Location = new System.Drawing.Point( 54, 3 );
			this.cbIcon.Name = "cbIcon";
			this.cbIcon.Size = new System.Drawing.Size( 127, 38 );
			this.cbIcon.TabIndex = 1;
			// 
			// iconList
			// 
			this.iconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.iconList.ImageSize = new System.Drawing.Size( 32, 32 );
			this.iconList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 7, 17 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 28, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Icon";
			// 
			// pageLevel1
			// 
			this.pageLevel1.Controls.Add( this.skillLevelPanel1 );
			this.pageLevel1.Location = new System.Drawing.Point( 4, 22 );
			this.pageLevel1.Name = "pageLevel1";
			this.pageLevel1.Padding = new System.Windows.Forms.Padding( 3 );
			this.pageLevel1.Size = new System.Drawing.Size( 497, 327 );
			this.pageLevel1.TabIndex = 0;
			this.pageLevel1.Text = "Level 1";
			this.pageLevel1.UseVisualStyleBackColor = true;
			// 
			// skillLevelPanel1
			// 
			this.skillLevelPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skillLevelPanel1.Location = new System.Drawing.Point( 3, 3 );
			this.skillLevelPanel1.Name = "skillLevelPanel1";
			this.skillLevelPanel1.Size = new System.Drawing.Size( 491, 321 );
			this.skillLevelPanel1.TabIndex = 0;
			// 
			// pageLevel2
			// 
			this.pageLevel2.Controls.Add( this.skillLevelPanel2 );
			this.pageLevel2.Location = new System.Drawing.Point( 4, 22 );
			this.pageLevel2.Name = "pageLevel2";
			this.pageLevel2.Padding = new System.Windows.Forms.Padding( 3 );
			this.pageLevel2.Size = new System.Drawing.Size( 497, 327 );
			this.pageLevel2.TabIndex = 1;
			this.pageLevel2.Text = "Level 2";
			this.pageLevel2.UseVisualStyleBackColor = true;
			// 
			// skillLevelPanel2
			// 
			this.skillLevelPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skillLevelPanel2.Location = new System.Drawing.Point( 3, 3 );
			this.skillLevelPanel2.Name = "skillLevelPanel2";
			this.skillLevelPanel2.Size = new System.Drawing.Size( 491, 321 );
			this.skillLevelPanel2.TabIndex = 1;
			// 
			// pageLevel3
			// 
			this.pageLevel3.Controls.Add( this.skillLevelPanel3 );
			this.pageLevel3.Location = new System.Drawing.Point( 4, 22 );
			this.pageLevel3.Name = "pageLevel3";
			this.pageLevel3.Padding = new System.Windows.Forms.Padding( 3 );
			this.pageLevel3.Size = new System.Drawing.Size( 497, 327 );
			this.pageLevel3.TabIndex = 2;
			this.pageLevel3.Text = "Level 3";
			this.pageLevel3.UseVisualStyleBackColor = true;
			// 
			// skillLevelPanel3
			// 
			this.skillLevelPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skillLevelPanel3.Location = new System.Drawing.Point( 3, 3 );
			this.skillLevelPanel3.Name = "skillLevelPanel3";
			this.skillLevelPanel3.Size = new System.Drawing.Size( 491, 321 );
			this.skillLevelPanel3.TabIndex = 1;
			// 
			// listSkills
			// 
			this.listSkills.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.colName} );
			this.listSkills.FullRowSelect = true;
			this.listSkills.GridLines = true;
			this.listSkills.Location = new System.Drawing.Point( 12, 27 );
			this.listSkills.MultiSelect = false;
			this.listSkills.Name = "listSkills";
			this.listSkills.Size = new System.Drawing.Size( 218, 353 );
			this.listSkills.SmallImageList = this.iconList;
			this.listSkills.TabIndex = 4;
			this.listSkills.UseCompatibleStateImageBehavior = false;
			this.listSkills.View = System.Windows.Forms.View.Details;
			this.listSkills.SelectedIndexChanged += new System.EventHandler( this.listSkills_SelectedIndexChanged );
			// 
			// colName
			// 
			this.colName.Text = "Skillname";
			this.colName.Width = 173;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 753, 409 );
			this.Controls.Add( this.listSkills );
			this.Controls.Add( this.tabControl1 );
			this.Controls.Add( this.statusStrip1 );
			this.Controls.Add( this.menuStrip1 );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.Text = "Shaiya Skill Editor - by GodLesZ 4 r0xy.";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler( this.frmMain_KeyUp );
			this.statusStrip1.ResumeLayout( false );
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout( false );
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout( false );
			this.pageSkillBase.ResumeLayout( false );
			this.pageSkillBase.PerformLayout();
			this.pageLevel1.ResumeLayout( false );
			this.pageLevel2.ResumeLayout( false );
			this.pageLevel3.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem MenuProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramClose;
		private System.Windows.Forms.ToolStripMenuItem MenuSkills;
		private System.Windows.Forms.ToolStripMenuItem MenuSkillsOpen;
		private System.Windows.Forms.ToolStripMenuItem MenuSkillsSave;
		private System.Windows.Forms.ToolStripMenuItem MenuAbout;
		private System.Windows.Forms.ToolStripSeparator MenuSkillsSeperator1;
		private System.Windows.Forms.ToolStripMenuItem MenuSkillsAdd;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage pageLevel1;
		private System.Windows.Forms.TabPage pageLevel2;
		private System.Windows.Forms.TabPage pageLevel3;
		private System.Windows.Forms.TabPage pageSkillBase;
		private SkillLevelPanel skillLevelPanel1;
		private SkillLevelPanel skillLevelPanel2;
		private SkillLevelPanel skillLevelPanel3;
		private System.Windows.Forms.Label label1;
		private Ssc.ImageComboBox cbIcon;
		private System.Windows.Forms.ImageList iconList;
		private System.Windows.Forms.ComboBox cbGameMode;
		private System.Windows.Forms.ComboBox cbSkillType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSaveSkill;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusText;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ListView listSkills;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ToolStripMenuItem MenuSkillsDelete;
		private System.Windows.Forms.ComboBox cbLevel;
		private System.Windows.Forms.Label label4;
	}
}

