namespace eAthenaTool.Client {
	partial class pnlTreeNodeEaToolMain {
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

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.txtEathenaPath = new System.Windows.Forms.TextBox();
			this.btnEathenaOpen = new System.Windows.Forms.Button();
			this.btnRagnarokOpen = new System.Windows.Forms.Button();
			this.txtRagnarokPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 4, 4 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 104, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "eAthena Verzeichnis";
			// 
			// txtEathenaPath
			// 
			this.txtEathenaPath.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtEathenaPath.Location = new System.Drawing.Point( 7, 21 );
			this.txtEathenaPath.Name = "txtEathenaPath";
			this.txtEathenaPath.ReadOnly = true;
			this.txtEathenaPath.Size = new System.Drawing.Size( 665, 20 );
			this.txtEathenaPath.TabIndex = 1;
			// 
			// btnEathenaOpen
			// 
			this.btnEathenaOpen.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnEathenaOpen.Location = new System.Drawing.Point( 678, 19 );
			this.btnEathenaOpen.Name = "btnEathenaOpen";
			this.btnEathenaOpen.Size = new System.Drawing.Size( 80, 23 );
			this.btnEathenaOpen.TabIndex = 2;
			this.btnEathenaOpen.Text = "Durchsuchen";
			this.btnEathenaOpen.UseVisualStyleBackColor = true;
			this.btnEathenaOpen.Click += new System.EventHandler( this.btnEathenaOpen_Click );
			// 
			// btnRagnarokOpen
			// 
			this.btnRagnarokOpen.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnRagnarokOpen.Location = new System.Drawing.Point( 678, 71 );
			this.btnRagnarokOpen.Name = "btnRagnarokOpen";
			this.btnRagnarokOpen.Size = new System.Drawing.Size( 80, 23 );
			this.btnRagnarokOpen.TabIndex = 5;
			this.btnRagnarokOpen.Text = "Durchsuchen";
			this.btnRagnarokOpen.UseVisualStyleBackColor = true;
			this.btnRagnarokOpen.Click += new System.EventHandler( this.btnRagnarokOpen_Click );
			// 
			// txtRagnarokPath
			// 
			this.txtRagnarokPath.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtRagnarokPath.Location = new System.Drawing.Point( 7, 73 );
			this.txtRagnarokPath.Name = "txtRagnarokPath";
			this.txtRagnarokPath.ReadOnly = true;
			this.txtRagnarokPath.Size = new System.Drawing.Size( 665, 20 );
			this.txtRagnarokPath.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 4, 56 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 111, 13 );
			this.label2.TabIndex = 3;
			this.label2.Text = "Ragnarok Verzeichnis";
			// 
			// pnlTreeNodeEaToolMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.btnRagnarokOpen );
			this.Controls.Add( this.txtRagnarokPath );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.btnEathenaOpen );
			this.Controls.Add( this.txtEathenaPath );
			this.Controls.Add( this.label1 );
			this.Name = "pnlTreeNodeEaToolMain";
			this.Size = new System.Drawing.Size( 761, 538 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEathenaPath;
		private System.Windows.Forms.Button btnEathenaOpen;
		private System.Windows.Forms.Button btnRagnarokOpen;
		private System.Windows.Forms.TextBox txtRagnarokPath;
		private System.Windows.Forms.Label label2;
	}
}
