namespace GrfEditor.Client {
	partial class FrmExtract {
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
			this.lblInfo = new System.Windows.Forms.Label();
			this.progressFiles = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(9, 9);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(81, 13);
			this.lblInfo.TabIndex = 0;
			this.lblInfo.Text = "File: searching..";
			// 
			// progressFiles
			// 
			this.progressFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressFiles.Location = new System.Drawing.Point(12, 35);
			this.progressFiles.Name = "progressFiles";
			this.progressFiles.Size = new System.Drawing.Size(587, 23);
			this.progressFiles.TabIndex = 1;
			// 
			// frmExtract
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(611, 70);
			this.Controls.Add(this.progressFiles);
			this.Controls.Add(this.lblInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmExtract";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Extracting..";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExtract_FormClosing);
			this.Load += new System.EventHandler(this.frmExtract_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.ProgressBar progressFiles;
	}
}