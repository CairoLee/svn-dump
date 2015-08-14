namespace GodLesZ.eAthenaEditor.Editor {
	partial class frmMain {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuMainFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainFileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMainFileClose = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainEditCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainEditPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainEditCut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMainEditSearch = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainEditReplace = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainEditSearchAgain = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainEditSearchAgainReverse = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainOptionsSpaces = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainOptionsNewslines = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainOptionsLinenumbers = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMainOptionsCurrentRow = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainOptionsBracketMatch = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMainOptionsTabSize = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainOptionsFontSize = new System.Windows.Forms.ToolStripMenuItem();
			this.fileTabs = new System.Windows.Forms.TabControl();
			this.menuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFile,
            this.menuMainEdit,
            this.menuMainOptions});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(567, 24);
			this.menuMain.TabIndex = 2;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuMainFile
			// 
			this.menuMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFileNew,
            this.menuMainFileOpen,
            this.menuMainFileSave,
            this.menuMainFileSaveAs,
            this.toolStripSeparator3,
            this.menuMainFileClose,
            this.toolStripSeparator1,
            this.menuMainFileExit});
			this.menuMainFile.Name = "menuMainFile";
			this.menuMainFile.Size = new System.Drawing.Size(44, 20);
			this.menuMainFile.Text = "&Datei";
			// 
			// menuMainFileNew
			// 
			this.menuMainFileNew.Image = global::GodLesZ.eAthenaEditor.Editor.Properties.Resources.ImageFileNew;
			this.menuMainFileNew.Name = "menuMainFileNew";
			this.menuMainFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.menuMainFileNew.Size = new System.Drawing.Size(290, 22);
			this.menuMainFileNew.Text = "&Neu";
			this.menuMainFileNew.Click += new System.EventHandler(this.menuMainFileNew_Click);
			// 
			// menuMainFileOpen
			// 
			this.menuMainFileOpen.Image = global::GodLesZ.eAthenaEditor.Editor.Properties.Resources.ImageFileOpen;
			this.menuMainFileOpen.Name = "menuMainFileOpen";
			this.menuMainFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.menuMainFileOpen.Size = new System.Drawing.Size(290, 22);
			this.menuMainFileOpen.Text = "&Öffnen...";
			this.menuMainFileOpen.Click += new System.EventHandler(this.menuMainFileOpen_Click);
			// 
			// menuMainFileSave
			// 
			this.menuMainFileSave.Image = global::GodLesZ.eAthenaEditor.Editor.Properties.Resources.ImageFileSave;
			this.menuMainFileSave.Name = "menuMainFileSave";
			this.menuMainFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.menuMainFileSave.Size = new System.Drawing.Size(290, 22);
			this.menuMainFileSave.Text = "&Speichern";
			this.menuMainFileSave.Click += new System.EventHandler(this.menuMainFileSave_Click);
			// 
			// menuMainFileSaveAs
			// 
			this.menuMainFileSaveAs.Image = global::GodLesZ.eAthenaEditor.Editor.Properties.Resources.ImageFileSaveAll;
			this.menuMainFileSaveAs.Name = "menuMainFileSaveAs";
			this.menuMainFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
						| System.Windows.Forms.Keys.S)));
			this.menuMainFileSaveAs.Size = new System.Drawing.Size(290, 22);
			this.menuMainFileSaveAs.Text = "Speichern unter...";
			this.menuMainFileSaveAs.Click += new System.EventHandler(this.menuMainFileSaveAs_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(287, 6);
			// 
			// menuMainFileClose
			// 
			this.menuMainFileClose.Name = "menuMainFileClose";
			this.menuMainFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.menuMainFileClose.Size = new System.Drawing.Size(290, 22);
			this.menuMainFileClose.Text = "Schließen";
			this.menuMainFileClose.Click += new System.EventHandler(this.menuMainFileClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(287, 6);
			// 
			// menuMainFileExit
			// 
			this.menuMainFileExit.Name = "menuMainFileExit";
			this.menuMainFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.menuMainFileExit.Size = new System.Drawing.Size(290, 22);
			this.menuMainFileExit.Text = "Programm Beenden";
			this.menuMainFileExit.Click += new System.EventHandler(this.menuMainFileExit_Click);
			// 
			// menuMainEdit
			// 
			this.menuMainEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainEditCopy,
            this.menuMainEditPaste,
            this.menuMainEditCut,
            this.toolStripSeparator2,
            this.menuMainEditSearch,
            this.menuMainEditReplace,
            this.menuMainEditSearchAgain,
            this.menuMainEditSearchAgainReverse});
			this.menuMainEdit.Name = "menuMainEdit";
			this.menuMainEdit.Size = new System.Drawing.Size(71, 20);
			this.menuMainEdit.Text = "&Bearbeiten";
			// 
			// menuMainEditCopy
			// 
			this.menuMainEditCopy.Image = global::GodLesZ.eAthenaEditor.Editor.Properties.Resources.ImageEditCopy;
			this.menuMainEditCopy.Name = "menuMainEditCopy";
			this.menuMainEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.menuMainEditCopy.Size = new System.Drawing.Size(311, 22);
			this.menuMainEditCopy.Text = "Kopieren";
			this.menuMainEditCopy.Click += new System.EventHandler(this.menuMainEditCopy_Click);
			// 
			// menuMainEditPaste
			// 
			this.menuMainEditPaste.Image = global::GodLesZ.eAthenaEditor.Editor.Properties.Resources.ImageEditPaste;
			this.menuMainEditPaste.Name = "menuMainEditPaste";
			this.menuMainEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.menuMainEditPaste.Size = new System.Drawing.Size(311, 22);
			this.menuMainEditPaste.Text = "Einfügen";
			this.menuMainEditPaste.Click += new System.EventHandler(this.menuMainEditPaste_Click);
			// 
			// menuMainEditCut
			// 
			this.menuMainEditCut.Image = global::GodLesZ.eAthenaEditor.Editor.Properties.Resources.ImageEditCut;
			this.menuMainEditCut.Name = "menuMainEditCut";
			this.menuMainEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.menuMainEditCut.Size = new System.Drawing.Size(311, 22);
			this.menuMainEditCut.Text = "Ausschneiden";
			this.menuMainEditCut.Click += new System.EventHandler(this.menuMainEditCut_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(308, 6);
			// 
			// menuMainEditSearch
			// 
			this.menuMainEditSearch.Name = "menuMainEditSearch";
			this.menuMainEditSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.menuMainEditSearch.Size = new System.Drawing.Size(311, 22);
			this.menuMainEditSearch.Text = "Suchen...";
			this.menuMainEditSearch.Click += new System.EventHandler(this.menuMainEditSearch_Click);
			// 
			// menuMainEditReplace
			// 
			this.menuMainEditReplace.Name = "menuMainEditReplace";
			this.menuMainEditReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.menuMainEditReplace.Size = new System.Drawing.Size(311, 22);
			this.menuMainEditReplace.Text = "Suchen und Ersetzen...";
			this.menuMainEditReplace.Click += new System.EventHandler(this.menuMainEditReplace_Click);
			// 
			// menuMainEditSearchAgain
			// 
			this.menuMainEditSearchAgain.Name = "menuMainEditSearchAgain";
			this.menuMainEditSearchAgain.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.menuMainEditSearchAgain.Size = new System.Drawing.Size(311, 22);
			this.menuMainEditSearchAgain.Text = "Erneut Suchen";
			this.menuMainEditSearchAgain.Click += new System.EventHandler(this.menuMainSearchAgain_Click);
			// 
			// menuMainEditSearchAgainReverse
			// 
			this.menuMainEditSearchAgainReverse.Name = "menuMainEditSearchAgainReverse";
			this.menuMainEditSearchAgainReverse.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
			this.menuMainEditSearchAgainReverse.Size = new System.Drawing.Size(311, 22);
			this.menuMainEditSearchAgainReverse.Text = "Erneut Suchen (Rückwärts)";
			this.menuMainEditSearchAgainReverse.Click += new System.EventHandler(this.menuSearchAgainReverse_Click);
			// 
			// menuMainOptions
			// 
			this.menuMainOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainOptionsSpaces,
            this.menuMainOptionsNewslines,
            this.menuMainOptionsLinenumbers,
            this.toolStripSeparator6,
            this.menuMainOptionsCurrentRow,
            this.menuMainOptionsBracketMatch,
            this.toolStripSeparator4,
            this.menuMainOptionsTabSize,
            this.menuMainOptionsFontSize});
			this.menuMainOptions.Name = "menuMainOptions";
			this.menuMainOptions.Size = new System.Drawing.Size(82, 20);
			this.menuMainOptions.Text = "&Einstellungen";
			// 
			// menuMainOptionsSpaces
			// 
			this.menuMainOptionsSpaces.Name = "menuMainOptionsSpaces";
			this.menuMainOptionsSpaces.Size = new System.Drawing.Size(240, 22);
			this.menuMainOptionsSpaces.Text = "Anzeigen: Tabs und Leerzeichen";
			this.menuMainOptionsSpaces.Click += new System.EventHandler(this.menuShowSpaces_Click);
			// 
			// menuMainOptionsNewslines
			// 
			this.menuMainOptionsNewslines.Name = "menuMainOptionsNewslines";
			this.menuMainOptionsNewslines.Size = new System.Drawing.Size(240, 22);
			this.menuMainOptionsNewslines.Text = "Anzeigen: Zeileumbruch";
			this.menuMainOptionsNewslines.Click += new System.EventHandler(this.menuShowNewlines_Click);
			// 
			// menuMainOptionsLinenumbers
			// 
			this.menuMainOptionsLinenumbers.Name = "menuMainOptionsLinenumbers";
			this.menuMainOptionsLinenumbers.Size = new System.Drawing.Size(240, 22);
			this.menuMainOptionsLinenumbers.Text = "Anzeigen: Zeilennummern";
			this.menuMainOptionsLinenumbers.Click += new System.EventHandler(this.menuShowLineNumbers_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(237, 6);
			// 
			// menuMainOptionsCurrentRow
			// 
			this.menuMainOptionsCurrentRow.Name = "menuMainOptionsCurrentRow";
			this.menuMainOptionsCurrentRow.Size = new System.Drawing.Size(240, 22);
			this.menuMainOptionsCurrentRow.Text = "Zeile markieren";
			this.menuMainOptionsCurrentRow.Click += new System.EventHandler(this.menuHighlightCurrentRow_Click);
			// 
			// menuMainOptionsBracketMatch
			// 
			this.menuMainOptionsBracketMatch.Name = "menuMainOptionsBracketMatch";
			this.menuMainOptionsBracketMatch.Size = new System.Drawing.Size(240, 22);
			this.menuMainOptionsBracketMatch.Text = "Klammern markieren";
			this.menuMainOptionsBracketMatch.Click += new System.EventHandler(this.menuBracketMatchingStyle_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(237, 6);
			// 
			// menuMainOptionsTabSize
			// 
			this.menuMainOptionsTabSize.Name = "menuMainOptionsTabSize";
			this.menuMainOptionsTabSize.Size = new System.Drawing.Size(240, 22);
			this.menuMainOptionsTabSize.Text = "Tabgröße einstellen...";
			this.menuMainOptionsTabSize.Click += new System.EventHandler(this.menuSetTabSize_Click);
			// 
			// menuMainOptionsFontSize
			// 
			this.menuMainOptionsFontSize.Name = "menuMainOptionsFontSize";
			this.menuMainOptionsFontSize.Size = new System.Drawing.Size(240, 22);
			this.menuMainOptionsFontSize.Text = "Schriftgröße einstellen...";
			this.menuMainOptionsFontSize.Click += new System.EventHandler(this.menuSetFont_Click);
			// 
			// fileTabs
			// 
			this.fileTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fileTabs.Location = new System.Drawing.Point(0, 24);
			this.fileTabs.Name = "fileTabs";
			this.fileTabs.SelectedIndex = 0;
			this.fileTabs.Size = new System.Drawing.Size(567, 454);
			this.fileTabs.TabIndex = 3;
			this.fileTabs.TabStop = false;
			// 
			// frmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 478);
			this.Controls.Add(this.fileTabs);
			this.Controls.Add(this.menuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuMain;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "eAthena NPC Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuMainFile;
		private System.Windows.Forms.ToolStripMenuItem menuMainFileOpen;
		private System.Windows.Forms.ToolStripMenuItem menuMainFileSave;
		private System.Windows.Forms.TabControl fileTabs;
		private System.Windows.Forms.ToolStripMenuItem menuMainFileNew;
		private System.Windows.Forms.ToolStripMenuItem menuMainFileSaveAs;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuMainFileExit;
		private System.Windows.Forms.ToolStripMenuItem menuMainFileClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuMainEdit;
		private System.Windows.Forms.ToolStripMenuItem menuMainEditCopy;
		private System.Windows.Forms.ToolStripMenuItem menuMainEditPaste;
		private System.Windows.Forms.ToolStripMenuItem menuMainEditCut;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuMainEditSearch;
		private System.Windows.Forms.ToolStripMenuItem menuMainEditReplace;
		private System.Windows.Forms.ToolStripMenuItem menuMainEditSearchAgain;
		private System.Windows.Forms.ToolStripMenuItem menuMainEditSearchAgainReverse;
		private System.Windows.Forms.ToolStripMenuItem menuMainOptions;
		private System.Windows.Forms.ToolStripMenuItem menuMainOptionsSpaces;
		private System.Windows.Forms.ToolStripMenuItem menuMainOptionsNewslines;
		private System.Windows.Forms.ToolStripMenuItem menuMainOptionsLinenumbers;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem menuMainOptionsCurrentRow;
		private System.Windows.Forms.ToolStripMenuItem menuMainOptionsBracketMatch;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem menuMainOptionsTabSize;
		private System.Windows.Forms.ToolStripMenuItem menuMainOptionsFontSize;
	}
}

