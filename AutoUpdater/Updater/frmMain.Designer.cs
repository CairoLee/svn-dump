namespace Updater {
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
			this.StatusProgress = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.StatusRtb = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// StatusProgress
			// 
			this.StatusProgress.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.StatusProgress.Location = new System.Drawing.Point( 12, 35 );
			this.StatusProgress.Name = "StatusProgress";
			this.StatusProgress.Size = new System.Drawing.Size( 331, 28 );
			this.StatusProgress.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 9, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 40, 13 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Status:";
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Location = new System.Drawing.Point( 55, 13 );
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size( 61, 13 );
			this.StatusLabel.TabIndex = 2;
			this.StatusLabel.Text = "intialisiere...";
			// 
			// StatusRtb
			// 
			this.StatusRtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StatusRtb.Location = new System.Drawing.Point( 13, 70 );
			this.StatusRtb.Name = "StatusRtb";
			this.StatusRtb.ReadOnly = true;
			this.StatusRtb.Size = new System.Drawing.Size( 330, 106 );
			this.StatusRtb.TabIndex = 3;
			this.StatusRtb.Text = "";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 355, 188 );
			this.Controls.Add( this.StatusRtb );
			this.Controls.Add( this.StatusLabel );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.StatusProgress );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Aktualisiere ";
			this.Load += new System.EventHandler( this.frmMain_Load );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmMain_FormClosing );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar StatusProgress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.RichTextBox StatusRtb;
	}
}

