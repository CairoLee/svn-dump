namespace GodLesZ.EdenEternal.DataViewer.Controls {
	partial class FormMapView {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.mapViewControl = new GodLesZ.EdenEternal.DataViewer.Controls.MapViewControl();
			this.SuspendLayout();
			// 
			// mapViewControl
			// 
			this.mapViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapViewControl.Location = new System.Drawing.Point(0, 0);
			this.mapViewControl.Name = "mapViewControl";
			this.mapViewControl.SceneFile = null;
			this.mapViewControl.Size = new System.Drawing.Size(682, 442);
			this.mapViewControl.TabIndex = 0;
			// 
			// FormMapView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 442);
			this.Controls.Add(this.mapViewControl);
			this.Name = "FormMapView";
			this.Text = "FormMapView";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}

		#endregion

		private MapViewControl mapViewControl;
	}
}