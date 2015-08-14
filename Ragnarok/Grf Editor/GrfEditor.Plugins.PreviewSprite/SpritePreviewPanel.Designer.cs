namespace GrfEditor.Plugins.PreviewSprite {
	partial class SpritePreviewPanel {
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
			this.btnFirst = new System.Windows.Forms.Button();
			this.btnZoomReset = new System.Windows.Forms.Button();
			this.btnPrev = new System.Windows.Forms.Button();
			this.btnZoomOut = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnLast = new System.Windows.Forms.Button();
			this.imgSprite = new System.Windows.Forms.PictureBox();
			this.pnlModify.SuspendLayout();
			this.pnlModifyInner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgSprite)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlModify
			// 
			this.pnlModify.Controls.Add(this.pnlModifyInner);
			this.pnlModify.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlModify.Location = new System.Drawing.Point(0, 296);
			this.pnlModify.Name = "pnlModify";
			this.pnlModify.Size = new System.Drawing.Size(272, 48);
			this.pnlModify.TabIndex = 0;
			// 
			// pnlModifyInner
			// 
			this.pnlModifyInner.Controls.Add(this.btnZoomIn);
			this.pnlModifyInner.Controls.Add(this.btnFirst);
			this.pnlModifyInner.Controls.Add(this.btnZoomReset);
			this.pnlModifyInner.Controls.Add(this.btnPrev);
			this.pnlModifyInner.Controls.Add(this.btnZoomOut);
			this.pnlModifyInner.Controls.Add(this.btnNext);
			this.pnlModifyInner.Controls.Add(this.btnLast);
			this.pnlModifyInner.Location = new System.Drawing.Point(6, 5);
			this.pnlModifyInner.Name = "pnlModifyInner";
			this.pnlModifyInner.Size = new System.Drawing.Size(260, 39);
			this.pnlModifyInner.TabIndex = 2;
			// 
			// btnZoomIn
			// 
			this.btnZoomIn.Image = global::GrfEditor.Library.Properties.Resources.zoom_in;
			this.btnZoomIn.Location = new System.Drawing.Point(156, 4);
			this.btnZoomIn.Name = "btnZoomIn";
			this.btnZoomIn.Size = new System.Drawing.Size(30, 30);
			this.btnZoomIn.TabIndex = 6;
			this.btnZoomIn.UseVisualStyleBackColor = true;
			this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
			// 
			// btnFirst
			// 
			this.btnFirst.Image = global::GrfEditor.Library.Properties.Resources.media_beginning;
			this.btnFirst.Location = new System.Drawing.Point(3, 4);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(30, 30);
			this.btnFirst.TabIndex = 0;
			this.btnFirst.UseVisualStyleBackColor = true;
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// btnZoomReset
			// 
			this.btnZoomReset.Image = global::GrfEditor.Library.Properties.Resources.view_1_1;
			this.btnZoomReset.Location = new System.Drawing.Point(192, 4);
			this.btnZoomReset.Name = "btnZoomReset";
			this.btnZoomReset.Size = new System.Drawing.Size(30, 30);
			this.btnZoomReset.TabIndex = 5;
			this.btnZoomReset.UseVisualStyleBackColor = true;
			this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
			// 
			// btnPrev
			// 
			this.btnPrev.Image = global::GrfEditor.Library.Properties.Resources.media_rewind;
			this.btnPrev.Location = new System.Drawing.Point(39, 4);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(30, 30);
			this.btnPrev.TabIndex = 1;
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// btnZoomOut
			// 
			this.btnZoomOut.Image = global::GrfEditor.Library.Properties.Resources.zoom_out;
			this.btnZoomOut.Location = new System.Drawing.Point(228, 4);
			this.btnZoomOut.Name = "btnZoomOut";
			this.btnZoomOut.Size = new System.Drawing.Size(30, 30);
			this.btnZoomOut.TabIndex = 4;
			this.btnZoomOut.UseVisualStyleBackColor = true;
			this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
			// 
			// btnNext
			// 
			this.btnNext.Image = global::GrfEditor.Library.Properties.Resources.media_fast_forward;
			this.btnNext.Location = new System.Drawing.Point(75, 4);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(30, 30);
			this.btnNext.TabIndex = 2;
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnLast
			// 
			this.btnLast.Image = global::GrfEditor.Library.Properties.Resources.media_end;
			this.btnLast.Location = new System.Drawing.Point(111, 4);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(30, 30);
			this.btnLast.TabIndex = 3;
			this.btnLast.UseVisualStyleBackColor = true;
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// imgSprite
			// 
			this.imgSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.imgSprite.Location = new System.Drawing.Point(0, 0);
			this.imgSprite.Name = "imgSprite";
			this.imgSprite.Size = new System.Drawing.Size(272, 296);
			this.imgSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgSprite.TabIndex = 1;
			this.imgSprite.TabStop = false;
			this.imgSprite.Click += new System.EventHandler(this.imgSprite_Click);
			// 
			// SpritePreviewPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.imgSprite);
			this.Controls.Add(this.pnlModify);
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Name = "SpritePreviewPanel";
			this.Size = new System.Drawing.Size(272, 344);
			this.Resize += new System.EventHandler(this.SpritePreviewPanel_Resize);
			this.pnlModify.ResumeLayout(false);
			this.pnlModifyInner.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imgSprite)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlModify;
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.PictureBox imgSprite;
		private System.Windows.Forms.Button btnZoomOut;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnZoomIn;
		private System.Windows.Forms.Button btnZoomReset;
		private System.Windows.Forms.Panel pnlModifyInner;
	}
}
