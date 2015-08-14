namespace eAthenaTool.Plugins.EditSprite {
	partial class frmPaletteEditor {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.pnlColors = new System.Windows.Forms.Panel();
			this.lblColorRGB = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblColorIndex = new System.Windows.Forms.ToolStripStatusLabel();
			this.paletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.alsBildSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.paletteToolStripMenuItem} );
			this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size( 282, 24 );
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lblColorIndex,
            this.lblColorRGB} );
			this.statusStrip1.Location = new System.Drawing.Point( 0, 306 );
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size( 282, 22 );
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// pnlColors
			// 
			this.pnlColors.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlColors.Location = new System.Drawing.Point( 0, 24 );
			this.pnlColors.Margin = new System.Windows.Forms.Padding( 0 );
			this.pnlColors.Name = "pnlColors";
			this.pnlColors.Padding = new System.Windows.Forms.Padding( 10 );
			this.pnlColors.Size = new System.Drawing.Size( 282, 282 );
			this.pnlColors.TabIndex = 2;
			// 
			// lblColorRGB
			// 
			this.lblColorRGB.AutoSize = false;
			this.lblColorRGB.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides)( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
			this.lblColorRGB.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblColorRGB.Name = "lblColorRGB";
			this.lblColorRGB.Size = new System.Drawing.Size( 120, 17 );
			this.lblColorRGB.Text = "Farbe: 255, 255, 255";
			this.lblColorRGB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblColorIndex
			// 
			this.lblColorIndex.AutoSize = false;
			this.lblColorIndex.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides)( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
			this.lblColorIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblColorIndex.Name = "lblColorIndex";
			this.lblColorIndex.Size = new System.Drawing.Size( 70, 17 );
			this.lblColorIndex.Text = "Index: 256";
			this.lblColorIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// paletteToolStripMenuItem
			// 
			this.paletteToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.exportierenToolStripMenuItem,
            this.importierenToolStripMenuItem,
            this.toolStripSeparator1,
            this.alsBildSpeichernToolStripMenuItem} );
			this.paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
			this.paletteToolStripMenuItem.Size = new System.Drawing.Size( 53, 20 );
			this.paletteToolStripMenuItem.Text = "Palette";
			// 
			// exportierenToolStripMenuItem
			// 
			this.exportierenToolStripMenuItem.Name = "exportierenToolStripMenuItem";
			this.exportierenToolStripMenuItem.Size = new System.Drawing.Size( 168, 22 );
			this.exportierenToolStripMenuItem.Text = "Exportieren...";
			// 
			// importierenToolStripMenuItem
			// 
			this.importierenToolStripMenuItem.Name = "importierenToolStripMenuItem";
			this.importierenToolStripMenuItem.Size = new System.Drawing.Size( 168, 22 );
			this.importierenToolStripMenuItem.Text = "Importieren...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 165, 6 );
			// 
			// alsBildSpeichernToolStripMenuItem
			// 
			this.alsBildSpeichernToolStripMenuItem.Name = "alsBildSpeichernToolStripMenuItem";
			this.alsBildSpeichernToolStripMenuItem.Size = new System.Drawing.Size( 168, 22 );
			this.alsBildSpeichernToolStripMenuItem.Text = "Als Bild speichern...";
			// 
			// frmPaletteEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 282, 328 );
			this.Controls.Add( this.pnlColors );
			this.Controls.Add( this.statusStrip1 );
			this.Controls.Add( this.menuStrip1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmPaletteEditor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Paletten Editor";
			this.menuStrip1.ResumeLayout( false );
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout( false );
			this.statusStrip1.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel pnlColors;
		private System.Windows.Forms.ToolStripStatusLabel lblColorRGB;
		private System.Windows.Forms.ToolStripStatusLabel lblColorIndex;
		private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportierenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importierenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem alsBildSpeichernToolStripMenuItem;
	}
}