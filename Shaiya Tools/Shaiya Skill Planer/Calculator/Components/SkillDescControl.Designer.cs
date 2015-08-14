namespace Ssc.Components {
	partial class SkillDescControl {
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
			this.picIcon = new System.Windows.Forms.PictureBox();
			this.lblDesc = new System.Windows.Forms.Label();
			this.lblLevel = new System.Windows.Forms.Label();
			this.lblSkillPoints = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblLevelValue = new System.Windows.Forms.Label();
			this.lblSkillPointsValue = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.picIcon ) ).BeginInit();
			this.SuspendLayout();
			// 
			// picIcon
			// 
			this.picIcon.BackColor = System.Drawing.Color.Transparent;
			this.picIcon.Location = new System.Drawing.Point( 6, 13 );
			this.picIcon.Name = "picIcon";
			this.picIcon.Size = new System.Drawing.Size( 32, 32 );
			this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picIcon.TabIndex = 0;
			this.picIcon.TabStop = false;
			// 
			// lblDesc
			// 
			this.lblDesc.AutoSize = true;
			this.lblDesc.BackColor = System.Drawing.Color.Transparent;
			this.lblDesc.Location = new System.Drawing.Point( 40, 13 );
			this.lblDesc.MaximumSize = new System.Drawing.Size( 290, 100 );
			this.lblDesc.Name = "lblDesc";
			this.lblDesc.Size = new System.Drawing.Size( 72, 13 );
			this.lblDesc.TabIndex = 1;
			this.lblDesc.Text = "Beschreibung";
			// 
			// lblLevel
			// 
			this.lblLevel.AutoSize = true;
			this.lblLevel.BackColor = System.Drawing.Color.Transparent;
			this.lblLevel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 6.000001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.lblLevel.Location = new System.Drawing.Point( 50, 37 );
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new System.Drawing.Size( 94, 12 );
			this.lblLevel.TabIndex = 2;
			this.lblLevel.Text = "Benötigtes Level:";
			// 
			// lblSkillPoints
			// 
			this.lblSkillPoints.AutoSize = true;
			this.lblSkillPoints.BackColor = System.Drawing.Color.Transparent;
			this.lblSkillPoints.Font = new System.Drawing.Font( "Microsoft Sans Serif", 6.000001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.lblSkillPoints.Location = new System.Drawing.Point( 211, 37 );
			this.lblSkillPoints.Name = "lblSkillPoints";
			this.lblSkillPoints.Size = new System.Drawing.Size( 69, 12 );
			this.lblSkillPoints.TabIndex = 3;
			this.lblSkillPoints.Text = "Skill Punkte:";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			this.lblName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.lblName.Location = new System.Drawing.Point( 3, 0 );
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size( 61, 13 );
			this.lblName.TabIndex = 4;
			this.lblName.Text = "Skillname";
			// 
			// lblLevelValue
			// 
			this.lblLevelValue.AutoSize = true;
			this.lblLevelValue.BackColor = System.Drawing.Color.Transparent;
			this.lblLevelValue.Font = new System.Drawing.Font( "Microsoft Sans Serif", 6.000001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.lblLevelValue.Location = new System.Drawing.Point( 143, 37 );
			this.lblLevelValue.Name = "lblLevelValue";
			this.lblLevelValue.Size = new System.Drawing.Size( 15, 12 );
			this.lblLevelValue.TabIndex = 5;
			this.lblLevelValue.Text = "99";
			// 
			// lblSkillPointsValue
			// 
			this.lblSkillPointsValue.AutoSize = true;
			this.lblSkillPointsValue.BackColor = System.Drawing.Color.Transparent;
			this.lblSkillPointsValue.Font = new System.Drawing.Font( "Microsoft Sans Serif", 6.000001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.lblSkillPointsValue.Location = new System.Drawing.Point( 279, 37 );
			this.lblSkillPointsValue.Name = "lblSkillPointsValue";
			this.lblSkillPointsValue.Size = new System.Drawing.Size( 15, 12 );
			this.lblSkillPointsValue.TabIndex = 6;
			this.lblSkillPointsValue.Text = "99";
			// 
			// SkillDescControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add( this.lblSkillPointsValue );
			this.Controls.Add( this.lblLevelValue );
			this.Controls.Add( this.lblName );
			this.Controls.Add( this.lblSkillPoints );
			this.Controls.Add( this.lblLevel );
			this.Controls.Add( this.lblDesc );
			this.Controls.Add( this.picIcon );
			this.Name = "SkillDescControl";
			this.Size = new System.Drawing.Size( 348, 59 );
			( (System.ComponentModel.ISupportInitialize)( this.picIcon ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picIcon;
		private System.Windows.Forms.Label lblDesc;
		private System.Windows.Forms.Label lblLevel;
		private System.Windows.Forms.Label lblSkillPoints;
		public System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblLevelValue;
		private System.Windows.Forms.Label lblSkillPointsValue;
	}
}
