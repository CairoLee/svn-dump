

namespace eAthenaStudio.Plugins.EditSprite {
	sealed partial class frmSpriteEditor {
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
			GodLesZ.Library.Docking.DockPanelSkin dockPanelSkin1 = new GodLesZ.Library.Docking.DockPanelSkin();
			GodLesZ.Library.Docking.AutoHideStripSkin autoHideStripSkin1 = new GodLesZ.Library.Docking.AutoHideStripSkin();
			GodLesZ.Library.Docking.DockPanelGradient dockPanelGradient1 = new GodLesZ.Library.Docking.DockPanelGradient();
			GodLesZ.Library.Docking.TabGradient tabGradient1 = new GodLesZ.Library.Docking.TabGradient();
			GodLesZ.Library.Docking.DockPaneStripSkin dockPaneStripSkin1 = new GodLesZ.Library.Docking.DockPaneStripSkin();
			GodLesZ.Library.Docking.DockPaneStripGradient dockPaneStripGradient1 = new GodLesZ.Library.Docking.DockPaneStripGradient();
			GodLesZ.Library.Docking.TabGradient tabGradient2 = new GodLesZ.Library.Docking.TabGradient();
			GodLesZ.Library.Docking.DockPanelGradient dockPanelGradient2 = new GodLesZ.Library.Docking.DockPanelGradient();
			GodLesZ.Library.Docking.TabGradient tabGradient3 = new GodLesZ.Library.Docking.TabGradient();
			GodLesZ.Library.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new GodLesZ.Library.Docking.DockPaneStripToolWindowGradient();
			GodLesZ.Library.Docking.TabGradient tabGradient4 = new GodLesZ.Library.Docking.TabGradient();
			GodLesZ.Library.Docking.TabGradient tabGradient5 = new GodLesZ.Library.Docking.TabGradient();
			GodLesZ.Library.Docking.DockPanelGradient dockPanelGradient3 = new GodLesZ.Library.Docking.DockPanelGradient();
			GodLesZ.Library.Docking.TabGradient tabGradient6 = new GodLesZ.Library.Docking.TabGradient();
			GodLesZ.Library.Docking.TabGradient tabGradient7 = new GodLesZ.Library.Docking.TabGradient();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.MenuEditor = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuEditorClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSprite = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSpriteOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSpriteSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuSpriteFrameAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSpriteFrameDel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuSpriteExtract = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPalette = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPaletteRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuPaletteColorHighlighLabel = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPaletteColorHighlight = new eAthenaStudio.Plugins.EditSprite.Controls.ToolStripColorComboBox();
			this.colorHighlightBox = new eAthenaStudio.Plugins.EditSprite.Controls.ColorComboBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuPaletteImport = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuPaletteExport = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuPaletteChart = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.ToolSpriteOpen = new System.Windows.Forms.ToolStripButton();
			this.ToolSpriteSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolFrameFirst = new System.Windows.Forms.ToolStripButton();
			this.ToolFramePrev = new System.Windows.Forms.ToolStripButton();
			this.ToolFrameNext = new System.Windows.Forms.ToolStripButton();
			this.ToolFrameLast = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolFrameZoomIn = new System.Windows.Forms.ToolStripButton();
			this.ToolFrameZoomOut = new System.Windows.Forms.ToolStripButton();
			this.dockPanel = new GodLesZ.Library.Docking.DockPanel();
			this.colorComboBox1 = new eAthenaStudio.Plugins.EditSprite.Controls.ColorComboBox();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MenuEditor,
			this.MenuSprite,
			this.MenuPalette});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(655, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// MenuEditor
			// 
			this.MenuEditor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MenuEditorClose});
			this.MenuEditor.Name = "MenuEditor";
			this.MenuEditor.Size = new System.Drawing.Size(47, 20);
			this.MenuEditor.Text = "&Editor";
			// 
			// MenuEditorClose
			// 
			this.MenuEditorClose.Name = "MenuEditorClose";
			this.MenuEditorClose.Size = new System.Drawing.Size(127, 22);
			this.MenuEditorClose.Text = "&Beenden";
			this.MenuEditorClose.Click += new System.EventHandler(this.MenuEditorClose_Click);
			// 
			// MenuSprite
			// 
			this.MenuSprite.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MenuSpriteOpen,
			this.MenuSpriteSave,
			this.toolStripSeparator3,
			this.MenuSpriteFrameAdd,
			this.MenuSpriteFrameDel,
			this.toolStripSeparator7,
			this.MenuSpriteExtract});
			this.MenuSprite.Name = "MenuSprite";
			this.MenuSprite.Size = new System.Drawing.Size(47, 20);
			this.MenuSprite.Text = "&Sprite";
			// 
			// MenuSpriteOpen
			// 
			this.MenuSpriteOpen.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.openHS;
			this.MenuSpriteOpen.Name = "MenuSpriteOpen";
			this.MenuSpriteOpen.Size = new System.Drawing.Size(185, 22);
			this.MenuSpriteOpen.Text = "&Öffnen...";
			this.MenuSpriteOpen.Click += new System.EventHandler(this.MenuSpriteOpen_Click);
			// 
			// MenuSpriteSave
			// 
			this.MenuSpriteSave.Enabled = false;
			this.MenuSpriteSave.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.saveHS;
			this.MenuSpriteSave.Name = "MenuSpriteSave";
			this.MenuSpriteSave.Size = new System.Drawing.Size(185, 22);
			this.MenuSpriteSave.Text = "&Speichern...";
			this.MenuSpriteSave.Click += new System.EventHandler(this.MenuSpriteSave_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
			// 
			// MenuSpriteFrameAdd
			// 
			this.MenuSpriteFrameAdd.Enabled = false;
			this.MenuSpriteFrameAdd.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.add;
			this.MenuSpriteFrameAdd.Name = "MenuSpriteFrameAdd";
			this.MenuSpriteFrameAdd.Size = new System.Drawing.Size(185, 22);
			this.MenuSpriteFrameAdd.Text = "Image hinzufügen...";
			this.MenuSpriteFrameAdd.Click += new System.EventHandler(this.MenuSpriteFrameAdd_Click);
			// 
			// MenuSpriteFrameDel
			// 
			this.MenuSpriteFrameDel.Enabled = false;
			this.MenuSpriteFrameDel.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.delete;
			this.MenuSpriteFrameDel.Name = "MenuSpriteFrameDel";
			this.MenuSpriteFrameDel.Size = new System.Drawing.Size(185, 22);
			this.MenuSpriteFrameDel.Text = "Image löschen";
			this.MenuSpriteFrameDel.Click += new System.EventHandler(this.MenuSpriteFrameDel_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(182, 6);
			// 
			// MenuSpriteExtract
			// 
			this.MenuSpriteExtract.Enabled = false;
			this.MenuSpriteExtract.Name = "MenuSpriteExtract";
			this.MenuSpriteExtract.Size = new System.Drawing.Size(185, 22);
			this.MenuSpriteExtract.Text = "&Images entpacken...";
			this.MenuSpriteExtract.Click += new System.EventHandler(this.MenuSpriteExtract_Click);
			// 
			// MenuPalette
			// 
			this.MenuPalette.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MenuPaletteRestore,
			this.toolStripSeparator5,
			this.MenuPaletteColorHighlighLabel,
			this.toolStripSeparator6,
			this.MenuPaletteImport,
			this.MenuPaletteExport,
			this.toolStripSeparator4,
			this.MenuPaletteChart});
			this.MenuPalette.Name = "MenuPalette";
			this.MenuPalette.Size = new System.Drawing.Size(53, 20);
			this.MenuPalette.Text = "&Palette";
			// 
			// MenuPaletteRestore
			// 
			this.MenuPaletteRestore.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.RepeatHS;
			this.MenuPaletteRestore.Name = "MenuPaletteRestore";
			this.MenuPaletteRestore.Size = new System.Drawing.Size(179, 22);
			this.MenuPaletteRestore.Text = "Reset";
			this.MenuPaletteRestore.Click += new System.EventHandler(this.MenuPaletteRestore_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(176, 6);
			// 
			// MenuPaletteColorHighlighLabel
			// 
			this.MenuPaletteColorHighlighLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MenuPaletteColorHighlight});
			this.MenuPaletteColorHighlighLabel.Name = "MenuPaletteColorHighlighLabel";
			this.MenuPaletteColorHighlighLabel.Size = new System.Drawing.Size(179, 22);
			this.MenuPaletteColorHighlighLabel.Text = "Highlight Farbe";
			// 
			// MenuPaletteColorHighlight
			// 
			this.MenuPaletteColorHighlight.AccessibleName = "MenuPaletteColorHighlight";
			this.MenuPaletteColorHighlight.ColorBox = this.colorHighlightBox;
			this.MenuPaletteColorHighlight.IconMenuItem = this.MenuPaletteColorHighlighLabel;
			this.MenuPaletteColorHighlight.Name = "MenuPaletteColorHighlight";
			this.MenuPaletteColorHighlight.Size = new System.Drawing.Size(121, 21);
			this.MenuPaletteColorHighlight.Text = "Color [Transparent]";
			this.MenuPaletteColorHighlight.SelectedColorChanged += new System.EventHandler(this.MenuPaletteColorHighlight_SelectedColorChanged);
			// 
			// colorHighlightBox
			// 
			this.colorHighlightBox.AccessibleName = "colorHighlightBox";
			this.colorHighlightBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.colorHighlightBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.colorHighlightBox.IntegralHeight = false;
			this.colorHighlightBox.Location = new System.Drawing.Point(33, 3);
			this.colorHighlightBox.Name = "colorHighlightBox";
			this.colorHighlightBox.Size = new System.Drawing.Size(121, 21);
			this.colorHighlightBox.TabIndex = 2;
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(176, 6);
			// 
			// MenuPaletteImport
			// 
			this.MenuPaletteImport.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.openHS;
			this.MenuPaletteImport.Name = "MenuPaletteImport";
			this.MenuPaletteImport.Size = new System.Drawing.Size(179, 22);
			this.MenuPaletteImport.Text = "&Import...";
			this.MenuPaletteImport.Click += new System.EventHandler(this.MenuPaletteImport_Click);
			// 
			// MenuPaletteExport
			// 
			this.MenuPaletteExport.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.saveHS;
			this.MenuPaletteExport.Name = "MenuPaletteExport";
			this.MenuPaletteExport.Size = new System.Drawing.Size(179, 22);
			this.MenuPaletteExport.Text = "&Export...";
			this.MenuPaletteExport.Click += new System.EventHandler(this.MenuPaletteExport_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(176, 6);
			// 
			// MenuPaletteChart
			// 
			this.MenuPaletteChart.Name = "MenuPaletteChart";
			this.MenuPaletteChart.Size = new System.Drawing.Size(179, 22);
			this.MenuPaletteChart.Text = "Als Bild &speichern...";
			this.MenuPaletteChart.Click += new System.EventHandler(this.MenuPaletteChart_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Location = new System.Drawing.Point(0, 337);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(655, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ToolSpriteOpen,
			this.ToolSpriteSave,
			this.toolStripSeparator1,
			this.ToolFrameFirst,
			this.ToolFramePrev,
			this.ToolFrameNext,
			this.ToolFrameLast,
			this.toolStripSeparator2,
			this.ToolFrameZoomIn,
			this.ToolFrameZoomOut});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(655, 25);
			this.toolStrip.TabIndex = 3;
			this.toolStrip.Text = "toolStrip1";
			// 
			// ToolSpriteOpen
			// 
			this.ToolSpriteOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolSpriteOpen.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.openHS;
			this.ToolSpriteOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolSpriteOpen.Name = "ToolSpriteOpen";
			this.ToolSpriteOpen.Size = new System.Drawing.Size(23, 22);
			this.ToolSpriteOpen.Text = "toolStripButton1";
			this.ToolSpriteOpen.ToolTipText = "Sprite öffnen";
			this.ToolSpriteOpen.Click += new System.EventHandler(this.ToolSpriteOpen_Click);
			// 
			// ToolSpriteSave
			// 
			this.ToolSpriteSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolSpriteSave.Enabled = false;
			this.ToolSpriteSave.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.saveHS;
			this.ToolSpriteSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolSpriteSave.Name = "ToolSpriteSave";
			this.ToolSpriteSave.Size = new System.Drawing.Size(23, 22);
			this.ToolSpriteSave.Text = "toolStripButton1";
			this.ToolSpriteSave.ToolTipText = "Sprite speichern";
			this.ToolSpriteSave.Click += new System.EventHandler(this.ToolSpriteSave_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ToolFrameFirst
			// 
			this.ToolFrameFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolFrameFirst.Enabled = false;
			this.ToolFrameFirst.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.DataContainer_MoveFirstHS;
			this.ToolFrameFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolFrameFirst.Name = "ToolFrameFirst";
			this.ToolFrameFirst.Size = new System.Drawing.Size(23, 22);
			this.ToolFrameFirst.Text = "toolStripButton1";
			this.ToolFrameFirst.ToolTipText = "erste Frame";
			this.ToolFrameFirst.Click += new System.EventHandler(this.ToolFrameFirst_Click);
			// 
			// ToolFramePrev
			// 
			this.ToolFramePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolFramePrev.Enabled = false;
			this.ToolFramePrev.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.DataContainer_MovePreviousHS;
			this.ToolFramePrev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolFramePrev.Name = "ToolFramePrev";
			this.ToolFramePrev.Size = new System.Drawing.Size(23, 22);
			this.ToolFramePrev.Text = "toolStripButton1";
			this.ToolFramePrev.ToolTipText = "eine Frame zurück";
			this.ToolFramePrev.Click += new System.EventHandler(this.ToolFramePrev_Click);
			// 
			// ToolFrameNext
			// 
			this.ToolFrameNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolFrameNext.Enabled = false;
			this.ToolFrameNext.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.DataContainer_MoveNextHS;
			this.ToolFrameNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolFrameNext.Name = "ToolFrameNext";
			this.ToolFrameNext.Size = new System.Drawing.Size(23, 22);
			this.ToolFrameNext.Text = "toolStripButton1";
			this.ToolFrameNext.ToolTipText = "eine Frame vor";
			this.ToolFrameNext.Click += new System.EventHandler(this.ToolFrameNext_Click);
			// 
			// ToolFrameLast
			// 
			this.ToolFrameLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolFrameLast.Enabled = false;
			this.ToolFrameLast.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.DataContainer_MoveLastHS;
			this.ToolFrameLast.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolFrameLast.Name = "ToolFrameLast";
			this.ToolFrameLast.Size = new System.Drawing.Size(23, 22);
			this.ToolFrameLast.Text = "toolStripButton2";
			this.ToolFrameLast.ToolTipText = "letzte Frame";
			this.ToolFrameLast.Click += new System.EventHandler(this.ToolFrameLast_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// ToolFrameZoomIn
			// 
			this.ToolFrameZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolFrameZoomIn.Enabled = false;
			this.ToolFrameZoomIn.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.zoom_in;
			this.ToolFrameZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolFrameZoomIn.Name = "ToolFrameZoomIn";
			this.ToolFrameZoomIn.Size = new System.Drawing.Size(23, 22);
			this.ToolFrameZoomIn.Text = "Zoom +1";
			this.ToolFrameZoomIn.Click += new System.EventHandler(this.ToolFrameZoomIn_Click);
			// 
			// ToolFrameZoomOut
			// 
			this.ToolFrameZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolFrameZoomOut.Enabled = false;
			this.ToolFrameZoomOut.Image = global::eAthenaStudio.Plugins.EditSprite.Properties.Resources.zoom_out;
			this.ToolFrameZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolFrameZoomOut.Name = "ToolFrameZoomOut";
			this.ToolFrameZoomOut.Size = new System.Drawing.Size(23, 22);
			this.ToolFrameZoomOut.Text = "Zoom -1";
			this.ToolFrameZoomOut.Click += new System.EventHandler(this.ToolFrameZoomOut_Click);
			// 
			// dockPanel
			// 
			this.dockPanel.ActiveAutoHideContent = null;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.dockPanel.Location = new System.Drawing.Point(0, 49);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(655, 288);
			dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
			autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
			tabGradient1.EndColor = System.Drawing.SystemColors.Control;
			tabGradient1.StartColor = System.Drawing.SystemColors.Control;
			tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			autoHideStripSkin1.TabGradient = tabGradient1;
			dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
			tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
			dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
			dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
			dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
			tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
			dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
			tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
			tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
			tabGradient5.EndColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient5.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
			tabGradient5.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
			dockPanelGradient3.EndColor = System.Drawing.SystemColors.ActiveCaption;
			dockPanelGradient3.StartColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
			tabGradient6.EndColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient6.StartColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient6.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
			tabGradient7.EndColor = System.Drawing.Color.Transparent;
			tabGradient7.StartColor = System.Drawing.Color.Transparent;
			tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
			dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
			dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
			this.dockPanel.Skin = dockPanelSkin1;
			this.dockPanel.TabIndex = 7;
			// 
			// colorComboBox1
			// 
			this.colorComboBox1.AccessibleName = "toolStripColorComboBox1";
			this.colorComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.colorComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.colorComboBox1.IntegralHeight = false;
			this.colorComboBox1.Location = new System.Drawing.Point(33, 31);
			this.colorComboBox1.Name = "colorComboBox1";
			this.colorComboBox1.Size = new System.Drawing.Size(121, 21);
			this.colorComboBox1.TabIndex = 2;
			// 
			// frmSpriteEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(655, 359);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "frmSpriteEditor";
			this.Text = "Sprite Editor";
			this.Load += new System.EventHandler(this.frmSpriteEditor_Load);
			this.Resize += new System.EventHandler(this.frmSpriteEditor_Resize);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripMenuItem MenuEditor;
		private System.Windows.Forms.ToolStripMenuItem MenuEditorClose;
		private System.Windows.Forms.ToolStripMenuItem MenuSprite;
		private System.Windows.Forms.ToolStripMenuItem MenuSpriteOpen;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripMenuItem MenuSpriteSave;
		private System.Windows.Forms.ToolStripButton ToolSpriteOpen;
		private System.Windows.Forms.ToolStripButton ToolSpriteSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ToolFramePrev;
		private System.Windows.Forms.ToolStripButton ToolFrameNext;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton ToolFrameFirst;
		private System.Windows.Forms.ToolStripButton ToolFrameLast;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem MenuSpriteExtract;
		private System.Windows.Forms.ToolStripMenuItem MenuPalette;
		private System.Windows.Forms.ToolStripMenuItem MenuPaletteImport;
		private System.Windows.Forms.ToolStripMenuItem MenuPaletteExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem MenuPaletteChart;
		private System.Windows.Forms.ToolStripMenuItem MenuPaletteRestore;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton ToolFrameZoomIn;
		private System.Windows.Forms.ToolStripButton ToolFrameZoomOut;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private eAthenaStudio.Plugins.EditSprite.Controls.ColorComboBox colorComboBox1;
		private System.Windows.Forms.ToolStripMenuItem MenuPaletteColorHighlighLabel;
		private eAthenaStudio.Plugins.EditSprite.Controls.ToolStripColorComboBox MenuPaletteColorHighlight;
		private eAthenaStudio.Plugins.EditSprite.Controls.ColorComboBox colorHighlightBox;
		private GodLesZ.Library.Docking.DockPanel dockPanel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem MenuSpriteFrameAdd;
		private System.Windows.Forms.ToolStripMenuItem MenuSpriteFrameDel;

	}
}