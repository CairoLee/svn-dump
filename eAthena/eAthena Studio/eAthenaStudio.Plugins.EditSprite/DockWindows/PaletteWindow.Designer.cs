namespace eAthenaStudio.Plugins.EditSprite {
	partial class PaletteWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pnlPalette = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatusColorRGB = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlPalette
			// 
			this.pnlPalette.AutoScroll = true;
			this.pnlPalette.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlPalette.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPalette.Location = new System.Drawing.Point(0, 0);
			this.pnlPalette.Name = "pnlPalette";
			this.pnlPalette.Padding = new System.Windows.Forms.Padding(5);
			this.pnlPalette.Size = new System.Drawing.Size(297, 246);
			this.pnlPalette.TabIndex = 5;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel2,
			this.lblStatusColorRGB});
			this.statusStrip1.Location = new System.Drawing.Point(0, 246);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(297, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.DisplayInColorHS;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
			// 
			// lblStatusColorRGB
			// 
			this.lblStatusColorRGB.AutoSize = false;
			this.lblStatusColorRGB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.lblStatusColorRGB.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblStatusColorRGB.Name = "lblStatusColorRGB";
			this.lblStatusColorRGB.Size = new System.Drawing.Size(105, 17);
			this.lblStatusColorRGB.Text = "[255] 255, 255, 255";
			this.lblStatusColorRGB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PaletteWindow
			// 
			this.AllowEndUserDocking = false;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(297, 268);
			this.CloseButton = false;
			this.CloseButtonVisible = false;
			this.ControlBox = false;
			this.Controls.Add(this.pnlPalette);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.HideOnClose = true;
			this.Name = "PaletteWindow";
			this.ShowHint = GodLesZ.Library.Docking.DockState.DockRight;
			this.TabText = "Palette";
			this.Text = "Palette";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlPalette;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusColorRGB;
	}
}