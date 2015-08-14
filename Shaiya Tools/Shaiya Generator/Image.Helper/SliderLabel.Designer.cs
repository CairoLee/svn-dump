namespace ImageHelper {
	partial class SliderLabel {
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
			this.progressBar = new System.Windows.Forms.TrackBar();
			this.lblProgress = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.progressBar ) ).BeginInit();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.AutoSize = false;
			this.progressBar.Location = new System.Drawing.Point( 0, 0 );
			this.progressBar.Maximum = 100;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size( 254, 23 );
			this.progressBar.TabIndex = 0;
			this.progressBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.progressBar.ValueChanged += new System.EventHandler( this.progressBar_ValueChanged );
			// 
			// lblProgress
			// 
			this.lblProgress.Location = new System.Drawing.Point( 255, 4 );
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size( 25, 13 );
			this.lblProgress.TabIndex = 1;
			this.lblProgress.Text = "{0}";
			this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SliderLabel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.lblProgress );
			this.Controls.Add( this.progressBar );
			this.Name = "SliderLabel";
			this.Size = new System.Drawing.Size( 288, 23 );
			this.BackColorChanged += new System.EventHandler( this.SliderLabel_BackColorChanged );
			this.SizeChanged += new System.EventHandler( this.SliderLabel_SizeChanged );
			( (System.ComponentModel.ISupportInitialize)( this.progressBar ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TrackBar progressBar;
		private System.Windows.Forms.Label lblProgress;
	}
}
