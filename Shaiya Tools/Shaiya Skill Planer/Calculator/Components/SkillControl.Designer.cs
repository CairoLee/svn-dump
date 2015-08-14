namespace Ssc.Components {
	partial class SkillControl {
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
			this.lblName = new System.Windows.Forms.Label();
			this.lblSp = new System.Windows.Forms.Label();
			this.lblReqLvl = new System.Windows.Forms.Label();
			this.pbIcon = new System.Windows.Forms.PictureBox();
			this.btnUp = new System.Windows.Forms.PictureBox();
			this.btnDown = new System.Windows.Forms.PictureBox();
			( (System.ComponentModel.ISupportInitialize)( this.pbIcon ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.btnUp ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.btnDown ) ).BeginInit();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.lblName.Location = new System.Drawing.Point( 0, 2 );
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size( 61, 13 );
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Skillname";
			this.lblName.MouseEnter += new System.EventHandler( this.Controls_MouseEnter );
			// 
			// lblSp
			// 
			this.lblSp.AutoSize = true;
			this.lblSp.Location = new System.Drawing.Point( 51, 33 );
			this.lblSp.Name = "lblSp";
			this.lblSp.Size = new System.Drawing.Size( 125, 13 );
			this.lblSp.TabIndex = 1;
			this.lblSp.Text = "Benötigte Skillpunkte: 99";
			this.lblSp.MouseEnter += new System.EventHandler( this.Controls_MouseEnter );
			// 
			// lblReqLvl
			// 
			this.lblReqLvl.AutoSize = true;
			this.lblReqLvl.Location = new System.Drawing.Point( 51, 16 );
			this.lblReqLvl.Name = "lblReqLvl";
			this.lblReqLvl.Size = new System.Drawing.Size( 104, 13 );
			this.lblReqLvl.TabIndex = 2;
			this.lblReqLvl.Text = "Benötigtes Level: 99";
			this.lblReqLvl.MouseEnter += new System.EventHandler( this.Controls_MouseEnter );
			// 
			// pbIcon
			// 
			this.pbIcon.Location = new System.Drawing.Point( 4, 15 );
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new System.Drawing.Size( 32, 32 );
			this.pbIcon.TabIndex = 5;
			this.pbIcon.TabStop = false;
			this.pbIcon.MouseEnter += new System.EventHandler( this.Controls_MouseEnter );
			// 
			// btnUp
			// 
			this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUp.Image = global::Ssc.Properties.Resources.btnUp;
			this.btnUp.Location = new System.Drawing.Point( 39, 15 );
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size( 12, 14 );
			this.btnUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.btnUp.TabIndex = 6;
			this.btnUp.TabStop = false;
			this.btnUp.EnabledChanged += new System.EventHandler( this.btnUp_EnabledChanged );
			this.btnUp.MouseEnter += new System.EventHandler( this.Controls_MouseEnter );
			// 
			// btnDown
			// 
			this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDown.Image = global::Ssc.Properties.Resources.btnDown;
			this.btnDown.Location = new System.Drawing.Point( 39, 33 );
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size( 12, 14 );
			this.btnDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.btnDown.TabIndex = 7;
			this.btnDown.TabStop = false;
			this.btnDown.EnabledChanged += new System.EventHandler( this.btnDown_EnabledChanged );
			this.btnDown.MouseEnter += new System.EventHandler( this.Controls_MouseEnter );
			// 
			// SkillControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add( this.btnDown );
			this.Controls.Add( this.btnUp );
			this.Controls.Add( this.pbIcon );
			this.Controls.Add( this.lblReqLvl );
			this.Controls.Add( this.lblSp );
			this.Controls.Add( this.lblName );
			this.Name = "SkillControl";
			this.Size = new System.Drawing.Size( 233, 50 );
			( (System.ComponentModel.ISupportInitialize)( this.pbIcon ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.btnUp ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.btnDown ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label lblName;
		public System.Windows.Forms.Label lblSp;
		public System.Windows.Forms.Label lblReqLvl;
		public System.Windows.Forms.PictureBox pbIcon;
		public System.Windows.Forms.PictureBox btnUp;
		public System.Windows.Forms.PictureBox btnDown;
	}
}
