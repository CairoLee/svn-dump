namespace GodLesZ.SiedlerOnline.TradeListener {
	partial class frmMain {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuMainProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainProgramTest = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMainProgramExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainSettingsNetwork = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainSettingsLanguage = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMainSettingsPauseCapture = new System.Windows.Forms.ToolStripMenuItem();
			this.statusMain = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatusPackets = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatusTrades = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabPageTrades = new System.Windows.Forms.TabPage();
			this.listTrades = new GodLesZ.SiedlerOnline.TradeListener.Controls.TradeListView();
			this.tabPageChatGlobal = new System.Windows.Forms.TabPage();
			this.chatGlobal = new GodLesZ.SiedlerOnline.TradeListener.Controls.ChatListView();
			this.tabPageChatHelp = new System.Windows.Forms.TabPage();
			this.chatHelp = new GodLesZ.SiedlerOnline.TradeListener.Controls.ChatListView();
			this.imagesTabControl = new System.Windows.Forms.ImageList(this.components);
			this.listFilter = new GodLesZ.Library.Controls.FastObjectListView();
			this.colFilterOffer = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.colFilterDemanded = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.colFilterPlayer = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.colFilterRatio = ((GodLesZ.Library.Controls.OLVColumn)(new GodLesZ.Library.Controls.OLVColumn()));
			this.btnFilterDelete = new System.Windows.Forms.Button();
			this.btnFilterAdd = new System.Windows.Forms.Button();
			this.cmbFilterProfile = new System.Windows.Forms.ComboBox();
			this.btnSaveFilterProfile = new System.Windows.Forms.Button();
			this.btnDeleteFilterProfile = new System.Windows.Forms.Button();
			this.menuMain.SuspendLayout();
			this.statusMain.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabPageTrades.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.listTrades)).BeginInit();
			this.tabPageChatGlobal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chatGlobal)).BeginInit();
			this.tabPageChatHelp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chatHelp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.listFilter)).BeginInit();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgram,
            this.menuMainSettings});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(848, 24);
			this.menuMain.TabIndex = 0;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuMainProgram
			// 
			this.menuMainProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgramTest,
            this.toolStripSeparator1,
            this.menuMainProgramExit});
			this.menuMainProgram.Name = "menuMainProgram";
			this.menuMainProgram.Size = new System.Drawing.Size(59, 20);
			this.menuMainProgram.Text = "Program";
			// 
			// menuMainProgramTest
			// 
			this.menuMainProgramTest.Name = "menuMainProgramTest";
			this.menuMainProgramTest.Size = new System.Drawing.Size(95, 22);
			this.menuMainProgramTest.Text = "Test";
			this.menuMainProgramTest.Click += new System.EventHandler(this.menuMainProgramTest_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(92, 6);
			// 
			// menuMainProgramExit
			// 
			this.menuMainProgramExit.Name = "menuMainProgramExit";
			this.menuMainProgramExit.Size = new System.Drawing.Size(95, 22);
			this.menuMainProgramExit.Text = "Exit";
			// 
			// menuMainSettings
			// 
			this.menuMainSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainSettingsNetwork,
            this.menuMainSettingsLanguage,
            this.toolStripSeparator2,
            this.menuMainSettingsPauseCapture});
			this.menuMainSettings.Name = "menuMainSettings";
			this.menuMainSettings.Size = new System.Drawing.Size(58, 20);
			this.menuMainSettings.Text = "Settings";
			this.menuMainSettings.Click += new System.EventHandler(this.menuMainSettings_Click);
			// 
			// menuMainSettingsNetwork
			// 
			this.menuMainSettingsNetwork.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.clients;
			this.menuMainSettingsNetwork.Name = "menuMainSettingsNetwork";
			this.menuMainSettingsNetwork.Size = new System.Drawing.Size(171, 22);
			this.menuMainSettingsNetwork.Text = "Network Settings..";
			this.menuMainSettingsNetwork.Click += new System.EventHandler(this.menuMainSettingsNetwork_Click);
			// 
			// menuMainSettingsLanguage
			// 
			this.menuMainSettingsLanguage.Name = "menuMainSettingsLanguage";
			this.menuMainSettingsLanguage.Size = new System.Drawing.Size(171, 22);
			this.menuMainSettingsLanguage.Text = "Language Settings..";
			this.menuMainSettingsLanguage.Click += new System.EventHandler(this.menuMainSettingsLanguage_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
			// 
			// menuMainSettingsPauseCapture
			// 
			this.menuMainSettingsPauseCapture.CheckOnClick = true;
			this.menuMainSettingsPauseCapture.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.gear_pause;
			this.menuMainSettingsPauseCapture.Name = "menuMainSettingsPauseCapture";
			this.menuMainSettingsPauseCapture.Size = new System.Drawing.Size(171, 22);
			this.menuMainSettingsPauseCapture.Text = "Pause Capture";
			this.menuMainSettingsPauseCapture.Click += new System.EventHandler(this.menuMainSettingsPauseCapture_Click);
			// 
			// statusMain
			// 
			this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatusPackets,
            this.lblStatusTrades});
			this.statusMain.Location = new System.Drawing.Point(0, 348);
			this.statusMain.Name = "statusMain";
			this.statusMain.Size = new System.Drawing.Size(848, 22);
			this.statusMain.TabIndex = 1;
			this.statusMain.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(653, 17);
			this.lblStatus.Spring = true;
			this.lblStatus.Text = "Loading..";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusPackets
			// 
			this.lblStatusPackets.AutoSize = false;
			this.lblStatusPackets.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.lblStatusPackets.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblStatusPackets.Name = "lblStatusPackets";
			this.lblStatusPackets.Size = new System.Drawing.Size(90, 17);
			this.lblStatusPackets.Text = "Packets: 0";
			this.lblStatusPackets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusTrades
			// 
			this.lblStatusTrades.AutoSize = false;
			this.lblStatusTrades.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.lblStatusTrades.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
			this.lblStatusTrades.Name = "lblStatusTrades";
			this.lblStatusTrades.Size = new System.Drawing.Size(90, 17);
			this.lblStatusTrades.Text = "Trades: 0";
			this.lblStatusTrades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabPageTrades);
			this.tabMain.Controls.Add(this.tabPageChatGlobal);
			this.tabMain.Controls.Add(this.tabPageChatHelp);
			this.tabMain.ImageList = this.imagesTabControl;
			this.tabMain.ItemSize = new System.Drawing.Size(26, 26);
			this.tabMain.Location = new System.Drawing.Point(303, 24);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(545, 324);
			this.tabMain.TabIndex = 2;
			this.tabMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabMain_Selected);
			// 
			// tabPageTrades
			// 
			this.tabPageTrades.Controls.Add(this.listTrades);
			this.tabPageTrades.ImageIndex = 0;
			this.tabPageTrades.Location = new System.Drawing.Point(4, 30);
			this.tabPageTrades.Name = "tabPageTrades";
			this.tabPageTrades.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTrades.Size = new System.Drawing.Size(537, 290);
			this.tabPageTrades.TabIndex = 0;
			this.tabPageTrades.Text = "Trade";
			this.tabPageTrades.UseVisualStyleBackColor = true;
			// 
			// listTrades
			// 
			this.listTrades.AlternateRowBackColor = System.Drawing.Color.Lavender;
			this.listTrades.BackColor = System.Drawing.SystemColors.Window;
			this.listTrades.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listTrades.EmptyListMsg = "No trades.";
			this.listTrades.EmptyListMsgFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listTrades.FullRowSelect = true;
			this.listTrades.GridLines = true;
			this.listTrades.HideSelection = false;
			this.listTrades.HighlightBackgroundColor = System.Drawing.Color.Tan;
			this.listTrades.HighlightForegroundColor = System.Drawing.Color.Black;
			this.listTrades.Location = new System.Drawing.Point(3, 3);
			this.listTrades.MultiSelect = false;
			this.listTrades.Name = "listTrades";
			this.listTrades.OwnerDraw = true;
			this.listTrades.PreserveSelectionOnChange = false;
			this.listTrades.RowHeight = 20;
			this.listTrades.ShowGroups = false;
			this.listTrades.ShowItemToolTips = true;
			this.listTrades.Size = new System.Drawing.Size(531, 284);
			this.listTrades.TabIndex = 0;
			this.listTrades.TradeFilterList = null;
			this.listTrades.UseAlternatingBackColors = true;
			this.listTrades.UseCellFormatEvents = true;
			this.listTrades.UseCompatibleStateImageBehavior = false;
			this.listTrades.UseCustomSelectionColors = true;
			this.listTrades.UseFiltering = true;
			this.listTrades.View = System.Windows.Forms.View.Details;
			this.listTrades.VirtualMode = true;
			this.listTrades.SelectedIndexChanged += new System.EventHandler(this.listTrades_SelectedIndexChanged);
			// 
			// tabPageChatGlobal
			// 
			this.tabPageChatGlobal.Controls.Add(this.chatGlobal);
			this.tabPageChatGlobal.ImageIndex = 3;
			this.tabPageChatGlobal.Location = new System.Drawing.Point(4, 30);
			this.tabPageChatGlobal.Name = "tabPageChatGlobal";
			this.tabPageChatGlobal.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageChatGlobal.Size = new System.Drawing.Size(537, 290);
			this.tabPageChatGlobal.TabIndex = 1;
			this.tabPageChatGlobal.Text = "Global Chat";
			this.tabPageChatGlobal.UseVisualStyleBackColor = true;
			// 
			// chatGlobal
			// 
			this.chatGlobal.AlternateRowBackColor = System.Drawing.Color.Lavender;
			this.chatGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chatGlobal.EmptyListMsg = "No messages.";
			this.chatGlobal.EmptyListMsgFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chatGlobal.FullRowSelect = true;
			this.chatGlobal.GridLines = true;
			this.chatGlobal.HideSelection = false;
			this.chatGlobal.HighlightBackgroundColor = System.Drawing.Color.Tan;
			this.chatGlobal.HighlightForegroundColor = System.Drawing.Color.Black;
			this.chatGlobal.Location = new System.Drawing.Point(3, 3);
			this.chatGlobal.MultiSelect = false;
			this.chatGlobal.Name = "chatGlobal";
			this.chatGlobal.OwnerDraw = true;
			this.chatGlobal.PreserveSelectionOnChange = false;
			this.chatGlobal.ShowGroups = false;
			this.chatGlobal.Size = new System.Drawing.Size(531, 284);
			this.chatGlobal.TabIndex = 0;
			this.chatGlobal.UseAlternatingBackColors = true;
			this.chatGlobal.UseCompatibleStateImageBehavior = false;
			this.chatGlobal.UseCustomSelectionColors = true;
			this.chatGlobal.UseFiltering = true;
			this.chatGlobal.View = System.Windows.Forms.View.Details;
			this.chatGlobal.VirtualMode = true;
			// 
			// tabPageChatHelp
			// 
			this.tabPageChatHelp.Controls.Add(this.chatHelp);
			this.tabPageChatHelp.ImageIndex = 3;
			this.tabPageChatHelp.Location = new System.Drawing.Point(4, 30);
			this.tabPageChatHelp.Name = "tabPageChatHelp";
			this.tabPageChatHelp.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageChatHelp.Size = new System.Drawing.Size(537, 290);
			this.tabPageChatHelp.TabIndex = 2;
			this.tabPageChatHelp.Text = "Help Chat";
			this.tabPageChatHelp.UseVisualStyleBackColor = true;
			// 
			// chatHelp
			// 
			this.chatHelp.AlternateRowBackColor = System.Drawing.Color.Lavender;
			this.chatHelp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chatHelp.EmptyListMsg = "No messages.";
			this.chatHelp.EmptyListMsgFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chatHelp.FullRowSelect = true;
			this.chatHelp.GridLines = true;
			this.chatHelp.HideSelection = false;
			this.chatHelp.HighlightBackgroundColor = System.Drawing.Color.Tan;
			this.chatHelp.HighlightForegroundColor = System.Drawing.Color.Black;
			this.chatHelp.Location = new System.Drawing.Point(3, 3);
			this.chatHelp.MultiSelect = false;
			this.chatHelp.Name = "chatHelp";
			this.chatHelp.OwnerDraw = true;
			this.chatHelp.PreserveSelectionOnChange = false;
			this.chatHelp.ShowGroups = false;
			this.chatHelp.Size = new System.Drawing.Size(531, 284);
			this.chatHelp.TabIndex = 1;
			this.chatHelp.UseAlternatingBackColors = true;
			this.chatHelp.UseCompatibleStateImageBehavior = false;
			this.chatHelp.UseCustomSelectionColors = true;
			this.chatHelp.UseFiltering = true;
			this.chatHelp.View = System.Windows.Forms.View.Details;
			this.chatHelp.VirtualMode = true;
			// 
			// imagesTabControl
			// 
			this.imagesTabControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesTabControl.ImageStream")));
			this.imagesTabControl.TransparentColor = System.Drawing.Color.Transparent;
			this.imagesTabControl.Images.SetKeyName(0, "icon_diplomacy.png");
			this.imagesTabControl.Images.SetKeyName(1, "icon_diplomacy_gray.png");
			this.imagesTabControl.Images.SetKeyName(2, "icon_gui_active.png");
			this.imagesTabControl.Images.SetKeyName(3, "icon_gui_inactive.png");
			// 
			// listFilter
			// 
			this.listFilter.AllColumns.Add(this.colFilterOffer);
			this.listFilter.AllColumns.Add(this.colFilterDemanded);
			this.listFilter.AllColumns.Add(this.colFilterPlayer);
			this.listFilter.AllColumns.Add(this.colFilterRatio);
			this.listFilter.CheckBoxes = true;
			this.listFilter.CheckedAspectName = "IsActive";
			this.listFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFilterOffer,
            this.colFilterDemanded,
            this.colFilterPlayer,
            this.colFilterRatio});
			this.listFilter.EmptyListMsg = "No filter set.";
			this.listFilter.EmptyListMsgFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listFilter.FullRowSelect = true;
			this.listFilter.GridLines = true;
			this.listFilter.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listFilter.Location = new System.Drawing.Point(0, 57);
			this.listFilter.Name = "listFilter";
			this.listFilter.RowHeight = 20;
			this.listFilter.ShowGroups = false;
			this.listFilter.ShowImagesOnSubItems = true;
			this.listFilter.Size = new System.Drawing.Size(297, 284);
			this.listFilter.TabIndex = 0;
			this.listFilter.UseCompatibleStateImageBehavior = false;
			this.listFilter.View = System.Windows.Forms.View.Details;
			this.listFilter.VirtualMode = true;
			this.listFilter.SelectionChanged += new System.EventHandler(this.listFilter_SelectionChanged);
			this.listFilter.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listFilter_ItemChecked);
			// 
			// colFilterOffer
			// 
			this.colFilterOffer.Text = "Offer";
			this.colFilterOffer.Width = 70;
			// 
			// colFilterDemanded
			// 
			this.colFilterDemanded.Text = "Demanded";
			this.colFilterDemanded.Width = 70;
			// 
			// colFilterPlayer
			// 
			this.colFilterPlayer.Text = "Player";
			this.colFilterPlayer.Width = 90;
			// 
			// colFilterRatio
			// 
			this.colFilterRatio.Text = "Ratio";
			this.colFilterRatio.Width = 40;
			// 
			// btnFilterDelete
			// 
			this.btnFilterDelete.Enabled = false;
			this.btnFilterDelete.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.delete;
			this.btnFilterDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnFilterDelete.Location = new System.Drawing.Point(247, 30);
			this.btnFilterDelete.Name = "btnFilterDelete";
			this.btnFilterDelete.Size = new System.Drawing.Size(50, 21);
			this.btnFilterDelete.TabIndex = 4;
			this.btnFilterDelete.Text = "Del";
			this.btnFilterDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFilterDelete.UseVisualStyleBackColor = true;
			this.btnFilterDelete.Click += new System.EventHandler(this.btnFilterDelete_Click);
			// 
			// btnFilterAdd
			// 
			this.btnFilterAdd.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.add;
			this.btnFilterAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnFilterAdd.Location = new System.Drawing.Point(191, 30);
			this.btnFilterAdd.Name = "btnFilterAdd";
			this.btnFilterAdd.Size = new System.Drawing.Size(50, 21);
			this.btnFilterAdd.TabIndex = 3;
			this.btnFilterAdd.Text = "Add";
			this.btnFilterAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFilterAdd.UseVisualStyleBackColor = true;
			this.btnFilterAdd.Click += new System.EventHandler(this.btnFilterAdd_Click);
			// 
			// cmbFilterProfile
			// 
			this.cmbFilterProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFilterProfile.FormattingEnabled = true;
			this.cmbFilterProfile.Location = new System.Drawing.Point(0, 30);
			this.cmbFilterProfile.Name = "cmbFilterProfile";
			this.cmbFilterProfile.Size = new System.Drawing.Size(95, 21);
			this.cmbFilterProfile.TabIndex = 5;
			this.cmbFilterProfile.SelectedIndexChanged += new System.EventHandler(this.cmbFilterProfile_SelectedIndexChanged);
			// 
			// btnSaveFilterProfile
			// 
			this.btnSaveFilterProfile.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.save_as;
			this.btnSaveFilterProfile.Location = new System.Drawing.Point(101, 30);
			this.btnSaveFilterProfile.Name = "btnSaveFilterProfile";
			this.btnSaveFilterProfile.Size = new System.Drawing.Size(21, 21);
			this.btnSaveFilterProfile.TabIndex = 6;
			this.btnSaveFilterProfile.UseVisualStyleBackColor = true;
			this.btnSaveFilterProfile.Click += new System.EventHandler(this.btnSaveFilterProfile_Click);
			// 
			// btnDeleteFilterProfile
			// 
			this.btnDeleteFilterProfile.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.delete;
			this.btnDeleteFilterProfile.Location = new System.Drawing.Point(128, 30);
			this.btnDeleteFilterProfile.Name = "btnDeleteFilterProfile";
			this.btnDeleteFilterProfile.Size = new System.Drawing.Size(21, 21);
			this.btnDeleteFilterProfile.TabIndex = 7;
			this.btnDeleteFilterProfile.UseVisualStyleBackColor = true;
			this.btnDeleteFilterProfile.Click += new System.EventHandler(this.btnDeleteFilterProfile_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(848, 370);
			this.Controls.Add(this.btnDeleteFilterProfile);
			this.Controls.Add(this.btnSaveFilterProfile);
			this.Controls.Add(this.cmbFilterProfile);
			this.Controls.Add(this.btnFilterDelete);
			this.Controls.Add(this.btnFilterAdd);
			this.Controls.Add(this.listFilter);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.statusMain);
			this.Controls.Add(this.menuMain);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuMain;
			this.Name = "frmMain";
			this.Text = "DSO Trade Listener - by GodLesZ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.statusMain.ResumeLayout(false);
			this.statusMain.PerformLayout();
			this.tabMain.ResumeLayout(false);
			this.tabPageTrades.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.listTrades)).EndInit();
			this.tabPageChatGlobal.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chatGlobal)).EndInit();
			this.tabPageChatHelp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chatHelp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.listFilter)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgram;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgramExit;
		private System.Windows.Forms.ToolStripMenuItem menuMainSettings;
		private System.Windows.Forms.ToolStripMenuItem menuMainSettingsNetwork;
		private System.Windows.Forms.StatusStrip statusMain;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabPageTrades;
		private System.Windows.Forms.TabPage tabPageChatGlobal;
		private System.Windows.Forms.TabPage tabPageChatHelp;
		private Controls.ChatListView chatGlobal;
		private Controls.ChatListView chatHelp;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private Controls.TradeListView listTrades;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgramTest;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ImageList imagesTabControl;
		private System.Windows.Forms.ToolStripMenuItem menuMainSettingsLanguage;
		private GodLesZ.Library.Controls.FastObjectListView listFilter;
		private GodLesZ.Library.Controls.OLVColumn colFilterOffer;
		private GodLesZ.Library.Controls.OLVColumn colFilterDemanded;
		private GodLesZ.Library.Controls.OLVColumn colFilterPlayer;
		private GodLesZ.Library.Controls.OLVColumn colFilterRatio;
		private System.Windows.Forms.Button btnFilterAdd;
		private System.Windows.Forms.Button btnFilterDelete;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusPackets;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusTrades;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuMainSettingsPauseCapture;
		private System.Windows.Forms.ComboBox cmbFilterProfile;
		private System.Windows.Forms.Button btnSaveFilterProfile;
		private System.Windows.Forms.Button btnDeleteFilterProfile;
	}
}

