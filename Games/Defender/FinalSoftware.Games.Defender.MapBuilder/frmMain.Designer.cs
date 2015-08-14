namespace FinalSoftware.Games.Defender.MapBuilder {
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
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuMainProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainMap = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainMapBackground = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.imageBackground = new System.Windows.Forms.PictureBox();
			this.panelBackground = new System.Windows.Forms.Panel();
			this.menuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageBackground)).BeginInit();
			this.panelBackground.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgram,
            this.menuMainMap,
            this.menuMainAbout});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(764, 24);
			this.menuMain.TabIndex = 0;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuMainProgram
			// 
			this.menuMainProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgramClose});
			this.menuMainProgram.Name = "menuMainProgram";
			this.menuMainProgram.Size = new System.Drawing.Size(50, 20);
			this.menuMainProgram.Text = "Editor";
			// 
			// menuMainProgramClose
			// 
			this.menuMainProgramClose.Name = "menuMainProgramClose";
			this.menuMainProgramClose.Size = new System.Drawing.Size(103, 22);
			this.menuMainProgramClose.Text = "Close";
			this.menuMainProgramClose.Click += new System.EventHandler(this.menuMainProgramClose_Click);
			// 
			// menuMainMap
			// 
			this.menuMainMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainMapBackground});
			this.menuMainMap.Name = "menuMainMap";
			this.menuMainMap.Size = new System.Drawing.Size(43, 20);
			this.menuMainMap.Text = "Map";
			// 
			// menuMainMapBackground
			// 
			this.menuMainMapBackground.Name = "menuMainMapBackground";
			this.menuMainMapBackground.Size = new System.Drawing.Size(166, 22);
			this.menuMainMapBackground.Text = "Set background ..";
			this.menuMainMapBackground.Click += new System.EventHandler(this.menuMainMapBackground_Click);
			// 
			// menuMainAbout
			// 
			this.menuMainAbout.Name = "menuMainAbout";
			this.menuMainAbout.Size = new System.Drawing.Size(24, 20);
			this.menuMainAbout.Text = "?";
			this.menuMainAbout.Click += new System.EventHandler(this.menuMainAbout_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 376);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(764, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// imageBackground
			// 
			this.imageBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imageBackground.Location = new System.Drawing.Point(0, 0);
			this.imageBackground.Name = "imageBackground";
			this.imageBackground.Size = new System.Drawing.Size(764, 352);
			this.imageBackground.TabIndex = 2;
			this.imageBackground.TabStop = false;
			this.imageBackground.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBackground_MouseClick);
			this.imageBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageBackground_MouseDown);
			this.imageBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBackground_MouseMove);
			this.imageBackground.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageBackground_MouseUp);
			this.imageBackground.Resize += new System.EventHandler(this.imageBackground_Resize);
			// 
			// panelBackground
			// 
			this.panelBackground.AutoScroll = true;
			this.panelBackground.Controls.Add(this.imageBackground);
			this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBackground.Location = new System.Drawing.Point(0, 24);
			this.panelBackground.Name = "panelBackground";
			this.panelBackground.Size = new System.Drawing.Size(764, 352);
			this.panelBackground.TabIndex = 3;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 398);
			this.Controls.Add(this.panelBackground);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuMain);
			this.MainMenuStrip = this.menuMain;
			this.Name = "frmMain";
			this.Text = "Defender . Map Builder";
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageBackground)).EndInit();
			this.panelBackground.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgram;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgramClose;
		private System.Windows.Forms.ToolStripMenuItem menuMainMap;
		private System.Windows.Forms.ToolStripMenuItem menuMainMapBackground;
		private System.Windows.Forms.ToolStripMenuItem menuMainAbout;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.PictureBox imageBackground;
		private System.Windows.Forms.Panel panelBackground;


	}
}

