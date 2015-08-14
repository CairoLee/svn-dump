namespace GrfEditor.Library.Controls {
	partial class PalPreviewPanel {
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.imagePalette = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imagePalette)).BeginInit();
			this.SuspendLayout();
			// 
			// imagePalette
			// 
			this.imagePalette.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePalette.Location = new System.Drawing.Point(0, 0);
			this.imagePalette.Name = "imagePalette";
			this.imagePalette.Size = new System.Drawing.Size(270, 342);
			this.imagePalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.imagePalette.TabIndex = 0;
			this.imagePalette.TabStop = false;
			// 
			// PalPreviewPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.imagePalette);
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Name = "PalPreviewPanel";
			this.Size = new System.Drawing.Size(270, 342);
			((System.ComponentModel.ISupportInitialize)(this.imagePalette)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imagePalette;
	}
}
