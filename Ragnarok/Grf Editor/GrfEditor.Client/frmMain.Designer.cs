namespace GrfEditor.Client {
	partial class FrmMain {
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

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.txtFilterText = new System.Windows.Forms.TextBox();
			this.imagesGeneralSmall = new System.Windows.Forms.ImageList(this.components);
			this.listViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.listViewContextCopyPath = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.listViewContextExtract = new System.Windows.Forms.ToolStripMenuItem();
			this.listViewContextExtractAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.listViewContextFileAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.listViewContextFolderAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.listViewContextFileRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.listViewContextFolderRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.imagesDataTypes = new System.Windows.Forms.ImageList(this.components);
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatusPlaceholder = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatusProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.lblGrfInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.mainMenuGrf = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuEditOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuEditSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuEditSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mainMenuEditNew = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.mainMenuEditExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuPlugins = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuPluginsSeperator = new System.Windows.Forms.ToolStripSeparator();
			this.mainMenuPluginsReload = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.previewImage = new System.Windows.Forms.PictureBox();
			this.previewText = new System.Windows.Forms.RichTextBox();
			this.splitterFilesPreview = new System.Windows.Forms.Splitter();
			this.pnlFiles = new System.Windows.Forms.Panel();
			this.listView = new GodLesZ.Library.Controls.FastObjectListView();
			this.colNum = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.colName = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.colDataSize = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.colDataSizeExtracted = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.colOffset = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.pnlSearch = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEn2Korea = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtID2Name = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFilter = new System.Windows.Forms.Button();
			this.listViewContext.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.pnlPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
			this.pnlFiles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
			this.pnlSearch.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtFilterText
			// 
			this.txtFilterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilterText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtFilterText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtFilterText.BackColor = System.Drawing.SystemColors.Window;
			this.txtFilterText.Enabled = false;
			this.txtFilterText.Location = new System.Drawing.Point(3, 4);
			this.txtFilterText.Name = "txtFilterText";
			this.txtFilterText.ReadOnly = true;
			this.txtFilterText.Size = new System.Drawing.Size(600, 20);
			this.txtFilterText.TabIndex = 0;
			this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
			this.txtFilterText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilterText_KeyUp);
			// 
			// imagesGeneralSmall
			// 
			this.imagesGeneralSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesGeneralSmall.ImageStream")));
			this.imagesGeneralSmall.TransparentColor = System.Drawing.Color.Transparent;
			this.imagesGeneralSmall.Images.SetKeyName(0, "box.png");
			this.imagesGeneralSmall.Images.SetKeyName(1, "box_add.png");
			this.imagesGeneralSmall.Images.SetKeyName(2, "box_closed.png");
			this.imagesGeneralSmall.Images.SetKeyName(3, "box_delete.png");
			this.imagesGeneralSmall.Images.SetKeyName(4, "box_into.png");
			this.imagesGeneralSmall.Images.SetKeyName(5, "box_new.png");
			this.imagesGeneralSmall.Images.SetKeyName(6, "box_next.png");
			this.imagesGeneralSmall.Images.SetKeyName(7, "box_out.png");
			this.imagesGeneralSmall.Images.SetKeyName(8, "box_preferences.png");
			this.imagesGeneralSmall.Images.SetKeyName(9, "box_previous.png");
			this.imagesGeneralSmall.Images.SetKeyName(10, "box_software.png");
			this.imagesGeneralSmall.Images.SetKeyName(11, "box_tall.png");
			this.imagesGeneralSmall.Images.SetKeyName(12, "box_view.png");
			this.imagesGeneralSmall.Images.SetKeyName(13, "box_white.png");
			// 
			// listViewContext
			// 
			this.listViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listViewContextCopyPath,
            this.toolStripSeparator2,
            this.listViewContextExtract,
            this.listViewContextExtractAll,
            this.toolStripSeparator4,
            this.listViewContextFileAdd,
            this.listViewContextFolderAdd,
            this.toolStripSeparator5,
            this.listViewContextFileRemove,
            this.listViewContextFolderRemove});
			this.listViewContext.Name = "listViewContext";
			this.listViewContext.Size = new System.Drawing.Size(181, 176);
			this.listViewContext.Opening += new System.ComponentModel.CancelEventHandler(this.listViewContext_Opening);
			// 
			// listViewContextCopyPath
			// 
			this.listViewContextCopyPath.Image = ((System.Drawing.Image)(resources.GetObject("listViewContextCopyPath.Image")));
			this.listViewContextCopyPath.Name = "listViewContextCopyPath";
			this.listViewContextCopyPath.Size = new System.Drawing.Size(180, 22);
			this.listViewContextCopyPath.Text = "Copy path";
			this.listViewContextCopyPath.Click += new System.EventHandler(this.listViewContextCopyPath_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
			// 
			// listViewContextExtract
			// 
			this.listViewContextExtract.Image = ((System.Drawing.Image)(resources.GetObject("listViewContextExtract.Image")));
			this.listViewContextExtract.Name = "listViewContextExtract";
			this.listViewContextExtract.Size = new System.Drawing.Size(180, 22);
			this.listViewContextExtract.Text = "Extract..";
			this.listViewContextExtract.Click += new System.EventHandler(this.listViewContextExtract_Click);
			// 
			// listViewContextExtractAll
			// 
			this.listViewContextExtractAll.Image = ((System.Drawing.Image)(resources.GetObject("listViewContextExtractAll.Image")));
			this.listViewContextExtractAll.Name = "listViewContextExtractAll";
			this.listViewContextExtractAll.Size = new System.Drawing.Size(180, 22);
			this.listViewContextExtractAll.Text = "Extract all..";
			this.listViewContextExtractAll.Click += new System.EventHandler(this.listViewContextExtractAll_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
			// 
			// listViewContextFileAdd
			// 
			this.listViewContextFileAdd.Image = ((System.Drawing.Image)(resources.GetObject("listViewContextFileAdd.Image")));
			this.listViewContextFileAdd.Name = "listViewContextFileAdd";
			this.listViewContextFileAdd.Size = new System.Drawing.Size(180, 22);
			this.listViewContextFileAdd.Text = "Add new file..";
			this.listViewContextFileAdd.Click += new System.EventHandler(this.listViewContextFileAdd_Click);
			// 
			// listViewContextFolderAdd
			// 
			this.listViewContextFolderAdd.Image = ((System.Drawing.Image)(resources.GetObject("listViewContextFolderAdd.Image")));
			this.listViewContextFolderAdd.Name = "listViewContextFolderAdd";
			this.listViewContextFolderAdd.Size = new System.Drawing.Size(180, 22);
			this.listViewContextFolderAdd.Text = "Add folder content..";
			this.listViewContextFolderAdd.Click += new System.EventHandler(this.listViewContextFolderAdd_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
			// 
			// listViewContextFileRemove
			// 
			this.listViewContextFileRemove.Image = ((System.Drawing.Image)(resources.GetObject("listViewContextFileRemove.Image")));
			this.listViewContextFileRemove.Name = "listViewContextFileRemove";
			this.listViewContextFileRemove.Size = new System.Drawing.Size(180, 22);
			this.listViewContextFileRemove.Text = "Delete file";
			this.listViewContextFileRemove.Click += new System.EventHandler(this.listViewContextFileRemove_Click);
			// 
			// listViewContextFolderRemove
			// 
			this.listViewContextFolderRemove.Image = ((System.Drawing.Image)(resources.GetObject("listViewContextFolderRemove.Image")));
			this.listViewContextFolderRemove.Name = "listViewContextFolderRemove";
			this.listViewContextFolderRemove.Size = new System.Drawing.Size(180, 22);
			this.listViewContextFolderRemove.Text = "Delete files in folder";
			this.listViewContextFolderRemove.Click += new System.EventHandler(this.listViewContextFolderRemove_Click);
			// 
			// imagesDataTypes
			// 
			this.imagesDataTypes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesDataTypes.ImageStream")));
			this.imagesDataTypes.TransparentColor = System.Drawing.Color.Transparent;
			this.imagesDataTypes.Images.SetKeyName(0, "data");
			this.imagesDataTypes.Images.SetKeyName(1, "text");
			this.imagesDataTypes.Images.SetKeyName(2, "image");
			this.imagesDataTypes.Images.SetKeyName(3, "sound");
			this.imagesDataTypes.Images.SetKeyName(4, "folder.png");
			this.imagesDataTypes.Images.SetKeyName(5, "add2.png");
			this.imagesDataTypes.Images.SetKeyName(6, "refresh.png");
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatusPlaceholder,
            this.lblStatusProgress,
            this.lblGrfInfo});
			this.statusStrip.Location = new System.Drawing.Point(0, 446);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1029, 22);
			this.statusStrip.TabIndex = 4;
			this.statusStrip.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblStatus.Image")));
			this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(55, 17);
			this.lblStatus.Text = "Ready";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusPlaceholder
			// 
			this.lblStatusPlaceholder.Name = "lblStatusPlaceholder";
			this.lblStatusPlaceholder.Size = new System.Drawing.Size(857, 17);
			this.lblStatusPlaceholder.Spring = true;
			this.lblStatusPlaceholder.Text = " ";
			// 
			// lblStatusProgress
			// 
			this.lblStatusProgress.Name = "lblStatusProgress";
			this.lblStatusProgress.Size = new System.Drawing.Size(100, 16);
			this.lblStatusProgress.Step = 1;
			this.lblStatusProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// lblGrfInfo
			// 
			this.lblGrfInfo.Name = "lblGrfInfo";
			this.lblGrfInfo.Size = new System.Drawing.Size(28, 17);
			this.lblGrfInfo.Text = "Info";
			this.lblGrfInfo.Visible = false;
			// 
			// menuStrip
			// 
			this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuGrf,
            this.menuMainSettings,
            this.mainMenuPlugins,
            this.mainMenuAbout});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1029, 24);
			this.menuStrip.TabIndex = 6;
			this.menuStrip.Text = "menuStrip1";
			// 
			// mainMenuGrf
			// 
			this.mainMenuGrf.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuEditOpen,
            this.mainMenuEditSave,
            this.mainMenuEditSaveAs,
            this.toolStripSeparator1,
            this.mainMenuEditNew,
            this.toolStripSeparator6,
            this.mainMenuEditExit});
			this.mainMenuGrf.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuGrf.Image")));
			this.mainMenuGrf.Name = "mainMenuGrf";
			this.mainMenuGrf.Size = new System.Drawing.Size(51, 20);
			this.mainMenuGrf.Text = "&Grf";
			// 
			// mainMenuEditOpen
			// 
			this.mainMenuEditOpen.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuEditOpen.Image")));
			this.mainMenuEditOpen.Name = "mainMenuEditOpen";
			this.mainMenuEditOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mainMenuEditOpen.Size = new System.Drawing.Size(154, 22);
			this.mainMenuEditOpen.Text = "&Open..";
			this.mainMenuEditOpen.Click += new System.EventHandler(this.mainMenuEditOpen_Click);
			// 
			// mainMenuEditSave
			// 
			this.mainMenuEditSave.Enabled = false;
			this.mainMenuEditSave.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuEditSave.Image")));
			this.mainMenuEditSave.Name = "mainMenuEditSave";
			this.mainMenuEditSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mainMenuEditSave.Size = new System.Drawing.Size(154, 22);
			this.mainMenuEditSave.Text = "&Save";
			this.mainMenuEditSave.Click += new System.EventHandler(this.mainMenuEditSave_Click);
			// 
			// mainMenuEditSaveAs
			// 
			this.mainMenuEditSaveAs.Enabled = false;
			this.mainMenuEditSaveAs.Name = "mainMenuEditSaveAs";
			this.mainMenuEditSaveAs.Size = new System.Drawing.Size(154, 22);
			this.mainMenuEditSaveAs.Text = "Save As..";
			this.mainMenuEditSaveAs.Click += new System.EventHandler(this.mainMenuEditSaveAs_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
			// 
			// mainMenuEditNew
			// 
			this.mainMenuEditNew.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuEditNew.Image")));
			this.mainMenuEditNew.Name = "mainMenuEditNew";
			this.mainMenuEditNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.mainMenuEditNew.Size = new System.Drawing.Size(154, 22);
			this.mainMenuEditNew.Text = "&New..";
			this.mainMenuEditNew.Click += new System.EventHandler(this.mainMenuEditNew_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(151, 6);
			// 
			// mainMenuEditExit
			// 
			this.mainMenuEditExit.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuEditExit.Image")));
			this.mainMenuEditExit.Name = "mainMenuEditExit";
			this.mainMenuEditExit.Size = new System.Drawing.Size(154, 22);
			this.mainMenuEditExit.Text = "Exit";
			this.mainMenuEditExit.Click += new System.EventHandler(this.mainMenuEditExit_Click);
			// 
			// menuMainSettings
			// 
			this.menuMainSettings.Image = ((System.Drawing.Image)(resources.GetObject("menuMainSettings.Image")));
			this.menuMainSettings.Name = "menuMainSettings";
			this.menuMainSettings.Size = new System.Drawing.Size(83, 20);
			this.menuMainSettings.Text = "&Settings..";
			this.menuMainSettings.Click += new System.EventHandler(this.mainMenuSettings_Click);
			// 
			// mainMenuPlugins
			// 
			this.mainMenuPlugins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuPluginsSeperator,
            this.mainMenuPluginsReload});
			this.mainMenuPlugins.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuPlugins.Image")));
			this.mainMenuPlugins.Name = "mainMenuPlugins";
			this.mainMenuPlugins.Size = new System.Drawing.Size(74, 20);
			this.mainMenuPlugins.Text = "Plugins";
			// 
			// mainMenuPluginsSeperator
			// 
			this.mainMenuPluginsSeperator.Name = "mainMenuPluginsSeperator";
			this.mainMenuPluginsSeperator.Size = new System.Drawing.Size(149, 6);
			// 
			// mainMenuPluginsReload
			// 
			this.mainMenuPluginsReload.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuPluginsReload.Image")));
			this.mainMenuPluginsReload.Name = "mainMenuPluginsReload";
			this.mainMenuPluginsReload.Size = new System.Drawing.Size(152, 22);
			this.mainMenuPluginsReload.Text = "Reload plugins";
			this.mainMenuPluginsReload.Click += new System.EventHandler(this.mainMenuPluginsReload_Click);
			// 
			// mainMenuAbout
			// 
			this.mainMenuAbout.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuAbout.Image")));
			this.mainMenuAbout.Name = "mainMenuAbout";
			this.mainMenuAbout.Size = new System.Drawing.Size(74, 20);
			this.mainMenuAbout.Text = "&About..";
			this.mainMenuAbout.Click += new System.EventHandler(this.mainMenuAbout_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlPreview);
			this.pnlMain.Controls.Add(this.splitterFilesPreview);
			this.pnlMain.Controls.Add(this.pnlFiles);
			this.pnlMain.Controls.Add(this.pnlSearch);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 24);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(1029, 422);
			this.pnlMain.TabIndex = 8;
			// 
			// pnlPreview
			// 
			this.pnlPreview.Controls.Add(this.previewImage);
			this.pnlPreview.Controls.Add(this.previewText);
			this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPreview.Location = new System.Drawing.Point(692, 30);
			this.pnlPreview.Name = "pnlPreview";
			this.pnlPreview.Size = new System.Drawing.Size(337, 392);
			this.pnlPreview.TabIndex = 6;
			// 
			// previewImage
			// 
			this.previewImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.previewImage.Location = new System.Drawing.Point(0, 0);
			this.previewImage.Name = "previewImage";
			this.previewImage.Size = new System.Drawing.Size(337, 392);
			this.previewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.previewImage.TabIndex = 1;
			this.previewImage.TabStop = false;
			this.previewImage.Visible = false;
			// 
			// previewText
			// 
			this.previewText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.previewText.Location = new System.Drawing.Point(0, 0);
			this.previewText.Name = "previewText";
			this.previewText.ReadOnly = true;
			this.previewText.Size = new System.Drawing.Size(337, 392);
			this.previewText.TabIndex = 0;
			this.previewText.Text = "";
			this.previewText.Visible = false;
			// 
			// splitterFilesPreview
			// 
			this.splitterFilesPreview.Location = new System.Drawing.Point(682, 30);
			this.splitterFilesPreview.Name = "splitterFilesPreview";
			this.splitterFilesPreview.Size = new System.Drawing.Size(10, 392);
			this.splitterFilesPreview.TabIndex = 7;
			this.splitterFilesPreview.TabStop = false;
			// 
			// pnlFiles
			// 
			this.pnlFiles.Controls.Add(this.listView);
			this.pnlFiles.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlFiles.Location = new System.Drawing.Point(0, 30);
			this.pnlFiles.Name = "pnlFiles";
			this.pnlFiles.Size = new System.Drawing.Size(682, 392);
			this.pnlFiles.TabIndex = 4;
			// 
			// listView
			// 
			this.listView.AlternateRowBackColor = System.Drawing.Color.Lavender;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNum,
            this.colName,
            this.colDataSize,
            this.colDataSizeExtracted,
            this.colOffset});
			this.listView.ContextMenuStrip = this.listViewContext;
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.EmptyListMsg = "No Items in the GRF";
			this.listView.EmptyListMsgFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HideSelection = false;
			this.listView.HighlightBackgroundColor = System.Drawing.Color.Tan;
			this.listView.HighlightForegroundColor = System.Drawing.Color.Black;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.Name = "listView";
			this.listView.ShowGroups = false;
			this.listView.Size = new System.Drawing.Size(682, 392);
			this.listView.SmallImageList = this.imagesDataTypes;
			this.listView.TabIndex = 6;
			this.listView.UseAlternatingBackColors = true;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.UseCustomSelectionColors = true;
			this.listView.UseFiltering = true;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.VirtualMode = true;
			this.listView.SelectionChanged += new System.EventHandler(this.listView_SelectionChanged);
			this.listView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView_KeyPress);
			// 
			// colNum
			// 
			this.colNum.AspectName = "Index";
			this.colNum.IsEditable = false;
			this.colNum.Text = "#";
			this.colNum.Width = 56;
			// 
			// colName
			// 
			this.colName.AspectName = "Filepath";
			this.colName.IsEditable = false;
			this.colName.Text = "Filepath";
			this.colName.Width = 385;
			// 
			// colDataSize
			// 
			this.colDataSize.AspectName = "LengthCompressed";
			this.colDataSize.IsEditable = false;
			this.colDataSize.Text = "Size";
			// 
			// colDataSizeExtracted
			// 
			this.colDataSizeExtracted.AspectName = "LengthUncompressed";
			this.colDataSizeExtracted.IsEditable = false;
			this.colDataSizeExtracted.Text = "Size (Extracted)";
			this.colDataSizeExtracted.Width = 86;
			// 
			// colOffset
			// 
			this.colOffset.AspectName = "Offset";
			this.colOffset.IsEditable = false;
			this.colOffset.Text = "Offset";
			this.colOffset.Width = 86;
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.label3);
			this.pnlSearch.Controls.Add(this.txtEn2Korea);
			this.pnlSearch.Controls.Add(this.label2);
			this.pnlSearch.Controls.Add(this.txtID2Name);
			this.pnlSearch.Controls.Add(this.label1);
			this.pnlSearch.Controls.Add(this.txtFilterText);
			this.pnlSearch.Controls.Add(this.btnFilter);
			this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlSearch.Location = new System.Drawing.Point(0, 0);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(1029, 30);
			this.pnlSearch.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(719, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Item search";
			// 
			// txtEn2Korea
			// 
			this.txtEn2Korea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEn2Korea.Location = new System.Drawing.Point(858, 4);
			this.txtEn2Korea.Name = "txtEn2Korea";
			this.txtEn2Korea.ReadOnly = true;
			this.txtEn2Korea.Size = new System.Drawing.Size(77, 20);
			this.txtEn2Korea.TabIndex = 2;
			this.txtEn2Korea.TextChanged += new System.EventHandler(this.txtEn2Korea_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(817, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Name";
			// 
			// txtID2Name
			// 
			this.txtID2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtID2Name.Location = new System.Drawing.Point(965, 4);
			this.txtID2Name.Name = "txtID2Name";
			this.txtID2Name.ReadOnly = true;
			this.txtID2Name.Size = new System.Drawing.Size(52, 20);
			this.txtID2Name.TabIndex = 3;
			this.txtID2Name.TextChanged += new System.EventHandler(this.txtID2Name_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(941, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(18, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "ID";
			// 
			// btnFilter
			// 
			this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFilter.Enabled = false;
			this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnFilter.ImageIndex = 12;
			this.btnFilter.ImageList = this.imagesGeneralSmall;
			this.btnFilter.Location = new System.Drawing.Point(609, 3);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(73, 21);
			this.btnFilter.TabIndex = 1;
			this.btnFilter.Text = "Filter files";
			this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// FrmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1029, 468);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FrmMain";
			this.Text = "Gravity Ressource File Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
			this.listViewContext.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.pnlPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
			this.pnlFiles.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtFilterText;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ContextMenuStrip listViewContext;
		private System.Windows.Forms.ToolStripMenuItem listViewContextExtract;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusPlaceholder;
		private System.Windows.Forms.ToolStripProgressBar lblStatusProgress;
		private System.Windows.Forms.ToolStripMenuItem mainMenuGrf;
		private System.Windows.Forms.ToolStripMenuItem mainMenuEditOpen;
		private System.Windows.Forms.ToolStripMenuItem mainMenuEditSave;
		private System.Windows.Forms.ImageList imagesDataTypes;
		private System.Windows.Forms.ImageList imagesGeneralSmall;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Panel pnlSearch;
		private System.Windows.Forms.Panel pnlPreview;
		private System.Windows.Forms.Splitter splitterFilesPreview;
		private System.Windows.Forms.Panel pnlFiles;
		private System.Windows.Forms.PictureBox previewImage;
		private System.Windows.Forms.RichTextBox previewText;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private GodLesZ.Library.Controls.FastObjectListView listView;
		private GodLesZ.Library.Controls.OLVColumn colNum;
		private GodLesZ.Library.Controls.OLVColumn colName;
		private GodLesZ.Library.Controls.OLVColumn colDataSize;
		private GodLesZ.Library.Controls.OLVColumn colDataSizeExtracted;
		private GodLesZ.Library.Controls.OLVColumn colOffset;
		private System.Windows.Forms.ToolStripMenuItem listViewContextCopyPath;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TextBox txtID2Name;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEn2Korea;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripStatusLabel lblGrfInfo;
		private System.Windows.Forms.ToolStripMenuItem listViewContextExtractAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem listViewContextFileAdd;
		private System.Windows.Forms.ToolStripMenuItem listViewContextFolderAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem listViewContextFileRemove;
		private System.Windows.Forms.ToolStripMenuItem listViewContextFolderRemove;
		private System.Windows.Forms.ToolStripMenuItem mainMenuEditNew;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem mainMenuAbout;
		private System.Windows.Forms.ToolStripMenuItem menuMainSettings;
		private System.Windows.Forms.ToolStripMenuItem mainMenuEditExit;
		private System.Windows.Forms.ToolStripMenuItem mainMenuPlugins;
		private System.Windows.Forms.ToolStripSeparator mainMenuPluginsSeperator;
		private System.Windows.Forms.ToolStripMenuItem mainMenuPluginsReload;
		private System.Windows.Forms.ToolStripMenuItem mainMenuEditSaveAs;
		private System.Windows.Forms.Label label3;
	}
}

