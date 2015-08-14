namespace eACGUI {
	partial class Core {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Core ) );
			this.barMainMenu = new DevComponents.DotNetBar.Bar();
			this.btnMenuProgram = new DevComponents.DotNetBar.ButtonItem();
			this.btnMenuProgramClose = new DevComponents.DotNetBar.ButtonItem();
			this.btnMenuSettings = new DevComponents.DotNetBar.ButtonItem();
			this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
			this.btnMenuEditPath = new DevComponents.DotNetBar.ButtonItem();
			this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
			this.chkSettingComments = new DevComponents.DotNetBar.CheckBoxItem();
			this.chkSettingBackup = new DevComponents.DotNetBar.CheckBoxItem();
			this.chkSettingSaveOnExit = new DevComponents.DotNetBar.CheckBoxItem();
			this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
			this.btnMenuGUICcBlue = new DevComponents.DotNetBar.ButtonItem();
			this.btnMenuGUICcSilver = new DevComponents.DotNetBar.ButtonItem();
			this.btnMenuGUICcBlack = new DevComponents.DotNetBar.ButtonItem();
			this.btnMenuGUICcCustom = new DevComponents.DotNetBar.ColorPickerDropDown();
			this.btnMenuExtras = new DevComponents.DotNetBar.ButtonItem();
			this.btnMenuRefresh = new DevComponents.DotNetBar.ButtonItem();
			this.btnMenuImport = new DevComponents.DotNetBar.ButtonItem();
			this.btnMenuExport = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
			this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
			this.comboSettingSearch = new DevComponents.DotNetBar.ComboBoxItem();
			this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
			this.btnAbout = new DevComponents.DotNetBar.ButtonItem();
			this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
			this.barStatus = new DevComponents.DotNetBar.Bar();
			this.lblStatus = new DevComponents.DotNetBar.LabelItem();
			this.panelControl = new DevComponents.DotNetBar.PanelEx();
			this.btnSave = new DevComponents.DotNetBar.ButtonX();
			this.btnClose = new DevComponents.DotNetBar.ButtonX();
			this.panelFilesList = new DevComponents.DotNetBar.PanelEx();
			this.FileTree = new System.Windows.Forms.TreeView();
			this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
			this.panelConfGrid = new DevComponents.DotNetBar.PanelEx();
			this.ConfGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
			this.ColSetting = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			( (System.ComponentModel.ISupportInitialize)( this.barMainMenu ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.barStatus ) ).BeginInit();
			this.panelControl.SuspendLayout();
			this.panelFilesList.SuspendLayout();
			this.panelConfGrid.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.ConfGrid ) ).BeginInit();
			this.SuspendLayout();
			// 
			// barMainMenu
			// 
			this.barMainMenu.AccessibleDescription = "GUI Main Menu";
			this.barMainMenu.AccessibleName = "Main Menu";
			this.barMainMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
			this.barMainMenu.ColorScheme.PredefinedColorScheme = DevComponents.DotNetBar.ePredefinedColorScheme.Blue2003;
			this.barMainMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.barMainMenu.Items.AddRange( new DevComponents.DotNetBar.BaseItem[] {
            this.btnMenuProgram,
            this.btnMenuSettings,
            this.btnMenuExtras,
            this.labelItem2,
            this.comboSettingSearch,
            this.labelItem1,
            this.btnAbout,
            this.labelItem3} );
			this.barMainMenu.Location = new System.Drawing.Point( 0, 0 );
			this.barMainMenu.Name = "barMainMenu";
			this.barMainMenu.Size = new System.Drawing.Size( 848, 26 );
			this.barMainMenu.Stretch = true;
			this.barMainMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.barMainMenu.TabIndex = 0;
			this.barMainMenu.TabStop = false;
			this.barMainMenu.Text = "bar1";
			// 
			// btnMenuProgram
			// 
			this.btnMenuProgram.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuProgram.ImagePaddingHorizontal = 8;
			this.btnMenuProgram.Name = "btnMenuProgram";
			this.btnMenuProgram.SubItems.AddRange( new DevComponents.DotNetBar.BaseItem[] {
            this.btnMenuProgramClose} );
			this.btnMenuProgram.Text = "Programm";
			// 
			// btnMenuProgramClose
			// 
			this.btnMenuProgramClose.BeginGroup = true;
			this.btnMenuProgramClose.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuProgramClose.ImagePaddingHorizontal = 8;
			this.btnMenuProgramClose.Name = "btnMenuProgramClose";
			this.btnMenuProgramClose.Text = "<font color=\"#BA1419\">Beenden</font>";
			this.btnMenuProgramClose.Click += new System.EventHandler( this.btnMenuProgramClose_Click );
			// 
			// btnMenuSettings
			// 
			this.btnMenuSettings.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuSettings.ImagePaddingHorizontal = 8;
			this.btnMenuSettings.Name = "btnMenuSettings";
			this.btnMenuSettings.SubItems.AddRange( new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem5,
            this.btnMenuEditPath,
            this.labelItem4,
            this.chkSettingComments,
            this.chkSettingBackup,
            this.chkSettingSaveOnExit,
            this.labelItem6,
            this.btnMenuGUICcBlue,
            this.btnMenuGUICcSilver,
            this.btnMenuGUICcBlack,
            this.btnMenuGUICcCustom} );
			this.btnMenuSettings.Text = "Einstellungen";
			// 
			// labelItem5
			// 
			this.labelItem5.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 221 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ), ( (int)( ( (byte)( 238 ) ) ) ) );
			this.labelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
			this.labelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.labelItem5.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ), ( (int)( ( (byte)( 110 ) ) ) ) );
			this.labelItem5.Name = "labelItem5";
			this.labelItem5.PaddingBottom = 1;
			this.labelItem5.PaddingLeft = 10;
			this.labelItem5.PaddingTop = 1;
			this.labelItem5.SingleLineColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 197 ) ) ) ), ( (int)( ( (byte)( 197 ) ) ) ), ( (int)( ( (byte)( 197 ) ) ) ) );
			this.labelItem5.Text = "Allgemeine Optionen";
			// 
			// btnMenuEditPath
			// 
			this.btnMenuEditPath.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuEditPath.ImagePaddingHorizontal = 8;
			this.btnMenuEditPath.Name = "btnMenuEditPath";
			this.btnMenuEditPath.Text = "Conf Pfad ändern";
			this.btnMenuEditPath.Click += new System.EventHandler( this.btnMenuEditPath_Click );
			// 
			// labelItem4
			// 
			this.labelItem4.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 221 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ), ( (int)( ( (byte)( 238 ) ) ) ) );
			this.labelItem4.BeginGroup = true;
			this.labelItem4.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
			this.labelItem4.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.labelItem4.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ), ( (int)( ( (byte)( 110 ) ) ) ) );
			this.labelItem4.Name = "labelItem4";
			this.labelItem4.PaddingBottom = 1;
			this.labelItem4.PaddingLeft = 10;
			this.labelItem4.PaddingTop = 1;
			this.labelItem4.SingleLineColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 197 ) ) ) ), ( (int)( ( (byte)( 197 ) ) ) ), ( (int)( ( (byte)( 197 ) ) ) ) );
			this.labelItem4.Text = "Anzeige Optionen";
			// 
			// chkSettingComments
			// 
			this.chkSettingComments.Checked = true;
			this.chkSettingComments.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSettingComments.Name = "chkSettingComments";
			this.chkSettingComments.Text = "Kommentare Anzeigen";
			this.chkSettingComments.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler( this.chkSettingComments_CheckedChanged );
			// 
			// chkSettingBackup
			// 
			this.chkSettingBackup.Checked = true;
			this.chkSettingBackup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSettingBackup.Name = "chkSettingBackup";
			this.chkSettingBackup.Text = "Backup beim Speichern";
			// 
			// chkSettingSaveOnExit
			// 
			this.chkSettingSaveOnExit.Name = "chkSettingSaveOnExit";
			this.chkSettingSaveOnExit.Text = "beim Beenden speichern";
			this.chkSettingSaveOnExit.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler( this.chkSettingSaveOnExit_CheckedChanged );
			// 
			// labelItem6
			// 
			this.labelItem6.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 221 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ), ( (int)( ( (byte)( 238 ) ) ) ) );
			this.labelItem6.BeginGroup = true;
			this.labelItem6.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
			this.labelItem6.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.labelItem6.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ), ( (int)( ( (byte)( 110 ) ) ) ) );
			this.labelItem6.Name = "labelItem6";
			this.labelItem6.PaddingBottom = 1;
			this.labelItem6.PaddingLeft = 10;
			this.labelItem6.PaddingTop = 1;
			this.labelItem6.SingleLineColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 197 ) ) ) ), ( (int)( ( (byte)( 197 ) ) ) ), ( (int)( ( (byte)( 197 ) ) ) ) );
			this.labelItem6.Text = "GUI Optionen";
			// 
			// btnMenuGUICcBlue
			// 
			this.btnMenuGUICcBlue.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuGUICcBlue.ImagePaddingHorizontal = 8;
			this.btnMenuGUICcBlue.Name = "btnMenuGUICcBlue";
			this.btnMenuGUICcBlue.Text = "GUI: Blau";
			this.btnMenuGUICcBlue.MouseLeave += new System.EventHandler( this.btnMenuGUICcBlue_MouseLeave );
			this.btnMenuGUICcBlue.MouseHover += new System.EventHandler( this.btnMenuGUICcBlue_MouseHover );
			this.btnMenuGUICcBlue.Click += new System.EventHandler( this.btnMenuGUICcBlue_Click );
			// 
			// btnMenuGUICcSilver
			// 
			this.btnMenuGUICcSilver.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuGUICcSilver.ImagePaddingHorizontal = 8;
			this.btnMenuGUICcSilver.Name = "btnMenuGUICcSilver";
			this.btnMenuGUICcSilver.Text = "GUI: Silber";
			this.btnMenuGUICcSilver.MouseLeave += new System.EventHandler( this.btnMenuGUICcSilver_MouseLeave );
			this.btnMenuGUICcSilver.MouseHover += new System.EventHandler( this.btnMenuGUICcSilver_MouseHover );
			this.btnMenuGUICcSilver.Click += new System.EventHandler( this.btnMenuGUICcSilver_Click );
			// 
			// btnMenuGUICcBlack
			// 
			this.btnMenuGUICcBlack.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuGUICcBlack.ImagePaddingHorizontal = 8;
			this.btnMenuGUICcBlack.Name = "btnMenuGUICcBlack";
			this.btnMenuGUICcBlack.Text = "GUI: Schwarz";
			this.btnMenuGUICcBlack.MouseLeave += new System.EventHandler( this.btnMenuGUICcBlack_MouseLeave );
			this.btnMenuGUICcBlack.MouseHover += new System.EventHandler( this.btnMenuGUICcBlack_MouseHover );
			this.btnMenuGUICcBlack.Click += new System.EventHandler( this.btnMenuGUICcBlack_Click );
			// 
			// btnMenuGUICcCustom
			// 
			this.btnMenuGUICcCustom.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuGUICcCustom.ImagePaddingHorizontal = 8;
			this.btnMenuGUICcCustom.Name = "btnMenuGUICcCustom";
			this.btnMenuGUICcCustom.Text = "GUI: Custom";
			this.btnMenuGUICcCustom.ColorPreview += new DevComponents.DotNetBar.ColorPreviewEventHandler( this.btnMenuGUICcCustom_ColorPreview );
			this.btnMenuGUICcCustom.SelectedColorChanged += new System.EventHandler( this.btnMenuGUICcCustom_SelectedColorChanged );
			this.btnMenuGUICcCustom.ExpandChange += new System.EventHandler( this.btnMenuGUICcCustom_ExpandChange );
			// 
			// btnMenuExtras
			// 
			this.btnMenuExtras.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuExtras.ImagePaddingHorizontal = 8;
			this.btnMenuExtras.Name = "btnMenuExtras";
			this.btnMenuExtras.SubItems.AddRange( new DevComponents.DotNetBar.BaseItem[] {
            this.btnMenuRefresh,
            this.btnMenuImport,
            this.btnMenuExport,
            this.buttonItem1} );
			this.btnMenuExtras.Text = "Extras";
			// 
			// btnMenuRefresh
			// 
			this.btnMenuRefresh.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuRefresh.ImagePaddingHorizontal = 8;
			this.btnMenuRefresh.Name = "btnMenuRefresh";
			this.btnMenuRefresh.Text = "Conf neu einlesn";
			this.btnMenuRefresh.Click += new System.EventHandler( this.btnMenuRefresh_Click );
			// 
			// btnMenuImport
			// 
			this.btnMenuImport.BeginGroup = true;
			this.btnMenuImport.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuImport.ImagePaddingHorizontal = 8;
			this.btnMenuImport.Name = "btnMenuImport";
			this.btnMenuImport.Text = "Conf XML Import";
			this.btnMenuImport.Click += new System.EventHandler( this.btnMenuImport_Click );
			// 
			// btnMenuExport
			// 
			this.btnMenuExport.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnMenuExport.ImagePaddingHorizontal = 8;
			this.btnMenuExport.Name = "btnMenuExport";
			this.btnMenuExport.Text = "Conf XML Export";
			this.btnMenuExport.Click += new System.EventHandler( this.btnMenuExport_Click );
			// 
			// buttonItem1
			// 
			this.buttonItem1.BeginGroup = true;
			this.buttonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.buttonItem1.ImagePaddingHorizontal = 8;
			this.buttonItem1.Name = "buttonItem1";
			this.buttonItem1.Text = "Conf Merge";
			this.buttonItem1.Click += new System.EventHandler( this.btnMenuMerge_Click );
			// 
			// labelItem2
			// 
			this.labelItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
			this.labelItem2.Name = "labelItem2";
			this.labelItem2.Text = "Suche";
			// 
			// comboSettingSearch
			// 
			this.comboSettingSearch.ComboWidth = 150;
			this.comboSettingSearch.DropDownHeight = 106;
			this.comboSettingSearch.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
			this.comboSettingSearch.Name = "comboSettingSearch";
			this.comboSettingSearch.SelectedIndexChanged += new System.EventHandler( this.comboSettingSearch_SelectedIndexChanged );
			// 
			// labelItem1
			// 
			this.labelItem1.Name = "labelItem1";
			this.labelItem1.PaddingLeft = 50;
			// 
			// btnAbout
			// 
			this.btnAbout.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet;
			this.btnAbout.ImagePaddingHorizontal = 8;
			this.btnAbout.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Text = "Über...";
			this.btnAbout.Click += new System.EventHandler( this.btnMenuAbout_Click );
			// 
			// labelItem3
			// 
			this.labelItem3.Name = "labelItem3";
			this.labelItem3.PaddingRight = 5;
			// 
			// barStatus
			// 
			this.barStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
			this.barStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barStatus.Items.AddRange( new DevComponents.DotNetBar.BaseItem[] {
            this.lblStatus} );
			this.barStatus.Location = new System.Drawing.Point( 0, 412 );
			this.barStatus.Name = "barStatus";
			this.barStatus.Size = new System.Drawing.Size( 848, 20 );
			this.barStatus.Stretch = true;
			this.barStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.barStatus.TabIndex = 7;
			this.barStatus.TabStop = false;
			this.barStatus.Text = "bar1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.PaddingLeft = 1;
			this.lblStatus.PaddingTop = 3;
			this.lblStatus.Text = "Ready...";
			// 
			// panelControl
			// 
			this.panelControl.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelControl.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelControl.Controls.Add( this.btnSave );
			this.panelControl.Controls.Add( this.btnClose );
			this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl.Location = new System.Drawing.Point( 0, 378 );
			this.panelControl.Name = "panelControl";
			this.panelControl.Size = new System.Drawing.Size( 848, 34 );
			this.panelControl.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelControl.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelControl.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelControl.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelControl.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelControl.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelControl.Style.GradientAngle = 90;
			this.panelControl.TabIndex = 8;
			// 
			// btnSave
			// 
			this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
			this.btnSave.FocusCuesEnabled = false;
			this.btnSave.Location = new System.Drawing.Point( 651, 5 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 75, 23 );
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Speichern";
			this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
			// 
			// btnClose
			// 
			this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
			this.btnClose.FocusCuesEnabled = false;
			this.btnClose.Location = new System.Drawing.Point( 761, 5 );
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size( 75, 23 );
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Beenden";
			this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
			// 
			// panelFilesList
			// 
			this.panelFilesList.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelFilesList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelFilesList.Controls.Add( this.FileTree );
			this.panelFilesList.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelFilesList.Location = new System.Drawing.Point( 0, 26 );
			this.panelFilesList.Name = "panelFilesList";
			this.panelFilesList.Size = new System.Drawing.Size( 200, 352 );
			this.panelFilesList.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelFilesList.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelFilesList.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelFilesList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelFilesList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelFilesList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelFilesList.Style.GradientAngle = 90;
			this.panelFilesList.TabIndex = 9;
			this.panelFilesList.Text = "panelEx2";
			// 
			// FileTree
			// 
			this.FileTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FileTree.Location = new System.Drawing.Point( 0, 0 );
			this.FileTree.Name = "FileTree";
			this.FileTree.Size = new System.Drawing.Size( 200, 352 );
			this.FileTree.TabIndex = 0;
			this.FileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.FileTree_AfterSelect );
			// 
			// expandableSplitter1
			// 
			this.expandableSplitter1.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
			this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandableSplitter1.ExpandFillColor = System.Drawing.SystemColors.ControlDarkDark;
			this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
			this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
			this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 251 ) ) ) ) );
			this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 163 ) ) ) ), ( (int)( ( (byte)( 209 ) ) ) ), ( (int)( ( (byte)( 254 ) ) ) ) );
			this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 234 ) ) ) ), ( (int)( ( (byte)( 244 ) ) ) ), ( (int)( ( (byte)( 254 ) ) ) ) );
			this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
			this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
			this.expandableSplitter1.HotExpandFillColor = System.Drawing.SystemColors.ControlDarkDark;
			this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
			this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.HotGripDarkColor = System.Drawing.SystemColors.ControlDarkDark;
			this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 251 ) ) ) ) );
			this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.expandableSplitter1.Location = new System.Drawing.Point( 200, 26 );
			this.expandableSplitter1.Name = "expandableSplitter1";
			this.expandableSplitter1.Size = new System.Drawing.Size( 10, 352 );
			this.expandableSplitter1.TabIndex = 10;
			this.expandableSplitter1.TabStop = false;
			// 
			// panelConfGrid
			// 
			this.panelConfGrid.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelConfGrid.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelConfGrid.Controls.Add( this.ConfGrid );
			this.panelConfGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelConfGrid.Location = new System.Drawing.Point( 210, 26 );
			this.panelConfGrid.Name = "panelConfGrid";
			this.panelConfGrid.Size = new System.Drawing.Size( 638, 352 );
			this.panelConfGrid.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelConfGrid.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelConfGrid.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelConfGrid.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelConfGrid.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelConfGrid.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelConfGrid.Style.GradientAngle = 90;
			this.panelConfGrid.TabIndex = 11;
			this.panelConfGrid.Text = "panelEx3";
			// 
			// ConfGrid
			// 
			this.ConfGrid.AllowUserToAddRows = false;
			this.ConfGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ConfGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ConfGrid.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSetting,
            this.ColValue} );
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.ConfGrid.DefaultCellStyle = dataGridViewCellStyle1;
			this.ConfGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConfGrid.GridColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 208 ) ) ) ), ( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 229 ) ) ) ) );
			this.ConfGrid.Location = new System.Drawing.Point( 0, 0 );
			this.ConfGrid.Name = "ConfGrid";
			this.ConfGrid.RowHeadersWidth = 25;
			this.ConfGrid.Size = new System.Drawing.Size( 638, 352 );
			this.ConfGrid.TabIndex = 0;
			this.ConfGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler( this.ConfGrid_UserAddedRow );
			this.ConfGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler( this.ConfGrid_UserDeletedRow );
			this.ConfGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler( this.ConfGrid_CellEndEdit );
			// 
			// ColSetting
			// 
			this.ColSetting.HeaderText = "Einstellung";
			this.ColSetting.Name = "ColSetting";
			this.ColSetting.Width = 300;
			// 
			// ColValue
			// 
			this.ColValue.HeaderText = "Wert";
			this.ColValue.Name = "ColValue";
			this.ColValue.Width = 300;
			// 
			// Core
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size( 848, 432 );
			this.Controls.Add( this.panelConfGrid );
			this.Controls.Add( this.expandableSplitter1 );
			this.Controls.Add( this.panelFilesList );
			this.Controls.Add( this.panelControl );
			this.Controls.Add( this.barStatus );
			this.Controls.Add( this.barMainMenu );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "Core";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "eAthena Config GUI";
			this.Load += new System.EventHandler( this.Core_Load );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.Core_FormClosing );
			( (System.ComponentModel.ISupportInitialize)( this.barMainMenu ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.barStatus ) ).EndInit();
			this.panelControl.ResumeLayout( false );
			this.panelFilesList.ResumeLayout( false );
			this.panelConfGrid.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.ConfGrid ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private DevComponents.DotNetBar.Bar barMainMenu;
		private DevComponents.DotNetBar.ButtonItem btnMenuGUICcBlue;
		private DevComponents.DotNetBar.ButtonItem btnMenuGUICcSilver;
		private DevComponents.DotNetBar.ButtonItem btnMenuGUICcBlack;
		private DevComponents.DotNetBar.ColorPickerDropDown btnMenuGUICcCustom;
		private DevComponents.DotNetBar.ButtonItem btnMenuProgram;
		private DevComponents.DotNetBar.ButtonItem btnMenuProgramClose;
		private DevComponents.DotNetBar.Bar barStatus;
		private DevComponents.DotNetBar.PanelEx panelControl;
		private DevComponents.DotNetBar.PanelEx panelFilesList;
		private System.Windows.Forms.TreeView FileTree;
		private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
		private DevComponents.DotNetBar.PanelEx panelConfGrid;
		private DevComponents.DotNetBar.Controls.DataGridViewX ConfGrid;
		private DevComponents.DotNetBar.ButtonX btnClose;
		private DevComponents.DotNetBar.ButtonX btnSave;
		private DevComponents.DotNetBar.ButtonItem btnMenuEditPath;
		private DevComponents.DotNetBar.LabelItem lblStatus;
		private DevComponents.DotNetBar.ButtonItem btnAbout;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColSetting;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
		private DevComponents.DotNetBar.ComboBoxItem comboSettingSearch;
		private DevComponents.DotNetBar.LabelItem labelItem2;
		private DevComponents.DotNetBar.LabelItem labelItem1;
		private DevComponents.DotNetBar.ButtonItem btnMenuSettings;
		private DevComponents.DotNetBar.CheckBoxItem chkSettingComments;
		private DevComponents.DotNetBar.LabelItem labelItem3;
		private DevComponents.DotNetBar.LabelItem labelItem5;
		private DevComponents.DotNetBar.LabelItem labelItem4;
		private DevComponents.DotNetBar.CheckBoxItem chkSettingSaveOnExit;
		private DevComponents.DotNetBar.LabelItem labelItem6;
		private DevComponents.DotNetBar.ButtonItem btnMenuExtras;
		private DevComponents.DotNetBar.ButtonItem btnMenuExport;
		private DevComponents.DotNetBar.ButtonItem buttonItem1;
		private DevComponents.DotNetBar.ButtonItem btnMenuImport;
		private DevComponents.DotNetBar.ButtonItem btnMenuRefresh;
		private DevComponents.DotNetBar.CheckBoxItem chkSettingBackup;


	}
}

