namespace ZenAIConfigPanel.Controls {
	partial class PercentMeter {
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
			this.trackBar = new System.Windows.Forms.TrackBar();
			this.numPercent = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.trackBar ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numPercent ) ).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar
			// 
			this.trackBar.AutoSize = false;
			this.trackBar.Location = new System.Drawing.Point( -5, -2 );
			this.trackBar.Maximum = 100;
			this.trackBar.Name = "trackBar";
			this.trackBar.Size = new System.Drawing.Size( 123, 21 );
			this.trackBar.TabIndex = 0;
			this.trackBar.TickFrequency = 2;
			this.trackBar.Scroll += new System.EventHandler( this.trackBar_Scroll );
			this.trackBar.MouseEnter += new System.EventHandler( this.trackBar_MouseEnter );
			// 
			// numPercent
			// 
			this.numPercent.Location = new System.Drawing.Point( 113, 0 );
			this.numPercent.Name = "numPercent";
			this.numPercent.Size = new System.Drawing.Size( 43, 20 );
			this.numPercent.TabIndex = 1;
			this.numPercent.ValueChanged += new System.EventHandler( this.numPercent_ValueChanged );
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point( 157, 2 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 16, 16 );
			this.label1.TabIndex = 2;
			this.label1.Text = "%";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.MouseEnter += new System.EventHandler( this.label1_MouseEnter );
			// 
			// PercentMeter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.numPercent );
			this.Controls.Add( this.trackBar );
			this.Name = "PercentMeter";
			this.Size = new System.Drawing.Size( 172, 20 );
			( (System.ComponentModel.ISupportInitialize)( this.trackBar ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numPercent ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TrackBar trackBar;
		private System.Windows.Forms.NumericUpDown numPercent;
		private System.Windows.Forms.Label label1;
	}
}
