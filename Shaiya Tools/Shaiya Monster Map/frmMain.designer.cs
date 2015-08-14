namespace ShaiyaMonsterMap {
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
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.MenuProgramm = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgrammSave = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgrammReload = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgrammSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuProgrammLocalBackup = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgrammSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuProgrammExit = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingShowName = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingMarkedStandAlone = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.MainStatus = new System.Windows.Forms.StatusStrip();
			this.lblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.imageListPoints = new System.Windows.Forms.ImageList( this.components );
			this.tabMain = new System.Windows.Forms.TabControl();
			this.pageMap1 = new System.Windows.Forms.TabPage();
			this.mobMap1 = new ShaiyaMonsterMap.Components.MapControl();
			this.pageMap2 = new System.Windows.Forms.TabPage();
			this.mobMap2 = new ShaiyaMonsterMap.Components.MapControl();
			this.pageMap3 = new System.Windows.Forms.TabPage();
			this.mobMap3 = new ShaiyaMonsterMap.Components.MapControl();
			this.pageMap4 = new System.Windows.Forms.TabPage();
			this.mobMap4 = new ShaiyaMonsterMap.Components.MapControl();
			this.pageMapDungeon = new System.Windows.Forms.TabPage();
			this.mobMap5 = new ShaiyaMonsterMap.Components.MapControlSelector();
			this.pageMapPvP = new System.Windows.Forms.TabPage();
			this.mobMap6 = new ShaiyaMonsterMap.Components.MapControlSelector();
			this.pageSearch = new System.Windows.Forms.TabPage();
			this.listSearchResult = new System.Windows.Forms.ListView();
			this.colMobSearchName = new System.Windows.Forms.ColumnHeader();
			this.colMobSearchLevel = new System.Windows.Forms.ColumnHeader();
			this.colMobSearchElement = new System.Windows.Forms.ColumnHeader();
			this.colMobSearchCount = new System.Windows.Forms.ColumnHeader();
			this.colMobSearchMap = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.btnMobSearch = new System.Windows.Forms.Button();
			this.txtMobSearch = new System.Windows.Forms.TextBox();
			this.MainStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.btnFractionLight = new System.Windows.Forms.ToolStripButton();
			this.btnFractionDark = new System.Windows.Forms.ToolStripButton();
			this.MainMenu.SuspendLayout();
			this.MainStatus.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.pageMap1.SuspendLayout();
			this.pageMap2.SuspendLayout();
			this.pageMap3.SuspendLayout();
			this.pageMap4.SuspendLayout();
			this.pageMapDungeon.SuspendLayout();
			this.pageMapPvP.SuspendLayout();
			this.pageSearch.SuspendLayout();
			this.MainStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgramm,
            this.MenuSetting,
            this.MenuAbout} );
			this.MainMenu.Location = new System.Drawing.Point( 0, 0 );
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size( 841, 24 );
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "menuStrip1";
			// 
			// MenuProgramm
			// 
			this.MenuProgramm.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgrammSave,
            this.MenuProgrammReload,
            this.MenuProgrammSep1,
            this.MenuProgrammLocalBackup,
            this.MenuProgrammSep2,
            this.MenuProgrammExit} );
			this.MenuProgramm.Name = "MenuProgramm";
			this.MenuProgramm.Size = new System.Drawing.Size( 67, 20 );
			this.MenuProgramm.Text = "Programm";
			// 
			// MenuProgrammSave
			// 
			this.MenuProgrammSave.Name = "MenuProgrammSave";
			this.MenuProgrammSave.Size = new System.Drawing.Size( 187, 22 );
			this.MenuProgrammSave.Text = "Liste speichern";
			this.MenuProgrammSave.Click += new System.EventHandler( this.MenuProgrammSave_Click );
			// 
			// MenuProgrammReload
			// 
			this.MenuProgrammReload.Name = "MenuProgrammReload";
			this.MenuProgrammReload.Size = new System.Drawing.Size( 187, 22 );
			this.MenuProgrammReload.Text = "Liste neuladen";
			this.MenuProgrammReload.Click += new System.EventHandler( this.MenuProgrammReload_Click );
			// 
			// MenuProgrammSep1
			// 
			this.MenuProgrammSep1.Name = "MenuProgrammSep1";
			this.MenuProgrammSep1.Size = new System.Drawing.Size( 184, 6 );
			// 
			// MenuProgrammLocalBackup
			// 
			this.MenuProgrammLocalBackup.Name = "MenuProgrammLocalBackup";
			this.MenuProgrammLocalBackup.Size = new System.Drawing.Size( 187, 22 );
			this.MenuProgrammLocalBackup.Text = "lokales Backup erstellen";
			this.MenuProgrammLocalBackup.Click += new System.EventHandler( this.MenuProgrammLocalBackup_Click );
			// 
			// MenuProgrammSep2
			// 
			this.MenuProgrammSep2.Name = "MenuProgrammSep2";
			this.MenuProgrammSep2.Size = new System.Drawing.Size( 184, 6 );
			// 
			// MenuProgrammExit
			// 
			this.MenuProgrammExit.Name = "MenuProgrammExit";
			this.MenuProgrammExit.Size = new System.Drawing.Size( 187, 22 );
			this.MenuProgrammExit.Text = "Beenden";
			this.MenuProgrammExit.Click += new System.EventHandler( this.MenuProgrammExit_Click );
			// 
			// MenuSetting
			// 
			this.MenuSetting.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuSettingShowName,
            this.MenuSettingMarkedStandAlone} );
			this.MenuSetting.Name = "MenuSetting";
			this.MenuSetting.Size = new System.Drawing.Size( 82, 20 );
			this.MenuSetting.Text = "Einstellungen";
			// 
			// MenuSettingShowName
			// 
			this.MenuSettingShowName.Checked = global::ShaiyaMonsterMap.Properties.Settings.Default.ShowName;
			this.MenuSettingShowName.CheckOnClick = true;
			this.MenuSettingShowName.Name = "MenuSettingShowName";
			this.MenuSettingShowName.Size = new System.Drawing.Size( 223, 22 );
			this.MenuSettingShowName.Text = "Name über Punkt anzeigen";
			this.MenuSettingShowName.Click += new System.EventHandler( this.MenuSettingShowName_Click );
			// 
			// MenuSettingMarkedStandAlone
			// 
			this.MenuSettingMarkedStandAlone.Checked = global::ShaiyaMonsterMap.Properties.Settings.Default.MarkedStandAlone;
			this.MenuSettingMarkedStandAlone.CheckOnClick = true;
			this.MenuSettingMarkedStandAlone.Name = "MenuSettingMarkedStandAlone";
			this.MenuSettingMarkedStandAlone.Size = new System.Drawing.Size( 223, 22 );
			this.MenuSettingMarkedStandAlone.Text = "Markierte Punkte \"stand-alone\"";
			this.MenuSettingMarkedStandAlone.Click += new System.EventHandler( this.MenuSettingMarkedStandAlone_Click );
			// 
			// MenuAbout
			// 
			this.MenuAbout.Name = "MenuAbout";
			this.MenuAbout.Size = new System.Drawing.Size( 48, 20 );
			this.MenuAbout.Text = "About";
			this.MenuAbout.Click += new System.EventHandler( this.MenuAbout_Click );
			// 
			// MainStatus
			// 
			this.MainStatus.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusText,
            this.lblStatus} );
			this.MainStatus.Location = new System.Drawing.Point( 0, 593 );
			this.MainStatus.Name = "MainStatus";
			this.MainStatus.Size = new System.Drawing.Size( 841, 22 );
			this.MainStatus.TabIndex = 1;
			this.MainStatus.Text = "statusStrip1";
			// 
			// lblStatusText
			// 
			this.lblStatusText.Name = "lblStatusText";
			this.lblStatusText.Size = new System.Drawing.Size( 42, 17 );
			this.lblStatusText.Text = "Status:";
			// 
			// lblStatus
			// 
			this.lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size( 39, 17 );
			this.lblStatus.Text = "Fertig!";
			// 
			// imageListPoints
			// 
			this.imageListPoints.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageListPoints.ImageStream" ) ) );
			this.imageListPoints.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListPoints.Images.SetKeyName( 0, "Mob1.png" );
			this.imageListPoints.Images.SetKeyName( 1, "Mob2.png" );
			this.imageListPoints.Images.SetKeyName( 2, "Mob3.png" );
			this.imageListPoints.Images.SetKeyName( 3, "Mob4.png" );
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add( this.pageMap1 );
			this.tabMain.Controls.Add( this.pageMap2 );
			this.tabMain.Controls.Add( this.pageMap3 );
			this.tabMain.Controls.Add( this.pageMap4 );
			this.tabMain.Controls.Add( this.pageMapDungeon );
			this.tabMain.Controls.Add( this.pageMapPvP );
			this.tabMain.Controls.Add( this.pageSearch );
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point( 0, 49 );
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size( 841, 544 );
			this.tabMain.TabIndex = 3;
			this.tabMain.SelectedIndexChanged += new System.EventHandler( this.tabMain_SelectedIndexChanged );
			// 
			// pageMap1
			// 
			this.pageMap1.Controls.Add( this.mobMap1 );
			this.pageMap1.Location = new System.Drawing.Point( 4, 22 );
			this.pageMap1.Name = "pageMap1";
			this.pageMap1.Size = new System.Drawing.Size( 833, 518 );
			this.pageMap1.TabIndex = 0;
			this.pageMap1.Text = "Map 1";
			this.pageMap1.UseVisualStyleBackColor = true;
			// 
			// mobMap1
			// 
			this.mobMap1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mobMap1.Location = new System.Drawing.Point( 0, 0 );
			this.mobMap1.Name = "mobMap1";
			this.mobMap1.Size = new System.Drawing.Size( 833, 518 );
			this.mobMap1.TabIndex = 0;
			// 
			// pageMap2
			// 
			this.pageMap2.Controls.Add( this.mobMap2 );
			this.pageMap2.Location = new System.Drawing.Point( 4, 22 );
			this.pageMap2.Name = "pageMap2";
			this.pageMap2.Size = new System.Drawing.Size( 833, 518 );
			this.pageMap2.TabIndex = 1;
			this.pageMap2.Text = "Map 2";
			this.pageMap2.UseVisualStyleBackColor = true;
			// 
			// mobMap2
			// 
			this.mobMap2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mobMap2.Location = new System.Drawing.Point( 0, 0 );
			this.mobMap2.Name = "mobMap2";
			this.mobMap2.Size = new System.Drawing.Size( 833, 518 );
			this.mobMap2.TabIndex = 0;
			// 
			// pageMap3
			// 
			this.pageMap3.Controls.Add( this.mobMap3 );
			this.pageMap3.Location = new System.Drawing.Point( 4, 22 );
			this.pageMap3.Name = "pageMap3";
			this.pageMap3.Size = new System.Drawing.Size( 833, 518 );
			this.pageMap3.TabIndex = 2;
			this.pageMap3.Text = "Map 3";
			this.pageMap3.UseVisualStyleBackColor = true;
			// 
			// mobMap3
			// 
			this.mobMap3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mobMap3.Location = new System.Drawing.Point( 0, 0 );
			this.mobMap3.Name = "mobMap3";
			this.mobMap3.Size = new System.Drawing.Size( 833, 518 );
			this.mobMap3.TabIndex = 0;
			// 
			// pageMap4
			// 
			this.pageMap4.Controls.Add( this.mobMap4 );
			this.pageMap4.Location = new System.Drawing.Point( 4, 22 );
			this.pageMap4.Name = "pageMap4";
			this.pageMap4.Size = new System.Drawing.Size( 833, 518 );
			this.pageMap4.TabIndex = 3;
			this.pageMap4.Text = "Map 4";
			this.pageMap4.UseVisualStyleBackColor = true;
			// 
			// mobMap4
			// 
			this.mobMap4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mobMap4.Location = new System.Drawing.Point( 0, 0 );
			this.mobMap4.Name = "mobMap4";
			this.mobMap4.Size = new System.Drawing.Size( 833, 518 );
			this.mobMap4.TabIndex = 0;
			// 
			// pageMapDungeon
			// 
			this.pageMapDungeon.Controls.Add( this.mobMap5 );
			this.pageMapDungeon.Location = new System.Drawing.Point( 4, 22 );
			this.pageMapDungeon.Name = "pageMapDungeon";
			this.pageMapDungeon.Size = new System.Drawing.Size( 833, 518 );
			this.pageMapDungeon.TabIndex = 4;
			this.pageMapDungeon.Text = "Dungeons";
			this.pageMapDungeon.UseVisualStyleBackColor = true;
			// 
			// mobMap5
			// 
			this.mobMap5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mobMap5.Location = new System.Drawing.Point( 0, 0 );
			this.mobMap5.Name = "mobMap5";
			this.mobMap5.Size = new System.Drawing.Size( 833, 518 );
			this.mobMap5.TabIndex = 0;
			// 
			// pageMapPvP
			// 
			this.pageMapPvP.Controls.Add( this.mobMap6 );
			this.pageMapPvP.Location = new System.Drawing.Point( 4, 22 );
			this.pageMapPvP.Name = "pageMapPvP";
			this.pageMapPvP.Size = new System.Drawing.Size( 833, 518 );
			this.pageMapPvP.TabIndex = 5;
			this.pageMapPvP.Text = "PvP Maps";
			this.pageMapPvP.UseVisualStyleBackColor = true;
			// 
			// mobMap6
			// 
			this.mobMap6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mobMap6.Location = new System.Drawing.Point( 0, 0 );
			this.mobMap6.Name = "mobMap6";
			this.mobMap6.Size = new System.Drawing.Size( 833, 518 );
			this.mobMap6.TabIndex = 0;
			// 
			// pageSearch
			// 
			this.pageSearch.Controls.Add( this.listSearchResult );
			this.pageSearch.Controls.Add( this.label1 );
			this.pageSearch.Controls.Add( this.btnMobSearch );
			this.pageSearch.Controls.Add( this.txtMobSearch );
			this.pageSearch.Location = new System.Drawing.Point( 4, 22 );
			this.pageSearch.Name = "pageSearch";
			this.pageSearch.Padding = new System.Windows.Forms.Padding( 3 );
			this.pageSearch.Size = new System.Drawing.Size( 833, 518 );
			this.pageSearch.TabIndex = 6;
			this.pageSearch.Text = "Monster Suche";
			this.pageSearch.UseVisualStyleBackColor = true;
			// 
			// listSearchResult
			// 
			this.listSearchResult.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listSearchResult.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.listSearchResult.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.colMobSearchName,
            this.colMobSearchLevel,
            this.colMobSearchElement,
            this.colMobSearchCount,
            this.colMobSearchMap} );
			this.listSearchResult.FullRowSelect = true;
			this.listSearchResult.GridLines = true;
			this.listSearchResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listSearchResult.HideSelection = false;
			this.listSearchResult.Location = new System.Drawing.Point( 9, 55 );
			this.listSearchResult.Name = "listSearchResult";
			this.listSearchResult.OwnerDraw = true;
			this.listSearchResult.Size = new System.Drawing.Size( 816, 457 );
			this.listSearchResult.TabIndex = 3;
			this.listSearchResult.UseCompatibleStateImageBehavior = false;
			this.listSearchResult.View = System.Windows.Forms.View.Details;
			this.listSearchResult.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler( this.listSearchResult_DrawColumnHeader );
			this.listSearchResult.DoubleClick += new System.EventHandler( this.listSearchResult_DoubleClick );
			this.listSearchResult.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler( this.listSearchResult_DrawSubItem );
			// 
			// colMobSearchName
			// 
			this.colMobSearchName.Text = "Monstername";
			this.colMobSearchName.Width = 172;
			// 
			// colMobSearchLevel
			// 
			this.colMobSearchLevel.Text = "Level";
			// 
			// colMobSearchElement
			// 
			this.colMobSearchElement.Text = "Element";
			this.colMobSearchElement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colMobSearchElement.Width = 50;
			// 
			// colMobSearchCount
			// 
			this.colMobSearchCount.Text = "Anzahl";
			// 
			// colMobSearchMap
			// 
			this.colMobSearchMap.Text = "Map";
			this.colMobSearchMap.Width = 136;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 5, 12 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 71, 13 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Monstername";
			// 
			// btnMobSearch
			// 
			this.btnMobSearch.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnMobSearch.Location = new System.Drawing.Point( 172, 28 );
			this.btnMobSearch.Name = "btnMobSearch";
			this.btnMobSearch.Size = new System.Drawing.Size( 52, 20 );
			this.btnMobSearch.TabIndex = 1;
			this.btnMobSearch.Text = "Suchen";
			this.btnMobSearch.UseVisualStyleBackColor = true;
			this.btnMobSearch.Click += new System.EventHandler( this.btnMobSearch_Click );
			// 
			// txtMobSearch
			// 
			this.txtMobSearch.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtMobSearch.Location = new System.Drawing.Point( 8, 28 );
			this.txtMobSearch.Name = "txtMobSearch";
			this.txtMobSearch.Size = new System.Drawing.Size( 158, 20 );
			this.txtMobSearch.TabIndex = 0;
			// 
			// MainStrip
			// 
			this.MainStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnFractionLight,
            this.btnFractionDark} );
			this.MainStrip.Location = new System.Drawing.Point( 0, 24 );
			this.MainStrip.Name = "MainStrip";
			this.MainStrip.Size = new System.Drawing.Size( 841, 25 );
			this.MainStrip.TabIndex = 4;
			this.MainStrip.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size( 50, 22 );
			this.toolStripLabel1.Text = "Fraktion:";
			// 
			// btnFractionLight
			// 
			this.btnFractionLight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFractionLight.Image = global::ShaiyaMonsterMap.Properties.Resources.faction_light;
			this.btnFractionLight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFractionLight.Name = "btnFractionLight";
			this.btnFractionLight.Size = new System.Drawing.Size( 23, 22 );
			this.btnFractionLight.Text = "Fraktion: Licht";
			this.btnFractionLight.Click += new System.EventHandler( this.btnFractionLight_Click );
			// 
			// btnFractionDark
			// 
			this.btnFractionDark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFractionDark.Image = global::ShaiyaMonsterMap.Properties.Resources.faction_dark;
			this.btnFractionDark.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFractionDark.Margin = new System.Windows.Forms.Padding( 5, 1, 0, 2 );
			this.btnFractionDark.Name = "btnFractionDark";
			this.btnFractionDark.Size = new System.Drawing.Size( 23, 22 );
			this.btnFractionDark.Text = "Fraktion: Zorn";
			this.btnFractionDark.Click += new System.EventHandler( this.btnFractionDark_Click );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 841, 615 );
			this.Controls.Add( this.tabMain );
			this.Controls.Add( this.MainStrip );
			this.Controls.Add( this.MainStatus );
			this.Controls.Add( this.MainMenu );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.KeyPreview = true;
			this.MainMenuStrip = this.MainMenu;
			this.Name = "frmMain";
			this.Text = "Shaiya Monster Map";
			this.Shown += new System.EventHandler( this.frmMain_Shown );
			this.KeyUp += new System.Windows.Forms.KeyEventHandler( this.frmMain_KeyUp );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmMain_FormClosing );
			this.MainMenu.ResumeLayout( false );
			this.MainMenu.PerformLayout();
			this.MainStatus.ResumeLayout( false );
			this.MainStatus.PerformLayout();
			this.tabMain.ResumeLayout( false );
			this.pageMap1.ResumeLayout( false );
			this.pageMap2.ResumeLayout( false );
			this.pageMap3.ResumeLayout( false );
			this.pageMap4.ResumeLayout( false );
			this.pageMapDungeon.ResumeLayout( false );
			this.pageMapPvP.ResumeLayout( false );
			this.pageSearch.ResumeLayout( false );
			this.pageSearch.PerformLayout();
			this.MainStrip.ResumeLayout( false );
			this.MainStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.StatusStrip MainStatus;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramm;
		private System.Windows.Forms.ToolStripMenuItem MenuProgrammSave;
		private System.Windows.Forms.ToolStripSeparator MenuProgrammSep1;
		private System.Windows.Forms.ToolStripMenuItem MenuProgrammExit;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage pageMap1;
		private System.Windows.Forms.ToolStripMenuItem MenuProgrammReload;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusText;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripMenuItem MenuSetting;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingShowName;
		private System.Windows.Forms.ToolStripMenuItem MenuProgrammLocalBackup;
		private System.Windows.Forms.ToolStripSeparator MenuProgrammSep2;
		private System.Windows.Forms.ImageList imageListPoints;
		private ShaiyaMonsterMap.Components.MapControl mobMap1;
		private System.Windows.Forms.TabPage pageMap2;
		private System.Windows.Forms.TabPage pageMap3;
		private System.Windows.Forms.TabPage pageMap4;
		private System.Windows.Forms.TabPage pageMapDungeon;
		private System.Windows.Forms.TabPage pageMapPvP;
		private System.Windows.Forms.ToolStrip MainStrip;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton btnFractionLight;
		private System.Windows.Forms.ToolStripButton btnFractionDark;
		private ShaiyaMonsterMap.Components.MapControl mobMap2;
		private ShaiyaMonsterMap.Components.MapControl mobMap3;
		private ShaiyaMonsterMap.Components.MapControl mobMap4;
		private ShaiyaMonsterMap.Components.MapControlSelector mobMap6;
		private ShaiyaMonsterMap.Components.MapControlSelector mobMap5;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingMarkedStandAlone;
		private System.Windows.Forms.ToolStripMenuItem MenuAbout;
		private System.Windows.Forms.TabPage pageSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnMobSearch;
		private System.Windows.Forms.TextBox txtMobSearch;
		private System.Windows.Forms.ListView listSearchResult;
		private System.Windows.Forms.ColumnHeader colMobSearchName;
		private System.Windows.Forms.ColumnHeader colMobSearchElement;
		private System.Windows.Forms.ColumnHeader colMobSearchLevel;
		private System.Windows.Forms.ColumnHeader colMobSearchMap;
		private System.Windows.Forms.ColumnHeader colMobSearchCount;
	}
}

