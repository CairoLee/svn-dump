namespace GodLesZ.FunRO.Patcher {
	partial class frmSettings {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.rdbLayoutDefault = new System.Windows.Forms.RadioButton();
			this.imgLayoutDefault = new System.Windows.Forms.PictureBox();
			this.imgLayoutRed = new System.Windows.Forms.PictureBox();
			this.rdbLayoutRed = new System.Windows.Forms.RadioButton();
			this.imgLayoutGray = new System.Windows.Forms.PictureBox();
			this.rdbLayoutGray = new System.Windows.Forms.RadioButton();
			this.imgLayoutGreen = new System.Windows.Forms.PictureBox();
			this.rdbLayoutGreen = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.imgLayoutDefault)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLayoutRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLayoutGray)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLayoutGreen)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(709, 430);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(628, 430);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "Layout";
			// 
			// rdbLayoutDefault
			// 
			this.rdbLayoutDefault.AutoSize = true;
			this.rdbLayoutDefault.Checked = true;
			this.rdbLayoutDefault.Location = new System.Drawing.Point(17, 129);
			this.rdbLayoutDefault.Name = "rdbLayoutDefault";
			this.rdbLayoutDefault.Size = new System.Drawing.Size(59, 17);
			this.rdbLayoutDefault.TabIndex = 3;
			this.rdbLayoutDefault.Text = "Default";
			this.rdbLayoutDefault.UseVisualStyleBackColor = true;
			// 
			// imgLayoutDefault
			// 
			this.imgLayoutDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgLayoutDefault.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgLayoutDefault.Image = ((System.Drawing.Image)(resources.GetObject("imgLayoutDefault.Image")));
			this.imgLayoutDefault.Location = new System.Drawing.Point(82, 56);
			this.imgLayoutDefault.Name = "imgLayoutDefault";
			this.imgLayoutDefault.Size = new System.Drawing.Size(302, 168);
			this.imgLayoutDefault.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imgLayoutDefault.TabIndex = 4;
			this.imgLayoutDefault.TabStop = false;
			this.imgLayoutDefault.Click += new System.EventHandler(this.imgLayoutDefault_Click);
			// 
			// imgLayoutRed
			// 
			this.imgLayoutRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgLayoutRed.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgLayoutRed.Image = ((System.Drawing.Image)(resources.GetObject("imgLayoutRed.Image")));
			this.imgLayoutRed.Location = new System.Drawing.Point(484, 56);
			this.imgLayoutRed.Name = "imgLayoutRed";
			this.imgLayoutRed.Size = new System.Drawing.Size(302, 168);
			this.imgLayoutRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imgLayoutRed.TabIndex = 6;
			this.imgLayoutRed.TabStop = false;
			this.imgLayoutRed.Click += new System.EventHandler(this.imgLayoutRed_Click);
			// 
			// rdbLayoutRed
			// 
			this.rdbLayoutRed.AutoSize = true;
			this.rdbLayoutRed.Location = new System.Drawing.Point(419, 129);
			this.rdbLayoutRed.Name = "rdbLayoutRed";
			this.rdbLayoutRed.Size = new System.Drawing.Size(45, 17);
			this.rdbLayoutRed.TabIndex = 5;
			this.rdbLayoutRed.Text = "Red";
			this.rdbLayoutRed.UseVisualStyleBackColor = true;
			// 
			// imgLayoutGray
			// 
			this.imgLayoutGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgLayoutGray.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgLayoutGray.Image = ((System.Drawing.Image)(resources.GetObject("imgLayoutGray.Image")));
			this.imgLayoutGray.Location = new System.Drawing.Point(484, 242);
			this.imgLayoutGray.Name = "imgLayoutGray";
			this.imgLayoutGray.Size = new System.Drawing.Size(302, 168);
			this.imgLayoutGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imgLayoutGray.TabIndex = 10;
			this.imgLayoutGray.TabStop = false;
			this.imgLayoutGray.Click += new System.EventHandler(this.imgLayoutGray_Click);
			// 
			// rdbLayoutGray
			// 
			this.rdbLayoutGray.AutoSize = true;
			this.rdbLayoutGray.Location = new System.Drawing.Point(419, 315);
			this.rdbLayoutGray.Name = "rdbLayoutGray";
			this.rdbLayoutGray.Size = new System.Drawing.Size(47, 17);
			this.rdbLayoutGray.TabIndex = 9;
			this.rdbLayoutGray.Text = "Gray";
			this.rdbLayoutGray.UseVisualStyleBackColor = true;
			// 
			// imgLayoutGreen
			// 
			this.imgLayoutGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgLayoutGreen.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgLayoutGreen.Image = ((System.Drawing.Image)(resources.GetObject("imgLayoutGreen.Image")));
			this.imgLayoutGreen.Location = new System.Drawing.Point(82, 242);
			this.imgLayoutGreen.Name = "imgLayoutGreen";
			this.imgLayoutGreen.Size = new System.Drawing.Size(302, 168);
			this.imgLayoutGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imgLayoutGreen.TabIndex = 8;
			this.imgLayoutGreen.TabStop = false;
			this.imgLayoutGreen.Click += new System.EventHandler(this.imgLayoutGreen_Click);
			// 
			// rdbLayoutGreen
			// 
			this.rdbLayoutGreen.AutoSize = true;
			this.rdbLayoutGreen.Location = new System.Drawing.Point(17, 315);
			this.rdbLayoutGreen.Name = "rdbLayoutGreen";
			this.rdbLayoutGreen.Size = new System.Drawing.Size(54, 17);
			this.rdbLayoutGreen.TabIndex = 7;
			this.rdbLayoutGreen.Text = "Green";
			this.rdbLayoutGreen.UseVisualStyleBackColor = true;
			// 
			// frmSettings
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(796, 465);
			this.Controls.Add(this.imgLayoutGray);
			this.Controls.Add(this.rdbLayoutGray);
			this.Controls.Add(this.imgLayoutGreen);
			this.Controls.Add(this.rdbLayoutGreen);
			this.Controls.Add(this.imgLayoutRed);
			this.Controls.Add(this.rdbLayoutRed);
			this.Controls.Add(this.imgLayoutDefault);
			this.Controls.Add(this.rdbLayoutDefault);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSettings";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FunRO Patcher - Options";
			((System.ComponentModel.ISupportInitialize)(this.imgLayoutDefault)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLayoutRed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLayoutGray)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLayoutGreen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rdbLayoutDefault;
		private System.Windows.Forms.PictureBox imgLayoutDefault;
		private System.Windows.Forms.PictureBox imgLayoutRed;
		private System.Windows.Forms.RadioButton rdbLayoutRed;
		private System.Windows.Forms.PictureBox imgLayoutGray;
		private System.Windows.Forms.RadioButton rdbLayoutGray;
		private System.Windows.Forms.PictureBox imgLayoutGreen;
		private System.Windows.Forms.RadioButton rdbLayoutGreen;
	}
}