using System;
using System.Text;
using GodLesZ.eAthenaEditor.Library.Document;
using GodLesZ.eAthenaEditor.Library;
using System.Collections.Generic;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptFormattingStrategy : DefaultFormattingStrategy {
		private static readonly char[] whitespaceChars = { ' ', '\t' };
		private static readonly List<string> mIndentationChars = new List<string>(
			new string[] {
				"{",
				")" // only the next line
			}
		);


		public ScriptFormattingStrategy()
			: base() {
		}


		/// <summary>
		/// Description
		/// </summary>
		private string GetIndentationSmart(TextArea textArea, int lineNumber) {
			if (lineNumber < 0 || lineNumber > textArea.Document.TotalNumberOfLines) {
				throw new ArgumentOutOfRangeException("lineNumber");
			}

			//! TODO:
			//			- search backward the last symbol
			//			- on { or ), indend by \t
			//			- think about more indentation style
			//			- remember last ) and set next indentation -1

			LineSegment lastLine = textArea.Document.GetLineSegment(lineNumber);
			if (lastLine == null || lastLine.Words.Count == 0) {
				// No text in the last line
				return "";
			}

			// Fetch leading space of last line
			string lastLeading = GetIndentation(textArea, lineNumber);
			TextWord lastWord = lastLine.Words[lastLine.Words.Count - 1];
			if (lastWord.Type != TextWordType.Word) {
				return lastLeading;
			}
			if (mIndentationChars.Contains(lastWord.Word.Trim()) == false) {
				return lastLeading;
			}

			return lastLeading + "\t";
		}

		protected override int AutoIndentLine(TextArea textArea, int lineNumber) {
			string indentation = lineNumber != 0 ? GetIndentationSmart(textArea, lineNumber - 1) : "";
			if (indentation.Length > 0) {
				string newLineText = indentation + TextUtilities.GetLineAsString(textArea.Document, lineNumber).Trim();
				LineSegment oldLine = textArea.Document.GetLineSegment(lineNumber);
				SmartReplaceLine(textArea.Document, oldLine, newLineText);
			}
			return indentation.Length;
		}


		/// <summary>
		/// Could be overwritten to define more complex indenting.
		/// </summary>
		protected override int SmartIndentLine(TextArea textArea, int line) {
			return AutoIndentLine(textArea, line); // smart = autoindent in normal texts
		}

		/// <summary>
		/// This function formats a specific line after <code>ch</code> is pressed.
		/// </summary>
		/// <returns>
		/// the caret delta position the caret will be moved this number
		/// of bytes (e.g. the number of bytes inserted before the caret, or
		/// removed, if this number is negative)
		/// </returns>
		public override void FormatLine(TextArea textArea, int line, int cursorOffset, char ch) {
			if (ch == '\n') {
				textArea.Caret.Column = IndentLine(textArea, line);
			}
		}

		/// <summary>
		/// This function sets the indentlevel in a range of lines.
		/// </summary>
		public override void IndentLines(TextArea textArea, int begin, int end) {
			textArea.Document.UndoStack.StartUndoGroup();
			for (int i = begin; i <= end; ++i) {
				IndentLine(textArea, i);
			}
			textArea.Document.UndoStack.EndUndoGroup();
		}

		public override int SearchBracketBackward(IDocument document, int offset, char openBracket, char closingBracket) {
			int brackets = -1;
			int lineStart = document.GetLineNumberForOffset(offset);
			int openMultilineComments = 0;
			// find the matching bracket if there is no string/comment in the way
			for (int i = offset; i >= 0; i--) {
				char ch = document.GetCharAt(i);
				if (ch == openBracket) {
					// Found a bracket, check if we are in a comment line
					int testOffset = IsInCommentLine(document, i);

					// nothing found, count bracket
					if (testOffset < 0) {
						brackets++;
						if (brackets == 0)
							return i;
					} else {
						i = testOffset;
					}
				} else if (ch == closingBracket) {
					// Found a bracket, check if we are in a comment line
					int testOffset = IsInCommentLine(document, i);

					// nothing found, count bracket
					if (testOffset < 0) {
						brackets--;
					} else {
						i = testOffset;
					}
				} else if (ch == '"') {
					// Tricky..
					// We dont know, if this is start of a quote or end of it >.>
					// Best thing we can do is check for next quote in the same line
					int startOffset = i;
					for (i--; i >= 0; i--) {
						ch = document.GetCharAt(i);
						if (ch == '"') {
							// Found next quote in front of the last
							// Now we can assume that the quote starts here
							break;
						} else if (ch == '\n') {
							// We are 1 line before the quote.. and didnt found a previous quote
							// Assume the found quote was the start of a string
							// So just reset our iterator
							i = startOffset;
							break;
						}
					}
				} else if (ch == '/' && i > 0) {
					ch = document.GetCharAt(i - 1);
					if (ch == '/') {
						// Bracket is after a line comment, dont highlight
						if (document.GetLineNumberForOffset(i) == lineStart) {
							break;
						}
						// Reached start of line comment, nothing to do
						i--;
					} else if (ch == '*') {
						// This means, we encounter a multiline comment end
						// So skip everthing until comment start
						for (i -= 2; i >= 0; i--) {
							ch = document.GetCharAt(i);
							if (ch == '*') {
								if (i > 0 && document.GetCharAt(i - 1) == '/') {
									break;
								}
							}
						}
						// End of text or comment
						i--;
					} else if ((i + 1) < document.TextLength && (ch = document.GetCharAt(i + 1)) == '*') {
						// This means, we encounter the start of a multiline comment
						// If we found a ENDING comment in a previous run, this is the start of it
						// So the bracket is not IN this comment
						if (openMultilineComments == 0) {
							// The counter is 0, so we didnt found a ending comment yet
							// this means, our bracket comes after the current multiline comment start
							// and we dont highlight it
							break;
						}
						// Yep we found a multiline start
						openMultilineComments++;
					}
				} else if (ch == '*' && (i + 1) < document.TextLength) {
					ch = document.GetCharAt(i + 1);
					if (ch == '/') {
						// This means, we encounter the end of a multiline comment
						// So we have to find a start of it
						openMultilineComments--;
					}
				}
			}

			return -1;
		}

		private int IsInCommentLine(IDocument document, int i) {
			for (; i >= 0; i--) {
				char ch = document.GetCharAt(i);
				// Found a newline, means we havent found a comment in front of the target line
				if (ch == '\n') {
					return -1;
				}
				if (i > 0 && ch == '/' && document.GetCharAt(i - 1) == '/') {
					i--;
					break;
				}
			}
			return i;
		}

		public override int SearchBracketForward(IDocument document, int offset, char openBracket, char closingBracket) {
			int brackets = 1;
			// Before searching matching brackets, check if we are in a comment line
			for (int i = offset; i >= 0; i--) {
				char ch = document.GetCharAt(i);
				if (ch == '\n') {
					// Next line above bracket start, so no line comment can kill us
					break;
				} else if (ch == '/' && i > 0 && (ch = document.GetCharAt(i - 1)) == '/') {
					return -1;
				}
			}
			// find the matching bracket if there is no string/comment in the way
			for (int i = offset; i < document.TextLength; i++) {
				char ch = document.GetCharAt(i);
				if (ch == openBracket) {
					brackets++;
				} else if (ch == closingBracket) {
					brackets--;
					if (brackets == 0)
						return i;
				} else if (ch == '"') {
					// Tricky..
					// We dont know, if this is start of a quote or end of it >.>
					// Best thing we can do is check for next quote in the same line
					int startOffset = i;
					for (; i < document.TextLength; i++) {
						ch = document.GetCharAt(i);
						if (ch == '"') {
							// Found next quote after the last
							// Now we can assume that the quote ends here
							break;
						} else if (ch == '\n') {
							// We are at the end of the line.. and didnt found a previous quote
							// Assume the found quote was the start of a string
							// So just reset our iterator
							i = startOffset;
							break;
						}
					}
				} else if (ch == '/' && (i + 1) < document.TextLength) {
					ch = document.GetCharAt(i + 1);
					if (ch == '/') {
						// SKip until newline
						for (i++; i < document.TextLength; i++) {
							if ((ch = document.GetCharAt(i)) == '\n') {
								break;
							}
						}
						// Reached end of line
					} else if (ch == '*') {
						// This means, we encounter the start of a multiline comment
						// So skip until comment closed (start after *)
						for (i += 2; i < document.TextLength; i++) {
							if ((ch = document.GetCharAt(i)) == '*') {
								if ((i + 1) < document.TextLength && document.GetCharAt(i + 1) == '/') {
									break;
								}
							}
						}
						// Reached end of text of comment
						i++;
					}
				} else if (ch == '*' && (i + 1) < document.TextLength) {
					ch = document.GetCharAt(i + 1);
					if (ch == '/') {
						// This means, we encounter the end of a multiline comment
						// And because of we skip everthing after a comment start, this means that the bracket
						// is in a multiline comment
						// And we dont highlight it
						break;
					}
				}
			}
			return -1;
		}




		private int SkipBackwardChar(IDocument document, char searchChar, int i) {
			for (; i >= 0; i--) {
				if (document.GetCharAt(i) == searchChar) {
					return i;
				}
			}
			return -1;
		}

		private int SkipBackwardString(IDocument document, string searchString, int i) {
			for (; i >= 0; i--) {
				// Compare first char
				char ch = document.GetCharAt(i);
				if (ch == searchString[0]) {
					// First char match, compare rest of string
					int s = 1;
					for (i--; s < searchString.Length && i >= 0; i--, s++) {
						// Match kill, break it
						if (searchString[s] != document.GetCharAt(i)) {
							break;
						}
					}

					// Did we searched until string length?
					if (s >= searchString.Length) {
						// return current position + string length, this is searchString start position
						return i + searchString.Length - 1;
					}
				}
			}

			return -1;
		}


		private int SkipForwardChar(IDocument document, char searchChar, int i) {
			for (; i < document.TextLength; i++) {
				if (document.GetCharAt(i) == searchChar) {
					return i;
				}
			}
			return -1;
		}

		private int SkipForwardString(IDocument document, string searchString, int i) {
			for (; i < document.TextLength; i++) {
				// Compare first char
				if (document.GetCharAt(i) == searchString[0]) {
					// First char match, compare rest of string
					int s = 1;
					for (; s < searchString.Length && i < document.TextLength; i++, s++) {
						// Match kill, break it
						if (searchString[s] != document.GetCharAt(i)) {
							break;
						}
					}

					// Did we searched until string length?
					if (s >= searchString.Length) {
						// return current position - string length, this is searchString start position
						return i - searchString.Length;
					}
				}
			}

			return -1;
		}

	}

}
