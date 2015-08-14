using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.eAthenaEditor.Library.Gui.CompletionWindow;
using System.Windows.Forms;
using GodLesZ.eAthenaEditor.Library;
using GodLesZ.eAthenaEditor.Library.Script;
using System.IO;
using System.Xml.Serialization;
using GodLesZ.eAthenaEditor.Library.Document;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptCompletionProvider : ICompletionDataProvider {
		private ScriptContentLoader mScriptContent = null;

		private ImageList mImageList;
		private int mDefaultIndex = 0;
		private string mPreSelection = null;

		public ImageList ImageList {
			get { return mImageList; }
		}

		public string PreSelection {
			get { return mPreSelection; }
			set { mPreSelection = value; }
		}

		public int DefaultIndex {
			get { return mDefaultIndex; }
		}


		public ScriptCompletionProvider(ImageList imageList) {
			mImageList = imageList;
			if (mScriptContent == null) {
				mScriptContent = new ScriptContentLoader();
			}
		}


		public CompletionDataProviderKeyResult ProcessKey(char key) {
			if (char.IsLetterOrDigit(key) || key == '_') {
				return CompletionDataProviderKeyResult.NormalKey;
			}
			return CompletionDataProviderKeyResult.InsertionKey;
		}

		/// <summary>
		/// Called when entry should be inserted. Forward to the insertion action of the completion data.
		/// </summary>
		public bool InsertAction(ICompletionData data, TextArea textArea, int insertionOffset, char key) {
			int endOffset = insertionOffset;
			LineSegment line = textArea.Document.GetLineSegment(textArea.Caret.Line);
			// Try to find the last word and replace it
			if (insertionOffset != 0) {
				// insertionOffset represent the current Caret, so this isnt needed
				// But just in case..
				if (textArea.Caret.Column > 0) {
					TextWord word = line.GetWord(textArea.Caret.Column - 1);
					if (word != null) {
						// Nothing todo?
						if (word.Word == data.Text) {
							data.Text = "";
						} else {
							// cap insert data
							data.Text = data.Text.Substring(word.Length);
						}
					}
				}
			}

			return data.InsertAction(textArea, key);
		}

		public ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped) {
			List<ICompletionData> completionData = new List<ICompletionData>();

			int column = Math.Max(0, textArea.Caret.Column - 1);
			LineSegment line = textArea.Document.GetLineSegment(textArea.Caret.Line);
			TextWord word = line.GetWord(column);

			string itemText = (word != null ? word.Word : "") + char.ToLower(charTyped);

			if (mScriptContent.CommandsFlat.ContainsKey(itemText) != false) {
				foreach (string key in mScriptContent.CommandsFlat[itemText]) {
					completionData.Add(new ScriptCompletionData(mScriptContent.Commands[key].Name, mScriptContent.Commands[key].Description, 0));
				}
			}
			if (mScriptContent.ConstantsFlat.ContainsKey(itemText) != false) {
				foreach (string key in mScriptContent.ConstantsFlat[itemText]) {
					completionData.Add(new ScriptCompletionData(mScriptContent.Constants[key].Name, mScriptContent.Constants[key].Description, 0));
				}
			}
			if (mScriptContent.Maps.ContainsKey(itemText) != false) {
				foreach (string key in mScriptContent.Maps[itemText]) {
					completionData.Add(new ScriptCompletionData(key, key, 0));
				}
			}

			return completionData.ToArray();
		}

	}

}
