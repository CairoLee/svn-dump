namespace ClientPatcher {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMain ) );
			this.btnPatchIt = new System.Windows.Forms.Button();
			this.txtPatchList = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPatchFile = new System.Windows.Forms.TextBox();
			this.btnOpenPatches = new System.Windows.Forms.Button();
			this.btnOpenPatchFile = new System.Windows.Forms.Button();
			this.btnAbout = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// btnPatchIt
			// 
			this.btnPatchIt.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnPatchIt.Enabled = false;
			this.btnPatchIt.Location = new System.Drawing.Point( 344, 188 );
			this.btnPatchIt.Name = "btnPatchIt";
			this.btnPatchIt.Size = new System.Drawing.Size( 65, 23 );
			this.btnPatchIt.TabIndex = 0;
			this.btnPatchIt.Text = "Patch";
			this.btnPatchIt.UseVisualStyleBackColor = true;
			this.btnPatchIt.Click += new System.EventHandler( this.btnPatchIt_Click );
			// 
			// txtPatchList
			// 
			this.txtPatchList.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtPatchList.Location = new System.Drawing.Point( 72, 6 );
			this.txtPatchList.Name = "txtPatchList";
			this.txtPatchList.Size = new System.Drawing.Size( 266, 20 );
			this.txtPatchList.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 1, 9 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 46, 13 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Patches";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 1, 35 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 66, 13 );
			this.label2.TabIndex = 4;
			this.label2.Text = "File to Patch";
			// 
			// txtPatchFile
			// 
			this.txtPatchFile.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtPatchFile.Location = new System.Drawing.Point( 73, 32 );
			this.txtPatchFile.Name = "txtPatchFile";
			this.txtPatchFile.Size = new System.Drawing.Size( 265, 20 );
			this.txtPatchFile.TabIndex = 3;
			// 
			// btnOpenPatches
			// 
			this.btnOpenPatches.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOpenPatches.Location = new System.Drawing.Point( 344, 4 );
			this.btnOpenPatches.Name = "btnOpenPatches";
			this.btnOpenPatches.Size = new System.Drawing.Size( 65, 23 );
			this.btnOpenPatches.TabIndex = 5;
			this.btnOpenPatches.Text = "Open";
			this.btnOpenPatches.UseVisualStyleBackColor = true;
			this.btnOpenPatches.Click += new System.EventHandler( this.btnOpenPatches_Click );
			// 
			// btnOpenPatchFile
			// 
			this.btnOpenPatchFile.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOpenPatchFile.Location = new System.Drawing.Point( 344, 30 );
			this.btnOpenPatchFile.Name = "btnOpenPatchFile";
			this.btnOpenPatchFile.Size = new System.Drawing.Size( 65, 23 );
			this.btnOpenPatchFile.TabIndex = 6;
			this.btnOpenPatchFile.Text = "Open";
			this.btnOpenPatchFile.UseVisualStyleBackColor = true;
			this.btnOpenPatchFile.Click += new System.EventHandler( this.btnOpenPatchFile_Click );
			// 
			// btnAbout
			// 
			this.btnAbout.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.btnAbout.Location = new System.Drawing.Point( 4, 188 );
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size( 25, 23 );
			this.btnAbout.TabIndex = 7;
			this.btnAbout.Text = "?";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler( this.btnAbout_Click );
			// 
			// txtLog
			// 
			this.txtLog.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtLog.Location = new System.Drawing.Point( 4, 58 );
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size( 405, 124 );
			this.txtLog.TabIndex = 8;
			this.txtLog.Text = "";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 415, 216 );
			this.Controls.Add( this.txtLog );
			this.Controls.Add( this.btnAbout );
			this.Controls.Add( this.btnOpenPatchFile );
			this.Controls.Add( this.btnOpenPatches );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtPatchFile );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.txtPatchList );
			this.Controls.Add( this.btnPatchIt );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "frmMain";
			this.Text = "Client Patcher";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPatchIt;
		private System.Windows.Forms.TextBox txtPatchList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPatchFile;
		private System.Windows.Forms.Button btnOpenPatches;
		private System.Windows.Forms.Button btnOpenPatchFile;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.RichTextBox txtLog;
	}
}

