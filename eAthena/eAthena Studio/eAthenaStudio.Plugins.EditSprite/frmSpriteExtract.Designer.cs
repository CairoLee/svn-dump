namespace eAthenaStudio.Plugins.EditSprite {
	partial class frmSpriteExtract {
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnExtract = new System.Windows.Forms.Button();
			this.btnOpenFolder = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.chkAllFrames = new System.Windows.Forms.CheckBox();
			this.checkedFrames = new System.Windows.Forms.CheckedListBox();
			this.chkTransparency = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Zielordner";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(73, 10);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(257, 20);
			this.textBox1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(340, 132);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnExtract
			// 
			this.btnExtract.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnExtract.Enabled = false;
			this.btnExtract.Location = new System.Drawing.Point(259, 132);
			this.btnExtract.Name = "btnExtract";
			this.btnExtract.Size = new System.Drawing.Size(75, 23);
			this.btnExtract.TabIndex = 3;
			this.btnExtract.Text = "Entpacken";
			this.btnExtract.UseVisualStyleBackColor = true;
			this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
			// 
			// btnOpenFolder
			// 
			this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenFolder.Location = new System.Drawing.Point(336, 8);
			this.btnOpenFolder.Name = "btnOpenFolder";
			this.btnOpenFolder.Size = new System.Drawing.Size(79, 23);
			this.btnOpenFolder.TabIndex = 4;
			this.btnOpenFolder.Text = "Durchsuchen";
			this.btnOpenFolder.UseVisualStyleBackColor = true;
			this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Frames";
			// 
			// chkAllFrames
			// 
			this.chkAllFrames.AutoSize = true;
			this.chkAllFrames.Location = new System.Drawing.Point(187, 43);
			this.chkAllFrames.Name = "chkAllFrames";
			this.chkAllFrames.Size = new System.Drawing.Size(43, 17);
			this.chkAllFrames.TabIndex = 9;
			this.chkAllFrames.Text = "Alle";
			this.chkAllFrames.UseVisualStyleBackColor = true;
			this.chkAllFrames.CheckedChanged += new System.EventHandler(this.chkAllFrames_CheckedChanged);
			// 
			// checkedFrames
			// 
			this.checkedFrames.FormattingEnabled = true;
			this.checkedFrames.Location = new System.Drawing.Point(73, 42);
			this.checkedFrames.Name = "checkedFrames";
			this.checkedFrames.Size = new System.Drawing.Size(108, 79);
			this.checkedFrames.TabIndex = 10;
			this.checkedFrames.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedFrames_ItemCheck);
			// 
			// chkTransparency
			// 
			this.chkTransparency.AutoSize = true;
			this.chkTransparency.Location = new System.Drawing.Point(187, 66);
			this.chkTransparency.Name = "chkTransparency";
			this.chkTransparency.Size = new System.Drawing.Size(83, 17);
			this.chkTransparency.TabIndex = 11;
			this.chkTransparency.Text = "Transparent";
			this.chkTransparency.UseVisualStyleBackColor = true;
			// 
			// frmSpriteExtract
			// 
			this.AcceptButton = this.btnExtract;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(427, 167);
			this.Controls.Add(this.chkTransparency);
			this.Controls.Add(this.checkedFrames);
			this.Controls.Add(this.chkAllFrames);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOpenFolder);
			this.Controls.Add(this.btnExtract);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSpriteExtract";
			this.Text = "Sprite entpacken";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnExtract;
		private System.Windows.Forms.Button btnOpenFolder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkAllFrames;
		private System.Windows.Forms.CheckedListBox checkedFrames;
		private System.Windows.Forms.CheckBox chkTransparency;
	}
}