namespace ImageHelper {
	partial class ColorChooser {
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
			this.imageColor = new System.Windows.Forms.PictureBox();
			( (System.ComponentModel.ISupportInitialize)( this.imageColor ) ).BeginInit();
			this.SuspendLayout();
			// 
			// imageColor
			// 
			this.imageColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imageColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageColor.Location = new System.Drawing.Point( 0, 0 );
			this.imageColor.Name = "imageColor";
			this.imageColor.Size = new System.Drawing.Size( 20, 20 );
			this.imageColor.TabIndex = 0;
			this.imageColor.TabStop = false;
			this.imageColor.Click += new System.EventHandler( this.imageColor_Click );
			// 
			// ColorChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.imageColor );
			this.Name = "ColorChooser";
			this.Size = new System.Drawing.Size( 20, 20 );
			( (System.ComponentModel.ISupportInitialize)( this.imageColor ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.PictureBox imageColor;
	}
}
