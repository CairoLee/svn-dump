namespace ShaiyaMonsterMap.Forms {
	partial class frmMobPoint {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMobPoint ) );
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLevel = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.chkBoss = new System.Windows.Forms.CheckBox();
			this.label14 = new System.Windows.Forms.Label();
			this.cbElement = new ShaiyaMonsterMap.Components.ElementComboBox();
			this.cbCount = new System.Windows.Forms.ComboBox();
			this.txtInfo = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 13, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 35, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point( 65, 10 );
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size( 163, 20 );
			this.txtName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 13, 39 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 33, 13 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Level";
			// 
			// txtLevel
			// 
			this.txtLevel.Location = new System.Drawing.Point( 65, 36 );
			this.txtLevel.Name = "txtLevel";
			this.txtLevel.Size = new System.Drawing.Size( 63, 20 );
			this.txtLevel.TabIndex = 2;
			this.txtLevel.Text = "1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 13, 65 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 39, 13 );
			this.label3.TabIndex = 4;
			this.label3.Text = "Anzahl";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point( 13, 292 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 215, 23 );
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point( 25, 171 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 53, 13 );
			this.label4.TabIndex = 7;
			this.label4.Text = "Weiß = -6";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label5.ForeColor = System.Drawing.Color.SkyBlue;
			this.label5.Location = new System.Drawing.Point( 25, 193 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 69, 13 );
			this.label5.TabIndex = 8;
			this.label5.Text = "Hellblau: -5-4";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Navy;
			this.label6.Location = new System.Drawing.Point( 25, 215 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 85, 13 );
			this.label6.TabIndex = 9;
			this.label6.Text = "Dunkelblau: -3-4";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.ForestGreen;
			this.label7.Location = new System.Drawing.Point( 25, 237 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 56, 13 );
			this.label7.TabIndex = 10;
			this.label7.Text = "Grün: +/-1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 192 ) ) ) ), ( (int)( ( (byte)( 192 ) ) ) ), ( (int)( ( (byte)( 0 ) ) ) ) );
			this.label8.Location = new System.Drawing.Point( 125, 171 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 56, 13 );
			this.label8.TabIndex = 11;
			this.label8.Text = "Gelb: +2-3";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.DarkOrange;
			this.label9.Location = new System.Drawing.Point( 125, 193 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 69, 13 );
			this.label9.TabIndex = 12;
			this.label9.Text = "Orange: +4-5";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.Color.Red;
			this.label10.Location = new System.Drawing.Point( 125, 215 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 51, 13 );
			this.label10.TabIndex = 13;
			this.label10.Text = "Rot: +6-7";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.Color.DeepPink;
			this.label11.Location = new System.Drawing.Point( 125, 237 );
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size( 55, 13 );
			this.label11.TabIndex = 14;
			this.label11.Text = "Pink: +8-9";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.Gray;
			this.label12.Location = new System.Drawing.Point( 74, 258 );
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size( 54, 13 );
			this.label12.TabIndex = 15;
			this.label12.Text = "Grau: +10";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point( 13, 91 );
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size( 45, 13 );
			this.label13.TabIndex = 16;
			this.label13.Text = "Element";
			// 
			// chkBoss
			// 
			this.chkBoss.AutoSize = true;
			this.chkBoss.Location = new System.Drawing.Point( 16, 141 );
			this.chkBoss.Name = "chkBoss";
			this.chkBoss.Size = new System.Drawing.Size( 90, 17 );
			this.chkBoss.TabIndex = 6;
			this.chkBoss.Text = "Boss Monster";
			this.chkBoss.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point( 13, 118 );
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size( 25, 13 );
			this.label14.TabIndex = 20;
			this.label14.Text = "Info";
			// 
			// cbElement
			// 
			this.cbElement.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cbElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbElement.FormattingEnabled = true;
			this.cbElement.IntegralHeight = false;
			this.cbElement.Location = new System.Drawing.Point( 65, 88 );
			this.cbElement.Name = "cbElement";
			this.cbElement.Size = new System.Drawing.Size( 163, 21 );
			this.cbElement.TabIndex = 4;
			// 
			// cbCount
			// 
			this.cbCount.FormattingEnabled = true;
			this.cbCount.Items.AddRange( new object[] {
            "wenig (1-5)",
            "mittel (5-10)",
            "viele (10-15)",
            "sehr viele (15+)",
            "1 (Boss)"} );
			this.cbCount.Location = new System.Drawing.Point( 66, 62 );
			this.cbCount.Name = "cbCount";
			this.cbCount.Size = new System.Drawing.Size( 162, 21 );
			this.cbCount.TabIndex = 3;
			// 
			// txtInfo
			// 
			this.txtInfo.Location = new System.Drawing.Point( 65, 115 );
			this.txtInfo.Name = "txtInfo";
			this.txtInfo.Size = new System.Drawing.Size( 163, 20 );
			this.txtInfo.TabIndex = 5;
			// 
			// frmMobPoint
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 240, 327 );
			this.Controls.Add( this.txtInfo );
			this.Controls.Add( this.cbCount );
			this.Controls.Add( this.label14 );
			this.Controls.Add( this.chkBoss );
			this.Controls.Add( this.cbElement );
			this.Controls.Add( this.label13 );
			this.Controls.Add( this.label12 );
			this.Controls.Add( this.label11 );
			this.Controls.Add( this.label10 );
			this.Controls.Add( this.label9 );
			this.Controls.Add( this.label8 );
			this.Controls.Add( this.label7 );
			this.Controls.Add( this.label6 );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.btnSave );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.txtLevel );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtName );
			this.Controls.Add( this.label1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "frmMobPoint";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Eintrag";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSave;
		public System.Windows.Forms.TextBox txtName;
		public System.Windows.Forms.TextBox txtLevel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		public ShaiyaMonsterMap.Components.ElementComboBox cbElement;
		public System.Windows.Forms.CheckBox chkBoss;
		private System.Windows.Forms.Label label14;
		public System.Windows.Forms.TextBox txtInfo;
		public System.Windows.Forms.ComboBox cbCount;
	}
}