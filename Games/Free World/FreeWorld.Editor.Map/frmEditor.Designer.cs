using FreeWorld.Engine.Tools.XnaFake;

namespace FreeWorld.Editor.Map {
	partial class FrmEditor {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditor));
			this.MapHScrollBar = new System.Windows.Forms.HScrollBar();
			this.MapVScrollBar = new System.Windows.Forms.VScrollBar();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.MenuEditor = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuEditorNew = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuEditorOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuEditorSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuEditorExit = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingsOneTimeFill = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingsFillSameTexture = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuSettingsTransparentLayer = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuSettingsGridNonEmptyCells = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuExtras = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuExtrasMapPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuExtrasMapConvert = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.DrawpanelLayout = new System.Windows.Forms.TableLayoutPanel();
			this.RenderDisplayMap = new FreeWorld.Engine.Tools.XnaFake.TileDisplay();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.LayerStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.fileNewToolstrip = new System.Windows.Forms.ToolStripButton();
			this.fileOpenToolstrip = new System.Windows.Forms.ToolStripButton();
			this.fileSaveToolstrip = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuToolStripDrawNormalButton = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripDrawEraseButton = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripDrawFillButton = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripDrawRectangleButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuToolStripDrawRotateButton = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripDrawFlipButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuToolStripShowGridButton = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripShowAllLayersButton = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripShowCollisionLayer = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripShowFog = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuToolStripActionUndo = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripActionRedo = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.NavigationContainer = new System.Windows.Forms.SplitContainer();
			this.TextureTabControl = new System.Windows.Forms.TabControl();
			this.tabPageTilesets = new System.Windows.Forms.TabPage();
			this.tableLayoutTilesets = new System.Windows.Forms.TableLayoutPanel();
			this.TilesetHScrollBar = new System.Windows.Forms.HScrollBar();
			this.TilesetVScrollBar = new System.Windows.Forms.VScrollBar();
			this.RenderDisplayTexture = new FreeWorld.Engine.Tools.XnaFake.TileDisplay();
			this.comboTilesets = new System.Windows.Forms.ComboBox();
			this.tabPageAutotiles = new System.Windows.Forms.TabPage();
			this.tableLayoutAutotiles = new System.Windows.Forms.TableLayoutPanel();
			this.AutotilesVScrollBar = new System.Windows.Forms.VScrollBar();
			this.RenderDisplayAutotile = new FreeWorld.Engine.Tools.XnaFake.TileDisplay();
			this.comboAutotiles = new System.Windows.Forms.ComboBox();
			this.tabPageAnimations = new System.Windows.Forms.TabPage();
			this.tableLayoutAnimations = new System.Windows.Forms.TableLayoutPanel();
			this.AnimationsHScrollBar = new System.Windows.Forms.HScrollBar();
			this.AnimationsVScrollBar = new System.Windows.Forms.VScrollBar();
			this.RenderDisplayAnimations = new FreeWorld.Engine.Tools.XnaFake.TileDisplay();
			this.comboAnimations = new System.Windows.Forms.ComboBox();
			this.tabPageObjects = new System.Windows.Forms.TabPage();
			this.tableLayoutObjects = new System.Windows.Forms.TableLayoutPanel();
			this.ObjectsHScrollBar = new System.Windows.Forms.HScrollBar();
			this.ObjectsVScrollBar = new System.Windows.Forms.VScrollBar();
			this.RenderDisplayObjects = new FreeWorld.Engine.Tools.XnaFake.TileDisplay();
			this.comboObjects = new System.Windows.Forms.ComboBox();
			this.ProjectTree = new System.Windows.Forms.TreeView();
			this.ProjectTreeImageList = new System.Windows.Forms.ImageList(this.components);
			this.ProjectTreeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ProjectTreeContextAddLayer = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.ProjectTreeContextEditSize = new System.Windows.Forms.ToolStripMenuItem();
			this.ProjectTreeContextEditName = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.ProjectTreeContextEditFog = new System.Windows.Forms.ToolStripMenuItem();
			this.ProjectTreeNodeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ProjectTreeNodeContextRename = new System.Windows.Forms.ToolStripMenuItem();
			this.ProjectTreeNodeContextDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ProjectTreeNodeContextMoveUp = new System.Windows.Forms.ToolStripMenuItem();
			this.ProjectTreeNodeContextMoveDown = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.DrawpanelLayout.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NavigationContainer)).BeginInit();
			this.NavigationContainer.Panel1.SuspendLayout();
			this.NavigationContainer.Panel2.SuspendLayout();
			this.NavigationContainer.SuspendLayout();
			this.TextureTabControl.SuspendLayout();
			this.tabPageTilesets.SuspendLayout();
			this.tableLayoutTilesets.SuspendLayout();
			this.tabPageAutotiles.SuspendLayout();
			this.tableLayoutAutotiles.SuspendLayout();
			this.tabPageAnimations.SuspendLayout();
			this.tableLayoutAnimations.SuspendLayout();
			this.tabPageObjects.SuspendLayout();
			this.tableLayoutObjects.SuspendLayout();
			this.ProjectTreeContext.SuspendLayout();
			this.ProjectTreeNodeContext.SuspendLayout();
			this.SuspendLayout();
			// 
			// MapHScrollBar
			// 
			this.MapHScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapHScrollBar.LargeChange = 1;
			this.MapHScrollBar.Location = new System.Drawing.Point(0, 423);
			this.MapHScrollBar.Maximum = 0;
			this.MapHScrollBar.Name = "MapHScrollBar";
			this.MapHScrollBar.Size = new System.Drawing.Size(521, 20);
			this.MapHScrollBar.TabIndex = 1;
			this.MapHScrollBar.Visible = false;
			this.MapHScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MapHScrollBar_Scroll);
			// 
			// MapVScrollBar
			// 
			this.MapVScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapVScrollBar.LargeChange = 1;
			this.MapVScrollBar.Location = new System.Drawing.Point(521, 0);
			this.MapVScrollBar.Maximum = 0;
			this.MapVScrollBar.Name = "MapVScrollBar";
			this.MapVScrollBar.Size = new System.Drawing.Size(20, 423);
			this.MapVScrollBar.TabIndex = 2;
			this.MapVScrollBar.Visible = false;
			this.MapVScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MapVScrollBar_Scroll);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEditor,
            this.MenuSettings,
            this.MenuExtras,
            this.MenuAbout});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(838, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// MenuEditor
			// 
			this.MenuEditor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEditorNew,
            this.MenuEditorOpen,
            this.MenuEditorSave,
            this.toolStripSeparator2,
            this.MenuEditorExit});
			this.MenuEditor.Name = "MenuEditor";
			this.MenuEditor.Size = new System.Drawing.Size(50, 20);
			this.MenuEditor.Text = "Editor";
			// 
			// MenuEditorNew
			// 
			this.MenuEditorNew.Image = global::FreeWorld.Editor.Map.Properties.Resources.Map_New;
			this.MenuEditorNew.Name = "MenuEditorNew";
			this.MenuEditorNew.Size = new System.Drawing.Size(161, 22);
			this.MenuEditorNew.Text = "Neue Map...";
			this.MenuEditorNew.Click += new System.EventHandler(this.MenuFileNew_Click);
			// 
			// MenuEditorOpen
			// 
			this.MenuEditorOpen.Image = global::FreeWorld.Editor.Map.Properties.Resources.Map_Open;
			this.MenuEditorOpen.Name = "MenuEditorOpen";
			this.MenuEditorOpen.Size = new System.Drawing.Size(161, 22);
			this.MenuEditorOpen.Text = "Map öffnen...";
			this.MenuEditorOpen.Click += new System.EventHandler(this.MenuFileOpen_Click);
			// 
			// MenuEditorSave
			// 
			this.MenuEditorSave.Image = global::FreeWorld.Editor.Map.Properties.Resources.Map_Save;
			this.MenuEditorSave.Name = "MenuEditorSave";
			this.MenuEditorSave.Size = new System.Drawing.Size(161, 22);
			this.MenuEditorSave.Text = "Map speichern...";
			this.MenuEditorSave.Click += new System.EventHandler(this.MenuFileSave_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
			// 
			// MenuEditorExit
			// 
			this.MenuEditorExit.Image = global::FreeWorld.Editor.Map.Properties.Resources.Program_Exit;
			this.MenuEditorExit.Name = "MenuEditorExit";
			this.MenuEditorExit.Size = new System.Drawing.Size(161, 22);
			this.MenuEditorExit.Text = "Beenden";
			this.MenuEditorExit.Click += new System.EventHandler(this.MenuEditorExit_Click);
			// 
			// MenuSettings
			// 
			this.MenuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSettingsOneTimeFill,
            this.MenuSettingsFillSameTexture,
            this.toolStripSeparator9,
            this.MenuSettingsTransparentLayer,
            this.toolStripSeparator10,
            this.MenuSettingsGridNonEmptyCells});
			this.MenuSettings.Name = "MenuSettings";
			this.MenuSettings.Size = new System.Drawing.Size(90, 20);
			this.MenuSettings.Text = "Einstellungen";
			// 
			// MenuSettingsOneTimeFill
			// 
			this.MenuSettingsOneTimeFill.Checked = true;
			this.MenuSettingsOneTimeFill.CheckOnClick = global::FreeWorld.Editor.Map.Properties.Settings.Default.OneTimeFill;
			this.MenuSettingsOneTimeFill.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuSettingsOneTimeFill.Image = global::FreeWorld.Editor.Map.Properties.Resources.Mode_Fill;
			this.MenuSettingsOneTimeFill.Name = "MenuSettingsOneTimeFill";
			this.MenuSettingsOneTimeFill.Size = new System.Drawing.Size(226, 22);
			this.MenuSettingsOneTimeFill.Text = "Füllen: \"One-time\"";
			// 
			// MenuSettingsFillSameTexture
			// 
			this.MenuSettingsFillSameTexture.Checked = global::FreeWorld.Editor.Map.Properties.Settings.Default.FillSameTexture;
			this.MenuSettingsFillSameTexture.CheckOnClick = true;
			this.MenuSettingsFillSameTexture.Image = global::FreeWorld.Editor.Map.Properties.Resources.Mode_Fill;
			this.MenuSettingsFillSameTexture.Name = "MenuSettingsFillSameTexture";
			this.MenuSettingsFillSameTexture.Size = new System.Drawing.Size(226, 22);
			this.MenuSettingsFillSameTexture.Text = "Füllen: nur gleiche Textur";
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(223, 6);
			// 
			// MenuSettingsTransparentLayer
			// 
			this.MenuSettingsTransparentLayer.Checked = global::FreeWorld.Editor.Map.Properties.Settings.Default.TransparentLayer;
			this.MenuSettingsTransparentLayer.CheckOnClick = true;
			this.MenuSettingsTransparentLayer.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuSettingsTransparentLayer.Image = global::FreeWorld.Editor.Map.Properties.Resources.Layer_Blue;
			this.MenuSettingsTransparentLayer.Name = "MenuSettingsTransparentLayer";
			this.MenuSettingsTransparentLayer.Size = new System.Drawing.Size(226, 22);
			this.MenuSettingsTransparentLayer.Text = "Ebenen: inaktive Transparent";
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(223, 6);
			// 
			// MenuSettingsGridNonEmptyCells
			// 
			this.MenuSettingsGridNonEmptyCells.Checked = global::FreeWorld.Editor.Map.Properties.Settings.Default.GridOnlyNonEmptyCells;
			this.MenuSettingsGridNonEmptyCells.CheckOnClick = true;
			this.MenuSettingsGridNonEmptyCells.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuSettingsGridNonEmptyCells.Image = global::FreeWorld.Editor.Map.Properties.Resources.Show_Grid;
			this.MenuSettingsGridNonEmptyCells.Name = "MenuSettingsGridNonEmptyCells";
			this.MenuSettingsGridNonEmptyCells.Size = new System.Drawing.Size(226, 22);
			this.MenuSettingsGridNonEmptyCells.Text = "Grid: nur nicht-leere Zellen";
			// 
			// MenuExtras
			// 
			this.MenuExtras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExtrasMapPreview,
            this.toolStripSeparator6,
            this.MenuExtrasMapConvert});
			this.MenuExtras.Name = "MenuExtras";
			this.MenuExtras.Size = new System.Drawing.Size(49, 20);
			this.MenuExtras.Text = "Extras";
			// 
			// MenuExtrasMapPreview
			// 
			this.MenuExtrasMapPreview.Name = "MenuExtrasMapPreview";
			this.MenuExtrasMapPreview.Size = new System.Drawing.Size(189, 22);
			this.MenuExtrasMapPreview.Text = "Map Preview erstellen";
			this.MenuExtrasMapPreview.Click += new System.EventHandler(this.MenuExtrasMapPreview_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(186, 6);
			// 
			// MenuExtrasMapConvert
			// 
			this.MenuExtrasMapConvert.Name = "MenuExtrasMapConvert";
			this.MenuExtrasMapConvert.Size = new System.Drawing.Size(189, 22);
			this.MenuExtrasMapConvert.Text = "Konvertierung < 3.1";
			this.MenuExtrasMapConvert.Click += new System.EventHandler(this.MenuExtrasMapConvert_Click);
			// 
			// MenuAbout
			// 
			this.MenuAbout.Name = "MenuAbout";
			this.MenuAbout.Size = new System.Drawing.Size(53, 20);
			this.MenuAbout.Text = "Über...";
			this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
			// 
			// DrawpanelLayout
			// 
			this.DrawpanelLayout.ColumnCount = 2;
			this.DrawpanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.DrawpanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.DrawpanelLayout.Controls.Add(this.RenderDisplayMap, 0, 0);
			this.DrawpanelLayout.Controls.Add(this.MapVScrollBar, 1, 0);
			this.DrawpanelLayout.Controls.Add(this.MapHScrollBar, 0, 1);
			this.DrawpanelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DrawpanelLayout.Location = new System.Drawing.Point(0, 0);
			this.DrawpanelLayout.Name = "DrawpanelLayout";
			this.DrawpanelLayout.RowCount = 2;
			this.DrawpanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.DrawpanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.DrawpanelLayout.Size = new System.Drawing.Size(541, 443);
			this.DrawpanelLayout.TabIndex = 12;
			// 
			// RenderDisplayMap
			// 
			this.RenderDisplayMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RenderDisplayMap.Location = new System.Drawing.Point(3, 3);
			this.RenderDisplayMap.Name = "RenderDisplayMap";
			this.RenderDisplayMap.Size = new System.Drawing.Size(515, 417);
			this.RenderDisplayMap.TabIndex = 0;
			this.RenderDisplayMap.Text = "MapDisplay";
			this.RenderDisplayMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseClick);
			this.RenderDisplayMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseDown);
			this.RenderDisplayMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseMove);
			this.RenderDisplayMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseUp);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LayerStatus,
            this.StatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 498);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusStrip1.Size = new System.Drawing.Size(838, 22);
			this.statusStrip1.TabIndex = 12;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// LayerStatus
			// 
			this.LayerStatus.AutoSize = false;
			this.LayerStatus.Name = "LayerStatus";
			this.LayerStatus.Size = new System.Drawing.Size(280, 17);
			this.LayerStatus.Text = "Aktive Ebene: keine";
			this.LayerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StatusLabel
			// 
			this.StatusLabel.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 17);
			this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNewToolstrip,
            this.fileOpenToolstrip,
            this.fileSaveToolstrip,
            this.toolStripSeparator4,
            this.MenuToolStripDrawNormalButton,
            this.MenuToolStripDrawEraseButton,
            this.MenuToolStripDrawFillButton,
            this.MenuToolStripDrawRectangleButton,
            this.toolStripSeparator7,
            this.MenuToolStripDrawRotateButton,
            this.MenuToolStripDrawFlipButton,
            this.toolStripSeparator3,
            this.MenuToolStripShowGridButton,
            this.MenuToolStripShowAllLayersButton,
            this.MenuToolStripShowCollisionLayer,
            this.MenuToolStripShowFog,
            this.toolStripSeparator5,
            this.MenuToolStripActionUndo,
            this.MenuToolStripActionRedo});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(838, 31);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// fileNewToolstrip
			// 
			this.fileNewToolstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fileNewToolstrip.Image = global::FreeWorld.Editor.Map.Properties.Resources.Map_New;
			this.fileNewToolstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileNewToolstrip.Name = "fileNewToolstrip";
			this.fileNewToolstrip.Size = new System.Drawing.Size(28, 28);
			this.fileNewToolstrip.Text = "toolStripButton1";
			this.fileNewToolstrip.ToolTipText = "Neue Map anlegen";
			this.fileNewToolstrip.Click += new System.EventHandler(this.MenuFileNew_Click);
			// 
			// fileOpenToolstrip
			// 
			this.fileOpenToolstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fileOpenToolstrip.Image = global::FreeWorld.Editor.Map.Properties.Resources.Map_Open;
			this.fileOpenToolstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileOpenToolstrip.Name = "fileOpenToolstrip";
			this.fileOpenToolstrip.Size = new System.Drawing.Size(28, 28);
			this.fileOpenToolstrip.Text = "toolStripButton1";
			this.fileOpenToolstrip.ToolTipText = "Map öffnen";
			this.fileOpenToolstrip.Click += new System.EventHandler(this.MenuFileOpen_Click);
			// 
			// fileSaveToolstrip
			// 
			this.fileSaveToolstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fileSaveToolstrip.Image = global::FreeWorld.Editor.Map.Properties.Resources.Map_Save;
			this.fileSaveToolstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileSaveToolstrip.Name = "fileSaveToolstrip";
			this.fileSaveToolstrip.Size = new System.Drawing.Size(28, 28);
			this.fileSaveToolstrip.Text = "toolStripButton1";
			this.fileSaveToolstrip.ToolTipText = "Map speichern";
			this.fileSaveToolstrip.Click += new System.EventHandler(this.MenuFileSave_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
			// 
			// MenuToolStripDrawNormalButton
			// 
			this.MenuToolStripDrawNormalButton.Checked = true;
			this.MenuToolStripDrawNormalButton.CheckOnClick = true;
			this.MenuToolStripDrawNormalButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuToolStripDrawNormalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripDrawNormalButton.Image = global::FreeWorld.Editor.Map.Properties.Resources.Mode_Edit;
			this.MenuToolStripDrawNormalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripDrawNormalButton.Name = "MenuToolStripDrawNormalButton";
			this.MenuToolStripDrawNormalButton.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripDrawNormalButton.Text = "toolStripButton1";
			this.MenuToolStripDrawNormalButton.ToolTipText = "Zeichenmodus: Zeichnen";
			this.MenuToolStripDrawNormalButton.Click += new System.EventHandler(this.MenuToolStripDrawNormalButton_Click);
			// 
			// MenuToolStripDrawEraseButton
			// 
			this.MenuToolStripDrawEraseButton.CheckOnClick = true;
			this.MenuToolStripDrawEraseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripDrawEraseButton.Image = global::FreeWorld.Editor.Map.Properties.Resources.Mode_Erase;
			this.MenuToolStripDrawEraseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripDrawEraseButton.Name = "MenuToolStripDrawEraseButton";
			this.MenuToolStripDrawEraseButton.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripDrawEraseButton.Text = "toolStripButton1";
			this.MenuToolStripDrawEraseButton.ToolTipText = "Zeichenmodus: Löschen";
			this.MenuToolStripDrawEraseButton.Click += new System.EventHandler(this.MenuToolStripDrawEraseButton_Click);
			// 
			// MenuToolStripDrawFillButton
			// 
			this.MenuToolStripDrawFillButton.CheckOnClick = true;
			this.MenuToolStripDrawFillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripDrawFillButton.Image = global::FreeWorld.Editor.Map.Properties.Resources.Mode_Fill;
			this.MenuToolStripDrawFillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripDrawFillButton.Name = "MenuToolStripDrawFillButton";
			this.MenuToolStripDrawFillButton.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripDrawFillButton.Text = "toolStripButton1";
			this.MenuToolStripDrawFillButton.ToolTipText = "Zeichenmodus: +Ausfüllen";
			this.MenuToolStripDrawFillButton.Click += new System.EventHandler(this.MenuToolStripDrawFillButton_Click);
			// 
			// MenuToolStripDrawRectangleButton
			// 
			this.MenuToolStripDrawRectangleButton.CheckOnClick = true;
			this.MenuToolStripDrawRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripDrawRectangleButton.Image = global::FreeWorld.Editor.Map.Properties.Resources.Mode_Select;
			this.MenuToolStripDrawRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripDrawRectangleButton.Name = "MenuToolStripDrawRectangleButton";
			this.MenuToolStripDrawRectangleButton.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripDrawRectangleButton.Text = "toolStripButton1";
			this.MenuToolStripDrawRectangleButton.ToolTipText = "Rechteck Auswahl auf der Map erstellen";
			this.MenuToolStripDrawRectangleButton.Click += new System.EventHandler(this.MenuToolStripDrawRectangleButton_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
			// 
			// MenuToolStripDrawRotateButton
			// 
			this.MenuToolStripDrawRotateButton.CheckOnClick = true;
			this.MenuToolStripDrawRotateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripDrawRotateButton.Image = global::FreeWorld.Editor.Map.Properties.Resources.Rotate;
			this.MenuToolStripDrawRotateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripDrawRotateButton.Name = "MenuToolStripDrawRotateButton";
			this.MenuToolStripDrawRotateButton.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripDrawRotateButton.Text = "toolStripButton1";
			this.MenuToolStripDrawRotateButton.ToolTipText = "Zellen drehen";
			this.MenuToolStripDrawRotateButton.Click += new System.EventHandler(this.MenuToolStripDrawRotateButton_Click);
			// 
			// MenuToolStripDrawFlipButton
			// 
			this.MenuToolStripDrawFlipButton.CheckOnClick = true;
			this.MenuToolStripDrawFlipButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripDrawFlipButton.Image = global::FreeWorld.Editor.Map.Properties.Resources.Flip_V;
			this.MenuToolStripDrawFlipButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripDrawFlipButton.Name = "MenuToolStripDrawFlipButton";
			this.MenuToolStripDrawFlipButton.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripDrawFlipButton.Text = "toolStripButton1";
			this.MenuToolStripDrawFlipButton.ToolTipText = "Linksklick: vertikal Spiegeln; Rechtsklick: horizontal Spiegeln";
			this.MenuToolStripDrawFlipButton.Click += new System.EventHandler(this.MenuToolStripDrawFlipButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			// 
			// MenuToolStripShowGridButton
			// 
			this.MenuToolStripShowGridButton.Checked = global::FreeWorld.Editor.Map.Properties.Settings.Default.ShowGrid;
			this.MenuToolStripShowGridButton.CheckOnClick = true;
			this.MenuToolStripShowGridButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripShowGridButton.Image = global::FreeWorld.Editor.Map.Properties.Resources.Show_Grid;
			this.MenuToolStripShowGridButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripShowGridButton.Name = "MenuToolStripShowGridButton";
			this.MenuToolStripShowGridButton.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripShowGridButton.Text = "Grid anzeigen";
			// 
			// MenuToolStripShowAllLayersButton
			// 
			this.MenuToolStripShowAllLayersButton.CheckOnClick = true;
			this.MenuToolStripShowAllLayersButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripShowAllLayersButton.Image = global::FreeWorld.Editor.Map.Properties.Resources.Show_All_Layers;
			this.MenuToolStripShowAllLayersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripShowAllLayersButton.Name = "MenuToolStripShowAllLayersButton";
			this.MenuToolStripShowAllLayersButton.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripShowAllLayersButton.Text = "Alle Ebenen anzeigen";
			// 
			// MenuToolStripShowCollisionLayer
			// 
			this.MenuToolStripShowCollisionLayer.CheckOnClick = true;
			this.MenuToolStripShowCollisionLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripShowCollisionLayer.Image = global::FreeWorld.Editor.Map.Properties.Resources.Show_Collision_Layer;
			this.MenuToolStripShowCollisionLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripShowCollisionLayer.Name = "MenuToolStripShowCollisionLayer";
			this.MenuToolStripShowCollisionLayer.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripShowCollisionLayer.Text = "Kollisions Ebene anzeigen";
			// 
			// MenuToolStripShowFog
			// 
			this.MenuToolStripShowFog.CheckOnClick = true;
			this.MenuToolStripShowFog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripShowFog.Image = global::FreeWorld.Editor.Map.Properties.Resources.Show_Fog;
			this.MenuToolStripShowFog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripShowFog.Name = "MenuToolStripShowFog";
			this.MenuToolStripShowFog.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripShowFog.Text = "Nebel anzeigen";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
			// 
			// MenuToolStripActionUndo
			// 
			this.MenuToolStripActionUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripActionUndo.Enabled = false;
			this.MenuToolStripActionUndo.Image = global::FreeWorld.Editor.Map.Properties.Resources.Undo;
			this.MenuToolStripActionUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripActionUndo.Name = "MenuToolStripActionUndo";
			this.MenuToolStripActionUndo.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripActionUndo.Text = "toolStripButton1";
			this.MenuToolStripActionUndo.ToolTipText = "Ein Zeichenaktion rückgängig";
			this.MenuToolStripActionUndo.Click += new System.EventHandler(this.MenuToolStripUndoAction_Click);
			// 
			// MenuToolStripActionRedo
			// 
			this.MenuToolStripActionRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripActionRedo.Enabled = false;
			this.MenuToolStripActionRedo.Image = global::FreeWorld.Editor.Map.Properties.Resources.Redo;
			this.MenuToolStripActionRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripActionRedo.Name = "MenuToolStripActionRedo";
			this.MenuToolStripActionRedo.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripActionRedo.Text = "toolStripButton1";
			this.MenuToolStripActionRedo.ToolTipText = "Eine Zeichenaktion wiederherstellen";
			this.MenuToolStripActionRedo.Click += new System.EventHandler(this.MenuToolStripRedoAction_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 55);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.NavigationContainer);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.DrawpanelLayout);
			this.splitContainer1.Size = new System.Drawing.Size(838, 443);
			this.splitContainer1.SplitterDistance = 293;
			this.splitContainer1.TabIndex = 14;
			// 
			// NavigationContainer
			// 
			this.NavigationContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NavigationContainer.Location = new System.Drawing.Point(0, 0);
			this.NavigationContainer.Name = "NavigationContainer";
			this.NavigationContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// NavigationContainer.Panel1
			// 
			this.NavigationContainer.Panel1.AutoScroll = true;
			this.NavigationContainer.Panel1.Controls.Add(this.TextureTabControl);
			// 
			// NavigationContainer.Panel2
			// 
			this.NavigationContainer.Panel2.Controls.Add(this.ProjectTree);
			this.NavigationContainer.Size = new System.Drawing.Size(293, 443);
			this.NavigationContainer.SplitterDistance = 337;
			this.NavigationContainer.TabIndex = 12;
			// 
			// TextureTabControl
			// 
			this.TextureTabControl.Controls.Add(this.tabPageTilesets);
			this.TextureTabControl.Controls.Add(this.tabPageAutotiles);
			this.TextureTabControl.Controls.Add(this.tabPageAnimations);
			this.TextureTabControl.Controls.Add(this.tabPageObjects);
			this.TextureTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextureTabControl.Location = new System.Drawing.Point(0, 0);
			this.TextureTabControl.Name = "TextureTabControl";
			this.TextureTabControl.SelectedIndex = 0;
			this.TextureTabControl.Size = new System.Drawing.Size(293, 337);
			this.TextureTabControl.TabIndex = 3;
			this.TextureTabControl.SelectedIndexChanged += new System.EventHandler(this.TextureTabControl_SelectedIndexChanged);
			// 
			// tabPageTilesets
			// 
			this.tabPageTilesets.Controls.Add(this.tableLayoutTilesets);
			this.tabPageTilesets.Location = new System.Drawing.Point(4, 22);
			this.tabPageTilesets.Name = "tabPageTilesets";
			this.tabPageTilesets.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTilesets.Size = new System.Drawing.Size(285, 311);
			this.tabPageTilesets.TabIndex = 0;
			this.tabPageTilesets.Text = "Tilesets";
			this.tabPageTilesets.UseVisualStyleBackColor = true;
			// 
			// tableLayoutTilesets
			// 
			this.tableLayoutTilesets.ColumnCount = 2;
			this.tableLayoutTilesets.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutTilesets.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutTilesets.Controls.Add(this.TilesetHScrollBar, 0, 2);
			this.tableLayoutTilesets.Controls.Add(this.TilesetVScrollBar, 1, 1);
			this.tableLayoutTilesets.Controls.Add(this.RenderDisplayTexture, 0, 1);
			this.tableLayoutTilesets.Controls.Add(this.comboTilesets, 0, 0);
			this.tableLayoutTilesets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutTilesets.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutTilesets.Name = "tableLayoutTilesets";
			this.tableLayoutTilesets.RowCount = 3;
			this.tableLayoutTilesets.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutTilesets.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutTilesets.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutTilesets.Size = new System.Drawing.Size(279, 305);
			this.tableLayoutTilesets.TabIndex = 2;
			// 
			// TilesetHScrollBar
			// 
			this.tableLayoutTilesets.SetColumnSpan(this.TilesetHScrollBar, 2);
			this.TilesetHScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TilesetHScrollBar.LargeChange = 1;
			this.TilesetHScrollBar.Location = new System.Drawing.Point(0, 288);
			this.TilesetHScrollBar.Maximum = 0;
			this.TilesetHScrollBar.Name = "TilesetHScrollBar";
			this.TilesetHScrollBar.Size = new System.Drawing.Size(279, 17);
			this.TilesetHScrollBar.TabIndex = 8;
			this.TilesetHScrollBar.Visible = false;
			// 
			// TilesetVScrollBar
			// 
			this.TilesetVScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TilesetVScrollBar.LargeChange = 1;
			this.TilesetVScrollBar.Location = new System.Drawing.Point(262, 27);
			this.TilesetVScrollBar.Maximum = 0;
			this.TilesetVScrollBar.Name = "TilesetVScrollBar";
			this.TilesetVScrollBar.Size = new System.Drawing.Size(17, 261);
			this.TilesetVScrollBar.TabIndex = 3;
			this.TilesetVScrollBar.Visible = false;
			this.TilesetVScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TextureHScrollBar_Scroll);
			// 
			// RenderDisplayTexture
			// 
			this.RenderDisplayTexture.Cursor = System.Windows.Forms.Cursors.Cross;
			this.RenderDisplayTexture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RenderDisplayTexture.Location = new System.Drawing.Point(3, 30);
			this.RenderDisplayTexture.Name = "RenderDisplayTexture";
			this.RenderDisplayTexture.Size = new System.Drawing.Size(256, 255);
			this.RenderDisplayTexture.TabIndex = 1;
			this.RenderDisplayTexture.Text = "TextureDisplay";
			this.RenderDisplayTexture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextureDisplay_MouseDown);
			this.RenderDisplayTexture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextureDisplay_MouseMove);
			this.RenderDisplayTexture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextureDisplay_MouseUp);
			// 
			// comboTilesets
			// 
			this.tableLayoutTilesets.SetColumnSpan(this.comboTilesets, 2);
			this.comboTilesets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboTilesets.Enabled = false;
			this.comboTilesets.FormattingEnabled = true;
			this.comboTilesets.Location = new System.Drawing.Point(3, 3);
			this.comboTilesets.Name = "comboTilesets";
			this.comboTilesets.Size = new System.Drawing.Size(273, 21);
			this.comboTilesets.TabIndex = 5;
			this.comboTilesets.SelectedIndexChanged += new System.EventHandler(this.comboTextures_SelectedIndexChanged);
			// 
			// tabPageAutotiles
			// 
			this.tabPageAutotiles.Controls.Add(this.tableLayoutAutotiles);
			this.tabPageAutotiles.Location = new System.Drawing.Point(4, 22);
			this.tabPageAutotiles.Name = "tabPageAutotiles";
			this.tabPageAutotiles.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAutotiles.Size = new System.Drawing.Size(285, 311);
			this.tabPageAutotiles.TabIndex = 1;
			this.tabPageAutotiles.Text = "Autotiles";
			this.tabPageAutotiles.UseVisualStyleBackColor = true;
			// 
			// tableLayoutAutotiles
			// 
			this.tableLayoutAutotiles.ColumnCount = 2;
			this.tableLayoutAutotiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutAutotiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutAutotiles.Controls.Add(this.AutotilesVScrollBar, 1, 1);
			this.tableLayoutAutotiles.Controls.Add(this.RenderDisplayAutotile, 0, 1);
			this.tableLayoutAutotiles.Controls.Add(this.comboAutotiles, 0, 0);
			this.tableLayoutAutotiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutAutotiles.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutAutotiles.Name = "tableLayoutAutotiles";
			this.tableLayoutAutotiles.RowCount = 2;
			this.tableLayoutAutotiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutAutotiles.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutAutotiles.Size = new System.Drawing.Size(279, 305);
			this.tableLayoutAutotiles.TabIndex = 3;
			// 
			// AutotilesVScrollBar
			// 
			this.AutotilesVScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AutotilesVScrollBar.LargeChange = 1;
			this.AutotilesVScrollBar.Location = new System.Drawing.Point(262, 27);
			this.AutotilesVScrollBar.Maximum = 0;
			this.AutotilesVScrollBar.Name = "AutotilesVScrollBar";
			this.AutotilesVScrollBar.Size = new System.Drawing.Size(17, 278);
			this.AutotilesVScrollBar.TabIndex = 3;
			this.AutotilesVScrollBar.Visible = false;
			// 
			// RenderDisplayAutotile
			// 
			this.RenderDisplayAutotile.Cursor = System.Windows.Forms.Cursors.No;
			this.RenderDisplayAutotile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RenderDisplayAutotile.Location = new System.Drawing.Point(3, 30);
			this.RenderDisplayAutotile.Name = "RenderDisplayAutotile";
			this.RenderDisplayAutotile.Size = new System.Drawing.Size(256, 272);
			this.RenderDisplayAutotile.TabIndex = 1;
			this.RenderDisplayAutotile.Text = "RenderDisplayAutotiles";
			// 
			// comboAutotiles
			// 
			this.tableLayoutAutotiles.SetColumnSpan(this.comboAutotiles, 2);
			this.comboAutotiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboAutotiles.Enabled = false;
			this.comboAutotiles.FormattingEnabled = true;
			this.comboAutotiles.Location = new System.Drawing.Point(3, 3);
			this.comboAutotiles.Name = "comboAutotiles";
			this.comboAutotiles.Size = new System.Drawing.Size(273, 21);
			this.comboAutotiles.TabIndex = 5;
			this.comboAutotiles.SelectedIndexChanged += new System.EventHandler(this.comboAutoTextures_SelectedIndexChanged);
			// 
			// tabPageAnimations
			// 
			this.tabPageAnimations.Controls.Add(this.tableLayoutAnimations);
			this.tabPageAnimations.Location = new System.Drawing.Point(4, 22);
			this.tabPageAnimations.Name = "tabPageAnimations";
			this.tabPageAnimations.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAnimations.Size = new System.Drawing.Size(285, 311);
			this.tabPageAnimations.TabIndex = 2;
			this.tabPageAnimations.Text = "Animationen";
			this.tabPageAnimations.UseVisualStyleBackColor = true;
			// 
			// tableLayoutAnimations
			// 
			this.tableLayoutAnimations.ColumnCount = 2;
			this.tableLayoutAnimations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutAnimations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutAnimations.Controls.Add(this.AnimationsHScrollBar, 0, 2);
			this.tableLayoutAnimations.Controls.Add(this.AnimationsVScrollBar, 1, 1);
			this.tableLayoutAnimations.Controls.Add(this.RenderDisplayAnimations, 0, 1);
			this.tableLayoutAnimations.Controls.Add(this.comboAnimations, 0, 0);
			this.tableLayoutAnimations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutAnimations.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutAnimations.Name = "tableLayoutAnimations";
			this.tableLayoutAnimations.RowCount = 3;
			this.tableLayoutAnimations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutAnimations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutAnimations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutAnimations.Size = new System.Drawing.Size(279, 305);
			this.tableLayoutAnimations.TabIndex = 4;
			// 
			// AnimationsHScrollBar
			// 
			this.tableLayoutAnimations.SetColumnSpan(this.AnimationsHScrollBar, 2);
			this.AnimationsHScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AnimationsHScrollBar.LargeChange = 1;
			this.AnimationsHScrollBar.Location = new System.Drawing.Point(0, 288);
			this.AnimationsHScrollBar.Maximum = 0;
			this.AnimationsHScrollBar.Name = "AnimationsHScrollBar";
			this.AnimationsHScrollBar.Size = new System.Drawing.Size(279, 17);
			this.AnimationsHScrollBar.TabIndex = 7;
			this.AnimationsHScrollBar.Visible = false;
			this.AnimationsHScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.AnimationsHScrollBar_Scroll);
			// 
			// AnimationsVScrollBar
			// 
			this.AnimationsVScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AnimationsVScrollBar.LargeChange = 1;
			this.AnimationsVScrollBar.Location = new System.Drawing.Point(262, 27);
			this.AnimationsVScrollBar.Maximum = 0;
			this.AnimationsVScrollBar.Name = "AnimationsVScrollBar";
			this.AnimationsVScrollBar.Size = new System.Drawing.Size(17, 261);
			this.AnimationsVScrollBar.TabIndex = 3;
			this.AnimationsVScrollBar.Visible = false;
			this.AnimationsVScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.AnimationsVScrollBar_Scroll);
			// 
			// RenderDisplayAnimations
			// 
			this.RenderDisplayAnimations.Cursor = System.Windows.Forms.Cursors.No;
			this.RenderDisplayAnimations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RenderDisplayAnimations.Location = new System.Drawing.Point(3, 30);
			this.RenderDisplayAnimations.Name = "RenderDisplayAnimations";
			this.RenderDisplayAnimations.Size = new System.Drawing.Size(256, 255);
			this.RenderDisplayAnimations.TabIndex = 1;
			this.RenderDisplayAnimations.Text = "AnimationsDisplay";
			// 
			// comboAnimations
			// 
			this.tableLayoutAnimations.SetColumnSpan(this.comboAnimations, 2);
			this.comboAnimations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboAnimations.Enabled = false;
			this.comboAnimations.FormattingEnabled = true;
			this.comboAnimations.Location = new System.Drawing.Point(3, 3);
			this.comboAnimations.Name = "comboAnimations";
			this.comboAnimations.Size = new System.Drawing.Size(273, 21);
			this.comboAnimations.TabIndex = 5;
			this.comboAnimations.SelectedIndexChanged += new System.EventHandler(this.comboAnimations_SelectedIndexChanged);
			// 
			// tabPageObjects
			// 
			this.tabPageObjects.Controls.Add(this.tableLayoutObjects);
			this.tabPageObjects.Location = new System.Drawing.Point(4, 22);
			this.tabPageObjects.Name = "tabPageObjects";
			this.tabPageObjects.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageObjects.Size = new System.Drawing.Size(285, 311);
			this.tabPageObjects.TabIndex = 3;
			this.tabPageObjects.Text = "Objekte";
			this.tabPageObjects.UseVisualStyleBackColor = true;
			// 
			// tableLayoutObjects
			// 
			this.tableLayoutObjects.ColumnCount = 2;
			this.tableLayoutObjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutObjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutObjects.Controls.Add(this.ObjectsHScrollBar, 0, 2);
			this.tableLayoutObjects.Controls.Add(this.ObjectsVScrollBar, 1, 1);
			this.tableLayoutObjects.Controls.Add(this.RenderDisplayObjects, 0, 1);
			this.tableLayoutObjects.Controls.Add(this.comboObjects, 0, 0);
			this.tableLayoutObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutObjects.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutObjects.Name = "tableLayoutObjects";
			this.tableLayoutObjects.RowCount = 3;
			this.tableLayoutObjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutObjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutObjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutObjects.Size = new System.Drawing.Size(279, 305);
			this.tableLayoutObjects.TabIndex = 5;
			// 
			// ObjectsHScrollBar
			// 
			this.tableLayoutObjects.SetColumnSpan(this.ObjectsHScrollBar, 2);
			this.ObjectsHScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ObjectsHScrollBar.LargeChange = 1;
			this.ObjectsHScrollBar.Location = new System.Drawing.Point(0, 288);
			this.ObjectsHScrollBar.Maximum = 0;
			this.ObjectsHScrollBar.Name = "ObjectsHScrollBar";
			this.ObjectsHScrollBar.Size = new System.Drawing.Size(279, 17);
			this.ObjectsHScrollBar.TabIndex = 6;
			this.ObjectsHScrollBar.Visible = false;
			this.ObjectsHScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ObjectsHScrollBar_Scroll);
			// 
			// ObjectsVScrollBar
			// 
			this.ObjectsVScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ObjectsVScrollBar.LargeChange = 1;
			this.ObjectsVScrollBar.Location = new System.Drawing.Point(262, 27);
			this.ObjectsVScrollBar.Maximum = 0;
			this.ObjectsVScrollBar.Name = "ObjectsVScrollBar";
			this.ObjectsVScrollBar.Size = new System.Drawing.Size(17, 261);
			this.ObjectsVScrollBar.TabIndex = 3;
			this.ObjectsVScrollBar.Visible = false;
			this.ObjectsVScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ObjectsVScrollBar_Scroll);
			// 
			// RenderDisplayObjects
			// 
			this.RenderDisplayObjects.Cursor = System.Windows.Forms.Cursors.No;
			this.RenderDisplayObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RenderDisplayObjects.Location = new System.Drawing.Point(3, 30);
			this.RenderDisplayObjects.Name = "RenderDisplayObjects";
			this.RenderDisplayObjects.Size = new System.Drawing.Size(256, 255);
			this.RenderDisplayObjects.TabIndex = 1;
			this.RenderDisplayObjects.Text = "ObjectsDisplay";
			// 
			// comboObjects
			// 
			this.tableLayoutObjects.SetColumnSpan(this.comboObjects, 2);
			this.comboObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboObjects.Enabled = false;
			this.comboObjects.FormattingEnabled = true;
			this.comboObjects.Location = new System.Drawing.Point(3, 3);
			this.comboObjects.Name = "comboObjects";
			this.comboObjects.Size = new System.Drawing.Size(273, 21);
			this.comboObjects.TabIndex = 5;
			this.comboObjects.SelectedIndexChanged += new System.EventHandler(this.comboObjects_SelectedIndexChanged);
			// 
			// ProjectTree
			// 
			this.ProjectTree.AllowDrop = true;
			this.ProjectTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ProjectTree.HideSelection = false;
			this.ProjectTree.ImageIndex = 0;
			this.ProjectTree.ImageList = this.ProjectTreeImageList;
			this.ProjectTree.Location = new System.Drawing.Point(0, 0);
			this.ProjectTree.Name = "ProjectTree";
			this.ProjectTree.SelectedImageIndex = 0;
			this.ProjectTree.Size = new System.Drawing.Size(293, 102);
			this.ProjectTree.TabIndex = 0;
			this.ProjectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTree_AfterSelect);
			this.ProjectTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTree_NodeMouseClick);
			// 
			// ProjectTreeImageList
			// 
			this.ProjectTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ProjectTreeImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.ProjectTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ProjectTreeContext
			// 
			this.ProjectTreeContext.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.ProjectTreeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProjectTreeContextAddLayer,
            this.toolStripSeparator8,
            this.ProjectTreeContextEditSize,
            this.ProjectTreeContextEditName,
            this.toolStripSeparator11,
            this.ProjectTreeContextEditFog});
			this.ProjectTreeContext.Name = "ProjectTreeContext";
			this.ProjectTreeContext.Size = new System.Drawing.Size(182, 136);
			this.ProjectTreeContext.Opening += new System.ComponentModel.CancelEventHandler(this.ProjectTreeContext_Opening);
			// 
			// ProjectTreeContextAddLayer
			// 
			this.ProjectTreeContextAddLayer.Image = global::FreeWorld.Editor.Map.Properties.Resources.Layer_New;
			this.ProjectTreeContextAddLayer.Name = "ProjectTreeContextAddLayer";
			this.ProjectTreeContextAddLayer.Size = new System.Drawing.Size(181, 30);
			this.ProjectTreeContextAddLayer.Text = "Ebene hinzufügen";
			this.ProjectTreeContextAddLayer.Click += new System.EventHandler(this.ProjectTreeContextAddLayer_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(178, 6);
			// 
			// ProjectTreeContextEditSize
			// 
			this.ProjectTreeContextEditSize.Name = "ProjectTreeContextEditSize";
			this.ProjectTreeContextEditSize.Size = new System.Drawing.Size(181, 30);
			this.ProjectTreeContextEditSize.Text = "Map Größe ändern";
			this.ProjectTreeContextEditSize.Click += new System.EventHandler(this.mapGrößeÄndernToolStripMenuItem_Click);
			// 
			// ProjectTreeContextEditName
			// 
			this.ProjectTreeContextEditName.Name = "ProjectTreeContextEditName";
			this.ProjectTreeContextEditName.Size = new System.Drawing.Size(181, 30);
			this.ProjectTreeContextEditName.Text = "Map Name ändern";
			this.ProjectTreeContextEditName.Click += new System.EventHandler(this.mapNameÄndernToolStripMenuItem_Click);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(178, 6);
			// 
			// ProjectTreeContextEditFog
			// 
			this.ProjectTreeContextEditFog.Image = global::FreeWorld.Editor.Map.Properties.Resources.Show_Fog;
			this.ProjectTreeContextEditFog.Name = "ProjectTreeContextEditFog";
			this.ProjectTreeContextEditFog.Size = new System.Drawing.Size(181, 30);
			this.ProjectTreeContextEditFog.Text = "Nebel...";
			this.ProjectTreeContextEditFog.Click += new System.EventHandler(this.ProjectTreeContextEditFog_Click);
			// 
			// ProjectTreeNodeContext
			// 
			this.ProjectTreeNodeContext.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.ProjectTreeNodeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProjectTreeNodeContextRename,
            this.ProjectTreeNodeContextDelete,
            this.toolStripSeparator1,
            this.ProjectTreeNodeContextMoveUp,
            this.ProjectTreeNodeContextMoveDown});
			this.ProjectTreeNodeContext.Name = "ProjectTreeNodeContext";
			this.ProjectTreeNodeContext.Size = new System.Drawing.Size(178, 130);
			this.ProjectTreeNodeContext.Opening += new System.ComponentModel.CancelEventHandler(this.ProjectTreeNodeContext_Opening);
			// 
			// ProjectTreeNodeContextRename
			// 
			this.ProjectTreeNodeContextRename.Image = global::FreeWorld.Editor.Map.Properties.Resources.Layer_Rename;
			this.ProjectTreeNodeContextRename.Name = "ProjectTreeNodeContextRename";
			this.ProjectTreeNodeContextRename.Size = new System.Drawing.Size(177, 30);
			this.ProjectTreeNodeContextRename.Text = "Ebene umbennen";
			this.ProjectTreeNodeContextRename.Click += new System.EventHandler(this.ProjectTreeNodeContextRename_Click);
			// 
			// ProjectTreeNodeContextDelete
			// 
			this.ProjectTreeNodeContextDelete.Image = global::FreeWorld.Editor.Map.Properties.Resources.Layer_Delete;
			this.ProjectTreeNodeContextDelete.Name = "ProjectTreeNodeContextDelete";
			this.ProjectTreeNodeContextDelete.Size = new System.Drawing.Size(177, 30);
			this.ProjectTreeNodeContextDelete.Text = "Ebene Löschen";
			this.ProjectTreeNodeContextDelete.Click += new System.EventHandler(this.ProjectTreeNodeContextDelete_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
			// 
			// ProjectTreeNodeContextMoveUp
			// 
			this.ProjectTreeNodeContextMoveUp.Name = "ProjectTreeNodeContextMoveUp";
			this.ProjectTreeNodeContextMoveUp.Size = new System.Drawing.Size(177, 30);
			this.ProjectTreeNodeContextMoveUp.Text = "Ebene nach oben";
			this.ProjectTreeNodeContextMoveUp.Click += new System.EventHandler(this.ProjectTreeNodeContextMoveUp_Click);
			// 
			// ProjectTreeNodeContextMoveDown
			// 
			this.ProjectTreeNodeContextMoveDown.Name = "ProjectTreeNodeContextMoveDown";
			this.ProjectTreeNodeContextMoveDown.Size = new System.Drawing.Size(177, 30);
			this.ProjectTreeNodeContextMoveDown.Text = "Ebene nach unten";
			this.ProjectTreeNodeContextMoveDown.Click += new System.EventHandler(this.ProjectTreeNodeContextMoveDown_Click);
			// 
			// FrmEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(838, 520);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmEditor";
			this.Text = "FreeWorld.Engine Editor - v3.1 by GodLesZ";
			this.Activated += new System.EventHandler(this.frmEditor_Activated);
			this.Deactivate += new System.EventHandler(this.frmEditor_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditor_FormClosing);
			this.Shown += new System.EventHandler(this.frmEditor_Shown);
			this.ResizeEnd += new System.EventHandler(this.frmEditor_ResizeEnd);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditor_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.DrawpanelLayout.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.NavigationContainer.Panel1.ResumeLayout(false);
			this.NavigationContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NavigationContainer)).EndInit();
			this.NavigationContainer.ResumeLayout(false);
			this.TextureTabControl.ResumeLayout(false);
			this.tabPageTilesets.ResumeLayout(false);
			this.tableLayoutTilesets.ResumeLayout(false);
			this.tabPageAutotiles.ResumeLayout(false);
			this.tableLayoutAutotiles.ResumeLayout(false);
			this.tabPageAnimations.ResumeLayout(false);
			this.tableLayoutAnimations.ResumeLayout(false);
			this.tabPageObjects.ResumeLayout(false);
			this.tableLayoutObjects.ResumeLayout(false);
			this.ProjectTreeContext.ResumeLayout(false);
			this.ProjectTreeNodeContext.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TileDisplay RenderDisplayMap;
		private System.Windows.Forms.HScrollBar MapHScrollBar;
		private System.Windows.Forms.VScrollBar MapVScrollBar;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem MenuEditor;
		private System.Windows.Forms.ToolStripMenuItem MenuEditorNew;
		private System.Windows.Forms.ToolStripMenuItem MenuEditorOpen;
		private System.Windows.Forms.ToolStripMenuItem MenuEditorExit;
		private System.Windows.Forms.ToolStripMenuItem MenuEditorSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TableLayoutPanel DrawpanelLayout;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer NavigationContainer;
		private System.Windows.Forms.TreeView ProjectTree;
		private System.Windows.Forms.ToolStripButton MenuToolStripDrawNormalButton;
		private System.Windows.Forms.ToolStripButton fileNewToolstrip;
		private System.Windows.Forms.ToolStripButton fileOpenToolstrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton MenuToolStripDrawEraseButton;
		private System.Windows.Forms.ToolStripButton MenuToolStripDrawFillButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton fileSaveToolstrip;
		private System.Windows.Forms.ContextMenuStrip ProjectTreeContext;
		private System.Windows.Forms.ToolStripMenuItem ProjectTreeContextAddLayer;
		private System.Windows.Forms.ContextMenuStrip ProjectTreeNodeContext;
		private System.Windows.Forms.ToolStripMenuItem ProjectTreeNodeContextDelete;
		private System.Windows.Forms.ImageList ProjectTreeImageList;
		private TileDisplay RenderDisplayTexture;
		private System.Windows.Forms.TableLayoutPanel tableLayoutTilesets;
		private System.Windows.Forms.VScrollBar TilesetVScrollBar;
		private System.Windows.Forms.ToolStripButton MenuToolStripDrawRectangleButton;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ProjectTreeNodeContextMoveUp;
		private System.Windows.Forms.ToolStripMenuItem ProjectTreeNodeContextMoveDown;
		private System.Windows.Forms.ToolStripStatusLabel LayerStatus;
		private System.Windows.Forms.ToolStripButton MenuToolStripShowGridButton;
		private System.Windows.Forms.ToolStripButton MenuToolStripShowAllLayersButton;
		private System.Windows.Forms.ToolStripButton MenuToolStripShowCollisionLayer;
		private System.Windows.Forms.ToolStripMenuItem ProjectTreeNodeContextRename;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem MenuSettings;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingsOneTimeFill;
		private System.Windows.Forms.ToolStripButton MenuToolStripDrawRotateButton;
		private System.Windows.Forms.ToolStripButton MenuToolStripActionUndo;
		private System.Windows.Forms.TabControl TextureTabControl;
		private System.Windows.Forms.TabPage tabPageTilesets;
		private System.Windows.Forms.TabPage tabPageAutotiles;
		private System.Windows.Forms.ComboBox comboTilesets;
		private System.Windows.Forms.TableLayoutPanel tableLayoutAutotiles;
		private System.Windows.Forms.VScrollBar AutotilesVScrollBar;
		private TileDisplay RenderDisplayAutotile;
		private System.Windows.Forms.ComboBox comboAutotiles;
		private System.Windows.Forms.ToolStripMenuItem MenuExtras;
		private System.Windows.Forms.ToolStripMenuItem MenuExtrasMapPreview;
		private System.Windows.Forms.ToolStripButton MenuToolStripActionRedo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem ProjectTreeContextEditSize;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingsFillSameTexture;
		private System.Windows.Forms.ToolStripMenuItem ProjectTreeContextEditName;
		private System.Windows.Forms.ToolStripMenuItem MenuAbout;
		private System.Windows.Forms.ToolStripButton MenuToolStripDrawFlipButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingsTransparentLayer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingsGridNonEmptyCells;
		private System.Windows.Forms.ToolStripButton MenuToolStripShowFog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem ProjectTreeContextEditFog;
		private System.Windows.Forms.TabPage tabPageAnimations;
		private System.Windows.Forms.TableLayoutPanel tableLayoutAnimations;
		private System.Windows.Forms.VScrollBar AnimationsVScrollBar;
		private TileDisplay RenderDisplayAnimations;
		private System.Windows.Forms.ComboBox comboAnimations;
		private System.Windows.Forms.TabPage tabPageObjects;
		private System.Windows.Forms.TableLayoutPanel tableLayoutObjects;
		private System.Windows.Forms.VScrollBar ObjectsVScrollBar;
		private TileDisplay RenderDisplayObjects;
		private System.Windows.Forms.ComboBox comboObjects;
		private System.Windows.Forms.HScrollBar ObjectsHScrollBar;
		private System.Windows.Forms.HScrollBar AnimationsHScrollBar;
		private System.Windows.Forms.HScrollBar TilesetHScrollBar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem MenuExtrasMapConvert;
	}
}

