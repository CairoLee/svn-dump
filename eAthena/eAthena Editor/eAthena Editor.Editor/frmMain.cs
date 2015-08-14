using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using GodLesZ.eAthenaEditor.Library;
using GodLesZ.eAthenaEditor.Library.Document;
using GodLesZ.eAthenaEditor.Editor.Syntax;
using GodLesZ.eAthenaEditor.Editor.Controls;
using GodLesZ.eAthenaEditor.Library.Gui.CompletionWindow;

namespace GodLesZ.eAthenaEditor.Editor {

	public partial class frmMain : Form {
		private ITextEditorProperties mEditorSettings;

		private frmFindAndReplace mFindAndReplace = new frmFindAndReplace();


		public IEnumerable<ScriptTextEditorControl> AllEditors {
			get {
				return from t in fileTabs.Controls.Cast<EditorTabPage>()
					   select t.Editor;
			}
		}

		public EditorTabPage ActiveTab {
			get {
				if (fileTabs.TabPages.Count == 0) {
					return null;
				}
				return fileTabs.SelectedTab as EditorTabPage;
			}
		}

		public ScriptTextEditorControl ActiveEditor {
			get {
				if (ActiveTab == null) {
					return null;
				}
				return ActiveTab.Editor;
			}
		}


		public frmMain() {
			InitializeComponent();

			AddNewTextEditor("New file");
		}


