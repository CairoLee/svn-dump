namespace GrfEditor.Library.Controls {
	partial class ImagePreviewPanel {
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
			this.imagePreview = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
			this.SuspendLayout();
			// 
			// imagePreview
			// 
			this.imagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePreview.Location = new System.Drawing.Point(0, 0);
			this.imagePreview.Name = "imagePreview";
			this.imagePreview.Size = new System.Drawing.Size(270, 342);
			this.imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imagePreview.TabIndex = 0;
			this.imagePreview.TabStop = false;
			// 
			// ImagePreviewPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.imagePreview);
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Name = "ImagePreviewPanel";
			this.Size = new System.Drawing.Size(270, 342);
			((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imagePreview;
	}
}
