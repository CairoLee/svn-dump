namespace Win32ToolPatcher {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtExe = new System.Windows.Forms.TextBox();
			this.txtDll = new System.Windows.Forms.TextBox();
			this.btnPatch = new System.Windows.Forms.Button();
			this.btnOpenExe = new System.Windows.Forms.Button();
			this.btnOpenDll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 13, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 60, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Client EXE:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 13, 42 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 66, 13 );
			this.label2.TabIndex = 1;
			this.label2.Text = "Schutz DLL:";
			// 
			// txtExe
			// 
			this.txtExe.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtExe.Location = new System.Drawing.Point( 88, 10 );
			this.txtExe.Name = "txtExe";
			this.txtExe.ReadOnly = true;
			this.txtExe.Size = new System.Drawing.Size( 289, 20 );
			this.txtExe.TabIndex = 2;
			// 
			// txtDll
			// 
			this.txtDll.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtDll.Location = new System.Drawing.Point( 88, 39 );
			this.txtDll.Name = "txtDll";
			this.txtDll.ReadOnly = true;
			this.txtDll.Size = new System.Drawing.Size( 289, 20 );
			this.txtDll.TabIndex = 3;
			// 
			// btnPatch
			// 
			this.btnPatch.Enabled = false;
			this.btnPatch.Location = new System.Drawing.Point( 383, 83 );
			this.btnPatch.Name = "btnPatch";
			this.btnPatch.Size = new System.Drawing.Size( 75, 23 );
			this.btnPatch.TabIndex = 4;
			this.btnPatch.Text = "Patch!";
			this.btnPatch.UseVisualStyleBackColor = true;
			this.btnPatch.Click += new System.EventHandler( this.btnPatch_Click );
			// 
			// btnOpenExe
			// 
			this.btnOpenExe.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOpenExe.Location = new System.Drawing.Point( 383, 10 );
			this.btnOpenExe.Name = "btnOpenExe";
			this.btnOpenExe.Size = new System.Drawing.Size( 75, 20 );
			this.btnOpenExe.TabIndex = 5;
			this.btnOpenExe.Text = "Öffnen";
			this.btnOpenExe.UseVisualStyleBackColor = true;
			this.btnOpenExe.Click += new System.EventHandler( this.btnOpenExe_Click );
			// 
			// btnOpenDll
			// 
			this.btnOpenDll.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOpenDll.Location = new System.Drawing.Point( 383, 39 );
			this.btnOpenDll.Name = "btnOpenDll";
			this.btnOpenDll.Size = new System.Drawing.Size( 75, 20 );
			this.btnOpenDll.TabIndex = 6;
			this.btnOpenDll.Text = "Öffnen";
			this.btnOpenDll.UseVisualStyleBackColor = true;
			this.btnOpenDll.Click += new System.EventHandler( this.btnOpenDll_Click );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 470, 118 );
			this.Controls.Add( this.btnOpenDll );
			this.Controls.Add( this.btnOpenExe );
			this.Controls.Add( this.btnPatch );
			this.Controls.Add( this.txtDll );
			this.Controls.Add( this.txtExe );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmMain";
			this.Text = "Exe Patcher Tool - part of GodLesZ\' Client Protection";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtExe;
		private System.Windows.Forms.TextBox txtDll;
		private System.Windows.Forms.Button btnPatch;
		private System.Windows.Forms.Button btnOpenExe;
		private System.Windows.Forms.Button btnOpenDll;
	}
}

