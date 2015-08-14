using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.eAthenaEditor.Library;
using GodLesZ.eAthenaEditor.Library.Document;
using System.Text.RegularExpressions;
using GodLesZ.eAthenaEditor.Editor.Syntax;

namespace GodLesZ.eAthenaEditor.Editor.Controls {

	public partial class ScriptEditorPanel : UserControl {
		private bool mUpdateAfterUpdate = false;
		private object mLock = new Object();
		private string mText = null;

		private BackgroundWorker mWorker;
		private Timer mRefreshDelayTimer;
		private bool mDontJumpToHeader = false;

		public ScriptTextEditorControl Editor {
			get { return txtEditor; }
		}

		public ScriptEntityComboBox ListEntitys {
			get { return cmbEntitys; }
		}

		public ScriptEntityManager ScriptEntitys {
			get;
			private set;
		}


		public ScriptEditorPanel() {
			InitializeComponent();
			InitializeBackgroundWorker();
		}

		private void InitializeBackgroundWorker() {
			ScriptEntitys = new ScriptEntityManager();

			mRefreshDelayTimer = new Timer();
			mRefreshDelayTimer.Enabled = false;
			mRefreshDelayTimer.Interval = 1500;
			mRefreshDelayTimer.Tick += new EventHandler(mRefreshDelayTimer_Tick);

			mWorker = new BackgroundWorker();
			mWorker.WorkerSupportsCancellation = true;
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mWorker_RunWorkerCompleted);
			mWorker.DoWork += new DoWorkEventHandler(mWorker_DoWork);

			Editor.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
			Editor.ActiveTextAreaControl.Caret.PositionChanged += new EventHandler(Caret_PositionChanged);
		}


		#region Editor & Document Events
		private void Document_DocumentChanged(object sender, DocumentEventArgs e) {
			if (mRefreshDelayTimer.Enabled == true || mWorker.IsBusy == true) {
				mUpdateAfterUpdate = true;
				return;
			}

			mText = Editor.Document.TextContent;
			mRefreshDelayTimer.Enabled = true;
			mRefreshDelayTimer.Start();
		}

		private void Caret_PositionChanged(object sender, EventArgs e) {
			int caretOffset = Editor.ActiveTextAreaControl.Caret.Offset;
			int selectedIndex = -1;
			for (int i = 0; i < ScriptEntitys.Count; i++) {
				if (caretOffset >= ScriptEntitys[i].OffsetStart && caretOffset <= ScriptEntitys[i].OffsetEnd) {
					selectedIndex = i;
					break;
				}
			}

			mDontJumpToHeader = true;
			cmbEntitys.SelectedIndex = (selectedIndex < cmbEntitys.Items.Count ? selectedIndex : -1);
			mDontJumpToHeader = false;
		}
		#endregion

		#region ScriptEditorPanel Events
		private void ScriptEditorPanel_Enter(object sender, EventArgs e) {
			if (Editor.ContainsFocus == false && Editor.CanFocus == true) {
				Editor.Focus();
			}

		}
		#endregion

		#region BackgroundWorker Events
		private void mRefreshDelayTimer_Tick(object sender, EventArgs e) {
			lock (mLock) {
				mRefreshDelayTimer.Stop();
				mRefreshDelayTimer.Enabled = false;
				mWorker.RunWorkerAsync();
			}
		}

