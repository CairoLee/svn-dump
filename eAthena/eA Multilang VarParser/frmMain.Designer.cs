namespace eA_Script_VarParser {
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
			this.btnOpen = new System.Windows.Forms.Button();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.listLog = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point( 13, 15 );
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size( 75, 21 );
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler( this.btnOpen_Click );
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point( 94, 15 );
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size( 386, 20 );
			this.txtPath.TabIndex = 1;
			// 
			// listLog
			// 
			this.listLog.FormattingEnabled = true;
			this.listLog.Location = new System.Drawing.Point( 13, 59 );
			this.listLog.Name = "listLog";
			this.listLog.Size = new System.Drawing.Size( 467, 316 );
			this.listLog.TabIndex = 2;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 492, 392 );
			this.Controls.Add( this.listLog );
			this.Controls.Add( this.txtPath );
			this.Controls.Add( this.btnOpen );
			this.Name = "frmMain";
			this.Text = "Form1";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.ListBox listLog;
	}
}

