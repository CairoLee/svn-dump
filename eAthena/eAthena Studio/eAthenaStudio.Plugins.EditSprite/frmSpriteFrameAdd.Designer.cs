namespace eAthenaStudio.Plugins.EditSprite {
	partial class frmSpriteFrameAdd {
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnOpen = new System.Windows.Forms.Button();
			this.cmbAddType = new System.Windows.Forms.ComboBox();
			this.cmbAddPosition = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.imgFramePreview = new System.Windows.Forms.PictureBox();
			this.imgNewPreview = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgFramePreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgNewPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bild-Datei";
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(88, 58);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 20);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "Öffnen";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// cmbAddType
			// 
			this.cmbAddType.FormattingEnabled = true;
			this.cmbAddType.Items.AddRange(new object[] {
            "nach",
            "vor"});
			this.cmbAddType.Location = new System.Drawing.Point(15, 183);
			this.cmbAddType.Name = "cmbAddType";
			this.cmbAddType.Size = new System.Drawing.Size(57, 21);
			this.cmbAddType.TabIndex = 3;
			// 
			// cmbAddPosition
			// 
			this.cmbAddPosition.FormattingEnabled = true;
			this.cmbAddPosition.Location = new System.Drawing.Point(88, 183);
			this.cmbAddPosition.Name = "cmbAddPosition";
			this.cmbAddPosition.Size = new System.Drawing.Size(74, 21);
			this.cmbAddPosition.TabIndex = 4;
			this.cmbAddPosition.SelectedIndexChanged += new System.EventHandler(this.cmbAddPosition_SelectedIndexChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(214, 299);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(133, 299);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// imgFramePreview
			// 
			this.imgFramePreview.BackColor = System.Drawing.Color.Transparent;
			this.imgFramePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgFramePreview.Location = new System.Drawing.Point(169, 138);
			this.imgFramePreview.Name = "imgFramePreview";
			this.imgFramePreview.Size = new System.Drawing.Size(120, 120);
			this.imgFramePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgFramePreview.TabIndex = 6;
			this.imgFramePreview.TabStop = false;
			// 
			// imgNewPreview
			// 
			this.imgNewPreview.BackColor = System.Drawing.Color.Transparent;
			this.imgNewPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgNewPreview.Location = new System.Drawing.Point(169, 12);
			this.imgNewPreview.Name = "imgNewPreview";
			this.imgNewPreview.Size = new System.Drawing.Size(120, 120);
			this.imgNewPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgNewPreview.TabIndex = 9;
			this.imgNewPreview.TabStop = false;
			// 
			// frmSpriteFrameAdd
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(301, 334);
			this.Controls.Add(this.imgNewPreview);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.imgFramePreview);
			this.Controls.Add(this.cmbAddPosition);
			this.Controls.Add(this.cmbAddType);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSpriteFrameAdd";
			this.Text = "Image hinzufügen";
			((System.ComponentModel.ISupportInitialize)(this.imgFramePreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgNewPreview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.ComboBox cmbAddType;
		private System.Windows.Forms.ComboBox cmbAddPosition;
		private System.Windows.Forms.PictureBox imgFramePreview;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.PictureBox imgNewPreview;
	}
}