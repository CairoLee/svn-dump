namespace AchieveTool {
	partial class frmAddReceivement {
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
			this.btnOK = new System.Windows.Forms.Button();
			this.txtParam = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbTyp = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point( 157, 61 );
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size( 56, 23 );
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
			// 
			// txtParam
			// 
			this.txtParam.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtParam.Location = new System.Drawing.Point( 53, 33 );
			this.txtParam.Name = "txtParam";
			this.txtParam.Size = new System.Drawing.Size( 160, 20 );
			this.txtParam.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 12, 36 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 37, 13 );
			this.label2.TabIndex = 8;
			this.label2.Text = "Param";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 12, 9 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 25, 13 );
			this.label3.TabIndex = 11;
			this.label3.Text = "Typ";
			// 
			// cmbTyp
			// 
			this.cmbTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTyp.FormattingEnabled = true;
			this.cmbTyp.Location = new System.Drawing.Point( 53, 6 );
			this.cmbTyp.Name = "cmbTyp";
			this.cmbTyp.Size = new System.Drawing.Size( 121, 21 );
			this.cmbTyp.TabIndex = 12;
			// 
			// frmAddReceivement
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 226, 94 );
			this.Controls.Add( this.cmbTyp );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.btnOK );
			this.Controls.Add( this.txtParam );
			this.Controls.Add( this.label2 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmAddReceivement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gib dem User etwas";
			this.Load += new System.EventHandler( this.frmAddReceivement_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtParam;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbTyp;
	}
}