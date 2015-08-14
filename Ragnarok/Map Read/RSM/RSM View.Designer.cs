namespace MapRead.RSM {
	partial class RSMViewer {
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
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOpenFile.Location = new System.Drawing.Point( 386, 12 );
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size( 75, 23 );
			this.btnOpenFile.TabIndex = 0;
			this.btnOpenFile.Text = "button1";
			this.btnOpenFile.UseVisualStyleBackColor = true;
			this.btnOpenFile.Click += new System.EventHandler( this.btnOpenFile_Click );
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtFile.Location = new System.Drawing.Point( 12, 14 );
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size( 368, 20 );
			this.txtFile.TabIndex = 1;
			// 
			// RSM_View
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 473, 471 );
			this.Controls.Add( this.txtFile );
			this.Controls.Add( this.btnOpenFile );
			this.Name = "RSM_View";
			this.Text = "RSM View";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.TextBox txtFile;
	}
}