namespace eAthenaStudio.Library.Forms {
	partial class frmOverwriteFile {
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
			this.labelText = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonRename = new System.Windows.Forms.Button();
			this.buttonOverwrite = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelText
			// 
			this.labelText.Location = new System.Drawing.Point(12, 9);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(460, 59);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "Die Datei # existiert bereits. Möchtest du sie überschreiben, umbenennen, oder di" +
				"e Aktion abbrechen?";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(388, 79);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(84, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Abbrechen";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonRename
			// 
			this.buttonRename.Location = new System.Drawing.Point(298, 79);
			this.buttonRename.Name = "buttonRename";
			this.buttonRename.Size = new System.Drawing.Size(84, 23);
			this.buttonRename.TabIndex = 2;
			this.buttonRename.Text = "Umbennen";
			this.buttonRename.UseVisualStyleBackColor = true;
			this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
			// 
			// buttonOverwrite
			// 
			this.buttonOverwrite.Location = new System.Drawing.Point(208, 79);
			this.buttonOverwrite.Name = "buttonOverwrite";
			this.buttonOverwrite.Size = new System.Drawing.Size(84, 23);
			this.buttonOverwrite.TabIndex = 3;
			this.buttonOverwrite.Text = "Überschreiben";
			this.buttonOverwrite.UseVisualStyleBackColor = true;
			this.buttonOverwrite.Click += new System.EventHandler(this.buttonOverwrite_Click);
			// 
			// frmOverwriteFile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 114);
			this.ControlBox = false;
			this.Controls.Add(this.buttonOverwrite);
			this.Controls.Add(this.buttonRename);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmOverwriteFile";
			this.Text = "Datei überschreiben oder umbennen";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonRename;
		private System.Windows.Forms.Button buttonOverwrite;
	}
}