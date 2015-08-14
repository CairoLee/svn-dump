namespace FreeWorld.Editor.Animation {
	partial class FormImportRpgMaker {
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
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.btnImportSelected = new System.Windows.Forms.Button();
			this.listAnimations = new System.Windows.Forms.ListView();
			this.colIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colFrames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Location = new System.Drawing.Point(13, 13);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
			this.btnOpenFile.TabIndex = 0;
			this.btnOpenFile.Text = "Open file..";
			this.btnOpenFile.UseVisualStyleBackColor = true;
			this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
			// 
			// btnImportSelected
			// 
			this.btnImportSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImportSelected.Enabled = false;
			this.btnImportSelected.Location = new System.Drawing.Point(287, 257);
			this.btnImportSelected.Name = "btnImportSelected";
			this.btnImportSelected.Size = new System.Drawing.Size(103, 23);
			this.btnImportSelected.TabIndex = 2;
			this.btnImportSelected.Text = "Import selected";
			this.btnImportSelected.UseVisualStyleBackColor = true;
			this.btnImportSelected.Click += new System.EventHandler(this.btnImportSelected_Click);
			// 
			// listAnimations
			// 
			this.listAnimations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIndex,
            this.colName,
            this.colFrames});
			this.listAnimations.FullRowSelect = true;
			this.listAnimations.GridLines = true;
			this.listAnimations.Location = new System.Drawing.Point(13, 43);
			this.listAnimations.MultiSelect = false;
			this.listAnimations.Name = "listAnimations";
			this.listAnimations.Size = new System.Drawing.Size(250, 237);
			this.listAnimations.TabIndex = 3;
			this.listAnimations.UseCompatibleStateImageBehavior = false;
			this.listAnimations.View = System.Windows.Forms.View.Details;
			this.listAnimations.SelectedIndexChanged += new System.EventHandler(this.listAnimations_SelectedIndexChanged);
			// 
			// colIndex
			// 
			this.colIndex.Text = "#";
			this.colIndex.Width = 34;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 147;
			// 
			// colFrames
			// 
			this.colFrames.Text = "Frames";
			this.colFrames.Width = 47;
			// 
			// FormImportRpgMaker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 289);
			this.Controls.Add(this.listAnimations);
			this.Controls.Add(this.btnImportSelected);
			this.Controls.Add(this.btnOpenFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormImportRpgMaker";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Import from RPG Maker Export";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.Button btnImportSelected;
		private System.Windows.Forms.ListView listAnimations;
		private System.Windows.Forms.ColumnHeader colIndex;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colFrames;
	}
}