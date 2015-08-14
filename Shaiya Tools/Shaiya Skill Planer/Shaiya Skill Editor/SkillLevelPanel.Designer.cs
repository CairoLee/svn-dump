namespace Shaiya_Skill_Editor {
	partial class SkillLevelPanel {
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
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cbElement = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.chkHPPerc = new System.Windows.Forms.CheckBox();
			this.chkMPPerc = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.chkSPPerc = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtEffect = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.txtCooldown = new Shaiya_Skill_Editor.FloatTextBox();
			this.txtCasttime = new Shaiya_Skill_Editor.FloatTextBox();
			this.txtNeededLevel = new Shaiya_Skill_Editor.IntTextBox();
			this.txtPoints = new Shaiya_Skill_Editor.IntTextBox();
			this.txtSP = new Shaiya_Skill_Editor.IntTextBox();
			this.txtMP = new Shaiya_Skill_Editor.IntTextBox();
			this.txtHP = new Shaiya_Skill_Editor.IntTextBox();
			this.txtAoeRange = new Shaiya_Skill_Editor.IntTextBox();
			this.txtRange = new Shaiya_Skill_Editor.IntTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 0, 4 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 35, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtName.Location = new System.Drawing.Point( 57, 1 );
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size( 268, 20 );
			this.txtName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 0, 121 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 39, 13 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Range";
			// 
			// label3
			// 
			this.label3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 222, 121 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 62, 13 );
			this.label3.TabIndex = 3;
			this.label3.Text = "AoE Range";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 0, 147 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 47, 13 );
			this.label4.TabIndex = 6;
			this.label4.Text = "Casttime";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 0, 173 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 45, 13 );
			this.label6.TabIndex = 9;
			this.label6.Text = "Element";
			// 
			// cbElement
			// 
			this.cbElement.FormattingEnabled = true;
			this.cbElement.Items.AddRange( new object[] {
            "None",
            "Neutral",
            "Feuer",
            "Wasser",
            "Wind",
            "Erde"} );
			this.cbElement.Location = new System.Drawing.Point( 53, 170 );
			this.cbElement.Name = "cbElement";
			this.cbElement.Size = new System.Drawing.Size( 78, 21 );
			this.cbElement.TabIndex = 10;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point( 0, 76 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 22, 13 );
			this.label7.TabIndex = 11;
			this.label7.Text = "HP";
			// 
			// chkHPPerc
			// 
			this.chkHPPerc.AutoSize = true;
			this.chkHPPerc.Location = new System.Drawing.Point( 61, 75 );
			this.chkHPPerc.Name = "chkHPPerc";
			this.chkHPPerc.Size = new System.Drawing.Size( 34, 17 );
			this.chkHPPerc.TabIndex = 13;
			this.chkHPPerc.Text = "%";
			this.chkHPPerc.UseVisualStyleBackColor = true;
			// 
			// chkMPPerc
			// 
			this.chkMPPerc.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkMPPerc.AutoSize = true;
			this.chkMPPerc.Location = new System.Drawing.Point( 178, 75 );
			this.chkMPPerc.Name = "chkMPPerc";
			this.chkMPPerc.Size = new System.Drawing.Size( 34, 17 );
			this.chkMPPerc.TabIndex = 16;
			this.chkMPPerc.Text = "%";
			this.chkMPPerc.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 117, 76 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 23, 13 );
			this.label8.TabIndex = 14;
			this.label8.Text = "MP";
			// 
			// chkSPPerc
			// 
			this.chkSPPerc.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.chkSPPerc.AutoSize = true;
			this.chkSPPerc.Location = new System.Drawing.Point( 293, 75 );
			this.chkSPPerc.Name = "chkSPPerc";
			this.chkSPPerc.Size = new System.Drawing.Size( 34, 17 );
			this.chkSPPerc.TabIndex = 19;
			this.chkSPPerc.Text = "%";
			this.chkSPPerc.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point( 232, 76 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 21, 13 );
			this.label9.TabIndex = 17;
			this.label9.Text = "SP";
			// 
			// label11
			// 
			this.label11.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point( 225, 147 );
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size( 59, 13 );
			this.label11.TabIndex = 20;
			this.label11.Text = "Cool Down";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 0, 38 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 41, 13 );
			this.label5.TabIndex = 24;
			this.label5.Text = "Punkte";
			// 
			// label10
			// 
			this.label10.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point( 194, 38 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 85, 13 );
			this.label10.TabIndex = 26;
			this.label10.Text = "benötigtes Level";
			// 
			// txtEffect
			// 
			this.txtEffect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtEffect.Location = new System.Drawing.Point( 233, 170 );
			this.txtEffect.Name = "txtEffect";
			this.txtEffect.Size = new System.Drawing.Size( 92, 20 );
			this.txtEffect.TabIndex = 29;
			// 
			// label12
			// 
			this.label12.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point( 163, 173 );
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size( 70, 13 );
			this.label12.TabIndex = 28;
			this.label12.Text = "Statuseffekte";
			// 
			// txtDesc
			// 
			this.txtDesc.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtDesc.Location = new System.Drawing.Point( 3, 206 );
			this.txtDesc.Multiline = true;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size( 322, 64 );
			this.txtDesc.TabIndex = 30;
			// 
			// txtCooldown
			// 
			this.txtCooldown.Location = new System.Drawing.Point( 290, 144 );
			this.txtCooldown.Name = "txtCooldown";
			this.txtCooldown.Size = new System.Drawing.Size( 35, 20 );
			this.txtCooldown.TabIndex = 32;
			this.txtCooldown.Text = "0,0";
			this.txtCooldown.Value = 0F;
			// 
			// txtCasttime
			// 
			this.txtCasttime.Location = new System.Drawing.Point( 53, 144 );
			this.txtCasttime.Name = "txtCasttime";
			this.txtCasttime.Size = new System.Drawing.Size( 35, 20 );
			this.txtCasttime.TabIndex = 31;
			this.txtCasttime.Text = "0,0";
			this.txtCasttime.Value = 0F;
			// 
			// txtNeededLevel
			// 
			this.txtNeededLevel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtNeededLevel.Location = new System.Drawing.Point( 285, 35 );
			this.txtNeededLevel.Name = "txtNeededLevel";
			this.txtNeededLevel.Size = new System.Drawing.Size( 40, 20 );
			this.txtNeededLevel.TabIndex = 27;
			this.txtNeededLevel.Text = "0";
			this.txtNeededLevel.Value = 0;
			// 
			// txtPoints
			// 
			this.txtPoints.Location = new System.Drawing.Point( 53, 35 );
			this.txtPoints.Name = "txtPoints";
			this.txtPoints.Size = new System.Drawing.Size( 35, 20 );
			this.txtPoints.TabIndex = 25;
			this.txtPoints.Text = "0";
			this.txtPoints.Value = 0;
			// 
			// txtSP
			// 
			this.txtSP.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtSP.Location = new System.Drawing.Point( 255, 73 );
			this.txtSP.Name = "txtSP";
			this.txtSP.Size = new System.Drawing.Size( 35, 20 );
			this.txtSP.TabIndex = 18;
			this.txtSP.Text = "0";
			this.txtSP.Value = 0;
			// 
			// txtMP
			// 
			this.txtMP.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtMP.Location = new System.Drawing.Point( 140, 73 );
			this.txtMP.Name = "txtMP";
			this.txtMP.Size = new System.Drawing.Size( 35, 20 );
			this.txtMP.TabIndex = 15;
			this.txtMP.Text = "0";
			this.txtMP.Value = 0;
			// 
			// txtHP
			// 
			this.txtHP.Location = new System.Drawing.Point( 23, 73 );
			this.txtHP.Name = "txtHP";
			this.txtHP.Size = new System.Drawing.Size( 35, 20 );
			this.txtHP.TabIndex = 12;
			this.txtHP.Text = "0";
			this.txtHP.Value = 0;
			// 
			// txtAoeRange
			// 
			this.txtAoeRange.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtAoeRange.Location = new System.Drawing.Point( 290, 118 );
			this.txtAoeRange.Name = "txtAoeRange";
			this.txtAoeRange.Size = new System.Drawing.Size( 35, 20 );
			this.txtAoeRange.TabIndex = 5;
			this.txtAoeRange.Text = "0";
			this.txtAoeRange.Value = 0;
			// 
			// txtRange
			// 
			this.txtRange.Location = new System.Drawing.Point( 53, 118 );
			this.txtRange.Name = "txtRange";
			this.txtRange.Size = new System.Drawing.Size( 35, 20 );
			this.txtRange.TabIndex = 4;
			this.txtRange.Text = "0";
			this.txtRange.Value = 0;
			// 
			// SkillLevelPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.txtCooldown );
			this.Controls.Add( this.txtCasttime );
			this.Controls.Add( this.txtDesc );
			this.Controls.Add( this.txtEffect );
			this.Controls.Add( this.label12 );
			this.Controls.Add( this.txtNeededLevel );
			this.Controls.Add( this.label10 );
			this.Controls.Add( this.txtPoints );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.label11 );
			this.Controls.Add( this.chkSPPerc );
			this.Controls.Add( this.txtSP );
			this.Controls.Add( this.label9 );
			this.Controls.Add( this.chkMPPerc );
			this.Controls.Add( this.txtMP );
			this.Controls.Add( this.label8 );
			this.Controls.Add( this.chkHPPerc );
			this.Controls.Add( this.txtHP );
			this.Controls.Add( this.label7 );
			this.Controls.Add( this.cbElement );
			this.Controls.Add( this.label6 );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.txtAoeRange );
			this.Controls.Add( this.txtRange );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtName );
			this.Controls.Add( this.label1 );
			this.Name = "SkillLevelPanel";
			this.Size = new System.Drawing.Size( 325, 273 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private IntTextBox txtRange;
		private IntTextBox txtAoeRange;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbElement;
		private IntTextBox txtHP;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkHPPerc;
		private System.Windows.Forms.CheckBox chkMPPerc;
		private IntTextBox txtMP;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkSPPerc;
		private IntTextBox txtSP;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private IntTextBox txtPoints;
		private System.Windows.Forms.Label label5;
		private IntTextBox txtNeededLevel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtEffect;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtDesc;
		private FloatTextBox txtCasttime;
		private FloatTextBox txtCooldown;
	}
}
