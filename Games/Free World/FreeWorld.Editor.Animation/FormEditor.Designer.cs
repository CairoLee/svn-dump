using FreeWorld.Engine.Tools.XnaFake;

namespace FreeWorld.Editor.Animation {
	partial class FormEditor {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditor));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditorNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditorSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditorOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuEditorClose = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.MenuToolStripNew = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripOpen = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuToolStripPlay = new System.Windows.Forms.ToolStripButton();
			this.MenuToolStripStop = new System.Windows.Forms.ToolStripButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.pnlTilesetThumbs = new System.Windows.Forms.Panel();
			this.listFrames = new System.Windows.Forms.ListBox();
			this.ListFramesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ListFramesContextCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.ListFramesContextPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ListFramesContextClear = new System.Windows.Forms.ToolStripMenuItem();
			this.PanelTilesetChoose = new System.Windows.Forms.Panel();
			this.cmbTilesets = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnCharPosReset = new System.Windows.Forms.Button();
			this.chkMousePointer = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SliderCharY = new System.Windows.Forms.TrackBar();
			this.SliderCharX = new System.Windows.Forms.TrackBar();
			this.comboCharTilesets = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkCharDisplay = new System.Windows.Forms.CheckBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.comboFrameCount = new System.Windows.Forms.ComboBox();
			this.listFrameImages = new System.Windows.Forms.ListView();
			this.colImageNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colImageType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listFrameImagesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.listFrameImagesContextDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblRotate = new System.Windows.Forms.Label();
			this.SliderRotate = new System.Windows.Forms.TrackBar();
			this.label12 = new System.Windows.Forms.Label();
			this.SliderColorBlue = new System.Windows.Forms.TrackBar();
			this.label7 = new System.Windows.Forms.Label();
			this.SliderColorGreen = new System.Windows.Forms.TrackBar();
			this.label9 = new System.Windows.Forms.Label();
			this.SliderColorRed = new System.Windows.Forms.TrackBar();
			this.label10 = new System.Windows.Forms.Label();
			this.ColorBox = new System.Windows.Forms.PictureBox();
			this.label8 = new System.Windows.Forms.Label();
			this.lblAlpha = new System.Windows.Forms.Label();
			this.SliderTrans = new System.Windows.Forms.TrackBar();
			this.label6 = new System.Windows.Forms.Label();
			this.chkMirrorVerti = new System.Windows.Forms.CheckBox();
			this.chkMirrorHori = new System.Windows.Forms.CheckBox();
			this.lblWidth = new System.Windows.Forms.Label();
			this.sliderScale = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuEditorImportRpgMaker = new System.Windows.Forms.ToolStripMenuItem();
			this.RenderDisplayAnimation = new FreeWorld.Engine.Tools.XnaFake.TileDisplay();
			this.chkDrawLastFrame = new System.Windows.Forms.CheckBox();
			this.chkSelectedImageIsBackground = new System.Windows.Forms.CheckBox();
			this.numFrameTime = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.ListFramesContextMenu.SuspendLayout();
			this.PanelTilesetChoose.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SliderCharY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderCharX)).BeginInit();
			this.panel4.SuspendLayout();
			this.listFrameImagesContextMenu.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SliderRotate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderColorBlue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderColorGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderColorRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderTrans)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sliderScale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFrameTime)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 616);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(773, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(56, 17);
			this.StatusLabel.Text = "Loading..";
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(773, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// editorToolStripMenuItem
			// 
			this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditorNew,
            this.menuEditorSave,
            this.menuEditorOpen,
            this.toolStripSeparator2,
            this.menuEditorImportRpgMaker,
            this.toolStripSeparator4,
            this.menuEditorClose});
			this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
			this.editorToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.editorToolStripMenuItem.Text = "Editor";
			// 
			// menuEditorNew
			// 
			this.menuEditorNew.Name = "menuEditorNew";
			this.menuEditorNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.menuEditorNew.Size = new System.Drawing.Size(207, 22);
			this.menuEditorNew.Text = "Neue Animation";
			this.menuEditorNew.Click += new System.EventHandler(this.MenuEditorNew_Click);
			// 
			// menuEditorSave
			// 
			this.menuEditorSave.Name = "menuEditorSave";
			this.menuEditorSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.menuEditorSave.Size = new System.Drawing.Size(207, 22);
			this.menuEditorSave.Text = "Speichern";
			this.menuEditorSave.Click += new System.EventHandler(this.MenuEditorSave_Click);
			// 
			// menuEditorOpen
			// 
			this.menuEditorOpen.Name = "menuEditorOpen";
			this.menuEditorOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.menuEditorOpen.Size = new System.Drawing.Size(207, 22);
			this.menuEditorOpen.Text = "Öffnen";
			this.menuEditorOpen.Click += new System.EventHandler(this.MenuEditorOpen_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(204, 6);
			// 
			// menuEditorClose
			// 
			this.menuEditorClose.Image = global::FreeWorld.Editor.Animation.Properties.Resources.Program_Exit;
			this.menuEditorClose.Name = "menuEditorClose";
			this.menuEditorClose.Size = new System.Drawing.Size(207, 22);
			this.menuEditorClose.Text = "Beenden";
			this.menuEditorClose.Click += new System.EventHandler(this.MenuEditorClose_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripNew,
            this.MenuToolStripOpen,
            this.MenuToolStripSave,
            this.toolStripSeparator3,
            this.MenuToolStripPlay,
            this.MenuToolStripStop});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(773, 31);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// MenuToolStripNew
			// 
			this.MenuToolStripNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripNew.Image = global::FreeWorld.Editor.Animation.Properties.Resources.Show_Animation;
			this.MenuToolStripNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripNew.Name = "MenuToolStripNew";
			this.MenuToolStripNew.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripNew.Text = "Neue Animation";
			this.MenuToolStripNew.Click += new System.EventHandler(this.MenuEditorNew_Click);
			// 
			// MenuToolStripOpen
			// 
			this.MenuToolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripOpen.Image = global::FreeWorld.Editor.Animation.Properties.Resources.Open_Animation;
			this.MenuToolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripOpen.Name = "MenuToolStripOpen";
			this.MenuToolStripOpen.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripOpen.Text = "Animation öffnen";
			this.MenuToolStripOpen.Click += new System.EventHandler(this.MenuEditorOpen_Click);
			// 
			// MenuToolStripSave
			// 
			this.MenuToolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripSave.Image = global::FreeWorld.Editor.Animation.Properties.Resources.Save_Animation;
			this.MenuToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripSave.Name = "MenuToolStripSave";
			this.MenuToolStripSave.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripSave.Text = "Animation speichern";
			this.MenuToolStripSave.Click += new System.EventHandler(this.MenuEditorSave_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			// 
			// MenuToolStripPlay
			// 
			this.MenuToolStripPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripPlay.Image = global::FreeWorld.Editor.Animation.Properties.Resources.Animation_Play;
			this.MenuToolStripPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripPlay.Name = "MenuToolStripPlay";
			this.MenuToolStripPlay.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripPlay.Text = "Animation abspieln";
			this.MenuToolStripPlay.Click += new System.EventHandler(this.MenuToolStripPlay_Click);
			// 
			// MenuToolStripStop
			// 
			this.MenuToolStripStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolStripStop.Enabled = false;
			this.MenuToolStripStop.Image = global::FreeWorld.Editor.Animation.Properties.Resources.Animation_Stop;
			this.MenuToolStripStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolStripStop.Name = "MenuToolStripStop";
			this.MenuToolStripStop.Size = new System.Drawing.Size(28, 28);
			this.MenuToolStripStop.Text = "Animation stopen";
			this.MenuToolStripStop.Click += new System.EventHandler(this.MenuToolStripStop_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 306F));
			this.tableLayoutPanel1.Controls.Add(this.pnlTilesetThumbs, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.RenderDisplayAnimation, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.listFrames, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.PanelTilesetChoose, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.listFrameImages, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 561);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// pnlTilesetThumbs
			// 
			this.pnlTilesetThumbs.AutoScroll = true;
			this.pnlTilesetThumbs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tableLayoutPanel1.SetColumnSpan(this.pnlTilesetThumbs, 3);
			this.pnlTilesetThumbs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlTilesetThumbs.Location = new System.Drawing.Point(3, 439);
			this.pnlTilesetThumbs.Name = "pnlTilesetThumbs";
			this.pnlTilesetThumbs.Size = new System.Drawing.Size(767, 119);
			this.pnlTilesetThumbs.TabIndex = 4;
			// 
			// listFrames
			// 
			this.listFrames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listFrames.ContextMenuStrip = this.ListFramesContextMenu;
			this.listFrames.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listFrames.FormattingEnabled = true;
			this.listFrames.Location = new System.Drawing.Point(3, 211);
			this.listFrames.Name = "listFrames";
			this.listFrames.Size = new System.Drawing.Size(78, 193);
			this.listFrames.TabIndex = 1;
			this.listFrames.SelectedIndexChanged += new System.EventHandler(this.ListFrames_SelectedIndexChanged);
			// 
			// ListFramesContextMenu
			// 
			this.ListFramesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListFramesContextCopy,
            this.ListFramesContextPaste,
            this.toolStripSeparator1,
            this.ListFramesContextClear});
			this.ListFramesContextMenu.Name = "ListFramesContextMenu";
			this.ListFramesContextMenu.Size = new System.Drawing.Size(122, 76);
			this.ListFramesContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ListFramesContextMenu_Opening);
			// 
			// ListFramesContextCopy
			// 
			this.ListFramesContextCopy.Name = "ListFramesContextCopy";
			this.ListFramesContextCopy.Size = new System.Drawing.Size(121, 22);
			this.ListFramesContextCopy.Text = "Kopieren";
			this.ListFramesContextCopy.Click += new System.EventHandler(this.ListFramesContextCopy_Click);
			// 
			// ListFramesContextPaste
			// 
			this.ListFramesContextPaste.Name = "ListFramesContextPaste";
			this.ListFramesContextPaste.Size = new System.Drawing.Size(121, 22);
			this.ListFramesContextPaste.Text = "Einfügen";
			this.ListFramesContextPaste.Click += new System.EventHandler(this.ListFramesContextPaste_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
			// 
			// ListFramesContextClear
			// 
			this.ListFramesContextClear.Name = "ListFramesContextClear";
			this.ListFramesContextClear.Size = new System.Drawing.Size(121, 22);
			this.ListFramesContextClear.Text = "Leeren";
			this.ListFramesContextClear.Click += new System.EventHandler(this.ListFramesContextClear_Click);
			// 
			// PanelTilesetChoose
			// 
			this.PanelTilesetChoose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelTilesetChoose.Controls.Add(this.cmbTilesets);
			this.PanelTilesetChoose.Controls.Add(this.label13);
			this.PanelTilesetChoose.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelTilesetChoose.Location = new System.Drawing.Point(470, 410);
			this.PanelTilesetChoose.Name = "PanelTilesetChoose";
			this.PanelTilesetChoose.Size = new System.Drawing.Size(300, 23);
			this.PanelTilesetChoose.TabIndex = 7;
			// 
			// cmbTilesets
			// 
			this.cmbTilesets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTilesets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTilesets.FormattingEnabled = true;
			this.cmbTilesets.Location = new System.Drawing.Point(41, 0);
			this.cmbTilesets.Name = "cmbTilesets";
			this.cmbTilesets.Size = new System.Drawing.Size(252, 21);
			this.cmbTilesets.TabIndex = 1;
			this.cmbTilesets.SelectedIndexChanged += new System.EventHandler(this.comboTileset_SelectedIndexChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(2, 4);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(38, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "Tileset";
			// 
			// panel2
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.numFrameTime);
			this.panel2.Controls.Add(this.chkDrawLastFrame);
			this.panel2.Controls.Add(this.btnCharPosReset);
			this.panel2.Controls.Add(this.chkMousePointer);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.SliderCharY);
			this.panel2.Controls.Add(this.SliderCharX);
			this.panel2.Controls.Add(this.comboCharTilesets);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.chkCharDisplay);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(767, 70);
			this.panel2.TabIndex = 9;
			// 
			// btnCharPosReset
			// 
			this.btnCharPosReset.Location = new System.Drawing.Point(314, 31);
			this.btnCharPosReset.Name = "btnCharPosReset";
			this.btnCharPosReset.Size = new System.Drawing.Size(44, 23);
			this.btnCharPosReset.TabIndex = 8;
			this.btnCharPosReset.Text = "Reset";
			this.btnCharPosReset.UseVisualStyleBackColor = true;
			this.btnCharPosReset.Click += new System.EventHandler(this.btnCharPosReset_Click);
			// 
			// chkMousePointer
			// 
			this.chkMousePointer.AutoSize = true;
			this.chkMousePointer.Location = new System.Drawing.Point(464, 3);
			this.chkMousePointer.Name = "chkMousePointer";
			this.chkMousePointer.Size = new System.Drawing.Size(98, 17);
			this.chkMousePointer.TabIndex = 7;
			this.chkMousePointer.Text = "Maus anzeigen";
			this.chkMousePointer.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Y";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "X";
			// 
			// SliderCharY
			// 
			this.SliderCharY.AutoSize = false;
			this.SliderCharY.LargeChange = 1;
			this.SliderCharY.Location = new System.Drawing.Point(31, 45);
			this.SliderCharY.Maximum = 360;
			this.SliderCharY.Name = "SliderCharY";
			this.SliderCharY.Size = new System.Drawing.Size(282, 22);
			this.SliderCharY.TabIndex = 4;
			this.SliderCharY.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// SliderCharX
			// 
			this.SliderCharX.AutoSize = false;
			this.SliderCharX.LargeChange = 1;
			this.SliderCharX.Location = new System.Drawing.Point(31, 24);
			this.SliderCharX.Maximum = 360;
			this.SliderCharX.Name = "SliderCharX";
			this.SliderCharX.Size = new System.Drawing.Size(282, 22);
			this.SliderCharX.TabIndex = 3;
			this.SliderCharX.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// comboCharTilesets
			// 
			this.comboCharTilesets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCharTilesets.FormattingEnabled = true;
			this.comboCharTilesets.Location = new System.Drawing.Point(38, 1);
			this.comboCharTilesets.Name = "comboCharTilesets";
			this.comboCharTilesets.Size = new System.Drawing.Size(196, 21);
			this.comboCharTilesets.TabIndex = 2;
			this.comboCharTilesets.SelectedIndexChanged += new System.EventHandler(this.comboCharTilesets_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Char";
			// 
			// chkCharDisplay
			// 
			this.chkCharDisplay.AutoSize = true;
			this.chkCharDisplay.Checked = true;
			this.chkCharDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCharDisplay.Location = new System.Drawing.Point(240, 3);
			this.chkCharDisplay.Name = "chkCharDisplay";
			this.chkCharDisplay.Size = new System.Drawing.Size(73, 17);
			this.chkCharDisplay.TabIndex = 0;
			this.chkCharDisplay.Text = "Darstellen";
			this.chkCharDisplay.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.comboFrameCount);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 410);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(78, 23);
			this.panel4.TabIndex = 11;
			// 
			// comboFrameCount
			// 
			this.comboFrameCount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboFrameCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboFrameCount.FormattingEnabled = true;
			this.comboFrameCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
			this.comboFrameCount.Location = new System.Drawing.Point(0, 0);
			this.comboFrameCount.Name = "comboFrameCount";
			this.comboFrameCount.Size = new System.Drawing.Size(76, 21);
			this.comboFrameCount.TabIndex = 6;
			this.comboFrameCount.SelectedIndexChanged += new System.EventHandler(this.comboFrameCount_SelectedIndexChanged);
			// 
			// listFrameImages
			// 
			this.listFrameImages.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listFrameImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listFrameImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImageNum,
            this.colImageType});
			this.listFrameImages.ContextMenuStrip = this.listFrameImagesContextMenu;
			this.listFrameImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listFrameImages.FullRowSelect = true;
			this.listFrameImages.GridLines = true;
			this.listFrameImages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listFrameImages.HideSelection = false;
			this.listFrameImages.Location = new System.Drawing.Point(3, 79);
			this.listFrameImages.MultiSelect = false;
			this.listFrameImages.Name = "listFrameImages";
			this.listFrameImages.Size = new System.Drawing.Size(78, 126);
			this.listFrameImages.TabIndex = 8;
			this.listFrameImages.UseCompatibleStateImageBehavior = false;
			this.listFrameImages.View = System.Windows.Forms.View.Details;
			this.listFrameImages.SelectedIndexChanged += new System.EventHandler(this.listFrameImages_SelectedIndexChanged);
			// 
			// colImageNum
			// 
			this.colImageNum.Text = "#";
			this.colImageNum.Width = 23;
			// 
			// colImageType
			// 
			this.colImageType.Text = "Typ";
			this.colImageType.Width = 37;
			// 
			// listFrameImagesContextMenu
			// 
			this.listFrameImagesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listFrameImagesContextDelete});
			this.listFrameImagesContextMenu.Name = "listFrameImagesContextMenu";
			this.listFrameImagesContextMenu.Size = new System.Drawing.Size(119, 26);
			// 
			// listFrameImagesContextDelete
			// 
			this.listFrameImagesContextDelete.Name = "listFrameImagesContextDelete";
			this.listFrameImagesContextDelete.Size = new System.Drawing.Size(118, 22);
			this.listFrameImagesContextDelete.Text = "Löschen";
			this.listFrameImagesContextDelete.Click += new System.EventHandler(this.listFrameImagesContextDelete_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.chkSelectedImageIsBackground);
			this.panel1.Controls.Add(this.lblRotate);
			this.panel1.Controls.Add(this.SliderRotate);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.SliderColorBlue);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.SliderColorGreen);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.SliderColorRed);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.ColorBox);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.lblAlpha);
			this.panel1.Controls.Add(this.SliderTrans);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.chkMirrorVerti);
			this.panel1.Controls.Add(this.chkMirrorHori);
			this.panel1.Controls.Add(this.lblWidth);
			this.panel1.Controls.Add(this.sliderScale);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(470, 79);
			this.panel1.Name = "panel1";
			this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
			this.panel1.Size = new System.Drawing.Size(300, 325);
			this.panel1.TabIndex = 3;
			// 
			// lblRotate
			// 
			this.lblRotate.AutoSize = true;
			this.lblRotate.Location = new System.Drawing.Point(259, 67);
			this.lblRotate.Name = "lblRotate";
			this.lblRotate.Size = new System.Drawing.Size(17, 13);
			this.lblRotate.TabIndex = 23;
			this.lblRotate.Text = "0°";
			// 
			// SliderRotate
			// 
			this.SliderRotate.AutoSize = false;
			this.SliderRotate.Enabled = false;
			this.SliderRotate.Location = new System.Drawing.Point(92, 64);
			this.SliderRotate.Maximum = 360;
			this.SliderRotate.Name = "SliderRotate";
			this.SliderRotate.Size = new System.Drawing.Size(170, 25);
			this.SliderRotate.TabIndex = 22;
			this.SliderRotate.TickStyle = System.Windows.Forms.TickStyle.None;
			this.SliderRotate.Scroll += new System.EventHandler(this.SliderRotate_Scroll);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(4, 67);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "Drehung";
			// 
			// SliderColorBlue
			// 
			this.SliderColorBlue.AutoSize = false;
			this.SliderColorBlue.Enabled = false;
			this.SliderColorBlue.Location = new System.Drawing.Point(168, 163);
			this.SliderColorBlue.Maximum = 255;
			this.SliderColorBlue.Name = "SliderColorBlue";
			this.SliderColorBlue.Size = new System.Drawing.Size(122, 22);
			this.SliderColorBlue.TabIndex = 20;
			this.SliderColorBlue.TickStyle = System.Windows.Forms.TickStyle.None;
			this.SliderColorBlue.Scroll += new System.EventHandler(this.SliderColorBlue_Scroll);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(148, 166);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "B";
			// 
			// SliderColorGreen
			// 
			this.SliderColorGreen.AutoSize = false;
			this.SliderColorGreen.Enabled = false;
			this.SliderColorGreen.Location = new System.Drawing.Point(168, 142);
			this.SliderColorGreen.Maximum = 255;
			this.SliderColorGreen.Name = "SliderColorGreen";
			this.SliderColorGreen.Size = new System.Drawing.Size(122, 22);
			this.SliderColorGreen.TabIndex = 18;
			this.SliderColorGreen.TickStyle = System.Windows.Forms.TickStyle.None;
			this.SliderColorGreen.Scroll += new System.EventHandler(this.SliderColorGreen_Scroll);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(148, 145);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(15, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "G";
			// 
			// SliderColorRed
			// 
			this.SliderColorRed.AutoSize = false;
			this.SliderColorRed.Enabled = false;
			this.SliderColorRed.Location = new System.Drawing.Point(168, 122);
			this.SliderColorRed.Maximum = 255;
			this.SliderColorRed.Name = "SliderColorRed";
			this.SliderColorRed.Size = new System.Drawing.Size(122, 22);
			this.SliderColorRed.TabIndex = 16;
			this.SliderColorRed.TickStyle = System.Windows.Forms.TickStyle.None;
			this.SliderColorRed.Scroll += new System.EventHandler(this.SliderColorRed_Scroll);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(148, 124);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(15, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "R";
			// 
			// ColorBox
			// 
			this.ColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorBox.Enabled = false;
			this.ColorBox.Location = new System.Drawing.Point(105, 122);
			this.ColorBox.Name = "ColorBox";
			this.ColorBox.Size = new System.Drawing.Size(30, 18);
			this.ColorBox.TabIndex = 14;
			this.ColorBox.TabStop = false;
			this.ColorBox.Click += new System.EventHandler(this.ColorBox_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(4, 123);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "Farbüberlagerung";
			// 
			// lblAlpha
			// 
			this.lblAlpha.AutoSize = true;
			this.lblAlpha.Location = new System.Drawing.Point(259, 92);
			this.lblAlpha.Name = "lblAlpha";
			this.lblAlpha.Size = new System.Drawing.Size(21, 13);
			this.lblAlpha.TabIndex = 11;
			this.lblAlpha.Text = "0%";
			// 
			// SliderTrans
			// 
			this.SliderTrans.AutoSize = false;
			this.SliderTrans.Enabled = false;
			this.SliderTrans.Location = new System.Drawing.Point(92, 89);
			this.SliderTrans.Maximum = 255;
			this.SliderTrans.Name = "SliderTrans";
			this.SliderTrans.Size = new System.Drawing.Size(170, 25);
			this.SliderTrans.TabIndex = 10;
			this.SliderTrans.TickStyle = System.Windows.Forms.TickStyle.None;
			this.SliderTrans.Scroll += new System.EventHandler(this.SliderTrans_Scroll);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 92);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Transparenz";
			// 
			// chkMirrorVerti
			// 
			this.chkMirrorVerti.AutoSize = true;
			this.chkMirrorVerti.Enabled = false;
			this.chkMirrorVerti.Location = new System.Drawing.Point(153, 39);
			this.chkMirrorVerti.Name = "chkMirrorVerti";
			this.chkMirrorVerti.Size = new System.Drawing.Size(105, 17);
			this.chkMirrorVerti.TabIndex = 8;
			this.chkMirrorVerti.Text = "Vertikal Spiegeln";
			this.chkMirrorVerti.UseVisualStyleBackColor = true;
			this.chkMirrorVerti.CheckedChanged += new System.EventHandler(this.chkMirrorVerti_CheckedChanged);
			// 
			// chkMirrorHori
			// 
			this.chkMirrorHori.AutoSize = true;
			this.chkMirrorHori.Enabled = false;
			this.chkMirrorHori.Location = new System.Drawing.Point(7, 39);
			this.chkMirrorHori.Name = "chkMirrorHori";
			this.chkMirrorHori.Size = new System.Drawing.Size(117, 17);
			this.chkMirrorHori.TabIndex = 7;
			this.chkMirrorHori.Text = "Horizontal Spiegeln";
			this.chkMirrorHori.UseVisualStyleBackColor = true;
			this.chkMirrorHori.CheckedChanged += new System.EventHandler(this.chkMirrorHori_CheckedChanged);
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(259, 8);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(33, 13);
			this.lblWidth.TabIndex = 2;
			this.lblWidth.Text = "100%";
			// 
			// sliderScale
			// 
			this.sliderScale.AutoSize = false;
			this.sliderScale.Enabled = false;
			this.sliderScale.Location = new System.Drawing.Point(39, 5);
			this.sliderScale.Maximum = 300;
			this.sliderScale.Minimum = 1;
			this.sliderScale.Name = "sliderScale";
			this.sliderScale.Size = new System.Drawing.Size(223, 25);
			this.sliderScale.TabIndex = 1;
			this.sliderScale.TickStyle = System.Windows.Forms.TickStyle.None;
			this.sliderScale.Value = 100;
			this.sliderScale.Scroll += new System.EventHandler(this.sliderScale_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Scale";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(204, 6);
			// 
			// menuEditorImportRpgMaker
			// 
			this.menuEditorImportRpgMaker.Name = "menuEditorImportRpgMaker";
			this.menuEditorImportRpgMaker.Size = new System.Drawing.Size(207, 22);
			this.menuEditorImportRpgMaker.Text = "Import RPG Maker Export";
			this.menuEditorImportRpgMaker.Click += new System.EventHandler(this.menuEditorImportRpgMaker_Click);
			// 
			// RenderDisplayAnimation
			// 
			this.RenderDisplayAnimation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RenderDisplayAnimation.Location = new System.Drawing.Point(87, 79);
			this.RenderDisplayAnimation.Name = "RenderDisplayAnimation";
			this.tableLayoutPanel1.SetRowSpan(this.RenderDisplayAnimation, 3);
			this.RenderDisplayAnimation.Size = new System.Drawing.Size(377, 354);
			this.RenderDisplayAnimation.TabIndex = 0;
			this.RenderDisplayAnimation.TargetGraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
			this.RenderDisplayAnimation.Text = "AnimationDisplay";
			this.RenderDisplayAnimation.Click += new System.EventHandler(this.RenderDisplayAnimation_Click);
			this.RenderDisplayAnimation.MouseEnter += new System.EventHandler(this.RenderDisplayAnimation_MouseEnter);
			this.RenderDisplayAnimation.MouseLeave += new System.EventHandler(this.RenderDisplayAnimation_MouseLeave);
			this.RenderDisplayAnimation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RenderDisplayAnimation_MouseUp);
			// 
			// chkDrawLastFrame
			// 
			this.chkDrawLastFrame.AutoSize = true;
			this.chkDrawLastFrame.Location = new System.Drawing.Point(464, 21);
			this.chkDrawLastFrame.Name = "chkDrawLastFrame";
			this.chkDrawLastFrame.Size = new System.Drawing.Size(133, 17);
			this.chkDrawLastFrame.TabIndex = 9;
			this.chkDrawLastFrame.Text = "Letzte Frame anzeigen";
			this.chkDrawLastFrame.UseVisualStyleBackColor = true;
			// 
			// chkSelectedImageIsBackground
			// 
			this.chkSelectedImageIsBackground.AutoSize = true;
			this.chkSelectedImageIsBackground.Location = new System.Drawing.Point(7, 190);
			this.chkSelectedImageIsBackground.Name = "chkSelectedImageIsBackground";
			this.chkSelectedImageIsBackground.Size = new System.Drawing.Size(78, 17);
			this.chkSelectedImageIsBackground.TabIndex = 24;
			this.chkSelectedImageIsBackground.Text = "Hintergund";
			this.chkSelectedImageIsBackground.UseVisualStyleBackColor = true;
			this.chkSelectedImageIsBackground.CheckedChanged += new System.EventHandler(this.chkSelectedImageIsBackground_CheckedChanged);
			// 
			// numFrameTime
			// 
			this.numFrameTime.Location = new System.Drawing.Point(525, 39);
			this.numFrameTime.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.numFrameTime.Name = "numFrameTime";
			this.numFrameTime.Size = new System.Drawing.Size(50, 20);
			this.numFrameTime.TabIndex = 10;
			this.numFrameTime.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numFrameTime.ValueChanged += new System.EventHandler(this.numFrameTime_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(461, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Frame time";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(578, 41);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(20, 13);
			this.label11.TabIndex = 12;
			this.label11.Text = "ms";
			// 
			// FormEditor
			// 
			this.ClientSize = new System.Drawing.Size(773, 638);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(781, 670);
			this.Name = "FormEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "The Free World - Animation Editor v.01 Alpha";
			this.Load += new System.EventHandler(this.frmEditor_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditor_KeyDown);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ListFramesContextMenu.ResumeLayout(false);
			this.PanelTilesetChoose.ResumeLayout(false);
			this.PanelTilesetChoose.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SliderCharY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderCharX)).EndInit();
			this.panel4.ResumeLayout(false);
			this.listFrameImagesContextMenu.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SliderRotate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderColorBlue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderColorGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderColorRed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SliderTrans)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sliderScale)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFrameTime)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStripMenuItem menuEditorClose;
		private TileDisplay RenderDisplayAnimation;
		private System.Windows.Forms.ListBox listFrames;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblAlpha;
		private System.Windows.Forms.TrackBar SliderTrans;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkMirrorVerti;
		private System.Windows.Forms.CheckBox chkMirrorHori;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.TrackBar sliderScale;
		private System.Windows.Forms.TrackBar SliderColorBlue;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TrackBar SliderColorGreen;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TrackBar SliderColorRed;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.PictureBox ColorBox;
		private System.Windows.Forms.Panel pnlTilesetThumbs;
		private System.Windows.Forms.Label lblRotate;
		private System.Windows.Forms.TrackBar SliderRotate;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel PanelTilesetChoose;
		private System.Windows.Forms.ComboBox cmbTilesets;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ContextMenuStrip ListFramesContextMenu;
		private System.Windows.Forms.ToolStripMenuItem ListFramesContextCopy;
		private System.Windows.Forms.ToolStripMenuItem ListFramesContextPaste;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ListFramesContextClear;
		private System.Windows.Forms.ToolStripMenuItem menuEditorSave;
		private System.Windows.Forms.ToolStripMenuItem menuEditorOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuEditorNew;
		private System.Windows.Forms.ToolStripButton MenuToolStripNew;
		private System.Windows.Forms.ToolStripButton MenuToolStripOpen;
		private System.Windows.Forms.ToolStripButton MenuToolStripSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton MenuToolStripPlay;
		private System.Windows.Forms.ToolStripButton MenuToolStripStop;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.ListView listFrameImages;
		private System.Windows.Forms.ColumnHeader colImageNum;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox comboCharTilesets;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkCharDisplay;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar SliderCharY;
		private System.Windows.Forms.TrackBar SliderCharX;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox comboFrameCount;
		private System.Windows.Forms.CheckBox chkMousePointer;
		private System.Windows.Forms.Button btnCharPosReset;
		private System.Windows.Forms.ColumnHeader colImageType;
		private System.Windows.Forms.ContextMenuStrip listFrameImagesContextMenu;
		private System.Windows.Forms.ToolStripMenuItem listFrameImagesContextDelete;
		private System.Windows.Forms.ToolStripMenuItem menuEditorImportRpgMaker;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.CheckBox chkDrawLastFrame;
		private System.Windows.Forms.CheckBox chkSelectedImageIsBackground;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numFrameTime;
	}
}

