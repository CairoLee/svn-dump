namespace ToolAdler32 {
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
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.txtChecksum = new System.Windows.Forms.TextBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.chkHex = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtPath.Location = new System.Drawing.Point( 51, 13 );
			this.txtPath.Name = "txtPath";
			this.txtPath.ReadOnly = true;
			this.txtPath.Size = new System.Drawing.Size( 301, 20 );
			this.txtPath.TabIndex = 0;
			this.txtPath.TextChanged += new System.EventHandler( this.txtPath_TextChanged );
			// 
			// btnOpen
			// 
			this.btnOpen.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOpen.Location = new System.Drawing.Point( 358, 13 );
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size( 75, 20 );
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Öffnen";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler( this.btnOpen_Click );
			// 
			// txtChecksum
			// 
			this.txtChecksum.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtChecksum.Location = new System.Drawing.Point( 13, 108 );
			this.txtChecksum.Name = "txtChecksum";
			this.txtChecksum.ReadOnly = true;
			this.txtChecksum.Size = new System.Drawing.Size( 366, 20 );
			this.txtChecksum.TabIndex = 2;
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.progressBar.Location = new System.Drawing.Point( 13, 84 );
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size( 420, 18 );
			this.progressBar.TabIndex = 3;
			// 
			// chkHex
			// 
			this.chkHex.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.chkHex.AutoSize = true;
			this.chkHex.Location = new System.Drawing.Point( 385, 110 );
			this.chkHex.Name = "chkHex";
			this.chkHex.Size = new System.Drawing.Size( 48, 17 );
			this.chkHex.TabIndex = 4;
			this.chkHex.Text = "HEX";
			this.chkHex.UseVisualStyleBackColor = true;
			this.chkHex.CheckedChanged += new System.EventHandler( this.chkHex_CheckedChanged );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 10, 16 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 35, 13 );
			this.label1.TabIndex = 5;
			this.label1.Text = "Datei:";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 445, 144 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.chkHex );
			this.Controls.Add( this.progressBar );
			this.Controls.Add( this.txtChecksum );
			this.Controls.Add( this.btnOpen );
			this.Controls.Add( this.txtPath );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmMain";
			this.Text = "Adler32 Tool - part of GodLesZ\' Client Protection";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.TextBox txtChecksum;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.CheckBox chkHex;
		private System.Windows.Forms.Label label1;
	}
}

