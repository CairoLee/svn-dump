using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.eAthenaEditor.Library.Document;
using System.Text.RegularExpressions;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	/// <summary>
	/// The class to generate the foldings, it implements GodLesZ.eAthenaEditor.Library.Document.IFoldingStrategy
	/// </summary>
	public class RegionFoldingStrategy : IFoldingStrategy {
		/// <summary>
		/// Generates the foldings for our document.
		/// </summary>
		/// <param name="document">The current document.</param>
		/// <param name="fileName">The filename of the document.</param>
		/// <param name="parseInformation">Extra parse information, not used in this sample.</param>
		/// <returns>A list of FoldMarkers.</returns>
		public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation) {
			List<FoldMarker> markers = new List<FoldMarker>();
			ScriptEntityManager functions = new ScriptEntityManager();
			Regex regexFunction = new Regex(@"^[^\t]+\tscript\t(.+)\t([^{\n]*){$", RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);

			Match match = null;

			Stack<int> startComments = new Stack<int>();
			Stack<int> startBrackets = new Stack<int>();

			// Create foldmarkers for the whole document, enumerate through every line.
			for (int i = 0; i < document.TotalNumberOfLines; i++) {
				LineSegment seg = document.GetLineSegment(i);
				string line = document.GetText(seg);
				int offset = -1, end = -1;

				// I combined the request with [else if]
				// So a { } wont count; only on different lines

				if ((offset = line.IndexOf("/*")) != -1) {
					// start at next line, if present
					if ((i + 1) < document.TotalNumberOfLines) {
						// dont count the comment if a closing one follows on the same line after it
						if (line.Length <= (offset + 1) || line.IndexOf("*/", offset + 2) == -1) {
							//seg = document.GetLineSegment(i + 1);
							//offset = seg.Offset;
							offset = seg.Offset + offset + 2; // real start is SegmentStart + IndexOf
							startComments.Push(offset);
						}
					}
				} else if ((end = line.IndexOf("*/")) != -1) {
					if (startComments.Count > 0) {
						offset = startComments.Pop();
						end = (seg.Offset + end); // real end is SegmentStart + IndexOf
						markers.Add(new FoldMarker(document, offset, (end - offset), "...", false));
					}
				}

				if ((match = regexFunction.Match(line)).Success == true) {
					string name = match.Groups[1].Captures[0].Value;

					functions.Add(new ScriptEntityFunction(name, false, seg.Offset, match.Index));

					// Offset of {
					offset = seg.Offset + match.Index + match.Length;
					// start at next line, if present
					if ((i + 1) < document.TotalNumberOfLines) {
						// dont count the bracket if a closing one follows on the same line after it
						if (line.Length <= (match.Index + match.Length + 1) || line.IndexOf('}', match.Index + match.Length + 1) == -1) {
							//seg = document.GetLineSegment(i + 1);
							startBrackets.Push(offset - 1);
						}
					}
				} else if ((end = line.IndexOf('}')) != -1) {
					// only counts on another line AND not in comment
					if (startComments.Count == 0 && startBrackets.Count > 0) {
						offset = startBrackets.Pop();
						// end of bracket folding is CurrentSegment.Offset - 1 => 1 line before
						end = seg.Offset + 1;
						int len = (end - offset);
						markers.Add(new FoldMarker(document, offset, len, "...", false));
					}
				}

			}

			return markers;
		}
	}

}
