namespace GodLesZ.EdenEternal.DataViewer.Controls {
	partial class MonsterListControl {
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
			this.components = new System.ComponentModel.Container();
			this.mobImages = new System.Windows.Forms.ImageList(this.components);
			this.listMonsters = new System.Windows.Forms.ListView();
			this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mobImagesLarge = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// mobImages
			// 
			this.mobImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.mobImages.ImageSize = new System.Drawing.Size(32, 32);
			this.mobImages.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// listMonsters
			// 
			this.listMonsters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colName});
			this.listMonsters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMonsters.FullRowSelect = true;
			this.listMonsters.GridLines = true;
			this.listMonsters.LargeImageList = this.mobImagesLarge;
			this.listMonsters.Location = new System.Drawing.Point(0, 0);
			this.listMonsters.MultiSelect = false;
			this.listMonsters.Name = "listMonsters";
			this.listMonsters.Size = new System.Drawing.Size(575, 357);
			this.listMonsters.SmallImageList = this.mobImages;
			this.listMonsters.TabIndex = 0;
			this.listMonsters.UseCompatibleStateImageBehavior = false;
			this.listMonsters.View = System.Windows.Forms.View.Details;
			// 
			// colID
			// 
			this.colID.Text = "ID";
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 310;
			// 
			// mobImagesLarge
			// 
			this.mobImagesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.mobImagesLarge.ImageSize = new System.Drawing.Size(64, 64);
			this.mobImagesLarge.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MonsterListControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.listMonsters);
			this.Name = "MonsterListControl";
			this.Size = new System.Drawing.Size(575, 357);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList mobImages;
		private System.Windows.Forms.ListView listMonsters;
		private System.Windows.Forms.ColumnHeader colID;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ImageList mobImagesLarge;
	}
}
