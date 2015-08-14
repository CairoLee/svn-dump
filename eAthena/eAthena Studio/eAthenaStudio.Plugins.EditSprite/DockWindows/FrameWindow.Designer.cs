namespace eAthenaStudio.Plugins.EditSprite {
	partial class FrameWindow {
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatusSize = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatusFrames = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatusZoom = new System.Windows.Forms.ToolStripStatusLabel();
			this.imageSprite = new eAthenaStudio.Plugins.EditSprite.Controls.ZoomableSpriteFrame();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageSprite)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.lblStatusSize,
			this.lblStatusFrames,
			this.toolStripStatusLabel1,
			this.lblStatusZoom});
			this.statusStrip1.Location = new System.Drawing.Point(0, 321);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(433, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblStatusSize
			// 
			this.lblStatusSize.AutoSize = false;
			this.lblStatusSize.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.lblStatusSize.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblStatusSize.Name = "lblStatusSize";
			this.lblStatusSize.Size = new System.Drawing.Size(70, 17);
			this.lblStatusSize.Text = "100 x 100";
			this.lblStatusSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusFrames
			// 
			this.lblStatusFrames.AutoSize = false;
			this.lblStatusFrames.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.lblStatusFrames.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblStatusFrames.Name = "lblStatusFrames";
			this.lblStatusFrames.Size = new System.Drawing.Size(70, 17);
			this.lblStatusFrames.Text = "999/999";
			this.lblStatusFrames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(223, 17);
			this.toolStripStatusLabel1.Spring = true;
			// 
			// lblStatusZoom
			// 
			this.lblStatusZoom.AutoSize = false;
			this.lblStatusZoom.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.lblStatusZoom.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblStatusZoom.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.ZoomHS;
			this.lblStatusZoom.Margin = new System.Windows.Forms.Padding(0);
			this.lblStatusZoom.Name = "lblStatusZoom";
			this.lblStatusZoom.Size = new System.Drawing.Size(55, 22);
			this.lblStatusZoom.Text = "1.0";
			// 
			// imageSprite
			// 
			this.imageSprite.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageSprite.Font = new System.Drawing.Font("Tahoma", 9F);
			this.imageSprite.ForeColor = System.Drawing.Color.White;
			this.imageSprite.HoverColor = System.Drawing.Color.Transparent;
			this.imageSprite.Location = new System.Drawing.Point(0, 0);
			this.imageSprite.Name = "imageSprite";
			this.imageSprite.PaddingBottom = 20;
			this.imageSprite.PaddingLeft = 40;
			this.imageSprite.SelectedColor = System.Drawing.Color.Empty;
			this.imageSprite.Size = new System.Drawing.Size(433, 321);
			this.imageSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imageSprite.SpriteFrame = null;
			this.imageSprite.TabIndex = 8;
			this.imageSprite.TabStop = false;
			this.imageSprite.Zoom = 1F;
			// 
			// FrameWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 343);
			this.CloseButton = false;
			this.CloseButtonVisible = false;
			this.Controls.Add(this.imageSprite);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HideOnClose = true;
			this.Name = "FrameWindow";
			this.ShowHint = GodLesZ.Library.Docking.DockState.Document;
			this.TabText = "Frame";
			this.Text = "Frame Preview";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageSprite)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusSize;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusFrames;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusZoom;
		private eAthenaStudio.Plugins.EditSprite.Controls.ZoomableSpriteFrame imageSprite;
	}
}