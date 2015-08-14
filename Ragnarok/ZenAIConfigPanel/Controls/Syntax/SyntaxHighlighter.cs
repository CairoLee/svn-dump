using System.Drawing;
using System.Text.RegularExpressions;

namespace Moonlight {

	internal class SyntaxHighlighter {
		private bool compiled = false;
		private Regex keywordsRegexp = null;
		private Regex functionsRegexp = null;
		private Regex typeNamesRegexp = null;
		private Regex stringsRegexp = null;
		private Regex commentsRegexp = null;


		public SyntaxHighlighter() {
		}


		public void DoSyntaxHightlightCurrentLine(SyntaxRichTextBox codeTextbox) {
			if (!compiled)
				Update(codeTextbox);

			string line = RichTextboxHelper.GetCurrentLine(codeTextbox);
			int lineStart = RichTextboxHelper.GetCurrentLineStartIndex(codeTextbox);
			ProcessLine(codeTextbox, line, lineStart);
		}
		public void DoSyntaxHightlightSelection(SyntaxRichTextBox codeTextbox, int selectionStart, int selectionLength) {
			if (!compiled)
				Update(codeTextbox);
			ProcessSelection(codeTextbox, selectionStart, selectionLength);
		}

		public void DoSyntaxHightlightAllLines(SyntaxRichTextBox codeTextbox) {
			if (!compiled)
				Update(codeTextbox);
			ProcessAllLines(codeTextbox);
		}

		/// <summary>
		/// Compiles the necessary regexps
		/// </summary>
		/// <param name="syntaxSettings"></param>
		public void Update(SyntaxRichTextBox codeTextbox) {
			string keywords = string.Empty;
			string functions = string.Empty;
			string typeNames = string.Empty;
			string comments = string.Empty;

			for (int i = 0; i < codeTextbox.CodeWordsKeywords.Count; i++) {
				string strKeyword = codeTextbox.CodeWordsKeywords[i];
				keywords += "\\b" + strKeyword + "\\b";
				if (i != codeTextbox.CodeWordsKeywords.Count - 1)
					keywords += "|";
			}

			for (int i = 0; i < codeTextbox.CodeWordsFunctions.Count; i++) {
				string strFunction = codeTextbox.CodeWordsFunctions[i];
				functions += "\\b" + strFunction + "\\b";
				if (i != codeTextbox.CodeWordsFunctions.Count - 1)
					functions += "|";
			}

			for (int i = 0; i < codeTextbox.CodeWordsTypes.Count; i++) {
				string strType = codeTextbox.CodeWordsTypes[i];
				typeNames += "\\b" + strType + "\\b";
				if (i != codeTextbox.CodeWordsTypes.Count - 1)
					typeNames += "|";
			}

			for (int i = 0; i < codeTextbox.CodeWordsComments.Count; i++) {
				string strComments = codeTextbox.CodeWordsComments[i];
				comments += "" + strComments + ".*$";
				if (i != codeTextbox.CodeWordsComments.Count - 1)
					comments += "|";
			}

			keywordsRegexp = new Regex(keywords, RegexOptions.Compiled);
			typeNamesRegexp = new Regex(typeNames, RegexOptions.Compiled);
			functionsRegexp = new Regex(functions, RegexOptions.Compiled);
			commentsRegexp = new Regex(comments, RegexOptions.Compiled | RegexOptions.Multiline);
			stringsRegexp = new Regex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", RegexOptions.Compiled | RegexOptions.Multiline);

			compiled = true;
		}

		#region Private methods
		/// <summary>
		/// Processes a regex.
		/// </summary>
		/// <param name="richTextbox"></param>
		/// <param name="line"></param>
		/// <param name="lineStart"></param>
		/// <param name="regexp"></param>
		/// <param name="color"></param>
		private void ProcessRegex(SyntaxRichTextBox codeTextbox, string line, int lineStart, Regex regexp, Color color) {
			// @TODO: Contains a bug for the compiled typeNamesRegexp in  the following line:
			// -- This is the standard mod for ZenAI.
			//		  Check this..
			return;

			if (regexp == null)
				return;

			Match regMatch;
			for (regMatch = regexp.Match(line); regMatch.Success; regMatch = regMatch.NextMatch()) {
				int nStart = lineStart + regMatch.Index;
				int nLenght = regMatch.Length;
				codeTextbox.SelectionStart = nStart;
				codeTextbox.SelectionLength = nLenght;
				codeTextbox.SelectionColor = color;
			}
		}

