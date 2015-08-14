namespace eAthenaStudio.Client {
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
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingsOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPlugins = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlPlugins = new System.Windows.Forms.Panel();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram,
            this.MenuSettings,
            this.MenuPlugins,
            this.MenuAbout});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(675, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// MenuProgram
			// 
			this.MenuProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgramClose});
			this.MenuProgram.Image = global::eAthenaStudio.Client.Properties.Resources.application;
			this.MenuProgram.Name = "MenuProgram";
			this.MenuProgram.Size = new System.Drawing.Size(83, 20);
			this.MenuProgram.Text = "Programm";
			// 
			// MenuProgramClose
			// 
			this.MenuProgramClose.Name = "MenuProgramClose";
			this.MenuProgramClose.Size = new System.Drawing.Size(116, 22);
			this.MenuProgramClose.Text = "Beenden";
			this.MenuProgramClose.Click += new System.EventHandler(this.MenuProgramClose_Click);
			// 
			// MenuSettings
			// 
			this.MenuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSettingsOptions});
			this.MenuSettings.Image = global::eAthenaStudio.Client.Properties.Resources.application_edit;
			this.MenuSettings.Name = "MenuSettings";
			this.MenuSettings.Size = new System.Drawing.Size(98, 20);
			this.MenuSettings.Text = "Einstellungen";
			// 
			// MenuSettingsOptions
			// 
			this.MenuSettingsOptions.Image = global::eAthenaStudio.Client.Properties.Resources.wrench;
			this.MenuSettingsOptions.Name = "MenuSettingsOptions";
			this.MenuSettingsOptions.Size = new System.Drawing.Size(126, 22);
			this.MenuSettingsOptions.Text = "Optionen..";
			this.MenuSettingsOptions.Click += new System.EventHandler(this.MenuSettingsOptions_Click);
			// 
			// MenuPlugins
			// 
			this.MenuPlugins.Image = global::eAthenaStudio.Client.Properties.Resources.plugin;
			this.MenuPlugins.Name = "MenuPlugins";
			this.MenuPlugins.Size = new System.Drawing.Size(68, 20);
			this.MenuPlugins.Text = "Plugins";
			// 
			// MenuAbout
			// 
			this.MenuAbout.Image = global::eAthenaStudio.Client.Properties.Resources.application_form_magnify;
			this.MenuAbout.Name = "MenuAbout";
			this.MenuAbout.Size = new System.Drawing.Size(64, 20);
			this.MenuAbout.Text = "About";
			// 
			// pnlPlugins
			// 
			this.pnlPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlPlugins.BackColor = System.Drawing.SystemColors.Control;
			this.pnlPlugins.Location = new System.Drawing.Point(13, 28);
			this.pnlPlugins.Margin = new System.Windows.Forms.Padding(0);
			this.pnlPlugins.Name = "pnlPlugins";
			this.pnlPlugins.Size = new System.Drawing.Size(650, 272);
			this.pnlPlugins.TabIndex = 1;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(675, 312);
			this.Controls.Add(this.pnlPlugins);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "frmMain";
			this.Text = "eAthena Tool - by GodLesZ";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem MenuProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramClose;
		private System.Windows.Forms.ToolStripMenuItem MenuSettings;
		private System.Windows.Forms.ToolStripMenuItem MenuPlugins;
		private System.Windows.Forms.ToolStripMenuItem MenuAbout;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingsOptions;
		private System.Windows.Forms.Panel pnlPlugins;
	}
}

