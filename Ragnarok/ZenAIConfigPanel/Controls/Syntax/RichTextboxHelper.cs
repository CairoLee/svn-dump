using System.Windows.Forms;

namespace Moonlight {

	internal class RichTextboxHelper {

		public static string GetLastWord(RichTextBox richTextbox) {
			int pos = richTextbox.SelectionStart;

			while (pos > 1) {
				string substr = richTextbox.Text.Substring(pos - 1, 1);
				if (char.IsWhiteSpace(substr, 0))
					return richTextbox.Text.Substring(pos, richTextbox.SelectionStart - pos);
				pos--;
			}

			return richTextbox.Text.Substring(0, richTextbox.SelectionStart);
		}

		public static string GetLastLine(RichTextBox richTextbox) {
			int charIndex = richTextbox.SelectionStart;
			int currentLineNumber = richTextbox.GetLineFromCharIndex(charIndex);
			if (richTextbox.Lines.Length <= currentLineNumber)
				return richTextbox.Lines[richTextbox.Lines.Length - 1];
			return richTextbox.Lines[currentLineNumber];
		}

		public static string GetCurrentLine(RichTextBox richTextbox) {
			int charIndex = richTextbox.SelectionStart;
			int currentLineNumber = richTextbox.GetLineFromCharIndex(charIndex);
			if (currentLineNumber < richTextbox.Lines.Length)
				return richTextbox.Lines[currentLineNumber];
			return string.Empty;
		}

		public static int GetCurrentLineStartIndex(RichTextBox richTextbox) {
			return richTextbox.GetFirstCharIndexOfCurrentLine();
		}

	}

}
