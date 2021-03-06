﻿namespace ShaiyaMonsterMap {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmLogin ) );
			this.label1 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPasswort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bntLogin = new System.Windows.Forms.Button();
			this.btnSkip = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 13, 76 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 55, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Username";
			// 
			// txtUsername
			// 
			this.txtUsername.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtUsername.Location = new System.Drawing.Point( 74, 73 );
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size( 262, 20 );
			this.txtUsername.TabIndex = 1;
			// 
			// txtPasswort
			// 
			this.txtPasswort.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtPasswort.Location = new System.Drawing.Point( 74, 99 );
			this.txtPasswort.Name = "txtPasswort";
			this.txtPasswort.PasswordChar = '*';
			this.txtPasswort.Size = new System.Drawing.Size( 262, 20 );
			this.txtPasswort.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 13, 102 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 50, 13 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Passwort";
			// 
			// bntLogin
			// 
			this.bntLogin.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.bntLogin.Location = new System.Drawing.Point( 261, 132 );
			this.bntLogin.Name = "bntLogin";
			this.bntLogin.Size = new System.Drawing.Size( 75, 23 );
			this.bntLogin.TabIndex = 4;
			this.bntLogin.Text = "Login";
			this.bntLogin.UseVisualStyleBackColor = true;
			this.bntLogin.Click += new System.EventHandler( this.bntLogin_Click );
			// 
			// btnSkip
			// 
			this.btnSkip.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSkip.Location = new System.Drawing.Point( 16, 132 );
			this.btnSkip.Name = "btnSkip";
			this.btnSkip.Size = new System.Drawing.Size( 80, 23 );
			this.btnSkip.TabIndex = 5;
			this.btnSkip.Text = "Überspringen";
			this.btnSkip.UseVisualStyleBackColor = true;
			this.btnSkip.Click += new System.EventHandler( this.btnSkip_Click );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 13, 9 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 326, 39 );
			this.label3.TabIndex = 6;
			this.label3.Text = "Zum ändern der Map-Daten wird ein Account benötigt!\r\nFalls du einen möchtest, wen" +
				"de dich bitte an GodLesZ oder Nezumi\r\nund benutze den \"Überspringen\" Button.";
			// 
			// frmLogin
			// 
			this.AcceptButton = this.bntLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnSkip;
			this.ClientSize = new System.Drawing.Size( 348, 167 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.btnSkip );
			this.Controls.Add( this.bntLogin );
			this.Controls.Add( this.txtPasswort );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtUsername );
			this.Controls.Add( this.label1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLogin";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmLogin_FormClosing );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPasswort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bntLogin;
		private System.Windows.Forms.Button btnSkip;
		private System.Windows.Forms.Label label3;
	}
}