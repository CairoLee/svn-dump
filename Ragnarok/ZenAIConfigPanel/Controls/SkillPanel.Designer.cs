namespace ZenAIConfigPanel.Controls {
	partial class SkillPanel {
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
			this.imgSkill = new System.Windows.Forms.PictureBox();
			this.lblSkillName = new System.Windows.Forms.Label();
			this.lblSkillMinSP = new System.Windows.Forms.Label();
			this.txtSkillMinSP = new System.Windows.Forms.TextBox();
			this.cmbSkillLevel = new System.Windows.Forms.ComboBox();
			( (System.ComponentModel.ISupportInitialize)( this.imgSkill ) ).BeginInit();
			this.SuspendLayout();
			// 
			// imgSkill
			// 
			this.imgSkill.Location = new System.Drawing.Point( 0, 0 );
			this.imgSkill.Name = "imgSkill";
			this.imgSkill.Size = new System.Drawing.Size( 24, 24 );
			this.imgSkill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imgSkill.TabIndex = 0;
			this.imgSkill.TabStop = false;
			// 
			// lblSkillName
			// 
			this.lblSkillName.AutoSize = true;
			this.lblSkillName.Location = new System.Drawing.Point( 27, 6 );
			this.lblSkillName.Name = "lblSkillName";
			this.lblSkillName.Size = new System.Drawing.Size( 57, 13 );
			this.lblSkillName.TabIndex = 1;
			this.lblSkillName.Text = "Skill Name";
			// 
			// lblSkillMinSP
			// 
			this.lblSkillMinSP.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.lblSkillMinSP.AutoSize = true;
			this.lblSkillMinSP.Location = new System.Drawing.Point( 134, 5 );
			this.lblSkillMinSP.Name = "lblSkillMinSP";
			this.lblSkillMinSP.Size = new System.Drawing.Size( 38, 13 );
			this.lblSkillMinSP.TabIndex = 2;
			this.lblSkillMinSP.Text = "MinSP";
			// 
			// txtSkillMinSP
			// 
			this.txtSkillMinSP.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtSkillMinSP.Location = new System.Drawing.Point( 175, 2 );
			this.txtSkillMinSP.Name = "txtSkillMinSP";
			this.txtSkillMinSP.Size = new System.Drawing.Size( 31, 20 );
			this.txtSkillMinSP.TabIndex = 3;
			// 
			// cmbSkillLevel
			// 
			this.cmbSkillLevel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmbSkillLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSkillLevel.FormattingEnabled = true;
			this.cmbSkillLevel.Items.AddRange( new object[] {
            "Off",
            "Lvl 1",
            "Lvl 2",
            "Lvl 3",
            "Lvl 4",
            "Lvl 5"} );
			this.cmbSkillLevel.Location = new System.Drawing.Point( 208, 2 );
			this.cmbSkillLevel.Name = "cmbSkillLevel";
			this.cmbSkillLevel.Size = new System.Drawing.Size( 55, 21 );
			this.cmbSkillLevel.TabIndex = 4;
			// 
			// SkillPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add( this.cmbSkillLevel );
			this.Controls.Add( this.txtSkillMinSP );
			this.Controls.Add( this.lblSkillMinSP );
			this.Controls.Add( this.lblSkillName );
			this.Controls.Add( this.imgSkill );
			this.Name = "SkillPanel";
			this.Size = new System.Drawing.Size( 264, 24 );
			( (System.ComponentModel.ISupportInitialize)( this.imgSkill ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox imgSkill;
		private System.Windows.Forms.Label lblSkillName;
		private System.Windows.Forms.Label lblSkillMinSP;
		private System.Windows.Forms.TextBox txtSkillMinSP;
		private System.Windows.Forms.ComboBox cmbSkillLevel;
	}
}
