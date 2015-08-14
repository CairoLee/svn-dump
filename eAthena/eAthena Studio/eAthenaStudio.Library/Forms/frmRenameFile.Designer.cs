namespace eAthenaStudio.Library.Forms {
	partial class frmRenameFile {
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
			this.components = new System.ComponentModel.Container();
			this.labelOldName = new System.Windows.Forms.Label();
			this.labelPath = new System.Windows.Forms.Label();
			this.textBoxNewName = new System.Windows.Forms.TextBox();
			this.labelExtension = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// labelOldName
			// 
			this.labelOldName.Location = new System.Drawing.Point(9, 9);
			this.labelOldName.Name = "labelOldName";
			this.labelOldName.Size = new System.Drawing.Size(460, 23);
			this.labelOldName.TabIndex = 0;
			this.labelOldName.Text = "Bitte gib einen neuen Dateinamen ein. (Alter Dateiname: #)";
			// 
			// labelPath
			// 
			this.labelPath.Location = new System.Drawing.Point(9, 46);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(460, 20);
			this.labelPath.TabIndex = 1;
			this.labelPath.Text = "C:/";
			// 
			// textBoxNewName
			// 
			this.textBoxNewName.Location = new System.Drawing.Point(12, 69);
			this.textBoxNewName.Name = "textBoxNewName";
			this.textBoxNewName.Size = new System.Drawing.Size(400, 20);
			this.textBoxNewName.TabIndex = 2;
			this.textBoxNewName.TextChanged += new System.EventHandler(this.textBoxNewName_TextChanged);
			// 
			// labelExtension
			// 
			this.labelExtension.AutoSize = true;
			this.labelExtension.Location = new System.Drawing.Point(418, 72);
			this.labelExtension.Name = "labelExtension";
			this.labelExtension.Size = new System.Drawing.Size(24, 13);
			this.labelExtension.TabIndex = 3;
			this.labelExtension.Text = ".ext";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(397, 108);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Abbrechen";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Enabled = false;
			this.buttonOK.Location = new System.Drawing.Point(316, 108);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// frmRenameFile
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(484, 143);
			this.ControlBox = false;
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelExtension);
			this.Controls.Add(this.textBoxNewName);
			this.Controls.Add(this.labelPath);
			this.Controls.Add(this.labelOldName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmRenameFile";
			this.Text = "Datei umbennen";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelOldName;
		private System.Windows.Forms.Label labelPath;
		public System.Windows.Forms.TextBox textBoxNewName;
		private System.Windows.Forms.Label labelExtension;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}