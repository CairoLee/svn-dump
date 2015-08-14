namespace GrfEditor.Plugins.PreviewGat {
	partial class GatPreviewPanel {
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
			this.pnlModify = new System.Windows.Forms.Panel();
			this.pnlModifyInner = new System.Windows.Forms.Panel();
			this.btnZoomIn = new System.Windows.Forms.Button();
			this.btnZoomOut = new System.Windows.Forms.Button();
			this.btnZoomReset = new System.Windows.Forms.Button();
			this.imagePreview = new System.Windows.Forms.PictureBox();
			this.progressLoading = new System.Windows.Forms.ProgressBar();
			this.pnlModify.SuspendLayout();
			this.pnlModifyInner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlModify
			// 
			this.pnlModify.BackColor = System.Drawing.Color.Transparent;
			this.pnlModify.Controls.Add(this.pnlModifyInner);
			this.pnlModify.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlModify.Location = new System.Drawing.Point(0, 294);
			this.pnlModify.Name = "pnlModify";
			this.pnlModify.Size = new System.Drawing.Size(270, 48);
			this.pnlModify.TabIndex = 0;
			// 
			// pnlModifyInner
			// 
			this.pnlModifyInner.Controls.Add(this.btnZoomIn);
			this.pnlModifyInner.Controls.Add(this.btnZoomOut);
			this.pnlModifyInner.Controls.Add(this.btnZoomReset);
			this.pnlModifyInner.Location = new System.Drawing.Point(80, 4);
			this.pnlModifyInner.Name = "pnlModifyInner";
			this.pnlModifyInner.Size = new System.Drawing.Size(113, 41);
			this.pnlModifyInner.TabIndex = 10;
			// 
			// btnZoomIn
			// 
			this.btnZoomIn.Image = global::GrfEditor.Library.Properties.Resources.zoom_in;
			this.btnZoomIn.Location = new System.Drawing.Point(5, 3);
			this.btnZoomIn.Name = "btnZoomIn";
			this.btnZoomIn.Size = new System.Drawing.Size(30, 30);
			this.btnZoomIn.TabIndex = 9;
			this.btnZoomIn.UseVisualStyleBackColor = true;
			this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
			// 
			// btnZoomOut
			// 
			this.btnZoomOut.Image = global::GrfEditor.Library.Properties.Resources.zoom_out;
			this.btnZoomOut.Location = new System.Drawing.Point(77, 3);
			this.btnZoomOut.Name = "btnZoomOut";
			this.btnZoomOut.Size = new System.Drawing.Size(30, 30);
			this.btnZoomOut.TabIndex = 7;
			this.btnZoomOut.UseVisualStyleBackColor = true;
			this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
			// 
			// btnZoomReset
			// 
			this.btnZoomReset.Image = global::GrfEditor.Library.Properties.Resources.view_1_1;
			this.btnZoomReset.Location = new System.Drawing.Point(41, 3);
			this.btnZoomReset.Name = "btnZoomReset";
			this.btnZoomReset.Size = new System.Drawing.Size(30, 30);
			this.btnZoomReset.TabIndex = 8;
			this.btnZoomReset.UseVisualStyleBackColor = true;
			this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
			// 
			// imagePreview
			// 
			this.imagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePreview.Location = new System.Drawing.Point(0, 0);
			this.imagePreview.Name = "imagePreview";
			this.imagePreview.Size = new System.Drawing.Size(270, 294);
			this.imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imagePreview.TabIndex = 1;
			this.imagePreview.TabStop = false;
			this.imagePreview.Click += new System.EventHandler(this.imagePreview_Click);
			// 
			// progressLoading
			// 
			this.progressLoading.Location = new System.Drawing.Point(20, 161);
			this.progressLoading.Name = "progressLoading";
			this.progressLoading.Size = new System.Drawing.Size(233, 23);
			this.progressLoading.TabIndex = 2;
			this.progressLoading.Visible = false;
			// 
			// GatPreviewPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.progressLoading);
			this.Controls.Add(this.imagePreview);
			this.Controls.Add(this.pnlModify);
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Name = "GatPreviewPanel";
			this.Size = new System.Drawing.Size(270, 342);
			this.Resize += new System.EventHandler(this.GatPreviewPanel_Resize);
			this.pnlModify.ResumeLayout(false);
			this.pnlModifyInner.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlModify;
		private System.Windows.Forms.PictureBox imagePreview;
		private System.Windows.Forms.Button btnZoomIn;
		private System.Windows.Forms.Button btnZoomReset;
		private System.Windows.Forms.Button btnZoomOut;
		private System.Windows.Forms.Panel pnlModifyInner;
		private System.Windows.Forms.ProgressBar progressLoading;
	}
}
