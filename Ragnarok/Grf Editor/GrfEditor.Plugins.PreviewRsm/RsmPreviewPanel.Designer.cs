
namespace GrfEditor.Library.Controls {
	partial class RsmPreviewPanel {
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
            this.renderDisplay = new GodLesZ.Library.MonoGame.DeviceFake.TileDisplay();
			this.SuspendLayout();
			// 
			// renderDisplay
			// 
			this.renderDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.renderDisplay.Location = new System.Drawing.Point(0, 0);
			this.renderDisplay.Name = "renderDisplay";
			this.renderDisplay.Size = new System.Drawing.Size(1008, 546);
			this.renderDisplay.TabIndex = 0;
			this.renderDisplay.Text = "renderDisplay";
			// 
			// RsmPreviewPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.renderDisplay);
			this.Name = "RsmPreviewPanel";
			this.Size = new System.Drawing.Size(1008, 546);
			this.ResumeLayout(false);

		}

		#endregion

        private GodLesZ.Library.MonoGame.DeviceFake.TileDisplay renderDisplay;
	}
}