		#region frmMain Events
		private void frmMain_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void frmMain_DragDrop(object sender, DragEventArgs e) {
			string[] list = e.Data.GetData(DataFormats.FileDrop) as string[];
			if (list != null) {
				OpenFiles(list);
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			foreach (EditorTabPage tab in Controls["fileTabs"].Controls.Cast<EditorTabPage>()) {
				if (tab == null) {
					continue;
				}
				if (tab.OnFormClose() == true) {
					e.Cancel = true;
				}
			}
		}
		#endregion

		#region menuMainFile Events
		private void menuMainFileNew_Click(object sender, EventArgs e) {
			AddNewTextEditor("New file");
		}

		private void menuMainFileOpen_Click(object sender, EventArgs e) {
			using (OpenFileDialog dlg = new OpenFileDialog()) {
				dlg.Filter = "eAthena Text File (*.txt; *.ea; *.conf)|*.txt;*.ea;*.conf";
				dlg.Multiselect = true;
				if (dlg.ShowDialog(this) == DialogResult.OK) {
					OpenFiles(dlg.FileNames);
				}
			}
		}

		private void menuMainFileSave_Click(object sender, EventArgs e) {
			var tab = ActiveTab;
			if (tab != null) {
				tab.EditorSave();
			}
		}

		private void menuMainFileSaveAs_Click(object sender, EventArgs e) {
			var tab = ActiveTab;
			if (tab != null) {
				tab.EditorSaveAs();
			}
		}

		private void menuMainFileClose_Click(object sender, EventArgs e) {
			var tab = ActiveTab;
			if (tab != null) {
				tab.EditorRemove();
			}
		}

		private void menuMainFileExit_Click(object sender, EventArgs e) {
			Close();
		}
		#endregion

		#region menuMainEdit Events
		private void menuMainEditCopy_Click(object sender, EventArgs e) {
			if (HaveSelection() == true) {
				DoEditAction(ActiveEditor, new GodLesZ.eAthenaEditor.Library.Actions.Copy());
			}
		}

		private void menuMainEditPaste_Click(object sender, EventArgs e) {
			var editor = ActiveEditor;
			if (editor != null) {
				DoEditAction(ActiveEditor, new GodLesZ.eAthenaEditor.Library.Actions.Paste());
			}
		}

		private void menuMainEditCut_Click(object sender, EventArgs e) {
			if (HaveSelection() == true) {
				DoEditAction(ActiveEditor, new GodLesZ.eAthenaEditor.Library.Actions.Cut());
			}
		}

		private void menuMainEditDelete_Click(object sender, EventArgs e) {
			if (HaveSelection() == true) {
				DoEditAction(ActiveEditor, new GodLesZ.eAthenaEditor.Library.Actions.Delete());
			}
		}


		private void menuMainEditSearch_Click(object sender, EventArgs e) {
			var editor = ActiveEditor;
			if (editor != null) {
				mFindAndReplace.ShowFor(editor, false);
			}
		}

		private void menuMainEditReplace_Click(object sender, EventArgs e) {
			var editor = ActiveEditor;
			if (editor != null) {
				mFindAndReplace.ShowFor(editor, true);
			}
		}

		private void menuMainSearchAgain_Click(object sender, EventArgs e) {
			var editor = ActiveEditor;
			if (editor != null) {
				mFindAndReplace.FindNext(true, false, string.Format("Suchtext «{0}» nicht gefunden!", mFindAndReplace.LookFor));
			}
		}

		private void menuSearchAgainReverse_Click(object sender, EventArgs e) {
			var editor = ActiveEditor;
			if (editor != null) {
				mFindAndReplace.FindNext(true, true, string.Format("Suchtext «{0}» nicht gefunden!", mFindAndReplace.LookFor));
			}
		}
		#endregion

		#region menuMainOptions Events
		private void menuShowSpaces_Click(object sender, EventArgs e) {
			mEditorSettings.ShowSpaces = !mEditorSettings.ShowSpaces;
			OnSettingsChanged();
		}
		private void menuShowNewlines_Click(object sender, EventArgs e) {
			mEditorSettings.ShowEOLMarker = !mEditorSettings.ShowEOLMarker;
			OnSettingsChanged();
		}

		private void menuHighlightCurrentRow_Click(object sender, EventArgs e) {
			mEditorSettings.LineViewerStyle = mEditorSettings.LineViewerStyle == LineViewerStyle.None ? LineViewerStyle.FullRow : LineViewerStyle.None;
			OnSettingsChanged();
		}

		private void menuBracketMatchingStyle_Click(object sender, EventArgs e) {
			mEditorSettings.BracketMatchingStyle = mEditorSettings.BracketMatchingStyle == BracketMatchingStyle.After ? BracketMatchingStyle.Before : BracketMatchingStyle.After;
			OnSettingsChanged();
		}

		private void menuShowLineNumbers_Click(object sender, EventArgs e) {
			mEditorSettings.ShowLineNumbers = !mEditorSettings.ShowLineNumbers;
			OnSettingsChanged();
		}

		private void menuSetTabSize_Click(object sender, EventArgs e) {
			string result = InputBox.Show("Specify the desired tab width.", "Tab size", mEditorSettings.TabIndent.ToString());
			int value;
			if (result != null && int.TryParse(result, out value) && value.IsInRange(1, 32)) {
				mEditorSettings.TabIndent = value;
				OnSettingsChanged();
			}

		}

		private void menuSetFont_Click(object sender, EventArgs e) {
			var editor = ActiveEditor;
			if (editor != null) {
				using (FontDialog dlg = new FontDialog()) {
					dlg.Font = editor.Font;
					if (dlg.ShowDialog(this) == DialogResult.OK) {
						mEditorSettings.Font = dlg.Font;
						OnSettingsChanged();
					}
				}
			}
		}
		#endregion


		#region Helper: File

		private EditorTabPage AddNewTextEditor(string title) {
			if (mEditorSettings == null) {
				mEditorSettings = new DefaultTextEditorProperties();
				mEditorSettings.AllowCaretBeyondEOL = false;
				mEditorSettings.AutoInsertCurlyBracket = true;
				mEditorSettings.BracketMatchingStyle = BracketMatchingStyle.After;
				mEditorSettings.ConvertTabsToSpaces = false;
				mEditorSettings.CutCopyWholeLine = true;
				mEditorSettings.DocumentSelectionMode = DocumentSelectionMode.Normal;
				mEditorSettings.EnableFolding = true;
				mEditorSettings.HideMouseCursor = false;
				mEditorSettings.IndentStyle = IndentStyle.Smart;
				mEditorSettings.IsIconBarVisible = true;
				mEditorSettings.LineTerminator = Environment.NewLine;
				mEditorSettings.LineViewerStyle = LineViewerStyle.None;
				mEditorSettings.MouseWheelScrollDown = true;
				mEditorSettings.MouseWheelTextZoom = true;
				mEditorSettings.ShowEOLMarker = false;
				mEditorSettings.ShowHorizontalRuler = false;
				mEditorSettings.ShowInvalidLines = false;
				mEditorSettings.ShowLineNumbers = true;
				mEditorSettings.ShowMatchingBracket = true;
				mEditorSettings.ShowSpaces = false;
				mEditorSettings.ShowTabs = false;
				mEditorSettings.ShowVerticalRuler = false;
				mEditorSettings.SupportReadOnlySegments = false;
				mEditorSettings.TabIndent = 4;
				mEditorSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			}
			var tab = new EditorTabPage(title, mEditorSettings);

			fileTabs.Controls.Add(tab);
			fileTabs.SelectTab(tab);

			return tab;
		}

		private void OpenFiles(string[] fns) {
			// Close default untitled document if it is still empty
			if (fileTabs.TabPages.Count == 1) {
				var tab = ActiveTab;
				if (tab != null && tab.Editor.Document.TextLength == 0 && string.IsNullOrEmpty(tab.Editor.FileName)) {
					tab.EditorRemove();
				}
			}

			// Open file(s)
			foreach (string fn in fns) {
				var tab = AddNewTextEditor(Path.GetFileName(fn));
				try {
					tab.Editor.LoadFile(fn);
					// Modified flag is set during loading because the document 
					// "changes" (from nothing to something). So, clear it again.
					tab.IsModified = false;
				} catch (Exception ex) {
					MessageBox.Show(ex.Message, ex.GetType().Name);
					tab = ActiveTab;
					if (ActiveTab != null) {
						tab.EditorRemove();
						return;
					}
				}

				//editor.Document.FoldingManager.UpdateFoldings(null, null);
			}
		}

		#endregion

		#region Helper: Edit

		private bool HaveSelection() {
			var editor = ActiveEditor;
			return editor != null && editor.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected;
		}

		private void DoEditAction(ScriptTextEditorControl editor, GodLesZ.eAthenaEditor.Library.Actions.IEditAction action) {
			if (editor != null && action != null) {
				var area = editor.ActiveTextAreaControl.TextArea;
				editor.BeginUpdate();
				try {
					lock (editor.Document) {
						action.Execute(area);
						if (area.SelectionManager.HasSomethingSelected && area.AutoClearSelection /*&& caretchanged*/) {
							if (area.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal) {
								area.SelectionManager.ClearSelection();
							}
						}
					}
				} finally {
					editor.EndUpdate();
					area.Caret.UpdateCaretPosition();
				}
			}
		}

		#endregion

		#region Helper: Options

		/// <summary>Show current settings on the Options menu</summary>
		/// <remarks>We don't have to sync settings between the editors because 
		/// they all share the same DefaultTextEditorProperties object.</remarks>
		private void OnSettingsChanged() {
			var editor = ActiveEditor;
			if (editor != null) {
				editor.ShowSpaces = editor.ShowTabs = mEditorSettings.ShowSpaces;
				editor.ShowEOLMarkers = mEditorSettings.ShowEOLMarker;
				editor.LineViewerStyle = mEditorSettings.LineViewerStyle;
				editor.BracketMatchingStyle = mEditorSettings.BracketMatchingStyle;
				editor.ShowLineNumbers = mEditorSettings.ShowLineNumbers;
				editor.TabIndent = mEditorSettings.TabIndent;
				editor.Font = mEditorSettings.Font;
			}

			menuMainOptionsSpaces.Checked = mEditorSettings.ShowSpaces;
			menuMainOptionsNewslines.Checked = mEditorSettings.ShowEOLMarker;
			menuMainOptionsCurrentRow.Checked = mEditorSettings.LineViewerStyle == LineViewerStyle.FullRow;
			menuMainOptionsBracketMatch.Checked = mEditorSettings.BracketMatchingStyle == BracketMatchingStyle.After;
			menuMainOptionsLinenumbers.Checked = mEditorSettings.ShowLineNumbers;
		}

		#endregion

	}

}