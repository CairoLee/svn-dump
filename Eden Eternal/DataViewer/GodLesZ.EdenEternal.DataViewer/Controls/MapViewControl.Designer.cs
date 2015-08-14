namespace GodLesZ.EdenEternal.DataViewer.Controls {
	partial class MapViewControl {
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
			this.imageMap = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imageMap)).BeginInit();
			this.SuspendLayout();
			// 
			// imageMap
			// 
			this.imageMap.BackColor = System.Drawing.Color.Transparent;
			this.imageMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imageMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageMap.Location = new System.Drawing.Point(0, 0);
			this.imageMap.Name = "imageMap";
			this.imageMap.Size = new System.Drawing.Size(554, 421);
			this.imageMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imageMap.TabIndex = 0;
			this.imageMap.TabStop = false;
			this.imageMap.SizeChanged += new System.EventHandler(this.imageMap_SizeChanged);
			// 
			// MapViewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.imageMap);
			this.Name = "MapViewControl";
			this.Size = new System.Drawing.Size(554, 421);
			((System.ComponentModel.ISupportInitialize)(this.imageMap)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imageMap;
	}
}
