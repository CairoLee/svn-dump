using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.eAthenaEditor.Library;
using GodLesZ.eAthenaEditor.Editor.Syntax;
using GodLesZ.eAthenaEditor.Library.Document;
using GodLesZ.eAthenaEditor.Library.Gui.CompletionWindow;
using System.IO;

namespace GodLesZ.eAthenaEditor.Editor.Controls {

	public class EditorTabPage : TabPage {
		private static ImageList mImagelist = new ImageList();
		private static ScriptCompletionProvider mCompletionDataProvider = new ScriptCompletionProvider(Imagelist);
		private ScriptToolTipProvider mScriptToolTip;

		private CodeCompletionWindow mCompletionWindow;

		public static ImageList Imagelist {
			get { return mImagelist; }
		}

		public ScriptEntityComboBox ListEntitys {
			get { return EditorPanel.ListEntitys; }
		}

		public ScriptTextEditorControl Editor {
			get { return EditorPanel.Editor; }
		}

		public ScriptEditorPanel EditorPanel {
			get { return Controls.OfType<ScriptEditorPanel>().FirstOrDefault(); }
		}

		public bool IsModified {
			get {
				// ScriptTextEditorControl doesn't seem to contain its own 'modified' flag, so 
				// instead we'll treat the "*" on the filename as the modified flag.
				return Editor != null && Text.EndsWith("*");
			}
			set {

				if (Editor != null && IsModified != value) {
					if (IsModified == true) {
						Text = Text.Substring(0, Text.Length - 1);
					} else {
						Text += "*";
					}
				}
			}
		}



		public EditorTabPage(string title, ITextEditorProperties properties)
			: base(title) {

			ScriptEditorPanel pnl = new ScriptEditorPanel();
			pnl.Dock = DockStyle.Fill;

			pnl.Editor.IsReadOnly = false;
			pnl.Editor.TextEditorProperties = properties;
			pnl.Editor.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
			pnl.Editor.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
			pnl.Editor.ActiveTextAreaControl.TextArea.KeyEventHandler += TextArea_KeyDown;
			pnl.Editor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("eAthena");

			mScriptToolTip = new ScriptToolTipProvider(pnl.Editor);

			Controls.Add(pnl);
		}


		#region Editor Methods
		public bool OnFormClose() {
			if (IsModified == false) {
				return false;
			}

			var r = MessageBox.Show(string.Format("Would you like to save the changed made in {0}?", Editor.FileName ?? "New file"), "Save changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (r == DialogResult.Cancel) {
				return true;
			} else if (r == DialogResult.Yes) {
				if (EditorSave() == false) {
					return true;
				}
			}
			return false;
		}

		public void EditorRemove() {
			Controls.Remove(Editor);
			(Parent as TabControl).TabPages.Remove(this);
		}

		public bool EditorSave() {
			if (string.IsNullOrEmpty(Editor.FileName)) {
				return EditorSaveAs();
			}

			try {
				Editor.SaveFile(Editor.FileName);
				IsModified = false;
				return true;
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, ex.GetType().Name);
				return false;
			}
		}

		public bool EditorSaveAs() {
			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.FileName = (string.IsNullOrEmpty(Editor.FileName) == false ? Editor.FileName : "New file.ea");
				if (dlg.ShowDialog(this) == DialogResult.OK) {
					try {
						Editor.SaveFile(dlg.FileName);
						Editor.Parent.Text = Path.GetFileName(Editor.FileName);
						IsModified = false;

						// The syntax highlighting strategy doesn't change automatically, so do it manually.
						Editor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("eAthena");
						return true;
					} catch (Exception ex) {
						MessageBox.Show(ex.Message, ex.GetType().Name);
					}
				}
			}

			return false;
		}
		#endregion

		#region Document & TextEditor Events
		private void Document_DocumentChanged(object sender, DocumentEventArgs e) {
			IsModified = true;
			// Will be updated on syntax formatting
			//Editor.Document.FoldingManager.UpdateFoldings(Editor.FileName, null);
		}

		private bool TextArea_KeyDown(char key) {
			if (mCompletionWindow != null) {
				if (mCompletionWindow.ProcessKeyEvent(key) == true) {
					return true;
				}
			}

			ShowIntellisense(key);
			return false;
		}
		#endregion


		private void ShowIntellisense(char value) {

			CodeCompletionWindow completionWindow = CodeCompletionWindow.ShowCompletionWindow(
				((Form)Parent.Parent),
				Editor,
				"",
				mCompletionDataProvider,
				value
			);

			// created a new window
			if (completionWindow != null) {
				completionWindow.Closed += new EventHandler(CompletionWindow_Closed);
				mCompletionWindow = completionWindow;
			} else if (mCompletionWindow != null) {
				// Window creation failed because provider returns null
				// Close previous window too
				mCompletionWindow.Close();
			}

		}

		private void CompletionWindow_Closed(object sender, EventArgs e) {

			if (mCompletionWindow != null) {
				mCompletionWindow.Closed -= new EventHandler(CompletionWindow_Closed);
				mCompletionWindow.Dispose();
				mCompletionWindow = null;
			}
		}


	}

}
