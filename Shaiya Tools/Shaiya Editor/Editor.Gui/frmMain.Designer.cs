namespace Editor.Gui {
	partial class frmMain {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMain ) );
			this.FileTree = new System.Windows.Forms.TreeView();
			this.FileTreeContext = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.FileTreeContextExtract = new System.Windows.Forms.ToolStripMenuItem();
			this.FileTreeContextReplace = new System.Windows.Forms.ToolStripMenuItem();
			this.FileImageList = new System.Windows.Forms.ImageList( this.components );
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuData = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuDataOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuDataSave = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ToolStripOpen = new System.Windows.Forms.ToolStripButton();
			this.ToolStripSave = new System.Windows.Forms.ToolStripButton();
			this.PanelPreview = new System.Windows.Forms.Panel();
			this.FileTreeContextSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.FileTreeContextAddFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.FileTreeContextAddFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuDataRepack = new System.Windows.Forms.ToolStripMenuItem();
			this.FileTreeContext.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// FileTree
			// 
			this.FileTree.ContextMenuStrip = this.FileTreeContext;
			this.FileTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.FileTree.ImageIndex = 0;
			this.FileTree.ImageList = this.FileImageList;
			this.FileTree.Location = new System.Drawing.Point( 0, 49 );
			this.FileTree.Name = "FileTree";
			this.FileTree.SelectedImageIndex = 0;
			this.FileTree.Size = new System.Drawing.Size( 297, 337 );
			this.FileTree.TabIndex = 0;
			this.FileTree.MouseClick += new System.Windows.Forms.MouseEventHandler( this.FileTree_MouseClick );
			this.FileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.FileTree_AfterSelect );
			// 
			// FileTreeContext
			// 
			this.FileTreeContext.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.FileTreeContextExtract,
            this.FileTreeContextReplace,
            this.FileTreeContextSep1,
            this.FileTreeContextAddFolder,
            this.FileTreeContextAddFile} );
			this.FileTreeContext.Name = "FileTreeContext";
			this.FileTreeContext.Size = new System.Drawing.Size( 173, 98 );
			this.FileTreeContext.Opening += new System.ComponentModel.CancelEventHandler( this.FileTreeContext_Opening );
			// 
			// FileTreeContextExtract
			// 
			this.FileTreeContextExtract.Name = "FileTreeContextExtract";
			this.FileTreeContextExtract.Size = new System.Drawing.Size( 172, 22 );
			this.FileTreeContextExtract.Text = "Entpacken";
			this.FileTreeContextExtract.Click += new System.EventHandler( this.FileTreeContextExtract_Click );
			// 
			// FileTreeContextReplace
			// 
			this.FileTreeContextReplace.Name = "FileTreeContextReplace";
			this.FileTreeContextReplace.Size = new System.Drawing.Size( 172, 22 );
			this.FileTreeContextReplace.Text = "Ersetzen";
			this.FileTreeContextReplace.Click += new System.EventHandler( this.FileTreeContextReplace_Click );
			// 
			// FileImageList
			// 
			this.FileImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "FileImageList.ImageStream" ) ) );
			this.FileImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.FileImageList.Images.SetKeyName( 0, "shell32_5.ico" );
			this.FileImageList.Images.SetKeyName( 1, "shell32_152.ico" );
			this.FileImageList.Images.SetKeyName( 2, "shell32_226.ico" );
			this.FileImageList.Images.SetKeyName( 3, "shell32_225.ico" );
			this.FileImageList.Images.SetKeyName( 4, "shell32_154.ico" );
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram,
            this.MenuData} );
			this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size( 676, 24 );
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// MenuProgram
			// 
			this.MenuProgram.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgramClose} );
			this.MenuProgram.Name = "MenuProgram";
			this.MenuProgram.Size = new System.Drawing.Size( 67, 20 );
			this.MenuProgram.Text = "Programm";
			// 
			// MenuProgramClose
			// 
			this.MenuProgramClose.Name = "MenuProgramClose";
			this.MenuProgramClose.Size = new System.Drawing.Size( 116, 22 );
			this.MenuProgramClose.Text = "Beenden";
			this.MenuProgramClose.Click += new System.EventHandler( this.MenuProgramClose_Click );
			// 
			// MenuData
			// 
			this.MenuData.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuDataOpen,
            this.MenuDataSave,
            this.toolStripSeparator1,
            this.MenuDataRepack} );
			this.MenuData.Name = "MenuData";
			this.MenuData.Size = new System.Drawing.Size( 42, 20 );
			this.MenuData.Text = "Data";
			// 
			// MenuDataOpen
			// 
			this.MenuDataOpen.Name = "MenuDataOpen";
			this.MenuDataOpen.Size = new System.Drawing.Size( 152, 22 );
			this.MenuDataOpen.Text = "Öffnen";
			this.MenuDataOpen.Click += new System.EventHandler( this.MenuDataOpen_Click );
			// 
			// MenuDataSave
			// 
			this.MenuDataSave.Enabled = false;
			this.MenuDataSave.Name = "MenuDataSave";
			this.MenuDataSave.Size = new System.Drawing.Size( 152, 22 );
			this.MenuDataSave.Text = "Speichern";
			this.MenuDataSave.Click += new System.EventHandler( this.MenuDataSave_Click );
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point( 0, 386 );
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size( 676, 22 );
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripOpen,
            this.ToolStripSave} );
			this.toolStrip1.Location = new System.Drawing.Point( 0, 24 );
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size( 676, 25 );
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// ToolStripOpen
			// 
			this.ToolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripOpen.Image = global::Editor.Gui.Properties.Resources.folder_page;
			this.ToolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripOpen.Name = "ToolStripOpen";
			this.ToolStripOpen.Size = new System.Drawing.Size( 23, 22 );
			this.ToolStripOpen.Text = "Shaiya Data öffnen";
			this.ToolStripOpen.Click += new System.EventHandler( this.ToolStripOpen_Click );
			// 
			// ToolStripSave
			// 
			this.ToolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripSave.Enabled = false;
			this.ToolStripSave.Image = global::Editor.Gui.Properties.Resources.disk;
			this.ToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripSave.Name = "ToolStripSave";
			this.ToolStripSave.Size = new System.Drawing.Size( 23, 22 );
			this.ToolStripSave.Text = "Shaiya Data speichern";
			this.ToolStripSave.Click += new System.EventHandler( this.ToolStripSave_Click );
			// 
			// PanelPreview
			// 
			this.PanelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelPreview.Location = new System.Drawing.Point( 297, 49 );
			this.PanelPreview.Name = "PanelPreview";
			this.PanelPreview.Size = new System.Drawing.Size( 379, 337 );
			this.PanelPreview.TabIndex = 5;
			// 
			// FileTreeContextSep1
			// 
			this.FileTreeContextSep1.Name = "FileTreeContextSep1";
			this.FileTreeContextSep1.Size = new System.Drawing.Size( 169, 6 );
			this.FileTreeContextSep1.Visible = false;
			// 
			// FileTreeContextAddFolder
			// 
			this.FileTreeContextAddFolder.Name = "FileTreeContextAddFolder";
			this.FileTreeContextAddFolder.Size = new System.Drawing.Size( 172, 22 );
			this.FileTreeContextAddFolder.Text = "Ordner hinzufügen..";
			this.FileTreeContextAddFolder.Visible = false;
			this.FileTreeContextAddFolder.Click += new System.EventHandler( this.FileTreeContextAddFolder_Click );
			// 
			// FileTreeContextAddFile
			// 
			this.FileTreeContextAddFile.Name = "FileTreeContextAddFile";
			this.FileTreeContextAddFile.Size = new System.Drawing.Size( 172, 22 );
			this.FileTreeContextAddFile.Text = "Datei hinzufügen..";
			this.FileTreeContextAddFile.Visible = false;
			this.FileTreeContextAddFile.Click += new System.EventHandler( this.FileTreeContextAddFile_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 149, 6 );
			// 
			// MenuDataRepack
			// 
			this.MenuDataRepack.Enabled = false;
			this.MenuDataRepack.Name = "MenuDataRepack";
			this.MenuDataRepack.Size = new System.Drawing.Size( 152, 22 );
			this.MenuDataRepack.Text = "Neu packen";
			this.MenuDataRepack.Click += new System.EventHandler( this.MenuDataRepack_Click );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 676, 408 );
			this.Controls.Add( this.PanelPreview );
			this.Controls.Add( this.FileTree );
			this.Controls.Add( this.toolStrip1 );
			this.Controls.Add( this.statusStrip1 );
			this.Controls.Add( this.menuStrip1 );
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.Text = "Shaiya Data Editor - by GodLesZ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmMain_FormClosing );
			this.FileTreeContext.ResumeLayout( false );
			this.menuStrip1.ResumeLayout( false );
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout( false );
			this.toolStrip1.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView FileTree;
		private System.Windows.Forms.ImageList FileImageList;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton ToolStripOpen;
		private System.Windows.Forms.Panel PanelPreview;
		private System.Windows.Forms.ContextMenuStrip FileTreeContext;
		private System.Windows.Forms.ToolStripMenuItem FileTreeContextExtract;
		private System.Windows.Forms.ToolStripMenuItem FileTreeContextReplace;
		private System.Windows.Forms.ToolStripMenuItem MenuProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramClose;
		private System.Windows.Forms.ToolStripMenuItem MenuData;
		private System.Windows.Forms.ToolStripMenuItem MenuDataSave;
		private System.Windows.Forms.ToolStripMenuItem MenuDataOpen;
		private System.Windows.Forms.ToolStripButton ToolStripSave;
		private System.Windows.Forms.ToolStripSeparator FileTreeContextSep1;
		private System.Windows.Forms.ToolStripMenuItem FileTreeContextAddFolder;
		private System.Windows.Forms.ToolStripMenuItem FileTreeContextAddFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem MenuDataRepack;
	}
}