		/// <summary>
		/// Processes syntax highlightning for a line.
		/// </summary>
		/// <param name="richTextbox"></param>
		/// <param name="syntaxSettings"></param>
		/// <param name="line"></param>
		/// <param name="lineStart"></param>
		private void ProcessLine(SyntaxRichTextBox codeTextbox, string line, int lineStart) {
			codeTextbox.EnablePainting = false;

			int nPosition = codeTextbox.SelectionStart;
			codeTextbox.SelectionStart = lineStart;
			codeTextbox.SelectionLength = line.Length;
			codeTextbox.SelectionColor = Color.Black;

			// Process the keywords
			ProcessRegex(codeTextbox, line, lineStart, keywordsRegexp, codeTextbox.CodeColorKeyword);
			ProcessRegex(codeTextbox, line, lineStart, typeNamesRegexp, codeTextbox.CodeColorType);
			ProcessRegex(codeTextbox, line, lineStart, functionsRegexp, codeTextbox.CodeColorFunction);
			ProcessRegex(codeTextbox, line, lineStart, stringsRegexp, codeTextbox.CodeColorPlainText);
			if (codeTextbox.CodeWordsComments.Count > 0)
				ProcessRegex(codeTextbox, line, lineStart, commentsRegexp, codeTextbox.CodeColorComment);

			codeTextbox.SelectionStart = nPosition;
			codeTextbox.SelectionLength = 0;
			codeTextbox.SelectionColor = Color.Black;

			codeTextbox.EnablePainting = true;
		}

		private void ProcessSelection(SyntaxRichTextBox codeTextbox, int selectionStart, int selectionLength) {
			codeTextbox.EnablePainting = false;

			int nPosition = selectionStart;

			codeTextbox.SelectionStart = selectionStart;
			codeTextbox.SelectionLength = selectionLength;
			string text = codeTextbox.SelectedText;

			codeTextbox.SelectionColor = Color.Black;


			ProcessRegex(codeTextbox, text, selectionStart, keywordsRegexp, codeTextbox.CodeColorKeyword);
			ProcessRegex(codeTextbox, text, selectionStart, typeNamesRegexp, codeTextbox.CodeColorType);
			ProcessRegex(codeTextbox, text, selectionStart, functionsRegexp, codeTextbox.CodeColorFunction);
			ProcessRegex(codeTextbox, text, selectionStart, stringsRegexp, codeTextbox.CodeColorPlainText);
			if (codeTextbox.CodeWordsComments.Count > 0)
				ProcessRegex(codeTextbox, text, selectionStart, commentsRegexp, codeTextbox.CodeColorComment);

			codeTextbox.SelectionStart = nPosition;
			codeTextbox.SelectionLength = 0;
			codeTextbox.SelectionColor = Color.Black;

			codeTextbox.EnablePainting = true;
		}

		public void ProcessAllLines(SyntaxRichTextBox codeTextbox) {
			codeTextbox.EnablePainting = false;

			// Save the position and make the whole line black
			int nPosition = codeTextbox.SelectionStart;
			codeTextbox.SelectionStart = 0;
			codeTextbox.SelectionLength = codeTextbox.Text.Length;
			codeTextbox.SelectionColor = Color.Black;

			ProcessRegex(codeTextbox, codeTextbox.Text, 0, keywordsRegexp, codeTextbox.CodeColorKeyword);
			ProcessRegex(codeTextbox, codeTextbox.Text, 0, typeNamesRegexp, codeTextbox.CodeColorType);
			ProcessRegex(codeTextbox, codeTextbox.Text, 0, functionsRegexp, codeTextbox.CodeColorFunction);
			ProcessRegex(codeTextbox, codeTextbox.Text, 0, stringsRegexp, codeTextbox.CodeColorPlainText);
			if (codeTextbox.CodeWordsComments.Count > 0)
				ProcessRegex(codeTextbox, codeTextbox.Text, 0, commentsRegexp, codeTextbox.CodeColorComment);

			codeTextbox.SelectionStart = nPosition;
			codeTextbox.SelectionLength = 0;
			codeTextbox.SelectionColor = Color.Black;

			codeTextbox.EnablePainting = true;
		}
		#endregion

	}

}
