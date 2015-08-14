namespace Shaiya.Reader.Client {
	partial class frmLogin {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancle = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 13, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 59, 13 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Loginname";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 13, 39 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 50, 13 );
			this.label2.TabIndex = 3;
			this.label2.Text = "Passwort";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point( 214, 75 );
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size( 75, 23 );
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancle
			// 
			this.btnCancle.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancle.Location = new System.Drawing.Point( 12, 75 );
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size( 75, 23 );
			this.btnCancle.TabIndex = 5;
			this.btnCancle.Text = "Abbruch";
			this.btnCancle.UseVisualStyleBackColor = true;
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtPassword.Location = new System.Drawing.Point( 84, 36 );
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size( 205, 20 );
			this.txtPassword.TabIndex = 2;
			// 
			// txtUsername
			// 
			this.txtUsername.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtUsername.Location = new System.Drawing.Point( 84, 10 );
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size( 205, 20 );
			this.txtUsername.TabIndex = 0;
			// 
			// frmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 301, 110 );
			this.Controls.Add( this.btnCancle );
			this.Controls.Add( this.btnOk );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtPassword );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.txtUsername );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmLogin";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Forum Login";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmLogin_FormClosing );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancle;
	}
}