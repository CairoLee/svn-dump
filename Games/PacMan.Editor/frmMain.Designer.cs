namespace PacMan.Editor {
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
			this.imageEditor = new System.Windows.Forms.PictureBox();
			this.lblWall = new System.Windows.Forms.Label();
			this.btnWall = new System.Windows.Forms.Button();
			this.btnPath = new System.Windows.Forms.Button();
			this.lblPath = new System.Windows.Forms.Label();
			this.btnHomeBase = new System.Windows.Forms.Button();
			this.lblHomeBase = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.menuProgramNewLevel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.imageEditor)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageEditor
			// 
			this.imageEditor.BackColor = System.Drawing.Color.LightCoral;
			this.imageEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imageEditor.Location = new System.Drawing.Point(12, 41);
			this.imageEditor.Name = "imageEditor";
			this.imageEditor.Size = new System.Drawing.Size(500, 500);
			this.imageEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imageEditor.TabIndex = 0;
			this.imageEditor.TabStop = false;
			this.imageEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageEditor_MouseClick);
			this.imageEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageEditor_MouseDown);
			this.imageEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageEditor_MouseMove);
			this.imageEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageEditor_MouseUp);
			// 
			// lblWall
			// 
			this.lblWall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWall.BackColor = System.Drawing.Color.ForestGreen;
			this.lblWall.Location = new System.Drawing.Point(743, 43);
			this.lblWall.Name = "lblWall";
			this.lblWall.Size = new System.Drawing.Size(20, 20);
			this.lblWall.TabIndex = 2;
			// 
			// btnWall
			// 
			this.btnWall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWall.Location = new System.Drawing.Point(661, 41);
			this.btnWall.Name = "btnWall";
			this.btnWall.Size = new System.Drawing.Size(75, 23);
			this.btnWall.TabIndex = 3;
			this.btnWall.Text = "Wand";
			this.btnWall.UseVisualStyleBackColor = true;
			this.btnWall.Click += new System.EventHandler(this.btnWall_Click);
			// 
			// btnPath
			// 
			this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPath.Location = new System.Drawing.Point(661, 70);
			this.btnPath.Name = "btnPath";
			this.btnPath.Size = new System.Drawing.Size(75, 23);
			this.btnPath.TabIndex = 5;
			this.btnPath.Text = "Weg";
			this.btnPath.UseVisualStyleBackColor = true;
			this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// lblPath
			// 
			this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPath.BackColor = System.Drawing.Color.Transparent;
			this.lblPath.Location = new System.Drawing.Point(743, 72);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(20, 20);
			this.lblPath.TabIndex = 4;
			// 
			// btnHomeBase
			// 
			this.btnHomeBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHomeBase.Location = new System.Drawing.Point(661, 99);
			this.btnHomeBase.Name = "btnHomeBase";
			this.btnHomeBase.Size = new System.Drawing.Size(75, 23);
			this.btnHomeBase.TabIndex = 7;
			this.btnHomeBase.Text = "Gegner";
			this.btnHomeBase.UseVisualStyleBackColor = true;
			this.btnHomeBase.Click += new System.EventHandler(this.btnHomeBase_Click);
			// 
			// lblHomeBase
			// 
			this.lblHomeBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblHomeBase.BackColor = System.Drawing.Color.Transparent;
			this.lblHomeBase.Location = new System.Drawing.Point(743, 101);
			this.lblHomeBase.Name = "lblHomeBase";
			this.lblHomeBase.Size = new System.Drawing.Size(20, 20);
			this.lblHomeBase.TabIndex = 6;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(690, 527);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProgram});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(775, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuProgram
			// 
			this.menuProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProgramNewLevel,
            this.toolStripSeparator1,
            this.menuProgramClose});
			this.menuProgram.Name = "menuProgram";
			this.menuProgram.Size = new System.Drawing.Size(76, 20);
			this.menuProgram.Text = "Programm";
			// 
			// menuProgramNewLevel
			// 
			this.menuProgramNewLevel.Name = "menuProgramNewLevel";
			this.menuProgramNewLevel.Size = new System.Drawing.Size(152, 22);
			this.menuProgramNewLevel.Text = "Neues Level";
			this.menuProgramNewLevel.Click += new System.EventHandler(this.menuProgramNewLevel_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// menuProgramClose
			// 
			this.menuProgramClose.Name = "menuProgramClose";
			this.menuProgramClose.Size = new System.Drawing.Size(152, 22);
			this.menuProgramClose.Text = "Beenden";
			this.menuProgramClose.Click += new System.EventHandler(this.menuProgramClose_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 562);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnHomeBase);
			this.Controls.Add(this.lblHomeBase);
			this.Controls.Add(this.btnPath);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.btnWall);
			this.Controls.Add(this.lblWall);
			this.Controls.Add(this.imageEditor);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(600, 600);
			this.Name = "frmMain";
			this.Text = "PacMan Level Editor";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.imageEditor)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox imageEditor;
		private System.Windows.Forms.Label lblWall;
		private System.Windows.Forms.Button btnWall;
		private System.Windows.Forms.Button btnPath;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Button btnHomeBase;
		private System.Windows.Forms.Label lblHomeBase;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuProgram;
		private System.Windows.Forms.ToolStripMenuItem menuProgramNewLevel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuProgramClose;
	}
}