		private void mWorker_DoWork(object sender, DoWorkEventArgs e) {
			ScriptEntitys.Clear();

			string scriptTypes = "script|warp|shop|cashshop|monster|boss_monster|mapflag";
			Regex regexEntity = new Regex("^(.+)\t(" + scriptTypes + ")\t(.+)\t([^{\n]*){?", RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
			MatchCollection matches = regexEntity.Matches(mText);
			int matchCount = matches.Count;
			List<FoldMarker> newFoldings = new List<FoldMarker>();

			foreach (Match match in matches) {
				string matchString = match.Groups[0].Captures[0].Value.TrimEnd(); // trim possible \r
				string w1 = match.Groups[1].Captures[0].Value;
				string w2 = match.Groups[2].Captures[0].Value;
				string w3 = match.Groups[3].Captures[0].Value;
				string w4 = match.Groups[4].Captures[0].Value;
				int offsetStart = match.Index;
				int offsetEnd = 0;
				string safeW2 = w2.ToLower().Trim();
				if (safeW2 == "monster" || safeW2 == "boss_monster" || safeW2 == "shop" || safeW2 == "cashshop") {
					offsetEnd = match.Index + matchString.Length;
				} else {
					// Search closing bracket
					offsetEnd = GetBodyEnd(match.Index + matchString.Length);
					// Add folding
					newFoldings.Add(new FoldMarker(Editor.Document, offsetStart + match.Length - 1, (offsetEnd - offsetStart - match.Length + 1), "...", false));
				}

				ScriptEntity en = ScriptEntityFactory.CreateEntity(w1, w2, w3, w4, offsetStart, offsetEnd);
				ScriptEntitys.Add(en);
			}

			matches = null;
			mText = null;

			Editor.Document.FoldingManager.UpdateFoldings(newFoldings);
		}

		private void mWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			lock (mLock) {
				ListEntitys.Items.Clear();

				//! realy set selected function here? will be done on caretChange too!
				int caretOffset = Editor.ActiveTextAreaControl.Caret.Offset;
				int selectedIndex = -1;
				for (int i = 0; i < ScriptEntitys.Count; i++) {
					ListEntitys.Items.Add(new ScriptEntityComboBoxItem(ListEntitys, ScriptEntitys[i]));
					if (selectedIndex == -1 && caretOffset >= ScriptEntitys[i].OffsetStart && caretOffset <= ScriptEntitys[i].OffsetEnd) {
						selectedIndex = i;
					}
				}

				if (selectedIndex != -1) {
					mDontJumpToHeader = true;
					cmbEntitys.SelectedIndex = selectedIndex;
					mDontJumpToHeader = false;
				}

				if (mUpdateAfterUpdate == true) {
					mUpdateAfterUpdate = false;
					mText = Editor.Document.TextContent;
					mRefreshDelayTimer.Enabled = true;
					mRefreshDelayTimer.Start();
				}
			}
		}
		#endregion

		#region ScriptFunctions & ScriptNpcs Events
		private void cmbFunctions_SelectedIndexChanged(object sender, EventArgs e) {
			if (mDontJumpToHeader == true || cmbEntitys.SelectedIndex == -1) {
				mDontJumpToHeader = false;
				return;
			}

			TextLocation pos = Editor.Document.OffsetToPosition(ScriptEntitys[cmbEntitys.SelectedIndex].OffsetStart);
			Editor.ActiveTextAreaControl.Caret.Position = pos;
			Editor.Focus();
		}

		private void cmbNpcs_SelectedIndexChanged(object sender, EventArgs e) {

		}
		#endregion





		private int GetBodyEnd(int startOffset) {
			int openBrackets = 1;
			int endOffset = 0;

			for (endOffset = startOffset; openBrackets > 0 && endOffset < mText.Length; endOffset++) {
				char curChar = mText[endOffset];
				if (curChar == '/' && (endOffset + 1) < mText.Length) {
					if (mText[endOffset + 1] == '/') {
						int endComment = mText.IndexOf('\n', endOffset);
						if (endComment == -1) {
							endOffset = -1;
							break;
						}

						endOffset = endComment;
						continue;
					} else if (mText[endOffset + 1] == '*') {
						int endComment = mText.IndexOf("*/", endOffset);
						if (endComment == -1) {
							endOffset = -1;
							break;
						}

						endOffset = endComment + 1;
						continue;
					}
				} else if (curChar == '{') {
					openBrackets++;
				} else if (curChar == '}') {
					openBrackets--;
				}
			}

			return endOffset;
		}

	}

}
