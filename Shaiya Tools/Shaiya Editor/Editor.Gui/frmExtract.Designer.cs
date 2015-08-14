namespace Editor.Gui {
	partial class frmExtract {
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
			this.progressStatus = new System.Windows.Forms.ProgressBar();
			this.lblStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressStatus
			// 
			this.progressStatus.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.progressStatus.Location = new System.Drawing.Point( 12, 35 );
			this.progressStatus.Name = "progressStatus";
			this.progressStatus.Size = new System.Drawing.Size( 352, 20 );
			this.progressStatus.TabIndex = 0;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point( 9, 9 );
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size( 0, 13 );
			this.lblStatus.TabIndex = 1;
			// 
			// frmExtract
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 376, 67 );
			this.Controls.Add( this.lblStatus );
			this.Controls.Add( this.progressStatus );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmExtract";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Entpacken...";
			this.Load += new System.EventHandler( this.frmExtract_Load );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmExtract_FormClosing );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressStatus;
		private System.Windows.Forms.Label lblStatus;
	}
}