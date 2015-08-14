namespace eAthenaStudio.Client {
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("eAthena Verzeichnis");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("eAthena Manager", new System.Windows.Forms.TreeNode[] {
            treeNode1});
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Plugins");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
			this.treeProperties = new System.Windows.Forms.TreeView();
			this.imagesTreeView = new System.Windows.Forms.ImageList(this.components);
			this.panelControls = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeProperties
			// 
			this.treeProperties.ImageKey = "folder_closed 16x16.png";
			this.treeProperties.ImageList = this.imagesTreeView;
			this.treeProperties.Location = new System.Drawing.Point(12, 12);
			this.treeProperties.Name = "treeProperties";
			treeNode1.Name = "nodeEaManagerRoot";
			treeNode1.Tag = "1";
			treeNode1.Text = "eAthena Verzeichnis";
			treeNode2.Name = "nodeEaManager";
			treeNode2.Tag = "0";
			treeNode2.Text = "eAthena Manager";
			treeNode3.Name = "nodePlugins";
			treeNode3.Tag = "10";
			treeNode3.Text = "Plugins";
			this.treeProperties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
			this.treeProperties.SelectedImageKey = "folder_closed 16x16.png";
			this.treeProperties.Size = new System.Drawing.Size(167, 291);
			this.treeProperties.TabIndex = 0;
			this.treeProperties.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeProperties_AfterCollapse);
			this.treeProperties.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeProperties_AfterSelect);
			this.treeProperties.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeProperties_AfterExpand);
			// 
			// imagesTreeView
			// 
			this.imagesTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesTreeView.ImageStream")));
			this.imagesTreeView.TransparentColor = System.Drawing.Color.Transparent;
			this.imagesTreeView.Images.SetKeyName(0, "folder_closed 16x16.png");
			this.imagesTreeView.Images.SetKeyName(1, "folder_open 16x16.png");
			// 
			// panelControls
			// 
			this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelControls.BackColor = System.Drawing.Color.Transparent;
			this.panelControls.Location = new System.Drawing.Point(186, 12);
			this.panelControls.Name = "panelControls";
			this.panelControls.Size = new System.Drawing.Size(438, 291);
			this.panelControls.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(549, 309);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(468, 309);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmSettings
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(636, 377);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.panelControls);
			this.Controls.Add(this.treeProperties);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmSettings";
			this.Text = "eAthena Tool - Optionen";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeProperties;
		private System.Windows.Forms.Panel panelControls;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ImageList imagesTreeView;
	}
}