namespace Sbt.Compontents {
	partial class BossPanel {
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
			this.lblTime = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.lblName.Location = new System.Drawing.Point( -2, 0 );
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size( 70, 13 );
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Boss Name";
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Location = new System.Drawing.Point( -2, 16 );
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size( 64, 13 );
			this.lblTime.TabIndex = 1;
			this.lblTime.Text = "03:50:30:59";
			this.lblTime.Click += new System.EventHandler( this.lblTime_Click );
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point( 141, 3 );
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size( 75, 23 );
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Starten";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler( this.btnReset_Click );
			// 
			// BossPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add( this.btnReset );
			this.Controls.Add( this.lblTime );
			this.Controls.Add( this.lblName );
			this.Name = "BossPanel";
			this.Size = new System.Drawing.Size( 218, 30 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label lblName;
		public System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Button btnReset;
	}
}
