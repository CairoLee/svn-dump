namespace GodLesZ.Ragnarok.SkillCalculator {
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
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuMainProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainMobs = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainMobsReload = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainSkills = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainSkillsReload = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusMain = new System.Windows.Forms.StatusStrip();
			this.cmbSkills = new GodLesZ.Ragnarok.SkillCalculator.Library.Controls.SkillComboBox();
			this.btnChooseMob = new System.Windows.Forms.Button();
			this.mobPanel = new GodLesZ.Ragnarok.SkillCalculator.Library.Controls.MobPanel();
			this.menuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgram,
            this.menuMainMobs,
            this.menuMainSkills,
            this.menuMainAbout});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(688, 24);
			this.menuMain.TabIndex = 0;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuMainProgram
			// 
			this.menuMainProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgramClose});
			this.menuMainProgram.Name = "menuMainProgram";
			this.menuMainProgram.Size = new System.Drawing.Size(65, 20);
			this.menuMainProgram.Text = "Program";
			// 
			// menuMainProgramClose
			// 
			this.menuMainProgramClose.Name = "menuMainProgramClose";
			this.menuMainProgramClose.Size = new System.Drawing.Size(103, 22);
			this.menuMainProgramClose.Text = "Close";
			// 
			// menuMainMobs
			// 
			this.menuMainMobs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainMobsReload});
			this.menuMainMobs.Name = "menuMainMobs";
			this.menuMainMobs.Size = new System.Drawing.Size(49, 20);
			this.menuMainMobs.Text = "Mobs";
			// 
			// menuMainMobsReload
			// 
			this.menuMainMobsReload.Name = "menuMainMobsReload";
			this.menuMainMobsReload.Size = new System.Drawing.Size(110, 22);
			this.menuMainMobsReload.Text = "Reload";
			// 
			// menuMainSkills
			// 
			this.menuMainSkills.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainSkillsReload});
			this.menuMainSkills.Name = "menuMainSkills";
			this.menuMainSkills.Size = new System.Drawing.Size(45, 20);
			this.menuMainSkills.Text = "Skills";
			// 
			// menuMainSkillsReload
			// 
			this.menuMainSkillsReload.Name = "menuMainSkillsReload";
			this.menuMainSkillsReload.Size = new System.Drawing.Size(110, 22);
			this.menuMainSkillsReload.Text = "Reload";
			// 
			// menuMainAbout
			// 
			this.menuMainAbout.Name = "menuMainAbout";
			this.menuMainAbout.Size = new System.Drawing.Size(58, 20);
			this.menuMainAbout.Text = "About..";
			// 
			// statusMain
			// 
			this.statusMain.Location = new System.Drawing.Point(0, 438);
			this.statusMain.Name = "statusMain";
			this.statusMain.Size = new System.Drawing.Size(688, 22);
			this.statusMain.TabIndex = 1;
			this.statusMain.Text = "statusStrip1";
			// 
			// cmbSkills
			// 
			this.cmbSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSkills.FormattingEnabled = true;
			this.cmbSkills.ItemHeight = 25;
			this.cmbSkills.Location = new System.Drawing.Point(13, 39);
			this.cmbSkills.MaxDropDownItems = 10;
			this.cmbSkills.Name = "cmbSkills";
			this.cmbSkills.Size = new System.Drawing.Size(190, 31);
			this.cmbSkills.TabIndex = 2;
			// 
			// btnChooseMob
			// 
			this.btnChooseMob.Location = new System.Drawing.Point(252, 46);
			this.btnChooseMob.Name = "btnChooseMob";
			this.btnChooseMob.Size = new System.Drawing.Size(75, 23);
			this.btnChooseMob.TabIndex = 3;
			this.btnChooseMob.Text = "Select Mob";
			this.btnChooseMob.UseVisualStyleBackColor = true;
			this.btnChooseMob.Click += new System.EventHandler(this.btnChooseMob_Click);
			// 
			// mobPanel
			// 
			this.mobPanel.BackColor = System.Drawing.Color.Transparent;
			this.mobPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mobPanel.IsSelected = false;
			this.mobPanel.Location = new System.Drawing.Point(13, 96);
			this.mobPanel.Mob = null;
			this.mobPanel.Name = "mobPanel";
			this.mobPanel.Size = new System.Drawing.Size(226, 374);
			this.mobPanel.TabIndex = 4;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(688, 460);
			this.Controls.Add(this.mobPanel);
			this.Controls.Add(this.btnChooseMob);
			this.Controls.Add(this.cmbSkills);
			this.Controls.Add(this.statusMain);
			this.Controls.Add(this.menuMain);
			this.MainMenuStrip = this.menuMain;
			this.Name = "frmMain";
			this.Text = "Skill Calculator";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgram;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgramClose;
		private System.Windows.Forms.ToolStripMenuItem menuMainMobs;
		private System.Windows.Forms.ToolStripMenuItem menuMainMobsReload;
		private System.Windows.Forms.ToolStripMenuItem menuMainSkills;
		private System.Windows.Forms.ToolStripMenuItem menuMainSkillsReload;
		private System.Windows.Forms.ToolStripMenuItem menuMainAbout;
		private System.Windows.Forms.StatusStrip statusMain;
		private Library.Controls.SkillComboBox cmbSkills;
		private System.Windows.Forms.Button btnChooseMob;
		private Library.Controls.MobPanel mobPanel;
	}
}

